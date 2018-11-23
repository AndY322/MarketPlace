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
            if(tradePlace == null)
            {
                return HttpNotFound();
            }
            return View(tradePlace);
        }


        [HttpPost, ActionName("Remove")]
        public ActionResult RemoveConfirmed(int id)
        {
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if(tradePlace == null)
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
            if(id == null)
            {
                return HttpNotFound();
            }
            TradePlace tradePlace = db.TradePlaces.Find(id);
            if(tradePlace != null)
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
        public ActionResult ShowDetails(int id)
        {
            
            var employee = db.Employees.Include(e => e.TradePlace).Where(e => e.TradePlaceId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }


        [HttpPost]
        public ActionResult ShowDetails()
        {
            return RedirectToAction("Index");
        }
    }
}