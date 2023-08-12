using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Trainee.StudentAttendance
{
    public class StudentAttendanceDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetStudentAttendance(int standardId, int divisionId,DateTime attendanceDate)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetStudentAttendance";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@standardId", standardId);
                cmd.Parameters.AddWithValue("@divisionId", divisionId);
                cmd.Parameters.AddWithValue("@attendanceDate", attendanceDate);
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
        public int AddStudentAttendance(List<AddNewStudentAttendance> parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                SqlTransaction tran = null;
                //using (IDbTransaction tran = con1.BeginTransaction())
                //{
                try
                {
                    tran = con1.BeginTransaction("Transaction1");
                    strsqlquery = "AddStudentAttendance";
                    int sequenceNumber = 1;
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@standardId", item.StandardId);
                        cmd.Parameters.AddWithValue("@divisionId", item.DivisionId);
                        cmd.Parameters.AddWithValue("@attendanceDate", item.AttendanceDate);
                        cmd.Parameters.AddWithValue("@applicationUserId", item.ApplicationUserId);
                        var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                        cmd.Parameters.AddWithValue("@studentName", item.StudentName);
                        cmd.Parameters.AddWithValue("@attendance", item.Attandence);
                        cmd.Parameters.AddWithValue("@createdBy", int.Parse(createdBy));

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
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int UpdateStudentAttendance(List<AddNewStudentAttendance> parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                SqlTransaction tran = null;
                //using (IDbTransaction tran = con1.BeginTransaction())
                //{
                try
                {
                    tran = con1.BeginTransaction("Transaction1");
                    strsqlquery = "UpdateStudentAttendance";
                    
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", item.Id);
                        cmd.Parameters.AddWithValue("@standardId", item.StandardId);
                        cmd.Parameters.AddWithValue("@divisionId", item.DivisionId);
                        cmd.Parameters.AddWithValue("@attendanceDate", item.AttendanceDate);
                        cmd.Parameters.AddWithValue("@applicationUserId", item.ApplicationUserId);
                        var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                        cmd.Parameters.AddWithValue("@studentName", item.StudentName);
                        cmd.Parameters.AddWithValue("@attendance", item.Attandence);
                        cmd.Parameters.AddWithValue("@updatedBy", int.Parse(createdBy));

                        result = cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            noofSuccess += 1;
                        }
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
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetAllStudentAttendanceByMonth(int standardId, int divisionId, int monthid, int year)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetAllStudentAttendanceByMonth";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentId", standardId);
                cmd.Parameters.AddWithValue("@divisionId", divisionId);
                cmd.Parameters.AddWithValue("@month", monthid);
                cmd.Parameters.AddWithValue("@Year", year);
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