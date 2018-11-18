using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MarketPlace.Models
{
    public class TradePlaceContext : DbContext
    {

        public DbSet<TradePlace> TradePlaces { get; set; }
        public DbSet<AddPlace> AddPlaces { get; set; }
        public DbSet<RemoveTradePlace> RemoveTradePlaces { get; set; }
    }

    public class PlaceDbInitializer :  DropCreateDatabaseAlways<TradePlaceContext>
    {
        protected override void Seed(TradePlaceContext db)
        {
            db.TradePlaces.Add(new TradePlace { Name = "FlowerMarket", Address = 101, Size = 2 });
            db.TradePlaces.Add(new TradePlace { Name = "GrocecryStore", Address = 102, Size = 1 });
            db.TradePlaces.Add(new TradePlace { Name = "McDonalds", Address = 103, Size = 3 });
        }
    }
}