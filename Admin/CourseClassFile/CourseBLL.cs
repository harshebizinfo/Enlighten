using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.CourseClassFile
{
    public class CourseBLL
    {
        public DataTable GetCourseSubjectList(string typeValue)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.GetCourseSubjectList(typeValue);
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
        public DataTable GetCourseSubjectListOfLearner()
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.GetCourseSubjectListOfLearner();
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
        public DataTable GetCourseSubjectUnderDepartmentStandardList(string typeValue)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.GetCourseSubjectUnderDepartmentStandardList(typeValue);
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
        public DataTable GetCourseUnderDepartment(int departmentStandardId)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.GetCourseUnderDepartment(departmentStandardId);
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
        public int AddNewCourseSubject(int subjectId,string subjectCourseName, int departmentStandardId, Boolean ispublished)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.AddNewCourseSubject(subjectId,subjectCourseName, departmentStandardId, ispublished);
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
        public int UpdateCourseSubject(int id, int subjectId, string subjectCourseName, int departmentStandardId, Boolean ispublished)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.UpdateCourseSubject(id, subjectId, subjectCourseName, departmentStandardId, ispublished);
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
        public int DeleteCourseSubject(int id)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.DeleteCourseSubject(id);
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
        public int PublishCourseSubject(List<CourseSubjectList> parameter)
        {

            CourseDAL objdal1 = new CourseDAL();
            try
            {
                return objdal1.PublishCourseSubject(parameter);
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