using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjeOdevi.ViewModels
{
    public class takipEdilenIdler
    {
        public List <int> takipedilenler { get; set; }
    }
    public class postIndex
    {
        public IEnumerable<Post> post { get; set; }
    }
    public class postadd
    {
        
        public int kisiID { get; set; }
        
        public string resimUrl { get; set; }
        [DisplayName("Yorum")]
        public string Yorum { get; set; }
        
        [DisplayName("Like")]
        public int Like { get; set; }

        
        [DisplayName("Tarih")]
        public DateTime Tarih { get; set; }
    }
}