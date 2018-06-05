using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.Models
{
    public class KisiTakip
    {
        public virtual int Id { get; set; }
        public virtual int kisiID { get; set; }
        public virtual int takipettigiID { get; set; }

    }
    public class KisiTakipMap : ClassMapping<KisiTakip>
    {
        public KisiTakipMap()
        {
            Table("kisitakip");

            Id(x => x.Id, x => x.Generator(Generators.Identity));


            Property(x => x.kisiID, x => x.NotNullable(true));
            Property(x => x.takipettigiID, x => x.NotNullable(true));
        }
            
    }

}