using LMS.Admin.ClassFile;
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
    public partial class AddLearner1 : System.Web.UI.Page
    {
        public static string Constr = ""; //ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        private static Random random = new Random();
        List<Qualification> qualifications = new List<Qualification>();
        Qualification bel = new Qualification();
        AdminBLL adminbll = new AdminBLL();
        ApplicationUser addNewUser = new ApplicationUser();
        DataTable dt;
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
                btnDocuments.BackColor = _color;
                btnDocuments.ForeColor = _otherbackcolor;
                //btnAssignStandard.BackColor = _color;
                bindlearnerddl();
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
            btnDocuments.BackColor = _color;
            btnDocuments.ForeColor = _otherbackcolor;
            //btnAssignStandard.BackColor = _color;
        }


        protected void btnDocuments_Click(object sender, EventArgs e)
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
            btnDocuments.BackColor = _backcolor;
            btnDocuments.ForeColor = _txtcolor;
            btnPersonalDetail.BackColor = _color;
            btnPersonalDetail.ForeColor = _otherbackcolor;
            //btnAssignStandard.BackColor = _color;
            //BindDocumentGridview();
        }

       

        //protected void btnAssignStandard_Click(object sender, EventArgs e)
        //{
        //    MultiView1.ActiveViewIndex = 2;
        //    string hex = "#8fcccc";
        //    Color _color = System.Drawing.ColorTranslator.FromHtml(hex);
        //    string forehex = "#000000";
        //    Color _txtcolor = System.Drawing.ColorTranslator.FromHtml(forehex);
        //    string backColor = "#f2f2f2";
        //    Color _backcolor = System.Drawing.ColorTranslator.FromHtml(backColor);
        //    btnAssignStandard.BackColor = _backcolor;
        //    btnAssignStandard.ForeColor = _txtcolor;
        //    btnPersonalDetail.BackColor = _color;
        //    btnDocuments.BackColor = _color;
        //}

        
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

        protected void Button9_Click(object sender, EventArgs e)
        {
            BLL objbll = new BLL();

            AdminBLL adminbll = new AdminBLL();


            objbll = new BLL();
            try
            {

                DataTable dtcheckUserExisting = new DataTable();
                dtcheckUserExisting = objbll.UserLogin(txtEmail.Text);
                if (dtcheckUserExisting.Rows.Count == 0)
                {
                    dt = new DataTable();
                    //var encryptedSaltKey = genrate_random_no();
                    //var encryptedString = AesOperation.EncryptString(encryptedSaltKey, txtEmail.Text);
                    addNewUser.FirstName = txtFirstName.Text;
                    addNewUser.LastName = txtLastName.Text;
                    addNewUser.EmailId = txtEmail.Text;
                    addNewUser.UserName = txtEmail.Text;
                    addNewUser.FatherName = txtFatherName.Text;
                    addNewUser.FatherContactNumber = txtFatherContactNumber.Text;
                    addNewUser.PresentAddess = txtpresentAddress.Text;
                    addNewUser.PresentCity = txtPresentCity.Text;
                    addNewUser.PresentState = txtPresentState.Text;
                    addNewUser.PermanentAddress = txtpermanentAddress.Text;
                    addNewUser.PermanentCity = txtpermanentCity.Text;
                    addNewUser.PermanentState = txtPermanentState.Text;
                    addNewUser.Gender = ddlGender.SelectedValue;
                    addNewUser.AdhaarCardNumber = txtadhaarNumber.Text;
                    addNewUser.PANCardNumber = null;

                    addNewUser.ContactNumber = txtContactNumber.Text;
                    addNewUser.NumberOfAttempts = 0;
                    addNewUser.PasswordHashKey = null;//encryptedString;
                    addNewUser.PasswordSaltKey = null;//encryptedSaltKey;
                    var result = adminbll.AddNewLearner(addNewUser);
                    if (result > 0)
                    {

                        var emailencryptedKey = AesOperation.EncryptString("pAudS4S3KD0idn#@!Qh5kSje35*kE4AS", txtEmail.Text);
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
                        msg.To.Add(txtEmail.Text.Trim());
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
                        txtFirstName.Text="";
                        txtLastName.Text="";
                        txtEmail.Text="";
                        txtFatherName.Text="";
                        txtFatherContactNumber.Text="";
                        txtpresentAddress.Text="";
                        txtPresentCity.Text="";
                        txtPresentState.Text="";
                        txtpermanentAddress.Text="";
                        txtpermanentCity.Text="";
                        txtPermanentState.Text="";
                        ddlGender.SelectedValue = "";
                        txtadhaarNumber.Text="";
                        txtContactNumber.Text="";
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Student Added Sucessfully')", true);
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
        public string genrate_random_no()
        {
            BLL objbll = new BLL();
            objbll = new BLL();
            bool condition;
            var c = "";

            c = RandomString();
            var tendantno = c.ToString();
            condition = objbll.VerifySaltKey(tendantno);

            while (condition == true)
            {
                c = RandomString();
                var newTendantno = c.ToString();
                var values = objbll.VerifySaltKey(newTendantno);
                if (!values)
                {
                    break;
                }
            }
            return (c).ToString();
        }
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789&%*^$!";
            return new string(Enumerable.Repeat(chars, 32)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            txtFatherName.Text = "";
            txtFatherContactNumber.Text = "";
            txtpresentAddress.Text = "";
            txtPresentCity.Text = "";
            txtPresentState.Text = "";
            txtpermanentAddress.Text = "";
            txtpermanentCity.Text = "";
            txtPermanentState.Text = "";
            ddlGender.SelectedValue = "";
            txtadhaarNumber.Text = "";
            txtContactNumber.Text = "";
        }
        public void bindlearnerddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetDDLLearner();
            ddlDocumentStudent.DataSource = dt;
            ddlDocumentStudent.DataBind();
            ddlDocumentStudent.DataTextField = "EmailId";
            ddlDocumentStudent.DataValueField = "ApplicationUserId";
            ddlDocumentStudent.DataBind();
            ddlDocumentStudent.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        protected void Button1_Click(object sender, EventArgs e)
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
                            int applicationUserId = int.Parse(ddlDocumentStudent.SelectedValue);
                            var filename = TranTrackid + "_" + applicationUserId.ToString() + "_" + count.ToString();
                            string clientFolderPath = Server.MapPath("../StudentDocumentsFile/" + applicationUserId.ToString() + "/");
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
                        var result = adminbll.UploadFileOnDocumentFileRequired(int.Parse(ddlDocumentStudent.SelectedValue), selectedvalue, 3);
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