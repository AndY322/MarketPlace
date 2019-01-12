using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public int? Age { get; set; }
    }
}