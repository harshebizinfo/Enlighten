using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Learner.ComplaintClassFile
{
    public class ComplaintBLL
    {
        public DataTable GetComplaintList()
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.GetComplaintList();
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
        public DataTable GetComplaintListById(int id)
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.GetComplaintListById(id);
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
        public int AddNewComplaint(ComplaintListModel complaintList)
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.AddNewComplaint(complaintList);
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
        public int UpdateComplaint(ComplaintListModel complaintList)
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.UpdateComplaint(complaintList);
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
        public int DeleteComplaint(int id)
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.DeleteComplaint(id);
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
        public DataTable GetComplaintListByAdmissionNumber(string admissionNo)
        {

            ComplaintDAL objdal1 = new ComplaintDAL();
            try
            {
                return objdal1.GetComplaintListByAdmissionNumber(admissionNo);
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