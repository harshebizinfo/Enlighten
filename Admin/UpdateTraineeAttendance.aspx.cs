using LMS.Admin.TraineeAttendance;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class UpdateTraineeAttendance : System.Web.UI.Page
    {
        TraineeAttendanceBLL traineeAttendancebll = new TraineeAttendanceBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //bindTraineeDetail();
                Calendar1.StartDate = DateTime.Today.AddDays(-2);
                Calendar1.EndDate = DateTime.Today.AddDays(2);
                btnSave.Visible = false;
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindTraineeDetail();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
            }
        }
        public void bindTraineeDetail()
        {
            DataTable dt = new DataTable();
            dt = traineeAttendancebll.GetTraineeAttendance(DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void txtDate_TextChanged1(object sender, EventArgs e)
        {
                btnSave.Visible = true;
                bindTraineeDetail();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<AddNewTraineeAttendance> addNewStudentAttendance = new List<AddNewTraineeAttendance>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Label attendanceId = (Label)row.FindControl("lblid");
                Label TraineeId = (Label)row.FindControl("lblapplicationUserId");
                Label TraineeName = (Label)row.FindControl("lblTraineeName");
                Label TraineeEmail = (Label)row.FindControl("lblTraineeEmail");
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
                    new AddNewTraineeAttendance
                    {
                        Id = int.Parse(attendanceId.Text),
                        ApplicationUserId = int.Parse(TraineeId.Text),
                        TraineeName = TraineeName.Text,
                        TraineeEmail = TraineeEmail.Text,
                        Attandence = status1,
                        AttendanceDate = DateTime.ParseExact(txtDate.Text, "dd/MM/yyyy", null)
                    }); ;
            }
            var result = traineeAttendancebll.UpdateTraineeAttendance(addNewStudentAttendance);
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