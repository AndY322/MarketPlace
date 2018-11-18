using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class RemoveTradePlace
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
        public string Person { get; set; }
    }
}