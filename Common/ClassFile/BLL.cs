using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Common.ClassFile
{
    public class BLL
    {
        //Getting the Clientinfofrom Admin database
        public DataTable GetClientinfo(ClientDetail objbol)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.GetClientinfo(objbol);
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

        public bool VerifySaltKey(string saltKey)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.VerifyAESSaltKey(saltKey);
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
        public DataTable UserLogin(string email)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.UserLogin(email);
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
        public DataTable GetGroupName(string email)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.GetGroupName(email);
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
        public int SetNumberOfAttempts(string email,int numberofAttempts)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.SetNumberOfAttempts(email,numberofAttempts);
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
        public int RegisterUser(AddUser parameter)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.RegisterUser(parameter);
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
        public int SetUserPassword(string email,string encryptedSaltKey,string encryptedHashKey)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.SetUserPassword(email, encryptedSaltKey, encryptedHashKey);
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
        public int SetSaltKeyOfUser(string email, string encryptedSaltKey)
        {

            DAL objdal1 = new DAL();
            try
            {
                return objdal1.SetSaltKeyOfUser(email, encryptedSaltKey);
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