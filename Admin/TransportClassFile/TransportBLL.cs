using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.TransportClassFile
{
    public class TransportBLL
    {
        #region TransportMode
        public DataTable GetVehicleModeList(string typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetVehicleModeList(typeValue);
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
        public int AddNewVehicleMode(string vehicleName, string vehicleType, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddNewVehicleMode(vehicleName, vehicleType, ispublished);
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
        public int UpdateVehicleMode(int id, string vehicleName, string vehicleType, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.UpdateVehicleMode(id, vehicleName, vehicleType, ispublished);
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
        public int DeleteVehicleMode(int id)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.DeleteVehicleMode(id);
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
        public int PublishVehicleMode(List<TransportModeList> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.PublishVehicleMode(parameter);
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
        #endregion
        #region VehicleInfo
        public DataTable GetVehicleMasterList(string typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetVehicleMasterList(typeValue);
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
        public DataTable GetVehicleMasterById(int typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetVehicleMasterById(typeValue);
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
        public int AddNewVehicleMaster(AddVehicleList addVehicleList)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddNewVehicleMaster(addVehicleList);
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
        public int UpdateVehicleMaster(AddVehicleList updateVehicleList)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.UpdateVehicleMaster(updateVehicleList);
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
        public int DeleteVehicleMaster(int id)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.DeleteVehicleMaster(id);
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
        public int PublishVehicleMaster(List<AddVehicleList> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.PublishVehicleMaster(parameter);
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
        #endregion
        #region AreaMaster
        public DataTable GetAreaMasterList(string typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetAreaMasterList(typeValue);
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
        public int AddAreaMaster(string areaName, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddAreaMaster(areaName, ispublished);
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
        public int UpdateAreaMaster(int id, string areaName, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.UpdateAreaMaster(id, areaName, ispublished);
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
        public int DeleteAreaMaster(int id)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.DeleteAreaMaster(id);
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
        public int PublishAreaMaster(List<AreaMasterList> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.PublishAreaMaster(parameter);
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
        #endregion
        #region vehiclePrice
        public DataTable GetTransportPriceList(string typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetTransportPriceList(typeValue);
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
        public int AddTransportPrice(int areaNameId, int vehicleModeId, int amount, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddTransportPrice(areaNameId, vehicleModeId, amount, ispublished);
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
        public int UpdateTransportPrice(int id, int amount, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.UpdateTransportPrice(id, amount, ispublished);
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
        public int DeleteTransportPrice(int id)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.DeleteTransportPrice(id);
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
        public int PublishTransportPrice(List<TransportFeeList> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.PublishTransportPrice(parameter);
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
        #endregion
        #region AreaVehicleMapping
        public DataTable GetAreaVehicleMappingList(string typeValue)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetAreaVehicleMappingList(typeValue);
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
        public int AddAreaVehicleMapping(int areaNameId, int vehicleMasterId, Boolean ispublished)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddAreaVehicleMapping(areaNameId, vehicleMasterId, ispublished);
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
        public int DeleteAreaVehicleMapping(int id)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.DeleteAreaVehicleMapping(id);
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
        public int PublishAreaVehicleMapping(List<TransportFeeList> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.PublishAreaVehicleMapping(parameter);
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
        #endregion
        #region VehicleUnderAreaMode
        public DataTable GetVehicleUnderModeOrArea(int modeId, int areaId)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetVehicleUnderModeOrArea(modeId, areaId);
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
        #endregion
        public int AddConveyanceMonthForStudent(List<AddConveyanceMonthForStudent> parameter)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddConveyanceMonthForStudent(parameter);
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
        public int UpdateConveyanceMonthForStudent(int applicationUserId, int divisionId, int standardId)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.UpdateConveyanceMonthForStudent(applicationUserId, divisionId, standardId);
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
        public int AddUpdateConveyanceMonthForStudent(int applicationUserId)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddUpdateConveyanceMonthForStudent(applicationUserId);
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
        public DataTable GetConveyanceMonthForStudent(int applicationUserId,int divisionId,int standardId)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.GetConveyanceMonthForStudent(applicationUserId,divisionId,standardId);
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
        public int AddStudentTransportHistory(int areaId,int modeId,string pickupvehichleNumber,int pickupvehichleNumberId,string dropVehicleNumber,int dropVehicleNumberId,DateTime fromDate,int applicationUserId,Boolean isCurrentActive, Boolean IsOneWayTrip)
        {

            TransportDAL objdal1 = new TransportDAL();
            try
            {
                return objdal1.AddStudentTransportHistory(areaId,modeId,pickupvehichleNumber,pickupvehichleNumberId,dropVehicleNumber,dropVehicleNumberId,fromDate,applicationUserId,isCurrentActive, IsOneWayTrip);
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