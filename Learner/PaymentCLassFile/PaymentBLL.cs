using LMS.Learner.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Learner.PaymentCLassFile
{
    public class PaymentBLL
    {
        public int AddNewTempPaymentDetail(TempPaymentDetailField parameter)
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.AddNewTempPaymentDetail(parameter);
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
        public DataTable GetPaymentDetail(int departmentStandardId, int courseSubjectId, int examId)
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.GetPaymentDetail(departmentStandardId, courseSubjectId, examId);
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
        public DataTable GetTempPaymentDetailById(int id)
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.GetTempPaymentDetailById(id);
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
        public DataTable GetPaymentData(int standardId, int academicYear, string admissionNumber)
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.GetPaymentData(standardId,academicYear,admissionNumber);
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
        public DataTable CheckPreviousBalanceExists()
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.CheckPreviousBalanceExists();
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
        public DataTable GetAllTempPaymentDetail()
        {

            PaymentDAL objdal1 = new PaymentDAL();
            try
            {
                return objdal1.GetAllTempPaymentDetail();
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
        public int updatePaymentTempverifiedstatus(string referenceNumber)
        {
            PaymentDAL dal = new PaymentDAL();
            try
            {
                return dal.updatePaymentTempverifiedstatus(referenceNumber);
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                dal = null;
            }
        }
        public int get_if_paymentreferenceid_exist(string referenceNumber)
        {
            PaymentDAL dal = new PaymentDAL();
            try
            {
                return dal.get_if_paymentreferenceid_exist(referenceNumber);
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                dal = null;
            }
        }

    }
}