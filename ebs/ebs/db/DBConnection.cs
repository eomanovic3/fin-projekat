﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ebs.db
{
    public class DBConnection
    {
        public MySqlConnection conn;

        string myConnectionString;

        public DBConnection()
        {
            myConnectionString = "Server=localhost;Port=3306;Database=mydb;Uid=root;Pwd = sql123; ";
            conn = new MySqlConnection(myConnectionString);
            conn.Open();

        }

    }
}