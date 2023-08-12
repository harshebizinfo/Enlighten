using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.SubjectClassFile;
using LMS.BasicClass;

namespace LMS.Admin
{
    public partial class CourseORSubjectList : System.Web.UI.Page
    {
        CourseBLL bll = new CourseBLL();
        DeptBLL deptbll = new DeptBLL();
        SubjectBLL subjectBLL = new SubjectBLL();
        int deletingID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!IsPostBack)
            {
                getclients();
                bindaddCourseDepartmentddl();
                bindupdateCourseDepartmentddl();
                bindaddSubjectddl();
                bindupdateSubjectddl();
            }
        }
        //private DataTable socialEvents;
        private void BindGrid(string p)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetCourseSubjectList("Full");
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR Section LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        public void bindaddCourseDepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddladddept.DataSource = dt;
            ddladddept.DataBind();
            ddladddept.DataTextField = "DepartmentStandardName";
            ddladddept.DataValueField = "Id";
            ddladddept.DataBind();
            ddladddept.Items.Insert(0, new ListItem("-- Select Department / Standard --", "0"));
        }
        public void bindupdateCourseDepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlupdatedept.DataSource = dt;
            ddlupdatedept.DataBind();
            ddlupdatedept.DataTextField = "DepartmentStandardName";
            ddlupdatedept.DataValueField = "Id";
            ddlupdatedept.DataBind();
            ddlupdatedept.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindaddSubjectddl()
        {
            DataTable dt = new DataTable();
            dt = subjectBLL.GetSubjectMasterList("Active");
            ddladdCourse.DataSource = dt;
            ddladdCourse.DataBind();
            ddladdCourse.DataTextField = "SubjectName";
            ddladdCourse.DataValueField = "Id";
            ddladdCourse.DataBind();
            ddladdCourse.Items.Insert(0, new ListItem("-- Select Course / Subject --", "0"));
        }
        public void bindupdateSubjectddl()
        {
            DataTable dt = new DataTable();
            dt = subjectBLL.GetSubjectMasterList("Active");
            ddlupdateCourse.DataSource = dt;
            ddlupdateCourse.DataBind();
            ddlupdateCourse.DataTextField = "SubjectName";
            ddlupdateCourse.DataValueField = "Id";
            ddlupdateCourse.DataBind();
            ddlupdateCourse.Items.Insert(0, new ListItem("--  Course / Subject --", "0"));
        }
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = bll.GetCourseSubjectList("Full");
            GridView1.DataSource = dt;
            GridView1.DataBind();
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
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
            }
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {

                if (int.Parse(ddladddept.SelectedValue) != 0 && int.Parse(ddladdCourse.SelectedValue) != 0)
                {
                    Boolean isPublished = false;
                    if (CheckBox1.Checked == true)
                    {
                        isPublished = true;
                    }
                    // DataTable dtdepartmentstandard = new DataTable();
                    // dtdepartmentstandard = bll.GetCourseSubjectList("Full");
                    // List<string> departmentstandard = new List<string>();
                    // departmentstandard = dtdepartmentstandard.AsEnumerable()
                    //.Select(r => r.Field<string>("CourseSubjectName"))
                    //.ToList();
                    // if (!departmentstandard.Contains(txtCourseName.Text))
                    // {
                    var result = bll.AddNewCourseSubject(int.Parse(ddladdCourse.SelectedValue), ddladdCourse.SelectedItem.ToString(), int.Parse(ddladddept.SelectedValue.ToString()), isPublished);
                    if (result > 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course / Subject Registered Sucessfully')", true);
                        getclients();
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                    }
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course / Subject already in available')", true);
                    //}
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Course / Subject')", true);
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select department to delete')", true);
            }

        }
        protected void imgbtn_Click(object sender, EventArgs e)
        {
            string selectedDepartmentvalue = "";
            string selectedSubjectvalue = "";
            LinkButton btndetails = sender as LinkButton;
            string id = (btndetails.CommandArgument).ToString();
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            lblID.Text = id;
            Label labelSubjectName = gvrow.FindControl("lblSubjectname") as Label;
            Label labelboolean = gvrow.FindControl("lblIsActive") as Label;
            Label labeldepartmentname = gvrow.FindControl("lbldepartmentname") as Label;
            Boolean ischeckedvalue = labelboolean.Text == "Active" ? true : false;
            selectedSubjectvalue = labelSubjectName.Text;
            selectedDepartmentvalue = labeldepartmentname.Text;
            //ddlupdatedept.SelectedItem.Text = selectedvalue;
            ddlupdatedept.SelectedValue = ddlupdatedept.Items.FindByText(selectedDepartmentvalue).Value;
            ddlupdateCourse.SelectedValue = ddlupdateCourse.Items.FindByText(selectedSubjectvalue).Value;
            CheckBox2.Checked = ischeckedvalue;
            this.ModalPopupExtender1.Show();
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteAdminCourseId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                Boolean isPublished = false;
                if (CheckBox2.Checked == true)
                {
                    isPublished = true;
                }

                var result = bll.UpdateCourseSubject(int.Parse(lblID.Text), int.Parse(ddlupdateCourse.SelectedValue), ddlupdateCourse.SelectedItem.Value.ToString(), int.Parse(ddlupdatedept.SelectedValue), isPublished);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course / Subject Updated Sucessfully')", true);
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
                bll = null;
            }
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deleteItemId = int.Parse(lblDeleteAdminCourseId.Text);
                var result = bll.DeleteCourseSubject(deleteItemId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('course / subject Deleted Sucessfully')", true);
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

                //        var result = bll.DeleteCourseSubject(deleteid);
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
                //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('course / subject Deleted Sucessfully')", true);
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



            //try
            //{
            //    int id = int.Parse(ViewState["deletedValueId"].ToString());
            //    var result = bll.DeleteCourseSubject(id);
            //    if (result > 0)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('course / subject Deleted Sucessfully')", true);
            //        getclients();
            //    }
            //    else
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    bll = null;
            //}
        }
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<CourseSubjectList> examAnswerList = new List<CourseSubjectList>();
                foreach (GridViewRow row in GridView1.Rows)
                {
                    Label labelId = row.FindControl("lblid") as Label;
                    Label labelSubjectName = row.FindControl("lblSubjectname") as Label;
                    Label labelboolean = row.FindControl("lblIsActive") as Label;
                    Label labeldepartmentname = row.FindControl("lbldepartmentname") as Label;
                    Boolean isActive = false;
                    int id = Convert.ToInt32(labelId.Text);
                    CheckBox checkIsActive = (row.FindControl("chkIsActive") as CheckBox);

                    if (checkIsActive.Checked == true)
                    {
                        isActive = true;
                    }

                    examAnswerList.Add(new CourseSubjectList { Id = id, IsActive = isActive });
                }
                int result = bll.PublishCourseSubject(examAnswerList);
                if (result > 0)
                {
                    getclients();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Course / Subject Published Successfully')", true);
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
            string attachment = "attachment; filename=SubjectList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='6' align='center'><font size='7'>Course List</font></td></tr>
                                        <tr><td colspan='6'></td></tr></Table>";
            Response.Write(headerTable);
            Response.Write(sw.ToString());
            string footerTable = @"<Table><tr><td colspan='6'></td></tr><tr><td colspan='3' align='left'><b>Report By :</b>" + userName + "</td><td colspan='3' align='right'><b>Date :</b>" + DateTime.Now.ToString("dd-MM-yyyy") + "</td></tr></Table>";
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
            dt = bll.GetCourseSubjectList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR Section LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetCourseSubjectList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR Section LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}