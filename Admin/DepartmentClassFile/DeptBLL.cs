using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.DepartmentClassFile
{
    public class DeptBLL
    {
        public DataTable GetDepartmentStandardList(string typeValue)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetDepartmentStandardList(typeValue);
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
        public DataTable GetDepartmentStandardUnderTraineeList(string typeValue)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetDepartmentStandardUnderTraineeList(typeValue);
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
        public int AddNewDepartmentStandard(string departmentName,Boolean ispublished)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.AddNewDepartmentStandard(departmentName, ispublished);
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
        public int UpdateDepartmentStandard(int id,string departmentName, Boolean ispublished)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.UpdateDepartmentStandard(id,departmentName, ispublished);
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
        public int DeleteDepartmentStandard(int id)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.DeleteDepartmentStandard(id);
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
        public int PublishDepartment(List<DepartmentStandardList> parameter)
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.PublishDepartment(parameter);
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
        public DataTable GetListOfDepartmentByUserId()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetListOfDepartmentByUserId();
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
        public DataTable GetTehseelMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetTehseelMasterList();
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
        public DataTable GetCityMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetCityMasterList();
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
        public DataTable GetMediumMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetMediumMasterList();
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
        public DataTable GetStreamMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetStreamMasterList();
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
        public DataTable GetEducationMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetEducationMasterList();
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
        public DataTable GetOccupationMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetOccupationMasterList();
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
        public DataTable GetDocumentMasterList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetDocumentMasterList();
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
        public DataTable GetStudentInformationList()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetStudentInformationList();
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
        public DataTable GetStudentInformationListByApplicationUserId()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetStudentInformationListByApplicationUserId();
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
        public DataTable GetStudentInformationDetailsByApplicationUserId()
        {

            DeptDAL objdal1 = new DeptDAL();
            try
            {
                return objdal1.GetStudentInformationDetailsByApplicationUserId();
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