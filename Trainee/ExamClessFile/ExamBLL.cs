using LMS.Trainee.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Trainee.ExamClessFile
{
    public class ExamBLL
    {
        public DataTable GetExamList(string typeValue)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.GetExamList(typeValue);
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
        public DataTable GetExamListByDepartmentId(int departmentId)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.GetExamListByDepartmentId(departmentId);
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
        public DataTable GetExamListByCourseId(int courseId)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.GetExamListByCourseId(courseId);
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
        public int AddNewExam(string examName, Boolean ispublished)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.AddNewExam(examName, ispublished);
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
        public int UpdateExamSetting(Boolean isNew,string examName,int departmentStandardId ,int courseSubjectId,int totalMarks,DateTime examStartDateTime,DateTime examEndDateTime, int examId,int numberOfQuestion, int durationInMinutes)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.UpdateExamSetting(isNew,examName, departmentStandardId, courseSubjectId,totalMarks,examStartDateTime,examEndDateTime,examId, numberOfQuestion, durationInMinutes);
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
        public int UpdateExam(int id, string examName, Boolean ispublished)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.UpdateExam(id, examName, ispublished);
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
        public int DeleteExam(int id)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.DeleteExam(id);
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
        public DataTable GetExamDetailByID(int examId)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.GetExamDetailByID(examId);
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
        public int PublishExam(List<ExamFieldList1> parameter)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.PublishExam(parameter);
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
        public DataTable GetExamCoveredTime(int departmentStandardId, int courseSubjectId,int examId, int numberOfQuestion)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.GetExamCoveredTime(departmentStandardId, courseSubjectId, examId, numberOfQuestion);
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
        public int AddNewExamCoveredTime(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts, int timeCoveredInMinutes, int timeCoveredInSeconds,DateTime examStartDateTime,DateTime examEndDateTime)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.AddNewExamCoveredTime(departmentStandardId, courseSubjectId, examId, numberOfAttempts, timeCoveredInMinutes, timeCoveredInSeconds, examStartDateTime, examEndDateTime);
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
        public int UpdateExamCoveredTime(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts, int timeCoveredInMinutes,int timeCoveredInSeconds)
        {

            ExamDAL objdal1 = new ExamDAL();
            try
            {
                return objdal1.UpdateExamCoveredTime(departmentStandardId, courseSubjectId, examId, numberOfAttempts, timeCoveredInMinutes, timeCoveredInSeconds);
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