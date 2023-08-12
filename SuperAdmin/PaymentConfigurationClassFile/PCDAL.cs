using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.PaymentConfigurationClassFile
{
    public class PCDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetAllClientsPaymentConfiguration()
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllClientsPaymentConfiguration";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@clientId", clientId);
                //cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetClientsPaymentConfigurationById(int id)
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetClientsPaymentConfigurationById";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetClientsPaymentConfigurationByClientId(string clientId)
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetClientsPaymentConfigurationByClientId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int AddNewClientsPaymentConfiguration(ClientPaymentConfiguration parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewClientsPaymentConfiguration";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@paymentGateWay", parameter.PaymentGateWay);
                cmd.Parameters.AddWithValue("@clientId", parameter.ClientId);
                cmd.Parameters.AddWithValue("@paymentPassword", parameter.PaymentPassword);
                cmd.Parameters.AddWithValue("@merchantId", parameter.MerchantId);
                cmd.Parameters.AddWithValue("@isActive", parameter.IsActive);
                cmd.Parameters.AddWithValue("@requestHashKey", parameter.RequestHashKey);
                cmd.Parameters.AddWithValue("@responseHashKey", parameter.ResponseHashKey);
                cmd.Parameters.AddWithValue("@requestAESKey", parameter.RequestAESKey);
                cmd.Parameters.AddWithValue("@responseAESKey", parameter.ResponseAESKey);
                cmd.Parameters.AddWithValue("@transactionType", parameter.TransactionType);
                cmd.Parameters.AddWithValue("@productId", parameter.ProductId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(applicationUserId));
                cmd.Parameters.AddWithValue("@razorKey", parameter.RazorKey);
                cmd.Parameters.AddWithValue("@razorSecretKey", parameter.RazorSecretKey);
                cmd.Parameters.AddWithValue("@MerchantCode", parameter.MerchantCode);
                cmd.Parameters.AddWithValue("@IsKey", parameter.IsKey);
                cmd.Parameters.AddWithValue("@IsIv", parameter.IsIv);

                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateClientsPaymentConfiguration(ClientPaymentConfiguration parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateClientsPaymentConfiguration";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", parameter.Id);
                cmd.Parameters.AddWithValue("@paymentGateWay", parameter.PaymentGateWay);
                cmd.Parameters.AddWithValue("@clientId", parameter.ClientId);
                cmd.Parameters.AddWithValue("@paymentPassword", parameter.PaymentPassword);
                cmd.Parameters.AddWithValue("@merchantId", parameter.MerchantId);
                cmd.Parameters.AddWithValue("@isActive", parameter.IsActive);
                cmd.Parameters.AddWithValue("@requestHashKey", parameter.RequestHashKey);
                cmd.Parameters.AddWithValue("@responseHashKey", parameter.ResponseHashKey);
                cmd.Parameters.AddWithValue("@requestAESKey", parameter.RequestAESKey);
                cmd.Parameters.AddWithValue("@responseAESKey", parameter.ResponseAESKey);
                cmd.Parameters.AddWithValue("@transactionType", parameter.TransactionType);
                cmd.Parameters.AddWithValue("@productId", parameter.ProductId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(applicationUserId));
                cmd.Parameters.AddWithValue("@razorKey", parameter.RazorKey);
                cmd.Parameters.AddWithValue("@razorSecretKey", parameter.RazorSecretKey);
                cmd.Parameters.AddWithValue("@MerchantCode", parameter.MerchantCode);
                cmd.Parameters.AddWithValue("@IsKey", parameter.IsKey);
                cmd.Parameters.AddWithValue("@IsIv", parameter.IsIv);

                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int DeleteClientsPaymentConfiguration(string clientId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteClientsPaymentConfiguration";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", clientId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(createdBy));

                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int PublishClientsPaymentConfiguration(List<ClientPaymentConfiguration> parameter)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                SqlTransaction tran = null;
                try
                {
                    tran = con1.BeginTransaction("Transaction1");
                    strsqlquery = "PublishClientsPaymentConfiguration";
                    int sequenceNumber = 1;
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", item.ClientId);
                        cmd.Parameters.AddWithValue("@isActive", item.IsActive);
                        var updatedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                        cmd.Parameters.AddWithValue("@updatedBy", int.Parse(updatedBy));

                        result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            noofSuccess += 1;
                        }
                        sequenceNumber += 1;
                    }
                    tran.Commit();
                    if (con1.State != ConnectionState.Closed)
                    {
                        con1.Close();
                    }
                    return noofSuccess;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                    con1.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetFeeTransactionBySuperAdmin()
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetFeeTransactionBySuperAdmin";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@clientId", clientId);
                //cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}