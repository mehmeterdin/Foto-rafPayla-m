using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Mapping.ByCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.Models
{
    public class Kisi
    {

        public virtual int Id { get; set; }
        public virtual string Username { get; set; }
        public virtual string PasswordHash{ get; set; }

    }
    public class KisiMap : ClassMapping<Kisi>
    {
        public KisiMap()
        {
            Table("kisi");
            
            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.Username, x => x.NotNullable(true));
            Property(x => x.PasswordHash, x => x.NotNullable(true));
        }
    }
}