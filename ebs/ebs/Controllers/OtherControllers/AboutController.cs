using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult About()
        {
            if (Session["Username"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                Console.WriteLine(Session["Username"]);
                return View();
            }
        }
    }
}