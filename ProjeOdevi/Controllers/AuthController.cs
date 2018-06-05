using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NHibernate;
using NHibernate.Linq;
using ProjeOdevi.Models;
using ProjeOdevi.ViewModels;

namespace ProjeOdevi.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login( )
        {
            return View();
        }
        public ActionResult Register()
        {
            return View( new KisiNew() { });
        }
        [HttpPost]
        public ActionResult Login (AuthLogin formdata)
        {

            if (!ModelState.IsValid)
            {
                return View(formdata);
            }
            FormsAuthentication.SetAuthCookie(formdata.Username, false);
            if (Database.Session.Query<Kisi>().Any(x=> x.Username == formdata.Username && x.PasswordHash == formdata.Password))
            {
                formdata.Id = Database.Session.Query<Kisi>().Where(x => x.Username == formdata.Username).Select(x => x.Id).FirstOrDefault();
                Session.Add("onlineID", formdata.Id);
                return RedirectToRoute("Home");
            }
            return View(formdata);
            

        }
        [HttpPost]
        public ActionResult Register(KisiNew formdata)
        {
            if (Database.Session.Query<Kisi>().Any(x => x.Username == formdata.Username))
            {
                ModelState.AddModelError("Username", "Username  must be unique");
            }

            if (!ModelState.IsValid)
            {
                return View(formdata);
            }

            var kisi = new Kisi()
            {
                Username = formdata.Username,
                PasswordHash = formdata.Password
            };

            Database.Session.Save(kisi);



            return RedirectToRoute("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToRoute("Home");
        }
        public ActionResult kullanicilar()
        {
            int onlineID = Convert.ToInt32(Session["onlineID"]);
            var idler = new takipEdilenIdler();
            idler.takipedilenler = Database.Session.Query<KisiTakip>().Where(x => x.kisiID == onlineID).Select(x => x.takipettigiID).ToList();
            var kisiler = new KisiIndex()
            {
                Kisiler = Database.Session.Query<Kisi>().Where(x =>  !idler.takipedilenler.Contains(x.Id) && x.Id != onlineID).ToList()
            };
            
            return View(kisiler);
        }
        
        public ActionResult takipEdilenKullanicilar()
        {
            int onlineID = Convert.ToInt32(Session["onlineID"]);
            var idler = new takipEdilenIdler();
            idler.takipedilenler = Database.Session.Query<KisiTakip>().Where(x => x.kisiID == onlineID).Select(x => x.takipettigiID).ToList();
            var kisiler = new KisiIndex()
            {
                Kisiler = Database.Session.Query<Kisi>().Where(x => idler.takipedilenler.Contains(x.Id)).ToList()
            };

            return View(kisiler);
        }
        public ActionResult UnFollow(int id)
        {
            var kisi = Database.Session.Query<KisiTakip>().Where(x => x.takipettigiID == id).FirstOrDefault();
            if (kisi == null)
            {
                return HttpNotFound();
            }
            using (ITransaction trans = Database.Session.BeginTransaction())
            {
                Database.Session.Delete(kisi);
                trans.Commit();
            }
            return RedirectToRoute("Following");
        }

        public ActionResult Takip(int id)
        {

            var takiplesme = new KisiTakip()
            {
                kisiID = Convert.ToInt32(Session["onlineID"]),
                takipettigiID = id
            };

            Database.Session.Save(takiplesme);

            return RedirectToRoute("Kullanicilar");

            //takipten çıkma için 
            //    var kisi = Database.Session.Query<Kisi>().Where(x => x.Id == takipedilecekid).FirstOrDefault();
            //    if (kisi == null)
            //    {
            //        return HttpNotFound();
            //    }
            //    Database.Session.Delete(kisi);
        }

    }
}