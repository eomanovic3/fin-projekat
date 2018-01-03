using ebs.db;
using ebs;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using ebs.Models;

namespace ebs.Controllers
{
    public class GenerateChartController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();
             // GET: GenerateChart
        public ActionResult GenerateChart()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GenerateChart(string xOsa, string yOsa, string chartChoice)
        {
            TempData["xOsa"] = xOsa;
            TempData["yOsa"] = yOsa;
            ViewData["chartChoice"] = chartChoice;
            return View();
        }
        public JsonResult ChartBarAndDonutData()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = "SELECT COUNT(d." + TempData["xOsa"] + "), a." + TempData["yOsa"] + " FROM  BP07.academicyear a, BP07.course_department b, BP07.labgroup c, BP07.user_enrollment d, BP07.studyyear e WHERE  a.id = b.academicyearid AND c.course_departmentid = b.id  AND d.labgroupid = c.id AND e.id = d.studyyearid AND(d.studyyearid = 1 OR d.studyyearid = 2 OR d.studyyearid = 3)  GROUP BY a.title  ORDER BY a.title ASC";

                //  string query = "SELECT Sum(b." + TempData["xOsa"] + "), a." + TempData["yOsa"] + " AS opis FROM bp07.TypeOfEmployee a, bp07.EmployeeDetails b WHERE b.typeofemployeeid = a.id GROUP BY a.description";
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                List<float> result = new List<float>();
                List<string> result2 = new List<string>();

                while (rd.Read())
                {
                    result.Add(rd.GetFloat(0));
                    result2.Add(rd.GetString(1));
                }
                Chart _chart = new Chart();
                _chart.labels = result2;
                _chart.datasets = new List<Datasets>();
                List<Datasets> _dataSet = new List<Datasets>();
                _dataSet.Add(new Datasets()
                {
                    label = "Chart View",
                    data = result,
                    backgroundColor = new List<string> { "#FF0000", "#800000", "#808000", "#008080", "#800080", "#0000FF", "#000080", "#999999", "#E9967A", "#CD5C5C", "#1A5276", "#27AE60" },
                    borderColor = new List<string> { "#FF0000", "#800000", "#808000", "#008080", "#800080", "#0000FF", "#000080", "#999999", "#E9967A", "#CD5C5C", "#1A5276", "#27AE60" },
                    borderWidth = new List<string> { "1" }
                });
                _chart.datasets = _dataSet;
                conn.conn.Close();
                return Json(_chart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                conn.conn.Close();
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult ChartRadarAndLineData()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = "SELECT COUNT(d." + TempData["xOsa"] + "), a." + TempData["yOsa"] + " FROM  BP07.academicyear a, BP07.course_department b, BP07.labgroup c, BP07.user_enrollment d, BP07.studyyear e WHERE  a.id = b.academicyearid AND c.course_departmentid = b.id  AND d.labgroupid = c.id AND e.id = d.studyyearid AND(d.studyyearid = 1 OR d.studyyearid = 2 OR d.studyyearid = 3)  GROUP BY a.title  ORDER BY a.title ASC";

                //  string query = "SELECT Sum(b." + TempData["xOsa"] + "), a." + TempData["yOsa"] + " AS opis FROM bp07.TypeOfEmployee a, bp07.EmployeeDetails b WHERE b.typeofemployeeid = a.id GROUP BY a.description";
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                List<float> result = new List<float>();
                List<string> result2 = new List<string>();

                while (rd.Read())
                {
                    result.Add(rd.GetFloat(0));
                    result2.Add(rd.GetString(1));
                }
                Chart _chart = new Chart();
                _chart.labels = result2;
                _chart.datasets = new List<Datasets>();
                List<Datasets> _dataSet = new List<Datasets>();
                _dataSet.Add(new Datasets()
                {
                    label = "Chart view",
                    data = result,
                    backgroundColor = new List<string> { "rgba(200,0,0,0.2)" },
                    borderColor = new List<string> { "rgba(200,0,0,0.2)" },
                    borderWidth = new List<string> { "1" }
                });
                _chart.datasets = _dataSet;
                conn.conn.Close();
               return Json(_chart, JsonRequestBehavior.AllowGet);
            }
            else
            {
                conn.conn.Close();
                return Json(alldata, JsonRequestBehavior.AllowGet);
            }

        }

    }
}
