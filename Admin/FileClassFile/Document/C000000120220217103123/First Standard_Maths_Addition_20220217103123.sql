
drop procedure sp_get_coursenames_for_payment_online							(no modification required)
drop procedure sp_get_Class_Section_allotment									(modification required ) from [ClassMaster] table
drop procedure sp_get_Fees_Report_online										(No modification required) update FeeTransaction add column onlineAmt, onlineDate, OnlineReferenceNumber
drop procedure sp_get_Fees_Report_only_online									(no modification required)
drop procedure sp_Get_PaymentData												(no modification required)
drop procedure sp_check_if_registrationnumber_exists_online						(no modification required)
drop procedure sp_get_personal_details_online									(modification required)  SectionName to AppliedStream
drop procedure sp_get_tempTabledata_for_reverification_all						(no modification required)
drop procedure sp_updateTempPaymentstatus_verified		 						(no modification required)
drop procedure sp_get_fees_details_online				 						(no modification required)
drop procedure sp_get_Latefees_details_online				 					(no modification required)
drop procedure sp_insert_temp_Data							 					(no modification required)
drop procedure sp_get_temp_Data_online											(no modification required)
drop procedure sp_GenerateReceipt												(no modification required)
drop procedure sp_insert_FeeTransactionOnline									(no modification required)
drop procedure sp_insert_FeeTransactionDetailOnline								(no modification required)
drop procedure sp_get_FeeTypeSeqNo												(no modification required)
drop procedure sp_get_FeeHeadSeqNo												(no modification required)
drop procedure sp_getpersonaldetailsReceipt_online								(no modification required)
drop procedure sp_getTotalFeedetailsReceipt_online								(no modification required)
drop procedure sp_getFeeTransdetailsReceipt_online								(no modification required)


Queries
How fees to be calculated ?

class master contain two more field can we have to include that amount in fee