using LMS.Trainee.BasicClass;
using LMS.Trainee.QuestionClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class CheckExamPaper : System.Web.UI.Page
    {
        QuestionBLL questionbll = new QuestionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int departmentId = int.Parse(Session["StandardId"].ToString());
                int subjectId = int.Parse(Session["SubjectId"].ToString());
                int examId = int.Parse(Session["examId"].ToString());
                int userId = int.Parse(Session["CheckUserId"].ToString());
                int numberOfAttempts = int.Parse(Session["NumberOfAttempts"].ToString());
                DataTable dt = new DataTable();
                dt = questionbll.GETLearnerAnswer(departmentId, subjectId, examId, userId, numberOfAttempts);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int totalMarks = 0;
            int departmentId = int.Parse(Session["StandardId"].ToString());
            int subjectId = int.Parse(Session["SubjectId"].ToString());
            int examId = int.Parse(Session["examId"].ToString());
            int userId = int.Parse(Session["CheckUserId"].ToString());
            int numberOfAttempts = 0;
            List<ExamAnswer> examAnswerList = new List<ExamAnswer>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                int rollno1 = Convert.ToInt32(row.Cells[0].Text);
                TextBox txtMarksValue = (row.Cells[5].FindControl("txtMarks") as TextBox);

                int marks = int.Parse(txtMarksValue.Text);
                totalMarks += marks;
                numberOfAttempts = Convert.ToInt32(row.Cells[6].Text);
                examAnswerList.Add(new ExamAnswer { ExamAnswerId = rollno1, Marks = marks });
            }
            int result = questionbll.UpdateLearnerMarks(examAnswerList);
            int updatedcheckedId = questionbll.UpdateNumberOfExamAttemptsIsChecked(departmentId, subjectId, examId, userId, numberOfAttempts);
            if (result > 0)
            {
                int totalObtainedMarks = questionbll.UpdateStudentResultTotalMarks(departmentId,subjectId,examId,userId, numberOfAttempts, totalMarks);
                if (totalObtainedMarks > 0)
                {
                    Session["CheckUserId"] = "";
                    Session["StandardId"] = "";
                    Session["SubjectId"] = "";
                    Session["examId"] = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
                    Response.Redirect("CheckQuestionPaper.aspx");
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
            }
        }
    }
}