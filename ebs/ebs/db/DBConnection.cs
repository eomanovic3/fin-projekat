using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Oracle.DataAccess.Client;

namespace ebs.db
{
    public class DBConnection
    {
        public MySqlConnection conn;

        string myConnectionString;

        public DBConnection()
        {
            myConnectionString = "Server=localhost;Port=3306;Database=mydb;Uid=root;Pwd = 2016SIEtf; ";
            conn = new MySqlConnection(myConnectionString);
            conn.Open();

            /*myConnectionString = "Data Source = DESCRIPTION ="+
    "(ADDRESS_LIST ="+
        "(ADDRESS = (PROTOCOL = TCP)(HOST = 80.65.65.66)(PORT = 1521))"+
    ")"+
    "(CONNECT_DATA ="+
      "(SID = etflab)"+
    "); User Id = BP11; Password = TZ7j71rm; Connection Timeout = 120";

            try
            {
                conn = new OracleConnection(myConnectionString);
                conn.Open();
            }
            catch (OracleException oracleException)
            {
                Console.Write(oracleException.Message);
            }*/


        }

    }
}