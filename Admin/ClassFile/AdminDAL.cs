using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace LMS.Admin.ClassFile
{
    public class AdminDAL
    {
        SqlCommand cmd = null;
        SqlCommand cmd1 = null;
        SqlDataAdapter da = null;
        DataTable dt;
        string strsqlquery = string.Empty;
        ClientConnection objdal01 = new ClientConnection();
        string connection1 = string.Empty;
        public DataTable GetLogedInUserRole(string clientId, int applicationUserId)
        {
            try
            {

                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetLogedInUserRole";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@clientId", clientId);
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
        public DataTable GetGroupNameList(string email)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);

                strsqlquery = "GetUserRoleList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", email);
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
        public int AddNewLearner(ApplicationUser parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewLearner";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", parameter.FirstName);
                cmd.Parameters.AddWithValue("@lastName", parameter.LastName);
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@emailId", parameter.EmailId);
                cmd.Parameters.AddWithValue("@userName", parameter.UserName);
                cmd.Parameters.AddWithValue("@fatherName", parameter.FatherName);
                cmd.Parameters.AddWithValue("@fatherContactNumber", parameter.FatherContactNumber);
                cmd.Parameters.AddWithValue("@presentAddess", parameter.PresentAddess);
                cmd.Parameters.AddWithValue("@presentCity", parameter.PresentCity);
                cmd.Parameters.AddWithValue("@presentState", parameter.PresentState);
                cmd.Parameters.AddWithValue("@permanentAddress", parameter.PermanentAddress);
                cmd.Parameters.AddWithValue("@permanentCity", parameter.PermanentCity);
                cmd.Parameters.AddWithValue("@permanentState", parameter.PermanentState);
                cmd.Parameters.AddWithValue("@gender", parameter.Gender);
                cmd.Parameters.AddWithValue("@adhaarCardNumber", parameter.AdhaarCardNumber);
                cmd.Parameters.AddWithValue("@pANCardNumber", parameter.PANCardNumber);
                cmd.Parameters.AddWithValue("@passwordHashKey", parameter.PasswordHashKey);
                cmd.Parameters.AddWithValue("@passwordSaltKey", parameter.PasswordSaltKey);
                cmd.Parameters.AddWithValue("@numberOfAttempts", parameter.NumberOfAttempts);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
                cmd.Parameters.AddWithValue("@clientId", clientId);//parameter.ClientId
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(applicationUserId));
                cmd.Parameters.AddWithValue("@lASTID", 0);

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
        public int AddNewTrainee(ApplicationUser parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewTrainee";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", parameter.FirstName);
                cmd.Parameters.AddWithValue("@lastName", parameter.LastName);
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@emailId", parameter.EmailId);
                cmd.Parameters.AddWithValue("@userName", parameter.UserName);
                cmd.Parameters.AddWithValue("@fatherName", parameter.FatherName);
                cmd.Parameters.AddWithValue("@fatherContactNumber", parameter.FatherContactNumber);
                cmd.Parameters.AddWithValue("@presentAddess", parameter.PresentAddess);
                cmd.Parameters.AddWithValue("@presentCity", parameter.PresentCity);
                cmd.Parameters.AddWithValue("@presentState", parameter.PresentState);
                cmd.Parameters.AddWithValue("@permanentAddress", parameter.PermanentAddress);
                cmd.Parameters.AddWithValue("@permanentCity", parameter.PermanentCity);
                cmd.Parameters.AddWithValue("@permanentState", parameter.PermanentState);
                cmd.Parameters.AddWithValue("@gender", parameter.Gender);
                cmd.Parameters.AddWithValue("@adhaarCardNumber", parameter.AdhaarCardNumber);
                cmd.Parameters.AddWithValue("@pANCardNumber", parameter.PANCardNumber);
                cmd.Parameters.AddWithValue("@passwordHashKey", parameter.PasswordHashKey);
                cmd.Parameters.AddWithValue("@passwordSaltKey", parameter.PasswordSaltKey);
                cmd.Parameters.AddWithValue("@numberOfAttempts", parameter.NumberOfAttempts);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
                cmd.Parameters.AddWithValue("@clientId", clientId);//parameter.ClientId
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(applicationUserId));
                cmd.Parameters.AddWithValue("@lASTID", 0);

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
        public int AddBankDetails(string bankName, string accountnumber, string ifscCode, int applicationUserId, string accountHolderName, string nickName)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddBankDetails";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@bankname", bankName);
                cmd.Parameters.AddWithValue("@accountNumber", accountnumber);
                cmd.Parameters.AddWithValue("@ifscCode", ifscCode);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                cmd.Parameters.AddWithValue("@accountHolderName", accountHolderName);
                cmd.Parameters.AddWithValue("@nickName", nickName);
                var createdById = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@createdBy", int.Parse(createdById));

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
        public DataTable GetDDLLearner()
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetDDLLearner";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetApplicationUserById(int applicationUserId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetApplicationUserById";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
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
        public int AddMappingApplicationUserIdAndDepartmentStandard(AddStudentInDepartment parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddMappingApplicationUserIdAndDepartmentStandard";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicationUserId", parameter.ApplicationUserId);
                cmd.Parameters.AddWithValue("@departmentStandardId", parameter.DepartmentStandardId);
                cmd.Parameters.AddWithValue("@divisionId", parameter.DivisionId);
                cmd.Parameters.AddWithValue("@categoryId", parameter.CategoryId);
                cmd.Parameters.AddWithValue("@areaId", parameter.AreaId);
                cmd.Parameters.AddWithValue("@hasConveyance", parameter.HasConveyance);
                cmd.Parameters.AddWithValue("@modeId", parameter.ModeId);
                cmd.Parameters.AddWithValue("@pickupVehicleNumber", parameter.PickUpVehicleNumber);
                cmd.Parameters.AddWithValue("@dropVehicleNumber", parameter.DropVehicleNumber);
                cmd.Parameters.AddWithValue("@pickUpVehicleNumberId", parameter.PickUpVehicleId);
                cmd.Parameters.AddWithValue("@dropVehicleNumberId", parameter.DropVehicleId);
                cmd.Parameters.AddWithValue("@isPublished", parameter.IsActive);
                cmd.Parameters.AddWithValue("@isOneTrip", parameter.IsOneWayTrip);
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
        public int EditMappingApplicationUserIdAndDepartmentStandard(AddStudentInDepartment parameter)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "EditMappingApplicationUserIdAndDepartmentStandard";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", parameter.Id);
                cmd.Parameters.AddWithValue("@applicationUserId", parameter.ApplicationUserId);
                cmd.Parameters.AddWithValue("@departmentStandardId", parameter.DepartmentStandardId);
                cmd.Parameters.AddWithValue("@divisionId", parameter.DivisionId);
                cmd.Parameters.AddWithValue("@categoryId", parameter.CategoryId);
                cmd.Parameters.AddWithValue("@areaId", parameter.AreaId);
                cmd.Parameters.AddWithValue("@hasConveyance", parameter.HasConveyance);
                cmd.Parameters.AddWithValue("@modeId", parameter.ModeId);
                cmd.Parameters.AddWithValue("@pickupVehicleNumber", parameter.PickUpVehicleNumber);
                cmd.Parameters.AddWithValue("@dropVehicleNumber", parameter.DropVehicleNumber);
                cmd.Parameters.AddWithValue("@pickUpVehicleNumberId", parameter.PickUpVehicleId);
                cmd.Parameters.AddWithValue("@dropVehicleNumberId", parameter.DropVehicleId);
                cmd.Parameters.AddWithValue("@isPublished", parameter.IsActive);
                cmd.Parameters.AddWithValue("@isOneTrip", parameter.IsOneWayTrip);
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
        public int DeleteMappingApplicationUserIdAndDepartmentStandard(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteMappingApplicationUserIdAndDepartmentStandard";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
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
        public int PublishMappingApplicationUserIdAndDepartmentStandard(List<AddStudentInDepartment> parameter)
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
                    strsqlquery = "PublishMappingApplicationUserIdAndDepartmentStandard";
                    int sequenceNumber = 1;
                    var result = 0;
                    var noofSuccess = 0;
                    foreach (var item in parameter)
                    {
                        cmd = new SqlCommand(strsqlquery, con1, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", item.Id);
                        cmd.Parameters.AddWithValue("@isPublished", item.IsActive);
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
        public DataTable GETMappingApplicationUserIdAndDepartmentStandardByID(int id)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GETMappingApplicationUserIdAndDepartmentStandardByID";
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
        public DataTable GetStudentUnderDepartmentList(int standardId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetStudentUnderDepartmentList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@standardId", standardId);
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
        public DataTable GetAllDepartmentUnderStudentList(int studentId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllDepartmentUnderStudentList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@studentId", studentId);
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
        public int AddNewGroup(string groupName)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddNewGroup";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@groupName", groupName);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
                cmd.Parameters.AddWithValue("@clientId", clientId);
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
        public int UpdateGroupName(int tenantGroupId, string groupName)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateGroupName";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenantGroupId", tenantGroupId);
                cmd.Parameters.AddWithValue("@groupName", groupName);
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
        public int DeleteGroupName(int tenantGroupId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteGroupName";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenantGroupId", tenantGroupId);
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
        public DataTable GetApplicationUserList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                // SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetApplicationUserList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetTraineeApplicationUserList()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                // SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetTraineeApplicationUserList";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetDashBoardDeatilForAdmin()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                // SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetDashBoardDeatilForAdmin";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetDDLTrainee()
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetDDLTrainee";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetBankDetailsByApplicationUserId()
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetBankDetailsByApplicationUserId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(clientId));
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
        public DataTable GetDDLTenantRole()
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetDDLTenantRole";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetGroupNameByClientId()
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetGroupNameByClientId";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public int AssignTenantGroupDepartmentAndCourseToTrainee(int departmentStandardId, int courseSubjectId, int applicationUserId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AssignTenantGroupDepartmentAndCourseToTrainee";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@departmentStandardId", departmentStandardId);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                cmd.Parameters.AddWithValue("@courseSubjectId", courseSubjectId);
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
        public DataTable GetLearnerDetailUnderTrainee(int departmentId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetLearnerDetailUnderTrainee";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var applicationUserid = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@applicationUserId", int.Parse(applicationUserid));
                cmd.Parameters.AddWithValue("@type", "AllDepartment");
                cmd.Parameters.AddWithValue("@departmentId", departmentId);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetLearnerDetailUnderTraineebyDepartmentId(int departmentStandardId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetLearnerDetailUnderTrainee";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var applicationUserid = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@type", "DepartmentById");
                cmd.Parameters.AddWithValue("@departmentId", departmentStandardId);
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public int UploadFileOnDocumentFileRequired(int applicationUserId, string filePath, int fileTypeId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UploadFileOnDocumentFileRequired";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fileTypeId", fileTypeId);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                cmd.Parameters.AddWithValue("@DifferentFilePath", filePath);

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
        public DataTable GetDocumentsFileRequired(int applicationUserId, int fileTypeId)
        {
            try
            {
                connection1 = objdal01.Conncetion();
                SqlConnection con1 = new SqlConnection(connection1);
                //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetDocumentsFileRequired";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
                cmd.Parameters.AddWithValue("@fileTypeId", fileTypeId);
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
        public int DeleteApplicationUser(int applicationUserId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteApplicationUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
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
        public int UpdatedApplicationUserById(ApplicationUser parameter)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdatedApplicationUserById";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", parameter.FirstName);
                cmd.Parameters.AddWithValue("@lastName", parameter.LastName);
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@email", parameter.EmailId);
                cmd.Parameters.AddWithValue("@fatherName", parameter.FatherName);
                cmd.Parameters.AddWithValue("@fatherContactNumber", parameter.FatherContactNumber);
                cmd.Parameters.AddWithValue("@presentAddress", parameter.PresentAddess);
                cmd.Parameters.AddWithValue("@presentCity", parameter.PresentCity);
                cmd.Parameters.AddWithValue("@presentState", parameter.PresentState);
                cmd.Parameters.AddWithValue("@permanentAddress", parameter.PermanentAddress);
                cmd.Parameters.AddWithValue("@permanentCity", parameter.PermanentCity);
                cmd.Parameters.AddWithValue("@permanentState", parameter.PermanentState);
                cmd.Parameters.AddWithValue("@applicationUserId", parameter.ApplicationUserId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(applicationUserId));

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
        public int UpdatedStudentDetailApplicationUserById(StudentDetailModel parameter)
        {

            connection1 = objdal01.Conncetion();
            SqlConnection con1 = new SqlConnection(connection1);
            //SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

            strsqlquery = "UpdatedApplicationUserById";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd1 = new SqlCommand("UpdateStudentDetailByAddmissionNo", con1);

                SqlTransaction trans = con1.BeginTransaction();
                cmd.Transaction = trans;
                cmd1.Transaction = trans;
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", parameter.FirstName);
                cmd.Parameters.AddWithValue("@lastName", parameter.LastName);
                cmd.Parameters.AddWithValue("@contactNumber", parameter.ContactNumber);
                cmd.Parameters.AddWithValue("@email", parameter.EmailId);
                cmd.Parameters.AddWithValue("@fatherName", parameter.FatherName);
                cmd.Parameters.AddWithValue("@fatherContactNumber", parameter.FatherContactNumber);
                cmd.Parameters.AddWithValue("@presentAddress", parameter.PresentAddess);
                cmd.Parameters.AddWithValue("@presentCity", parameter.PresentCity);
                cmd.Parameters.AddWithValue("@presentState", parameter.PresentState);
                cmd.Parameters.AddWithValue("@permanentAddress", parameter.PermanentAddress);
                cmd.Parameters.AddWithValue("@permanentCity", parameter.PermanentCity);
                cmd.Parameters.AddWithValue("@permanentState", parameter.PermanentState);
                cmd.Parameters.AddWithValue("@applicationUserId", parameter.ApplicationUserId);
                var applicationUserId = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                cmd.Parameters.AddWithValue("@updatedBy", int.Parse(applicationUserId));

                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.AddWithValue("@Language ", parameter.Language );
                cmd1.Parameters.AddWithValue("@Nationality ", parameter.Nationality );
                cmd1.Parameters.AddWithValue("@TehseelId", parameter.TehseelId);
                cmd1.Parameters.AddWithValue("@CityId", parameter.CityId);
                cmd1.Parameters.AddWithValue("@PrevSchoolName", parameter.PrevSchoolName);
                cmd1.Parameters.AddWithValue("@PrevStreamId", parameter.PrevStreamId);
                cmd1.Parameters.AddWithValue("@PrevClassId", parameter.PrevClassId);
                cmd1.Parameters.AddWithValue("@PrevMediumId", parameter.PrevMediumId);
                cmd1.Parameters.AddWithValue("@PrevMarks", parameter.PrevMarks);
                cmd1.Parameters.AddWithValue("@PrevTotalMarks", parameter.PrevTotalMarks);
                cmd1.Parameters.AddWithValue("@PrevAddress", parameter.PrevAddress);
                cmd1.Parameters.AddWithValue("@FatherPhone", parameter.FatherPhone);
                cmd1.Parameters.AddWithValue("@FatherEducationId", parameter.FatherEducationId);
                cmd1.Parameters.AddWithValue("@FatherOccupationId", parameter.FatherOccupationId);
                cmd1.Parameters.AddWithValue("@FatherAddress", parameter.FatherAddress);
                cmd1.Parameters.AddWithValue("@MotherName", parameter.MotherName);
                cmd1.Parameters.AddWithValue("@MotherPhone", parameter.MotherPhone);
                cmd1.Parameters.AddWithValue("@MotherEducationId", parameter.MotherEducationId);
                cmd1.Parameters.AddWithValue("@MotherOccupationId", parameter.MotherOccupationId);
                cmd1.Parameters.AddWithValue("@MotherAddress", parameter.MotherAddress);
                cmd1.Parameters.AddWithValue("@GuardianName", parameter.GuardianName);
                cmd1.Parameters.AddWithValue("@GuardianPhone", parameter.GuardianPhone);
                cmd1.Parameters.AddWithValue("@GuardianRelationShip", parameter.GuardianRelationShip);
                cmd1.Parameters.AddWithValue("@GuardianAddress", parameter.GuardianAddress);
                cmd1.Parameters.AddWithValue("@DocumentsId", parameter.DocumentsId);
                cmd1.Parameters.AddWithValue("@IsPreviousSchoolIncluded", parameter.IsPreviousSchoolIncluded);
                cmd1.Parameters.AddWithValue("@IsSibilingsIncluded", parameter.IsSibilingsIncluded);
                cmd1.Parameters.AddWithValue("@AdmissionNumber", parameter.AdmissionNumber);

                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery();
                // cmd.Dispose();
               
                trans.Commit();
                if (con1.State != ConnectionState.Closed)
                {
                    con1.Close();
                }
                return 1;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
        }
        public DataTable GetAllUserUnderClient()
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllUserUnderClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetAllGroupUnderClient()
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllGroupUnderClient";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                var clientId = Convert.ToString(System.Web.HttpContext.Current.Session["ClientID"]);
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
        public DataTable GetAllGroupAssignToUser(int applicationUser)
        {
            try
            {
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);

                strsqlquery = "GetAllGroupAssignToUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUser);
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
        public int DeleteGroupAssignToUser(int id)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "DeleteGroupAssignToUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                var createdBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
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
        public int AddGroupAssignTenantGroupToUser(int tenantGroupId, int applicationUserId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "AddGroupAssignTenantGroupToUser";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenantGroupId", tenantGroupId);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
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
        public int UpdateGroupAssignTenantSetPrimary(int tenantGroupId, int applicationUserId)
        {
            try
            {
                //connection1 = objdal01.Conncetion();
                //SqlConnection con1 = new SqlConnection(connection1);
                SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection1"].ConnectionString);  //Different Connection string for admin Database

                strsqlquery = "UpdateGroupAssignTenantSetPrimary";
                if (con1.State != ConnectionState.Open)
                {
                    con1.Open();
                }
                cmd = new SqlCommand(strsqlquery, con1);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenantGroupId", tenantGroupId);
                cmd.Parameters.AddWithValue("@applicationUserId", applicationUserId);
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
    }
}