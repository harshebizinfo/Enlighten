using LMS.Common.ClassFile;
using LMS.Learner.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Learner.PaymentCLassFile
{
    public class PaymentDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public int AddNewTempPaymentDetail(TempPaymentDetailField parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewTempPaymentDetail";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", parameter.DepartmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", parameter.CourseSubjectId);
                cmd.Parameters.AddWithValue("@examId", parameter.ExamId);
                cmd.Parameters.AddWithValue("@paymentNumberOfTimes", parameter.PaymentNumberOfTimes);
                cmd.Parameters.AddWithValue("@referenceNumber", parameter.ReferenceNumber);
                cmd.Parameters.AddWithValue("@verified", parameter.Verified);
                cmd.Parameters.AddWithValue("@transactionDate", parameter.TransactionDate);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
                cmd.Parameters.AddWithValue("@clientId", clientId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", createdBy);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(createdBy));
                cmd.Parameters.AddWithValue("@id", SqlDbType.Int).Direction = ParameterDirection.Output;

                var result = cmd.ExecuteNonQuery();
                cmd.Dispose();
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
        public DataTable GetPaymentDetail(int departmentStandardId, int courseSubjectId, int examId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                strsqlquery = "GetPaymentDetail";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examId", examId);
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTempPaymentDetailById(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                strsqlquery = "GetTempPaymentDetailById";
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
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetPaymentData(int standardId,int academicYear,string admissionNumber)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                strsqlquery = "GetPaymentData";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClassName", standardId);
                cmd.Parameters.AddWithValue("@academicYear", academicYear);
                cmd.Parameters.AddWithValue("@admissionNumber", admissionNumber);
                //var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                //cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable CheckPreviousBalanceExists()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                strsqlquery = "CheckPreviousBalanceExists";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllTempPaymentDetail()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                strsqlquery = "GetAllTempPaymentDetail";
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
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int updatePaymentTempverifiedstatus(string referencenumber)
        {
            int result = 0;
            connection1 = objdal01.Conncetion();
            SqlConnection con1 = new SqlConnection(connection1);
            try
            {
                if (con1.State == ConnectionState.Closed)
                {
                    con1.Open();
                }
                SqlCommand cmd = new SqlCommand("sp_updateTempPaymentstatus_verified", con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@referenceno", referencenumber);
                result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return result;
                }
                cmd.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
            }
        }
        public int get_if_paymentreferenceid_exist(string referencenumber)
        {
            int result = 0;
            connection1 = objdal01.Conncetion();
            SqlConnection coninstitute = new SqlConnection(connection1);
            try
            {
                if (coninstitute.State == ConnectionState.Closed)
                {
                    coninstitute.Open();
                }
                string query = @"select * from FeeTransaction where OnlineRefNo='" + referencenumber + "'";
                SqlCommand cmd = new SqlCommand(query, coninstitute);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    result = 1;
                }

                cmd.Dispose();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (coninstitute.State != ConnectionState.Closed)
                {
                    coninstitute.Close();
                }
            }
        }
    }
}