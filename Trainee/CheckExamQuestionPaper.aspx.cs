using ICSharpCode.SharpZipLib.Zip;
using LMS.Learner;
using LMS.Learner.BasicClass;
using LMS.Trainee.BasicClass;
using LMS.Trainee.QuestionClassFile;
using Magnum.FileSystem;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class CheckExamQuestionPaper : System.Web.UI.Page
    {
        QuestionBLL questionbll = new QuestionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int departmentId = int.Parse(Session["StandardId"].ToString());
                int subjectId = int.Parse(Session["SubjectId"].ToString());
                int examId = int.Parse(Session["examId"].ToString());
                int userId = int.Parse(Session["CheckUserId"].ToString());
                int numberOfAttempts = int.Parse(Session["NumberOfAttempts"].ToString());
                DataTable dt = new DataTable();
                dt = questionbll.GETLearnerAnswer(departmentId, subjectId, examId, userId, numberOfAttempts);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int totalMarks = 0;
            int departmentId = int.Parse(Session["StandardId"].ToString());
            int subjectId = int.Parse(Session["SubjectId"].ToString());
            int examId = int.Parse(Session["examId"].ToString());
            int userId = int.Parse(Session["CheckUserId"].ToString());
            int numberOfAttempts = 0;
            List<ExamAnswer> examAnswerList = new List<ExamAnswer>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label labelId = row.FindControl("lblid") as Label;
                int rollno1 = int.Parse(labelId.Text);
                TextBox txtMarksValue = (row.Cells[4].FindControl("txtMarks") as TextBox);

                int marks = int.Parse(txtMarksValue.Text);
                totalMarks += marks;
                numberOfAttempts = Convert.ToInt32(row.Cells[6].Text);
                examAnswerList.Add(new ExamAnswer { ExamAnswerId = rollno1, Marks = marks });
            }
            int result = questionbll.UpdateLearnerMarks(examAnswerList);
            int updatedcheckedId = questionbll.UpdateNumberOfExamAttemptsIsChecked(departmentId, subjectId, examId, userId, numberOfAttempts);
            if (result > 0)
            {
                int totalObtainedMarks = questionbll.UpdateStudentResultTotalMarks(departmentId, subjectId, examId, userId, numberOfAttempts, totalMarks);
                //if (totalObtainedMarks > 0)
                if (totalObtainedMarks > 0)
                {
                    Session["CheckUserId"] = "";
                    Session["StandardId"] = "";
                    Session["SubjectId"] = "";
                    Session["examId"] = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    Response.Redirect("CheckQuestionPaper.aspx?value=Sucess");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int departmentId = int.Parse(Session["StandardId"].ToString());
            int subjectId = int.Parse(Session["SubjectId"].ToString());
            int examId = int.Parse(Session["examId"].ToString());
            int userId = int.Parse(Session["CheckUserId"].ToString());
            int numberOfAttempts = int.Parse(Session["NumberOfAttempts"].ToString());
            DataTable dt = new DataTable();
            dt = questionbll.GETLearnerAnswer(departmentId, subjectId, examId, userId, numberOfAttempts);
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnsizedwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnsizedwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
                e.Row.Cells[8].CssClass = "columnwidth";
                e.Row.Cells[9].CssClass = "columnwidth";
                e.Row.Cells[10].CssClass = "columnwidth";
                e.Row.Cells[11].CssClass = "columnwidth";
            }
        }
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            Button btndetails = sender as Button;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var selectedFIle = gvrow.Cells[3].Text;
            var updatedData = selectedFIle.Replace("&quot;", '"'.ToString());
            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<FileUploadList>>(updatedData);
            //HttpResponse res = GetHttpResponse();
            //Response.AddHeader("Content-Disposition", "attachment; filename=AnswerFile.zip");
            //Response.ContentType = "application/zip";
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Id"), new DataColumn("FilePath")});
            //using (var zipStream = new ZipOutputStream(Response.OutputStream))
            //{
                int count = 0;
                foreach (var filePath in correctAnswerSerializeData)
                {
                    count += 1;
                    string[] authorsList = filePath.FileName.Split('/');
                    var finalName = authorsList.LastOrDefault();
                    string extension = System.IO.Path.GetExtension(finalName);
                    string CompletefilePath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString() + "/" + filePath.FileName.ToString();// ServerMapPath(filePath.FileName.ToString());
                dt.Rows.Add(count, CompletefilePath);
                    //byte[] fileBytes = System.IO.File.ReadAllBytes(CompletefilePath);

                    //var fileEntry = new ZipEntry(Path.GetFileName(filePath.FileName))
                    //{
                    //    Size = fileBytes.Length
                    //};

                    //zipStream.PutNextEntry(fileEntry);
                    //zipStream.Write(fileBytes, 0, fileBytes.Length);


                    // string attachment = "attachment; filename=DepartmentList.xls";
                    //res.Clear();
                    //res.AppendHeader("content-disposition", "attachment; filename=" + finalName.ToString());
                    //res.ContentType = ReturnExtension(extension.ToLower());
                    //res.WriteFile(CompletefilePath);
                    //res.Flush();
                   

                }
                GridView2.DataSource = dt;
                GridView2.DataBind();
            ModalPopupExtender1.Show();
                //zipStream.Flush();
                //zipStream.Close();
                // }
                //res.End();
        }
        public static string ServerMapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
        public static HttpResponse GetHttpResponse()
        {
            return HttpContext.Current.Response;
        }
        private string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }
        protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string[] authorsList = e.CommandArgument.ToString().Split('\\');
            var finalName = authorsList.LastOrDefault();
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "filename=" + finalName);
            Response.TransmitFile(""+e.CommandArgument);
            Response.End();
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
    }
}