using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Admin.DepartmentClassFile
{
    public class DeptDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetDepartmentStandardList(string typeValue)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetDepartmentStandardList";
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
        public DataTable GetDepartmentStandardUnderTraineeList(string typeValue)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetDepartmentStandardList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", typeValue);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(createdBy));
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
        public int AddNewDepartmentStandard(string divisionName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewDepartmentStandard";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentName", divisionName);
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
        public int UpdateDepartmentStandard(int id, string divisionName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateDepartmentStandard";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentName", divisionName);
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
        public int DeleteDepartmentStandard(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteDepartmentStandard";
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
        public int PublishDepartment(List<DepartmentStandardList> parameter)
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
                    strsqlquery = "PublishDepartment";
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
        public DataTable GetListOfDepartmentByUserId()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetListOfDepartmentByUserId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(createdBy));
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
        public DataTable GetTehseelMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetTehseelMasterList";
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
        public DataTable GetCityMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetCityMasterList";
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
        public DataTable GetMediumMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetMediumMasterList";
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
        public DataTable GetStreamMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStreamMasterList";
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
        public DataTable GetEducationMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetEducationMasterList";
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
        public DataTable GetOccupationMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetOccupationMasterList";
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
        public DataTable GetDocumentMasterList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetDocumentMasterList";
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
        public DataTable GetStudentInformationList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStudentInformationList";
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
        public DataTable GetStudentInformationListByApplicationUserId()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStudentInformationListByApplicationUserId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                var deletedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(deletedBy));
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
        public DataTable GetStudentInformationDetailsByApplicationUserId()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStudentInformationDetailsByApplicationUserId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                var deletedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(deletedBy));
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