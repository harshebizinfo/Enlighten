using LMS.Admin.AssignmentClassFIle;
using LMS.Learner.BasicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class AssignmentList : System.Web.UI.Page
    {
        AssignmentBLL assignmentBLL = new AssignmentBLL();
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
            if(departmentId.Rows.Count>0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }
            DataTable dt = new DataTable();
            dt = assignmentBLL.AssignmentListUnderDepartment(deptId);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void src_Click(object sender, EventArgs e)
        {
            DataTable departmentId = new DataTable();
            departmentId = assignmentBLL.GetLearnerDepartmentId();
            int deptId = 0;
            if (departmentId.Rows.Count > 0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = assignmentBLL.AssignmentListUnderDepartment(deptId);
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseName LIKE '%" + search + "%'  OR DepartmentName LIKE '%" + search + "%' OR LessonName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
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
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[2].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[3].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[4].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[5].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[6].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[7].CssClass = "assignmentcolumnwidth";
            }
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