using LMS.Common.ClassFile;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.ClientClassFile
{
    public class ClientDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetAllClient()
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllClient";
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
        public DataTable GetPaymentMethod()
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetPaymentMethod";
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
        public DataTable GetClientByClientId(string clientId)
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetClientByClientId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
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
        public int AddNewClient(AddNewClientDetail parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientname", parameter.ClientName);
                cmd.Parameters.AddWithValue("@emailid", parameter.EmailId);
                cmd.Parameters.AddWithValue("@countryCode", "+91");
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@address", parameter.Address);
                cmd.Parameters.AddWithValue("@institutename", parameter.InstituteName);
                cmd.Parameters.AddWithValue("@logoPath", parameter.LogoPath);
                cmd.Parameters.AddWithValue("@paymentMode", parameter.PaymentTypeId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId==""?0:int.Parse(applicationUserId));

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
        public int EditNewClient(AddNewClientDetail parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "EditNewClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientid", parameter.ClientId);
                cmd.Parameters.AddWithValue("@clientname", parameter.ClientName);
                cmd.Parameters.AddWithValue("@emailid", parameter.EmailId);
                cmd.Parameters.AddWithValue("@countryCode", "+91");
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@address", parameter.Address);
                cmd.Parameters.AddWithValue("@institutename", parameter.InstituteName);
                cmd.Parameters.AddWithValue("@logoPath", parameter.LogoPath);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId == "" ? 0 : int.Parse(applicationUserId));
                cmd.Parameters.AddWithValue("@isGoogleSubscription", parameter.IsGoogleSubscription);
                cmd.Parameters.AddWithValue("@paymentMode", parameter.PaymentTypeId);

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
        public int EditClientSubscription(string clientId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "EditClientSubscription";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientid", clientId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId == "" ? 0 : int.Parse(applicationUserId));

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
        public int CreateTableInDatabase(string script, string databaseName)
        {
            int result = 0;
            //string connection1 = @"Data Source=180.149.243.170;User ID=meena;Password=PepsiCoak@123;Initial Catalog=" + databaseName + ";Integrated Security=false;Max Pool Size=10000";
            //SqlConnection con_createdb = new SqlConnection(connection1);
            SqlConnection con_createdb = new SqlConnection(@"Data Source=DESKTOP-RALBFLT\SQLEXPRESS;Initial Catalog=" + databaseName + ";Integrated Security=true");
            //SqlConnection con_createdb = new SqlConnection(@"Data Source=WIN-MN8LM32RG64;Initial Catalog=" + databaseName + ";Integrated Security=true");
            try
            {
                if (con_createdb.State == ConnectionState.Closed)
                {
                    con_createdb.Open();
                }
                //SqlConnection conn = new SqlConnection(sqlConnectionString);

                Server server = new Server(new ServerConnection(con_createdb));

                server.ConnectionContext.ExecuteNonQuery(script);
                result = 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con_createdb.State != ConnectionState.Closed)
                {
                    con_createdb.Close();
                }
            }
            return result;
        }
        public int ActivateDatabaseAndClient(string clientId)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "ActivateDatabaseAndClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@id", int.Parse(applicationUserId));
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
        public int CreateAdminOfClient(string clientId)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "CreateAdminOfClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(applicationUserId));
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
        public int DeleteClient(string clientId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@deletedBy", int.Parse(createdBy));

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
        public int PublishClient(List<AddNewClientDetail> parameter)
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
                    strsqlquery = "PublishClient";
                    int sequenceNumber = 1;
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@clientId", item.ClientId);
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
    }
}