using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.SuperAdmin.ClientClassFile
{
    public class ClientBLL
    {
        public DataTable GetAllClient()
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.GetAllClient();
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
        public DataTable GetPaymentMethod()
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.GetPaymentMethod();
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
        public DataTable GetClientByClientId(string clientId)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.GetClientByClientId(clientId);
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
        public int AddNewClient(AddNewClientDetail parameter)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.AddNewClient(parameter);
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
        public int EditNewClient(AddNewClientDetail parameter)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.EditNewClient(parameter);
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
        public int EditClientSubscription(string clientId)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.EditClientSubscription(clientId);
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
        public int CreateTableInDatabase(string script,string databaseName)
        {
            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.CreateTableInDatabase(script, databaseName);
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                objdal1 = null;
            }

        }
        public int ActivateDatabaseAndClient(string clientId)
        {
            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.ActivateDatabaseAndClient(clientId);
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                objdal1 = null;
            }

        }
        public int CreateAdminOfClient(string clientId)
        {
            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.CreateAdminOfClient(clientId);
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                objdal1 = null;
            }

        }
        public int DeleteClient(string clientId)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.DeleteClient(clientId);
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
        public int PublishClient(List<AddNewClientDetail> parameter)
        {

            ClientDAL objdal1 = new ClientDAL();
            try
            {
                return objdal1.PublishClient(parameter);
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