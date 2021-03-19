using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace BusinessLayer.Repository
{
    public class CustomerBusiness
    {
        //private Connection con;
        //private SqlCommand cmd;
        private string Messages = string.Empty;
        public IEnumerable<CustomerModel> GetAllCustomer
        {
            get
            {
                Connection con = new Connection();
                List<CustomerModel> CustomerList = new List<CustomerModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("SP_GetAllCustomers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerModel Customerr = new CustomerModel();
                        Customerr.Customer = Convert.ToInt32(sdr["Customer"]);
                        Customerr.Name1 = sdr["Name1"].ToString();
                        CustomerList.Add(Customerr);
                    }
                }
                return CustomerList;
            }
        }

        public IEnumerable<CustomerModel> GetAllCustomerRecords
        {
            get
            {
                Connection con = new Connection();
                List<CustomerModel> rolelist = new List<CustomerModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllCustomers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        CustomerModel customer = new CustomerModel();
                        customer.Customer = Convert.ToInt32(sdr["Customer"]);
                        customer.Name1 = sdr["ShoDisting"].ToString();
                        customer.Name2 = sdr["Name2"].ToString();
                        customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                        customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                        customer.Division = sdr["Division"].ToString();
                        customer.RegionCode = sdr["RegionCode"].ToString();
                        customer.AreaCode = sdr["AreaCode"].ToString();
                        customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                        customer.TownCode = sdr["TownCode"].ToString();
                        customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                        customer.RegionDescription = sdr["RegionDescription"].ToString();
                        customer.AreaDescription = sdr["AreaDescription"].ToString();
                        customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                        customer.TownDescription = sdr["TownDescription"].ToString();
                        customer.PlantDescription = sdr["PlantDescription"].ToString();
                        rolelist.Add(customer);
                    }

                }
                return rolelist;
            }
        }
        public IEnumerable<CustomerModel> GetAllCustomerRecords2(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_AllCustomers_RegionWise", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    customer.Name1 = sdr["Name1"].ToString();
                    customer.Name2 = sdr["Name2"].ToString();
                    customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    customer.Division = sdr["Division"].ToString();
                    customer.RegionCode = sdr["RegionCode"].ToString();
                    customer.AreaCode = sdr["AreaCode"].ToString();
                    customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    customer.TownCode = sdr["TownCode"].ToString();
                    customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    customer.RegionDescription = sdr["RegionDescription"].ToString();
                    customer.AreaDescription = sdr["AreaDescription"].ToString();
                    customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    customer.TownDescription = sdr["TownDescription"].ToString();
                    customer.PlantDescription = sdr["PlantDescription"].ToString();
                    customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetCustomer(string name = null, string sales = null, string div = null, string category = null, string region = null, string area = null, string territory = null, string town = null, string plant = null)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomerName_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    customer.Name1 = sdr["Name1"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetSalesOrg(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetSalesOrg_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    
                    customer.SalesOrganization = sdr["SalesOrganization"].ToString();
               
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetDivision(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetDivision_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    customer.Division = sdr["Division"].ToString();
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
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetCategory(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetPackage_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
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
                    customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetRegion(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetRegion_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetArea(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetArea_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetTerritory(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetTerritory_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    //customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetTown(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetTown_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    customer.TownCode = sdr["TownCode"].ToString();
                    //customer.DeliveringPlant = sdr["DeliveringPlant"].ToString();
                    //customer.RegionDescription = sdr["RegionDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }

        public IEnumerable<CustomerModel> GetPlant(string name, string sales, string div, string category, string region, string area, string territory, string town, string plant)
        {
            Connection con = new Connection();
            List<CustomerModel> rolelist = new List<CustomerModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetPlant_Customer", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", name == null || name == "null" ? "" : name);
                cmd.Parameters.AddWithValue("@salesOrg", sales == "null" || sales == null ? "" : sales);
                cmd.Parameters.AddWithValue("@div", div == "null" || div == null ? "" : div);
                cmd.Parameters.AddWithValue("@Category", category == "null" || category == null ? "" : category);
                cmd.Parameters.AddWithValue("@RegionCode", region == "null" || region == null ? "" : region);
                cmd.Parameters.AddWithValue("@AreaCode", area == "null" || area == null ? "" : area);
                cmd.Parameters.AddWithValue("@TerritoryCode", territory == "null" || territory == null ? "" : territory);
                cmd.Parameters.AddWithValue("@TownCode", town == "null" || town == null ? "" : town);
                cmd.Parameters.AddWithValue("@plant", plant == "null" || plant == null ? "" : plant);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    CustomerModel customer = new CustomerModel();
                    //customer.Customer = Convert.ToInt32(sdr["Customer"]);
                    //customer.Name1 = sdr["Name1"].ToString();
                    //customer.Name2 = sdr["Name2"].ToString();
                    //customer.SalesOrganization = sdr["SalesOrganization"].ToString();
                    //customer.DistributionChannel = sdr["DistributionChannel"].ToString();
                    //customer.Division = sdr["Division"].ToString();
                    //customer.RegionCode = sdr["RegionCode"].ToString();
                    //customer.AreaCode = sdr["AreaCode"].ToString();
                    //customer.TerritoryCode = sdr["TerritoryCode"].ToString();
                    customer.TownCode = sdr["DeliveringPlant"].ToString();
                    customer.DeliveringPlant = sdr["PlantDescription"].ToString();
                    //customer.RegionDescription = sdr["PlantDescription"].ToString();
                    //customer.AreaDescription = sdr["AreaDescription"].ToString();
                    //customer.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    //customer.TownDescription = sdr["TownDescription"].ToString();
                    //customer.PlantDescription = sdr["PlantDescription"].ToString();
                    //customer.packageName = sdr["packageName"].ToString();
                    rolelist.Add(customer);
                }
            }
            return rolelist;

        }
    }
}
