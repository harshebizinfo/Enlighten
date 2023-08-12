using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
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
    public partial class StudentInDepartmentList : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        AdminBLL adminBll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlDepartment.DataSource = dt;
            ddlDepartment.DataBind();
            ddlDepartment.DataTextField = "DepartmentStandardName";
            ddlDepartment.DataValueField = "Id";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void getGroups()
        {
            DataTable dt = new DataTable();
            dt = adminBll.GetLearnerDetailUnderTrainee(int.Parse(ddlDepartment.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = adminBll.GetStudentUnderDepartmentList(int.Parse(ddlDepartment.SelectedValue));
            ddlStudent.DataSource = dt;
            ddlStudent.DataBind();
            ddlStudent.DataTextField = "EmailId";
            ddlStudent.DataValueField = "ApplicationUserId";
            ddlStudent.DataBind();
            ddlStudent.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void ddlStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            getclients();
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = adminBll.GetAllDepartmentUnderStudentList(int.Parse(ddlStudent.SelectedValue));
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
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[10].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[11].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "publishedcolumnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
                e.Row.Cells[8].CssClass = "columnwidth";
                e.Row.Cells[9].CssClass = "columnwidth";
                e.Row.Cells[10].CssClass = "publishedcolumnwidth";
                e.Row.Cells[11].CssClass = "actioncolumnwidth";
                //e.Row.Cells[1].CssClass = "columnwidth";
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
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["EditLearnerInDepartmentId"] = id;
            Response.Redirect("EditLearnerInDepartment.aspx");
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
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int departmentDeleteId = int.Parse(lblDeleteAdminDepartmentId.Text);
                var result = adminBll.DeleteMappingApplicationUserIdAndDepartmentStandard(departmentDeleteId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student from Standard Deleted Sucessfully')", true);
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
                adminBll = null;
            }
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<AddStudentInDepartment> examAnswerList = new List<AddStudentInDepartment>();
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

                    examAnswerList.Add(new AddStudentInDepartment { Id = id, IsActive = isActive });
                }
                int result = adminBll.PublishMappingApplicationUserIdAndDepartmentStandard(examAnswerList);
                if (result > 0)
                {
                    getclients();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student in Standard Published Successfully')", true);
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
                adminBll = null;
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
            string attachment = "attachment; filename=StudentInDepartmentList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Student In Department List</font></td></tr>
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLearnerInDepartment.aspx");
        }
    }
}