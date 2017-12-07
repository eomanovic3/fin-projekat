using ebs.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Session["Username"] != null)
            {
                Session.Abandon();
            }

            DBConnection db = new DBConnection();
            return View();
        }
    }
}