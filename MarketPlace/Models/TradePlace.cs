using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class TradePlace
    {
        public int Id { get; set; }
        public int Size { get; set; }
        [RegularExpression(@"\d*")]
        public string Address { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public TradePlace()
        {
            Employees = new List<Employee>();
        }
    }
}