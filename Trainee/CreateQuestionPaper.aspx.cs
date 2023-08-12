using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Learner.BasicClass;
using LMS.Trainee.BasicClass;
using LMS.Trainee.ExamClessFile;
using LMS.Trainee.QuestionClassFile;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class CreateQuestionPaper : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        ExamBLL exambll = new ExamBLL();
        QuestionBLL questionbll = new QuestionBLL();
        Question addQuestion = new Question();
        public static string optionValue = "";
        int deletingID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                //bindCourseddl();
                //bindExamddl();
                bindQuestionAnswerddl();
            }
            RequiredFieldValidator3.Enabled = false;
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
        public void bindQuestionAnswerddl()
        {
            DataTable dt = new DataTable();
            dt = questionbll.GetQuestionAnswerTypeList("Active");
            ddlQuestionAnswerType.DataSource = dt;
            ddlQuestionAnswerType.DataBind();
            ddlQuestionAnswerType.DataTextField = "AnswerTypeName";
            ddlQuestionAnswerType.DataValueField = "Id";
            ddlQuestionAnswerType.DataBind();
            ddlQuestionAnswerType.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindValidationAnswerTypeddl()
        {
            DataTable dt = new DataTable();
            dt = questionbll.GetValidationAnswerTypeList("Active");
            ddlValidationAnswertype.DataSource = dt;
            ddlValidationAnswertype.DataBind();
            ddlValidationAnswertype.DataTextField = "AnswerTypeName";
            ddlValidationAnswertype.DataValueField = "Id";
            ddlValidationAnswertype.DataBind();
            ddlValidationAnswertype.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void imgdeletebtn_Click(object sender, EventArgs e)
        {
            LinkButton btndetails = sender as LinkButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
            string id = (btndetails.CommandArgument).ToString();
            deletingID = int.Parse(id);
            ViewState["deletedValueId"] = deletingID;
            this.ModalPopupExtender2.Show();
        }
        public void bindValidationTypeddl(int validationAnswerTypeId)
        {
            DataTable dt = new DataTable();
            dt = questionbll.GetValidationTypeList("Active", validationAnswerTypeId);
            DropDownList6.DataSource = dt;
            DropDownList6.DataBind();
            DropDownList6.DataTextField = "ValidationTypeName";
            DropDownList6.DataValueField = "Id";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        [WebMethod]
        public static string SaveData(string empdata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(empdata);
            optionValue = serializeData.ToString();
            // ViewState[""].ToString() = serializeData;
            return null;
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuestionAnswerType.SelectedValue == "0")
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Proper Answer Type')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpop6('Select Proper Answer Type')</script>", false);
            }
            else if (ddlQuestionAnswerType.SelectedValue == "1")
            {
                bindValidationAnswerTypeddl();
                MultiView1.ActiveViewIndex = 0;
                RequiredFieldValidator3.Enabled = true;
                //MultiAnswer.ActiveViewIndex = 0;
                chktext.Checked = true;
                chkmultitext.Checked = true;
                chkmultipleoptions.Checked = true;
                chkuploadfile.Checked = true;
            }
            else if (ddlQuestionAnswerType.SelectedValue == "2")
            {
                MultiView1.ActiveViewIndex = 1;
                //MultiAnswer.ActiveViewIndex = 0;
                chktext.Checked = true;
                chkmultitext.Checked = true;
                chkmultipleoptions.Checked = true;
                chkuploadfile.Checked = true;
            }
            else if (ddlQuestionAnswerType.SelectedValue == "3")
            {
                MultiView1.ActiveViewIndex = 3;
                //MultiAnswer.ActiveViewIndex = 0;
                chktext.Checked = true;
                chkmultitext.Checked = true;
                chkmultipleoptions.Checked = true;
                chkuploadfile.Checked = true;
            }
            else
            {
                MultiView1.ActiveViewIndex = 2;
                //MultiAnswer.ActiveViewIndex = 1;
                chktext.Checked = true;
                chkmultitext.Checked = true;
                chkmultipleoptions.Checked = true;
                chkuploadfile.Checked = true;
            }
        }

        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlValidationAnswertype.SelectedValue == "1")
            {
                DropDownList6.Items.Clear();
                bindValidationTypeddl(int.Parse(ddlValidationAnswertype.SelectedValue));
            }
            else if (ddlValidationAnswertype.SelectedValue == "2")
            {
                DropDownList6.Items.Clear();
                bindValidationTypeddl(int.Parse(ddlValidationAnswertype.SelectedValue));
            }
            else if (ddlValidationAnswertype.SelectedValue == "3")
            {
                DropDownList6.Items.Clear();
                bindValidationTypeddl(int.Parse(ddlValidationAnswertype.SelectedValue));
            }
            else
            {

            }
        }

        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList6.SelectedItem.Text == "Greater than" || DropDownList6.SelectedItem.Text == "Greater than or equal to" || DropDownList6.SelectedItem.Text == "Less than"
                 || DropDownList6.SelectedItem.Text == "Less than or equal to" || DropDownList6.SelectedItem.Text == "Equal to" || DropDownList6.SelectedItem.Text == "Not equal to"
                 || DropDownList6.SelectedItem.Text == "Less than or equal to" || DropDownList6.SelectedItem.Text == "Maximum character count" || DropDownList6.SelectedItem.Text == "Minimum character count")
            {
                mltvalidation.ActiveViewIndex = 0;
            }
            else if (DropDownList6.SelectedItem.Text == "Contains" || DropDownList6.SelectedItem.Text == "Doesn't contains")
            {
                mltvalidation.ActiveViewIndex = 2;
            }
            else if (DropDownList6.SelectedItem.Text == "Between" || DropDownList6.SelectedItem.Text == "Not between")
            {
                mltvalidation.ActiveViewIndex = 1;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var value = inpHide.Value;
            List<int> checkedValue = new List<int>();
            if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 4 || int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 5 || int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 6)
            {
                if (checkedId.Value != "")
                {
                    checkedValue = checkedId.Value.Split(',').Select(Int32.Parse).ToList();
                }
                else
                {
                    string text7 = "Select Proper Answer";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpop1('" + text7 + "')</script>", false);
                }
            }
            try
            {
                var selectedvalue = "";


                addQuestion.DepartmentStandardId = int.Parse(ddlDepartmentStandard.SelectedValue.ToString());
                addQuestion.CourseSubjectId = int.Parse(ddlSubjectCourse.SelectedValue.ToString());
                addQuestion.ExamId = int.Parse(ddlExam.SelectedValue.ToString());
                addQuestion.QuestionToAsk = txtQuestion.Text;
                addQuestion.QuestionAnswerTypeId = int.Parse(ddlQuestionAnswerType.SelectedValue.ToString());
                if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 1)
                {
                    addQuestion.IsRequired = chktext.Checked == true ? true : false;
                    addQuestion.ValidationAnswerTypeId = int.Parse(ddlValidationAnswertype.SelectedValue.ToString());
                    int validationValue = DropDownList6.SelectedValue.ToString() == "" ? 0 : int.Parse(DropDownList6.SelectedValue.ToString());
                    addQuestion.ValidationAnswerId = validationValue;
                    if (validationValue > 0)
                    {
                        if (int.Parse(DropDownList6.SelectedValue.ToString()) == 1 || int.Parse(DropDownList6.SelectedValue.ToString()) == 2 || int.Parse(DropDownList6.SelectedValue.ToString()) == 3 || int.Parse(DropDownList6.SelectedValue.ToString()) == 4 || int.Parse(DropDownList6.SelectedValue.ToString()) == 5 || int.Parse(DropDownList6.SelectedValue.ToString()) == 6)
                        {
                            addQuestion.ValueToCompare = TextBox1.Text;
                        }
                        else if (int.Parse(DropDownList6.SelectedValue.ToString()) == 7 || int.Parse(DropDownList6.SelectedValue.ToString()) == 8)
                        {
                            addQuestion.MinValue = int.Parse(txtfrom.Text);
                            addQuestion.MaxValue = int.Parse(txttill.Text);
                        }
                        else if (int.Parse(DropDownList6.SelectedValue.ToString()) == 11 || int.Parse(DropDownList6.SelectedValue.ToString()) == 12 || int.Parse(DropDownList6.SelectedValue.ToString()) == 13 || int.Parse(DropDownList6.SelectedValue.ToString()) == 14)
                        {
                            addQuestion.ValueToCompare = TextBox2.Text;
                        }
                    }
                    addQuestion.ErrorMessage = txtcustomerrormessage.Text;
                    addQuestion.CorrectOption = txtCorrectAnswer.Text;
                }
                else if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 2)
                {
                    addQuestion.IsRequired = chkmultitext.Checked == true ? true : false;
                    addQuestion.CorrectOption = txtCorrectAnswer.Text;
                }
                else if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 3)
                {

                    addQuestion.IsRequired = chkuploadfile.Checked == true ? true : false;
                    addQuestion.CorrectOption = txtCorrectAnswer.Text;
                }
                else if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 4)
                {
                    addQuestion.IsRequired = chkmultipleoptions.Checked == true ? true : false;
                    addQuestion.QuestionOptionMetadata = value;
                    List<ObjectValue> optionAnswer = new List<ObjectValue>();
                    List<OptionValue> optionValues = new List<OptionValue>();
                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(value);
                    int count = 0;
                    foreach (var item in serializeData)
                    {
                        count += 1;
                        foreach (var selectedid in checkedValue)
                        {
                            if (count == selectedid)
                            {
                                selectedvalue = item.Option;
                                optionAnswer.Add(new ObjectValue { Option = item.Option });
                            }
                        }
                    }
                    selectedvalue = JsonConvert.SerializeObject(optionAnswer);

                    addQuestion.CorrectOption = selectedvalue;
                }
                else if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 5)
                {
                    addQuestion.IsRequired = chkmultitext.Checked == true ? true : false;
                    addQuestion.QuestionOptionMetadata = value;
                    List<ObjectValue> optionAnswer = new List<ObjectValue>();
                    List<OptionValue> optionValues = new List<OptionValue>();
                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(value);
                    int count = 0;
                    foreach (var item in serializeData)
                    {
                        count += 1;
                        foreach (var selectedid in checkedValue)
                        {
                            if (count == selectedid)
                            {
                                selectedvalue = item.Option;
                                optionAnswer.Add(new ObjectValue { Option = item.Option });
                            }
                        }
                    }
                    selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                    addQuestion.CorrectOption = selectedvalue;
                }
                else if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 6)
                {
                    addQuestion.IsRequired = chkmultitext.Checked == true ? true : false;
                    addQuestion.QuestionOptionMetadata = value;
                    List<ObjectValue> optionAnswer = new List<ObjectValue>();
                    List<OptionValue> optionValues = new List<OptionValue>();
                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(value);
                    int count = 0;
                    foreach (var item in serializeData)
                    {
                        count += 1;
                        foreach (var selectedid in checkedValue)
                        {
                            if (count == selectedid)
                            {
                                selectedvalue = item.Option;
                                optionAnswer.Add(new ObjectValue { Option = item.Option });
                            }
                        }
                    }
                    selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                    addQuestion.CorrectOption = selectedvalue;
                }
                else
                {
                    addQuestion.IsRequired = false;
                }
                addQuestion.Marks = int.Parse(txtMarks.Text);



                if (int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 4 || int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 5 || int.Parse(ddlQuestionAnswerType.SelectedValue.ToString()) == 6)
                {
                    if (checkedId.Value != "")
                    {
                        var result = questionbll.AddNewQuestion(addQuestion);
                        if (result > 0)
                        {
                            getclients();
                            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Question Added Sucessfully')", true);
                            string text6 = "Question Added Sucessfully";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpop5('" + text6 + "')</script>", false);
                        }
                        else
                        {
                            string text6 = "Something went wrong!";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpop6('" + text6 + "')</script>", false);
                        }
                    }
                }
                else
                {
                    var result = questionbll.AddNewQuestion(addQuestion);
                    if (result > 0)
                    {
                        getclients();
                        //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Question Added Sucessfully')", true);
                        string text6 = "Question Added Sucessfully";
                        ClearTextField();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpop5('" + text6 + "')</script>", false);
                    }
                    else
                    {
                        string text6 = "Something went wrong!";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpop6('" + text6 + "')</script>", false);
                    }
                }

            }
            catch (Exception ex)
            {
                //throw ex;
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpop6('" + ex.Message + "')</script>", false);
            }
            finally
            {
                questionbll = null;
            }
        }
        public void ClearTextField()
        {
            txtQuestion.Text = "";
            TextBox1.Text = "";
            txtfrom.Text = "";
            txttill.Text = "";
            TextBox2.Text = "";
            txtcustomerrormessage.Text = "";
            txtCorrectAnswer.Text = "";
            txtMarks.Text = "";
        }

        //protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (int.Parse(ddlDepartmentStandard.SelectedValue.ToString()) == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Department / Standard')", true);
        //    }
        //    else if (int.Parse(ddlSubjectCourse.SelectedValue.ToString()) == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Subject / Course')", true);
        //    }
        //    else if (int.Parse(ddlExam.SelectedValue.ToString()) == 0)
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Exam')", true);
        //    }
        //    else
        //    {
        //        getclients();
        //    }
        //}
        public void getclients()
        {
            DataTable dt = new DataTable();
            dt = questionbll.GetQuestionList(int.Parse(ddlDepartmentStandard.SelectedValue.ToString()), int.Parse(ddlSubjectCourse.SelectedValue.ToString()), int.Parse(ddlExam.SelectedValue.ToString()), false);

            foreach (DataRow dr in dt.Rows)
            {
                var value = dr["QuestionOptionMetadata"].ToString();
                string email = value != "" ? value : "";
                var newValue = "";
                if (email != "")
                {
                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);

                    foreach (var item in serializeData)
                    {
                        newValue += item.Option + ", ";
                    }
                }
                //email = email.Substring(0, email.IndexOf('@'));
                dr["QuestionOptionMetadata"] = newValue;
            }

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            getclients();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
                e.Row.Cells[6].CssClass = "columnwidth";
                e.Row.Cells[7].CssClass = "columnwidth";
            }
        }
        protected void btnStartExam_Click(object sender, EventArgs e)
        {
            getclients();
        }

        protected void ddlDepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
            bindExamddlByDepartment();
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                deletingID = int.Parse(ViewState["deletedValueId"].ToString());
                var result = questionbll.DeleteQuestionAndValidationTable(deletingID);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Question Deleted Sucessfully')", true);
                    getclients();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                questionbll = null;
            }

        }

        protected void btnListDelete_Click(object sender, EventArgs e)
        {
            List<int> deleteingId = new List<int>();
            foreach (GridViewRow row in GridView1.Rows)
            {
                Boolean isActive = false;
                Label labelid = row.FindControl("lblid") as Label;
                int id = Convert.ToInt32(labelid.Text);
                CheckBox checkIsActive = (row.FindControl("chkDelete") as CheckBox);

                if (checkIsActive.Checked == true)
                {
                    deleteingId.Add(id);
                }
            }
            if (deleteingId.Count > 0)
            {
                this.ModalPopupExtender2.Show();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please select Question to delete')", true);
            }

        }
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int resultCount = 0;
        //        foreach (GridViewRow row in GridView1.Rows)
        //        {
        //            Boolean isActive = false;
        //            Label labelid = row.FindControl("lblid") as Label;
        //            int deleteid = Convert.ToInt32(labelid.Text);
        //            CheckBox checkIsActive = (row.FindControl("chkDelete") as CheckBox);

        //            if (checkIsActive.Checked == true)
        //            {

        //                var result = questionbll.DeleteQuestionAndValidationTable(deleteid);
        //                if (result > 0)
        //                {
        //                    resultCount += 1;
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
        //                }
        //            }
        //        }
        //        if (resultCount > 0)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Group Name Deleted Sucessfully')", true);
        //            getclients();
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        questionbll = null;
        //    }

        //}

        protected void ddlSubjectCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindExamddlByCourse();
        }
    }
    public class ObjectValue
    {
        public string Option { get; set; }

    }
}