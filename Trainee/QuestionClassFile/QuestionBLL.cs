using LMS.Learner.BasicClass;
using LMS.Trainee.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Trainee.QuestionClassFile
{
    public class QuestionBLL
    {
        public DataTable GetQuestionAnswerTypeList(string typeValue)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetQuestionAnswerTypeList(typeValue);
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
        public DataTable GetValidationAnswerTypeList(string typeValue)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetValidationAnswerTypeList(typeValue);
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
        public DataTable GetValidationTypeList(string typeValue,int validationAnswerTypeId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetValidationTypeList(typeValue, validationAnswerTypeId);
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
        public int AddNewQuestion(Question parameter)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNewQuestion(parameter);
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
        public DataTable GetQuestionList(int departmentStandardId,int courseSubjectId,int examId, Boolean isExamList)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetQuestionList(departmentStandardId, courseSubjectId, examId,isExamList);
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
        public DataTable GetNewQuestionList(int departmentStandardId, int courseSubjectId, int examId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetNewQuestionList(departmentStandardId, courseSubjectId, examId);
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
        public int DeletePreviousExamAnswerLog(int id)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.DeletePreviousExamAnswerLog(id);
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
        public int DeletePreviousExamAnswerLogList(List<int> parameter)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.DeletePreviousExamAnswerLogList(parameter);
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
        public DataTable GetAllotedExamAnswerLogList(int departmentStandardId, int courseSubjectId, int examId,int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetAllotedExamAnswerLogList(departmentStandardId, courseSubjectId, examId, numberOfAttempts);
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
        public int AddNewAllotedQuestionExamAnswerLog(List<Question> parameter, int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNewAllotedQuestionExamAnswerLog(parameter, numberOfAttempts);
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
        public int AddNewSingleAllotedQuestionExamAnswerLog(List<Question> parameter, int numberOfAttempts,int sequenceno)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNewSingleAllotedQuestionExamAnswerLog(parameter, numberOfAttempts, sequenceno);
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
        public DataTable GetQuestionaireById(int questionId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetQuestionaireById(questionId);
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
        public int AddNewExamAnswer(List<ExamAnswerLog> parameter,int numberOfExamAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNewExamAnswer(parameter, numberOfExamAttempts);
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
        public DataTable GetValidationByQuestionId(int questionId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetValidationByQuestionId(questionId);
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
        public int UpdateAllotedQuestionExamAnswerLog(string answer,int marks,int allotedAnswerLogId, int? numberOfAttempts = null)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.UpdateAllotedQuestionExamAnswerLog(answer, marks, allotedAnswerLogId, numberOfAttempts);
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
        public DataTable GetNumberOfExamAttemptsList(int departmentStandardId, int courseSubjectId, int examId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetNumberOfExamAttemptsList(departmentStandardId, courseSubjectId, examId);
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
        public DataTable GetNumberOfExamAttemptsListByApplicationUserId(int departmentStandardId, int courseSubjectId, int examId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetNumberOfExamAttemptsListByApplicationUserId(departmentStandardId, courseSubjectId, examId);
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
        public DataTable GetNumberOfExamAttemptsIsChecked(int departmentStandardId, int courseSubjectId, int examId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetNumberOfExamAttemptsIsChecked(departmentStandardId, courseSubjectId, examId);
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
        public int AddNumberOfExamAttemptsList(int departmentStandardId, int courseSubjectId, int examId,int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNumberOfExamAttemptsList(departmentStandardId, courseSubjectId, examId, numberOfAttempts);
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
        public int UpdateNumberOfExamAttemptsIsChecked(int departmentStandardId, int courseSubjectId, int examId,int applicationUserId, int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.UpdateNumberOfExamAttemptsIsChecked(departmentStandardId, courseSubjectId, examId, applicationUserId, numberOfAttempts);
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
        public int UpdateAllotedQuestionExamAnswerLogNumberOfAttempts(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.UpdateAllotedQuestionExamAnswerLogNumberOfAttempts(departmentStandardId, courseSubjectId, examId, numberOfAttempts);
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
        public DataTable GETLearnerAnswer(int departmentStandardId, int courseSubjectId, int examId, int applicationUserId, int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GETLearnerAnswer(departmentStandardId, courseSubjectId, examId, applicationUserId, numberOfAttempts);
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
        public DataTable GETLearnerExamAnswerLog(int departmentStandardId, int courseSubjectId, int examId, int applicationUserId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GETLearnerExamAnswerLog(departmentStandardId, courseSubjectId, examId, applicationUserId);
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
        public int DeleteLearnerExamAnswerLog(int departmentStandardId, int courseSubjectId, int examId, int applicationUserId, int numberOfAtteempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.DeleteLearnerExamAnswerLog(departmentStandardId, courseSubjectId, examId, applicationUserId, numberOfAtteempts);
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
        public DataTable GetStudentResult(int departmentStandardId, int courseSubjectId, int examId)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.GetStudentResult(departmentStandardId, courseSubjectId, examId);
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
        public int UpdateLearnerMarks(List<ExamAnswer> parameter)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.UpdateLearnerMarks(parameter);
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
        public int AddNewStudentResult(int departmentStandardId, int courseSubjectId, int examId, int numberOfAttempts)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.AddNewStudentResult(departmentStandardId, courseSubjectId, examId, numberOfAttempts);
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
        public int UpdateStudentResultTotalMarks(int departmentStandardId, int courseSubjectId, int examId,int userId, int numberOfAttempts,int totalObtainedMarks)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.UpdateStudentResultTotalMarks(departmentStandardId, courseSubjectId, examId, userId, numberOfAttempts, totalObtainedMarks);
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
        public int DeleteQuestionAndValidationTable(int id)
        {

            QuestionDAL objdal1 = new QuestionDAL();
            try
            {
                return objdal1.DeleteQuestionAndValidationTable(id);
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