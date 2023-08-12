using LMS.Admin.DepartmentClassFile;
using LMS.Admin.DivisionClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class ClassDivisionAllotment : System.Web.UI.Page
    {
        DivisionBLL divisionBll = new DivisionBLL();
        DeptBLL deptbll = new DeptBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddepartmentddl();
                bindDivisionDDL();
                getAllotedDivisionandDepartment();
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddllessonDepartment.DataSource = dt;
            ddllessonDepartment.DataBind();
            ddllessonDepartment.DataTextField = "DepartmentStandardName";
            ddllessonDepartment.DataValueField = "Id";
            ddllessonDepartment.DataBind();
            ddllessonDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindDivisionDDL()
        {
            DataTable dt = new DataTable();
            dt = divisionBll.GetDivisionList("Active");
            ddlDivision.DataSource = dt;
            ddlDivision.DataBind();
            ddlDivision.DataTextField = "Section";
            ddlDivision.DataValueField = "Id";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void getAllotedDivisionandDepartment()
        {
            DataTable dt = new DataTable();
            dt = divisionBll.GetClassDivisionAllotment();
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
                //e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[4].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[5].CssClass = "columnwidth";
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getAllotedDivisionandDepartment();
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            var result = divisionBll.AssignClassDivisionAllotment(int.Parse(ddllessonDepartment.SelectedValue),int.Parse(ddlDivision.SelectedValue));
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Division Alloted Sucessfully')", true);
                getAllotedDivisionandDepartment();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteAllotedClassDivisionId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletelessonId = int.Parse(lblDeleteAllotedClassDivisionId.Text);
                var result = divisionBll.DeleteClassDivisionAllotment(deletelessonId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Alloted division Deleted Sucessfully')", true);
                    getAllotedDivisionandDepartment();
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
                divisionBll = null;
            }

        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=AllotedClassDivisionList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Class and Alloted Division List</font></td></tr>
                                        <tr><td colspan='5'></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(sw.ToString());
            string footerTable = @"<Table><tr><td colspan='5'></td></tr><tr><td colspan='2' align='left'><b>Report By :</b>" + userName + "</td><td></td><td colspan='2' align='right'><b>Date :</b>" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr></Table>";
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
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = divisionBll.GetClassDivisionAllotment();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Section LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = divisionBll.GetClassDivisionAllotment();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Section LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}