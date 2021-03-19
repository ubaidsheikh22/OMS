using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class Connection
    {
        string constr = null;
        public Connection()
        {
            //constr = ConfigurationManager.AppSettings.Get("TokenConnection");
            constr = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
        }
        public SqlConnection GetDataBaseConnection()
        {
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.ConnectionString = constr;
            sqlcon.Open();
            return sqlcon;
         }
        public void CloseConnection(SqlConnection sqlcon)
        {
            sqlcon.Close();
            sqlcon.Dispose();
        }
    }
}
