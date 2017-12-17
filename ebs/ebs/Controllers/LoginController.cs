using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using ebs.db;
using Oracle.DataAccess.Client;

namespace ebs.Controllers
{
    public class LoginController : Controller
    {
        DBConnection conn = new DBConnection();

        // GET: Login
        public ActionResult Login(FormCollection collection)
        {
            string username = collection["username"];
            string password = collection["password"];

            MySqlCommand cmd = new MySqlCommand("SELECT users.username, users.password FROM mydb.user users WHERE users.username = '" + username +
                "' AND users.password = '" + password + "'", conn.conn);

            MySqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read())
            {
                Session["Username"] = username;
                Session["Password"] = password;
                return View();

            }

            return RedirectToAction("Index", "Home");
        }

    }
}