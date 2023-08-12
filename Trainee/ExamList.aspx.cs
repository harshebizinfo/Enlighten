using LMS.Admin.DepartmentClassFile;
using LMS.Trainee.BasicClass;
using LMS.Trainee.ExamClessFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class ExamList : System.Web.UI.Page
    {
        ExamBLL bll = new ExamBLL();
        DeptBLL deptbll = new DeptBLL();
        int deletingID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!IsPostBack)
            {
                binddepartmentddl();
            }
        }
        //private DataTable socialEvents;
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardUnderTraineeList("Teacher");
            ddlDepartmentStandard.DataSource = dt;
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.DataTextField = "DepartmentStandardName";
            ddlDepartmentStandard.DataValueField = "Id";
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = bll.GetExamListByDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void BindGrid(string p)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetExamListByDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR ExamName LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtDepartmentName.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Name cannot be empty')", true);
                }
                else
                {
                    Boolean isPublished = false;
                    if (CheckBox1.Checked == true)
                    {
                        isPublished = true;
                    }
                    DataTable dtdepartmentstandard = new DataTable();
                    dtdepartmentstandard = bll.GetExamList("Full");
                    List<string> departmentstandard = new List<string>();
                    departmentstandard = dtdepartmentstandard.AsEnumerable()
                   .Select(r => r.Field<string>("ExamName"))
                   .ToList();
                    if (!departmentstandard.Contains(txtDepartmentName.Text))
                    {
                        var result = bll.AddNewExam(txtDepartmentName.Text, isPublished);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Registered Sucessfully')", true);
                            getclients();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam already in available')", true);
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
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            lblID.Text = (btndetails.CommandArgument).ToString();
            //Label labelExamName = gvrow.FindControl("lblexamname") as Label;
            //Label labelIsActive = gvrow.FindControl("lblIsActive") as Label;
            Session["EditExamDetailId"] = lblID.Text;
            Response.Redirect("EditExamDeatils.aspx");
            //txtname.Text = labelExamName.Text;
            //Boolean ischeckedvalue = labelIsActive.Text == "Active" ? true : false;
            //CheckBox2.Checked = ischeckedvalue;
            //this.ModalPopupExtender1.Show();
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteTraineeExamId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtname.Text))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam cannot be empty')", true);
                }
                else
                {
                    Boolean isPublished = false;
                    if (CheckBox2.Checked == true)
                    {
                        isPublished = true;
                    }

                    var result = bll.UpdateExam(int.Parse(lblID.Text), txtname.Text, isPublished);
                    if (result > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Updated Sucessfully')", true);
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
        protected void btnaddexam_Click(object sender, EventArgs e)
        {
            Response.Redirect("ExamSettings.aspx");
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<ExamFieldList1> examAnswerList = new List<ExamFieldList1>();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Boolean isActive = false;
                    Label labelid = row.FindControl("lblid") as Label;
                    int id = Convert.ToInt32(labelid.Text);
                    CheckBox checkIsActive = (row.FindControl("chkIsActive") as CheckBox);

                    if (checkIsActive.Checked == true)
                    {
                        isActive = true;
                    }

                    examAnswerList.Add(new ExamFieldList1 { Id = id, IsActive = isActive });
                }
                int result = bll.PublishExam(examAnswerList);
                if (result > 0)
                {
                    getclients();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Published Successfully')", true);
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
        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            List<int> deleteingId = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Boolean isActive = false;
                Label labelid = row.FindControl("lblid") as Label;
                int id = Convert.ToInt32(labelid.Text);
                CheckBox checkIsActive = (row.Cells[6].FindControl("chkDelete") as CheckBox);

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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select lesson to delete')", true);
            }

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deleteid = int.Parse(lblDeleteTraineeExamId.Text);
                var result = bll.DeleteExam(deleteid);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Deleted Sucessfully')", true);
                    getclients();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }
                //int resultCount = 0;
                //foreach (GridViewRow row in GridView1.Rows)
                //{
                //    Boolean isActive = false;
                //    Label labelid = row.FindControl("lblid") as Label;
                //    int deleteid = Convert.ToInt32(labelid.Text);
                //    CheckBox checkIsActive = (row.Cells[6].FindControl("chkDelete") as CheckBox);

                //    if (checkIsActive.Checked == true)
                //    {

                //        var result = bll.DeleteExam(deleteid);
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
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Deleted Sucessfully')", true);
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
            string attachment = "attachment; filename=ExamList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='7' align='center'><font size='7'>Exam List</font></td></tr>
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
        protected void src_Click(object sender, EventArgs e)
        {

            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetExamList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR ExamName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetExamList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'  OR ExamName LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }

        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            getclients();
        }
    }
}