using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjeOdevi.ViewModels
{
    public class AuthLogin
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required]
        [DataType("Password")]
        [DisplayName("Password")]
        [MinLength(5)]
        public string Password { get; set; }
    }
}