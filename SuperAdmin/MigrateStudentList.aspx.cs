using LMS.Admin.ClassFile;
using LMS.SuperAdmin.ClientClassFile;
using LMS.SuperAdmin.ServiceClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.SuperAdmin
{
    public partial class MigrateStudentList : System.Web.UI.Page
    {
        ServiceBLL serviceBLL = new ServiceBLL();
        AdminBLL adminBLL = new AdminBLL();
        ClientBLL clientBLL = new ClientBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getMigratedDetail();
                bindClientddl();
            }
        }
        public void getMigratedDetail()
        {
            DataTable dt = new DataTable();
            dt = serviceBLL.GetMigratedStudent();
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
                //e.Row.Cells[12].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "filescolumnwidth";
                e.Row.Cells[2].CssClass = "filescolumnwidth";
                e.Row.Cells[3].CssClass = "filescolumnwidth";
                e.Row.Cells[4].CssClass = "filescolumnwidth";
                e.Row.Cells[5].CssClass = "filescolumnwidth";
                // e.Row.Cells[12].CssClass = "filescolumnwidth";


            }
        }
        public void bindClientddl()
        {
            DataTable dt = new DataTable();
            dt = clientBLL.GetAllClient();
            ddlClient.DataSource = dt;
            ddlClient.DataBind();
            ddlClient.DataTextField = "InstituteName";
            ddlClient.DataValueField = "ClientID";
            ddlClient.DataBind();
            ddlClient.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = adminBLL.GetApplicationUserById(int.Parse(txtPaymentGateway.Text));
            if (dt.Rows.Count > 0)
            {
                int result = serviceBLL.AddMigratingStudent(ddlClient.SelectedValue.ToString(), txtmerchantid.Text, int.Parse(txtPaymentGateway.Text));
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Migrated Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }
            getMigratedDetail();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            txtmerchantid.Text = "";
            txtPaymentGateway.Text = "";
        }
    }
}