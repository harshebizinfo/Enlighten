using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.PaymentConfigurationClassFile
{
    public class PCBLL
    {
        public DataTable GetAllClientsPaymentConfiguration()
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.GetAllClientsPaymentConfiguration();
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
        public DataTable GetClientsPaymentConfigurationById(int id)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.GetClientsPaymentConfigurationById(id);
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
        public DataTable GetClientsPaymentConfigurationByClientId(string clientid)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.GetClientsPaymentConfigurationByClientId(clientid);
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
        public int AddNewClientsPaymentConfiguration(ClientPaymentConfiguration parameter)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.AddNewClientsPaymentConfiguration(parameter);
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
        public int UpdateClientsPaymentConfiguration(ClientPaymentConfiguration parameter)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.UpdateClientsPaymentConfiguration(parameter);
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
        public int DeleteClientsPaymentConfiguration(string clientId)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.DeleteClientsPaymentConfiguration(clientId);
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
        public int PublishClientsPaymentConfiguration(List<ClientPaymentConfiguration> parameter)
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.PublishClientsPaymentConfiguration(parameter);
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
        public DataTable GetFeeTransactionBySuperAdmin()
        {

            PCDAL objdal1 = new PCDAL();
            try
            {
                return objdal1.GetFeeTransactionBySuperAdmin();
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