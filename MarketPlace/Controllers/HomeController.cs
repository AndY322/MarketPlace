using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlace.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using PagedList.Mvc;
using PagedList;
using Microsoft.AspNet.Identity.EntityFramework;
using MarketPlace.Attribute;

namespace MarketPlace.Controllers
{
    public class HomeController : Controller
    {
        TradePlaceContext db = new TradePlaceContext();

        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);
            var tradePlace = from tp in db.TradePlaces
                             select tp;

            if (!String.IsNullOrEmpty(searchString))
            {
                ViewBag.searchString = searchString;
                tradePlace = tradePlace.Where(s => s.Name.Contains(searchString));
            }
            var tpList = tradePlace.ToList();
            return View(tpList.ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        [Auth(Roles = "Admin")]
        public ActionResult Remove(int id)
        {
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace == null)
            {
                return HttpNotFound();
            }
            return View(tradePlace);
        }


        [Auth(Roles = "Admin")]
        [HttpPost, ActionName("Remove")]
        public ActionResult RemoveConfirmed(int id)
        {
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace == null)
            {
                return HttpNotFound();
            }
            db.TradePlaces.Remove(tradePlace);
            db.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [Auth(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddPlace()
        {
            return View();
        }


        [Auth(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddPlace(TradePlace place)
        {
            if (ModelState.IsValid)
            {
                db.TradePlaces.Add(place);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }


        [Auth(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditPlace(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace != null)
            {
                return View(tradePlace);
            }
            return RedirectToAction("Index");
        }


        [Auth(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditPlace(TradePlace tradePlace)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tradePlace).State = EntityState.Modified;
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tradePlace);
        }


        [Authorize]
        [HttpGet]
        public ActionResult ShowDetails(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = db.Employees.Include(e => e.TradePlace).Where(e => e.TradePlaceId == id);
            var tradePlace = db.TradePlaces.Find(id);
            ViewBag.tradePlace = tradePlace;
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [Auth(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateEmployeeOnMainPage()
        {
            SelectList tradePlace = new SelectList(db.TradePlaces, "Id", "Name");
            ViewBag.tradePlace = tradePlace;
            return View();
        }


        [Auth(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateEmployeeOnMainPage(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            SelectList tradePlace = new SelectList(db.TradePlaces, "Id", "Name");
            ViewBag.tradePlace = tradePlace;
            return View();
        }


        [Auth(Roles = "Admin")]
        public ActionResult DeleteEmployee(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            db.Employees.Remove(employee);
            db.SaveChangesAsync();
            return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
        }


        [Auth(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddEmployee(int id)
        {
            var tradePlace = db.TradePlaces.Find(id);

            if (tradePlace == null)
            {
                return HttpNotFound();
            }
            ViewBag.tradePlace = tradePlace;
            return View();
        }


        [Auth(Roles = "Admin")]
        [HttpPost, ActionName("AddEmployee")]
        public ActionResult AddEmployeePost(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee == null)
                {
                    HttpNotFound();
                }
                db.Employees.Add(employee);
                db.SaveChangesAsync();
                return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
            }
            var returnView = AddEmployee(employee.TradePlaceId);
            return returnView;
        }


        [Auth(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            var employee = db.Employees.Find(id);
            ViewBag.tradePlace = db.TradePlaces.Find(employee.TradePlaceId);
            if(employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [Auth(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (employee == null)
                {
                    return HttpNotFound();
                }
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChangesAsync();
                return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
            }
            var returnView = EditEmployee(employee.TradePlaceId);
            return returnView;
        }
       

        
    }
}