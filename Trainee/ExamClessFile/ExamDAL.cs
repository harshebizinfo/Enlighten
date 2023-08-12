using LMS.Common.ClassFile;
using LMS.Trainee.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Trainee.ExamClessFile
{
    public class ExamDAL
    {
        SqlCommand cmd = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetExamList(string typeValue)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetExamList";
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
        public DataTable GetExamListByDepartmentId(int departmentId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetExamList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "ByDepartmentId");
                cmd.Parameters.AddWithValue("@departmentId", departmentId);
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
        public DataTable GetExamListByCourseId(int courseId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetExamList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@type", "ByCourseId");
                cmd.Parameters.AddWithValue("@courseId", courseId);
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
        public int AddNewExam(string examName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewExam";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examName", examName);
                cmd.Parameters.AddWithValue("@isActive", ispublished);
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
        public int UpdateExamSetting(Boolean isNew, string examName,int departmentStandardId, int courseSubjectId, int totalMarks, DateTime examStartDateTime, DateTime examEndDateTime, int examId, int numberOfQuestion, int durationInMinutes)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddExamSetting";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@isNew", isNew);
                cmd.Parameters.AddWithValue("@isActive", true);
                cmd.Parameters.AddWithValue("@ExamName", examName);
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
                cmd.Parameters.AddWithValue("@totalMarks", totalMarks);
                cmd.Parameters.AddWithValue("@examStartDateTime", examStartDateTime);
                cmd.Parameters.AddWithValue("@examEndDateTime", examEndDateTime);
                cmd.Parameters.AddWithValue("@numberOfQuestion", numberOfQuestion);
                cmd.Parameters.AddWithValue("@examId", examId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(createdBy));
                cmd.Parameters.AddWithValue("@durationInMinutes", durationInMinutes);

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
        public int UpdateExam(int id, string examName, Boolean ispublished)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateExam";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examid", id);
                cmd.Parameters.AddWithValue("@examName", examName);
                cmd.Parameters.AddWithValue("@isActive", ispublished);
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
        public int DeleteExam(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteExam";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examid", id);
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
        public DataTable GetExamDetailByID(int examId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetExamDetailByID";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@examId", examId);
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
        public int PublishExam(List<ExamFieldList1> parameter)
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
                    strsqlquery = "PublishExam";
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
        public DataTable GetExamCoveredTime(int departmentStandardId, int courseSubjectId, int examId, int numberOfQuestion)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //var databaseName = "CID20211124"; //Session["ClientID"].ToString();
                strsqlquery = "GetExamCoveredTime";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
                cmd.Parameters.AddWithValue("@examId", examId);
                cmd.Parameters.AddWithValue("@numberOfAttempts", numberOfQuestion);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
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
        public int AddNewExamCoveredTime(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts, int timeCoveredInMinutes,int timeCoveredInSeconds, DateTime examStartDateTime, DateTime examEndDateTime)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewExamCoveredTime";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
                cmd.Parameters.AddWithValue("@timeCoveredInMinutes", timeCoveredInMinutes);
                cmd.Parameters.AddWithValue("@timeCoveredInSecond", timeCoveredInSeconds);
                cmd.Parameters.AddWithValue("@numberOfAttempts", numberOfAttempts);
                cmd.Parameters.AddWithValue("@examStartDateTime", examStartDateTime);
                cmd.Parameters.AddWithValue("@examEndDateTime", examEndDateTime);
                cmd.Parameters.AddWithValue("@examId", examId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(createdBy));
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(createdBy));

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
        public int UpdateExamCoveredTime(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts, int timeCoveredInMinutes,int timeCoveredInSeconds)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateExamCoveredTime";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
                cmd.Parameters.AddWithValue("@timeCoveredInMinutes", timeCoveredInMinutes);
                cmd.Parameters.AddWithValue("@timeCoveredInSecond", timeCoveredInSeconds);
                cmd.Parameters.AddWithValue("@numberOfAttempts", numberOfAttempts);
                cmd.Parameters.AddWithValue("@examId", examId);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(createdBy));
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(createdBy));

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