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
    public class CustomerOrderAcceptanceBusiness
    {
        string Message = string.Empty;

        public IEnumerable<customerOrderAcceptanceModel> getRecordToGrid(int CustomerCode, string UserID)
        {

            Connection con = new Connection();
            List<customerOrderAcceptanceModel> customerOrderAcceptanceModellist = new List<customerOrderAcceptanceModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_CustomerOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", CustomerCode);
                cmd.Parameters.AddWithValue("@UserID", UserID);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customerOrderAcceptanceModel customerOrderAcceptanceModel = new customerOrderAcceptanceModel();
                    customerOrderAcceptanceModel.OrderRefrenceNumber = sdr["Order_Ref"].ToString();
                    customerOrderAcceptanceModel.CALDAY = sdr["CALDAY"].ToString();
                    //customerOrderAcceptanceModel.Material = Convert.ToInt32(sdr["Material"]);
                    customerOrderAcceptanceModel.Material = sdr["Material"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Material"]);
                    customerOrderAcceptanceModel.Description = sdr["Description"].ToString();
                    customerOrderAcceptanceModel.UnitPrice = sdr["UnitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    customerOrderAcceptanceModel.Quantity = Convert.ToInt32(sdr["Quantity"]);
                    customerOrderAcceptanceModel.WeeklyQuantity = Convert.ToInt32(sdr["WeeklyQuantity"]);
                    customerOrderAcceptanceModel.FirmOrder = Convert.ToInt32(sdr["FirmOrder"]);
                    customerOrderAcceptanceModel.Monday = Convert.ToInt32(sdr["Monday"]);
                    customerOrderAcceptanceModel.Tuesday = Convert.ToInt32(sdr["Tuesday"]);
                    customerOrderAcceptanceModel.Wednesday = Convert.ToInt32(sdr["Wednesday"]);
                    customerOrderAcceptanceModel.Thursday = Convert.ToInt32(sdr["Thursday"]);
                    customerOrderAcceptanceModel.Friday = Convert.ToInt32(sdr["Friday"]);
                    customerOrderAcceptanceModel.Saturday = Convert.ToInt32(sdr["Saturday"]);
                    customerOrderAcceptanceModel.Sunday = Convert.ToInt32(sdr["Sunday"]);
                    customerOrderAcceptanceModel.TotalValue = sdr["TotalValue"].ToString() == "" ? 0 : Convert.ToInt32(sdr["TotalValue"]);

                    customerOrderAcceptanceModel.MondayValue = Convert.ToInt32(sdr["MondayValue"]);
                    customerOrderAcceptanceModel.TuesdayValue = Convert.ToInt32(sdr["TuesdayValue"]);
                    customerOrderAcceptanceModel.WednesdayValue = Convert.ToInt32(sdr["WednesdayValue"]);
                    customerOrderAcceptanceModel.ThursdayValue = Convert.ToInt32(sdr["ThursdayValue"]);
                    customerOrderAcceptanceModel.FridayValue = Convert.ToInt32(sdr["FridayValue"]);
                    customerOrderAcceptanceModel.SaturdayValue = Convert.ToInt32(sdr["SaturdayValue"]);
                    customerOrderAcceptanceModel.SundayValue = Convert.ToInt32(sdr["SundayValue"]);
                    customerOrderAcceptanceModel.SalesOrganization = sdr["SalesOrganization"].ToString();
                    customerOrderAcceptanceModel.DistributionChannel = sdr["DistributionChannel"].ToString();
                    customerOrderAcceptanceModel.Division = sdr["Division"].ToString();
                    customerOrderAcceptanceModellist.Add(customerOrderAcceptanceModel);
                }
            }
            return customerOrderAcceptanceModellist;

        }

        public string addAcceptedOrders(DataTable dt)
        {
            //var tm = DateTime.Now.ToString();
            Connection conn = new Connection();

            try
            {
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_Accepted_Order_Insert", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.AddWithValue("@tbl_AcceptedOrder_Type", dt);
                    insertCommand.Parameters.Add("@message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@message"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@message"].Value;
                    // Execute the command.  
                    //insertCommand.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {

                ex.ToString();
            }
           

            return Message;
        }
    }


}