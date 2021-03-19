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
    public class materialMasterBusiness
    {
        public IEnumerable<materialMasterModel> GetAllMaterials(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_ALLMaterial", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.Material = Convert.ToInt32(sdr["Material"]);
                    materialMasterModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    materialMasterModel.DistributionChannel = Convert.ToInt32(sdr["DistributionChannel"]);
                    materialMasterModel.Division = Convert.ToInt32(sdr["Division"]);
                    materialMasterModel.Materialpricinggrp = Convert.ToInt32(sdr["Materialpricinggrp"]);
                    materialMasterModel.MaterialGroup = Convert.ToInt32(sdr["MaterialGroup"]);
                    materialMasterModel.MaterialType = sdr["MaterialType"].ToString();
                    materialMasterModel.Description = sdr["Description"].ToString();
                    materialMasterModel.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    materialMasterModel.MaterialGroupdescription = sdr["MaterialGroupdescription"].ToString();
                    materialMasterModel.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    materialMasterModel.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    materialMasterModel.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    materialMasterModel.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    materialMasterModel.MaterialTypeDescripiton = sdr["MaterialTypeDescripiton"].ToString();

                    materialMasterModel.unitPrice = sdr["unitPrice"].ToString();

                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetMaterials(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Material_MATERIAL", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.Material = Convert.ToInt32(sdr["Material"]);
                    materialMasterModel.Description = sdr["Description"].ToString();
                    materialMasterModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"].ToString());
                    materialMasterModel.Division = Convert.ToInt32(sdr["Division"].ToString());
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetSalesOrg(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Material_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.SalesOrganization = Convert.ToInt32(sdr["SalesOrganization"]);
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetPGD(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_PGD_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MatPricingGrpDescription = sdr["MatPricingGrpDescription"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetGROUP1(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_GROUP1_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MaterialGroup1_Description = sdr["MaterialGroup1_Description"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetGROUP2(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_GROUP2_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MaterialGroup2_Description = sdr["MaterialGroup2_Description"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetGROUP3(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_GROUP3_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MaterialGroup3_Description = sdr["MaterialGroup3_Description"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetGROUP4(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_GROUP4_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MaterialGroup4_Description = sdr["MaterialGroup4_Description"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetGROUP5(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_GROUP5_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.MaterialGroup5_Description = sdr["MaterialGroup5_Description"].ToString();
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }

        public IEnumerable<materialMasterModel> GetDivision(string material, string sales, string PGD, string group1, string group2, string group3, string group4, string group5, string Division)
        {

            Connection con = new Connection();
            List<materialMasterModel> materialMasterModelList = new List<materialMasterModel>();
            using (SqlConnection sqlcon = con.GetDataBaseConnection())
            {
                SqlCommand cmd = new SqlCommand("Get_Division_SALESORG", sqlcon);
                cmd.Parameters.AddWithValue("@material", material == null || material == "null" ? "" : material);
                cmd.Parameters.AddWithValue("@sales", sales == null || sales == "null" ? "" : sales);
                cmd.Parameters.AddWithValue("@pgd", PGD == null || PGD == "null" ? "" : PGD);
                cmd.Parameters.AddWithValue("@group1", group1 == null || group1 == "null" ? "" : group1);
                cmd.Parameters.AddWithValue("@group2", group2 == null || group2 == "null" ? "" : group2);
                cmd.Parameters.AddWithValue("@group3", group3 == null || group3 == "null" ? "" : group3);
                cmd.Parameters.AddWithValue("@group4", group4 == null || group4 == "null" ? "" : group4);
                cmd.Parameters.AddWithValue("@group5", group5 == null || group5 == "null" ? "" : group5);
                cmd.Parameters.AddWithValue("@Division", Division == null || Division == "null" ? "" : Division);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    materialMasterModel materialMasterModel = new materialMasterModel();
                    materialMasterModel.Division = Convert.ToInt32(sdr["Division"]);
                    materialMasterModelList.Add(materialMasterModel);
                }
            }
            return materialMasterModelList;

        }





    }
}