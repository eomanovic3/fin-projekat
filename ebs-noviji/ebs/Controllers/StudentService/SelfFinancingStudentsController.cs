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
    public class SelfFinancingStudentsController : Controller
    {
        static List<string> alldata = null;
        OracleDbConnection conn = new OracleDbConnection();

        // GET: AllStudents
        public ActionResult SelfFinancingStudents()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SelfFinancingStudents(string xOsa, string yOsa)
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
                if (TempData["yOsa"].ToString() == "1")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "2")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-1) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "3")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-2) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "4")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-3) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "5")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-4) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "6")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-5) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "7")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-6) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "8")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-7) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "9")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-8) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "10")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-9) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "11")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-10) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "12")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-11) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
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
                if (TempData["yOsa"].ToString() == "1")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "2")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-1) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "3")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-2) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "4")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-3) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "5")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-4) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "6")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-5) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "7")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-6) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "8")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-7) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "9")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-8) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "10")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-9) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "11")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-10) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
                }
                else if (TempData["yOsa"].ToString() == "12")
                {
                    query = "SELECT Count(sd.zamgeruserdetailsuserid), ay.title FROM bp07.StudentDetails sd, bp07.ZamgerUserDetails zd, bp07.User_Enrollment ue, bp07.Enrollment e, bp07.Course_Department cd, bp07.AcademicYear ay WHERE sd.budget = 0 AND sd.ZamgerUserDetailsUserid = zd.Userid AND ue.userid = zd.Userid AND ue.Enrollmentid = e.id AND e.title = '" + TempData["xOsa"] + "' AND ue.course_departmentid = cd.id AND cd.academicyearid = ay.id AND To_Number(SUBSTR(ay.title, -4, 4)) BETWEEN(EXTRACT(YEAR FROM SYSTIMESTAMP)-11) AND EXTRACT(YEAR FROM SYSTIMESTAMP) GROUP BY ay.title";
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