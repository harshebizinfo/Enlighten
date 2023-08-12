using LMS.SuperAdmin.ClientClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.HelpAndSupport
{
    public partial class PendingIssueList : System.Web.UI.Page
    {
        ClientBLL clientBLL = new ClientBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindClientddl();
            }
        }
        public void bindClientddl()
        {
            DataTable dt = new DataTable();
            dt = clientBLL.GetAllClient();
            ddlClient.DataSource = dt;
            ddlClient.DataBind();
            ddlClient.DataTextField = "ClientID";
            ddlClient.DataValueField = "Id";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("Select Client", "0"));
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
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "singleValuecolumnwidth";
                e.Row.Cells[2].CssClass = "singleValuecolumnwidth";
                e.Row.Cells[3].CssClass = "filescolumnwidth";
                e.Row.Cells[4].CssClass = "emailActioncolumnwidth";
                e.Row.Cells[5].CssClass = "filescolumnwidth";
                e.Row.Cells[6].CssClass = "filescolumnwidth";
                e.Row.Cells[7].CssClass = "filescolumnwidth";
                e.Row.Cells[8].CssClass = "filescolumnwidth";
                e.Row.Cells[9].CssClass = "singleValuecolumnwidth";
                e.Row.Cells[10].CssClass = "singleValuecolumnwidth";
                e.Row.Cells[11].CssClass = "Actioncolumnwidth";
                // e.Row.Cells[12].CssClass = "filescolumnwidth";

            }
        }
    }
}