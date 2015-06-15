using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace StudioApplication.Common
{
    public sealed class DataBaseConnections
    {
        public DataBaseConnections()
        { }
        public static string GetMainSqlConString()
        {
            string conStringName = ConfigurationManager.AppSettings["MainConStringName"].ToString();
            return ConfigurationManager.ConnectionStrings[conStringName].ConnectionString;
        }

    }
}
