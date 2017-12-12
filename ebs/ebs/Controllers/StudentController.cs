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

        public JsonResult GetDataForChartBacheleor()
        {
            MySqlCommand cmd = new MySqlCommand("SELECT count(year_of_study) AS number_of_students, year_of_study FROM mydb.student WHERE degree = 'Bacheleor' group by year_of_study desc;", conn.conn);
           // OracleCommand cmd = new OracleCommand("SELECT COUNT(a.userid) AS number_of_students, b.title as titles FROM  BP07.studyyear b, BP07.user_enrollment a WHERE a.studyyearid = b.id GROUP BY b.title ORDER BY COUNT(a.userid) ASC ", conn.conn);
           //iznad je query kako bi dobio/la sve studente po godina, First Bachelor 89, Second Bachelor 122 i tako dalje
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