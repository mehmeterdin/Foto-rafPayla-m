using ProjeOdevi.ViewModels;
using ProjeOdevi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using System.IO;
using NHibernate;

namespace ProjeOdevi.Controllers
{
    public class PostsController : Controller
    {
        // GET: Posts
        [Authorize]
        public ActionResult Index()
        {
            int id = Convert.ToInt32(Session["onlineID"]);
            var idler = new takipEdilenIdler();
            idler.takipedilenler = Database.Session.Query<KisiTakip>().Where(x => x.kisiID == id).Select(x => x.takipettigiID).ToList();

            var postlar = new postIndex();
            
            postlar.post = Database.Session.Query<Post>().Where(x=> idler.takipedilenler.Contains(x.kisiID)).ToList();
            
            
            return View(postlar);
           
        }
        public ActionResult newPost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult newPost(postadd post )
        {
            string yol="";
            //var file = Request.Files[0];
            //if (file != null && file.ContentLength > 0)
            //{
            //    StreamReader streamReader = new StreamReader(file.InputStream);
            //    yol = "~/resimler/" + Session["onlineid"].ToString()+ DateTime.Today.ToString() + ".jpg";
            //    FileStream fileStream = new FileStream(yol, FileMode.OpenOrCreate);
            //    Session.Add("yol", yol);
            //}
            var eklenecek = new Post()
            {
                kisiID = Convert.ToInt32(Session["onlineID"]),
                resimURL = post.resimUrl,
                yorum = post.Yorum,
                begeni = 0,
                tarih = DateTime.Today
            };
            Database.Session.Save(eklenecek);

            return RedirectToRoute("Home");
        }
        public ActionResult Profil()
        {
            int id = Convert.ToInt32(Session["onlineID"]);

            var postlar = new postIndex(){
                post=Database.Session.Query<Post>().Where(x => x.kisiID == id)
            };

            return View(postlar);
        }
        public ActionResult PostSil(int id)
        {
            var silinecekpost = Database.Session.Load<Post>(id);
            if (silinecekpost == null)
            {
                return HttpNotFound();
            }
            using (ITransaction trans = Database.Session.BeginTransaction())
            {
                Database.Session.Delete(silinecekpost);
                trans.Commit();
            }
            return RedirectToRoute("Profil");
        }


    }
}