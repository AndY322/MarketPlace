using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketPlace.Models
{
    public class TradePlace
    {
        public int Id { get; set; }
        public int Size { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }

        public ICollection<Employeer> Employeers { get; set; }

        public TradePlace()
        {
            Employeers = new List<Employeer>();
        }
    }
}