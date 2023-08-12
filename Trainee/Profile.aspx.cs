using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.BasicClass;
using LMS.Learner.BasicClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Profile1 : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        List<Qualification> qualifications = new List<Qualification>();
        Qualification bel = new Qualification();
        AdminBLL adminbll = new AdminBLL();
        DeptBLL deptbll = new DeptBLL();
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
                getPersonalDetails();
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
            TextBox8.Text = personalDetail.Rows[0]["PresentAddess"].ToString();
            TextBox9.Text = personalDetail.Rows[0]["PresentCity"].ToString();
            TextBox10.Text = personalDetail.Rows[0]["PresentState"].ToString();
            TextBox11.Text = personalDetail.Rows[0]["PermanentAddress"].ToString();
            TextBox12.Text = personalDetail.Rows[0]["PermanentCity"].ToString();
            TextBox13.Text = personalDetail.Rows[0]["PermanentState"].ToString();
            DropDownList1.SelectedValue = personalDetail.Rows[0]["Gender"].ToString();
            TextBox15.Text = personalDetail.Rows[0]["AdhaarCardNumber"].ToString();
            TextBox16.Text = personalDetail.Rows[0]["PANCardNumber"].ToString();
        }
        public void getBankDetails()
        {
            DataTable bankDetail = new DataTable();
            bankDetail = adminbll.GetBankDetailsByApplicationUserId();
            if (bankDetail.Rows.Count > 0)
            {
                TextBox26.Text = bankDetail.Rows[0]["BankName"].ToString();
                TextBox27.Text = bankDetail.Rows[0]["AccountNumber"].ToString();
                TextBox28.Text = bankDetail.Rows[0]["IFSCCode"].ToString();
                txtHolderName.Text = bankDetail.Rows[0]["AccountHolderName"].ToString();
                txtNickName.Text = bankDetail.Rows[0]["NickName"].ToString();
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
            getPersonalDetails();
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
            getBankDetails();
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
            getDepartmentStandard();
        }
        public void getDepartmentStandard()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetListOfDepartmentByUserId();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int applicationUserId = int.Parse(Session["ApplicationUserId"].ToString());
            bool hasFile = FileUpload1.HasFile;
            if (hasFile)
            {
                int filecount = 0;
                int fileuploadcount = 0;
                filecount = FileUpload1.PostedFiles.Count();

                if (filecount <= 5)
                {
                    Boolean isInvalid = false;
                    foreach (HttpPostedFile psFIle in FileUpload1.PostedFiles)
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
                        foreach (HttpPostedFile postedFile in FileUpload1.PostedFiles)
                        {
                            count += 1;
                            var fileUploadPath = postedFile.FileName;
                            string extension = System.IO.Path.GetExtension(postedFile.FileName);
                           // int applicationUserId = int.Parse(ddlEducationalTrainee.SelectedValue);
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
                        var result = adminbll.UploadFileOnDocumentFileRequired(applicationUserId, selectedvalue, 1);
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

        protected void Button6_Click(object sender, EventArgs e)
        {
            int applicationUserId = int.Parse(Session["ApplicationUserId"].ToString());
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
                            // int applicationUserId = int.Parse(ddlEducationalTrainee.SelectedValue);
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
                        var result = adminbll.UploadFileOnDocumentFileRequired(applicationUserId, selectedvalue, 2);
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
            int applicationUserId = int.Parse(Session["ApplicationUserId"].ToString());
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
                            // int applicationUserId = int.Parse(ddlEducationalTrainee.SelectedValue);
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
                        var result = adminbll.UploadFileOnDocumentFileRequired(applicationUserId, selectedvalue, 3);
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