using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Trainee.ExamClessFile;
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
    public partial class DeleteQuestionLog : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        AdminBLL adminbll = new AdminBLL();
        ExamBLL exambll = new ExamBLL();
        QuestionBLL questionbll = new QuestionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                //bindCourseddl();
                //bindExamddl();
                //bindlearnerddl();
               
            }
            btnSave.Visible = false;
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
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlDepartmentStandard.SelectedValue));
            ddlSubjectCourse.DataSource = dt;
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.DataTextField = "SubjectName";
            ddlSubjectCourse.DataValueField = "Id";
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindExamddlByDepartment()
        {
            DataTable dt = new DataTable();
            dt = exambll.GetExamListByDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
            ddlExam.DataSource = dt;
            ddlExam.DataBind();
            ddlExam.DataTextField = "ExamName";
            ddlExam.DataValueField = "Id";
            ddlExam.DataBind();
            ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
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
        public void bindlearnerddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetLearnerDetailUnderTraineebyDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
            ddlLearner.DataSource = dt;
            ddlLearner.DataBind();
            ddlLearner.DataTextField = "EmailId";
            ddlLearner.DataValueField = "ApplicationUserId";
            ddlLearner.DataBind();
            ddlLearner.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
            bindlearnerddl();
            bindExamddlByDepartment();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            bindQuestionLog();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[6].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[8].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[9].HorizontalAlign = HorizontalAlign.Left;
                //e.Row.Cells[1].CssClass = "columnwidth";
                //e.Row.Cells[2].CssClass = "columnwidth";
                //e.Row.Cells[3].CssClass = "columnwidth";
                //e.Row.Cells[4].CssClass = "columnwidth";
                //e.Row.Cells[5].CssClass = "columnwidth";
                //e.Row.Cells[6].CssClass = "columnwidth";
                //e.Row.Cells[7].CssClass = "columnwidth";
                //e.Row.Cells[8].CssClass = "columnwidth";
                //e.Row.Cells[9].CssClass = "columnwidth";
            }
        }
        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            
            btnSave.Visible = true;
            bindQuestionLog();
        }
        public void bindQuestionLog()
        {
            int departmentId = int.Parse(ddlDepartmentStandard.SelectedValue);
            int subjectId = int.Parse(ddlSubjectCourse.SelectedValue);
            int examId = int.Parse(ddlExam.SelectedValue);
            int userId = int.Parse(ddlLearner.SelectedValue);
            DataTable dt = new DataTable();
            dt = questionbll.GETLearnerExamAnswerLog(departmentId, subjectId, examId, userId);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int departmentId = int.Parse(ddlDepartmentStandard.SelectedValue);
            int subjectId = int.Parse(ddlSubjectCourse.SelectedValue);
            int examId = int.Parse(ddlExam.SelectedValue);
            int userId = int.Parse(ddlLearner.SelectedValue);
            var result=questionbll.DeleteLearnerExamAnswerLog(departmentId, subjectId, examId, userId,int.Parse(txtAttemptsNumber.Text));
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Question deleted sucessfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
            bindQuestionLog();
        }

        protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindExamddlByCourse();
        }
    }
}