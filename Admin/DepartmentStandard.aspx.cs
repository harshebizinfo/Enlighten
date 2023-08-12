using LMS.Admin.DepartmentClassFile;
using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class DepartmentStandard1 : System.Web.UI.Page
    {
        DeptBLL bll = new DeptBLL();
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
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetDepartmentStandardList("Full");
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "DepartmentStandardName LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = bll.GetDepartmentStandardList("Full");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Cells[1].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[2].CssClass = "columnwidth";
                //e.Row.Cells[3].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[4].CssClass = "publishedcolumnwidth";
                
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDepartmentName.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard cannot be empty')", true);
                }
                else
                {
                    Boolean isPublished = false;
                    if (CheckBox1.Checked == true)
                    {
                        isPublished = true;
                    }
                    DataTable dtdepartmentstandard = new DataTable();
                    dtdepartmentstandard = bll.GetDepartmentStandardList("Full");
                    List<string> departmentstandard = new List<string>();
                    departmentstandard = dtdepartmentstandard.AsEnumerable()
                   .Select(r => r.Field<string>("DepartmentStandardName"))
                   .ToList();
                    if (!departmentstandard.Contains(txtDepartmentName.Text))
                    {
                        var result = bll.AddNewDepartmentStandard(txtDepartmentName.Text, isPublished);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard Registered Sucessfully')", true);
                            getclients();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard already in available')", true);
                    }
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
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["id"] = id;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //Label lbl_p = gvr.FindControl("lbl_phone") as Label;
            Label labelName = gvrow.FindControl("lbldepartmentname") as Label;
            string name = labelName.Text;
            Label labelboolean = gvrow.FindControl("lblIsActive") as Label;
            Boolean ischeckedvalue = labelboolean.Text == "Active" ? true : false;

            lblID.Text = id;
            txtname.Text = name;
            CheckBox2.Checked = ischeckedvalue;
            this.ModalPopupExtender1.Show();
        }

        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteAdminDepartmentId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            List<int> deleteingId = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label labelid = row.FindControl("lblid") as Label;
                CheckBox checkIsActive = row.FindControl("chkDelete") as CheckBox;
                Boolean isActive = false;
                int id = Convert.ToInt32(labelid.Text);

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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select department to delete')", true);
            }

        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtname.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard cannot be empty')", true);
                }
                else
                {
                    Boolean isPublished = false;
                    if (CheckBox2.Checked == true)
                    {
                        isPublished = true;
                    }

                    var result = bll.UpdateDepartmentStandard(int.Parse(lblID.Text), txtname.Text, isPublished);
                    if (result > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard Updated Sucessfully')", true);
                        getclients();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                    }
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int departmentDeleteId = int.Parse(lblDeleteAdminDepartmentId.Text);
                var result = bll.DeleteDepartmentStandard(departmentDeleteId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard Deleted Sucessfully')", true);
                    getclients();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
                //int resultCount = 0;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Label labelid = row.FindControl("lblid") as Label;
                //    Label labelIsActive = row.FindControl("lblIsActive") as Label;
                //    CheckBox checkIsActive = row.FindControl("chkDelete") as CheckBox;
                //    int deleteid = Convert.ToInt32(labelid.Text);

                //    if (checkIsActive.Checked == true)
                //    {

                //        var result = bll.DeleteDepartmentStandard(deleteid);
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
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department / Standard Deleted Sucessfully')", true);
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
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<DepartmentStandardList> examAnswerList = new List<DepartmentStandardList>();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label labelid = row.FindControl("lblid") as Label;
                    Label labelIsActive = row.FindControl("lblIsActive") as Label;
                    CheckBox checkIsActive = row.FindControl("chkIsActive") as CheckBox;
                    Boolean isActive = false;
                    int id = Convert.ToInt32(labelid.Text);

                    if (checkIsActive.Checked == true)
                    {
                        isActive = true;
                    }

                    examAnswerList.Add(new DepartmentStandardList { Id = id, IsActive = isActive });
                }
                int result = bll.PublishDepartment(examAnswerList);
                if (result > 0)
                {
                    getclients();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department Published Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
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
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=DepartmentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Department List</font></td></tr>
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
            dt = bll.GetDepartmentStandardList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "DepartmentStandardName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetDepartmentStandardList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "DepartmentStandardName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}