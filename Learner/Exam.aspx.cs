using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Learner.BasicClass;
using LMS.Trainee.BasicClass;
using LMS.Trainee.ExamClessFile;
using LMS.Trainee.QuestionClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Exam : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        ExamBLL exambll = new ExamBLL();
        QuestionBLL questionbll = new QuestionBLL();
        public static string optionValue = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["value"] != null)
            {
                string value = Request.QueryString["value"].ToString();
                if (value == "Sucess")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Done Sucessfully!')", true);
                }
                if (value == "TimeOut")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry exam Timeout!')", true);
                }
            }
            if (!IsPostBack)
            {
                //binddepartmentddl();
                bindCourseddl();
               // bindExamddl();
            }
        }
        //public void binddepartmentddl()
        //{
        //    DataTable dt = new DataTable();
        //    dt = deptbll.GetDepartmentStandardList("Active");
        //    ddlDepartmentStandard.DataSource = dt;
        //    ddlDepartmentStandard.DataBind();
        //    ddlDepartmentStandard.DataTextField = "DepartmentStandardName";
        //    ddlDepartmentStandard.DataValueField = "Id";
        //    ddlDepartmentStandard.DataBind();
        //    ddlDepartmentStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseSubjectListOfLearner();
            ddlSubjectCourse.DataSource = dt;
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.DataTextField = "CourseSubjectName";
            ddlSubjectCourse.DataValueField = "Id";
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
            ViewState["departmentStandardId"] = int.Parse(dt.Rows[0]["DepartmentStandardID"].ToString());
        }
        public void bindExamddlByCourse()
        {
            DataTable dt = new DataTable();
            dt = exambll.GetExamListByCourseId(int.Parse(ddlSubjectCourse.SelectedValue));
            ddlExam.DataSource = dt;
            ddlExam.DataBind();
            ddlExam.DataTextField = "ExamName";
            ddlExam.DataValueField = "Id";
            ddlExam.DataBind();
            ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        //public void bindExamddl()
        //{
        //    DataTable dt = new DataTable();
        //    dt = exambll.GetExamList("Active");
        //    ddlExam.DataSource = dt;
        //    ddlExam.DataBind();
        //    ddlExam.DataTextField = "ExamName";
        //    ddlExam.DataValueField = "Id";
        //    ddlExam.DataBind();
        //    ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}

        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            DataTable examdt = new DataTable();
            examdt = exambll.GetExamDetailByID(int.Parse(ddlExam.SelectedValue));
            DataTable departmentdt = new DataTable();
            departmentdt = deptbll.GetDepartmentStandardUnderTraineeList("Learner");
            var departmentName = departmentdt.Rows[0]["DepartmentStandardName"].ToString();
            DataTable numberOfAttempts = new DataTable();
            int numberOfExamAttempts = 0;
            int departmentId = int.Parse(ViewState["departmentStandardId"].ToString());
            var startDate = DateTime.Parse(examdt.Rows[0]["ExamStartDateTime"].ToString());
            var endDate = DateTime.Parse(examdt.Rows[0]["ExamEndDateTime"].ToString()).AddDays(1);
            var currentDate = DateTime.Now;
            if (startDate <= currentDate && currentDate <= endDate)
            {
                numberOfAttempts = questionbll.GetNumberOfExamAttemptsList(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
                var abc = numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString();
                if (numberOfAttempts.Rows.Count > 0 && abc != "")
                {
                    numberOfExamAttempts = int.Parse(numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString());
                    if (numberOfExamAttempts < int.Parse(System.Configuration.ConfigurationManager.AppSettings["NumberOfAttempts"]))
                    {
                        numberOfExamAttempts = 0;
                        Session["NumberOfExamAttempts"] = 0;
                        DataTable dt = new DataTable();
                        dt = questionbll.GetAllotedExamAnswerLogList(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts);
                        if (dt.Rows.Count > 0)
                        {
                            DataTable examtimedt = new DataTable();
                            examtimedt = exambll.GetExamCoveredTime(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts);
                            DateTime examStartDateTime = DateTime.Parse(examtimedt.Rows[0]["ExamStartDateTime"].ToString());
                            DateTime examEndDateTime = DateTime.Parse(examtimedt.Rows[0]["ExamEndDateTime"].ToString());
                            int minutescovered = 0;
                            int secondscovered = 0;
                            DateTime currentDateTime = DateTime.Now;
                            if (currentDateTime.Ticks > examStartDateTime.Ticks && currentDateTime.Ticks < examEndDateTime.Ticks)
                            {
                                // targetDt is in between d1 and d2
                                TimeSpan span = examEndDateTime.Subtract(currentDateTime);
                                int minutesPending = (int)span.TotalMinutes;
                                if (examtimedt.Rows.Count > 0)
                                {
                                    minutescovered = minutesPending;
                                    secondscovered = int.Parse(examtimedt.Rows[0]["TimeCoveredInSecond"].ToString());
                                }
                                else
                                {
                                    minutescovered = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                                }
                                //Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
                                Session["DepartmentStandard"] = departmentName;
                                Session["CourseSubject"] = ddlSubjectCourse.SelectedItem.Text;
                                Session["Exam"] = ddlExam.SelectedItem.Text;
                                Session["DepartmentStandardId"] = departmentId;
                                Session["CourseSubjectId"] = ddlSubjectCourse.SelectedValue;
                                Session["ExamId"] = ddlExam.SelectedValue;
                                Session["UserName"] = Session["UserName"].ToString();
                                Session["DurationInMinutes"] = minutescovered;
                                Session["Minutes"] = int.Parse(Session["DurationInMinutes"].ToString());
                                Session["Second"] = secondscovered;
                                if (minutescovered > 0)
                                {
                                    Response.Redirect("QuestionPaper.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry your exam duration has been finished')", true);
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry your exam duration has been finished')", true);
                            }
                            
                        }
                        else
                        {
                            DataTable questiondt = new DataTable();
                            questiondt = questionbll.GetQuestionList(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), true);
                            List<Question> questionList = new List<Question>();
                            //questionList = questiondt;
                            questionList = (from DataRow dr in questiondt.Rows
                                            select new Question()
                                            {
                                                Id = int.Parse(dr["Id"].ToString()),
                                                ExamId = int.Parse(dr["ExamId"].ToString()),
                                                DepartmentStandardId = int.Parse(dr["DepartmentStandardId"].ToString()),
                                                CourseSubjectId = int.Parse(dr["CourseSubjectId"].ToString()),
                                            }).ToList();
                            var result = questionbll.AddNewAllotedQuestionExamAnswerLog(questionList, numberOfExamAttempts);
                            if (result > 0)
                            {
                                DateTime statDateTime = DateTime.Now;
                                int durationOfExam = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                                DateTime endExamDateTime = DateTime.Now.AddMinutes(durationOfExam);
                                var examTime = exambll.AddNewExamCoveredTime(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts, 0, 0, statDateTime, endExamDateTime);
                               
                                //Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
                                if (examTime > 0)
                                {
                                    Session["DepartmentStandard"] = departmentName;
                                    Session["CourseSubject"] = ddlSubjectCourse.SelectedItem.Text;
                                    Session["Exam"] = ddlExam.SelectedItem.Text;
                                    Session["DepartmentStandardId"] = departmentId;
                                    Session["CourseSubjectId"] = ddlSubjectCourse.SelectedValue;
                                    Session["ExamId"] = ddlExam.SelectedValue;
                                    Session["UserName"] = Session["UserName"].ToString();
                                    Session["DurationInMinutes"] = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                                    Session["Minutes"] = int.Parse(Session["DurationInMinutes"].ToString());
                                    Session["Second"] = 0;
                                    Response.Redirect("QuestionPaper.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                                }
                                //string s = "window.open('" + url + "', 'popup_window', 'width=100%,height=100%,resizable=yes');";
                                //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Number of attempts is not available')", true);
                    }
                }
                else
                {
                    Session["NumberOfExamAttempts"] = numberOfExamAttempts;
                    DataTable dt = new DataTable();
                    dt = questionbll.GetAllotedExamAnswerLogList(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts);
                    if (dt.Rows.Count > 0)
                    {
                        DataTable examtimedt = new DataTable();
                        examtimedt = exambll.GetExamCoveredTime(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts);
                        DateTime examStartDateTime = DateTime.Parse(examtimedt.Rows[0]["ExamStartDateTime"].ToString());
                        DateTime examEndDateTime = DateTime.Parse(examtimedt.Rows[0]["ExamEndDateTime"].ToString());
                        int minutescovered = 0;
                        int secondscovered = 0;
                        DateTime currentDateTime = DateTime.Now;
                        if (currentDateTime.Ticks > examStartDateTime.Ticks && currentDateTime.Ticks < examEndDateTime.Ticks)
                        {
                            // targetDt is in between d1 and d2
                            TimeSpan span = examEndDateTime.Subtract(currentDateTime);
                            int minutesPending = (int)span.TotalMinutes;
                            if (examtimedt.Rows.Count > 0)
                            {
                                minutescovered = minutesPending;
                                secondscovered = int.Parse(examtimedt.Rows[0]["TimeCoveredInSecond"].ToString());
                            }
                            else
                            {
                                minutescovered = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                            }
                            //Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
                            Session["DepartmentStandard"] = departmentName;
                            Session["CourseSubject"] = ddlSubjectCourse.SelectedItem.Text;
                            Session["Exam"] = ddlExam.SelectedItem.Text;
                            Session["DepartmentStandardId"] = departmentId;
                            Session["CourseSubjectId"] = ddlSubjectCourse.SelectedValue;
                            Session["ExamId"] = ddlExam.SelectedValue;
                            Session["UserName"] = Session["UserName"].ToString();
                            Session["DurationInMinutes"] = minutescovered;
                            Session["Minutes"] = int.Parse(Session["DurationInMinutes"].ToString());
                            Session["Second"] = 0;
                            if (minutescovered > 0)
                            {
                                Response.Redirect("QuestionPaper.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry your exam duration has been finished')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry your exam duration has been finished')", true);
                        }

                    }
                    else
                    {
                        DataTable questiondt = new DataTable();
                        questiondt = questionbll.GetQuestionList(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), true);
                        List<Question> questionList = new List<Question>();
                        //questionList = questiondt;
                        questionList = (from DataRow dr in questiondt.Rows
                                        select new Question()
                                        {
                                            Id = int.Parse(dr["Id"].ToString()),
                                            ExamId = int.Parse(dr["ExamId"].ToString()),
                                            DepartmentStandardId = int.Parse(dr["DepartmentStandardId"].ToString()),
                                            CourseSubjectId = int.Parse(dr["CourseSubjectId"].ToString()),
                                        }).ToList();
                        var result = questionbll.AddNewAllotedQuestionExamAnswerLog(questionList, numberOfExamAttempts);
                        if (result > 0)
                        {

                            DateTime statDateTime = DateTime.Now;
                            int durationOfExam = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                            DateTime endExamDateTime = DateTime.Now.AddMinutes(durationOfExam);
                            var examTime = exambll.AddNewExamCoveredTime(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), numberOfExamAttempts, 0, 0, statDateTime, endExamDateTime);
                            if (examTime > 0)
                            {
                                //Response.Write("<script type='text/javascript'>window.open('" + url + "');</script>");
                                Session["DepartmentStandard"] = departmentName;
                                Session["CourseSubject"] = ddlSubjectCourse.SelectedItem.Text;
                                Session["Exam"] = ddlExam.SelectedItem.Text;
                                Session["DepartmentStandardId"] = departmentId;
                                Session["CourseSubjectId"] = ddlSubjectCourse.SelectedValue;
                                Session["ExamId"] = ddlExam.SelectedValue;
                                Session["UserName"] = Session["UserName"].ToString();
                                Session["DurationInMinutes"] = int.Parse(examdt.Rows[0]["DurationInMinutes"].ToString());
                                Session["Minutes"] = int.Parse(Session["DurationInMinutes"].ToString());
                                Session["Second"] = 0;
                                Response.Redirect("QuestionPaper.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                }
            }
            else
            {
                if (currentDate <= startDate)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Still exam is not started')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry you are late for exam')", true);
                }

            }
        }

        protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindExamddlByCourse();
            int departmentId = int.Parse(ViewState["departmentStandardId"].ToString());
            DataTable IsChecked = new DataTable();
            IsChecked = questionbll.GetNumberOfExamAttemptsIsChecked(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
            Boolean isCheckedValue = IsChecked.Rows.Count == 0 ? false : Boolean.Parse(IsChecked.Rows[IsChecked.Rows.Count - 1]["IsChecked"].ToString());
            if (IsChecked.Rows.Count != 0)
            {
                if (isCheckedValue == false)
                {
                    btnStartExam.Enabled = false;
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Sorry you are not having more Attempts')", true);
                }
            }

            List<NumberOfAttempts> noOfAttempts = new List<NumberOfAttempts>();
            DataTable numberOfAttempts = new DataTable();
            numberOfAttempts = questionbll.GetNumberOfExamAttemptsListByApplicationUserId(departmentId, int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
            int _numberOfRecords = 0;
            if (numberOfAttempts.Rows.Count > 0)
            {
                foreach (DataRow item in numberOfAttempts.Rows)
                {
                    _numberOfRecords += 1;
                    DateTime passexpiredate = DateTime.Parse(item["CreatedOn"].ToString());
                    noOfAttempts.Add(new NumberOfAttempts { NoOfAttempts = _numberOfRecords + " Attempts", CreatedOn = passexpiredate.ToString("dd-MMM-yyyy") });
                }
            }
            GridView1.DataSource = noOfAttempts;
            GridView1.DataBind();

        }
    }
}