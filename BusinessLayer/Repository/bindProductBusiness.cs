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
    public class bindProductBusiness
    {
        string Message = string.Empty;
        public IEnumerable<materialMasterModel> GetAllMaterials
        {
            get
            {
                Connection con = new Connection();
                List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetMaterialForBinding", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        materialMasterModel materialMasterModel = new materialMasterModel();
                        materialMasterModel.Material = Convert.ToInt32(sdr["Material"]);
                        materialMasterModel.Description = sdr["Description"].ToString();
                        materialMasterModelList.Add(materialMasterModel);
                    }
                }
                return materialMasterModelList;
            }
        }

        public IEnumerable<materialMasterModel> GetBindedProducts
        {
            get
            {
                Connection con = new Connection();
                List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("GetBindedProducts", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        materialMasterModel materialMasterModel = new materialMasterModel();
                        materialMasterModel.Material = Convert.ToInt32(sdr["Product1"]);
                        materialMasterModel.Description = sdr["Description1"].ToString();
                        materialMasterModel.Material1 = Convert.ToInt32(sdr["Product2"]);
                        materialMasterModel.Description1 = sdr["Description2"].ToString();

                        materialMasterModelList.Add(materialMasterModel);
                    }
                }
                return materialMasterModelList;
            }
        }

        public string addProductsToBind(int productCode1 , int productCode2)
        {
            Connection conn = new Connection();
            using (SqlConnection sqlcon = conn.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("productBinding", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@product1", productCode1);
                cmd.Parameters.AddWithValue("@product2", productCode2);
                cmd.Parameters.Add("@message", SqlDbType.VarChar, 100);
                cmd.Parameters["@message"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                Message = (string)cmd.Parameters["@message"].Value;
            }
            return Message;
        }


    }
}
