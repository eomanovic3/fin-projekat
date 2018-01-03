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
    public class GraduateStudentsController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: AllStudents
        public ActionResult GraduateStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GraduateStudents(string xOsa, string yOsa)
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
                if (TempData["yOsa"].ToString() == "title")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'Bachelor' GROUP BY dep.title";
                }
                else if (TempData["yOsa"].ToString() == "title1")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'Masters' GROUP BY dep.title";
                }
                else if (TempData["yOsa"].ToString() == "title2")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'PhD' GROUP BY dep.title";
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
                System.Diagnostics.Debug.WriteLine(result);
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
        public JsonResult ChartRadarAndLineDataStudents()
        {
            if (alldata == null)
            {
                conn.conn.Open();

                string query = null;
                if (TempData["yOsa"].ToString() == "title")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'Bachelor' GROUP BY dep.title";
                }
                else if (TempData["yOsa"].ToString() == "title1")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'Masters' GROUP BY dep.title";
                }
                else if (TempData["yOsa"].ToString() == "title2")
                {
                    query = " SELECT Count(fp.id) AS brojDiplomanata, dep.title AS odsjek FROM bp07.FinalProject fp, bp07.DEGREE d, bp07.department_Degree dd, bp07.Department dep WHERE fp.degreeid = d.id AND d.id = dd.departmentid AND dd.degreeid = dep.id AND d.title = 'PhD' GROUP BY dep.title";
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
     
    }
}