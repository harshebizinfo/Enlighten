using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.ClassFile
{
    public class AdminBLL
    {
        public DataTable GetLogedInUserRole(string clientId, int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetLogedInUserRole(clientId, applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetGroupNameList(string email)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetGroupNameList(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddNewLearner(ApplicationUser parameter)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddNewLearner(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddNewTrainee(ApplicationUser parameter)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddNewTrainee(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddBankDetails(string bankName, string accountnumber, string ifscCode, int applicationUserId, string accountHolderName, string nickName)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddBankDetails(bankName, accountnumber, ifscCode, applicationUserId, accountHolderName, nickName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetDDLLearner()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetDDLLearner();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetApplicationUserById(int applicationUserById)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetApplicationUserById(applicationUserById);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddMappingApplicationUserIdAndDepartmentStandard(AddStudentInDepartment addStudentInDepartment)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddMappingApplicationUserIdAndDepartmentStandard(addStudentInDepartment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int EditMappingApplicationUserIdAndDepartmentStandard(AddStudentInDepartment editStudentInDepartment)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.EditMappingApplicationUserIdAndDepartmentStandard(editStudentInDepartment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int DeleteMappingApplicationUserIdAndDepartmentStandard(int id)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.DeleteMappingApplicationUserIdAndDepartmentStandard(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int PublishMappingApplicationUserIdAndDepartmentStandard(List<AddStudentInDepartment> parameter )
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.PublishMappingApplicationUserIdAndDepartmentStandard(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GETMappingApplicationUserIdAndDepartmentStandardByID(int id)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GETMappingApplicationUserIdAndDepartmentStandardByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetStudentUnderDepartmentList(int standardId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetStudentUnderDepartmentList(standardId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetAllDepartmentUnderStudentList(int studentId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetAllDepartmentUnderStudentList(studentId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddNewGroup(string groupName)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddNewGroup(groupName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int UpdateGroupName(int tenantGroupId, string groupName)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.UpdateGroupName(tenantGroupId, groupName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int DeleteGroupName(int tenantGroupId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.DeleteGroupName(tenantGroupId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetGroupNameByClientId()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetGroupNameByClientId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetApplicationUserList()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetApplicationUserList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetTraineeApplicationUserList()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetTraineeApplicationUserList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetDashBoardDeatilForAdmin()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetDashBoardDeatilForAdmin();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetDDLTrainee()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetDDLTrainee();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetBankDetailsByApplicationUserId()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetBankDetailsByApplicationUserId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetDDLTenantRole()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetDDLTenantRole();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AssignTenantGroupDepartmentAndCourseToTrainee(int departmentStandardId, int courseSubjectId, int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AssignTenantGroupDepartmentAndCourseToTrainee(departmentStandardId, courseSubjectId, applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetLearnerDetailUnderTrainee(int departmentID)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetLearnerDetailUnderTrainee(departmentID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetLearnerDetailUnderTraineebyDepartmentId(int departmentStandardId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetLearnerDetailUnderTraineebyDepartmentId(departmentStandardId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetDocumentsFileRequired(int applicationUserId, int fileTypeId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetDocumentsFileRequired(applicationUserId, fileTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int UploadFileOnDocumentFileRequired(int applicationUserId, string filePath, int fileTypeId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.UploadFileOnDocumentFileRequired(applicationUserId, filePath, fileTypeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int DeleteApplicationUser(int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.DeleteApplicationUser(applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int UpdatedApplicationUserById(ApplicationUser parameter)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.UpdatedApplicationUserById(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int UpdatedStudentDetailApplicationUserById(StudentDetailModel parameter)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.UpdatedStudentDetailApplicationUserById(parameter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetAllUserUnderClient()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetAllUserUnderClient();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetAllGroupUnderClient()
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetAllGroupUnderClient();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public DataTable GetAllGroupAssignToUser(int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.GetAllGroupAssignToUser(applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int DeleteGroupAssignToUser(int id)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.DeleteGroupAssignToUser(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int AddGroupAssignTenantGroupToUser(int tenantGroupId, int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.AddGroupAssignTenantGroupToUser(tenantGroupId, applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
        public int UpdateGroupAssignTenantSetPrimary(int tenantGroupId, int applicationUserId)
        {

            AdminDAL objdal1 = new AdminDAL();
            try
            {
                return objdal1.UpdateGroupAssignTenantSetPrimary(tenantGroupId, applicationUserId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objdal1 = null;
            }
        }
    }
}