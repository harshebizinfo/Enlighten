using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
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
    public partial class StudentList : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        AdminBLL adminBll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!this.IsPostBack)
            {
                binddepartmentddl();
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardUnderTraineeList("Teacher");
            ddlDepartmentStandard.DataSource = dt;
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.DataTextField = "DepartmentStandardName";
            ddlDepartmentStandard.DataValueField = "Id";
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        //private void BindGrid(string p)
        //{
        //    string search = txtSearch.Text;
        //    DataTable dt = new DataTable();
        //    dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartmentStandard.SelectedValue));
        //    DataView DataView = dt.DefaultView;
        //    DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentName LIKE '%" + search + "%'";
        //    GridView1.DataSource = DataView;
        //    GridView1.DataBind();
        //    ViewState["data"] = dt;
        //}
        public void getGroups()
        {
            DataTable dt = new DataTable();
            dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartmentStandard.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getGroups();
        }

        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            getGroups();
            //BindGrid(string.Empty);
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
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
            }
        }
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartmentStandard.SelectedValue));
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartmentStandard.SelectedValue));
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'"; ;
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }

        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=StudentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='7' align='center'><font size='7'>"+ ddlDepartmentStandard.SelectedItem.ToString() +" Student List</font></td></tr>                                        <tr><td colspan='7'></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(sw.ToString());
            string footerTable = @"<Table><tr><td colspan='7'></td></tr><tr><td colspan='3' align='left'><b>Report By :</b>" + userName + "</td><td></td><td colspan='3' align='right'><b>Date :</b>" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr></Table>";
            Response.Write(footerTable);
            Response.End();
        }
        private void PrepareGridViewForExport(Control gv)
        {
            LinkButton lb = new LinkButton();
            Literal l = new Literal();
            string name = String.Empty;
            for (int i = 0; i < gv.Controls.Count; i++)
            {
                if (gv.Controls[i].GetType() == typeof(LinkButton))
                {
                    l.Text = (gv.Controls[i] as LinkButton).Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(DropDownList))
                {
                    l.Text = (gv.Controls[i] as DropDownList).SelectedItem.Text;
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                else if (gv.Controls[i].GetType() == typeof(CheckBox))
                {
                    l.Text = (gv.Controls[i] as CheckBox).Checked ? "True" : "False";
                    gv.Controls.Remove(gv.Controls[i]);
                    gv.Controls.AddAt(i, l);
                }
                if (gv.Controls[i].HasControls())
                {
                    PrepareGridViewForExport(gv.Controls[i]);
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
    }
}