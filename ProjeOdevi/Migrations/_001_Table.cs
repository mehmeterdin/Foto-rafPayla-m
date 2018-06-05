using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjeOdevi.Migrations
{
    [Migration(1)]
    public class _001_Table : Migration
    {
        public override void Down()
        {
            Delete.Table("kisi");
            Delete.Table("post");
            Delete.Table("kisitakip");

        }

        public override void Up()
        {
            Create.Table("kisi")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("username").AsString(128)
                .WithColumn("passwordhash").AsString(256);

            Create.Table("post")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("resimUrl").AsString(256)
                .WithColumn("kisiID").AsInt32().ForeignKey("kisi", "Id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("yorum").AsString(256)
                .WithColumn("begeni").AsInt32()
                .WithColumn("tarih").AsDateTime();

            Create.Table("kisitakip")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey()
                .WithColumn("kisiID").AsInt32().ForeignKey("kisi", "Id").OnDelete(System.Data.Rule.Cascade)
                .WithColumn("takipettigiID").AsInt32().ForeignKey("kisi", "Id").OnDelete(System.Data.Rule.Cascade);

        }
    }
}