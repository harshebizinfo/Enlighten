using LMS.Admin.ClassFile;
using LMS.Admin.DepartmentClassFile;
using LMS.Admin.DivisionClassFile;
using LMS.Admin.FeeClassFile;
using LMS.Admin.TransportClassFile;
using LMS.BasicClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class EditLearnerInDepartment : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        AdminBLL adminbll = new AdminBLL();
        DivisionBLL divisionBLL = new DivisionBLL();
        TransportBLL transportBLL = new TransportBLL();
        FeeBLL feeBLL = new FeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                binddepartmentddl();
                //bindlearnerddl();
                bindAreaddl();
                bindModeddl();
                bindCategoryddl();
                bindFeeMonthddl();
                //remainingDetail.enable = false;
                DataTable dt = new DataTable();
                int idValue = int.Parse(Session["EditLearnerInDepartmentId"].ToString());
                dt = adminbll.GETMappingApplicationUserIdAndDepartmentStandardByID(idValue);
                if (dt.Rows.Count > 0)
                {
                    string departmentName = dt.Rows[0]["DepartmentStandardName"].ToString();
                    ddllessonDepartment.SelectedValue = ddllessonDepartment.Items.FindByText(departmentName).Value;
                    string emailId = dt.Rows[0]["EmailId"].ToString();
                    int departmentNameId = int.Parse(dt.Rows[0]["DepartmentStandardId"].ToString());
                    DataTable divisiondt = new DataTable();
                    divisiondt = divisionBLL.GetDivisionUnderDepartmentId(departmentNameId);
                    ddlDivision.DataSource = divisiondt;
                    ddlDivision.DataBind();
                    ddlDivision.DataTextField = "Section";
                    ddlDivision.DataValueField = "Id";
                    ddlDivision.DataBind();
                    ddlDivision.Items.Insert(0, new ListItem("-- Select --", "0"));

                    DataTable studentdt = new DataTable();
                    studentdt = adminbll.GetStudentUnderDepartmentList(departmentNameId);
                    ddlStudentCourse.DataSource = studentdt;
                    ddlStudentCourse.DataBind();
                    ddlStudentCourse.DataTextField = "EmailId";
                    ddlStudentCourse.DataValueField = "ApplicationUserId";
                    ddlStudentCourse.DataBind();
                    ddlStudentCourse.Items.Insert(0, new ListItem("-- Select --", "0"));


                    ddlStudentCourse.SelectedValue = ddlStudentCourse.Items.FindByText(emailId).Value;
                    string division = dt.Rows[0]["Section"].ToString();
                    ddlDivision.SelectedValue = ddlDivision.Items.FindByText(division).Value;
                    string categoryName = dt.Rows[0]["CategoryName"].ToString();
                    ddlCategory.SelectedValue = ddlCategory.Items.FindByText(categoryName).Value;
                    string areaName = dt.Rows[0]["AreaName"].ToString();
                    int areaId = int.Parse(dt.Rows[0]["AreaId"].ToString());
                    ddlArea.SelectedValue = ddlArea.Items.FindByText(areaName).Value;
                    Boolean hasConveyance = Boolean.Parse(dt.Rows[0]["HasConveyance"].ToString());
                    Boolean isOneWayTrip = Boolean.Parse(dt.Rows[0]["IsOneWayTrip"].ToString());
                    CheckBox3.Checked = isOneWayTrip;
                    CheckBox1.Checked = hasConveyance;
                    if (hasConveyance == true)
                    {
                        string vehicleName = dt.Rows[0]["VehicleName"].ToString();
                        int modeId = int.Parse(dt.Rows[0]["ModeId"].ToString());
                        ddlMode.SelectedValue = ddlMode.Items.FindByText(vehicleName).Value;

                        DataTable pickUpdt = new DataTable();
                        pickUpdt = transportBLL.GetVehicleUnderModeOrArea(modeId, areaId);
                        ddlPickUpVehicle.DataSource = pickUpdt;
                        ddlPickUpVehicle.DataBind();
                        ddlPickUpVehicle.DataTextField = "VehicleNumber";
                        ddlPickUpVehicle.DataValueField = "Id";
                        ddlPickUpVehicle.DataBind();
                        ddlPickUpVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));

                        string pickUpVehicleNumber = dt.Rows[0]["PickUpVehicleNumber"].ToString();
                        ddlPickUpVehicle.SelectedValue = ddlPickUpVehicle.Items.FindByText(pickUpVehicleNumber).Value;


                        DataTable dropdt = new DataTable();
                        dropdt = transportBLL.GetVehicleUnderModeOrArea(modeId, areaId);
                        ddlDropVehicle.DataSource = dropdt;
                        ddlDropVehicle.DataBind();
                        ddlDropVehicle.DataTextField = "VehicleNumber";
                        ddlDropVehicle.DataValueField = "Id";
                        ddlDropVehicle.DataBind();
                        ddlDropVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));
                        string dropVehicleNumber = dt.Rows[0]["DropVehicleNumber"].ToString();
                        ddlDropVehicle.SelectedValue = ddlDropVehicle.Items.FindByText(dropVehicleNumber).Value;

                        DataTable monthdt = new DataTable();
                        monthdt = transportBLL.GetConveyanceMonthForStudent(int.Parse(ddlStudentCourse.SelectedValue), departmentNameId, int.Parse(ddlDivision.SelectedValue));
                        if(monthdt.Rows.Count>0)
                        {
                            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
                            {
                                foreach (DataRow value in monthdt.Rows)
                                {
                                    if ((value["MonthId"].ToString() == CheckBoxList1.Items[i].Value)&& Boolean.Parse(value["IsActive"].ToString())==true)
                                    {
                                        CheckBoxList1.Items[i].Selected = true;
                                    }
                                }
                            }
                        }
                    }
                    Boolean isPublished = Boolean.Parse(dt.Rows[0]["IsActive"].ToString());
                    CheckBox2.Checked = isPublished;
                }

            }
        }
        public void bindFeeMonthddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetFeeMonthMasterList("Active");

            foreach (DataRow dr in dt.Rows)
            {
                CheckBoxList1.Items.Add(new ListItem { Text = dr["FeeMonth"].ToString(), Value = dr["Id"].ToString() });
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            ddllessonDepartment.DataSource = dt;
            ddllessonDepartment.DataBind();
            ddllessonDepartment.DataTextField = "DepartmentStandardName";
            ddllessonDepartment.DataValueField = "Id";
            ddllessonDepartment.DataBind();
            ddllessonDepartment.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindlearnerddl()
        {
            DataTable dt = new DataTable();
            dt = adminbll.GetStudentUnderDepartmentList(int.Parse(ddllessonDepartment.SelectedValue));
            ddlStudentCourse.DataSource = dt;
            ddlStudentCourse.DataBind();
            ddlStudentCourse.DataTextField = "EmailId";
            ddlStudentCourse.DataValueField = "ApplicationUserId";
            ddlStudentCourse.DataBind();
            ddlStudentCourse.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindAreaddl()
        {
            DataTable dt = new DataTable();
            dt = transportBLL.GetAreaMasterList("Active");
            ddlArea.DataSource = dt;
            ddlArea.DataBind();
            ddlArea.DataTextField = "AreaName";
            ddlArea.DataValueField = "Id";
            ddlArea.DataBind();
            ddlArea.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindModeddl()
        {
            DataTable dt = new DataTable();
            dt = transportBLL.GetVehicleModeList("Active");
            ddlMode.DataSource = dt;
            ddlMode.DataBind();
            ddlMode.DataTextField = "VehicleName";
            ddlMode.DataValueField = "Id";
            ddlMode.DataBind();
            ddlMode.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindCategoryddl()
        {
            DataTable dt = new DataTable();
            dt = feeBLL.GetCategoryMasterList("Active");
            ddlCategory.DataSource = dt;
            ddlCategory.DataBind();
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "Id";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
        public void bindDivisionddl()
        {
            DataTable dt = new DataTable();
            dt = divisionBLL.GetDivisionUnderDepartmentId(int.Parse(ddllessonDepartment.SelectedValue));
            ddlDivision.DataSource = dt;
            ddlDivision.DataBind();
            ddlDivision.DataTextField = "Section";
            ddlDivision.DataValueField = "Id";
            ddlDivision.DataBind();
            ddlDivision.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        //protected void ddlStudentCourse_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (int.Parse(ddlStudentCourse.SelectedValue) > 0)
        //    {
        //        DataTable dt = new DataTable();
        //        dt = adminbll.GetApplicationUserById(int.Parse(ddlStudentCourse.SelectedValue));
        //        lblFName.Text = dt.Rows[0]["FirstName"].ToString();
        //        lblLName.Text = dt.Rows[0]["LastName"].ToString();
        //        lblEmail.Text = dt.Rows[0]["EmailId"].ToString();
        //        // lblcontactnumber.Text = dt.Rows[0]["ContactNumber"].ToString();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Proper Learner')", true);
        //    }
        //}

        protected void Button9_Click(object sender, EventArgs e)
        {
            List<AddConveyanceMonthForStudent> addConveyanceMonthForStudents = new List<AddConveyanceMonthForStudent>();
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        
                        addConveyanceMonthForStudents.Add(new
                            AddConveyanceMonthForStudent
                        {
                            ApplicationUserId = int.Parse(ddlStudentCourse.SelectedValue),
                            StandardId = int.Parse(ddllessonDepartment.SelectedValue),
                            DivisionId = int.Parse(ddlDivision.SelectedValue),
                            MonthId = int.Parse(item.Value.ToString()),
                            IsActive = true
                        });
                    }
                    else
                    {
                        addConveyanceMonthForStudents.Add(new
                            AddConveyanceMonthForStudent
                        {
                            ApplicationUserId = int.Parse(ddlStudentCourse.SelectedValue),
                            StandardId = int.Parse(ddllessonDepartment.SelectedValue),
                            DivisionId = int.Parse(ddlDivision.SelectedValue),
                            MonthId = item.Value.ToString() == "" ? 0 : int.Parse(item.Value.ToString()),
                            IsActive = false
                        });
                    }
                }
                int idValue = int.Parse(Session["EditLearnerInDepartmentId"].ToString());
                AddStudentInDepartment addStudentInDepartment = new AddStudentInDepartment();
                addStudentInDepartment.Id = idValue;
                addStudentInDepartment.DepartmentStandardId = int.Parse(ddllessonDepartment.SelectedValue);
                addStudentInDepartment.ApplicationUserId = int.Parse(ddlStudentCourse.SelectedValue);
                addStudentInDepartment.DivisionId = int.Parse(ddlDivision.SelectedValue);
                addStudentInDepartment.CategoryId = int.Parse(ddlCategory.SelectedValue);
                addStudentInDepartment.AreaId = int.Parse(ddlArea.SelectedValue);
                addStudentInDepartment.HasConveyance = CheckBox1.Checked == true ? true : false;
                addStudentInDepartment.ModeId = int.Parse(ddlMode.SelectedValue);
                addStudentInDepartment.PickUpVehicleNumber = ddlPickUpVehicle.SelectedItem.ToString();
                addStudentInDepartment.DropVehicleNumber = ddlDropVehicle.SelectedItem.ToString();
                addStudentInDepartment.PickUpVehicleId = int.Parse(ddlPickUpVehicle.SelectedValue);
                addStudentInDepartment.DropVehicleId = int.Parse(ddlDropVehicle.SelectedValue);
                addStudentInDepartment.IsActive = CheckBox2.Checked == true ? true : false;
                addStudentInDepartment.IsOneWayTrip = CheckBox3.Checked == true ? true : false;

                int deletedExisting = transportBLL.UpdateConveyanceMonthForStudent(int.Parse(ddlStudentCourse.SelectedValue), int.Parse(ddlDivision.SelectedValue), int.Parse(ddllessonDepartment.SelectedValue));

                int result = adminbll.EditMappingApplicationUserIdAndDepartmentStandard(addStudentInDepartment);
                if (result > 0)
                {
                    int monthResult = transportBLL.AddConveyanceMonthForStudent(addConveyanceMonthForStudents);
                    if (monthResult > 0)
                    {
                    int studenttransportresult = transportBLL.AddStudentTransportHistory(int.Parse(ddlArea.SelectedValue),
                        int.Parse(ddlMode.SelectedValue),
                        ddlPickUpVehicle.SelectedItem.ToString(),
                        int.Parse(ddlPickUpVehicle.SelectedValue),
                        ddlDropVehicle.SelectedItem.ToString(),
                        int.Parse(ddlDropVehicle.SelectedValue),
                        Convert.ToDateTime(txtDate.Text),
                        int.Parse(ddlStudentCourse.SelectedValue),
                        CheckBox1.Checked == true ? true : false,
                        CheckBox3.Checked == true ? true : false
                        );

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department/Standard and student are mapped sucessfully')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Standard and student are mapped but conveyance not added sucessfully')", true);
                    }
                    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Department/Standard and student are mapped sucessfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
        }

        protected void ddllessonDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindDivisionddl();
            bindlearnerddl();
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable pickUpdt = new DataTable();
            pickUpdt = transportBLL.GetVehicleUnderModeOrArea(int.Parse(ddlMode.SelectedValue), int.Parse(ddlArea.SelectedValue));
            ddlPickUpVehicle.DataSource = pickUpdt;
            ddlPickUpVehicle.DataBind();
            ddlPickUpVehicle.DataTextField = "VehicleNumber";
            ddlPickUpVehicle.DataValueField = "Id";
            ddlPickUpVehicle.DataBind();
            ddlPickUpVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));

            DataTable dropdt = new DataTable();
            dropdt = transportBLL.GetVehicleUnderModeOrArea(int.Parse(ddlMode.SelectedValue), int.Parse(ddlArea.SelectedValue));
            ddlDropVehicle.DataSource = dropdt;
            ddlDropVehicle.DataBind();
            ddlDropVehicle.DataTextField = "VehicleNumber";
            ddlDropVehicle.DataValueField = "Id";
            ddlDropVehicle.DataBind();
            ddlDropVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void ddlMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable pickUpdt = new DataTable();
            pickUpdt = transportBLL.GetVehicleUnderModeOrArea(int.Parse(ddlMode.SelectedValue), int.Parse(ddlArea.SelectedValue));
            ddlPickUpVehicle.DataSource = pickUpdt;
            ddlPickUpVehicle.DataBind();
            ddlPickUpVehicle.DataTextField = "VehicleNumber";
            ddlPickUpVehicle.DataValueField = "Id";
            ddlPickUpVehicle.DataBind();
            ddlPickUpVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));

            DataTable dropdt = new DataTable();
            dropdt = transportBLL.GetVehicleUnderModeOrArea(int.Parse(ddlMode.SelectedValue), int.Parse(ddlArea.SelectedValue));
            ddlDropVehicle.DataSource = dropdt;
            ddlDropVehicle.DataBind();
            ddlDropVehicle.DataTextField = "VehicleNumber";
            ddlDropVehicle.DataValueField = "Id";
            ddlDropVehicle.DataBind();
            ddlDropVehicle.Items.Insert(0, new ListItem("-- Select --", "0"));
        }
    }
}