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
        
        [Required(ErrorMessage = "The Size field is required")]
        [RegularExpression(@"\d{1}", ErrorMessage = "Wrong size")]
        public int Size { get; set; }

        [Required(ErrorMessage = "The Address field is required")]
        [RegularExpression(@"\d{3}" ,ErrorMessage = "Wrong address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The Name field is required")]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public TradePlace()
        {
            Employees = new List<Employee>();
        }
    }
}