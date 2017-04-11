using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.Common;

namespace SQLServerDal
{
    public static class DbFactory
    {
        static readonly string ConnectString = ConfigurationManager.AppSettings["connstr"];
        public static DbConnection CreateConnection()
        {
            return new SqlConnection(ConnectString);
        }
    }
}
