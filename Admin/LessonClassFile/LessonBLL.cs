using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.LessonClassFile
{
    public class LessonBLL
    {
        public DataTable GetLessonList(string typeValue)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.GetLessonList(typeValue);
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
        public DataTable GetLessonListUnderDeptCourse(int deptId, int courseId)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.GetLessonListUnderDeptCourse(deptId,courseId);
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
        public DataTable GetLessonUnderTraineeList(string typeValue)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.GetLessonUnderTraineeList(typeValue);
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
        public int AddNewLesson(int departmentStandardId,int coursesubjectId,string lessonTitle,string lessonDescription, Boolean ispublished)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.AddNewLesson(departmentStandardId, coursesubjectId, lessonTitle, lessonDescription, ispublished);
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
        public int PublishLesson(List<LessonListDetailField> parameter)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.PublishLesson(parameter);
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
        public int DeleteLesson(int id)
        {

            LessonDAL objdal1 = new LessonDAL();
            try
            {
                return objdal1.DeleteLesson(id);
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