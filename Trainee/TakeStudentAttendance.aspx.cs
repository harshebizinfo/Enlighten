using LMS.Admin.DepartmentClassFile;
using LMS.Admin.DivisionClassFile;
using LMS.Trainee.StudentAttendance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class TakeStudentAttendance : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        DivisionBLL divisionbll = new DivisionBLL();
        StudentAttendanceBLL studentAttendancebll = new StudentAttendanceBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                Calendar1.StartDate = DateTime.Today.AddDays(-2);
                Calendar1.EndDate = DateTime.Today.AddDays(2);
                btnSave.Visible = false;
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindStudentDetail();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
            }
        }
        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            binddivisionddl();
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
        protected void ddlDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindStudentDetail();
        }
        public void bindStudentDetail()
        {
            DataTable dt = new DataTable();
            dt = divisionbll.GetStudentDetailUnderDepartmentAndDivision(int.Parse(ddlDepartmentStandard.SelectedValue), int.Parse(ddlDivision.SelectedValue));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void CountryChanged(object sender, EventArgs e)
        {
            DropDownList ddlAttendance = (DropDownList)sender;
            //ViewState["Filter"] = ddlAttendance.SelectedValue;
            //this.BindGrid();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label StudentId = (Label)row.FindControl("lblid");
                Label StudentName = (Label)row.FindControl("lblStudentName");
                RadioButton rbtn1 = (row.FindControl("rbtnPresent") as RadioButton);
                RadioButton rbtn2 = (row.FindControl("rbtnAbsent") as RadioButton);
                RadioButton rbtn3 = (row.FindControl("rbtnHalfDay") as RadioButton);
                RadioButton rbtn4 = (row.FindControl("rbtnHoliday") as RadioButton);
                RadioButton rbtn5 = (row.FindControl("rbtnLeave") as RadioButton);
                if (int.Parse(ddlAttendance.SelectedValue) == 1)
                {
                    rbtn1.Checked = true;
                    rbtn2.Checked = false;
                    rbtn3.Checked = false;
                    rbtn4.Checked = false;
                    rbtn5.Checked = false;
                }
                else if (int.Parse(ddlAttendance.SelectedValue) == 2)
                {
                    rbtn1.Checked = false;
                    rbtn2.Checked = true;
                    rbtn3.Checked = false;
                    rbtn4.Checked = false;
                    rbtn5.Checked = false;
                }
                else if (int.Parse(ddlAttendance.SelectedValue) == 3)
                {
                    rbtn1.Checked = false;
                    rbtn2.Checked = false;
                    rbtn3.Checked = true;
                    rbtn4.Checked = false;
                    rbtn5.Checked = false;
                }
                else if (int.Parse(ddlAttendance.SelectedValue) == 4)
                {
                    rbtn1.Checked = false;
                    rbtn2.Checked = false;
                    rbtn3.Checked = false;
                    rbtn4.Checked = true;
                    rbtn5.Checked = false;
                }
                else if (int.Parse(ddlAttendance.SelectedValue) == 5)
                {
                    rbtn1.Checked = false;
                    rbtn2.Checked = false;
                    rbtn3.Checked = false;
                    rbtn4.Checked = false;
                    rbtn5.Checked = true;
                }
            }
            //GridView1.DataBind();
        }
        protected void txtDate_TextChanged1(object sender, EventArgs e)
        {
            btnSave.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<AddNewStudentAttendance> addNewStudentAttendance = new List<AddNewStudentAttendance>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label StudentId = (Label)row.FindControl("lblid");
                Label StudentName = (Label)row.FindControl("lblStudentName");
                RadioButton rbtn1 = (row.FindControl("rbtnPresent") as RadioButton);
                RadioButton rbtn2 = (row.FindControl("rbtnAbsent") as RadioButton);
                RadioButton rbtn3 = (row.FindControl("rbtnHalfDay") as RadioButton);
                RadioButton rbtn4 = (row.FindControl("rbtnHoliday") as RadioButton);
                RadioButton rbtn5 = (row.FindControl("rbtnLeave") as RadioButton);
                String status1="";
                if (rbtn1.Checked)
                {
                    status1 = "Present";
                }
                else if (rbtn2.Checked)
                {
                    status1 = "Absent";
                }
                else if (rbtn3.Checked)
                {
                    status1 = "Half Day";
                }
                else if (rbtn4.Checked)
                {
                    status1 = "Holiday";
                }
                else if (rbtn5.Checked)
                {
                    status1 = "Leave";
                }
                //String dateofclass1 = DateTime.Now.ToShortDateString();
                //saveattendence(rollno1, teachername1, dateofclass1, status1);
                addNewStudentAttendance.Add(
                    new AddNewStudentAttendance
                    {
                        ApplicationUserId = int.Parse(StudentId.Text),
                        StandardId = int.Parse(ddlDepartmentStandard.SelectedValue),
                        DivisionId = int.Parse(ddlDivision.SelectedValue),
                        Attandence = status1,
                        StudentName = StudentName.Text,
                        AttendanceDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null)
                    });
            }
            var result = studentAttendancebll.AddStudentAttendance(addNewStudentAttendance);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Attendance Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }
    }
}