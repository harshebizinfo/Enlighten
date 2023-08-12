using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
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

namespace LMS.Trainee
{
    public partial class CheckQuestionPaper : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        AdminBLL adminbll = new AdminBLL();
        ExamBLL exambll = new ExamBLL();
        QuestionBLL questionbll = new QuestionBLL();
        //QuestionBLL questionbll = new QuestionBLL();
        public static string optionValue = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["value"] != null)
            {
                string value = Request.QueryString["value"].ToString();
                if (value == "Sucess")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Result Saved Sucessfully!')", true);
                }
                // Request.QueryString.Remove("Sucess");
            }
            if (!IsPostBack)
            {
                binddepartmentddl();
                //bindCourseddl();
                //bindExamddl();
                //bindlearnerddl();

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
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlDepartmentStandard.SelectedValue));
            ddlSubjectCourse.DataSource = dt;
            ddlSubjectCourse.DataBind();
            ddlSubjectCourse.DataTextField = "CourseSubjectName";
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            DataTable dt = new DataTable();
            dt = questionbll.GetStudentResult(int.Parse(ddlDepartmentStandard.SelectedValue.ToString()), int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Center;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
                //e.Row.Cells[1].CssClass = "columnwidth";
                //e.Row.Cells[2].CssClass = "columnwidth";
                //e.Row.Cells[3].CssClass = "columnwidth";
                //e.Row.Cells[4].CssClass = "columnwidth";
                //e.Row.Cells[5].CssClass = "columnwidth";
            }
        }
        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = questionbll.GetStudentResult(int.Parse(ddlDepartmentStandard.SelectedValue.ToString()), int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()));
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
            //bindlearnerddl();
            bindExamddlByDepartment();
        }

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            int applicationUserId = int.Parse(gvrow.Cells[0].Text);
            int noOfAttempts = int.Parse(gvrow.Cells[4].Text);
            Session["CheckUserId"] = applicationUserId;
            Session["StandardId"] = int.Parse(ddlDepartmentStandard.SelectedValue);
            Session["SubjectId"] = int.Parse(ddlSubjectCourse.SelectedValue);
            Session["examId"] = int.Parse(ddlExam.SelectedValue);
            Session["NumberOfAttempts"] = noOfAttempts;
            // this.ModalPopupExtender1.Show();
            Response.Redirect("CheckExamQuestionPaper.aspx");
        }

        protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindExamddlByCourse();
        }
    }
}