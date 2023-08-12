using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
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
    public partial class ExamSettings : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        ExamBLL bll = new ExamBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                // bindCourseddl();
                //bindExamddl();
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
        //public void bindExamddlByDepartment()
        //{
        //    DataTable dt = new DataTable();
        //    dt = bll.GetExamListByDepartmentId(int.Parse(ddlDepartmentStandard.SelectedValue));
        //    ddlExam.DataSource = dt;
        //    ddlExam.DataBind();
        //    ddlExam.DataTextField = "ExamName";
        //    ddlExam.DataValueField = "Id";
        //    ddlExam.DataBind();
        //    ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        //public void bindExamddlByCourse()
        //{
        //    DataTable dt = new DataTable();
        //    dt = bll.GetExamListByCourseId(int.Parse(ddlSubjectCourse.SelectedValue));
        //    ddlExam.DataSource = dt;
        //    ddlExam.DataBind();
        //    ddlExam.DataTextField = "ExamName";
        //    ddlExam.DataValueField = "Id";
        //    ddlExam.DataBind();
        //    ddlExam.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtstartDatetime.Text) || string.IsNullOrWhiteSpace(txtEndDatetime.Text) || string.IsNullOrWhiteSpace(txtTotalMarks.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Fill all the details')", true);
            }
            else
            {
                if (int.Parse(ddlDepartmentStandard.SelectedValue) == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Department / Standard')", true);
                }
                else
                {
                    if (int.Parse(ddlSubjectCourse.SelectedValue) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Subject / Course')", true);
                    }
                    else
                    {
                        if (string.IsNullOrWhiteSpace(txtExamName.Text))
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Provide Exam Name')", true);
                        }
                        else
                        {
                            DateTime startdate, endDate;
                            startdate = DateTime.ParseExact(txtstartDatetime.Text, "dd/MM/yyyy", null);//DateTime.Parse(txtstartDatetime.Text);
                            endDate = DateTime.ParseExact(txtEndDatetime.Text, "dd/MM/yyyy", null);//DateTime.Parse(txtEndDatetime.Text);
                            int datevalue = DateTime.Compare(startdate, endDate);
                            if (endDate > startdate)
                            {
                                DataTable examdt = new DataTable();
                                examdt = bll.GetExamList("Full");
                                List<string> departmentstandard = new List<string>();
                                departmentstandard = examdt.AsEnumerable()
                               .Select(r => r.Field<string>("ExamName"))
                               .ToList();
                                if (!departmentstandard.Contains(txtExamName.Text))
                                {
                                    var result = bll.UpdateExamSetting(true,txtExamName.Text, int.Parse(ddlDepartmentStandard.SelectedValue), int.Parse(ddlSubjectCourse.SelectedValue), int.Parse(txtTotalMarks.Text), startdate, endDate, 0, int.Parse(txtnumberofQuestion.Text), int.Parse(txtDuration.Text));
                                    if (result > 0)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Updated Sucessfully')", true);
                                        binddepartmentddl();
                                        bindCourseddl();
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
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Name already in available')", true);
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
        }

        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
            //bindExamddlByDepartment();
        }

        protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            //bindExamddlByCourse();
        }
    }
}