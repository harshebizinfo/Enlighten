using LMS.Admin.ClassFile;
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
    public partial class LearnerList : System.Web.UI.Page
    {
        AdminBLL bll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!this.IsPostBack)
            {
                getclients();
            }
        }
        private void BindGrid(string p)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetApplicationUserList();
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentName LIKE '%" + search + "%'  OR Section LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = bll.GetApplicationUserList();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
        }
        protected void btnAddLearner_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLearner1.aspx");
        }
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetApplicationUserList();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentName LIKE '%" + search + "%'  OR Section LIKE '%" + search + "%'";
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
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                 e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[0].CssClass = "columnwidth";
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
                e.Row.Cells[8].CssClass = "columnwidth";
            }
        }
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetApplicationUserList();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FirstName LIKE '%" + search + "%' OR LastName LIKE '%" + search + "%'  OR EmailId LIKE '%" + search + "%'  OR FatherName LIKE '%" + search + "%' OR FatherContactNumber LIKE '%" + search + "%' OR DepartmentName LIKE '%" + search + "%'  OR Section LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EditLearnerApplicationUserId"] = id;
            Response.Redirect("EditLearner.aspx");
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteTraineeId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=LearnerList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='7' align='center'><font size='7'>Learner List</font></td></tr>
                                        <tr><td colspan='7'></td></tr></Table>";
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
        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            List<int> deleteingId = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label labelId = row.FindControl("lblid") as Label;
                Boolean isActive = false;
                int id = Convert.ToInt32(labelId.Text);
                CheckBox checkIsActive = row.FindControl("chkDelete") as CheckBox;

                if (checkIsActive.Checked == true)
                {
                    deleteingId.Add(id);
                }
            }
            if (deleteingId.Count > 0)
            {
                this.ModalPopupExtender2.Show();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Trainee to delete')", true);
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var deletingId = int.Parse(lblDeleteTraineeId.Text);
                var result = bll.DeleteApplicationUser(deletingId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Deleted Sucessfully')", true);
                    getclients();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
                //int resultCount = 0;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label labelId = row.FindControl("lblid") as Label;
                //    Boolean isActive = false;
                //    int deleteid = Convert.ToInt32(labelId.Text);
                //    CheckBox checkIsActive = row.FindControl("chkDelete") as CheckBox;

                //    if (checkIsActive.Checked == true)
                //    {

                //        var result = bll.DeleteApplicationUser(deleteid);
                //        if (result > 0)
                //        {
                //            resultCount += 1;
                //        }
                //        else
                //        {
                //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                //        }
                //    }
                //}
                //if (resultCount > 0)
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('User Deleted Sucessfully')", true);
                //    getclients();
                //}
                //else
                //{
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                //}
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
    }
}