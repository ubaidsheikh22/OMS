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
    public class secondarySaleBusiness
    {
        public IEnumerable<secondarySalesModel> gridViewSecondarySales(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllSecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    secondarySalesModel.Name1 = sdr["Name1"].ToString();
                    secondarySalesModel.CustomerName2 = sdr["Name2"].ToString();
                    secondarySalesModel.RegionDescription = sdr["RegionDescription"].ToString();
                    secondarySalesModel.AreaDescription = sdr["AreaDescription"].ToString();
                    secondarySalesModel.TerritoryDescription = sdr["TerritoryDescription"].ToString();
                    secondarySalesModel.TownDescription = sdr["TownDescription"].ToString();
                    secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    secondarySalesModel.Description = sdr["Description"].ToString();
                    secondarySalesModel.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    secondarySalesModel.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    secondarySalesModel.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    secondarySalesModel.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    secondarySalesModel.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    secondarySalesModel.MaterialGroup5_Description = sdr["MaterialGroup5_Description"].ToString();
                    secondarySalesModel.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    secondarySalesModel.UOM = sdr["UOM"].ToString();
                    secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetCALDAY(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllCALDAY_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);



                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    //secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetComp(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllComp_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    //secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetSalesOrg(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllSalesOrg_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    //secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetDistr(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllDistr_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    //secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetDiv(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllDiv_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    //secondarySalesModel.Description = sdr["Material_Descr"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetCustomer(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllCustomer_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    //secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    secondarySalesModel.Description = sdr["Name1"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }

        public IEnumerable<secondarySalesModel> GetMaterial(string CALDAY, string Comp, string salesorg, string distr, string div, string customer, string material)
        {

            string Conn = ConfigurationManager.ConnectionStrings["OMSContext"].ToString();
            List<secondarySalesModel> secondarySalesList = new List<secondarySalesModel>();
            DateTime tm = DateTime.Now;
            using (SqlConnection sqlcon = new SqlConnection(Conn))
            {
                SqlCommand cmd = new SqlCommand("Get_AllMaterial_SecondarySales", sqlcon);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@calday", CALDAY == null || CALDAY == "null" ? "" : CALDAY);
                cmd.Parameters.AddWithValue("@comp", Comp == null || Comp == "null" ? "" : Comp);
                cmd.Parameters.AddWithValue("@salesorg", salesorg == null || salesorg == "null" ? "" : salesorg);
                cmd.Parameters.AddWithValue("@distr", distr == null || distr == "null" ? "" : distr);
                cmd.Parameters.AddWithValue("@div", div == null || div == "null" ? "" : div);
                cmd.Parameters.AddWithValue("@Customer", customer == "0000null" || customer == null || customer == "null" ? "" : customer);
                cmd.Parameters.AddWithValue("@Material", material == "0000000000null" || material == null || material == "null" ? "" : material);

                sqlcon.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    secondarySalesModel secondarySalesModel = new secondarySalesModel();
                    //secondarySalesModel.CalendarDay = sdr["CalendarDay"].ToString();
                    //secondarySalesModel.Company = Convert.ToInt32(sdr["Company"]);
                    //secondarySalesModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    //secondarySalesModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    //secondarySalesModel.Division = Convert.ToInt32(sdr["Division"]);
                    //secondarySalesModel.CustomerSoldToParty = Convert.ToInt32(sdr["CustomerSoldToParty"]);
                    secondarySalesModel.Material = Convert.ToInt32(sdr["Material"]);
                    //secondarySalesModel.UOM = sdr["UOM"].ToString();
                    //secondarySalesModel.Quantity = Convert.ToDouble(sdr["roundedQTY"]);
                    secondarySalesModel.Description = sdr["Description"].ToString();
                    //secondarySalesModel.Name1 = sdr["CustomerName"].ToString();

                    secondarySalesList.Add(secondarySalesModel);
                }
                sqlcon.Close();
            }
            return secondarySalesList;

        }
    }
}