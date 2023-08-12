﻿using LMS.Admin.ClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Learner
{
    public partial class LearnerMaster : System.Web.UI.MasterPage
    {
        AdminBLL adminBLL = new AdminBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var userName = Session["FirstAndLastName"].ToString();
                    var clientId = Session["ClientID"].ToString();
                    var applicationUserId = Session["ApplicationUserId"].ToString();
                    var role = Session["LogedInUserRole"].ToString();
                    DataTable dtrole = new DataTable();
                    dtrole = adminBLL.GetLogedInUserRole(clientId, int.Parse(applicationUserId));
                    DropDownList1.DataSource = dtrole;
                    DropDownList1.DataBind();
                    DropDownList1.DataTextField = "GroupName";
                    DropDownList1.DataValueField = "TenantGroupId";
                    DropDownList1.DataBind();

                    ListItem selectedListItem = DropDownList1.Items.FindByText(role);

                    if (selectedListItem != null)
                    {
                        selectedListItem.Selected = true;
                    }
                    Label1.Text = userName;
                    Boolean isGoogleSub = Boolean.Parse(Session["IsGoogleSubscription"].ToString());
                    if (isGoogleSub == true)
                    {
                        file.Visible = true;
                        eventdoc.Visible = true;
                    }
                    else
                    {
                        file.Visible = false;
                        eventdoc.Visible = false;
                    }
                    if (Session["IsFirstScreen"] == null)
                    {
                        Session["IsFirstScreen"] = "0";
                    }
                }
                ActiveIcon();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActiveIcon()
        {
            //class="active"
            string value=Session["IsFirstScreen"].ToString();
            if (value == "0")
            {
                page1.Attributes.Add("class", "active");
            }
            else if (value == "1")
            {
                page2.Attributes.Add("class", "active");
            }
            else if (value == "2")
            {
                file.Attributes.Add("class", "active");
            }
            else if (value == "3")
            {
                eventdoc.Attributes.Add("class", "active");
            }
            else if (value == "4")
            {
                page5.Attributes.Add("class", "active");
            }
            else if (value == "5")
            {
                page6.Attributes.Add("class", "active");
            }
            else if (value == "6")
            {
                page7.Attributes.Add("class", "active");
            }
            else if (value == "7")
            {
                page8.Attributes.Add("class", "active");
            }
            else if (value == "8")
            {
                page9.Attributes.Add("class", "active");
            }
            else
            {
                page1.Attributes.Add("class", "active");
            }
        }
        protected void functionName(object sender, EventArgs e)
        {
            //Response.Write("Hello World!!!");
            Session.Abandon();
            Response.Redirect("../Common/Login.aspx");
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedRoleName = DropDownList1.SelectedItem.ToString();
            if (selectedRoleName == "SuperAdmin")
            {
                Session["LogedInUserRole"] = "SuperAdmin";
                Response.Redirect("../SuperAdmin/Dashboard.aspx");
            }
            if (selectedRoleName == "Admin")
            {
                Session["LogedInUserRole"] = "Admin";
                Response.Redirect("../Admin/Dashboard.aspx");
            }
            else if (selectedRoleName == "Teacher")
            {
                Session["LogedInUserRole"] = "Teacher";
                Response.Redirect("../Trainee/Dashboard.aspx");
            }
            else if (selectedRoleName == "Learner")
            {
                Session["LogedInUserRole"] = "Learner";
                Response.Redirect("../Learner/Exam.aspx");
            }
        }
    }
}