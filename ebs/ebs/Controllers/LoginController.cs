using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using ebs.db;

namespace ebs.Controllers
{
    public class LoginController: Controller
    {
        DBConnection conn = new DBConnection();

        // GET: Login
        public ActionResult Login(FormCollection collection)
        {
            string username = collection["username"];
            string password = collection["password"];

            MySqlCommand cmd = new MySqlCommand("SELECT users.username, users.password FROM mydb.user users WHERE users.username = '" + username +
                "' AND users.password = '" + password + "'" , conn.conn);

            MySqlDataReader rd = cmd.ExecuteReader();

            if(rd.Read())
            {
                Session["Username"] = username;
                Session["Password"] = password;
                return View();

            }

            return RedirectToAction("Index", "Home");
        }

        public JsonResult GetDataForChartBacheleor()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Bacheleor' group by year_of_study desc;", conn.conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            List<string> returnData = new List<string>();

            while (rd.Read() && returnData.Count() < 5)
            {
                returnData.Add(rd["number_of_students"].ToString());
            }

            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDataForChartMaster()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Master' group by year_of_study desc;", conn.conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            List<string> returnData = new List<string>();

            while (rd.Read() && returnData.Count() < 5)
            {
                returnData.Add(rd["number_of_students"].ToString());
            }

            return Json(returnData, JsonRequestBehavior.AllowGet);
        }

        /*public JsonResult GetBar()
        {
            List<double> returnData = new List<double>();

            returnData.Add(33.1);
            returnData.Add(14.5);
            returnData.Add(11.8);
            returnData.Add(10.2);
            returnData.Add(10.4);
            returnData.Add(9.5);
            returnData.Add(4.5);
            returnData.Add(1.1);
            returnData.Add(4.9);
            
            return Json(returnData, JsonRequestBehavior.AllowGet);
        }*/
    }
}