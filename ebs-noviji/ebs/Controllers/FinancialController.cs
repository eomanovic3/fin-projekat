using ebs.db;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers
{
    
    public class FinancialController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: Financial
        public ActionResult Financial()
        {
                return View();
        }

        public JsonResult GetDataForChartAll()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = "SELECT Sum(b.salary) AS plata, a.description AS opis FROM bp07.TypeOfEmployee a, bp07.EmployeeDetails b WHERE b.typeofemployeeid = a.id GROUP BY a.description";
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                List<string> result = new List<string>();

                while (rd.Read())
                {
                    result.Add(rd.GetFloat(0).ToString());
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