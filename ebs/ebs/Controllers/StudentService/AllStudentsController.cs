using ebs.db;
using ebs.Models;
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
        [HttpPost]
        public ActionResult AllStudents(string xOsa, string yOsa)
        {
            TempData["xOsa"] = xOsa;
            TempData["yOsa"] = yOsa;
            return View();
        }


        public JsonResult ChartBarAndDonutDataStudents()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = null;
                if (TempData["yOsa"].ToString() == "title") { 
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b." + TempData["yOsa"] + "  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First Bachelor' OR b.title = 'Second Bachelor' OR b.title = 'Third Bachelor') GROUP BY b.title";
                }
                else if (TempData["yOsa"].ToString() == "title1")
                {
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b.title  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First Masters' OR b.title = 'Second Masters') GROUP BY b.title";
                }
                else if (TempData["yOsa"].ToString() == "title2")
                {
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b.title  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First PhD' OR b.title = 'Second PhD' OR b.title = 'Third PhD') GROUP BY b.title";
                }
               
                OracleCommand cmd = new OracleCommand(query, conn.conn);
                OracleDataReader rd = cmd.ExecuteReader();

                List<float> result= new List<float>();
                List<string> result2 = new List<string>();

                while (rd.Read())
                {
                    result.Add(rd.GetFloat(0));
                    result2.Add(rd.GetString(1));
                }
                System.Diagnostics.Debug.WriteLine(result);
                Chart _chart = new Chart();
                _chart.labels = result2;
                _chart.datasets= new List<Datasets>();
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
        public JsonResult ChartRadarAndLineDataStudents()
        {
            if (alldata == null)
            {
                conn.conn.Open();

                string query = null;
                if (TempData["yOsa"].ToString() == "title")
                {
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b." + TempData["yOsa"] + "  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First Bachelor' OR b.title = 'Second Bachelor' OR b.title = 'Third Bachelor') GROUP BY b.title";
                }
                else if (TempData["yOsa"].ToString() == "title1")
                {
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b.title  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First Masters' OR b.title = 'Second Masters') GROUP BY b.title";
                }
                else if (TempData["yOsa"].ToString() == "title2")
                {
                    query = "SELECT Count(a." + TempData["xOsa"] + "),b.title  FROM BP07.USER_ENROLLMENT a, BP07.STUDYYEAR b WHERE a.studyyearid = b.id AND(b.title = 'First PhD' OR b.title = 'Second PhD' OR b.title = 'Third PhD') GROUP BY b.title";
                }
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
        /*public JsonResult GetDataForChartAll()
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
        }*/
    }
}