using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class Employeer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }


        public TradePlace TradePlace { get; set; }
        public int TradePlaceId { get; set; }
    }
}