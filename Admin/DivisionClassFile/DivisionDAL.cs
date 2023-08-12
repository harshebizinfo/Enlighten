using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Admin.DivisionClassFile
{
    public class DivisionDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetDivisionList(string typeValue)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetDivisionList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", typeValue);
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
        public int AddNewDivision(string divisionName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewDivision";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@divisionName", divisionName);
                cmd.Parameters.AddWithValue("@ispublished", ispublished);
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
        public int UpdateDivision(int id, string divisionName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateDivision";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@divisionName", divisionName);
                cmd.Parameters.AddWithValue("@ispublished", ispublished);
                cmd.Parameters.AddWithValue("@id", id);
                var updatedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(updatedBy));

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
        public int DeleteDivision(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteDivision";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var deletedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@deletedBy", int.Parse(deletedBy));

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
        public int PublishDivision(List<DivisionList> parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                SqlTransaction tran = null;
                try
                {
                    tran = con1.BeginTransaction("Transaction1");
                    strsqlquery = "PublishDivision";
                    int sequenceNumber = 1;
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", item.Id);
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
        public DataTable GetClassDivisionAllotment()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetClassDivisionAllotment";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public int AssignClassDivisionAllotment(int departmentStandardId, int divisionId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AssignClassDivisionAllotment";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@divisionId", divisionId);
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
        public int DeleteClassDivisionAllotment(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteClassDivisionAllotment";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var updatedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@deletedBy", int.Parse(updatedBy));

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
        public DataTable GetDivisionUnderDepartmentId(int departmentStandardId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetDivisionUnderDepartmentId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
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
        public DataTable GetStudentDetailUnderDepartmentAndDivision(int standardId,int divisionId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStudentDetailUnderDepartmentAndDivision";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", standardId);
                cmd.Parameters.AddWithValue("@divisionId", divisionId);
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