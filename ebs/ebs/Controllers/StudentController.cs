using ebs.db;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class StudentController : Controller
    {
        DBConnection conn = new DBConnection();

        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        public JsonResult GetDataForChartBacheleor()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Bacheleor' group by year_of_study desc;", conn.conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            //OracleCommand cmd = new OracleCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Bacheleor' group by year_of_study desc;", conn.conn);
            //OracleDataReader rd = cmd.ExecuteReader();

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

            //OracleCommand cmd = new OracleCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Master' group by year_of_study desc;", conn.conn);
            //OracleDataReader rd = cmd.ExecuteReader();

            List<string> returnData = new List<string>();

            while (rd.Read() && returnData.Count() < 5)
            {
                returnData.Add(rd["number_of_students"].ToString());
            }

            var pom = Json(returnData, JsonRequestBehavior.AllowGet);

            return Json(returnData, JsonRequestBehavior.AllowGet);
        }
    }
}