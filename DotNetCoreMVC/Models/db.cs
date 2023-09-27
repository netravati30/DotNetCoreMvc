using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMVC.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Server=NETRAVATIH; Database=VisProductivity;MultipleActiveResultSets=true; User Id = sa; Password=Vistar@123$");

        // For View record
        public string BranchInsert(Branch branch, out string msg)
        {
          //  DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Insert_BranchDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BranchId", branch.BranchId);
                com.Parameters.AddWithValue("@BranchName", branch.BranchName);
                com.Parameters.AddWithValue("@Cluster", branch.Cluster);
                com.Parameters.AddWithValue("@State", branch.State);
                com.Parameters.AddWithValue("@Status", branch.Status);
                com.Parameters.AddWithValue("@CollectionBranch", branch.CollectionBranch);
                com.Parameters.AddWithValue("@Tier", branch.Tier);
                com.Parameters.AddWithValue("@Region", branch.Region);
                com.Parameters.AddWithValue("@Zone", branch.Zone);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }

        public string BranchUpdate(Branch branch, out string msg)
        {
            //  DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Update_BranchDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BranchId", branch.BranchId);
                com.Parameters.AddWithValue("@BranchName", branch.BranchName);
                com.Parameters.AddWithValue("@Cluster", branch.Cluster);
                com.Parameters.AddWithValue("@State", branch.State);
                com.Parameters.AddWithValue("@Status", branch.Status);
                com.Parameters.AddWithValue("@CollectionBranch", branch.CollectionBranch);
                com.Parameters.AddWithValue("@Tier", branch.Tier);
                com.Parameters.AddWithValue("@Region", branch.Region);
                com.Parameters.AddWithValue("@Zone", branch.Zone);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "OK";
                return msg;
            }
            catch (Exception ex)
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                msg = ex.Message;
                return msg;
            }
        }

        public DataSet GetBranchDetails(Branch branch, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Get_BranchMasterDetails", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        public DataSet GetBranchDetails1(Branch branch, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("Get_BranchMasterDetails1", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BranchId", branch.BranchId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

        public DataSet DeleteBranchDetails(Branch branch, out string msg)
        {
            DataSet ds = new DataSet();
            msg = "";
            try
            {
                SqlCommand com = new SqlCommand("[Delete_BranchMasterDetails]", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@BranchId", branch.BranchId);
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
                msg = "OK";
                return ds;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return ds;
            }
        }

    }
}
