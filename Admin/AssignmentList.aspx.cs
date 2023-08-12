using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.LessonClassFile;
using LMS.Learner.BasicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AssignmentList : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        LessonBLL bll = new LessonBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bindAssignmentListdepartmentddl();
            }
        }
        public void bindAssignmentListdepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlassignmentdepartmentList.DataSource = dt;
            ddlassignmentdepartmentList.DataBind();
            ddlassignmentdepartmentList.DataTextField = "DepartmentStandardName";
            ddlassignmentdepartmentList.DataValueField = "Id";
            ddlassignmentdepartmentList.DataBind();
            ddlassignmentdepartmentList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentListCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlassignmentdepartmentList.SelectedValue));
            ddlassignmentCourseList.DataSource = dt;
            ddlassignmentCourseList.DataBind();
            ddlassignmentCourseList.DataTextField = "CourseSubjectName";
            ddlassignmentCourseList.DataValueField = "Id";
            ddlassignmentCourseList.DataBind();
            ddlassignmentCourseList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAssignmentListlessonddl()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonListUnderDeptCourse(int.Parse(ddlassignmentdepartmentList.SelectedValue), int.Parse(ddlassignmentCourseList.SelectedValue));
            ddlassignmentLessonList.DataSource = dt;
            ddlassignmentLessonList.DataBind();
            ddlassignmentLessonList.DataTextField = "LessonTitle";
            ddlassignmentLessonList.DataValueField = "Id";
            ddlassignmentLessonList.DataBind();
            ddlassignmentLessonList.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void ddlassignmentdepartmentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentListCourseddl();
        }

        protected void ddlassignmentCourseList_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindAssignmentListlessonddl();
        }
        protected void linkAssignmentFileView_Click(object sender, EventArgs e)
        {
            DataTable assisnmentFilePath = new DataTable();
            var selectedFIle = "";
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            assisnmentFilePath = assignmentBLL.GetAssignmentList(int.Parse(lblID));
            if (assisnmentFilePath.Rows.Count > 0)
            {
                selectedFIle = assisnmentFilePath.Rows[0]["AssignmentFilePath"].ToString();
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
                var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                string CompletefilePath = prefixPath+"/Admin/" + filePath.FileName.ToString();// ServerMapPath(filePath.FileName.ToString());
                dt.Rows.Add(count, CompletefilePath);
            }
            GridView2.DataSource = dt;
            GridView2.DataBind();
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void linkAssignmentDelete_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            Session["AssignmentId"] = lblID;
            ModalPopupExtender2.Show();
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[2].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[3].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[4].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[5].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[6].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[7].CssClass = "assignmentcolumnwidth";
                //e.Row.Cells[8].CssClass = "assignmentcolumnwidth";
            }
        }
        //protected void gvFiles_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    string[] authorsList = e.CommandArgument.ToString().Split('\\');
        //    var finalName = authorsList.LastOrDefault();
        //    Response.Clear();
        //    //Response.ContentType = "application/octet-stream";
        //    string extension = Path.GetExtension(finalName);
        //    string contentType = "";

        //    switch (extension)
        //    {
        //        case ".pdf":
        //            contentType = "application/pdf";
        //            break;
        //        case ".xslx":
        //            contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            break;
        //        case ".docx":
        //            contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
        //            break;
        //    }
        //    Response.AppendHeader("Content-Disposition", "filename=" + finalName);
        //    Response.TransmitFile("" + e.CommandArgument);
        //    Response.End();
        //}
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int resultCount = 0;
                int id = int.Parse(Session["AssignmentId"].ToString());
                var result = assignmentBLL.DeleteAssignment(id);

                if (resultCount > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Deleted Sucessfully')", true);
                    bindAssignmentList();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bll = null;
            }

        }
        public void bindAssignmentList()
        {
            DataTable dt = new DataTable();
            dt = assignmentBLL.AssignmentList(int.Parse(ddlassignmentdepartmentList.SelectedValue), int.Parse(ddlassignmentCourseList.SelectedValue), int.Parse(ddlassignmentLessonList.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnAssignmentSearch_Click(object sender, EventArgs e)
        {
            bindAssignmentList();
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