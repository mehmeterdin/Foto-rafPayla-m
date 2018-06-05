using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjeOdevi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Home","",new {controller = "Posts" , action = "Index" });
            routes.MapRoute("Login", "login", new { controller = "Auth", action = "Login" });
            routes.MapRoute("Register", "register", new { controller = "Auth", action = "Register" });
            routes.MapRoute("Logout", "logout", new { controller = "Auth", action = "Logout" });
            routes.MapRoute("NewPost", "newpost", new { controller = "Posts", action = "newPost" });
            routes.MapRoute("Kullanicilar", "members", new { controller = "Auth", action = "kullanicilar" });
            routes.MapRoute("Takip", "takip", new { controller = "Auth", action = "Takip" });
            routes.MapRoute("Following", "following", new { controller = "Auth", action = "takipEdilenKullanicilar" });
            routes.MapRoute("UnFollow", "unfollow", new { controller = "Auth", action = "UnFollow" });
            routes.MapRoute("Profil", "profil", new { controller = "Posts", action = "Profil" });
            routes.MapRoute("PostSil", "postsil", new { controller = "Posts", action = "PostSil" });
        }
    }
}
