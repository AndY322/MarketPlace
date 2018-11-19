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
            IEnumerable<TradePlace> places = db.TradePlaces;
            ViewBag.TradePlaces = places;
            return View();
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
    }
}