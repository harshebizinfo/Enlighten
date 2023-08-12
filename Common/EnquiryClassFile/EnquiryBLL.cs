using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Common.EnquiryClassFile
{
    public class EnquiryBLL
    {
        public DataTable GetRequestEnquiry()
        {

            EnquiryDAL objdal1 = new EnquiryDAL();
            try
            {
                return objdal1.GetRequestEnquiry();
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
        public int DeleteRequestEnquiry(int id)
        {

            EnquiryDAL objdal1 = new EnquiryDAL();
            try
            {
                return objdal1.DeleteRequestEnquiry(id);
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
        public int RequestEnquiry(string fullName,string instituteName,string emailId,string contactNumber,string instituteAddress)
        {

            EnquiryDAL objdal1 = new EnquiryDAL();
            try
            {
                return objdal1.RequestEnquiry(fullName, instituteName, emailId, contactNumber, instituteAddress);
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