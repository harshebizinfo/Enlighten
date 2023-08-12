using LMS.Admin.ClassFile;
using LMS.Admin.CourseClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.BasicClass;
using LMS.Common.ClassFile;
using LMS.Learner.BasicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AddTrainee1 : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        List<Qualification> qualifications = new List<Qualification>();
        Qualification bel = new Qualification();
        DataTable dt;
        ApplicationUser addNewUser = new ApplicationUser();
        AdminBLL adminbll = new AdminBLL();
        DeptBLL deptbll = new DeptBLL();
        CourseBLL coursebll = new CourseBLL();
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.ActiveViewIndex = 0;
                string hex = "#8fcccc";
                Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
                string forehex = "#000000";
                Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
                string backColor = "#f2f2f2";
                Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
                string otherbackColor = "#ffffff";
                Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
                btnPersonalDetail.BackColor = _backcolor;
                btnPersonalDetail.ForeColor = _txtcolor;
                btnEducation.BackColor = _color;
                btnEducation.ForeColor = _otherbackcolor;
                btnExperience.BackColor = _color;
                btnExperience.ForeColor = _otherbackcolor;
                btnDocuments.BackColor = _color;
                btnDocuments.ForeColor = _otherbackcolor;
                btnBankAccount.BackColor = _color;
                btnBankAccount.ForeColor = _otherbackcolor;
                btnAssignStandard.BackColor = _color;
                btnAssignStandard.ForeColor = _otherbackcolor;

            }
        }
        protected void btnPersonalDetail_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnPersonalDetail.BackColor = _backcolor;
            btnPersonalDetail.ForeColor = _txtcolor;
            btnEducation.BackColor = _color;
            btnEducation.ForeColor = _otherbackcolor;
            btnExperience.BackColor = _color;
            btnExperience.ForeColor = _otherbackcolor;
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            btnBankAccount.BackColor = _color;
            btnBankAccount.ForeColor = _otherbackcolor;
            btnAssignStandard.BackColor = _color;
            btnAssignStandard.ForeColor = _otherbackcolor;
        }

        protected void btnEducation_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnEducation.BackColor = _backcolor;
            btnEducation.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            btnExperience.BackColor = _color;
            btnExperience.ForeColor = _otherbackcolor;
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            btnBankAccount.BackColor = _color;
            btnBankAccount.ForeColor = _otherbackcolor;
            btnAssignStandard.BackColor = _color;
            btnAssignStandard.ForeColor = _otherbackcolor;
            // BindEducationGridview();
            bindEducationalTraineeddl();
        }
        public void bindEducationalTraineeddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLTrainee();
            ddlEducationalTrainee.DataSource = dt;
            ddlEducationalTrainee.DataBind();
            ddlEducationalTrainee.DataTextField = "EmailId";
            ddlEducationalTrainee.DataValueField = "ApplicationUserId";
            ddlEducationalTrainee.DataBind();
            ddlEducationalTrainee.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnExperience_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnExperience.BackColor = _backcolor;
            btnExperience.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            btnEducation.BackColor = _color;
            btnEducation.ForeColor = _otherbackcolor;
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            btnBankAccount.BackColor = _color;
            btnBankAccount.ForeColor = _otherbackcolor;
            btnAssignStandard.BackColor = _color;
            btnAssignStandard.ForeColor = _otherbackcolor;
            // BindExperienceGridview();
            bindExperienceTraineeddl();
        }
        public void bindExperienceTraineeddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLTrainee();
            ddlExperienceTrainee.DataSource = dt;
            ddlExperienceTrainee.DataBind();
            ddlExperienceTrainee.DataTextField = "EmailId";
            ddlExperienceTrainee.DataValueField = "ApplicationUserId";
            ddlExperienceTrainee.DataBind();
            ddlExperienceTrainee.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnDocuments_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 3;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnDocuments.BackColor = _backcolor;
            btnDocuments.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            btnEducation.BackColor = _color;
            btnEducation.ForeColor = _otherbackcolor;
            btnExperience.BackColor = _color;
            btnExperience.ForeColor = _otherbackcolor;
            btnBankAccount.BackColor = _color;
            btnBankAccount.ForeColor = _otherbackcolor;
            btnAssignStandard.BackColor = _color;
            btnAssignStandard.ForeColor = _otherbackcolor;
            //BindDocumentGridview();
            bindDocumentTraineeddl();
        }
        public void bindDocumentTraineeddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLTrainee();
            ddlDocumentTrainee.DataSource = dt;
            ddlDocumentTrainee.DataBind();
            ddlDocumentTrainee.DataTextField = "EmailId";
            ddlDocumentTrainee.DataValueField = "ApplicationUserId";
            ddlDocumentTrainee.DataBind();
            ddlDocumentTrainee.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnBankAccount_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 4;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnBankAccount.BackColor = _backcolor;
            btnBankAccount.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            btnEducation.BackColor = _color;
            btnEducation.ForeColor = _otherbackcolor;
            btnExperience.BackColor = _color;
            btnExperience.ForeColor = _otherbackcolor;
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            btnAssignStandard.BackColor = _color;
            btnAssignStandard.ForeColor = _otherbackcolor;
            bindlearnerddl();
        }

        public void bindlearnerddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLTrainee();
            ddltrainee.DataSource = dt;
            ddltrainee.DataBind();
            ddltrainee.DataTextField = "EmailId";
            ddltrainee.DataValueField = "ApplicationUserId";
            ddltrainee.DataBind();
            ddltrainee.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void btnAssignStandard_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 5;
            string hex = "#8fcccc";
            Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
            string forehex = "#000000";
            Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
            string backColor = "#f2f2f2";
            Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
            string otherbackColor = "#ffffff";
            Color _otherbackcolor = System.Drawing.ColorTranslator.FromHtml(otherbackColor);
            btnAssignStandard.BackColor = _backcolor;
            btnAssignStandard.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            btnEducation.BackColor = _color;
            btnEducation.ForeColor = _otherbackcolor;
            btnExperience.BackColor = _color;
            btnExperience.ForeColor = _otherbackcolor;
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            btnBankAccount.BackColor = _color;
            btnBankAccount.ForeColor = _otherbackcolor;
            bindTraineeddl();
            binddepartmentddl();
            //bindCourseddl();
            //bindTenantGroupddl();
        }
        public void bindTraineeddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLTrainee();
            ddlUserName.DataSource = dt;
            ddlUserName.DataBind();
            ddlUserName.DataTextField = "EmailId";
            ddlUserName.DataValueField = "ApplicationUserId";
            ddlUserName.DataBind();
            ddlUserName.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddlassigndepartmentStandard.DataSource = dt;
            ddlassigndepartmentStandard.DataBind();
            ddlassigndepartmentStandard.DataTextField = "DepartmentStandardName";
            ddlassigndepartmentStandard.DataValueField = "Id";
            ddlassigndepartmentStandard.DataBind();
            ddlassigndepartmentStandard.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindCourseddl()
        {
            DataTable dt = new DataTable();
            dt = coursebll.GetCourseUnderDepartment(int.Parse(ddlassigndepartmentStandard.SelectedValue));
            ddlassignCourseSubject.DataSource = dt;
            ddlassignCourseSubject.DataBind();
            ddlassignCourseSubject.DataTextField = "CourseSubjectName";
            ddlassignCourseSubject.DataValueField = "Id";
            ddlassignCourseSubject.DataBind();
            ddlassignCourseSubject.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        //public void bindTenantGroupddl()
        //{
        //    DataTable dt = new DataTable();
        //    dt = adminbll.GetDDLTenantRole();
        //    ddlassignRole.DataSource = dt;
        //    ddlassignRole.DataBind();
        //    ddlassignRole.DataTextField = "GroupName";
        //    ddlassignRole.DataValueField = "TenantGroupId";
        //    ddlassignRole.DataBind();
        //    ddlassignRole.Items.Insert(0, new ListItem("-- Select --", "0"));
        //}
        //Education
        [WebMethod]
        public static string SaveEducation(string educationdata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<EducationalObjectValue>>(educationdata);
            using (var con = new SqlConnection(Constr))
            {
                foreach (var data in serializeData)
                {
                    using (var cmd = new SqlCommand("INSERT INTO Employee01 VALUES(@Fname, @Lname,@Email,@CreatedDate)"))
                    {

                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.AddWithValue("@Fname", data.FName);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return null;
        }

        public class EducationalObjectValue
        {
            public string Qualification { get; set; }
            public string Percentage { get; set; }

        }

        //Experience
        [WebMethod]
        public static string SaveExperience(string experiencedata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<ExperienceObjectValue>>(experiencedata);
            using (var con = new SqlConnection(Constr))
            {
                foreach (var data in serializeData)
                {
                    using (var cmd = new SqlCommand("INSERT INTO Employee01 VALUES(@Fname, @Lname,@Email,@CreatedDate)"))
                    {

                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.AddWithValue("@Fname", data.FName);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return null;
        }

        public class ExperienceObjectValue
        {
            public string Organization { get; set; }
            public string ExperienceInMonth { get; set; }

        }

        //Documents
        [WebMethod]
        public static string SaveDocument(string documentdata)
        {
            var serializeData = JsonConvert.DeserializeObject<List<DocumentObjectValue>>(documentdata);
            using (var con = new SqlConnection(Constr))
            {
                foreach (var data in serializeData)
                {
                    using (var cmd = new SqlCommand("INSERT INTO Employee01 VALUES(@Fname, @Lname,@Email,@CreatedDate)"))
                    {

                        cmd.CommandType = CommandType.Text;
                        // cmd.Parameters.AddWithValue("@Fname", data.FName);
                        cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                        cmd.Connection = con;
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            return null;
        }

        public class DocumentObjectValue
        {
            public string DocumentName { get; set; }
            public string FilePath { get; set; }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();

            AdminBLL adminbll = new AdminBLL();


            objbll = new BLL();
            try
            {

                DataTable dtcheckUserExisting = new DataTable();
                dtcheckUserExisting = objbll.UserLogin(txtemail.Text);
                if (dtcheckUserExisting.Rows.Count == 0)
                {
                    dt = new DataTable();
                    //var encryptedSaltKey = genrate_random_no();
                    //var encryptedString = AesOperation.EncryptString(encryptedSaltKey, txtEmail.Text);
                    addNewUser.FirstName = txtFirstName.Text;
                    addNewUser.LastName = txtLastName.Text;
                    addNewUser.EmailId = txtemail.Text;
                    addNewUser.UserName = txtemail.Text;
                    addNewUser.FatherName = txtFatherName.Text;
                    addNewUser.FatherContactNumber = txtfathercontactNumber.Text;
                    addNewUser.PresentAddess = txtpresentAddress.Text;
                    addNewUser.PresentCity = txtpresentCity.Text;
                    addNewUser.PresentState = txtpresentstate.Text;
                    addNewUser.PermanentAddress = txtpermanentaddress.Text;
                    addNewUser.PermanentCity = txtpermanentCity.Text;
                    addNewUser.PermanentState = txtpermanentState.Text;
                    addNewUser.Gender = ddlGender.SelectedValue;
                    addNewUser.AdhaarCardNumber = txtadhaarnumber.Text;
                    addNewUser.PANCardNumber = null;

                    addNewUser.ContactNumber = txtContactNumber.Text;
                    addNewUser.NumberOfAttempts = 0;
                    addNewUser.PasswordHashKey = null;//encryptedString;
                    addNewUser.PasswordSaltKey = null;//encryptedSaltKey;
                    var result = adminbll.AddNewTrainee(addNewUser);
                    if (result > 0)
                    {

                        var emailencryptedKey = AesOperation.EncryptString("pAudS4S3KD0idn#@!Qh5kSje35*kE4AS", txtemail.Text);
                        var prefixPath = System.Configuration.ConfigurationManager.AppSettings["DownloadingFileLocationPath"].ToString();
                        string message = prefixPath+"/Common/SetPassword.aspx?e=@email";
                        string updatedMessage = message.Replace("@email", emailencryptedKey);



                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;

                        smtp.Credentials = new System.Net.NetworkCredential("Harsh@ebizinfo.in", "HarshMishra@123");
                        smtp.EnableSsl = true;
                        MailMessage msg = new MailMessage();
                        msg.Subject = "User Added Successfully";
                        msg.Body = updatedMessage;
                        msg.IsBodyHtml = true;
                        msg.To.Add(txtemail.Text.Trim());
                        string fromaddress = "PG <donotreply@oxotel.in>";
                        msg.From = new MailAddress(fromaddress);
                        try
                        {
                            smtp.Send(msg);
                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + ex.Message + "')", true);
                        }
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtemail.Text = "";
                        txtFatherName.Text = "";
                        txtfathercontactNumber.Text = "";
                        txtpresentAddress.Text = "";
                        txtpresentCity.Text = "";
                        txtpresentstate.Text = "";
                        txtpermanentaddress.Text = "";
                        txtpermanentCity.Text = "";
                        txtpermanentState.Text = "";
                        ddlGender.SelectedValue = "";
                        txtadhaarnumber.Text = "";
                        txtContactNumber.Text = "";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Trainee Added Sucessfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('EmailId already in used')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objbll = null;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtemail.Text = "";
            txtFatherName.Text = "";
            txtfathercontactNumber.Text = "";
            txtpresentAddress.Text = "";
            txtpresentCity.Text = "";
            txtpresentstate.Text = "";
            txtpermanentaddress.Text = "";
            txtpermanentCity.Text = "";
            txtpermanentState.Text = "";
            ddlGender.SelectedValue = "";
            txtadhaarnumber.Text = "";
            txtContactNumber.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            try
            {
                var result = adminbll.AddBankDetails(txtBankName.Text, txtAccountNumber.Text, txtIFSCCode.Text, int.Parse(ddltrainee.SelectedValue), txtHolderName.Text, txtNickName.Text);
                if (result > 0)
                {
                    txtBankName.Text = "";
                    txtAccountNumber.Text = "";
                    txtIFSCCode.Text = "";
                    txtHolderName.Text = "";
                    txtHolderName.Text = "";
                    txtNickName.Text = "";
                    txtReAccountNumber.Text = "";
                    txtReIFSCName.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Bank Details Added Sucessfully')", true);
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
                adminbll = null;
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            try
            {
                var result = adminbll.AssignTenantGroupDepartmentAndCourseToTrainee(int.Parse(ddlassigndepartmentStandard.SelectedValue), int.Parse(ddlassignCourseSubject.SelectedValue), int.Parse(ddlUserName.SelectedValue));
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Standard assigned Sucessfully')", true);
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
                adminbll = null;
            }
        }

        protected void ddlassigndepartmentStandard_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCourseddl();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool hasFile = FileUpload1.HasFile;
            if (hasFile)
            {
                int filecount = 0;
                int fileuploadcount = 0;
                filecount = FileUpload1.PostedFiles.Count();

                if (filecount <= 5)
                {
                    Boolean isInvalid = false;
                    foreach(HttpPostedFile psFIle in FileUpload1.PostedFiles)
                    {
                        string extension = System.IO.Path.GetExtension(psFIle.FileName);
                        if(extension!=".pdf")
                        {
                            isInvalid = true;
                        }
                    }
                    if (!isInvalid)
                    {
                        List<FileUploadList> optionAnswer = new List<FileUploadList>();
                        int count = 0;
                        foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                        {
                            count += 1;
                            var fileUploadPath = postedFile.FileName;
                            string extension = System.IO.Path.GetExtension(postedFile.FileName);
                            int applicationUserId = int.Parse(ddlEducationalTrainee.SelectedValue);
                            var filename = TranTrackid + "_" + applicationUserId.ToString() + "_" + count.ToString();
                            string clientFolderPath = Server.MapPath("../TraineeEducationalFile/" + applicationUserId.ToString() + "/");
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
                            var completeFileName = "../TraineeEducationalFile/" + applicationUserId.ToString() + "/" + filename.ToString() + extension;
                            optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                            completeFileName = "";
                        }
                        var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                        ViewState["enteredAnswer"] = selectedvalue;//"~/UploadedAnswerFile/" + filename.ToString() + extension;
                        var result = adminbll.UploadFileOnDocumentFileRequired(int.Parse(ddlEducationalTrainee.SelectedValue), selectedvalue, 1);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Uploaded Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Only .pdf file')", true);
                    }

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

        protected void Button2_Click(object sender, EventArgs e)
        {
            bool hasFile = FileUpload3.HasFile;
            if (hasFile)
            {
                int filecount = 0;
                int fileuploadcount = 0;
                filecount = FileUpload3.PostedFiles.Count();

                if (filecount <= 5)
                {
                    Boolean isInvalid = false;
                    foreach (HttpPostedFile psFIle in FileUpload3.PostedFiles)
                    {
                        string extension = System.IO.Path.GetExtension(psFIle.FileName);
                        if (extension != ".pdf")
                        {
                            isInvalid = true;
                        }
                    }
                    if (!isInvalid)
                    {
                        List<FileUploadList> optionAnswer = new List<FileUploadList>();
                        int count = 0;
                        foreach (HttpPostedFile postedFile in FileUpload3.PostedFiles)
                        {
                            count += 1;
                            var fileUploadPath = postedFile.FileName;
                            string extension = System.IO.Path.GetExtension(postedFile.FileName);
                            int applicationUserId = int.Parse(ddlDocumentTrainee.SelectedValue);
                            var filename = TranTrackid + "_" + applicationUserId.ToString() + "_" + count.ToString();
                            string clientFolderPath = Server.MapPath("../TraineeDocumentsFile/" + applicationUserId.ToString() + "/");
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
                            FileUpload3.SaveAs(clientFolderPath + filename.ToString() + extension);
                            var completeFileName = "../TraineeDocumentsFile/" + applicationUserId.ToString() + "/" + filename.ToString() + extension;
                            optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                            completeFileName = "";
                        }
                        var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                        ViewState["enteredAnswer"] = selectedvalue;//"~/UploadedAnswerFile/" + filename.ToString() + extension;
                        var result = adminbll.UploadFileOnDocumentFileRequired(int.Parse(ddlDocumentTrainee.SelectedValue), selectedvalue, 3);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Uploaded Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Only .pdf file')", true);
                    }

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

        protected void btnExperienceSubmit_Click(object sender, EventArgs e)
        {
            bool hasFile = FileUpload2.HasFile;
            if (hasFile)
            {
                int filecount = 0;
                int fileuploadcount = 0;
                filecount = FileUpload2.PostedFiles.Count();

                if (filecount <= 5)
                {
                    Boolean isInvalid = false;
                    foreach (HttpPostedFile psFIle in FileUpload2.PostedFiles)
                    {
                        string extension = System.IO.Path.GetExtension(psFIle.FileName);
                        if (extension != ".pdf")
                        {
                            isInvalid = true;
                        }
                    }
                    if (!isInvalid)
                    {
                        List<FileUploadList> optionAnswer = new List<FileUploadList>();
                        int count = 0;
                        foreach (HttpPostedFile postedFile in FileUpload2.PostedFiles)
                        {
                            count += 1;
                            var fileUploadPath = postedFile.FileName;
                            string extension = System.IO.Path.GetExtension(postedFile.FileName);
                            int applicationUserId = int.Parse(ddlExperienceTrainee.SelectedValue);
                            var filename = TranTrackid + "_" + applicationUserId.ToString() + "_" + count.ToString();
                            string clientFolderPath = Server.MapPath("../TraineeExperienceFile/" + applicationUserId.ToString() + "/");
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
                            FileUpload2.SaveAs(clientFolderPath + filename.ToString() + extension);
                            var completeFileName = "../TraineeExperienceFile/" + applicationUserId.ToString() + "/" + filename.ToString() + extension;
                            optionAnswer.Add(new FileUploadList { FileName = completeFileName });
                            completeFileName = "";
                        }
                        var selectedvalue = JsonConvert.SerializeObject(optionAnswer);
                        ViewState["enteredAnswer"] = selectedvalue;//"~/UploadedAnswerFile/" + filename.ToString() + extension;
                        var result = adminbll.UploadFileOnDocumentFileRequired(int.Parse(ddlExperienceTrainee.SelectedValue), selectedvalue, 2);
                        if (result > 0)
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('File Uploaded Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Only .pdf file')", true);
                    }

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
    }
}