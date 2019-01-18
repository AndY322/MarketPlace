using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class Employee
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "The Name field is required")]
        [MaxLength(50, ErrorMessage = "Max size 50 letter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Surname field is required")]
        [MaxLength(50, ErrorMessage = "Max size 50 letter")]
        public string Surname { get; set; }

        [MaxLength(50, ErrorMessage = "Max size 50 letter")]
        public string Post { get; set; }

        public TradePlace TradePlace { get; set; }
        
        public int TradePlaceId { get; set; }
    }
}