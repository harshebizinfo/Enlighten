using LMS.BasicClass;
using LMS.SuperAdmin.PaymentConfigurationClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class PaymentConfiguration : System.Web.UI.Page
    {
        PCBLL pcBll = new PCBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindClientGrid();
            }
        }
        public void BindClientGrid()
        {
            DataTable dt = new DataTable();
            dt = pcBll.GetAllClientsPaymentConfiguration();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            //lblDeleteTraineeCourseId.Text = labelid.Text;
            ViewState["deletedClientUserId"] = labelid.Text;
            this.ModalPopupExtender2.Show();
        }
        protected void gridViewdriveDocument_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "filescolumnwidth";
                e.Row.Cells[2].CssClass = "filescolumnwidth";
                e.Row.Cells[3].CssClass = "filescolumnwidth";
                e.Row.Cells[4].CssClass = "filescolumnwidth";
                e.Row.Cells[5].CssClass = "filescolumnwidth";
                e.Row.Cells[6].CssClass = "filescolumnwidth";
                e.Row.Cells[7].CssClass = "filescolumnwidth";
                e.Row.Cells[8].CssClass = "filescolumnwidth";
                e.Row.Cells[9].CssClass = "filescolumnwidth";
                // e.Row.Cells[12].CssClass = "filescolumnwidth";

               
            }
        }
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["ClientPaymentConfigurationId"] = id;
            Response.Redirect("EditPaymentConfiguration.aspx");
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<ClientPaymentConfiguration> examAnswerList = new List<ClientPaymentConfiguration>();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Boolean isActive = false;
                    Label labelid = row.FindControl("lblid") as Label;
                    int clientId = int.Parse(labelid.Text);
                    CheckBox checkIsActive = (row.FindControl("chkIsActive") as CheckBox);

                    if (checkIsActive.Checked == true)
                    {
                        isActive = true;
                    }

                    examAnswerList.Add(new ClientPaymentConfiguration { Id = clientId, IsActive = isActive });
                }
                int result = pcBll.PublishClientsPaymentConfiguration(examAnswerList);
                if (result > 0)
                {
                    BindClientGrid();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration Published Successfully')", true);
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
                pcBll = null;
            }
        }
        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            List<string> deleteingId = new List<string>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Boolean isActive = false;
                Label labelid = row.FindControl("lblClientid") as Label;
                string clientId = labelid.Text;
                CheckBox checkIsActive = (row.FindControl("chkDelete") as CheckBox);

                if (checkIsActive.Checked == true)
                {
                    deleteingId.Add(clientId);
                }
            }
            if (deleteingId.Count > 0)
            {
                this.ModalPopupExtender2.Show();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Client to delete')", true);
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var clientId = ViewState["deletedClientUserId"].ToString();
                var result = pcBll.DeleteClientsPaymentConfiguration(clientId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Payment Configuration Deleted Sucessfully')", true);
                    BindClientGrid();
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
                pcBll = null;
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
            string attachment = "attachment; filename=PaymentConfigurationList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='12' align='center'><font size='7'>Payment Configuration List</font></td></tr>
                                        <tr><td colspan='12'></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(sw.ToString());
            string footerTable = @"<Table><tr><td colspan='12'></td></tr><tr><td colspan='6' align='left'><b>Report By :</b>" + userName + "</td><td colspan='6' align='right'><b>Date :</b>" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr></Table>";
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
            dt = pcBll.GetAllClientsPaymentConfiguration();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "ClientID LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }

        protected void txtSearch_TextChanged1(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = pcBll.GetAllClientsPaymentConfiguration();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "ClientID LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}