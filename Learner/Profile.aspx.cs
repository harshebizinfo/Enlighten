using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class Profile : System.Web.UI.Page
    {
        AdminBLL adminbll = new AdminBLL();
        DeptBLL deptbll = new DeptBLL();
        ApplicationUser addNewUser = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getPersonalDetails();

                bindStudentDetail();
            }
        }
        public void getPersonalDetails()
        {
            DataTable personalDetail = new DataTable();
            var logedInUserId = int.Parse(Session["ApplicationUserId"].ToString());
            personalDetail = adminbll.GetApplicationUserById(logedInUserId);
            txtFirstName.Text = personalDetail.Rows[0]["FirstName"].ToString();
            txtLastName.Text = personalDetail.Rows[0]["LastName"].ToString();
            txtContactNumber.Text = personalDetail.Rows[0]["ContactNumber"].ToString();
            TextBox1.Text = personalDetail.Rows[0]["EmailId"].ToString();
            TextBox6.Text = personalDetail.Rows[0]["FatherName"].ToString();
            TextBox7.Text = personalDetail.Rows[0]["FatherContactNumber"].ToString();
            TextBox15.Text = personalDetail.Rows[0]["AdhaarCardNumber"].ToString();
        }
        public void bindtehseelddl(int tehseelId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetTehseelMasterList();
            ddltehseel.DataSource = dt;
            ddltehseel.DataBind();
            ddltehseel.DataTextField = "TehseelName";
            ddltehseel.DataValueField = "Id";
            ddltehseel.DataBind();
            ddltehseel.Items.Insert(0, new ListItem("-- Select --", "0"));

            ddltehseel.SelectedValue = tehseelId.ToString();
        }
        public void bindcityddl(int cityid)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetCityMasterList();
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
            ddlcity.DataTextField = "CityName";
            ddlcity.DataValueField = "Id";
            ddlcity.DataBind();
            ddlcity.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlcity.SelectedValue = cityid.ToString();
        }
        public void bindMediumddl(int mediumId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetMediumMasterList();
            ddlprevMedium.DataSource = dt;
            ddlprevMedium.DataBind();
            ddlprevMedium.DataTextField = "MediumName";
            ddlprevMedium.DataValueField = "Id";
            ddlprevMedium.DataBind();
            ddlprevMedium.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlprevMedium.SelectedValue = mediumId.ToString();
        }
        public void bindStreamddl(int streamId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetStreamMasterList();
            ddlprevStream.DataSource = dt;
            ddlprevStream.DataBind();
            ddlprevStream.DataTextField = "StreamName";
            ddlprevStream.DataValueField = "Id";
            ddlprevStream.DataBind();
            ddlprevStream.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlprevStream.SelectedValue = streamId.ToString();
        }
        public void bindprevClassddl(int classid)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlPrevClass.DataSource = dt;
            ddlPrevClass.DataBind();
            ddlPrevClass.DataTextField = "DepartmentStandardName";
            ddlPrevClass.DataValueField = "Id";
            ddlPrevClass.DataBind();
            ddlPrevClass.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlPrevClass.SelectedValue = classid.ToString();
        }
        public void bindFatherEducationddl(int educationId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetEducationMasterList();
            ddlFatherEducation.DataSource = dt;
            ddlFatherEducation.DataBind();
            ddlFatherEducation.DataTextField = "EducationName";
            ddlFatherEducation.DataValueField = "Id";
            ddlFatherEducation.DataBind();
            ddlFatherEducation.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlFatherEducation.SelectedValue = educationId.ToString();
        }
        public void bindFatherOccupationddl(int occupationId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetOccupationMasterList();
            ddlFatherOccupation.DataSource = dt;
            ddlFatherOccupation.DataBind();
            ddlFatherOccupation.DataTextField = "OccupationName";
            ddlFatherOccupation.DataValueField = "Id";
            ddlFatherOccupation.DataBind();
            ddlFatherOccupation.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlFatherOccupation.SelectedValue = occupationId.ToString();
        }
        public void bindMotherEducationddl(int educationId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetEducationMasterList();
            ddlMotherEducation.DataSource = dt;
            ddlMotherEducation.DataBind();
            ddlMotherEducation.DataTextField = "EducationName";
            ddlMotherEducation.DataValueField = "Id";
            ddlMotherEducation.DataBind();
            ddlMotherEducation.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlMotherEducation.SelectedValue = educationId.ToString();
        }
        public void bindMotherOccupationddl(int occupationId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetOccupationMasterList();
            ddlMotherOccupation.DataSource = dt;
            ddlMotherOccupation.DataBind();
            ddlMotherOccupation.DataTextField = "OccupationName";
            ddlMotherOccupation.DataValueField = "Id";
            ddlMotherOccupation.DataBind();
            ddlMotherOccupation.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlMotherOccupation.SelectedValue = occupationId.ToString();
        }
        public void bindDocumentMasterddl(int documentId)
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDocumentMasterList();
            ddlDocument.DataSource = dt;
            ddlDocument.DataBind();
            ddlDocument.DataTextField = "DocumentName";
            ddlDocument.DataValueField = "Id";
            ddlDocument.DataBind();
            ddlDocument.Items.Insert(0, new ListItem("-- Select --", "0"));
            ddlDocument.SelectedValue = documentId.ToString();
        }
        public void bindStudentDetail()
        {
            string language = "";
            string nationality = "";
            int tehseelid = 0;
            int cityId = 0;
            int prevStreamid = 0;
            int prevclassId = 0;
            int prevMediumId = 0;
            int fathereducationId = 0;
            int fatherOccupationId = 0;
            int mothereducationId = 0;
            int motherOccupationId = 0;
            int documentId = 0;
            Boolean isPreviousSchoolIncluded = false;
            Boolean isSibilingsIncluded = false;
            DataTable dt = new DataTable();
            dt = deptbll.GetStudentInformationList();
            if (dt.Rows.Count > 0)
            {
                Session["AdmissionNumber"] = dt.Rows[0]["AdmissionNumber"].ToString();
                language = dt.Rows[0]["Language"].ToString();
                nationality = dt.Rows[0]["Nationality"].ToString();
                tehseelid = int.Parse(dt.Rows[0]["TehseelId"].ToString());
                cityId = int.Parse(dt.Rows[0]["CityId"].ToString());
                txtPevSchoolName.Text = dt.Rows[0]["PrevSchoolName"].ToString();
                prevStreamid = int.Parse(dt.Rows[0]["PrevStreamId"].ToString() == "" ? "0" : dt.Rows[0]["PrevStreamId"].ToString());
                prevclassId = int.Parse(dt.Rows[0]["PrevClassId"].ToString() == "" ? "0" : dt.Rows[0]["PrevClassId"].ToString());
                prevMediumId = int.Parse(dt.Rows[0]["PrevMediumId"].ToString() == "" ? "0" : dt.Rows[0]["PrevMediumId"].ToString());
                txtPrevMarks.Text = dt.Rows[0]["PrevMarks"].ToString();
                txtPrevTotalMarks.Text = dt.Rows[0]["PrevTotalMarks"].ToString();
                txtprevAddress.Text = dt.Rows[0]["PrevAddress"].ToString();
                txtFatherName.Text = dt.Rows[0]["FatherName"].ToString();
                txtFatherPhone.Text = dt.Rows[0]["FatherPhone"].ToString();
                fathereducationId = int.Parse(dt.Rows[0]["FatherEducationId"].ToString() == "" ? "0" : dt.Rows[0]["FatherEducationId"].ToString());
                fatherOccupationId = int.Parse(dt.Rows[0]["FatherOccupationId"].ToString() == "" ? "0" : dt.Rows[0]["FatherOccupationId"].ToString());
                txtFatherAddress.Text = dt.Rows[0]["FatherAddress"].ToString();
                txtMotherName.Text = dt.Rows[0]["MotherName"].ToString();
                txtMotherPhone.Text = dt.Rows[0]["MotherPhone"].ToString();
                mothereducationId = int.Parse(dt.Rows[0]["MotherEducationId"].ToString() == "" ? "0" : dt.Rows[0]["MotherEducationId"].ToString());
                motherOccupationId = int.Parse(dt.Rows[0]["MotherOccupationId"].ToString() == "" ? "0" : dt.Rows[0]["MotherOccupationId"].ToString());
                txtMotherAddress.Text = dt.Rows[0]["MotherAddress"].ToString();
                txtGuardianName.Text = dt.Rows[0]["GuardianName"].ToString();
                txtGuardianPhone.Text = dt.Rows[0]["GuardianPhone"].ToString();
                txtGuardianRelationship.Text = dt.Rows[0]["GuardianRelationShip"].ToString();
                txtGuardianAddress.Text = dt.Rows[0]["GuardianAddress"].ToString();
                documentId = int.Parse(dt.Rows[0]["DocumentsId"].ToString());
                isPreviousSchoolIncluded = Boolean.Parse(dt.Rows[0]["IsPreviousSchoolIncluded"].ToString());
                isSibilingsIncluded = Boolean.Parse(dt.Rows[0]["IsSibilingsIncluded"].ToString());
            }
            bindtehseelddl(tehseelid);
            bindcityddl(cityId);
            bindMediumddl(prevMediumId);
            bindStreamddl(prevStreamid);
            bindprevClassddl(prevclassId);
            bindFatherEducationddl(fathereducationId);
            bindFatherOccupationddl(fatherOccupationId);
            bindMotherEducationddl(mothereducationId);
            bindMotherOccupationddl(motherOccupationId);
            bindDocumentMasterddl(documentId);
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            try
            {
                StudentDetailModel sdm = new StudentDetailModel();
                var editApplicationUserLearnerId = Session["ApplicationUserId"].ToString();
                sdm.ApplicationUserId = int.Parse(editApplicationUserLearnerId);
                sdm.FirstName = txtFirstName.Text;
                sdm.LastName = txtLastName.Text;
                sdm.EmailId = TextBox1.Text;
                sdm.FatherName = TextBox6.Text;
                sdm.FatherContactNumber = TextBox7.Text;
                sdm.PresentAddess = "";
                sdm.PresentCity = "";
                sdm.PresentState = "";
                sdm.PermanentAddress = "";
                sdm.PermanentCity = "";
                sdm.PermanentState = "";
                sdm.ContactNumber = txtContactNumber.Text;
                sdm.AdmissionNumber = Session["AdmissionNumber"].ToString();
                sdm.Language = ddlLanguage.SelectedValue.ToString();
                sdm.Nationality = ddlnationality.SelectedValue.ToString();
                sdm.TehseelId = int.Parse(ddltehseel.SelectedValue.ToString());
                sdm.CityId = int.Parse(ddlcity.SelectedValue.ToString());
                sdm.PrevSchoolName = txtPevSchoolName.Text;
                sdm.PrevStreamId = int.Parse(ddlprevStream.SelectedValue.ToString());
                sdm.PrevClassId = int.Parse(ddlPrevClass.SelectedValue.ToString());
                sdm.PrevMediumId = int.Parse(ddlprevMedium.SelectedValue.ToString());
                sdm.PrevMarks = double.Parse(txtPrevMarks.Text==""?"0":txtPrevMarks.Text);
                sdm.PrevTotalMarks = double.Parse(txtPrevTotalMarks.Text==""?"0": txtPrevTotalMarks.Text);
                sdm.PrevAddress = txtprevAddress.Text;
                sdm.FatherName = txtFatherName.Text;
                sdm.FatherPhone = txtFatherPhone.Text;
                sdm.FatherEducationId = int.Parse(ddlFatherEducation.SelectedValue.ToString());
                sdm.FatherOccupationId = int.Parse(ddlFatherOccupation.SelectedValue.ToString());
                sdm.FatherAddress = txtFatherAddress.Text;
                sdm.MotherName = txtMotherName.Text;
                sdm.MotherPhone = txtMotherPhone.Text;
                sdm.MotherEducationId = int.Parse(ddlMotherEducation.SelectedValue.ToString());
                sdm.MotherOccupationId = int.Parse(ddlMotherOccupation.SelectedValue.ToString());
                sdm.MotherAddress = txtMotherAddress.Text;
                sdm.GuardianName = txtGuardianName.Text;
                sdm.GuardianPhone = txtGuardianPhone.Text;
                sdm.GuardianRelationShip = txtGuardianRelationship.Text;
                sdm.GuardianAddress = txtGuardianAddress.Text;
                sdm.DocumentsId = int.Parse(ddlDocument.SelectedValue.ToString());
                sdm.IsPreviousSchoolIncluded = chkbIsPreviousSchool.Checked == true ? true : false;
                sdm.IsSibilingsIncluded = IsSibilingsIncluded.Checked == true ? true : false;


                var result = adminbll.UpdatedStudentDetailApplicationUserById(sdm);
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your Details Updated Sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Email is already In use')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtContactNumber.Text = "";
            TextBox1.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            TextBox15.Text = "";
        }
    }
}