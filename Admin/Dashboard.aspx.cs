using LMS.Admin.ClassFile;
using LMS.Admin.EventClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class Dashboard1 : System.Web.UI.Page
    {
        AdminBLL adminBLL = new AdminBLL();
        EventBLL eventBLL = new EventBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               // BuildSocialEventTable();
                getCountDetails();
            }
            
        }
        private void getCountDetails()
        {
            DataTable dt = new DataTable();
            dt = adminBLL.GetDashBoardDeatilForAdmin();
            if(dt.Rows.Count>0)
            {
                lblCourse.Text = dt.Rows[0]["CourseCount"].ToString();
                lblDepartment.Text = dt.Rows[0]["DepartmentCount"].ToString();
                lblFaculty.Text = dt.Rows[0]["LearnerCount"].ToString();
                lblStudent.Text = dt.Rows[0]["TraineeCount"].ToString();
            }
        }
        //private void BuildSocialEventTable()
        //{

        //    DataTable dt = new DataTable();
        //    dt = eventBLL.GetEventSessionChartDetail();
        //    Chart1.DataSource = dt;
        //    //double sumX = 0;
        //    //double sumY = 0;
        //    //foreach (DataPoint point in Chart1.Series[0].Points)
        //    //{
        //    //    sumX += point.XValue;
        //    //    sumY += point.YValues[0];
        //    //}
        //    Chart1.Titles.Add(String.Format("Upcoming Events."));
        //    Chart1.ChartAreas[0].AxisX.Title = "Date of Month";
        //    //Chart1.Titles.Add(String.Format("Upcoming Events."));
        //    Chart1.ChartAreas[0].AxisY.Title = "Number of Events";
        //    //Chart1.ChartAreas(0).AxisX.Title = "Employee Id";
        //    //Chart1.ChartAreas(0).AxisX.TitleAlignment = StringAlignment.Near;
        //    //Chart1.ChartAreas(0).AxisX.TextOrientation = TextOrientation.Horizontal;
        //}
        public class lineChart
        {
            public int Score { get; set; }
            public string MonthName { get; set; }
        }
    }
}