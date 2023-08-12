using LMS.Admin.FeeClassFile;
using LMS.Admin.TransportClassFile;
using LMS.BasicClass;
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
    public partial class FeeNameMasterList : System.Web.UI.Page
    {
        FeeBLL feeBLL = new FeeBLL();
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
            dt = feeBLL.GetFeeNameMasterList("Full");
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "FeeName LIKE '%" + search + "%' OR FeeGroupName LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeNameMasterList("Full");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "publishedcolumnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
                e.Row.Cells[8].CssClass = "columnwidth";
                e.Row.Cells[9].CssClass = "columnwidth";
                e.Row.Cells[10].CssClass = "publishedcolumnwidth";
                e.Row.Cells[11].CssClass = "columnswidth";
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
        }
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EditFeeNameMasterDetailId"] = id;
            Response.Redirect("EditFeeNameMaster.aspx");
        }

        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteTransportVehicleId.Text = labelid.Text;
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int departmentDeleteId = int.Parse(lblDeleteTransportVehicleId.Text);
                var result = feeBLL.DeleteFeeNameMaster(departmentDeleteId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Name Deleted Sucessfully')", true);
                    getclients();
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
                feeBLL = null;
            }
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<AddFeeNameMasterList> examAnswerList = new List<AddFeeNameMasterList>();
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

                    examAnswerList.Add(new AddFeeNameMasterList { Id = id, IsActive = isActive });
                }
                int result = feeBLL.PublishFeeNameMaster(examAnswerList);
                if (result > 0)
                {
                    getclients();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fee Name Published Successfully')", true);
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
                feeBLL = null;
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
            string attachment = "attachment; filename=FeeNameList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Fee Name List</font></td></tr>
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
            dt = feeBLL.GetFeeNameMasterList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FeeName LIKE '%" + search + "%' OR FeeGroupName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeNameMasterList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "FeeName LIKE '%" + search + "%' OR FeeGroupName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }

        protected void btnAddVehicle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddFeeNameMaster.aspx");
        }
    }
}