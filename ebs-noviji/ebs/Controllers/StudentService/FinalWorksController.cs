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
    public class FinalWorksController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: AllStudents
        public ActionResult FinalWorks()
        {
            return View();
        }
        [HttpPost]
        public ActionResult FinalWorks(string xOsa, string yOsa)
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
                if (TempData["xOsa"].ToString() == "ciklus")
                {
                    if (TempData["yOsa"].ToString() == "2000/2001")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 5 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2001/2002")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 6 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2002/2003")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 7 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2003/2004")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 8 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2004/2005")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 9 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2005/2006")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 10 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2006/2007")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 12 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2007/2008")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 13 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2008/2009")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 14 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2009/2010")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 15 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2010/2011")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 16 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2011/2012")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 17 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2012/2013")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 18 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2013/2014")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 19 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2014/2015")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 20 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2015/2016")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 21 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2016/2017")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 22 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2017/2018")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 23 GROUP BY ay.title, d.title";

                    }
                }
                else if (TempData["xOsa"].ToString() == "godina")
                {
                    if(TempData["yOsa"].ToString() == "bachelor")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'Bachelor' GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "masters")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'Masters' GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "phd")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'PhD' GROUP BY ay.title, d.title";
                    }
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
                if (TempData["xOsa"].ToString() == "ciklus")
                {
                    if (TempData["yOsa"].ToString() == "2000/2001")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 5 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2001/2002")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 6 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2002/2003")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 7 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2003/2004")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 8 GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "2004/2005")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 9 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2005/2006")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 10 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2006/2007")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 12 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2007/2008")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 13 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2008/2009")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 14 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2009/2010")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 15 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2010/2011")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 16 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2011/2012")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 17 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2012/2013")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 18 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2013/2014")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 19 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2014/2015")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 20 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2015/2016")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 21 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2016/2017")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 22 GROUP BY ay.title, d.title";

                    }
                    else if (TempData["yOsa"].ToString() == "2017/2018")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, d.title as degree FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND ay.id = 23 GROUP BY ay.title, d.title";

                    }
                }
                else if (TempData["xOsa"].ToString() == "godina")
                {
                    if (TempData["yOsa"].ToString() == "bachelor")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'Bachelor' GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "masters")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'Masters' GROUP BY ay.title, d.title";
                    }
                    else if (TempData["yOsa"].ToString() == "phd")
                    {
                        query = "SELECT Count(fp.id) AS FinalProjects, ay.title AS accademicYear FROM bp07.finalProject fp, bp07.AcademicYear ay, bp07.DEGREE d WHERE fp.academicyearid = ay.id AND d.id = fp.degreeid  AND d.title = 'PhD' GROUP BY ay.title, d.title";
                    }
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