using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.TraineeAttendance
{
    public class TraineeAttendanceBLL
    {
        public DataTable GetTraineeAttendance(DateTime attendanceDate)
        {

            TraineeAttendanceDAL objdal1 = new TraineeAttendanceDAL();
            try
            {
                return objdal1.GetTraineeAttendance( attendanceDate);
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
        public int AddTraineeAttendance(List<AddNewTraineeAttendance> parameter)
        {

            TraineeAttendanceDAL objdal1 = new TraineeAttendanceDAL();
            try
            {
                return objdal1.AddTraineeAttendance(parameter);
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
        public int UpdateTraineeAttendance(List<AddNewTraineeAttendance> parameter)
        {

            TraineeAttendanceDAL objdal1 = new TraineeAttendanceDAL();
            try
            {
                return objdal1.UpdateTraineeAttendance(parameter);
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
        public DataTable GetAllTraineeAttendanceByMonth(int month,int year)
        {

            TraineeAttendanceDAL objdal1 = new TraineeAttendanceDAL();
            try
            {
                return objdal1.GetAllTraineeAttendanceByMonth(month,year);
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