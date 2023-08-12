using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using LMS.Admin.LessonClassFile;
using LMS.BasicClass;
using System.IO;

namespace LMS.Admin
{
    public partial class LessonList1 : System.Web.UI.Page
    {
        LessonBLL bll = new LessonBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //BindGrid(string.Empty);
            if (!this.IsPostBack)
            {
                this.getlessons();
            }
        }

        public void getlessons()
        {
            DataTable dt = new DataTable();
            dt = bll.GetLessonList("Full");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        private void BindGrid(string p)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetLessonList("Full");
            DataView DataView = dt.DefaultView;
            DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR LessonTitle LIKE '%" + search + "%'";
            GridView1.DataSource = DataView;
            GridView1.DataBind();
            ViewState["data"] = dt;
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getlessons();
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
        protected void btnPublish_Click(object sender, EventArgs e)
        {
            try
            {
                List<LessonListDetailField> examAnswerList = new List<LessonListDetailField>();
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

                    examAnswerList.Add(new LessonListDetailField { Id = id, IsActive = isActive });
                }
                int result = bll.PublishLesson(examAnswerList);
                if (result > 0)
                {
                    getlessons();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Published Successfully')", true);
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
                CheckBox checkIsActive = (row.FindControl("chkDelete") as CheckBox);

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
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            Label labelid = gvrow.FindControl("lblid") as Label;
            lblDeleteAdminLessonId.Text = labelid.Text;
            //ViewState["deletedGroupId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int deletelessonId = int.Parse(lblDeleteAdminLessonId.Text);
                var result = bll.DeleteLesson(deletelessonId);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Lesson Deleted Sucessfully')", true);
                    getlessons();
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
                //    CheckBox checkIsActive = (row.FindControl("chkDelete") as CheckBox);

                //    if (checkIsActive.Checked == true)
                //    {

                //        var result = bll.DeleteLesson(deleteid);
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
                //    getlessons();
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
        protected void btnAddLesson_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewLesson.aspx");
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=LessonList.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='7' align='center'><font size='7'>Lesson List</font></td></tr>
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
            dt = bll.GetLessonList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%'  OR DepartmentStandardName LIKE '%" + search + "%' OR LessonTitle LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = txtSearch.Text;
            DataTable dt = new DataTable();
            dt = bll.GetLessonList("Full");
            DataView DataView = dt.DefaultView;
            if (!string.IsNullOrEmpty(search))
            {
                //DataView.RowFilter = "client_name LIKE '%" + search + "%' OR client_number LIKE '%" + search + "%'";
                DataView.RowFilter = "CourseSubjectName LIKE '%" + search + "%' OR DepartmentStandardName LIKE '%" + search + "%'  OR LessonTitle LIKE '%" + search + "%'";
            }
            GridView1.DataSource = DataView;
            GridView1.DataBind();
        }
    }
}