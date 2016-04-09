using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KhorshidBare.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class KhorshidLogin
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ReturnUrl { get; set; }
    }
}