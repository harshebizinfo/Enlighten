using LMS.Trainee.ExamClessFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class EditExamDeatils : System.Web.UI.Page
    {
        ExamBLL examBLL = new ExamBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = new DataTable();
                int examId = int.Parse(Session["EditExamDetailId"].ToString());
                dt = examBLL.GetExamDetailByID(examId);
                if(dt.Rows.Count>0)
                {
                    txtExamName.Text = dt.Rows[0]["ExamName"].ToString();
                    txtstartDatetime.Text= Convert.ToDateTime(dt.Rows[0]["ExamStartDateTime"]).ToString("dd/MM/yyyy");
                    txtEndDatetime.Text = Convert.ToDateTime(dt.Rows[0]["ExamEndDateTime"]).ToString("dd/MM/yyyy");
                    txtTotalMarks.Text = dt.Rows[0]["TotalMarks"].ToString();
                    txtnumberofQuestion.Text = dt.Rows[0]["NumberOfQuestion"].ToString();
                    txtDuration.Text = dt.Rows[0]["DurationInMinutes"].ToString();
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int examId = int.Parse(Session["EditExamDetailId"].ToString());
            if (string.IsNullOrWhiteSpace(txtstartDatetime.Text) || string.IsNullOrWhiteSpace(txtEndDatetime.Text) || string.IsNullOrWhiteSpace(txtTotalMarks.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill all the details')", true);
            }
            else
            {
                DateTime startdate, endDate;
                startdate = DateTime.ParseExact(txtstartDatetime.Text, "dd/MM/yyyy", null);//DateTime.Parse(txtstartDatetime.Text);
                endDate = DateTime.ParseExact(txtEndDatetime.Text, "dd/MM/yyyy", null);//DateTime.Parse(txtEndDatetime.Text);
                int datevalue = DateTime.Compare(startdate, endDate);
                if (endDate > startdate)
                            {
                               
                               var result = examBLL.UpdateExamSetting(false,"", 0, 0, int.Parse(txtTotalMarks.Text), startdate, endDate, examId, int.Parse(txtnumberofQuestion.Text), int.Parse(txtDuration.Text));
                               if (result > 0)
                               {
                                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Updated Sucessfully')", true);
                                  
                                   //bindExamddl();
                                   txtTotalMarks.Text = "";
                                   txtstartDatetime.Text = "";
                                   txtEndDatetime.Text = "";
                               }
                               else
                               {
                                   ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                               }
                               
                            }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select End date greater than start date')", true);
                } 
            }
        }
    }
}