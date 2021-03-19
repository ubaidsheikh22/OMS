using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
   public class PackageBusiness
    {

        private Connection conn;
        private SqlCommand cmd;
        private string Message = string.Empty;
        public string InsertUpdatePackage(PackageModel model, string status)
        {
            conn = new Connection();
            using (SqlConnection SqlCon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Packages_Insert_Update_Delete", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Package_ID", model.Package_ID);
                cmd.Parameters.AddWithValue("@PackageName", model.PackageName);
                cmd.Parameters.AddWithValue("@User_ID", model.User_ID);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar,100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
                return Message;
        }


        public string UpdatePackage(PackageModel model, string status)
        {
            conn = new Connection();
            using (SqlConnection SqlCon = conn.GetDataBaseConnection())
            {
                cmd = new SqlCommand("SP_Packages_Insert_Update_Delete", SqlCon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Package_ID", model.Package_ID);
                cmd.Parameters.AddWithValue("@PackageName", model.PackageName);
                cmd.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                cmd.Parameters["@Message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@Message"].Value;
            }
            return Message;
        }

        public IEnumerable<PackageModel> GetAllPackagesRecords
        {
            get {
                Connection con = new Connection();
                List<PackageModel> pkgModel = new List<PackageModel>();
                using (SqlConnection SqlCon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllPackages", SqlCon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        PackageModel package = new PackageModel();
                        package.Package_ID = Convert.ToInt32(sdr["Package_ID"]);
                        package.PackageName = sdr["PackageName"].ToString();
                        package.UserName = sdr["UserName"].ToString();
                        pkgModel.Add(package);
                    }
                }
                return pkgModel;
            }
        }
    }
}
