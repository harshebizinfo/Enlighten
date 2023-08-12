using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.VideoClassFile
{
    public class VideoBLL
    {
        public int AddYoutubeVideo(int deptId,int courseId,int lessonId,string videoId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.AddYoutubeVideo(deptId,courseId,lessonId,videoId);
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
        public int AddPlayList(int deptId, int courseId, int lessonId, string playListId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.AddPlayList(deptId, courseId, lessonId, playListId);
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
        public int DeletePlayList(string playListId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.DeletePlayList(playListId);
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
        public int AddPlayListItem(int deptId, int courseId, int lessonId, string playListId,string itemId,string videoId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.AddPlayListItem(deptId, courseId, lessonId, playListId,itemId,videoId);
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
        public int DeletePlayListItem(string playListId,string itemId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.DeletePlayListItem(playListId, itemId);
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
        public DataTable GetPlayList(string playListId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.GetPlayList(playListId);
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
        public List<string> GetPlayListByDeptId(int deptId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.GetPlayListByDeptId(deptId);
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
        public List<string> GetPlayListUnderLesson(int deptId,int courseId,int lessonId)
        {

            VideoDAL objdal1 = new VideoDAL();
            try
            {
                return objdal1.GetPlayListUnderLesson(deptId,courseId,lessonId);
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