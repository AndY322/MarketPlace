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
            ViewBag.PlaceId = id;
            return View();
        }


        [HttpPost]
        public string Remove(RemoveTradePlace remove)
        {
            remove.Date = DateTime.Now;
            db.RemoveTradePlaces.Add(remove);
            db.SaveChanges();
            return "Торговое место удалено почти";
        }
    }
}