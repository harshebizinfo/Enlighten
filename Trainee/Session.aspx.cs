using LMS.MiliciousFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Trainee
{
    public partial class Session : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<DateClass> repeaterValue = new List<DateClass>();
            List<int> monthDates = new List<int>();
            int currentYear = int.Parse(DateTime.Now.Year.ToString());
            //int currentMonth = int.Parse(DateTime.Now.Month.ToString());
            int MonthNumber = int.Parse(DateTime.Now.Month.ToString());
            int NumberOfDays = DateTime.DaysInMonth(currentYear, MonthNumber);
            for (int i = 1; i <= NumberOfDays; i++)
            {
                var currentMonthName = getAbbreviatedName(DateTime.Now.Month);
                repeaterValue.Add(new DateClass { MonthDay = i, CurrentMonthName = currentMonthName });
            }
            Repeater1.DataSource = repeaterValue;
            Repeater1.DataBind();
        }
        static string getAbbreviatedName(int month)
        {
            DateTime date = new DateTime(2020, month, 1);

            return date.ToString("MMM");
        }
      
    }
}