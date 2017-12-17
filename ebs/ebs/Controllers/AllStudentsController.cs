using ebs.db;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    public class AllStudentsController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: AllStudents
        public ActionResult AllStudents()
        {
            return View();
        }

        public JsonResult GetDataForChartAll()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = "SELECT Count(id) FROM BP07.USER_ENROLLMENT WHERE studyyearid in (SELECT id FROM BP07.STUDYYEAR WHERE title = 'First Bachelor' OR title = 'Second Bachelor' OR title = 'Third Bachelor')";
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                rd.Read();

                int bachelor = rd.GetInt32(0);

                string query2 = "SELECT Count(id) FROM BP07.USER_ENROLLMENT WHERE studyyearid in (SELECT id FROM BP07.STUDYYEAR WHERE title = 'First Masters' OR title = 'Second Masters')";
                OracleCommand cmd2 = new OracleCommand(query2, conn.conn);
                OracleDataReader rd2 = cmd2.ExecuteReader();

                rd2.Read();

                int master = rd2.GetInt32(0);

                string query3 = "SELECT Count(id) FROM BP07.USER_ENROLLMENT WHERE studyyearid in (SELECT id FROM BP07.STUDYYEAR WHERE title = 'First PhD' OR title = 'Second PhD' OR title = 'Third PhD')";
                OracleCommand cmd3 = new OracleCommand(query3, conn.conn);
                OracleDataReader rd3 = cmd3.ExecuteReader();

                rd3.Read();

                int phd = rd3.GetInt32(0);

                List<string> result = new List<string>();
                result.Add(bachelor.ToString());
                result.Add(master.ToString());
                result.Add(phd.ToString());
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