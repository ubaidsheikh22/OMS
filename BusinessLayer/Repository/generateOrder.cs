using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace BusinessLayer.Repository
{
    public class generateOrder
    {
        private Connection conn;
        SqlDataAdapter da;
        private string Message = string.Empty;

        public IEnumerable<generateOrderModal> GetAllCustomerRecords2()
        {
            Connection con = new Connection();
            List<generateOrderModal> orderlist = new List<generateOrderModal>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GenerateOrderMoazzam", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal go = new generateOrderModal();
                    go.CALDAY = sdr["CALDAY"].ToString();
                    go.DISTR_CHAN = sdr["DISTR_CHAN"].ToString();
                    go.SALESORG = sdr["SALESORG"].ToString();
                    go.CUSTOMER = sdr["CUSTOMER"].ToString();
                    go.MATERIAL = sdr["MATERIAL"].ToString();
                    go.Order_Qty = sdr["QTY"].ToString();
                    go.DIVISION = sdr["DIVISION"].ToString();
                    go.MaterialTotalValues = sdr["materialprice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["materialprice"]);
                    go.MaterialGroup = sdr["MaterialGroup"].ToString();
                    go.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    go.DistributorClosingStock = sdr["DistributorClosingStock"].ToString() == "" ? 0 : Convert.ToDouble(sdr["DistributorClosingStock"]);
                    go.QTY = sdr["QTY"].ToString() == "" ? 0 : Convert.ToDouble(sdr["QTY"]);
                    go.AreaDescription = sdr["AreaDescription"].ToString();
                    go.RegionDescription = sdr["RegionDescription"].ToString();
                    go.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    go.TownDescription = sdr["TownDescription"].ToString();
                    go.RSFQTY = sdr["RSFQTY"].ToString() == "" ? 0 : Convert.ToInt32(sdr["RSFQTY"]);
                    go.SafetyStock = sdr["SafetyStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["SafetyStock"]);
                    go.DistributorClosingStock = sdr["DistributorClosingStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DistributorClosingStock"]);
                    go.SKUMapping = sdr["SKUMAPPING"].ToString() == null ? "" : sdr["SKUMAPPING"].ToString();
                    go.MaxDay = sdr["MaxDay"].ToString() == null ? "" : sdr["MaxDay"].ToString();
                    orderlist.Add(go);
                }
            }

            return orderlist;
        }


        public string InsertInTable(List<generateOrderModal> orderlist)
        {

            DataTable dtt = new DataTable();
            dtt.Columns.Add("Order_Ref");
            dtt.Columns.Add("CALDAY");
            dtt.Columns.Add("COMP_CODE");
            dtt.Columns.Add("SALESORG");
            dtt.Columns.Add("DISTR_CHAN");
            dtt.Columns.Add("DIVISION");
            dtt.Columns.Add("MATERIAL");
            dtt.Columns.Add("CUSTOMER");
            dtt.Columns.Add("Order_Qty", typeof(int));
            dtt.Columns.Add("Is_Generated");
            dtt.Columns.Add("weekNumber");
            dtt.Columns.Add("MaterialTotalValues");

            dtt.Columns.Add("RSFQTY");
            dtt.Columns.Add("SafetyStock");
            dtt.Columns.Add("DistributorClosingStock");
            dtt.Columns.Add("RegionDescription");
            dtt.Columns.Add("TownDescription");
            dtt.Columns.Add("TerritoryDescription");
            dtt.Columns.Add("AreaDescription");
            dtt.Columns.Add("SKUMapping");
            dtt.Columns.Add("MaxDay");

            //int i = 1000000;
            var dateRef = DateTime.Now.AddDays(7).ToString("yyyy-MM-dd");
            var date = DateTime.Now.AddDays(7);

            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(date);

            CultureInfo myCI = new CultureInfo("de-DE");
            Calendar myCal = myCI.Calendar;
            CalendarWeekRule myCWR = myCI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = myCI.DateTimeFormat.FirstDayOfWeek;
            int weekNumber = myCal.GetWeekOfYear(date, myCWR, myFirstDOW);

            foreach (var a in orderlist)
            {
                if (a.Order_Qty != "0")
                {
                    int Code = Convert.ToInt32(a.CUSTOMER);
                    dtt.Rows.Add(
                        Code + a.SALESORG + a.DIVISION + dateRef + '/' + weekNumber,
                        a.CALDAY,
                        a.COMP_CODE,
                        a.SALESORG,
                        a.DISTR_CHAN,
                        a.DIVISION,
                        a.MATERIAL,
                        a.CUSTOMER,
                        a.Order_Qty,
                        1,
                        weekNumber,
                        a.MaterialTotalValues,
                        a.RSFQTY,
                        a.SafetyStock,
                        a.DistributorClosingStock,
                        a.RegionDescription,
                        a.TownDescription,
                        a.TerritoryDescription,
                        a.AreaDescription,
                        a.SKUMapping,
                        a.MaxDay);
                }
            }

            conn = new Connection();
            try
            {
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_InsertOrders", sqlcon);
                    insertCommand.CommandTimeout = 600;
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_order", dtt);
                    typeParam.SqlDbType = SqlDbType.Structured;
                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@Message"].Value;
                    //insertCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return Message;
        }

        public IEnumerable<generateOrderModal> GetAllGeneratedOrderRecords2(string Region)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> AllOrderRecords = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Generate_Order_SKU", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", Region);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal AllForGenerateRecord = new generateOrderModal();
                    AllForGenerateRecord.Order_Ref = sdr["Order_Ref"].ToString();
                    AllForGenerateRecord.CALDAY = sdr["CALDAY"].ToString();
                    AllForGenerateRecord.COMP_CODE = sdr["CompanyCode"].ToString();
                    AllForGenerateRecord.SALESORG = sdr["SalesOrganization"].ToString();
                    AllForGenerateRecord.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    AllForGenerateRecord.DIVISION = sdr["Division"].ToString();
                    AllForGenerateRecord.CUSTOMER = sdr["Customer"].ToString();
                    AllOrderRecords.Add(AllForGenerateRecord);
                }
                sqlcon.Close();
            }
            return AllOrderRecords;
        }

        public IEnumerable<generateOrderModalGrid> gridView(string customer, string salesorg, string division, string region, string area, string territory, string town, string plant)
        {
            int count = 0;
            Connection con = new Connection();
            List<generateOrderModalGrid> orderlist = new List<generateOrderModalGrid>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_generatedOrders", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@salesorg", salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@division", division == "null" ? "" : division);
                cmd.Parameters.AddWithValue("@region", region == "null" ? "" : region);
                cmd.Parameters.AddWithValue("@area", area == "null" ? "" : area);
                cmd.Parameters.AddWithValue("@territory", territory == "null" ? "" : territory);
                cmd.Parameters.AddWithValue("@town", town == "null" ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@customer", customer == "null" ? "" : customer);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModalGrid go = new generateOrderModalGrid();
                    go.distinctValue = count++;
                    go.CALDAY = sdr["CALDAY"].ToString();
                    go.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    go.Order_Ref = sdr["Order_Ref"].ToString();
                    go.SALESORG = sdr["SalesOrganization"].ToString();
                    go.CUSTOMER = sdr["Customer"].ToString();
                    go.customerName = sdr["Name1"].ToString();
                    go.Description = sdr["Description"].ToString();
                    go.MATERIAL = sdr["Material"].ToString();
                    go.Order_Qty = sdr["QuantityFinal"].ToString();
                    go.weekNumber = sdr["weekNumber"].ToString();
                    go.MaterialTotalValues = sdr["MaterialValue"].ToString() == "" ? 0 : Convert.ToDouble(sdr["MaterialValue"]);
                    go.UnitPrice = sdr["UnitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    go.DIVISION = sdr["DIVISION"].ToString();
                    go.MaterialGroup = sdr["MaterialGroup"].ToString();
                    go.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    go.AreaDescription = sdr["AreaDescription"].ToString();
                    go.RegionDescription = sdr["RegionDescription"].ToString();
                    go.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    go.TownDescription = sdr["TownDescription"].ToString();
                    go.RSFQTY = sdr["RSFQTY"].ToString() == "" ? 0 : Convert.ToInt32(sdr["RSFQTY"]);
                    go.SafetyStock = sdr["SafetyStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["SafetyStock"]);
                    go.DistributorClosingStock = sdr["DistributorClosingStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DistributorClosingStock"]);
                    go.SKUMapping = sdr["SKUMAPPING"].ToString() == null ? "" : sdr["SKUMAPPING"].ToString();
                    go.MaxDay = sdr["MaxDay"].ToString() == null ? "" : sdr["MaxDay"].ToString();
                    orderlist.Add(go);
                }
            }
            return orderlist;
        }

        public IEnumerable<generateOrderModalGrid> ViewGeneratedOrder(string customer, string salesorg, string division, string region, string area, string territory, string town, string plant, string UserID)
        {

            int count = 0;
            Connection con = new Connection();
            List<generateOrderModalGrid> orderlist = new List<generateOrderModalGrid>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("View_generatedOrders", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@division", division == "null" ? "" : division);
                cmd.Parameters.AddWithValue("@region", region == "null" ? "" : region);
                cmd.Parameters.AddWithValue("@area", area == "null" ? "" : area);
                cmd.Parameters.AddWithValue("@territory", territory == "null" ? "" : territory);
                cmd.Parameters.AddWithValue("@town", town == "null" ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@customer", customer == "null" ? "" : customer);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModalGrid go = new generateOrderModalGrid();
                    go.distinctValue = count++;
                    go.CALDAY = sdr["CALDAY"].ToString();
                    go.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    go.Order_Ref = sdr["Order_Ref"].ToString();
                    go.SALESORG = sdr["SalesOrganization"].ToString();
                    go.CUSTOMER = sdr["Customer"].ToString();
                    go.customerName = sdr["Name1"].ToString();
                    go.Description = sdr["Description"].ToString();
                    go.MATERIAL = sdr["Material"].ToString();
                    go.Order_Qty = sdr["QuantityFinal"].ToString();
                    go.weekNumber = sdr["weekNumber"].ToString();
                    go.MaterialTotalValues = sdr["MaterialValue"].ToString() == "" ? 0 : Convert.ToDouble(sdr["MaterialValue"]);
                    go.UnitPrice = sdr["UnitPrice"].ToString() == "" ? 0 : Convert.ToDouble(sdr["UnitPrice"]);
                    go.DIVISION = sdr["DIVISION"].ToString();
                    go.MaterialGroup = sdr["MaterialGroup"].ToString();
                    go.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    go.AreaDescription = sdr["AreaDescription"].ToString();
                    go.RegionDescription = sdr["RegionDescription"].ToString();
                    go.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    go.TownDescription = sdr["TownDescription"].ToString();
                    go.RSFQTY = sdr["RSFQTY"].ToString() == "" ? 0 : Convert.ToInt32(sdr["RSFQTY"]);
                    go.SafetyStock = sdr["SafetyStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["SafetyStock"]);
                    go.DistributorClosingStock = sdr["DistributorClosingStock"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DistributorClosingStock"]);
                    go.SKUMapping = sdr["SKUMAPPING"].ToString() == null ? "" : sdr["SKUMAPPING"].ToString();
                    go.MaxDay = sdr["MaxDay"].ToString() == null ? "" : sdr["MaxDay"].ToString();
                    orderlist.Add(go);
                }
            }
            return orderlist;
        }

        public string InsertOrderInTable(List<generateOrderModal> orderlist)
        {

            DataTable dtt = new DataTable();
            dtt.Columns.Add("Order_Ref");
            dtt.Columns.Add("CALDAY");
            dtt.Columns.Add("COMP_CODE");
            dtt.Columns.Add("DISTR_CHAN");
            dtt.Columns.Add("SALESORG");
            dtt.Columns.Add("CUSTOMER");
            dtt.Columns.Add("MATERIAL");
            dtt.Columns.Add("Order_Qty", typeof(int));
            dtt.Columns.Add("DIVISION");
            dtt.Columns.Add("Is_Generated");
            dtt.Columns.Add("weekNumber");
            dtt.Columns.Add("MaterialTotalValues");
            dtt.Columns.Add("RSFQTY");
            dtt.Columns.Add("SafetyStock");
            dtt.Columns.Add("DistributorClosingStock");
            dtt.Columns.Add("RegionDescription");
            dtt.Columns.Add("TownDescription");
            dtt.Columns.Add("TerritoryDescription");
            dtt.Columns.Add("AreaDescription");
            dtt.Columns.Add("blank1");
            dtt.Columns.Add("blank2");

            int i = 1000000;

            var date = DateTime.Now.ToString("yyyyddMM");

            foreach (var a in orderlist)
            {
                if (a.Order_Qty != "0")
                    dtt.Rows.Add(a.Order_Ref, a.CALDAY, a.COMP_CODE, a.SALESORG, a.DISTR_CHAN, a.DIVISION, a.MATERIAL, a.CUSTOMER, a.Order_Qty, 1, a.weekNumber, a.MaterialTotalValues, "", "", "", "", "", "", "", "", "");
            }

            conn = new Connection();
            try
            {
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_InsertConfirmOrders", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    SqlParameter typeParam = insertCommand.Parameters.AddWithValue("@tbl_order", dtt);
                    typeParam.SqlDbType = SqlDbType.Structured;
                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@Message"].Value;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Message;
        }


        // start inserting all confirm order 
        public string InsertallOrderInTable(List<generateOrderModal> orderlist)
        {

            //DataTable dtt = new DataTable();
            //dtt.Columns.Add("Order_Ref");
            //dtt.Columns.Add("CALDAY");
            //dtt.Columns.Add("COMP_CODE");
            //dtt.Columns.Add("DISTR_CHAN");
            //dtt.Columns.Add("SALESORG");
            //dtt.Columns.Add("CUSTOMER");
            //dtt.Columns.Add("MATERIAL");
            //dtt.Columns.Add("Order_Qty", typeof(int));
            //dtt.Columns.Add("DIVISION");
            //dtt.Columns.Add("Is_Generated");
            //dtt.Columns.Add("weekNumber");
            //dtt.Columns.Add("MaterialTotalValues");
            //dtt.Columns.Add("RSFQTY");
            //dtt.Columns.Add("SafetyStock");
            //dtt.Columns.Add("DistributorClosingStock");
            //dtt.Columns.Add("RegionDescription");
            //dtt.Columns.Add("TownDescription");
            //dtt.Columns.Add("TerritoryDescription");
            //dtt.Columns.Add("AreaDescription");
            //dtt.Columns.Add("blank1");
            //dtt.Columns.Add("blank2");

            //int i = 1000000;

            //var date = DateTime.Now.ToString("yyyyddMM");

            //foreach (var a in orderlist)
            //{
            //    if (a.Order_Qty != "0")
            //        dtt.Rows.Add(a.Order_Ref, a.CALDAY, a.COMP_CODE, a.SALESORG, a.DISTR_CHAN, a.DIVISION, a.MATERIAL, a.CUSTOMER, a.Order_Qty, 1, a.weekNumber, a.MaterialTotalValues, "", "", "", "", "", "", "", "", "");
            //}

            conn = new Connection();
            try
            {
                using (SqlConnection sqlcon = conn.GetDataBaseConnection())
                {
                    // Create a DataTable with the modified rows.  
                    //DataTable addedCategories = CategoriesDataTable.GetChanges(DataRowState.Added);

                    // Configure the SqlCommand and SqlParameter.  
                    SqlCommand insertCommand = new SqlCommand("SP_InsertallConfirmOrders", sqlcon);
                    insertCommand.CommandType = CommandType.StoredProcedure;
                    insertCommand.Parameters.Add("@Message", SqlDbType.VarChar, 100);
                    insertCommand.Parameters["@Message"].Direction = ParameterDirection.Output;
                    insertCommand.ExecuteNonQuery();
                    Message = (string)insertCommand.Parameters["@Message"].Value;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return Message;
        }

        // end inserting all confirm order 


        public IEnumerable<generateOrderModal> getCustomer(string region)
        {
            Connection con = new Connection();
            List<generateOrderModal> orderlist = new List<generateOrderModal>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("GetCustomerForOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@region", region);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal go = new generateOrderModal();
                    go.CUSTOMER = sdr["CUSTOMER"].ToString();
                    go.customerName = sdr["Name1"].ToString();
                    orderlist.Add(go);
                }
            }

            return orderlist;
        }

        public IEnumerable<customerOrderAcceptanceModel> getRecordToGrid(int CustomerCode, string OrderReferenceNumber)
        {
            Connection con = new Connection();
            List<customerOrderAcceptanceModel> customerOrderAcceptanceModellist = new List<customerOrderAcceptanceModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_CustomerOrderFrequency", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CustomerId", CustomerCode);
                cmd.Parameters.AddWithValue("@OrderReferenceNumber", OrderReferenceNumber);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customerOrderAcceptanceModel customerOrderAcceptanceModel = new customerOrderAcceptanceModel();
                    customerOrderAcceptanceModel.OrderRefrenceNumber = sdr["Order_Ref"].ToString();
                    customerOrderAcceptanceModel.CALDAY = sdr["CALDAY"].ToString();
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
                    customerOrderAcceptanceModellist.Add(customerOrderAcceptanceModel);
                }
            }
            return customerOrderAcceptanceModellist;
        }
    }
}