using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.DivisionClassFile
{
    public class DivisionBLL
    {
        public DataTable GetDivisionList(string typeValue)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.GetDivisionList(typeValue);
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
        public int AddNewDivision(string section, Boolean ispublished)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.AddNewDivision(section, ispublished);
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
        public int UpdateDivision(int id, string section, Boolean ispublished)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.UpdateDivision(id, section, ispublished);
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
        public int DeleteDivision(int id)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.DeleteDivision(id);
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
        public int PublishDivision(List<DivisionList> parameter)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.PublishDivision(parameter);
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
        public DataTable GetClassDivisionAllotment()
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.GetClassDivisionAllotment();
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
        public int AssignClassDivisionAllotment(int departmentStandardId, int divisionId)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.AssignClassDivisionAllotment(departmentStandardId, divisionId);
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
        public int DeleteClassDivisionAllotment(int id)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.DeleteClassDivisionAllotment(id);
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
        public DataTable GetDivisionUnderDepartmentId(int departmentStandardId)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.GetDivisionUnderDepartmentId(departmentStandardId);
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
        public DataTable GetStudentDetailUnderDepartmentAndDivision(int standardId,int divisionId)
        {

            DivisionDAL objdal1 = new DivisionDAL();
            try
            {
                return objdal1.GetStudentDetailUnderDepartmentAndDivision(standardId, divisionId);
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