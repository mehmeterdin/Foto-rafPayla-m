using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string resimURL { get; set; }
        public virtual int kisiID { get; set; }
        public virtual string yorum { get; set; }
        public virtual int begeni { get; set; }
        public virtual DateTime tarih { get; set; }
    }
    public class PostMap : ClassMapping<Post>
    {
        public PostMap()
        {
            Table("post");

            Id(x => x.Id, x => x.Generator(Generators.Identity));

            Property(x => x.resimURL, x => x.NotNullable(true));
            Property(x => x.kisiID, x => x.NotNullable(true));
            Property(x => x.yorum);
            Property(x => x.begeni);
            Property(x => x.tarih);
        }
    }
}