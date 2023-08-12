using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.EventClassFile
{
    public class EventBLL
    {
        public DataTable GetSessionEventByDepartmentId(int departmentStandardId)
        {

            EventDAL objdal1 = new EventDAL();
            try
            {
                return objdal1.GetSessionEventByDepartmentId(departmentStandardId);
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
        public int AddSessionEvent(string eventId, int departmentStandardId)
        {

            EventDAL objdal1 = new EventDAL();
            try
            {
                return objdal1.AddSessionEvent(eventId, departmentStandardId);
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
        public int DeleteSessionEvent(string eventId)
        {

            EventDAL objdal1 = new EventDAL();
            try
            {
                return objdal1.DeleteSessionEvent(eventId);
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
        public List<string> GetEventDetailUnderByTraineeId()
        {

            EventDAL objdal1 = new EventDAL();
            try
            {
                return objdal1.GetEventDetailUnderByTraineeId();
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
        public DataTable GetEventSessionChartDetail()
        {

            EventDAL objdal1 = new EventDAL();
            try
            {
                return objdal1.GetEventSessionChartDetail();
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