using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class AcademicController : Controller
    {
        public ActionResult Academic()
        {
            if (Session["Username"] == null)
            {
                Session.Abandon();
                return RedirectToAction("Index", "Home");
            } 
            else
            {
                return View();
            }
        }
    }
}