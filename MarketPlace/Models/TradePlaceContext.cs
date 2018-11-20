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
        public DbSet<Employeer> Employeers { get; set; }
    }
}