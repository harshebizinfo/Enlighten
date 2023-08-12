using LMS.Admin.AssignmentClassFIle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class AllAssignmentList : System.Web.UI.Page
    {
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindAllAsignments();
            }
        }
        public void BindAllAsignments()
        {
            DataTable dt = new DataTable();
            dt = assignmentBLL.GetUploadedAssignmentUnderTrainee("Complete");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAllAsignments();
        }
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = assignmentBLL.GetUploadedAssignmentUnderTrainee("Complete");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%'  OR AssignmentTitle LIKE '%" + search + "%'";
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
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[2].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[3].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[4].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[5].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[6].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[7].CssClass = "assignmentcolumnwidth";
                e.Row.Cells[8].CssClass = "assignmentcolumnwidth";
            }
        }
        protected void linkAssignmentFileView_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            var lblID = (btndetails.CommandArgument).ToString();
            Session["ViewAllStudentsByAssignmentId"] = lblID;
            Response.Redirect("AssignmentSubmitedByLearner.aspx");
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Requested for feedback successfully.');", true);
        }
    }
}