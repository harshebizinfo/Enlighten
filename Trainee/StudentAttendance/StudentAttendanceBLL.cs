using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Trainee.StudentAttendance
{
    public class StudentAttendanceBLL
    {
        public DataTable GetStudentAttendance(int standardId, int divisionId, DateTime attendanceDate)
        {

            StudentAttendanceDAL objdal1 = new StudentAttendanceDAL();
            try
            {
                return objdal1.GetStudentAttendance(standardId, divisionId, attendanceDate);
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
        public int AddStudentAttendance(List<AddNewStudentAttendance> parameter)
        {

            StudentAttendanceDAL objdal1 = new StudentAttendanceDAL();
            try
            {
                return objdal1.AddStudentAttendance(parameter);
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
        public int UpdateStudentAttendance(List<AddNewStudentAttendance> parameter)
        {

            StudentAttendanceDAL objdal1 = new StudentAttendanceDAL();
            try
            {
                return objdal1.UpdateStudentAttendance(parameter);
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
        public DataTable GetAllStudentAttendanceByMonth(int standardId, int divisionId, int monthid, int year)
        {

            StudentAttendanceDAL objdal1 = new StudentAttendanceDAL();
            try
            {
                return objdal1.GetAllStudentAttendanceByMonth(standardId, divisionId, monthid, year);
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