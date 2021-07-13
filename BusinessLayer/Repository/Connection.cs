using System.Configuration;
using System.Data.SqlClient;

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
