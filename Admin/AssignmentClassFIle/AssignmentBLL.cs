using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.AssignmentClassFIle
{
    public class AssignmentBLL
    {
        public int AddAssignment(AssignmentModel assignmentModel)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.AddAssignment(assignmentModel);
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
        public int DeleteAssignment(int id)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.DeleteAssignment(id);
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
        public DataTable AssignmentList(int departmentId,int courseId,int lessonId)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.AssignmentList(departmentId,courseId,lessonId);
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
        public DataTable GetAssignmentList(int id)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetAssignmentList(id);
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
        public DataTable AssignmentListUnderDepartment(int departmentId)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.AssignmentListUnderDepartment(departmentId);
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
        public DataTable GetLearnerDepartmentId()
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetLearnerDepartmentId();
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
        #region uploadFIle
        public int SubmitNewAssignmentByLearner(int assignmentId,string submitAssignmentFIlePath)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.SubmitNewAssignmentByLearner(assignmentId, submitAssignmentFIlePath);
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
        public DataTable GetSubmittedAssignmentByAssignmentId(int assignmentId)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetSubmittedAssignmentByAssignmentId(assignmentId);
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
        public DataTable GetSubmitAssignmentById(int id)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetSubmitAssignmentById(id);
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
        public DataTable GetUploadedAssignmentUnderTrainee(string type)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetUploadedAssignmentUnderTrainee(type);
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
        public DataTable GetSubmittedAssignmentOfUserByAssignmentId(int assignmentId)
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetSubmittedAssignmentOfUserByAssignmentId(assignmentId);
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
        public DataTable GetUploadedAssignmentUnderDepartmentUsingApplicationUserId()
        {

            AssignmentDAL objdal1 = new AssignmentDAL();
            try
            {
                return objdal1.GetUploadedAssignmentUnderDepartmentUsingApplicationUserId();
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
        #endregion
    }
}