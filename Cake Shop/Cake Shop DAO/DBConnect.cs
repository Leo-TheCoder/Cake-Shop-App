using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Cake_Shop_DAO
{
    public class DBConnect
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["WeSplitDBConnectionString"].ConnectionString;
        protected SqlConnection _conn = new SqlConnection(connectionString);
    }
}
