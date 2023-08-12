using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.ServiceClassFile
{
    public class ServiceBLL
    {
        public DataTable GetServiceAccountDetailList()
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.GetServiceAccountDetailList();
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
        public DataTable GetServiceAccountDetailById(string clientId)
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.GetServiceAccountDetailById(clientId);
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
        public int AddServiceAccountDetail(AddServiceAccountDetail parameter)
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.AddServiceAccountDetail(parameter);
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
        public int DeleteServiceAccountDetail(int id)
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.DeleteServiceAccountDetail(id);
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
        public int PublishServiceAccountDetail(List<AddServiceAccountDetail> parameter)
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.PublishServiceAccountDetail(parameter);
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
        public DataTable GetMigratedStudent()
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.GetMigratedStudent();
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
        public int AddMigratingStudent(string clientId,string scholarId,int applicationUserId)
        {

            ServiceDAL objdal1 = new ServiceDAL();
            try
            {
                return objdal1.AddMigratingStudent(clientId,scholarId,applicationUserId);
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