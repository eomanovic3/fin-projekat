using ebs.db;
using ebs.Models;
using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ebs.Controllers.AcademicService
{
    public class EmployedUsersController : Controller
    {
        // GET: EmployedUsers
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: AllStudents
        public ActionResult EmployedUsers()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployedUsers(string xOsa, string yOsa)
        {
            TempData["xOsa"] = xOsa;
            TempData["yOsa"] = yOsa;
            return View();
        }


        public JsonResult ChartBarAndDonutDataUsers()
        {
            if (alldata == null)
            {
                conn.conn.Open();
                string query = null;
                if (TempData["xOsa"].ToString() == "profesori" && TempData["yOsa"].ToString() == "plata")
                {
                    query = "SELECT SUM(a.salary), b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%professor%' OR b.description LIKE '%Professor%') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "profesori" && TempData["yOsa"].ToString() == "broj")
                {
                    query = " SELECT Count(a.ZamgerUserDetailsUserid)AS employees, b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%professor%' OR b.description LIKE '%Professor%') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "asistenti" && TempData["yOsa"].ToString() == "broj")
                {
                    query = "SELECT Count(a.ZamgerUserDetailsUserid) AS employees , b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%assistants%' OR b.description = 'Assistant') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "asistenti" && TempData["yOsa"].ToString() == "plata")
                {
                    query = "SELECT SUM(a.salary), b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%assistants%' OR b.description = 'Assistant') GROUP BY b.description";
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
        public JsonResult ChartRadarAndLineDataUsers()
        {
            if (alldata == null)
            {
                conn.conn.Open();

                string query = null;
                if (TempData["xOsa"].ToString() == "profesori" && TempData["yOsa"].ToString() == "plata")
                {
                    query = "SELECT SUM(a.salary), b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%professor%' OR b.description LIKE '%Professor%') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "profesori" && TempData["yOsa"].ToString() == "broj")
                {
                    query = " SELECT Count(a.ZamgerUserDetailsUserid)AS employees, b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%professor%' OR b.description LIKE '%Professor%') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "asistenti" && TempData["yOsa"].ToString() == "broj")
                {
                    query = "SELECT Count(a.ZamgerUserDetailsUserid) AS employees , b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%assistants%' OR b.description = 'Assistant') GROUP BY b.description";
                }
                else if (TempData["xOsa"].ToString() == "asistenti" && TempData["yOsa"].ToString() == "plata")
                {
                    query ="SELECT SUM(a.salary), b.description FROM bp07.EmployeeDetails a, bp07.TypeOfEmployee b WHERE a.TypeOfEmployeeid = b.id AND(b.description LIKE '%assistants%' OR b.description = 'Assistant') GROUP BY b.description";
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
