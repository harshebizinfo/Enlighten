using LMS.Admin.AssignmentClassFIle;
using LMS.Admin.NoticeClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class LearnerNoticeList : System.Web.UI.Page
    {
        NoticeBLL noticeBLL = new NoticeBLL();
        AssignmentBLL assignmentBLL = new AssignmentBLL();
        int deletingID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!IsPostBack)
            {
                getclients();
            }
        }
        //private DataTable socialEvents;
        private void BindGrid(string p)
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
            dt = noticeBLL.GetAssignNoticeForStudentAndTrainee("Student", deptId);
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "Title LIKE '%" + search + "%' OR NoticeDescription LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void getclients()
        {
            DataTable departmentId = new DataTable();
            departmentId = assignmentBLL.GetLearnerDepartmentId();
            int deptId = 0;
            if (departmentId.Rows.Count > 0)
            {
                deptId = int.Parse(departmentId.Rows[0]["DepartmentStandardId"].ToString());
            }

            DataTable dt = new DataTable();
            dt = noticeBLL.GetAssignNoticeForStudentAndTrainee("Student", deptId);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
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
            dt = noticeBLL.GetAssignNoticeForStudentAndTrainee("Student", deptId);
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Title LIKE '%" + search + "%' OR NoticeDescription LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
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
            dt = noticeBLL.GetAssignNoticeForStudentAndTrainee("Student", deptId);
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Title LIKE '%" + search + "%' OR NoticeDescription LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}