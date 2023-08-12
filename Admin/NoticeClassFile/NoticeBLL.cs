using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.NoticeClassFile
{
    public class NoticeBLL
    {
        public DataTable GetNoticeList(string typeValue)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.GetNoticeList(typeValue);
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
        public int AddNotice(string title, string description, Boolean ispublished)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.AddNotice(title, description, ispublished);
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
        public int UpdateNotice(int id, string title, string description, Boolean ispublished)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.UpdateNotice(id, title, description, ispublished);
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
        public int DeleteNotice(int id)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.DeleteNotice(id);
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
        public int PublishNotice(List<NoticeMasterList> parameter)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.PublishNotice(parameter);
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
        public int AddAssignNotice(int noticeId,int standardId,Boolean isForStudent)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.AddAssignNotice(noticeId, standardId, isForStudent);
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
        public int DeleteAssignNotice(int noticeId)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.DeleteAssignNotice(noticeId);
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
        public DataTable GetAssignNotice(int noticeId)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.GetAssignNotice(noticeId);
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
        public DataTable GetAssignNoticeForStudentAndTrainee(string type,int? standardId)
        {

            NoticeDAL objdal1 = new NoticeDAL();
            try
            {
                return objdal1.GetAssignNoticeForStudentAndTrainee(type, standardId);
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