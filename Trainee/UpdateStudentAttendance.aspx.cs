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
    public partial class UpdateStudentAttendance : System.Web.UI.Page
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

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    var radioList = e.Row.FindControl("rbd_join") as RadioButtonList;
            //    RadioButton rbtn1 = e.Row.FindControl("rbtnPresent") as RadioButton;
            //    RadioButton rbtn2 = e.Row.FindControl("rbtnAbsent") as RadioButton;

            //    // this will be the object that you are binding to the grid
            //    var myObject = e.Row.DataItem as DataRowView;
            //    bool isSelected = bool.Parse(myObject["is_selected"].ToString());

            //    radioList.SelectedValue = isSelected ? "1" : "0";
            //}
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

        public void bindStudentDetail()
        {
            DataTable dt = new DataTable();
            dt = studentAttendancebll.GetStudentAttendance(int.Parse(ddlDepartmentStandard.SelectedValue), int.Parse(ddlDivision.SelectedValue), DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void txtDate_TextChanged1(object sender, EventArgs e)
        {
            if ((int.Parse(ddlDepartmentStandard.SelectedValue) >= 0) && (int.Parse(ddlDivision.SelectedValue) >= 0))
            {
                btnSave.Visible = true;
                bindStudentDetail();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<AddNewStudentAttendance> addNewStudentAttendance = new List<AddNewStudentAttendance>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label attendanceId = (Label)row.FindControl("lblid");
                Label StudentId = (Label)row.FindControl("lblapplicationUserId");
                Label StudentName = (Label)row.FindControl("lblStudentName");
                RadioButton rbtn1 = (row.FindControl("rbtnPresent") as RadioButton);
                RadioButton rbtn2 = (row.FindControl("rbtnAbsent") as RadioButton);
                RadioButton rbtn3 = (row.FindControl("rbtnHalfDay") as RadioButton);
                RadioButton rbtn4 = (row.FindControl("rbtnHoliday") as RadioButton);
                RadioButton rbtn5 = (row.FindControl("rbtnLeave") as RadioButton);
                String status1 = "";
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
                        Id = int.Parse(attendanceId.Text),
                        ApplicationUserId = int.Parse(StudentId.Text),
                        StandardId = int.Parse(ddlDepartmentStandard.SelectedValue),
                        DivisionId = int.Parse(ddlDivision.SelectedValue),
                        Attandence = status1,
                        StudentName = StudentName.Text,
                        AttendanceDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null)
                    }); ;
            }
            var result = studentAttendancebll.UpdateStudentAttendance(addNewStudentAttendance);
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