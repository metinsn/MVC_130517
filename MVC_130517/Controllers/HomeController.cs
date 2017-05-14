using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_130517.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(Session["name"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            string uname = frm.Get("userName");
            string pass = frm.Get("password");
            
            if (uname == "yavuz" && pass == "1234")
            {
                Session["name"] = "yavuz";
                Session["pass"] = "1234";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Mesaj = "Hatalı Bilgiler!";
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login", "Home");
        }
    }
}