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
    public class endSTockBusiness
    {
        public IEnumerable<endSTockModel> gridViewEndStock(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {


            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<endSTockModel> endSTockList = new List<endSTockModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_ALLENDSTOCK", sqlcon);
                cmd.CommandTimeout = 300;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null || TerritoryCode == "undefined" ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    //endSTockModel endSTockModel = new endSTockModel();
                    //endSTockModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //endSTockModel.Company = sdr["Company"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Company"]);
                    //endSTockModel.SalesOrganization = sdr["SalesOrganization"].ToString() == "" ? 0 : Convert.ToInt32(sdr["SalesOrganization"]);
                    //endSTockModel.DistributionChannel = sdr["DistributionChannel"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DistributionChannel"]);
                    //endSTockModel.Division = sdr["Division"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Division"]);
                    //endSTockModel.CustomerSoldToParty = sdr["CustomerSoldToParty"].ToString() == "" ? 0 : Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //endSTockModel.Material = sdr["Material"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Material"]);
                    //endSTockModel.UOM = sdr["UOM"].ToString();
                    //endSTockModel.ClosingQuantity = sdr["ClosingQuantity"].ToString() == "" ? 0 : Convert.ToDouble(sdr["ClosingQuantity"]);

                    endSTockModel endSTockModel = new endSTockModel();
                    endSTockModel.CalendarDay = sdr["CALDAY"].ToString();
                    endSTockModel.Company = sdr["COMP_CODE"].ToString() == "" ? 0 : Convert.ToInt32(sdr["COMP_CODE"]);
                    endSTockModel.SalesOrganization = sdr["SALESORG"].ToString();
                    endSTockModel.DistributionChannel = sdr["DISTR_CHAN"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DISTR_CHAN"]);
                    endSTockModel.Division = sdr["Division"].ToString() == "" ? 0 : Convert.ToInt32(sdr["Division"]);

                    endSTockModel.ZDOC_CATG = sdr["ZDOC_CATG"].ToString();
                    endSTockModel.UOM = sdr["BASE_UOM"].ToString();
                    endSTockModel.ClosingQuantity = sdr["roundedQTY"].ToString() == "" ? 0 : Convert.ToDouble(sdr["roundedQTY"]);
                    endSTockModel.CustomerSoldToParty = sdr["CUSTOMER"].ToString() == "" ? 0 : Convert.ToInt32(sdr["CUSTOMER"]);
                    endSTockModel.CustomerName = sdr["Name1"].ToString();
                    endSTockModel.CustomerName2 = sdr["Name2"].ToString();
                    endSTockModel.RegionDescription = sdr["RegionDescription"].ToString();
                    endSTockModel.AreaDescription = sdr["AreaDescription"].ToString();
                    endSTockModel.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    endSTockModel.TownDescription = sdr["TownDescription"].ToString();

                    endSTockModel.Material = sdr["MATERIAL"].ToString();
                    endSTockModel.MaterialDescription = sdr["Description"].ToString();
                    endSTockModel.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    endSTockModel.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    endSTockModel.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    endSTockModel.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    endSTockModel.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    endSTockModel.MaterialGroup5_Description = sdr["MaterialGroup5_Description"].ToString();
                    endSTockModel.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    endSTockList.Add(endSTockModel);
                }
                sqlcon.Close();
            }
            return endSTockList;

        }
        public IEnumerable<CustomerModel> getAllCustomer
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<CustomerModel> CustomerList = new List<CustomerModel>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("Get_AllCustomers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerModel CustomerModel = new CustomerModel();
                        CustomerModel.Customer = Convert.ToInt32(sdr["Customer"]);
                        CustomerModel.Name1 = sdr["Name1"].ToString();
                        CustomerList.Add(CustomerModel);
                    }
                    sqlcon.Close();
                }
                return CustomerList;
            }
        }

        public IEnumerable<endSTockModel> TotalEndStock
        {
            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<endSTockModel> TotalEndstock = new List<endSTockModel>();
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("TotalDistributorStock", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        endSTockModel TotalEndStock = new endSTockModel();
                        TotalEndStock.totalDistributorSum = sdr["TotalStock"].ToString();
                        TotalEndstock.Add(TotalEndStock);
                    }
                    sqlcon.Close();
                }
                return TotalEndstock;
            }
        }
        public IEnumerable<endSTockModel> GetmATERIAL(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer,string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLMaterial_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    endstocksales.Material = sdr["MATERIAL"].ToString();
                    endstocksales.Description = sdr["Description"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }
        public IEnumerable<endSTockModel> GetSales(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLSalesOrge_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    endstocksales.SalesOrganization = sdr["SALESORG"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

        public IEnumerable<endSTockModel> GetARegion(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLRegionCode_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    endstocksales.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    endstocksales.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

        public IEnumerable<endSTockModel> GetAreaa(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLArea_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    ///*endstocksales*/.RegionCode = sdr["RegionCode"].ToString();
                    endstocksales.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    endstocksales.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

        public IEnumerable<endSTockModel> GetTerriotory(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLTerritoryCode_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    ///*endstocksales*/.RegionCode = sdr["RegionCode"].ToString();
                    //endstocksales.AreaCode = sdr["AreaCode"].ToString();
                    endstocksales.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    endstocksales.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }


        public IEnumerable<endSTockModel> GetTown(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLTownCode_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    ///*endstocksales*/.RegionCode = sdr["RegionCode"].ToString();
                    //endstocksales.AreaCode = sdr["AreaCode"].ToString();
                    //endstocksales.TerritoryCode = sdr["TerritoryCode"].ToString();
                    endstocksales.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    endstocksales.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

        public IEnumerable<endSTockModel> GetCustomer(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLCustomer_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    endstocksales.AreaCode = sdr["CUSTOMER"].ToString();
                    endstocksales.CustomerName = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    ///*endstocksales*/.RegionCode = sdr["RegionCode"].ToString();
                    //endstocksales.AreaCode = sdr["AreaCode"].ToString();
                    //endstocksales.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //endstocksales.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //endstocksales.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

        public IEnumerable<endSTockModel> GetDivision(string Material, string salesOrg, string RegionCode, string AreaCode, string TerritoryCode, string TownCode, string customer, string division)
        {
            Connection con = new Connection();
            List<endSTockModel> rolelist = new List<endSTockModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLDivision_EndStock", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Material", Material == "null" || Material == "0000000000" || Material == null ? "" : Material);
                cmd.Parameters.AddWithValue("@salesOrg", salesOrg == "null" || salesOrg == null ? "" : salesOrg);
                cmd.Parameters.AddWithValue("@RegionCode", RegionCode == "null" || RegionCode == null ? "" : RegionCode);
                cmd.Parameters.AddWithValue("@AreaCode", AreaCode == "null" || AreaCode == null ? "" : AreaCode);
                cmd.Parameters.AddWithValue("@TerritoryCode", TerritoryCode == "null" || TerritoryCode == null ? "" : TerritoryCode);
                cmd.Parameters.AddWithValue("@TownCode", TownCode == "null" || TownCode == null ? "" : TownCode);
                cmd.Parameters.AddWithValue("@CustomerCode", customer == "null" || customer == "0000" || customer == null ? "" : customer);
                cmd.Parameters.AddWithValue("@Division", division == "null" || division == null ? "" : division);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    endSTockModel endstocksales = new endSTockModel();
                    //endstocksales.AreaCode = sdr["CUSTOMER"].ToString();
                    //endstocksales.CustomerName = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //endstocksales.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    endstocksales.Division = Convert.ToInt32(sdr["DIVISION"]);
                    ///*endstocksales*/.RegionCode = sdr["RegionCode"].ToString();
                    //endstocksales.AreaCode = sdr["AreaCode"].ToString();
                    //endstocksales.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //endstocksales.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //endstocksales.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(endstocksales);
                }
            }
            return rolelist;

        }

    }
}