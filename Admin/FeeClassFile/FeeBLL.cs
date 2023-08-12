using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.FeeClassFile
{
    public class FeeBLL
    {
        #region FeeGroup
        public DataTable GetFeeGroupList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeGroupList(typeValue);
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
        public int AddFeeGroup(string feeGroupName, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddFeeGroup(feeGroupName, ispublished);
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
        public int UpdateFeeGroup(int id, string feeGroupName, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateFeeGroup(id, feeGroupName, ispublished);
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
        public int DeleteFeeGroup(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteFeeGroup(id);
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
        public int PublishFeeGroup(List<FeeGroupList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishFeeGroup(parameter);
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

        #region FeeNameMaster
        public DataTable GetFeeNameMasterList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeNameMasterList(typeValue);
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
        public DataTable GetFeeNameMasterListById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeNameMasterListById(id);
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
        public int AddFeeNameMaster(AddFeeNameMasterList addFeeNameMasterList)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddFeeNameMaster(addFeeNameMasterList);
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
        public int UpdateFeeNameMaster(AddFeeNameMasterList updateFeeNameMasterList)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateFeeNameMaster(updateFeeNameMasterList);
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
        public int DeleteFeeNameMaster(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteFeeNameMaster(id);
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
        public int PublishFeeNameMaster(List<AddFeeNameMasterList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishFeeNameMaster(parameter);
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
        #region CategoryMaster
        public DataTable GetCategoryMasterList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetCategoryMasterList(typeValue);
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
        public int AddNewCategoryMaster(string categoryName, string categoryDescription, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddNewCategoryMaster(categoryName, categoryDescription, ispublished);
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
        public int UpdateCategoryMaster(int id, string categoryName, string categoryDescription, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateCategoryMaster(id, categoryName, categoryDescription, ispublished);
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
        public int DeleteCategoryMaster(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteCategoryMaster(id);
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
        public int PublishCategoryMaster(List<CategoryMasterList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishCategoryMaster(parameter);
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
        #region FeeMonth
        public DataTable GetFeeMonthMasterList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeMonthMasterList(typeValue);
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
        public DataTable GetFeeMonthMasterListById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeMonthMasterListById(id);
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
        public int AddNewFeeMonthMaster(string feeMonth, string feeMonthType, int numberOfMonth, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddNewFeeMonthMaster(feeMonth, feeMonthType, numberOfMonth, ispublished);
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
        public int UpdateFeeMonthMaster(int id, string feeMonth, string feeMonthType, int numberOfMonth, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateFeeMonthMaster(id, feeMonth, feeMonthType, numberOfMonth, ispublished);
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
        public int DeleteFeeMonthMaster(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteFeeMonthMaster(id);
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
        public int PublishFeeMonthMaster(List<FeeMonthMasterList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishFeeMonthMaster(parameter);
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
        #region FeeTypeMaster
        public DataTable GetFeeTypeMasterList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeTypeMasterList(typeValue);
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
        public DataTable GetFeeTypeMasterById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeTypeMasterById(id);
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
        public int AddFeeTypeMasterMaster(AddFeeTypeMasterList parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddFeeTypeMasterMaster(parameter);
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
        public int UpdateFeeTypeMaster(AddFeeTypeMasterList parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateFeeTypeMaster(parameter);
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
        public int DeleteFeeTypeMaster(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteFeeTypeMaster(id);
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
        public int PublishFeeTypeMaster(List<AddFeeTypeMasterList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishFeeTypeMaster(parameter);
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
        #region FeeStructure
        public DataTable GetFeeStructureList(string typeValue)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeStructureList(typeValue);
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
        public DataTable GetFeeStructureById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeStructureById(id);
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
        public int AddFeeStructure(AddFeeStructureList parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddFeeStructure(parameter);
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
        public int UpdateFeeStructure(int id, int amount, Boolean ispublished)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateFeeStructure(id, amount, ispublished);
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
        public int DeleteFeeStructure(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.DeleteFeeStructure(id);
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
        public int PublishFeeStructure(List<AddFeeStructureList> parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.PublishFeeStructure(parameter);
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
        public int AddFeeTypeMasterAndFeeStructure(AddFeeTypeStructureList parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddFeeTypeMasterAndFeeStructure(parameter);
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
        public int InsertPreviousBalanceFee(AddPreviousBalanceFee addPreviousBalanceFee)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertPreviousBalanceFee(addPreviousBalanceFee);
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
        public int AddAndCalculateBalanceFee(int applicationUserId,int categoryId)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.AddAndCalculateBalanceFee(applicationUserId, categoryId);
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
        public DataTable CheckIsUserAlreadyExists(int applicationUserId)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.CheckIsUserAlreadyExists(applicationUserId);
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
        public DataTable GetFeeDetails(AddPayment addPayment)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeDetails(addPayment);
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
        public DataTable GetTempPaymentDetailById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetTempPaymentDetailById(id);
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
        public int InsertTempPaymentDetail(AddPayment addPayment)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertTempPaymentDetail(addPayment);
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
        public DataTable GetTempSubscriptionPaymentById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetTempSubscriptionPaymentById(id);
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
        public int InsertTempSubscriptionPaymentDetail(SubscriptionModel addPayment)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertTempSubscriptionPaymentDetail(addPayment);
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
        public DataTable GetSubscriptionPaymentById(int id)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetSubscriptionPaymentById(id);
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
        public int UpdateClientSubscription(SubscriptionModel parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.UpdateClientSubscription(parameter);
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
        public int InsertSubscriptionPaymentDetail(SubscriptionModel addPayment)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertSubscriptionPaymentDetail(addPayment);
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
        public int GenerateReceiptNumber(DateTime receiptDate,int applicationUserId)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GenerateReceiptNumber(receiptDate, applicationUserId);
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
        public int InsertFeeTransactionOnline(AddFeeTransaction parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertFeeTransactionOnline(parameter);
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
        public int InsertFeeTransactionDetail(FeeTransactionDetail parameter)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.InsertFeeTransactionDetail(parameter);
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
        public DataTable GetFeeTransactionByReceiptNumber(int receiptId)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeTransactionByReceiptNumber(receiptId);
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
        public DataTable GetFeeTransactionDetailByReceiptNumber(int receiptId)
        {

            FeeDAL objdal1 = new FeeDAL();
            try
            {
                return objdal1.GetFeeTransactionDetailByReceiptNumber(receiptId);
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