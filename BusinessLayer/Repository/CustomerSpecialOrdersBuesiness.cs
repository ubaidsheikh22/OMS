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
   public class CustomerSpecialOrdersBuesiness
    {
        private Connection conn;
        private SqlCommand cmd;
        
        private string Message = string.Empty;
        public IEnumerable<materialMasterModel> GetAllMaterials(string customer, string SalesOrganization, string Division, string Material)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLMaterialForSPOrder", sqlcon);
                cmd.Parameters.AddWithValue("@Customer", customer);
                cmd.Parameters.AddWithValue("@Material", Material);
                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrganization);
                cmd.Parameters.AddWithValue("@Division", Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    //materialMasterModel.Sprefrence = sdr["OrderRefNo"].ToString();
                    materialMasterModel.Materialgroup1 = Convert.ToInt32(sdr["Material"]);
                    materialMasterModel.Description = sdr["Description"].ToString();
                    materialMasterModel.SalesOrganization = string.IsNullOrEmpty(sdr["SalesOrganization"].ToString()) ? 0 : Convert.ToInt32(sdr["SalesOrganization"]);
                    materialMasterModel.Division = Convert.ToInt32(sdr["Division"]);
                    materialMasterModel.quantity = sdr["Quantity"].ToString() == "" ? 0  : Convert.ToInt32(sdr["Quantity"]);
                    materialMasterModel.firmQuantity = sdr["FirmOrder"].ToString() == "" ? 0 : Convert.ToInt32(sdr["FirmOrder"]);
                    materialMasterModel.unitPrice2 = sdr["UnitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    materialMasterModel.unitPriceM = sdr["UnitPriceTBL"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPriceTBL"]);
                    materialMasterModelList.Add(materialMasterModel);
                }

                return materialMasterModelList;
            }
        }
        public List<string> addSpecialOrder(List<specialOrderModel> sp , int customerCode , int packageID)
        {
            //var tm = DateTime.Now.ToString();
            List<string> response = new List<string>();
            string Approve = "0";
            conn = new Connection();
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Material");
                dt.Columns.Add("SalesOrganization");
                dt.Columns.Add("Division");
                dt.Columns.Add("Quantity");
             
                foreach (var a in sp)
                {
                    dt.Rows.Add(a.Material, a.SalesOrganization, a.Division, a.Quantity);
                }
                specialOrderModel spp = new specialOrderModel();
                
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_SP_Order_Insertbk", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@Customer", customerCode);
                    insertCommand.Parameters.AddWithValue("@Package_ID", packageID);
                    insertCommand.Parameters.AddWithValue("@Approve", Approve);
                    insertCommand.Parameters.AddWithValue("@Special_Order_Material_Type", dt);

                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.Parameters.Add("@FirstName", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@FirstName"].Direction = ParameterDirection.Output;
                    insertCommand.Parameters.Add("@Email", SqlDbType.VarChar, 200);
                    insertCommand.Parameters["@Email"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();

                    response.Add((string)insertCommand.Parameters["@Message"].Value);
                    response.Add((string)insertCommand.Parameters["@FirstName"].Value);
                    response.Add((string)insertCommand.Parameters["@Email"].Value);
                }
            }
            catch (Exception ex)
            {

                throw;
            }


            return response;
        }
    }
}