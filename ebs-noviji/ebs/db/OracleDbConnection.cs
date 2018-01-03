using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ebs.db
{
    public class OracleDbConnection
    {
        public OracleConnection conn;

        string myConnectionString;

        public OracleDbConnection()
        {
            myConnectionString = "Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = 80.65.65.66)(PORT = 1521)) (CONNECT_DATA = (SID = etflab)));User Id=BP11;Password=TZ7j71rm; Connection Timeout=120;";
            conn = new OracleConnection(myConnectionString);
        }
    }
}