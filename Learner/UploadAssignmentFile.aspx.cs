using LMS.Admin.AssignmentClassFIle;
using LMS.Learner.BasicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class UploadAssignmentFile : System.Web.UI.Page
    {
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindGridviewOfAssignment();
            }
        }
        public void bindGridviewOfAssignment()
        {
            DataTable departmentId = new DataTable();
            departmentId = assignmentBLL.GetLearnerDepartmentId();
            int deptId = 0;
            if (departmentId.Rows.Count > 0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }
            DataTable dt = new DataTable();
            dt = assignmentBLL.AssignmentListUnderDepartment(deptId);
            ddlassignmentList.DataSource = dt;
            ddlassignmentList.DataBind();
            ddlassignmentList.DataTextField = "Title";
            ddlassignmentList.DataValueField = "Id";
            ddlassignmentList.DataBind();
            ddlassignmentList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void ddlassignmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGridviewOfSubmitedAssignment();
        }
        public void bindGridviewOfSubmitedAssignment()
        {

            DataTable dt = new DataTable();
            dt = assignmentBLL.GetSubmittedAssignmentByAssignmentId(int.Parse(ddlassignmentList.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[0].CssClass = "assignmentSrNumbercolumnwidth";
                //e.Row.Cells[7].CssClass = "columnwidth";
            }
        }
        protected void btnAssignmentSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt = assignmentBLL.GetSubmittedAssignmentByAssignmentId(int.Parse(ddlassignmentList.SelectedValue));
                if (dt.Rows.Count == 0)
                {
                    bool hasFile = FileUploadAssignment.HasFile;
                    if (hasFile)
                    {
                        int filecount = 0;
                        int fileuploadcount = 0;
                        filecount = FileUploadAssignment.PostedFiles.Count();

                        if (filecount <= 5)
                        {
                            List<FileUploadList> optionAnswer = new List<FileUploadList>();
                            int count = 0;
                            foreach (HttpPostedFile postedFile in FileUploadAssignment.PostedFiles)
                            {
                                count += 1;
                                var fileUploadPath = postedFile.FileName;
                                string extension = System.IO.Path.GetExtension(postedFile.FileName);
                                int applicationUserId = int.Parse(Session["applicationUserId"].ToString());
                                var clientId = Session["ClientID"].ToString();
                                var fileTitle = ddlassignmentList.SelectedItem.ToString();
                                var newfileTitle = fileTitle.Replace(" ", "");
                                var filename = newfileTitle + "_" + ddlassignmentList.SelectedValue.ToString() + "_" + applicationUserId.ToString() + "_" + TranTrackid + "_" + count.ToString();

                                string newFolderName = newfileTitle + "_" + ddlassignmentList.SelectedValue.ToString();
                                string onlyclientFolderPath = Server.MapPath("../SubmitAssignmentFile/" + clientId + "/");
                                if (!Directory.Exists(onlyclientFolderPath))
                                {
                                    //If Directory (Folder) does not exists. Create it.
                                    Directory.CreateDirectory(onlyclientFolderPath);
                                }
                                string clientFolderPath = Server.MapPath("../SubmitAssignmentFile/" + clientId + "/" + newFolderName + "/");
                                if (!Directory.Exists(clientFolderPath))
                                {
                                    //If Directory (Folder) does not exists. Create it.
                                    Directory.CreateDirectory(clientFolderPath);
                                }
                                if (System.IO.File.Exists(Path.Combine(clientFolderPath, filename)))
                                {
                                    // If file found, delete it    
                                    System.IO.File.Delete(Path.Combine(clientFolderPath, filename));
                                }
                                FileUploadAssignment.SaveAs(clientFolderPath + filename.ToString() + extension);
                                var completeFileName = "/SubmitAssignmentFile/" + clientId + "/" + newFolderName + "/" + filename.ToString() + extension;
                                optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                                completeFileName = "";
                            }
                            var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                            var completePath = selectedvalue;
                            var result = assignmentBLL.SubmitNewAssignmentByLearner(int.Parse(ddlassignmentList.SelectedValue), completePath);
                            if (result > 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Assignment Uploaded successfully.')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong.')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can upload maximum 5 file only.')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please select file to upload.')", true);
                    }












                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have already submitted your Assignment.')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[2].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[3].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[4].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[5].CssClass = "assignmentcolumnwidth";
            }
        }
        protected void linkAssignmentFileView_Click(object sender, EventArgs e)
        {
            DataTable assisnmentFilePath = new DataTable();
            var selectedFIle = "";
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            assisnmentFilePath = assignmentBLL.GetSubmitAssignmentById(int.Parse(lblID));
            if (assisnmentFilePath.Rows.Count > 0)
            {
                selectedFIle = assisnmentFilePath.Rows[0]["AnswerFilePath"].ToString();
            }
            //var selectedFIle = gvrow.Cells[7].Text;
            var updatedData = selectedFIle.Replace("&quot;", '"'.ToString());
            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<FileUploadList>>(updatedData);
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("FilePath") });
            //using (var zipStream = new ZipOutputStream(Response.OutputStream))
            //{
            int count = 0;
            foreach (var filePath in correctAnswerSerializeData)
            {
                count += 1;
                string[] authorsList = filePath.FileName.Split('/');
                var finalName = authorsList.LastOrDefault();
                string extension = System.IO.Path.GetExtension(finalName);
                string CompletefilePath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + filePath.FileName.ToString();// ServerMapPath(filePath.FileName.ToString());
                dt.Rows.Add(count, CompletefilePath);
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            ModalPopupExtender1.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] authorsList = e.CommandArgument.ToString().Split('\\');
            var finalName = authorsList.LastOrDefault();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            //string extension = Path.GetExtension(finalName);
            //string contentType = "";

            //switch (extension)
            //{
            //    case ".pdf":
            //        contentType = "application/pdf";
            //        break;
            //    case ".xslx":
            //        contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //        break;
            //    case ".docx":
            //        contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
            //        break;
            //}
            //Response.ContentType = contentType;
            Response.AppendHeader("Content-Disposition", "filename=" + finalName);
            Response.TransmitFile("" + e.CommandArgument);
            Response.End();
        }
    }
}