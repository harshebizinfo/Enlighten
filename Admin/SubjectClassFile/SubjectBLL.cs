using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.SubjectClassFile
{
    public class SubjectBLL
    {
        public DataTable GetSubjectMasterList(string typeValue)
        {

            SubjectDAL objdal1 = new SubjectDAL();
            try
            {
                return objdal1.GetSubjectMasterList(typeValue);
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
        public int AddSubjectMaster(string subjectName, Boolean ispublished)
        {

            SubjectDAL objdal1 = new SubjectDAL();
            try
            {
                return objdal1.AddSubjectMaster(subjectName, ispublished);
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
        public int UpdateSubjectMaster(int id, string subjectName, Boolean ispublished)
        {

            SubjectDAL objdal1 = new SubjectDAL();
            try
            {
                return objdal1.UpdateSubjectMaster(id, subjectName, ispublished);
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
        public int DeleteSubjectMaster(int id)
        {

            SubjectDAL objdal1 = new SubjectDAL();
            try
            {
                return objdal1.DeleteSubjectMaster(id);
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
        public int PublishSubjectMaster(List<SubjectMasterList> parameter)
        {

            SubjectDAL objdal1 = new SubjectDAL();
            try
            {
                return objdal1.PublishSubjectMaster(parameter);
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