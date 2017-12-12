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
        OracleDbConnection conn = new OracleDbConnection();

        // GET: Login
        public ActionResult Login(FormCollection collection)
        {
            if (Session["Username"] != null)
            {
                Session.Abandon();
                return View();
            }
            else
            {
                //string username = collection["username"];
                //string password = collection["password"];

                //MySqlCommand cmd = new MySqlCommand("SELECT users.username, users.password FROM mydb.user users WHERE users.username = '" + username +
                //    "' AND users.password = '" + password + "'", conn.conn);

                //MySqlDataReader rd = cmd.ExecuteReader();

                //if (rd.Read())
                //{
                //    Session["Username"] = username;//sumejja
                //    Session["Password"] = password;//sumejja
                //    return View();
                //}

                //return RedirectToAction("Index", "Home");
                string username = collection["Username"];
                string pwhash = collection["Password"];
                OracleCommand cmd = new OracleCommand("SELECT users.USERNAME, users.PWHASH FROM BP07.users users WHERE users.USERNAME = '" + username +
                    "' AND users.PWHASH = '" + pwhash + "'", conn.conn);

                OracleDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    Session["Username"] = username;//eomanovic3
                    Session["Password"] = pwhash;//sifra123
                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}