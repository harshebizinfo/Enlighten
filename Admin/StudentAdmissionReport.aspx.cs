using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using LMS.Admin.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class StudentAdmissionReport : System.Web.UI.Page
    {
        AdminBLL bll = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            //Create document  
            Document doc = new Document();
            //Create PDF Table  
            PdfPTable tableLayout = new PdfPTable(8);
            //Create a PDF file in specific path  
            PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("StudentAdmissionReport.pdf"), FileMode.Create));
            //Open the PDF document  
            doc.Open();
            //Add Content to PDF  
            doc.Add(Add_Content_To_PDF(tableLayout));
            // Closing the document  
            doc.Close();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=StudentAdmissionReport.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(doc);
            Response.End();
            btnOpenPDF.Enabled = true;
            btnGenerateReport.Enabled = false;
        }
        protected void OnDownload(object sender, EventArgs e)
        {
            GeneratePDF();
            byte[] bytes = File.ReadAllBytes(Server.MapPath("~/Report.pdf"));
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Report.pdf");
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
        private void GeneratePDF()
        {
            string html = "<table cellpadding='5' cellspacing='0' style='border: 1px solid #ccc;font-size: 15pt'>";
            //html += "<tr><td>Name :</td><td style='width:120px;border: 1px solid #ccc'>" + txtName.Text.Trim() + "</td></tr>";
            //html += "<tr><td>Age  :</td><td style='width:120px;border: 1px solid #ccc'>" + txtAge.Text.Trim() + "</td></tr>";
            html += "</table>";
            using (FileStream stream = new FileStream(Server.MapPath("~/Report.pdf"), FileMode.OpenOrCreate))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                StringReader sr = new StringReader(html);
                XMLWorkerHelper.GetInstance().ParseXHtml(writer, pdfDoc, sr);
                pdfDoc.Close();
                stream.Close();
            }
        }
        private PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            DataTable dt = new DataTable();
            dt = bll.GetApplicationUserList();
            float[] headers = {
                                    12,
                                    12,
                                    12,
                                    12,
                                    12,
                                    12,
                                    12,
                                    12
                                }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 80; //Set the PDF File witdh percentage  
                                              //Add Title to the PDF file at the top  
            tableLayout.AddCell(new PdfPCell(new Phrase("Student Admission Report", new Font(Font.FontFamily.HELVETICA, 13, 1)))
            {
                Colspan = 8,
                Border = 0,
                PaddingBottom = 20,
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            //Add header  
            AddCellToHeader(tableLayout, "Student Name");
            AddCellToHeader(tableLayout, "Gender");
            AddCellToHeader(tableLayout, "Application Date");
            AddCellToHeader(tableLayout, "Present Address");
            AddCellToHeader(tableLayout, "Phone");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "Father Name");
            AddCellToHeader(tableLayout, "Father Contact");
            //Add body  
            foreach (DataRow dr in dt.Rows)
            {
                var studentName = dr["FirstName"].ToString() + " " + dr["LastName"].ToString();
                AddCellToBody(tableLayout, studentName);
                AddCellToBody(tableLayout, dr["Gender"].ToString());
                AddCellToBody(tableLayout, dr["CreatedOn"].ToString());
                AddCellToBody(tableLayout, dr["PresentAddess"].ToString());
                AddCellToBody(tableLayout, dr["ContactNumber"].ToString());
                AddCellToBody(tableLayout, dr["EmailId"].ToString());
                AddCellToBody(tableLayout, dr["FatherName"].ToString());
                AddCellToBody(tableLayout, dr["FatherContactNumber"].ToString());
            }
            return tableLayout;
        }
        // Method to add single cell to the header  
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor =BaseColor.WHITE
            });
        }
        // Method to add single cell to the body  
        private static void AddCellToBody(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Padding = 5,
                BackgroundColor = BaseColor.WHITE
            });
        }

        protected void btnOpenPDF_Click(object sender, EventArgs e)
        {
            //Open the PDF file  
            Process.Start(Server.MapPath("StudentAdmissionReport.pdf"));
            btnGenerateReport.Enabled = true;
            btnOpenPDF.Enabled = false;
        }
    }
}