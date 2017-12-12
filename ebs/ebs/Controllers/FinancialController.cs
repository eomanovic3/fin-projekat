using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class FinancialController : Controller
    {
        // GET: Financial
        public ActionResult Financial()
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

        public JsonResult GetBar()
        {
            List<string> returnData = new List<string>();

            returnData.Add("33.1");
            returnData.Add("14.5");
            returnData.Add("11.8");
            returnData.Add("10.2");
            returnData.Add("10.4");

            return Json(returnData, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPie()
        {
            List<string> returnData = new List<string>();

            returnData.Add("1750");
            returnData.Add("6250");

            return Json(returnData, JsonRequestBehavior.AllowGet);
        }
    }
}