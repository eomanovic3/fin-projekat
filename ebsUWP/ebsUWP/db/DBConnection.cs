using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebsUWP.db
{
    class DBConnection
    {
        //public MySqlConnection conn;

        string myConnectionString;

        public DBConnection()
        {
            myConnectionString = "Server=localhost;Port=3306;Database=mydb;Uid=root;Pwd = 2016SIEtf; ";
            //conn = new MySqlConnection(myConnectionString);
            //conn.Open();

        }
    }
}
