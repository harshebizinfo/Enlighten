using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.BasicClass;
using LMS.Learner.ComplaintClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class ComplaintList : System.Web.UI.Page
    {
        ComplaintBLL bll = new ComplaintBLL();
        AdminBLL adminBLL = new AdminBLL();
        DeptBLL deptBLL = new DeptBLL();
        int deletingID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!IsPostBack)
            {
                var updatedBy = Convert.ToString(System.Web.HttpContext.Current.Session["ApplicationUserId"]);
                DataTable userdt = new DataTable();
                userdt = adminBLL.GetApplicationUserById(int.Parse(updatedBy));
                if(userdt.Rows.Count>0)
                {
                    Session["AdmissionNumber"] = userdt.Rows[0]["StudentInformationId"].ToString();
                }
                getclients();

            }
        }
        //private DataTable socialEvents;
        private void BindGrid(string p)
        {
           
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetComplaintListByAdmissionNumber("Full");
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "Complaint LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void getclients()
        {
            string admissionNo = Session["AdmissionNumber"].ToString();
            DataTable dt = new DataTable();
            dt = bll.GetComplaintListByAdmissionNumber(admissionNo);
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
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Complaint cannot be empty')", true);
                }
                else
                {
                    DataTable dt = new DataTable();
                    ComplaintListModel cl = new ComplaintListModel();
                    dt = deptBLL.GetStudentInformationListByApplicationUserId();
                    if(dt.Rows.Count>0)
                    {
                        cl.StreamId = int.Parse(dt.Rows[0]["StreamId"].ToString());
                        cl.ClassId = int.Parse(dt.Rows[0]["ClassId"].ToString());
                        cl.SectionId = int.Parse(dt.Rows[0]["SectionId"].ToString());
                    }
                    cl.AdmissionNumber = Session["AdmissionNumber"].ToString();
                    cl.Complaint = txtDepartmentName.Text;
                        var result = bll.AddNewComplaint(cl);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Complaint Registered Sucessfully')", true);
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
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            Session["id"] = id;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            //Label lbl_p = gvr.FindControl("lbl_phone") as Label;
            Label labelName = gvrow.FindControl("lbldepartmentname") as Label;
            string name = labelName.Text;
            lblID.Text = id;
            txtname.Text = name;
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtname.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert(' Complaint cannot be empty')", true);
                }
                else
                {
                    ComplaintListModel cl = new ComplaintListModel();
                    cl.Id = int.Parse(lblID.Text);
                    cl.Complaint = txtname.Text;
                    var result = bll.UpdateComplaint(cl);
                    if (result > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Complaint Updated Sucessfully')", true);
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
                var result = bll.DeleteComplaint(departmentDeleteId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Complaint Deleted Sucessfully')", true);
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
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Complaint List</font></td></tr>
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
            string admissionNo = Session["AdmissionNumber"].ToString();
            DataTable dt = new DataTable();
            dt = bll.GetComplaintListByAdmissionNumber(admissionNo);
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Complaint LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            string admissionNo = Session["AdmissionNumber"].ToString();
            DataTable dt = new DataTable();
            dt = bll.GetComplaintListByAdmissionNumber(admissionNo);
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "Complaint LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}