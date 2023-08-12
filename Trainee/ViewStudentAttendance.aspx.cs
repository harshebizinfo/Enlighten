﻿using LMS.Admin.DepartmentClassFile;
using LMS.Admin.DivisionClassFile;
using LMS.Trainee.StudentAttendance;
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
    public partial class ViewStudentAttendance : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        DivisionBLL divisionbll = new DivisionBLL();
        StudentAttendanceBLL studentAttendancebll = new StudentAttendanceBLL();
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
            dt = deptbll.GetDepartmentStandardUnderTraineeList("Teacher");
            ddlDepartmentStandard.DataSource = dt;
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.DataTextField = "DepartmentStandardName";
            ddlDepartmentStandard.DataValueField = "Id";
            ddlDepartmentStandard.DataBind();
            ddlDepartmentStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            binddivisionddl();
            //bindStudentDetailGridByStandard();
        }
        public void bindStudentDetailGridByMonthId()
        {
            DataTable newdt = new DataTable();
            newdt.Columns.Clear();
            newdt = null;
            GridView1.Columns.Clear();
            
            GridView1.DataSource = newdt;
            GridView1.DataBind();
            


            int year = DateTime.Now.Year;
            DataTable dt = new DataTable();
            dt.Columns.Clear();
            dt = studentAttendancebll.GetAllStudentAttendanceByMonth(int.Parse(ddlDepartmentStandard.SelectedValue), int.Parse(ddlDivision.SelectedValue), int.Parse(ddlMonth.SelectedValue), year);
            int count = 0;
            foreach (DataColumn col in dt.Columns)
            {
                count = count + 1;
                BoundField bField = new BoundField();
                bField.DataField = col.ColumnName;
                var columnName = col.ColumnName;
                var updatedColumnName = "";
                if(count>2)
                {
                    string stringAfterChar = columnName.Substring(3);
                    updatedColumnName = stringAfterChar;
                }
                else
                {
                    updatedColumnName = col.ColumnName;
                }
                bField.HeaderText = updatedColumnName;
                GridView1.Columns.Add(bField);
            }
            GridView1.DataSource = dt;
            //Bind the datatable with the GridView.
            GridView1.DataBind();
        }
       
        public void binddivisionddl()
        {
            DataTable dt = new DataTable();
            dt = divisionbll.GetDivisionUnderDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
            ddlDivision.DataSource = dt;
            ddlDivision.DataBind();
            ddlDivision.DataTextField = "Section";
            ddlDivision.DataValueField = "Id";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            PrepareGridViewForExport(GridView1);
            ExportGridView();
        }
        private void ExportGridView()
        {
            var userName = Session["FirstAndLastName"].ToString();
            string attachment = "attachment; filename=StudentAttendance.xls";
            Response.ClearContent();
            Response.AddHeader("content-disposition", attachment);
            Response.ContentType = "application/ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            string headerTable = @"<Table><tr><td colspan='5' align='center'><font size='7'>Student Attendance List</font></td></tr>
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = null;
            GridView1.DataSource = dt;
            GridView1.DataBind();
            bindStudentDetailGridByMonthId();
        }
    }
}