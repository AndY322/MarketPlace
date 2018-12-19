using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MarketPlace.Models;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MarketPlace.Controllers
{
    public class HomeController : Controller
    {
        TradePlaceContext db = new TradePlaceContext();


        public ActionResult Index()
        {
            var tradePlaces = db.TradePlaces;
            return View(tradePlaces);
        }


        [HttpGet]
        public ActionResult Remove(int id)
        {
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace == null)
            {
                return HttpNotFound();
            }
            return View(tradePlace);
        }


        [HttpPost, ActionName("Remove")]
        public ActionResult RemoveConfirmed(int id)
        {
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace == null)
            {
                return HttpNotFound();
            }
            db.TradePlaces.Remove(tradePlace);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult AddPlace()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddPlace(TradePlace place)
        {
            db.TradePlaces.Add(place);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditPlace(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if (tradePlace != null)
            {
                return View(tradePlace);
            }
            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult EditPlace(TradePlace tradePlace)
        {
            db.Entry(tradePlace).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


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


        [HttpGet]
        public ActionResult CreateEmployeeOnMainPage()
        {
            SelectList tradePlace = new SelectList(db.TradePlaces, "Id", "Name");
            ViewBag.tradePlace = tradePlace;
            return View();
        }


        [HttpPost]
        public ActionResult CreateEmployeeOnMainPage(Employee employee)
        {
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


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
            db.SaveChanges();
            return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
        }


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


        [HttpPost, ActionName("AddEmployee")]
        public ActionResult AddEmployeePost(Employee employee)
        {
            if (employee == null)
            {
                HttpNotFound();
            }
            db.Employees.Add(employee);
            db.SaveChanges();
            return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
        }


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


        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            if(employee == null)
            {
                return HttpNotFound();
            }
            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ShowDetails", new { id = employee.TradePlaceId });
        }
    }
}