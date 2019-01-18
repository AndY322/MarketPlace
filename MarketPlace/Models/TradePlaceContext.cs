using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MarketPlace.Models
{
    public class TradePlaceContext : IdentityDbContext<User>
    {
        public TradePlaceContext() : base("DefaultConnection")
        {}

        public static TradePlaceContext Create()
        {
            return new TradePlaceContext();
        }

        public DbSet<TradePlace> TradePlaces { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}