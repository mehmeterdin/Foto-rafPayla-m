using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeOdevi.ViewModels
{
    public class KisiIndex
    {
        public IEnumerable<Kisi> Kisiler { get; set; }
    }
    public class KisiNew
    {
        [Required, MaxLength(128)]
        public string Username { get; set; }

        [Required, DataType(DataType.Password), MinLength(5)]
        public string Password { get; set; }
    }
}