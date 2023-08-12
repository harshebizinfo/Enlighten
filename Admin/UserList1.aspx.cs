using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class UserList1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //this.BindGrid();
            }
            BuildSocialEventTable();
        }
        private DataTable socialEvents;
        private void BuildSocialEventTable()
        {
            // to simulate a database query
            socialEvents = new DataTable();
            socialEvents.Columns.Add(new DataColumn("ApplicationUserId", typeof(int)));
            socialEvents.Columns.Add(new DataColumn("UserName", typeof(string)));
            socialEvents.Columns.Add(new DataColumn("FirstName", typeof(string)));
            socialEvents.Columns.Add(new DataColumn("Surname", typeof(string)));
            socialEvents.Columns.Add(new DataColumn("Roles", typeof(string)));


            DataRow row;
            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 1;
            row["FirstName"] = "Harsh";
            row["Surname"] = "Mishra";
            row["UserName"] = "Harsh.Mishra@gmail.com";
            row["Roles"] = "Admin";

            socialEvents.Rows.Add(row);

            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 2;
            row["FirstName"] = "Sumit";
            row["Surname"] = "Badada";
            row["UserName"] = "Sumit.Badada@gmail.com";
            row["Roles"] = "Trainee";

            socialEvents.Rows.Add(row);

            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 3;
            row["FirstName"] = "Seema";
            row["Surname"] = "Dixit";
            row["UserName"] = "Seema.Dixit@gmail.com";
            row["Roles"] = "Trainee";

            socialEvents.Rows.Add(row);

            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 4;
            row["FirstName"] = "Ravi";
            row["Surname"] = "Saroj";
            row["UserName"] = "Ravi.Saroj@gmail.com";
            row["Roles"] = "Trainee";

            socialEvents.Rows.Add(row);

            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 5;
            row["FirstName"] = "Kartik";
            row["Surname"] = "Joshi";
            row["UserName"] = "Kartik.Joshi@gmail.com";
            row["Roles"] = "Trainee";

            socialEvents.Rows.Add(row);

            row = socialEvents.NewRow();
            row["ApplicationUserId"] = 6;
            row["FirstName"] = "Kapil";
            row["Surname"] = "Singh";
            row["UserName"] = "Kapil.Singh@gmail.com";
            row["Roles"] = "Trainee";

            socialEvents.Rows.Add(row);

            System.Data.DataView view = socialEvents.DefaultView;
            GridView1.Visible = true;
            GridView1.DataSource = view;
            GridView1.DataBind();
        }
    }
}