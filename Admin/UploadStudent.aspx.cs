using LMS.Admin.ClassFile;
using LMS.BasicClass;
using LMS.Common.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class UploadStudent : System.Web.UI.Page
    {
        string TranTrackid = Convert.ToDateTime(DateTime.Now).ToString("yyyyMMddhhmmss");
        ApplicationUser addNewUser = new ApplicationUser();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles == true)
            {
                var exten = System.IO.Path.GetExtension(FileUpload1.FileName);
                if (exten == ".xlsx")
                {
                    AdminBLL adminbll = new AdminBLL();
                    BLL objbll = new BLL();

                    var clientId = Session["ClientID"].ToString();
                    var newFile = clientId;
                    string clientFolderPath = Server.MapPath("LearnerExcelFile/" + clientId + "/");
                    if (!Directory.Exists(clientFolderPath))
                    {
                        //If Directory (Folder) does not exists. Create it.
                        Directory.CreateDirectory(clientFolderPath);
                    }
                    var extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    var completeFileName = clientFolderPath + TranTrackid + extension;
                    FileUpload1.SaveAs(completeFileName);
                    string sheet1 = string.Empty;
                    string excel_path = completeFileName;
                    // create connection with excel database  
                    OleDbConnection my_con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel_path + ";Extended Properties='Excel 12.0;HDR=NO'");
                    var path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel_path + ";Extended Properties='Excel 12.0;HDR=NO'";
                    path = string.Format(path, excel_path);
                    using (OleDbConnection excel_con = new OleDbConnection(path))
                    {
                        excel_con.Open();
                        sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();

                        //my_con.Open();
                        try
                        {

                            DataTable dt = new DataTable();
                            // get the excel file data and assign it in OleDbcoomad object(o_cmd) 
                            OleDbCommand o_cmd = new OleDbCommand("select * from [" + sheet1 + "]", excel_con);
                            //create oledbdataadapter object
                            OleDbDataAdapter da = new OleDbDataAdapter();
                            // pass o_cmd data to da object
                            da.SelectCommand = o_cmd;
                            //create a dataset object ds
                            DataSet ds = new DataSet();
                            // Assign da object data to dataset (virtual table) 
                            da.Fill(ds);
                            // assign dataset data to gridview control  
                            dt = ds.Tables[0];
                            dt.Rows.Remove(dt.Rows[0]);
                            int count = 0;
                            List<ApplicationUser> alreadyExisting = new List<ApplicationUser>();
                            foreach (DataRow item in dt.Rows)
                            {
                                DataTable dtcheckUserExisting = new DataTable();
                                dtcheckUserExisting = objbll.UserLogin(item[3].ToString());
                                if (dtcheckUserExisting.Rows.Count == 0)
                                {
                                    addNewUser.FirstName = item[0].ToString();
                                    addNewUser.LastName = item[1].ToString();
                                    addNewUser.EmailId = item[3].ToString();
                                    addNewUser.UserName = item[4].ToString();
                                    addNewUser.FatherName = item[5].ToString();
                                    addNewUser.FatherContactNumber = item[6].ToString();
                                    addNewUser.PresentAddess = item[7].ToString();
                                    addNewUser.PresentCity = item[8].ToString();
                                    addNewUser.PresentState = item[9].ToString();
                                    addNewUser.PermanentAddress = item[10].ToString();
                                    addNewUser.PermanentCity = item[11].ToString();
                                    addNewUser.PermanentState = item[12].ToString();
                                    addNewUser.Gender = item[13].ToString();
                                    addNewUser.AdhaarCardNumber = item[14].ToString();
                                    addNewUser.PANCardNumber = null;
                                    addNewUser.ContactNumber = item[2].ToString();
                                    addNewUser.NumberOfAttempts = 0;
                                    addNewUser.PasswordHashKey = "L+GjfpAx7MrwhtjWcnL8jw==";
                                    addNewUser.PasswordSaltKey = "KOWD$4V3FKI7QF^&WY752UG5ECANF6CN";
                                    var result = adminbll.AddNewLearner(addNewUser);
                                    if (result > 0)
                                    {
                                        count += 1;
                                    }
                                }
                                else
                                {
                                    alreadyExisting.Add(new ApplicationUser
                                    {
                                        FirstName = item[0].ToString(),
                                        LastName = item[1].ToString(),
                                        EmailId = item[3].ToString(),
                                        UserName = item[4].ToString(),
                                        FatherName = item[5].ToString(),
                                        FatherContactNumber = item[6].ToString(),
                                        PresentAddess = item[7].ToString(),
                                        PresentCity = item[8].ToString(),
                                        PresentState = item[9].ToString(),
                                        PermanentAddress = item[10].ToString(),
                                        PermanentCity = item[11].ToString(),
                                        PermanentState = item[12].ToString(),
                                        Gender = item[13].ToString(),
                                        AdhaarCardNumber = item[14].ToString(),
                                        PANCardNumber = null,
                                        ContactNumber = item[2].ToString(),
                                        NumberOfAttempts = 0,
                                        PasswordHashKey = "L+GjfpAx7MrwhtjWcnL8jw==",
                                        PasswordSaltKey = "KOWD$4V3FKI7QF^&WY752UG5ECANF6CN",
                                    });
                                }
                            }
                            if (count > 0)
                            {
                                Label1.Visible = true;
                                Label1.ForeColor = Color.Green;
                                Label1.Text = "Data Uploaded Sucessfully";
                            }
                            Label2.Visible = true;
                            Label2.ForeColor = Color.Black;
                            Label2.Text = "UnSaved Student List";

                            GridView1.DataSource = alreadyExisting;
                            GridView1.DataBind();
                            excel_con.Close();
                        }
                        catch (Exception ex)
                        {

                        }
                        excel_con.Close();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please choose file with xlsx format.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), "alert('Please choose proper File.');", true);
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[2].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[3].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[5].HorizontalAlign = HorizontalAlign.Left;
                e.Row.Cells[1].CssClass = "columnwidth";
                e.Row.Cells[2].CssClass = "columnwidth";
                e.Row.Cells[3].CssClass = "columnwidth";
                e.Row.Cells[4].CssClass = "columnwidth";
                e.Row.Cells[5].CssClass = "columnwidth";
            }
        }
    }
}