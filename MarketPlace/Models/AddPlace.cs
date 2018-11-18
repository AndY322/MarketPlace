using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class AddPlace
    {
        public int AddPlaceId { get; set; }
        public int PlaceId { get; set; }
        public DateTime AddDate { get; set; }
        public string Owner { get; set; }
    }
}