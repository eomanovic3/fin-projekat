using ebs.db;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class StudentController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        public ActionResult Student()
        {
            return View();
        }

        public JsonResult GetDataForChartAll()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = "SELECT Count(d.userid),a.title FROM BP07.academicyear a, BP07.course_department b, BP07.labgroup c, BP07.user_enrollment d WHERE a.id = b.academicyearid AND c.course_departmentid = b.id  AND d.labgroupid = c.id GROUP BY a.title ORDER BY a.title ASC";
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (rd.Read())
                {
                    result.Add(rd.GetInt32(0).ToString());
                }

                alldata = result;
                conn.conn.Close();
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }
        }


    }
}