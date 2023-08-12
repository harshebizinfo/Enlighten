using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LMS.Admin.FileClassFile
{
    public class FileBLL
    {
        public int AddDocumentInDrive(int deptId, int courseId, int lessonId, string documentId,string sharedLink)
        {

            FileDAL objdal1 = new FileDAL();
            try
            {
                return objdal1.AddDocumentInDrive(deptId, courseId, lessonId, documentId, sharedLink);
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
        public List<string> GetDocumentInDriveByDeptId(int deptId)
        {

            FileDAL objdal1 = new FileDAL();
            try
            {
                return objdal1.GetDocumentInDriveByDeptId(deptId);
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
        public int DeleteDocumentInDrive(string documentId)
        {

            FileDAL objdal1 = new FileDAL();
            try
            {
                return objdal1.DeleteDocumentInDrive(documentId);
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