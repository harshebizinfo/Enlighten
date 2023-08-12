using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LMS.Learner.BasicClass;
using LMS.Trainee;
using LMS.Trainee.BasicClass;
using LMS.Trainee.ExamClessFile;
using LMS.Trainee.QuestionClassFile;
using Newtonsoft.Json;
using System.Data;
using System.IO;

namespace LMS.Learner
{
    public partial class QuestionPaper : System.Web.UI.Page
    {
        QuestionBLL questionbll = new QuestionBLL();
        ExamBLL exambll = new ExamBLL();
        DataTable questiondt = new DataTable();
        int numberOfQuestion = 1;
        public int seconds; // Seconds.
        public int minutes; // Minutes.
        public int hours;   // Hours.
        public bool paused; // State of the timer [PAUSED/WORKING].
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int lastseqNumber = 0;
                //Page.Form.Attributes.Add("enctype", "multipart/form-data");
                if (!IsPostBack)
                {
                    var clientName = Session["ClientName"].ToString();
                    var departmentstandard = Session["DepartmentStandard"].ToString();
                    var subjectCourse = Session["CourseSubject"].ToString();
                    var exam = Session["Exam"].ToString();
                    var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
                    var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
                    var examId = int.Parse(Session["ExamId"].ToString());
                    var userName = Session["UserName"].ToString();
                    int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());

                    lblClientName.Text = clientName;
                    lblDepartment.Text = departmentstandard;
                    lblSubject.Text = subjectCourse;
                    lblExam.Text = exam;
                    lblusername.Text = userName;
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);

                    List<ExamAnswerLog> questionNumber = new List<ExamAnswerLog>();
                    questionNumber = (from DataRow dr in questiondt.Rows
                                      select new ExamAnswerLog()
                                      {
                                          Id = int.Parse(dr["Id"].ToString()),
                                          ExamId = int.Parse(dr["ExamId"].ToString()),
                                          DepartmentStandardId = int.Parse(dr["DepartmentStandardId"].ToString()),
                                          CourseSubjectId = int.Parse(dr["CourseSubjectId"].ToString()),
                                          ApplicationUserId = int.Parse(dr["ApplicationUserId"].ToString()),
                                          QuestionId = int.Parse(dr["QuestionId"].ToString()),
                                          Answer = dr["Answer"].ToString(),
                                          Marks = dr["Marks"].ToString() == "" ? 0 : int.Parse(dr["Marks"].ToString()),
                                          SequenceNumber = int.Parse(dr["SequenceNumber"].ToString()),
                                      }).ToList();
                    // var questionId = int.Parse(questiondt.Rows[0]["SequenceNumber"].ToString()) == 1 ? int.Parse(questiondt.Rows[0]["QuestionId"].ToString()) : 0;
                    var questionId = int.Parse(questionNumber.Where(m => m.SequenceNumber == 1).Select(p => p.QuestionId).FirstOrDefault().ToString());
                    ViewState["CurrentSequenceNumber"] = 1;//questiondt.Rows[0]["SequenceNumber"].ToString();
                    ViewState["currentSequenceNumber"] = 1;// int.Parse(questiondt.Rows[0]["SequenceNumber"].ToString());
                    lastseqNumber = questionNumber.Select(p => p.SequenceNumber).Max();
                    ViewState["lastSequenceNumber"] = lastseqNumber;
                    ViewState["NextSequenceNumber"] = 1 + 1;
                    DataTable questiondb = new DataTable();
                    questiondb = questionbll.GetQuestionaireById(questionId);
                    lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();
                    #region bindoptiondata
                    if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ViewState["multiViewActiveIndexId"] = 0;
                        if (questiondt.Rows[0]["Answer"].ToString() != null || questiondt.Rows[0]["Answer"].ToString() != "")
                        {
                            txtAnswer.Text = questiondt.Rows[0]["Answer"].ToString();
                        }
                        else
                        {
                            txtAnswer.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ViewState["multiViewActiveIndexId"] = 1;
                        if (questiondt.Rows[0]["Answer"].ToString() != null || questiondt.Rows[0]["Answer"].ToString() != "")
                        {
                            txtparagraph.Text = questiondt.Rows[0]["Answer"].ToString();
                        }
                        else
                        {
                            txtparagraph.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        MultiView1.ActiveViewIndex = 2;
                        ViewState["multiViewActiveIndexId"] = 2;
                        //if (questiondb.Rows[0]["Answer"].ToString() != null || questiondb.Rows[0]["Answer"].ToString() != "")
                        //{
                        //    FileUpload1 = questiondb.Rows[0]["Answer"].ToString();
                        //}
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        MultiView1.ActiveViewIndex = 3;
                        ViewState["multiViewActiveIndexId"] = 3;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        RadioButtonList1.DataSource = optionValues;
                        RadioButtonList1.DataTextField = "DisplayText";
                        RadioButtonList1.DataValueField = "ValueText";
                        RadioButtonList1.DataBind();
                        if (questiondt.Rows[0]["Answer"].ToString() != null || questiondt.Rows[0]["Answer"].ToString() != "")
                        {
                            RadioButtonList1.SelectedValue = questiondt.Rows[0]["Answer"].ToString();
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        MultiView1.ActiveViewIndex = 4;
                        ViewState["multiViewActiveIndexId"] = 4;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        CheckBoxList1.DataSource = optionValues;
                        CheckBoxList1.DataTextField = "DisplayText";
                        CheckBoxList1.DataValueField = "ValueText";
                        CheckBoxList1.DataBind();
                        if (questiondt.Rows[0]["Answer"].ToString() != null || questiondt.Rows[0]["Answer"].ToString() != "")
                        {
                            var previousAnswer = questiondt.Rows[0]["Answer"].ToString();
                            string[] authorsList = previousAnswer.Split(';');
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var value in authorsList)
                                {
                                    if (value == CheckBoxList1.Items[i].Value)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 5;
                        ViewState["multiViewActiveIndexId"] = 5;

                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                int iterationValue = 1;
                                //ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                                foreach (var item in serializeData)
                                {
                                    ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                    iterationValue += 1;
                                }
                                ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                            }
                        }
                        if (questiondt.Rows[0]["Answer"].ToString() != null || questiondt.Rows[0]["Answer"].ToString() != "")
                        {
                            ddlanswer.SelectedValue = questiondt.Rows[0]["Answer"].ToString();
                        }
                    }
                    #endregion
                    lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
                    mltbutton.ActiveViewIndex = 0;
                    hours = 0;
                    minutes = 0;// int.Parse(Session["DurationInMinutes"].ToString());
                    seconds = 0;
                    lblMinute.Text = minutes.ToString();
                    lblSecond.Text = seconds.ToString();

                }
                int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                int lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());

                if (currentSequence == 1)
                {
                    mltbutton.ActiveViewIndex = 0;
                }
                else if (currentSequence == lastSequenceNumber)
                {
                    mltbutton.ActiveViewIndex = 2;
                }
                else
                {
                    mltbutton.ActiveViewIndex = 1;
                }
                //getProgressDetail();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
            }

        }

        protected void btnNextQuestion_Click(object sender, EventArgs e)
        {

            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            DataTable previousquestiondb = new DataTable();
            previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
            #region updateAnswer
            DataTable validationdb = new DataTable();
            validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
            string enteredAnswer = "";
            string errormessage = "";
            int marks = 0;
            Boolean isRequired = false;
            //string validationAnswerType;
            if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                {
                    enteredAnswer = txtAnswer.Text;
                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                    {
                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                        {
                            int n;
                            bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                            if (isNumeric)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                    {
                                        if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                    {
                                        if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                    {
                                        if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                    {
                                        if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                    {
                                        if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= 0)
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                            }
                            double m;
                            bool isDouble = double.TryParse(txtAnswer.Text, out m);
                            if (!isNumeric)
                            {
                                if (isDouble)
                                {
                                    if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                        {
                                            if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                        {
                                            if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                        {
                                            if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                        {
                                            if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                        {
                                            if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                        {
                                            enteredAnswer = txtAnswer.Text;
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= 0)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    marks = 0;
                                }
                            }
                        }
                        else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                {
                                    if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                {
                                    if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                {
                                    if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                {
                                    if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Answer is required";
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                {
                    enteredAnswer = txtparagraph.Text;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                {

                    enteredAnswer = ViewState["enteredAnswer"].ToString();
                    ViewState["enteredAnswer"] = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                {
                    enteredAnswer = RadioButtonList1.SelectedItem.Text;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }

                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (CheckBoxList1.SelectedValue != null && CheckBoxList1.SelectedValue != "")
                {
                    List<string> YrStrList = new List<string>();
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    int answerCount = 0;
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        foreach (var answerItem in correctAnswerSerializeData)
                        {
                            if (item.Selected)
                            {
                                if (answerItem.Option == item.Value)
                                {
                                    answerCount += 1;
                                    YrStrList.Add(item.Value);
                                    if (answerCount == correctAnswerSerializeData.Count)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    String YrStr = String.Join(";", YrStrList.ToArray());
                    enteredAnswer = YrStr;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                {
                    enteredAnswer = ddlanswer.SelectedValue;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }

            if (!string.IsNullOrWhiteSpace(enteredAnswer))
            {
                var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                if (previousresult > 0)
                {
                    #region nextQuestion
                    ViewState["currentSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["NextSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["PreviousSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    var questionId = 0;
                    var previousAnswer = "";
                    foreach (DataRow dr in questiondt.Rows)
                    {
                        var value = int.Parse(dr["SequenceNumber"].ToString());
                        if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                        {
                            questionId = int.Parse(dr["QuestionId"].ToString());
                            previousAnswer = dr["Answer"].ToString();
                        }
                    }
                    DataTable questiondb = new DataTable();
                    questiondb = questionbll.GetQuestionaireById(questionId);
                    lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                    #region bindoptiondata
                    if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ViewState["multiViewActiveIndexId"] = 0;
                        if (previousAnswer != "")
                        {
                            txtAnswer.Text = previousAnswer;
                        }
                        else
                        {
                            txtAnswer.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ViewState["multiViewActiveIndexId"] = 1;
                        if (previousAnswer != "")
                        {
                            txtparagraph.Text = previousAnswer;
                        }
                        else
                        {
                            txtparagraph.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        MultiView1.ActiveViewIndex = 2;
                        ViewState["multiViewActiveIndexId"] = 2;
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        MultiView1.ActiveViewIndex = 3;
                        ViewState["multiViewActiveIndexId"] = 3;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        RadioButtonList1.DataSource = optionValues;
                        RadioButtonList1.DataTextField = "DisplayText";
                        RadioButtonList1.DataValueField = "ValueText";
                        RadioButtonList1.DataBind();
                        if (previousAnswer != "")
                        {
                            RadioButtonList1.SelectedValue = previousAnswer;
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        MultiView1.ActiveViewIndex = 4;
                        ViewState["multiViewActiveIndexId"] = 4;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        CheckBoxList1.DataSource = optionValues;
                        CheckBoxList1.DataTextField = "DisplayText";
                        CheckBoxList1.DataValueField = "ValueText";
                        CheckBoxList1.DataBind();
                        if (previousAnswer != "")
                        {
                            string[] authorsList = previousAnswer.Split(';');
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var value in authorsList)
                                {
                                    if (value == CheckBoxList1.Items[i].Value)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 5;
                        ViewState["multiViewActiveIndexId"] = 5;

                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                int iterationValue = 1;

                                foreach (var item in serializeData)
                                {
                                    ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                    iterationValue += 1;
                                }
                                ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                            }
                        }
                        if (previousAnswer != "")
                        {
                            ddlanswer.SelectedValue = previousAnswer;
                        }
                    }
                    #endregion

                    var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                    if (currentSequence == 1)
                    {
                        mltbutton.ActiveViewIndex = 0;
                    }
                    else if (currentSequence == lastSequenceNumber)
                    {
                        mltbutton.ActiveViewIndex = 2;
                    }
                    else
                    {
                        mltbutton.ActiveViewIndex = 1;
                    }
                    #endregion
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                //enteredAnswer== previousquestiondb.Rows[0]["CorrectOption"].ToString()
            }
            else
            {
                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Answer is Required')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : " + errormessage + "')", true);
                }
            }
            // getProgressDetail();
            #endregion
            lblUploadSucess.Visible = false;
            lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            DataTable previousquestiondb = new DataTable();
            previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
            #region updateAnswer
            DataTable validationdb = new DataTable();
            validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
            string enteredAnswer = "";
            string errormessage = "";
            int marks = 0;
            Boolean isRequired = false;
            //string validationAnswerType;
            if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                {
                    enteredAnswer = txtAnswer.Text;
                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                    {
                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                        {
                            int n;
                            bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                            if (isNumeric)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                    {
                                        if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                    {
                                        if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                    {
                                        if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                    {
                                        if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                    {
                                        if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= 0)
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                            }
                            double m;
                            bool isDouble = double.TryParse(txtAnswer.Text, out m);
                            if (!isNumeric)
                            {
                                if (isDouble)
                                {
                                    if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                        {
                                            if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                        {
                                            if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                        {
                                            if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                        {
                                            if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                        {
                                            if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                        {
                                            enteredAnswer = txtAnswer.Text;
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= 0)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    marks = 0;
                                }
                            }
                        }
                        else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                {
                                    if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                {
                                    if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                {
                                    if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                {
                                    if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Answer is required";
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                {
                    enteredAnswer = txtparagraph.Text;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                {

                    enteredAnswer = ViewState["enteredAnswer"].ToString();
                    ViewState["enteredAnswer"] = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                {
                    enteredAnswer = RadioButtonList1.SelectedItem.Text;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (CheckBoxList1.SelectedValue != null || CheckBoxList1.SelectedValue != "")
                {
                    List<string> YrStrList = new List<string>();
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    int answerCount = 0;
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        foreach (var answerItem in correctAnswerSerializeData)
                        {
                            if (item.Selected)
                            {
                                if (answerItem.Option == item.Value)
                                {
                                    answerCount += 1;
                                    YrStrList.Add(item.Value);
                                    if (answerCount == correctAnswerSerializeData.Count)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    String YrStr = String.Join(";", YrStrList.ToArray());
                    enteredAnswer = YrStr;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                {
                    enteredAnswer = ddlanswer.SelectedValue;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }

            if (!string.IsNullOrWhiteSpace(enteredAnswer))
            {
                //int marks = 0;
                //if (enteredAnswer == previousquestiondb.Rows[0]["CorrectOption"].ToString())
                //{
                //    marks = int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString());
                //}
                var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                if (previousresult > 0)
                {
                    #region nextQuestion
                    ViewState["currentSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["NextSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["PreviousSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    var questionId = 0;
                    var previousAnswer = "";
                    foreach (DataRow dr in questiondt.Rows)
                    {
                        var value = int.Parse(dr["SequenceNumber"].ToString());
                        if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                        {
                            questionId = int.Parse(dr["QuestionId"].ToString());
                            previousAnswer = dr["Answer"].ToString();
                        }
                    }
                    DataTable questiondb = new DataTable();
                    questiondb = questionbll.GetQuestionaireById(questionId);
                    lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                    #region bindoptiondata
                    if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ViewState["multiViewActiveIndexId"] = 0;
                        if (previousAnswer != "")
                        {
                            txtAnswer.Text = previousAnswer;
                        }
                        else
                        {
                            txtAnswer.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ViewState["multiViewActiveIndexId"] = 1;
                        if (previousAnswer != "")
                        {
                            txtparagraph.Text = previousAnswer;
                        }
                        else
                        {
                            txtparagraph.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        MultiView1.ActiveViewIndex = 2;
                        ViewState["multiViewActiveIndexId"] = 2;
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        MultiView1.ActiveViewIndex = 3;
                        ViewState["multiViewActiveIndexId"] = 3;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        RadioButtonList1.DataSource = optionValues;
                        RadioButtonList1.DataTextField = "DisplayText";
                        RadioButtonList1.DataValueField = "ValueText";
                        RadioButtonList1.DataBind();
                        if (previousAnswer != "")
                        {
                            RadioButtonList1.SelectedValue = previousAnswer;
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        MultiView1.ActiveViewIndex = 4;
                        ViewState["multiViewActiveIndexId"] = 4;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        CheckBoxList1.DataSource = optionValues;
                        CheckBoxList1.DataTextField = "DisplayText";
                        CheckBoxList1.DataValueField = "ValueText";
                        CheckBoxList1.DataBind();
                        if (previousAnswer != "")
                        {
                            string[] authorsList = previousAnswer.Split(';');
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var value in authorsList)
                                {
                                    if (value == CheckBoxList1.Items[i].Value)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 5;
                        ViewState["multiViewActiveIndexId"] = 5;
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                int iterationValue = 1;

                                foreach (var item in serializeData)
                                {
                                    ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                    iterationValue += 1;
                                }
                                ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                            }
                        }
                        if (previousAnswer != "")
                        {
                            ddlanswer.SelectedValue = previousAnswer;
                        }
                    }
                    #endregion

                    var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                    if (currentSequence == 1)
                    {
                        mltbutton.ActiveViewIndex = 0;
                    }
                    else if (currentSequence == lastSequenceNumber)
                    {
                        mltbutton.ActiveViewIndex = 2;
                    }
                    else
                    {
                        mltbutton.ActiveViewIndex = 1;
                    }
                    #endregion

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                //enteredAnswer== previousquestiondb.Rows[0]["CorrectOption"].ToString()
            }
            else
            {
                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Answer is Required')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : " + errormessage + "')", true);
                }
            }

            #endregion
            lblUploadSucess.Visible = false;
            lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
            // getProgressDetail();

        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            DataTable previousquestiondb = new DataTable();
            previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
            #region updateAnswer
            DataTable validationdb = new DataTable();
            validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
            string enteredAnswer = "";
            string errormessage = "";
            int marks = 0;
            Boolean isRequired = false;
            //string validationAnswerType;
            if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                {
                    enteredAnswer = txtAnswer.Text;
                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                    {
                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                        {
                            int n;
                            bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                            if (isNumeric)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                    {
                                        if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                    {
                                        if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                    {
                                        if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                    {
                                        if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                    {
                                        if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= 0)
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                            }
                            double m;
                            bool isDouble = double.TryParse(txtAnswer.Text, out m);
                            if (!isNumeric)
                            {
                                if (isDouble)
                                {
                                    if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                        {
                                            if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                        {
                                            if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                        {
                                            if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                        {
                                            if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                        {
                                            if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                        {
                                            enteredAnswer = txtAnswer.Text;
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= 0)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    marks = 0;
                                }
                            }
                        }
                        else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                {
                                    if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                {
                                    if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                {
                                    if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                {
                                    if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Answer is required";
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                {
                    enteredAnswer = txtparagraph.Text;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                {

                    enteredAnswer = ViewState["enteredAnswer"].ToString();
                    ViewState["enteredAnswer"] = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                {
                    enteredAnswer = RadioButtonList1.SelectedItem.Text;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (CheckBoxList1.SelectedValue != null || CheckBoxList1.SelectedValue != "")
                {
                    List<string> YrStrList = new List<string>();
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    int answerCount = 0;
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        foreach (var answerItem in correctAnswerSerializeData)
                        {
                            if (item.Selected)
                            {
                                if (answerItem.Option == item.Value)
                                {
                                    answerCount += 1;
                                    YrStrList.Add(item.Value);
                                    if (answerCount == correctAnswerSerializeData.Count)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    String YrStr = String.Join(";", YrStrList.ToArray());
                    enteredAnswer = YrStr;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                {
                    enteredAnswer = ddlanswer.SelectedValue;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }

            if (!string.IsNullOrWhiteSpace(enteredAnswer))
            {
                //int marks = 0;
                //if (enteredAnswer == previousquestiondb.Rows[0]["CorrectOption"].ToString())
                //{
                //    marks = int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString());
                //}
                var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                if (previousresult > 0)
                {
                    #region previousQuestion
                    ViewState["currentSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    ViewState["NextSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["PreviousSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    var questionId = 0;
                    var previousAnswer = "";
                    foreach (DataRow dr in questiondt.Rows)
                    {
                        var value = int.Parse(dr["SequenceNumber"].ToString());
                        if (currentSequence == value)
                        {
                            previousAnswer = dr["Answer"].ToString();
                            questionId = int.Parse(dr["QuestionId"].ToString());
                        }
                    }
                    DataTable questiondb = new DataTable();
                    questiondb = questionbll.GetQuestionaireById(questionId);
                    lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                    #region bindoptiondata
                    if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ViewState["multiViewActiveIndexId"] = 0;
                        if (previousAnswer != "")
                        {
                            txtAnswer.Text = previousAnswer;
                        }
                        else
                        {
                            txtAnswer.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ViewState["multiViewActiveIndexId"] = 1;
                        if (previousAnswer != "")
                        {
                            txtparagraph.Text = previousAnswer;
                        }
                        else
                        {
                            txtparagraph.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        MultiView1.ActiveViewIndex = 2;
                        ViewState["multiViewActiveIndexId"] = 2;
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        MultiView1.ActiveViewIndex = 3;
                        ViewState["multiViewActiveIndexId"] = 3;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        RadioButtonList1.DataSource = optionValues;
                        RadioButtonList1.DataTextField = "DisplayText";
                        RadioButtonList1.DataValueField = "ValueText";
                        RadioButtonList1.DataBind();

                        if (previousAnswer != "")
                        {
                            RadioButtonList1.SelectedValue = previousAnswer;
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        MultiView1.ActiveViewIndex = 4;
                        ViewState["multiViewActiveIndexId"] = 4;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        CheckBoxList1.DataSource = optionValues;
                        CheckBoxList1.DataTextField = "DisplayText";
                        CheckBoxList1.DataValueField = "ValueText";
                        CheckBoxList1.DataBind();

                        if (previousAnswer != "")
                        {
                            string[] authorsList = previousAnswer.Split(';');
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var value in authorsList)
                                {
                                    if (value == CheckBoxList1.Items[i].Value)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 5;
                        ViewState["multiViewActiveIndexId"] = 5;
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                int iterationValue = 1;

                                foreach (var item in serializeData)
                                {
                                    ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                    iterationValue += 1;
                                }
                                ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                            }
                        }
                        if (previousAnswer != "")
                        {
                            ddlanswer.SelectedValue = previousAnswer;
                        }
                    }
                    #endregion

                    var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                    if (currentSequence == 1)
                    {
                        mltbutton.ActiveViewIndex = 0;
                    }
                    else if (currentSequence == lastSequenceNumber)
                    {
                        mltbutton.ActiveViewIndex = 2;
                    }
                    else
                    {
                        mltbutton.ActiveViewIndex = 1;
                    }
                    #endregion
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                //enteredAnswer== previousquestiondb.Rows[0]["CorrectOption"].ToString()
            }
            else
            {
                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Answer is Required')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : " + errormessage + "')", true);
                }
            }

            #endregion
            lblUploadSucess.Visible = false;
            lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
            // getProgressDetail();

        }

        protected void btnprevi_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            DataTable previousquestiondb = new DataTable();
            previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
            #region updateAnswer
            DataTable validationdb = new DataTable();
            validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
            string enteredAnswer = "";
            string errormessage = "";
            int marks = 0;
            Boolean isRequired = false;
            //string validationAnswerType;
            if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                {
                    enteredAnswer = txtAnswer.Text;
                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                    {
                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                        {
                            int n;
                            bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                            if (isNumeric)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                    {
                                        if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                    {
                                        if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                    {
                                        if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                    {
                                        if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                    {
                                        if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= 0)
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                            }
                            double m;
                            bool isDouble = double.TryParse(txtAnswer.Text, out m);
                            if (!isNumeric)
                            {
                                if (isDouble)
                                {
                                    if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                        {
                                            if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                        {
                                            if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                        {
                                            if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                        {
                                            if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                        {
                                            if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                        {
                                            enteredAnswer = txtAnswer.Text;
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= 0)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    marks = 0;
                                }
                            }
                        }
                        else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                {
                                    if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                {
                                    if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                {
                                    if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                {
                                    if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Answer is required";
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                {
                    enteredAnswer = txtparagraph.Text;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                {

                    enteredAnswer = ViewState["enteredAnswer"].ToString();
                    ViewState["enteredAnswer"] = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                {
                    enteredAnswer = RadioButtonList1.SelectedItem.Text;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (CheckBoxList1.SelectedValue != null || CheckBoxList1.SelectedValue != "")
                {
                    List<string> YrStrList = new List<string>();
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    int answerCount = 0;
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        foreach (var answerItem in correctAnswerSerializeData)
                        {
                            if (item.Selected)
                            {
                                if (answerItem.Option == item.Value)
                                {
                                    answerCount += 1;
                                    YrStrList.Add(item.Value);
                                    if (answerCount == correctAnswerSerializeData.Count)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    String YrStr = String.Join(";", YrStrList.ToArray());
                    enteredAnswer = YrStr;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                {
                    enteredAnswer = ddlanswer.SelectedValue;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }

            if (!string.IsNullOrWhiteSpace(enteredAnswer))
            {
                //int marks = 0;
                //if (enteredAnswer == previousquestiondb.Rows[0]["CorrectOption"].ToString())
                //{
                //    marks = int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString());
                //}
                var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                if (previousresult > 0)
                {
                    #region previousQuestion
                    ViewState["currentSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    ViewState["NextSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) + 1;
                    ViewState["PreviousSequenceNumber"] = int.Parse(ViewState["currentSequenceNumber"].ToString()) - 1;
                    int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    var questionId = 0;
                    var previousAnswer = "";
                    foreach (DataRow dr in questiondt.Rows)
                    {
                        var value = int.Parse(dr["SequenceNumber"].ToString());
                        if (currentSequence == value)
                        {
                            questionId = int.Parse(dr["QuestionId"].ToString());
                            previousAnswer = dr["Answer"].ToString();
                        }
                    }
                    DataTable questiondb = new DataTable();
                    questiondb = questionbll.GetQuestionaireById(questionId);
                    lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                    #region bindoptiondata
                    if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        MultiView1.ActiveViewIndex = 0;
                        ViewState["multiViewActiveIndexId"] = 0;
                        if (previousAnswer != "")
                        {
                            txtAnswer.Text = previousAnswer;
                        }
                        else
                        {
                            txtAnswer.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        MultiView1.ActiveViewIndex = 1;
                        ViewState["multiViewActiveIndexId"] = 1;
                        if (previousAnswer != "")
                        {
                            txtparagraph.Text = previousAnswer;
                        }
                        else
                        {
                            txtparagraph.Text = "";
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        MultiView1.ActiveViewIndex = 2;
                        ViewState["multiViewActiveIndexId"] = 2;
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        MultiView1.ActiveViewIndex = 3;
                        ViewState["multiViewActiveIndexId"] = 3;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        RadioButtonList1.DataSource = optionValues;
                        RadioButtonList1.DataTextField = "DisplayText";
                        RadioButtonList1.DataValueField = "ValueText";
                        RadioButtonList1.DataBind();

                        if (previousAnswer != "")
                        {
                            RadioButtonList1.SelectedValue = previousAnswer;
                        }
                    }
                    else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        MultiView1.ActiveViewIndex = 4;
                        ViewState["multiViewActiveIndexId"] = 4;
                        List<OptionValue> optionValues = new List<OptionValue>();
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                foreach (var item in serializeData)
                                {
                                    optionValues.Add(new OptionValue
                                    {
                                        DisplayText = item.Option,
                                        ValueText = item.Option
                                    });
                                }
                            }
                        }
                        CheckBoxList1.DataSource = optionValues;
                        CheckBoxList1.DataTextField = "DisplayText";
                        CheckBoxList1.DataValueField = "ValueText";
                        CheckBoxList1.DataBind();
                        if (previousAnswer != "")
                        {
                            string[] authorsList = previousAnswer.Split(';');
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (var value in authorsList)
                                {
                                    if (value == CheckBoxList1.Items[i].Value)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MultiView1.ActiveViewIndex = 5;
                        ViewState["multiViewActiveIndexId"] = 5;
                        foreach (DataRow dr in questiondb.Rows)
                        {
                            var value = dr["QuestionOptionMetadata"].ToString();
                            string email = value != "" ? value : "";
                            var newValue = "";
                            if (email != "")
                            {
                                var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                int iterationValue = 1;

                                foreach (var item in serializeData)
                                {
                                    ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                    iterationValue += 1;
                                }
                                ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                            }
                        }
                        if (previousAnswer != "")
                        {
                            ddlanswer.SelectedValue = previousAnswer;
                        }
                    }
                    #endregion

                    var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                    if (currentSequence == 1)
                    {
                        mltbutton.ActiveViewIndex = 0;
                    }
                    else if (currentSequence == lastSequenceNumber)
                    {
                        mltbutton.ActiveViewIndex = 2;
                    }
                    else
                    {
                        mltbutton.ActiveViewIndex = 1;
                    }
                    #endregion
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                //enteredAnswer== previousquestiondb.Rows[0]["CorrectOption"].ToString()
            }
            else
            {
                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Answer is Required')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : " + errormessage + "')", true);
                }
            }

            #endregion
            lblUploadSucess.Visible = false;
            lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
            //getProgressDetail();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            DataTable previousquestiondb = new DataTable();
            previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
            #region updateAnswer
            DataTable validationdb = new DataTable();
            validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
            string enteredAnswer = "";
            string errormessage = "";
            int marks = 0;
            Boolean isRequired = false;
            //string validationAnswerType;
            if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                {
                    enteredAnswer = txtAnswer.Text;
                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                    {
                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                        {
                            int n;
                            bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                            if (isNumeric)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                    {
                                        if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                    {
                                        if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                    {
                                        if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                    {
                                        if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                    {
                                        if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                    {
                                        if (int.Parse(txtAnswer.Text) >= 0)
                                        {
                                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                            }
                            double m;
                            bool isDouble = double.TryParse(txtAnswer.Text, out m);
                            if (!isNumeric)
                            {
                                if (isDouble)
                                {
                                    if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                        {
                                            if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                        {
                                            if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                        {
                                            if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                        {
                                            if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                        {
                                            if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                        {
                                            enteredAnswer = txtAnswer.Text;
                                        }
                                        if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                        {
                                            if (double.Parse(txtAnswer.Text) >= 0)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    marks = 0;
                                }
                            }
                        }
                        else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                {
                                    if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                {
                                    if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                {
                                    if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                {
                                    if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                    else
                                    {
                                        marks = 0;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    errormessage = "Answer is required";
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                {
                    enteredAnswer = txtparagraph.Text;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                {

                    enteredAnswer = ViewState["enteredAnswer"].ToString();
                    ViewState["enteredAnswer"] = "";
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                {
                    enteredAnswer = RadioButtonList1.SelectedItem.Text;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (CheckBoxList1.SelectedValue != null || CheckBoxList1.SelectedValue != "")
                {

                    List<string> YrStrList = new List<string>();
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    int answerCount = 0;
                    foreach (ListItem item in CheckBoxList1.Items)
                    {
                        foreach (var answerItem in correctAnswerSerializeData)
                        {
                            if (item.Selected)
                            {
                                if (answerItem.Option == item.Value)
                                {
                                    answerCount += 1;
                                    YrStrList.Add(item.Value);
                                    if (answerCount == correctAnswerSerializeData.Count)
                                    {
                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                    }
                                }
                            }
                        }
                    }
                    String YrStr = String.Join(";", YrStrList.ToArray());
                    enteredAnswer = YrStr;
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }
            else
            {
                isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                {
                    enteredAnswer = ddlanswer.SelectedValue;
                    var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                    var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                    //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                    //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                    //int answerCount = 0;

                    foreach (var answerItem in correctAnswerSerializeData)
                    {
                        if (answerItem.Option == enteredAnswer)
                        {
                            marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                        }
                    }
                }
                else
                {
                    errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                }
            }

            if (!string.IsNullOrWhiteSpace(enteredAnswer))
            {
                //int marks = 0;
                //if (enteredAnswer == previousquestiondb.Rows[0]["CorrectOption"].ToString())
                //{
                //    marks = int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString());
                //}
                var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                if (previousresult > 0)
                {
                    #region FinalSubmit
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    List<ExamAnswerLog> examAnswerLog = new List<ExamAnswerLog>();
                    examAnswerLog = (from DataRow dr in questiondt.Rows
                                     select new ExamAnswerLog()
                                     {
                                         ApplicationUserId = int.Parse(dr["ApplicationUserId"].ToString()),
                                         QuestionId = int.Parse(dr["QuestionId"].ToString()),
                                         ExamId = int.Parse(dr["ExamId"].ToString()),
                                         DepartmentStandardId = int.Parse(dr["DepartmentStandardId"].ToString()),
                                         CourseSubjectId = int.Parse(dr["CourseSubjectId"].ToString()),
                                         Answer = dr["Answer"].ToString(),
                                         SequenceNumber = int.Parse(dr["SequenceNumber"].ToString()),
                                         Marks = int.Parse(dr["Marks"].ToString()),
                                     }).ToList();
                    numberOfExamAttempts += 1;

                    DataTable numberOfAttempts = new DataTable();
                    numberOfAttempts = questionbll.GetNumberOfExamAttemptsList(departmentstandardid, subjectCourseid, examId);
                    var attemptsCount = numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString() == "" ? 1 : int.Parse(numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString()) + 1;

                    var result = questionbll.AddNewExamAnswer(examAnswerLog, attemptsCount);
                    if (result > 0)
                    {

                        var addNumberOfAttempts = questionbll.AddNumberOfExamAttemptsList(departmentstandardid, subjectCourseid, examId, attemptsCount);
                        if (addNumberOfAttempts > 0)
                        {
                            var attemptsinExamLog = questionbll.UpdateAllotedQuestionExamAnswerLogNumberOfAttempts(departmentstandardid, subjectCourseid, examId, attemptsCount);
                            //string url = "Exam.aspx";
                            //string s = "window.close('" + url + "', 'popup_window', 'width=100%,height=100%,resizable=yes');";
                            //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                            if (attemptsinExamLog > 0)
                            {
                                var addnewResult = questionbll.AddNewStudentResult(departmentstandardid, subjectCourseid, examId, attemptsCount);
                                if (addnewResult > 0)
                                {
                                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Done Sucessfully!')", true);
                                    Response.Redirect("Exam.aspx?value=Sucess");
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
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                        }
                    }
                    #endregion
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
                //enteredAnswer== previousquestiondb.Rows[0]["CorrectOption"].ToString()
            }
            else
            {
                if (string.IsNullOrWhiteSpace(errormessage))
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : Answer is Required')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error : " + errormessage + "')", true);
                }
            }

            #endregion

            //getProgressDetail();

        }

        //protected void btnAsyncUpload_Click(object sender, EventArgs e)
        //{
        //    bool hasFile = FileUpload1.HasFile;
        //}
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            foreach (DataRow dr in questiondt.Rows)
            {
                var value = int.Parse(dr["SequenceNumber"].ToString());
                if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                {
                    previousquestionId = int.Parse(dr["QuestionId"].ToString());
                    allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                }
            }
            bool hasFile = FileUpload1.HasFile;
            if (hasFile)
            {
                int filecount = 0;
                int fileuploadcount = 0;
                filecount = FileUpload1.PostedFiles.Count();

                if (filecount <= 5)
                {
                    List<FileUploadList> optionAnswer = new List<FileUploadList>();
                    int count = 0;
                    foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                    {
                        count += 1;
                        var fileUploadPath = postedFile.FileName;
                        string extension = System.IO.Path.GetExtension(postedFile.FileName);
                        int applicationUserId = int.Parse(Session["applicationUserId"].ToString());
                        var filename = departmentstandardid.ToString() + "_" + subjectCourseid.ToString() + "_" + examId.ToString() + "_" + applicationUserId.ToString() + "_" + previousquestionId.ToString() + "_" + numberOfExamAttempts.ToString() + "_" + count.ToString();
                        string clientFolderPath = Server.MapPath("UploadedAnswerFile/");
                        if (!Directory.Exists(clientFolderPath))
                        {
                            //If Directory (Folder) does not exists. Create it.
                            Directory.CreateDirectory(clientFolderPath);
                        }
                        if (File.Exists(Path.Combine(clientFolderPath, filename)))
                        {
                            // If file found, delete it    
                            File.Delete(Path.Combine(clientFolderPath, filename));
                        }
                        FileUpload1.SaveAs(clientFolderPath + filename.ToString() + extension);
                        var completeFileName = "/Learner/UploadedAnswerFile/" + filename.ToString() + extension;
                        optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                        completeFileName = "";
                    }
                    var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                    ViewState["enteredAnswer"] = selectedvalue;//"~/UploadedAnswerFile/" + filename.ToString() + extension;
                    lblUploadSucess.Visible = true;
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You can upload maximum 5 file only')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
            }
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            //hours = 0;
            //minutes = int.Parse(Session["DurationInMinutes"].ToString());
            //seconds = 0;
            //lblMinute.Text = minutes.ToString();
            //lblSecond.Text = seconds.ToString();
            minutes = int.Parse(Session["Minutes"].ToString());
            seconds = int.Parse(Session["Second"].ToString());
            // Verify if the time didn't pass.
            if ((minutes == 0) && (hours == 0) && (seconds == 0))
            {
                // If the time is over, clear all settings and fields.
                // Also, show the message, notifying that the time is over.
                //timer1.Enabled = false;
                hours = 0;
                //minutes = int.Parse(Session["DurationInMinutes"].ToString());
                seconds = 0;
                //lblHr.Text = "00";
                lblMinute.Text = "00";
                lblSecond.Text = "00";
            }
            else
            {
                // Else continue counting.
                if (seconds < 1)
                {
                    seconds = 59;
                    if (minutes == 0)
                    {
                        minutes = 59;
                        if (hours != 0)
                            hours -= 1;

                    }
                    else
                    {
                        minutes -= 1;
                    }
                }
                else
                    seconds -= 1;

                Session["Minutes"] = minutes;
                Session["Second"] = seconds;
                // Display the current values of hours, minutes and seconds in
                // the corresponding fields.
                //lblHr.Text = hours.ToString();
                lblMinute.Text = minutes.ToString();
                lblSecond.Text = seconds.ToString();
                lblmultiViewActiveIndexId.Text = ViewState["multiViewActiveIndexId"].ToString();
                HiddenField1.Value = ViewState["multiViewActiveIndexId"].ToString();
                int mmin = int.Parse(Session["Minutes"].ToString());
                int s = int.Parse(Session["Second"].ToString());
                if (mmin == 0 && s == 0)
                {
                    var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
                    var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
                    var examId = int.Parse(Session["ExamId"].ToString());
                    int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
                    questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                    var allotedExamAnswerLogId = 0;
                    var previousquestionId = 0;
                    foreach (DataRow dr in questiondt.Rows)
                    {
                        var value = int.Parse(dr["SequenceNumber"].ToString());
                        if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                        {
                            previousquestionId = int.Parse(dr["QuestionId"].ToString());
                            allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                        }
                    }
                    DataTable previousquestiondb = new DataTable();
                    previousquestiondb = questionbll.GetQuestionaireById(previousquestionId);
                    #region updateAnswer
                    DataTable validationdb = new DataTable();
                    validationdb = questionbll.GetValidationByQuestionId(previousquestionId);
                    string enteredAnswer = "";
                    string errormessage = "";
                    int marks = 0;
                    Boolean isRequired = false;
                    //string validationAnswerType;
                    if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (!string.IsNullOrWhiteSpace(txtAnswer.Text))
                        {
                            enteredAnswer = txtAnswer.Text;
                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) != 0)
                            {
                                if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 1)
                                {
                                    int n;
                                    bool isNumeric = int.TryParse(txtAnswer.Text, out n);
                                    if (isNumeric)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                        {
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                            {
                                                if (int.Parse(txtAnswer.Text) > int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());

                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                            {
                                                if (int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                            {
                                                if (int.Parse(txtAnswer.Text) < int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                            {
                                                if (int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                            {
                                                if (int.Parse(txtAnswer.Text) == int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                            {
                                                if (int.Parse(txtAnswer.Text) != int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                            {
                                                if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= int.Parse(txtAnswer.Text) && int.Parse(txtAnswer.Text) >= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                            {
                                                if (int.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= int.Parse(txtAnswer.Text) || int.Parse(txtAnswer.Text) <= int.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                            {
                                                if (int.Parse(txtAnswer.Text) >= 0)
                                                {
                                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                }
                                                else
                                                {
                                                    marks = 0;
                                                }
                                            }
                                        }
                                    }
                                    double m;
                                    bool isDouble = double.TryParse(txtAnswer.Text, out m);
                                    if (!isNumeric)
                                    {
                                        if (isDouble)
                                        {
                                            if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                            {
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 1)
                                                {
                                                    if (double.Parse(txtAnswer.Text) > double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 2)
                                                {
                                                    if (double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 3)
                                                {
                                                    if (double.Parse(txtAnswer.Text) < double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 4)
                                                {
                                                    if (double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 5)
                                                {
                                                    if (double.Parse(txtAnswer.Text) == double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 6)
                                                {
                                                    if (double.Parse(txtAnswer.Text) != double.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 7)
                                                {
                                                    if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) >= double.Parse(txtAnswer.Text) && double.Parse(txtAnswer.Text) >= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 8)
                                                {
                                                    if (double.Parse(validationdb.Rows[0]["MaxValue"].ToString()) <= double.Parse(txtAnswer.Text) || double.Parse(txtAnswer.Text) <= double.Parse(validationdb.Rows[0]["MinValue"].ToString()))
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 9)
                                                {
                                                    enteredAnswer = txtAnswer.Text;
                                                }
                                                if (double.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 10)
                                                {
                                                    if (double.Parse(txtAnswer.Text) >= 0)
                                                    {
                                                        marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                                    }
                                                    else
                                                    {
                                                        marks = 0;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            marks = 0;
                                        }
                                    }
                                }
                                else if (int.Parse(validationdb.Rows[0]["ValidationAnswerTypeId"].ToString()) == 2)
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 11)
                                        {
                                            if (txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 12)
                                        {
                                            if (!txtAnswer.Text.Contains((validationdb.Rows[0]["ValueToCompare"].ToString())))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) != 0)
                                    {
                                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 13)
                                        {
                                            if (txtAnswer.Text.Length <= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                        if (int.Parse(validationdb.Rows[0]["ValidationAnswerId"].ToString()) == 14)
                                        {
                                            if (txtAnswer.Text.Length >= int.Parse(validationdb.Rows[0]["ValueToCompare"].ToString()))
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                            else
                                            {
                                                marks = 0;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            errormessage = "Answer is required";
                        }
                    }
                    else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (!string.IsNullOrWhiteSpace(txtparagraph.Text))
                        {
                            enteredAnswer = txtparagraph.Text;
                        }
                        else
                        {
                            errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (FileUpload1 != null && ViewState["enteredAnswer"].ToString() != "" && ViewState["enteredAnswer"].ToString() != null)
                        {

                            enteredAnswer = ViewState["enteredAnswer"].ToString();
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('please upload file')", true);
                        }
                    }
                    else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (RadioButtonList1.SelectedValue != null && RadioButtonList1.SelectedValue != "")
                        {
                            enteredAnswer = RadioButtonList1.SelectedItem.Text;
                            var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                            //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                            //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                            //int answerCount = 0;

                            foreach (var answerItem in correctAnswerSerializeData)
                            {
                                if (answerItem.Option == enteredAnswer)
                                {
                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                }
                            }
                        }
                        else
                        {
                            enteredAnswer = "";
                            //errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else if (int.Parse(previousquestiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (CheckBoxList1.SelectedValue != null || CheckBoxList1.SelectedValue != "")
                        {

                            List<string> YrStrList = new List<string>();
                            var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                            int answerCount = 0;
                            foreach (ListItem item in CheckBoxList1.Items)
                            {
                                foreach (var answerItem in correctAnswerSerializeData)
                                {
                                    if (item.Selected)
                                    {
                                        if (answerItem.Option == item.Value)
                                        {
                                            answerCount += 1;
                                            YrStrList.Add(item.Value);
                                            if (answerCount == correctAnswerSerializeData.Count)
                                            {
                                                marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                            }
                                        }
                                    }
                                }
                            }
                            String YrStr = String.Join(";", YrStrList.ToArray());
                            enteredAnswer = YrStr;
                        }
                        else
                        {
                            enteredAnswer = "";
                            // errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                        }
                    }
                    else
                    {
                        isRequired = Boolean.Parse(validationdb.Rows[0]["IsRequired"].ToString());
                        if (ddlanswer.SelectedValue != null || ddlanswer.SelectedValue != "")
                        {
                            enteredAnswer = ddlanswer.SelectedValue;
                            var correctAnswer = previousquestiondb.Rows[0]["CorrectOption"].ToString();
                            var correctAnswerSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(correctAnswer);
                            //var menuOptions = previousquestiondb.Rows[0]["QuestionOptionMetadata"].ToString();
                            //var menuOptionSerializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(menuOptions);
                            //int answerCount = 0;

                            foreach (var answerItem in correctAnswerSerializeData)
                            {
                                if (answerItem.Option == enteredAnswer)
                                {
                                    marks = int.Parse(previousquestiondb.Rows[0]["Marks"].ToString());
                                }
                            }
                        }
                        else
                        {
                            enteredAnswer = "";
                            //errormessage = validationdb.Rows[0]["ErrorMessage"].ToString();
                        }
                    }


                    var previousresult = questionbll.UpdateAllotedQuestionExamAnswerLog(enteredAnswer, marks, allotedExamAnswerLogId, numberOfExamAttempts);
                    if (previousresult > 0)
                    {
                        #region FinalSubmit
                        questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                        List<ExamAnswerLog> examAnswerLog = new List<ExamAnswerLog>();
                        examAnswerLog = (from DataRow dr in questiondt.Rows
                                         select new ExamAnswerLog()
                                         {
                                             ApplicationUserId = int.Parse(dr["ApplicationUserId"].ToString()),
                                             QuestionId = int.Parse(dr["QuestionId"].ToString()),
                                             ExamId = int.Parse(dr["ExamId"].ToString()),
                                             DepartmentStandardId = int.Parse(dr["DepartmentStandardId"].ToString()),
                                             CourseSubjectId = int.Parse(dr["CourseSubjectId"].ToString()),
                                             Answer = dr["Answer"].ToString() == "" ? "" : dr["Answer"].ToString(),
                                             SequenceNumber = int.Parse(dr["SequenceNumber"].ToString()),
                                             Marks = dr["Marks"].ToString() == "" ? 0 : int.Parse(dr["Marks"].ToString()),
                                         }).ToList();
                        numberOfExamAttempts += 1;

                        DataTable numberOfAttempts = new DataTable();
                        numberOfAttempts = questionbll.GetNumberOfExamAttemptsList(departmentstandardid, subjectCourseid, examId);
                        var attemptsCount = numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString() == "" ? 1 : int.Parse(numberOfAttempts.Rows[0]["NumberOfAttempts"].ToString()) + 1;

                        var result = questionbll.AddNewExamAnswer(examAnswerLog, attemptsCount);
                        if (result > 0)
                        {

                            var addNumberOfAttempts = questionbll.AddNumberOfExamAttemptsList(departmentstandardid, subjectCourseid, examId, attemptsCount);
                            if (addNumberOfAttempts > 0)
                            {
                                var attemptsinExamLog = questionbll.UpdateAllotedQuestionExamAnswerLogNumberOfAttempts(departmentstandardid, subjectCourseid, examId, attemptsCount);
                                //string url = "Exam.aspx";
                                //string s = "window.close('" + url + "', 'popup_window', 'width=100%,height=100%,resizable=yes');";
                                //ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
                                if (attemptsinExamLog > 0)
                                {
                                    var addnewResult = questionbll.AddNewStudentResult(departmentstandardid, subjectCourseid, examId, attemptsCount);
                                    if (addnewResult > 0)
                                    {
                                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Exam Done Sucessfully!')", true);
                                        Response.Redirect("Exam.aspx?value=TimeOut");
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
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                    }

                    #endregion
                }
                else
                {
                    var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
                    var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
                    var examId = int.Parse(Session["ExamId"].ToString());
                    int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
                    var examTime = exambll.UpdateExamCoveredTime(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts, int.Parse(lblMinute.Text), int.Parse(lblSecond.Text));
                }
                getProgressDetail();

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var answerTypeId = ViewState["multiViewActiveIndexId"].ToString();
            if (int.Parse(answerTypeId) == 2)
            {

            }
            else
            {
                var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
                var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
                var examId = int.Parse(Session["ExamId"].ToString());
                var userName = Session["UserName"].ToString();
                int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
                DataTable previousQuestiondt = new DataTable();
                previousQuestiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                List<int> questionList = new List<int>();
                var allotedExamAnswerLogId = 0;
                var previousquestionId = 0;
                var value = 0;
                foreach (DataRow dr in previousQuestiondt.Rows)
                {
                    questionList.Add(int.Parse(dr["QuestionId"].ToString()));
                    value = int.Parse(dr["SequenceNumber"].ToString());
                    if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                    {
                        previousquestionId = int.Parse(dr["QuestionId"].ToString());
                        allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                    }
                }

                int deleteResult = questionbll.DeletePreviousExamAnswerLog(allotedExamAnswerLogId);
                if (deleteResult > 0)
                {
                    DataTable newQuestion = new DataTable();
                    newQuestion = questionbll.GetNewQuestionList(departmentstandardid, subjectCourseid, examId);
                    List<Question> newQuestionList = new List<Question>();
                    //questionList = questiondt;
                    foreach (DataRow dataListItem in newQuestion.Rows)
                    {
                        if (!questionList.Contains(int.Parse(dataListItem["Id"].ToString())))
                        {
                            newQuestionList.Add(new Question
                            {
                                Id = int.Parse(dataListItem["Id"].ToString()),
                                ExamId = int.Parse(dataListItem["ExamId"].ToString())
                                ,
                                DepartmentStandardId = int.Parse(dataListItem["DepartmentStandardId"].ToString()),
                                CourseSubjectId = int.Parse(dataListItem["CourseSubjectId"].ToString())
                            });
                            break;
                        }
                    }
                    int currentSequenceValue = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    var result = questionbll.AddNewSingleAllotedQuestionExamAnswerLog(newQuestionList, numberOfExamAttempts, currentSequenceValue);
                    if (result > 0)
                    {
                        #region nextQuestion
                        int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                        questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                        var questionId = 0;
                        var previousAnswer = "";
                        foreach (DataRow dr in questiondt.Rows)
                        {
                            var sequenceno = int.Parse(dr["SequenceNumber"].ToString());
                            if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == sequenceno)
                            {
                                questionId = int.Parse(dr["QuestionId"].ToString());
                                previousAnswer = dr["Answer"].ToString();
                            }
                        }
                        DataTable questiondb = new DataTable();
                        questiondb = questionbll.GetQuestionaireById(questionId);
                        lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                        #region bindoptiondata
                        if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                        {
                            MultiView1.ActiveViewIndex = 0;
                            ViewState["multiViewActiveIndexId"] = 0;
                            if (previousAnswer != "")
                            {
                                txtAnswer.Text = previousAnswer;
                            }
                            else
                            {
                                txtAnswer.Text = "";
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                        {
                            MultiView1.ActiveViewIndex = 1;
                            ViewState["multiViewActiveIndexId"] = 1;
                            if (previousAnswer != "")
                            {
                                txtparagraph.Text = previousAnswer;
                            }
                            else
                            {
                                txtparagraph.Text = "";
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                        {
                            MultiView1.ActiveViewIndex = 2;
                            ViewState["multiViewActiveIndexId"] = 2;
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                        {
                            MultiView1.ActiveViewIndex = 3;
                            ViewState["multiViewActiveIndexId"] = 3;
                            List<OptionValue> optionValues = new List<OptionValue>();
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var rbtnvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = rbtnvalue != "" ? rbtnvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    foreach (var item in serializeData)
                                    {
                                        optionValues.Add(new OptionValue
                                        {
                                            DisplayText = item.Option,
                                            ValueText = item.Option
                                        });
                                    }
                                }
                            }
                            RadioButtonList1.DataSource = optionValues;
                            RadioButtonList1.DataTextField = "DisplayText";
                            RadioButtonList1.DataValueField = "ValueText";
                            RadioButtonList1.DataBind();
                            if (previousAnswer != "")
                            {
                                RadioButtonList1.SelectedValue = previousAnswer;
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                        {
                            MultiView1.ActiveViewIndex = 4;
                            ViewState["multiViewActiveIndexId"] = 4;
                            List<OptionValue> optionValues = new List<OptionValue>();
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var chkbxvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = chkbxvalue != "" ? chkbxvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    foreach (var item in serializeData)
                                    {
                                        optionValues.Add(new OptionValue
                                        {
                                            DisplayText = item.Option,
                                            ValueText = item.Option
                                        });
                                    }
                                }
                            }
                            CheckBoxList1.DataSource = optionValues;
                            CheckBoxList1.DataTextField = "DisplayText";
                            CheckBoxList1.DataValueField = "ValueText";
                            CheckBoxList1.DataBind();
                            if (previousAnswer != "")
                            {
                                string[] authorsList = previousAnswer.Split(';');
                                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                                {
                                    foreach (var chkbxvalueitem in authorsList)
                                    {
                                        if (chkbxvalueitem == CheckBoxList1.Items[i].Value)
                                        {
                                            CheckBoxList1.Items[i].Selected = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 5;
                            ViewState["multiViewActiveIndexId"] = 5;
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var ddlvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = ddlvalue != "" ? ddlvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    int iterationValue = 1;

                                    foreach (var item in serializeData)
                                    {
                                        ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                        iterationValue += 1;
                                    }
                                    ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                                }
                            }
                            if (previousAnswer != "")
                            {
                                ddlanswer.SelectedValue = previousAnswer;
                            }
                        }
                        #endregion

                        var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                        if (currentSequence == 1)
                        {
                            mltbutton.ActiveViewIndex = 0;
                        }
                        else if (currentSequence == lastSequenceNumber)
                        {
                            mltbutton.ActiveViewIndex = 2;
                        }
                        else
                        {
                            mltbutton.ActiveViewIndex = 1;
                        }
                        #endregion

                    }
                }
            }

        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            var answerTypeId = ViewState["multiViewActiveIndexId"].ToString();
            if (int.Parse(answerTypeId) == 2)
            {

            }
            else
            {
                var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
                var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
                var examId = int.Parse(Session["ExamId"].ToString());
                var userName = Session["UserName"].ToString();
                int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
                DataTable previousQuestiondt = new DataTable();
                previousQuestiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                List<int> questionList = new List<int>();
                var allotedExamAnswerLogId = 0;
                var previousquestionId = 0;
                var value = 0;
                foreach (DataRow dr in previousQuestiondt.Rows)
                {
                    questionList.Add(int.Parse(dr["QuestionId"].ToString()));
                    value = int.Parse(dr["SequenceNumber"].ToString());
                    if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == value)
                    {
                        previousquestionId = int.Parse(dr["QuestionId"].ToString());
                        allotedExamAnswerLogId = int.Parse(dr["Id"].ToString());
                    }
                }

                int deleteResult = questionbll.DeletePreviousExamAnswerLog(allotedExamAnswerLogId);
                if (deleteResult > 0)
                {
                    DataTable newQuestion = new DataTable();
                    newQuestion = questionbll.GetNewQuestionList(departmentstandardid, subjectCourseid, examId);
                    List<Question> newQuestionList = new List<Question>();
                    //questionList = questiondt;
                    foreach (DataRow dataListItem in newQuestion.Rows)
                    {
                        if (!questionList.Contains(int.Parse(dataListItem["Id"].ToString())))
                        {
                            newQuestionList.Add(new Question
                            {
                                Id = int.Parse(dataListItem["Id"].ToString()),
                                ExamId = int.Parse(dataListItem["ExamId"].ToString())
                                ,
                                DepartmentStandardId = int.Parse(dataListItem["DepartmentStandardId"].ToString()),
                                CourseSubjectId = int.Parse(dataListItem["CourseSubjectId"].ToString())
                            });
                            break;
                        }
                    }
                    int currentSequenceValue = int.Parse(ViewState["currentSequenceNumber"].ToString());
                    var result = questionbll.AddNewSingleAllotedQuestionExamAnswerLog(newQuestionList, numberOfExamAttempts, currentSequenceValue);
                    if (result > 0)
                    {
                        #region nextQuestion
                        int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
                        questiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
                        var questionId = 0;
                        var previousAnswer = "";
                        foreach (DataRow dr in questiondt.Rows)
                        {
                            var sequenceno = int.Parse(dr["SequenceNumber"].ToString());
                            if (int.Parse(ViewState["currentSequenceNumber"].ToString()) == sequenceno)
                            {
                                questionId = int.Parse(dr["QuestionId"].ToString());
                                previousAnswer = dr["Answer"].ToString();
                            }
                        }
                        DataTable questiondb = new DataTable();
                        questiondb = questionbll.GetQuestionaireById(questionId);
                        lblQuestion.Text = questiondb.Rows[0]["Question"].ToString();

                        #region bindoptiondata
                        if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 1)
                        {
                            MultiView1.ActiveViewIndex = 0;
                            ViewState["multiViewActiveIndexId"] = 0;
                            if (previousAnswer != "")
                            {
                                txtAnswer.Text = previousAnswer;
                            }
                            else
                            {
                                txtAnswer.Text = "";
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 2)
                        {
                            MultiView1.ActiveViewIndex = 1;
                            ViewState["multiViewActiveIndexId"] = 1;
                            if (previousAnswer != "")
                            {
                                txtparagraph.Text = previousAnswer;
                            }
                            else
                            {
                                txtparagraph.Text = "";
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 3)
                        {
                            MultiView1.ActiveViewIndex = 2;
                            ViewState["multiViewActiveIndexId"] = 2;
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 4)
                        {
                            MultiView1.ActiveViewIndex = 3;
                            ViewState["multiViewActiveIndexId"] = 3;
                            List<OptionValue> optionValues = new List<OptionValue>();
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var rbtnvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = rbtnvalue != "" ? rbtnvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    foreach (var item in serializeData)
                                    {
                                        optionValues.Add(new OptionValue
                                        {
                                            DisplayText = item.Option,
                                            ValueText = item.Option
                                        });
                                    }
                                }
                            }
                            RadioButtonList1.DataSource = optionValues;
                            RadioButtonList1.DataTextField = "DisplayText";
                            RadioButtonList1.DataValueField = "ValueText";
                            RadioButtonList1.DataBind();
                            if (previousAnswer != "")
                            {
                                RadioButtonList1.SelectedValue = previousAnswer;
                            }
                        }
                        else if (int.Parse(questiondb.Rows[0]["QuestionAnswerTypeId"].ToString()) == 5)
                        {
                            MultiView1.ActiveViewIndex = 4;
                            ViewState["multiViewActiveIndexId"] = 4;
                            List<OptionValue> optionValues = new List<OptionValue>();
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var chkbxvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = chkbxvalue != "" ? chkbxvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    foreach (var item in serializeData)
                                    {
                                        optionValues.Add(new OptionValue
                                        {
                                            DisplayText = item.Option,
                                            ValueText = item.Option
                                        });
                                    }
                                }
                            }
                            CheckBoxList1.DataSource = optionValues;
                            CheckBoxList1.DataTextField = "DisplayText";
                            CheckBoxList1.DataValueField = "ValueText";
                            CheckBoxList1.DataBind();
                            if (previousAnswer != "")
                            {
                                string[] authorsList = previousAnswer.Split(';');
                                for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                                {
                                    foreach (var chkbxvalueitem in authorsList)
                                    {
                                        if (chkbxvalueitem == CheckBoxList1.Items[i].Value)
                                        {
                                            CheckBoxList1.Items[i].Selected = true;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MultiView1.ActiveViewIndex = 5;
                            ViewState["multiViewActiveIndexId"] = 5;
                            foreach (DataRow dr in questiondb.Rows)
                            {
                                var ddlvalue = dr["QuestionOptionMetadata"].ToString();
                                string email = ddlvalue != "" ? ddlvalue : "";
                                var newValue = "";
                                if (email != "")
                                {
                                    var serializeData = JsonConvert.DeserializeObject<List<ObjectValue>>(email);
                                    int iterationValue = 1;

                                    foreach (var item in serializeData)
                                    {
                                        ddlanswer.Items.Insert(0, new ListItem(item.Option, item.Option.ToString()));
                                        iterationValue += 1;
                                    }
                                    ddlanswer.Items.Insert(0, new ListItem("-- Select Answer --", "0"));
                                }
                            }
                            if (previousAnswer != "")
                            {
                                ddlanswer.SelectedValue = previousAnswer;
                            }
                        }
                        #endregion

                        var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
                        if (currentSequence == 1)
                        {
                            mltbutton.ActiveViewIndex = 0;
                        }
                        else if (currentSequence == lastSequenceNumber)
                        {
                            mltbutton.ActiveViewIndex = 2;
                        }
                        else
                        {
                            mltbutton.ActiveViewIndex = 1;
                        }
                        #endregion

                    }
                }
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            var departmentstandardid = int.Parse(Session["DepartmentStandardId"].ToString());
            var subjectCourseid = int.Parse(Session["CourseSubjectId"].ToString());
            var examId = int.Parse(Session["ExamId"].ToString());
            var userName = Session["UserName"].ToString();
            int numberOfExamAttempts = int.Parse(Session["NumberOfExamAttempts"].ToString());
            DataTable previousQuestiondt = new DataTable();
            previousQuestiondt = questionbll.GetAllotedExamAnswerLogList(departmentstandardid, subjectCourseid, examId, numberOfExamAttempts);
            List<int> questionList = new List<int>();
            var allotedExamAnswerLogId = 0;
            var previousquestionId = 0;
            var value = 0;
            foreach (DataRow dr in previousQuestiondt.Rows)
            {
                questionList.Add(int.Parse(dr["Id"].ToString()));
            }
            int deletedResult = questionbll.DeletePreviousExamAnswerLogList(questionList);
            if (deletedResult > 0)
            {

            }

        }
        public void getProgressDetail()
        {
            int currentSequence = int.Parse(ViewState["currentSequenceNumber"].ToString());
            var lastSequenceNumber = int.Parse(ViewState["lastSequenceNumber"].ToString());
            //lblcurrentSequence.Text = currentSequence.ToString();
            //lbllastSequence.Text = lastSequenceNumber.ToString();

            lblmultiViewId.Text = lastSequenceNumber.ToString();
            lblPer1.Text = currentSequence.ToString();
            //double percent = (double)(currentSequence * 100) / lastSequenceNumber;
            //var percentageValue = Math.Ceiling(percent);
            //divprogress1.Style.Clear();
            //divprogress1.Style.Add("width", percentageValue + "%");
            //lblPer1.Text = percentageValue + "%";

        }
    }
}