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
    public class salesForcastBusiness
    {

        public IEnumerable<salesForcastModel> GetDropDownCustomer
        {
            get
            {
                Connection con = new Connection();
                List<salesForcastModel> CustomerList = new List<salesForcastModel>();
                using (SqlConnection sqlcon = con.GetDataBaseConnection())
                {
                    SqlCommand cmd = new SqlCommand("Get_AllCustomers", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        salesForcastModel Customer = new salesForcastModel();
                        Customer.Customer = Convert.ToInt32(sdr["Customer"]);
                        Customer.Name1 = sdr["Name1"].ToString();

                        CustomerList.Add(Customer);
                    }
                }
                return CustomerList;
            }
        }

        public List<salesForcastModel> getCalday(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetCalDay_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                    salesForcastModel.CalendarDay = sdr["CALDAY"].ToString();
                   
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getCompCode(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetCompCode_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                   
                    salesForcastModel.Company = sdr["COMP_CODE"].ToString() == "" ? 0 : Convert.ToInt32(sdr["COMP_CODE"]);
                  
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getSalesOrg(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetSalesOrg_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                
                    salesForcastModel.SalesOrganization = sdr["SALESORG"].ToString() == "" ? 0 : Convert.ToInt32(sdr["SALESORG"]);
                   
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getDistr(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetDistr_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                   
                    salesForcastModel.DistributionChannel = sdr["DISTR_CHAN"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DISTR_CHAN"]);
                  
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }


        public List<salesForcastModel> getDivision(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetDiv_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                 
                    salesForcastModel.Division = sdr["DIVISION"].ToString() == "" ? 0 : Convert.ToInt32(sdr["DIVISION"]);
                
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getPlant(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetPlant_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                   
                    salesForcastModel.Plant = sdr["PLANT"].ToString() == "" ? 0 : Convert.ToInt32(sdr["PLANT"]);
                 
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getCustomer(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetCustomer_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "0000000000null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                  
                    salesForcastModel.CustomerCode = sdr["CUSTOMER"].ToString() == "" ? "0" : sdr["CUSTOMER"].ToString();
                    salesForcastModel.ZDOC_CATG = sdr["Name1"].ToString();
                  
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public List<salesForcastModel> getMaterial(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {
            Connection con = new Connection();
            List<salesForcastModel> Caldaylist = new List<salesForcastModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("SP_GetMaterial_SaleforeCast", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@SALESORG", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@PLANT", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@CUSTOMER", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@MATERIAL", material == "null" || material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                   
                    salesForcastModel.ZDOC_CATG = sdr["Description"].ToString();
                    salesForcastModel.MaterialCode = sdr["MATERIAL"].ToString();
                    
                    Caldaylist.Add(salesForcastModel);
                }
            }
            return Caldaylist;
        }

        public IEnumerable<salesForcastModel> gridViewsalesForcast(string CALDAY, string company, string sales, string distr, string div, string plant, string customer, string material, string ZDOC_CATG, string ZBPCACC, string ZBPCVERS, string qty)
        {


            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<salesForcastModel> dd = new List<salesForcastModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_ALLRSF", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CALDAY", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@COMP_CODE", company == null || company == "null" ? "" : company);
                cmd.Parameters.AddWithValue("@salesOrg", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@Distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Plant", plant == null || plant == "null" ? "" : plant);
                cmd.Parameters.AddWithValue("@customer", customer == "null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@ZDOC_CATG", ZDOC_CATG == null || ZDOC_CATG == "null" ? "" : ZDOC_CATG);
                cmd.Parameters.AddWithValue("@ZBPCACC", ZBPCACC == null || ZBPCACC == "null" ? "" : ZBPCACC);
                cmd.Parameters.AddWithValue("@ZBPCVERS", ZBPCVERS == null || ZBPCVERS == "null" ? "" : ZBPCVERS);
                cmd.Parameters.AddWithValue("@BPCTOTPAGE", qty == null || qty == "null" ? "" : qty);
                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    salesForcastModel salesForcastModel = new salesForcastModel();
                    salesForcastModel.CalendarDay = sdr["CALDAY"].ToString();
                    salesForcastModel.Company = Convert.ToInt32(sdr["COMP_CODE"]);
                    salesForcastModel.SalesOrganization = Convert.ToInt32(sdr["SALESORG"]);
                    salesForcastModel.DistributionChannel = Convert.ToInt32(sdr["DISTR_CHAN"]);
                    salesForcastModel.Division = Convert.ToInt32(sdr["DIVISION"]);
                    salesForcastModel.Plant = Convert.ToInt32(sdr["PLANT"]);
                    salesForcastModel.CustomerSoldToParty = Convert.ToInt32(sdr["CUSTOMER"]);
                    salesForcastModel.Material = Convert.ToInt32(sdr["MATERIAL"]);
                    salesForcastModel.CustomerName = sdr["CustomerName"].ToString();
                    salesForcastModel.MaterialDescription = sdr["MaterialDesc"].ToString();
                    salesForcastModel.ZDOC_CATG = sdr["ZDOC_CATG"].ToString();
                    salesForcastModel.ZBPCACC = sdr["ZBPCACC"].ToString();
                    salesForcastModel.ZBPCVERS = sdr["ZBPCVERS"].ToString();

                    salesForcastModel.Quantity = Convert.ToDouble(sdr["BPCTOTPAGE"]);

                    salesForcastModel.Payer = Convert.ToInt32(sdr["PAYER"]);
                    salesForcastModel.GrWtKg = sdr["GR_WT_KG"].ToString();

                    salesForcastModel.GRNetKg = sdr["NT_WT_KG"].ToString();

                    //Moazzam
                    salesForcastModel.Name1 = sdr["Name1"].ToString();
                    salesForcastModel.Name2 = sdr["Name2"].ToString();
                    salesForcastModel.RegionDescription = sdr["RegionDescription"].ToString();
                    salesForcastModel.AreaDescription = sdr["AreaDescription"].ToString();
                    salesForcastModel.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    salesForcastModel.TownDescription = sdr["TownDescription"].ToString();

                    dd.Add(salesForcastModel);
                }
                sqlcon.Close();
            }
            return dd;

        }


        public IEnumerable<salesForcastModel> gridViewsalesForcastExe
        {

            get
            {
                string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
                List<salesForcastModel> dd = new List<salesForcastModel>();
                DateTime tm = DateTime.Now;
                using (SqlConnection sqlcon = new SqlConnection(Conn))
                {
                    SqlCommand cmd = new SqlCommand("Get_ALLRSF", sqlcon);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sqlcon.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        salesForcastModel salesForcastModel = new salesForcastModel();
                        salesForcastModel.CalendarDay = sdr["CalendarDay"].ToString();
                        salesForcastModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                        salesForcastModel.Company = Convert.ToInt32(sdr["Company"]);
                        salesForcastModel.Plant = Convert.ToInt32(sdr["Plant"]);
                        salesForcastModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                        salesForcastModel.Division = Convert.ToInt32(sdr["Division"]);
                        salesForcastModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                        salesForcastModel.Material = Convert.ToInt32(sdr["Material"]);
                        salesForcastModel.Quantity = Convert.ToDouble(sdr["Quantity"]);

                        dd.Add(salesForcastModel);
                    }
                    sqlcon.Close();
                }
                return dd;
            }
        }
    }
}