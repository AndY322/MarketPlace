using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MarketPlace.Models
{
    public class RegisterModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [RegularExpression(@"\d*")]
        public int? Age { get; set; }
    }
}