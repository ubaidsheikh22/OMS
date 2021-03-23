using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Repository
{
    public class ViewReportsBusiness
    {
        public IEnumerable<CustomerModel> getAllCutomers(string regionCode, string Customer, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllCustomersForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.Customer = Convert.ToInt32(sdr["Customer"]);
                    CM.Name1 = sdr["Name1"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<CustomerModel> getAllRegions(string regionCode, string Customer, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllRegionsForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.RegionCode = sdr["RegionCode"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public IEnumerable<materialMasterModel> getAllBrands(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllBrandsForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    CM.Material = Convert.ToInt32(sdr["Material"]);
                    CM.Description = sdr["Description"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public IEnumerable<materialMasterModel> getAllSKUs(string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllSKUsForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    //   CM.Material = Convert.ToInt32(sdr["Material"]);
                    CM.SKUMapping = sdr["SKUMapping"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public IEnumerable<CustomerModel> getAllSalesOrg(string regionCode, string Customer, string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllSalesOrgForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<CustomerModel> getAllArea(string regionCode, string Customer, string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllAreaForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.AreaCode = sdr["AreaCode"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<CustomerModel> getAllTown(string regionCode, string Customer, string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllTownForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.TownCode = sdr["TownCode"].ToString();
                    CM.TownDescription = sdr["TownDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<CustomerModel> getAllTerritory(string regionCode, string Customer, string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllTerritoryForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.TerritoryCode = sdr["TerritoryCode"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<CustomerModel> getAllPlant(string regionCode, string Customer, string SalesOrg, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<CustomerModel> CustomerList = new List<CustomerModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllPlantForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //cmd.Parameters.AddWithValue("@Customer", Customer);
                cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel CM = new CustomerModel();
                    CM.PlantDescription = sdr["PlantDescription"].ToString();
                    //CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }
        public IEnumerable<materialMasterModel> getAllMatgrp1(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllMatgrp1ForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    CM.Materialgroup1 = Convert.ToInt32(sdr["Materialgroup1"]);
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }

        public IEnumerable<materialMasterModel> getAllMatgrp2(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllMatgrp2ForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    CM.Materialgroup2 = Convert.ToInt32(sdr["Materialgroup2"]);
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public IEnumerable<materialMasterModel> getAllMatgrp3(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllMatgrp3ForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    CM.Materialgroup3 = Convert.ToInt32(sdr["Materialgroup3"]);
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }


        public IEnumerable<materialMasterModel> getAllMatgrp4(string regionCode, string UserId)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<materialMasterModel> CustomerList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_getAllMatgrp4ForReports", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Region", regionCode);
                //    cmd.Parameters.AddWithValue("@Customer", Customer);
                //cmd.Parameters.AddWithValue("@UserId", UserId);
                //cmd.Parameters.AddWithValue("@AreaCode", Areacode);
                //cmd.Parameters.AddWithValue("@TerriotoryCode", Terriotorycode);
                //cmd.Parameters.AddWithValue("@TownCode", Towncode);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel CM = new materialMasterModel();
                    CM.Materialgroup4 = Convert.ToInt32(sdr["Materialgroup4"]);
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CustomerList.Add(CM);
                }
                sqlcon.Close();
            }
            return CustomerList;

        }






        public IEnumerable<specialOrderModel> GetSpecialOrderReport(string Customer, string Region, string Material, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            Connection con = new Connection();
            List<specialOrderModel> LogList = new List<specialOrderModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {

                SqlCommand cmd = new SqlCommand("GetSpecialOrderReport", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@Region", Region);
                if (Material != "-1")
                    cmd.Parameters.AddWithValue("@Material", Material);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    specialOrderModel Log = new specialOrderModel();
                    Log.SP_Order_ID = sdr["SP_Order_ID"].ToString();
                    Log.Customer = Convert.ToInt32(sdr["Customer"]);
                    Log.Material = Convert.ToInt32(sdr["Material"]);
                    Log.Description = sdr["Description"].ToString();
                    Log.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    Log.Division = Convert.ToInt32(sdr["Division"]);
                    Log.RegionDescription = sdr["RegionDescription"].ToString();
                    Log.Quantity = Convert.ToInt32(sdr["Quantity"]);


                    //Log.MaterialSKU = sdr["SKUMapping"].ToString();

                    LogList.Add(Log);
                }
            }
            return LogList;
        }

        public IEnumerable<customerOrderAcceptanceModel> GetDayWiseShipmentReport(string Customer, string Region, string Material, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            Connection con = new Connection();
            List<customerOrderAcceptanceModel> LogList = new List<customerOrderAcceptanceModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {

                SqlCommand cmd = new SqlCommand("GetDayWiseShipmentReport", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@Region", Region);
                if (Material != "-1")
                    cmd.Parameters.AddWithValue("@Material", Material);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);

                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customerOrderAcceptanceModel Log = new customerOrderAcceptanceModel();
                    Log.OrderRefrenceNumber = sdr["OrderRefrenceNumber"].ToString();
                    Log.Material = Convert.ToInt32(sdr["Material"]);
                    Log.Description = sdr["Description"].ToString();
                    Log.customer = Convert.ToInt32(sdr["Customer"]);
                    Log.SalesOrganization = sdr["SalesOrganization"].ToString();
                    Log.RegionDescription = sdr["RegionDescription"].ToString();
                    Log.Division = sdr["Division"].ToString();
                    //Log.SKUMapping = sdr["SKUMapping"].ToString();
                    Log.FirmOrder = Convert.ToInt32(sdr["FirmOrder"]);
                    Log.Monday = Convert.ToInt32(sdr["Monday"]);
                    Log.Tuesday = Convert.ToInt32(sdr["Tuesday"]);
                    Log.Wednesday = Convert.ToInt32(sdr["Wednesday"]);
                    Log.Thursday = Convert.ToInt32(sdr["Thursday"]);
                    Log.Friday = Convert.ToInt32(sdr["Friday"]);
                    Log.Saturday = Convert.ToInt32(sdr["Saturday"]);
                    Log.Sunday = Convert.ToInt32(sdr["Sunday"]);
                    LogList.Add(Log);
                }
            }
            return LogList;
        }

        public IEnumerable<customerOrderAcceptanceModel> TossReport(string Customer, string Region, string Material, string SKU, string SalesOrganization, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            Connection con = new Connection();
            List<customerOrderAcceptanceModel> LogList = new List<customerOrderAcceptanceModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {

                SqlCommand cmd = new SqlCommand("GetDayWiseShipmentReport", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@Region", Region);
                if (Material != "-1")
                    cmd.Parameters.AddWithValue("@Material", Material);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);

                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrganization);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }

                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customerOrderAcceptanceModel Log = new customerOrderAcceptanceModel();
                    Log.OrderRefrenceNumber = sdr["OrderRefrenceNumber"].ToString();
                    Log.Material = Convert.ToInt32(sdr["Material"]);
                    Log.Description = sdr["Description"].ToString();
                    Log.customer = Convert.ToInt32(sdr["Customer"]);
                    Log.SalesOrganization = sdr["SalesOrganization"].ToString();
                    Log.RegionDescription = sdr["RegionDescription"].ToString();
                    Log.Division = sdr["Division"].ToString();
                    Log.SKUMapping = sdr["SKUMapping"].ToString();
                    Log.FirmOrder = Convert.ToInt32(sdr["FirmOrder"]);
                    Log.Monday = Convert.ToInt32(sdr["Monday"]);
                    Log.Tuesday = Convert.ToInt32(sdr["Tuesday"]);
                    Log.Wednesday = Convert.ToInt32(sdr["Wednesday"]);
                    Log.Thursday = Convert.ToInt32(sdr["Thursday"]);
                    Log.Friday = Convert.ToInt32(sdr["Friday"]);
                    Log.Saturday = Convert.ToInt32(sdr["Saturday"]);
                    Log.Sunday = Convert.ToInt32(sdr["Sunday"]);
                    LogList.Add(Log);
                }
            }
            return LogList;
        }


        public List<generateOrderModal> ReportSuggestedOrder(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ReportSuggestedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();
                    CM.Order_Ref = sdr["Order_Ref"].ToString();
                    CM.CALDAY = sdr["CALDAY"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    CM.DIVISION = sdr["Division"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.weekNumber = sdr["weekNumber"].ToString();
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);
                    CM.RSFQTY = Convert.ToInt32(sdr["RSFQTY"]);
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TownDescription = sdr["TownDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }

        public List<generateOrderModal> ReportConfirmedOrder(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ReportConfirmedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if(DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if(DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();

                    CM.Order_Ref = sdr["OrderRefrenceNumber"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    //CM.SKUMapping = sdr["SKUMapping"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);

                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }



        public List<generateOrderModal> CustomizeOrdersReport(string Customer, string Region, string Brand, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_CustomizeReportWithoutRSF", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                //if (SKU != "-1")
                //    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();

                    CM.Order_Ref = sdr["OrderRefrenceNumber"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    CM.AcceptedOrder = sdr["AcceptedOrder"].ToString();
                    CM.SpecialOrder = sdr["SpecialOrder"].ToString();
                    CM.TotalOrders = sdr["TotalOrders"].ToString();
                    CM.InTransitOrder = sdr["InTransitOrder"].ToString();
                    
                    CM.Monday = sdr["Monday"].ToString();
                    CM.Tuesday = sdr["Tuesday"].ToString();
                    CM.Wednesday = sdr["Wednesday"].ToString();
                    CM.Thursday = sdr["Thursday"].ToString();
                    CM.Friday = sdr["Friday"].ToString();
                    CM.Saturday = sdr["Saturday"].ToString();
                    CM.Sunday = sdr["Sunday"].ToString() == "" ? "0" : sdr["Sunday"].ToString();
                    CM.custDATEReport = sdr["CreatedAt"].ToString();

                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }

        public List<generateOrderModal> CustomizeOrdersReportWithRSF(string Customer, string Region, string Brand, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_CustomizeReportWithRSF", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                //if (SKU != "-1")
                //    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }
                sqlcon.Open();
                cmd.CommandTimeout = 600;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();

                    CM.Order_Ref = sdr["OrderRefrenceNumber"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    CM.weeklyrsf = sdr["weeklyrsf"].ToString();
                    CM.monthlyRSF = sdr["monthlyRSF"].ToString();
                    CM.suggestedOrder = sdr["suggestedOrder"].ToString();
                    CM.AcceptedOrder = sdr["AcceptedOrder"].ToString();
                    CM.SpecialOrder = sdr["SpecialOrder"].ToString();
                    CM.TotalOrders = sdr["TotalOrders"].ToString();
                    CM.InTransitOrder = sdr["InTransitOrder"].ToString();
                    CM.Monday = sdr["Monday"].ToString();
                    CM.Tuesday = sdr["Tuesday"].ToString();
                    CM.Wednesday = sdr["Wednesday"].ToString();
                    CM.Thursday = sdr["Thursday"].ToString();
                    CM.Friday = sdr["Friday"].ToString();
                    CM.Saturday = sdr["Saturday"].ToString();
                    CM.Sunday = sdr["Sunday"].ToString() == "" ? "0" : sdr["Sunday"].ToString();
                    CM.custDATEReport = sdr["CreatedAt"].ToString();

                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }



        public List<generateOrderModal> ReportUnConfirmedOrder(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ReportUnConfirmedOrder", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();
                    //CM.orderID = Convert.ToInt32(sdr["Order_ID"]);
                    CM.Order_Ref = sdr["Order_Ref"].ToString();
                    CM.CALDAY = sdr["CALDAY"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    CM.DIVISION = sdr["Division"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.weekNumber = sdr["weekNumber"].ToString();
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }


        public List<generateOrderModal> getInTransitOrderReport(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate, string EndDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_getInTransitOrderReport", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);

                cmd.Parameters.AddWithValue("@SalesOrganization", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                }
                if (EndDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(EndDate, out dt))
                        cmd.Parameters.AddWithValue("@EndDate", dt);
                }

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();
                    CM.Order_Ref = sdr["OrderRefrenceNumber"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.DIVISION = sdr["Division"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);


                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }

        public List<generateOrderModal> RSFFirmReport(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ReportFirmOrder_RSF", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                    {
                        DateTime EndDate = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    }
                }
                //if (EndDate != "")
                //{
                //    DateTime dt = DateTime.Now;
                //    if (DateTime.TryParse(EndDate, out dt))
                //        cmd.Parameters.AddWithValue("@EndDate", dt);
                //}
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();

                    CM.Order_Ref = sdr["Order_Ref"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    //CM.SKUMapping = sdr["SKUMapping"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);

                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }

        public List<generateOrderModal> RSFSuggestedReport(string Customer, string Region, string Brand, string SKU, string SalesOrg, string Area, string Town, string Territory, string Plant, string MatGrp1, string MatGrp2, string MatGrp3, string MatGrp4, string StartDate)
        {
            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<generateOrderModal> OrderModal = new List<generateOrderModal>();
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("SP_ReportSuggestedOrder_RSF", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                if (Region != "-1")
                    cmd.Parameters.AddWithValue("@RegionCode", Region);
                if (Brand != "-1")
                    cmd.Parameters.AddWithValue("@Material", Brand);
                if (Customer != "-1")
                    cmd.Parameters.AddWithValue("@Customer", Customer);
                if (SKU != "-1")
                    cmd.Parameters.AddWithValue("@SKU", SKU);
                if (SalesOrg != "-1")
                    cmd.Parameters.AddWithValue("@SalesOrg", SalesOrg);
                if (Area != "-1")
                    cmd.Parameters.AddWithValue("@Area", Area);
                if (Town != "-1")
                    cmd.Parameters.AddWithValue("@Town", Town);
                if (Territory != "-1")
                    cmd.Parameters.AddWithValue("@Territory", Territory);
                if (Plant != "-1")
                    cmd.Parameters.AddWithValue("@Plant", Plant);
                if (MatGrp1 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp1", MatGrp1);
                if (MatGrp2 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp2", MatGrp2);
                if (MatGrp3 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp3", MatGrp3);
                if (MatGrp4 != "-1")
                    cmd.Parameters.AddWithValue("@MatGrp4", MatGrp4);
                if (StartDate != "")
                {
                    DateTime dt = DateTime.Now;
                    if (DateTime.TryParse(StartDate, out dt))
                    {
                        DateTime EndDate = new DateTime(dt.Year, dt.Month, DateTime.DaysInMonth(dt.Year, dt.Month));
                        cmd.Parameters.AddWithValue("@StartDate", dt);
                        cmd.Parameters.AddWithValue("@EndDate", EndDate);
                    }
                }
                //if (EndDate != "")
                //{
                //    DateTime dt = DateTime.Now;
                //    if (DateTime.TryParse(EndDate, out dt))
                //        cmd.Parameters.AddWithValue("@EndDate", dt);
                //}
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    generateOrderModal CM = new generateOrderModal();

                    CM.Order_Ref = sdr["Order_Ref"].ToString();
                    CM.CUSTOMER = sdr["Customer"].ToString();
                    CM.customerName = sdr["Name1"].ToString();
                    CM.MATERIAL = sdr["Material"].ToString();
                    CM.Description = sdr["Description"].ToString();
                    CM.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    CM.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    CM.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    CM.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    CM.SALESORG = sdr["SalesOrganization"].ToString();
                    CM.AreaDescription = sdr["AreaDescription"].ToString();
                    CM.RegionDescription = sdr["RegionDescription"].ToString();
                    CM.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    CM.DISTR_CHAN = sdr["DistributionChannel"].ToString();
                    //CM.SKUMapping = sdr["SKUMapping"].ToString();
                    CM.QTY = Convert.ToDouble(sdr["Quantity"]);
                    CM.UnitPrice = Convert.ToDouble(sdr["UnitPrice"]);

                    OrderModal.Add(CM);
                }
                sqlcon.Close();
            }
            return OrderModal;
        }

    }
}
