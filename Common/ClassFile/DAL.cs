using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Common.ClassFile
{
    public class ClientConnection
    {
        public string Conncetion()
        {
            //string databasename = Convert.ToString(System.Web.HttpContext.Current.Session["DatabaseName"]);

            //string databasename = "CID20211124";
            string databasename = Convert.ToString(System.Web.HttpContext.Current.Session["DatabaseName"]);
            string connection1 = @"Data Source=DESKTOP-RALBFLT\SQLEXPRESS;Initial Catalog=" + databasename + ";Integrated Security=true";
            //string connection1 = @"Data Source=WIN-MN8LM32RG64;Initial Catalog=" + databasename + ";Integrated Security=true";
            //string connection1 = @"Data Source=180.149.243.170;  User ID=meena;Password=PepsiCoak@123;Initial Catalog=" + databasename + ";Integrated Security=false;Max Pool Size=10000";
            return connection1;

        }
    }
    public class DAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetClientinfo(ClientDetail objbol)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database
                strsqlquery = "GetCilent";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@client_id", objbol.ClientID);
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
        public bool VerifyAESSaltKey(string saltKey)
        {
            // bool condition;
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "VerifySaltKey";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@passwordSaltKey", saltKey);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                // return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataTable UserLogin(string email)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UserLogin";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", email);
                if(email.Contains("SuperAdmin"))
                {
                    cmd.Parameters.AddWithValue("@SuperAdmin", "SuperAdmin");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SuperAdmin", "Other");
                }
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
        public DataTable GetGroupName(string email)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "GetUserRole";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", email);
                if (email.Contains("SuperAdmin"))
                {
                    cmd.Parameters.AddWithValue("@SuperAdmin", "SuperAdmin");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@SuperAdmin", "Other");
                }
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
        public int SetNumberOfAttempts(string email, int numberofAttempts)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "SetNumberOfAttempts";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", email);
                cmd.Parameters.AddWithValue("@NumberOfAttempts", numberofAttempts);
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
        public int RegisterUser(AddUser parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "CreateNewRegisterUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emailID", parameter.Email);
                cmd.Parameters.AddWithValue("@firstName", parameter.FirstName);
                cmd.Parameters.AddWithValue("@lastName", parameter.LastName);
                cmd.Parameters.AddWithValue("@encryptedHashKey", parameter.PasswordHashKey);
                cmd.Parameters.AddWithValue("@encryptedSaltKey", parameter.PasswordSaltKay);
                cmd.Parameters.AddWithValue("@contactNumber", parameter.MobileNumber);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(createdBy));

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
        public int SetUserPassword(string email, string encryptedSaltKey, string encryptedHashKey)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "SetPassword";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emailID", email);
                cmd.Parameters.AddWithValue("@encryptedHashKey", encryptedHashKey);
                cmd.Parameters.AddWithValue("@encryptedsaltkey", encryptedSaltKey);

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
        public int SetSaltKeyOfUser(string email, string encryptedSaltKey)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "SetSaltKeyOfUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emailID", email);
                cmd.Parameters.AddWithValue("@encryptedsaltkey", encryptedSaltKey);

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
    }
}