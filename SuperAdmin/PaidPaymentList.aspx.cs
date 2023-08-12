using LMS.SuperAdmin.ClientClassFile;
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
    public partial class PaidPaymentList : System.Web.UI.Page
    {
        ClientBLL clientBll = new ClientBLL();
        PCBLL pcBLL = new PCBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // bindClient();
                BindClientsFeeTransaction();
            }
        }
        //public void bindClient()
        //{
        //    DataTable dt = new DataTable();
        //    dt = clientBll.GetAllClient();
        //    ddlClient.DataSource = dt;
        //    ddlClient.DataBind();
        //    ddlClient.DataTextField = "ClientName";
        //    ddlClient.DataValueField = "DatabaseName";
        //    ddlClient.DataBind();
        //    ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[2].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[3].CssClass = "publishedcolumnwidth";
                //e.Row.Cells[4].CssClass = "publishedcolumnwidth";

            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindClientsFeeTransaction();
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=PaidPaymentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Paid Fee List</font></td></tr>
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
        public void BindClientsFeeTransaction()
        {
            DataTable dt = new DataTable();
            dt = pcBLL.GetFeeTransactionBySuperAdmin();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void src_Click(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = pcBLL.GetFeeTransactionBySuperAdmin();
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                DataView.RowFilter = "InstituteName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                DateTime fromdate = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
                DataTable dt = new DataTable();
                dt = pcBLL.GetFeeTransactionBySuperAdmin();
                DataView DataView = dt.DefaultView;
                DataView.RowFilter = "CreatedOn > #" + fromdate + "#";
                GridView1.DataSource = DataView;
                GridView1.DataBind();
            }
            else
            {
                BindClientsFeeTransaction();
            }
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TextBox2.Text))
            {
                DateTime todate = DateTime.ParseExact(TextBox2.Text, "dd/MM/yyyy", null);
                DataTable dt = new DataTable();
                dt = pcBLL.GetFeeTransactionBySuperAdmin();
                DataView DataView = dt.DefaultView;
                DataView.RowFilter = "CreatedOn < #" + todate + "#";
                GridView1.DataSource = DataView;
                GridView1.DataBind();
            }
            else
            {
                BindClientsFeeTransaction();
            }
        }
    }
}