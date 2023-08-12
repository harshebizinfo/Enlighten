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
    public partial class AddVehicle : System.Web.UI.Page
    {
        TransportBLL transportBLL = new TransportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                binddepartmentddl();
            }
        }
        public void binddepartmentddl()
        {
            DataTable dt = new DataTable();
            dt = transportBLL.GetVehicleModeList("Active");
            ddlVehicleMode.DataSource = dt;
            ddlVehicleMode.DataBind();
            ddlVehicleMode.DataTextField = "VehicleName";
            ddlVehicleMode.DataValueField = "Id";
            ddlVehicleMode.DataBind();
            ddlVehicleMode.Items.Insert(0, new ListItem("-- Select --", "0"));
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Boolean checkedValue = false;
            if(CheckBox1.Checked==true)
            {
                checkedValue = true;
            }
            AddVehicleList vehicleList = new AddVehicleList();
            vehicleList.VehicleNumber = txtVehicleNumber.Text;
            vehicleList.VehicleDescription = txtVehicleDescription.Text;
            vehicleList.PickUpDriverName = txtPickUpDriverName.Text;
            vehicleList.PickUpDriverAddress = txtPickUpDriverAddress.Text;
            vehicleList.PickUpDriverContactNumber = txtPickUpDriverContactNumber.Text;
            vehicleList.PickUpDriverAdhaarNumber = txtPickUpDriverAdhaarNumber.Text;
            vehicleList.DropDriverName = txtDropDriverName.Text;
            vehicleList.DropDriverAddress = txtDropDriverAddress.Text;
            vehicleList.DropDriverContactNumber = txtDropDriverContactNumber.Text;
            vehicleList.DropDriverAdhaarNumber = txtDropriverAdhaarNumber.Text;
            vehicleList.VehicleModeId = int.Parse(ddlVehicleMode.SelectedValue);
            vehicleList.IsActive = checkedValue;
            var result = transportBLL.AddNewVehicleMaster(vehicleList);
            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle Registered Sucessfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }

        protected void Button10_Click(object sender, EventArgs e)
        {
            txtVehicleNumber.Text = "";
            txtVehicleDescription.Text = "";
            txtPickUpDriverName.Text = "";
            txtPickUpDriverAddress.Text = "";
            txtPickUpDriverAdhaarNumber.Text = "";
            txtPickUpDriverContactNumber.Text = "";
            txtDropDriverName.Text = "";
            txtDropDriverAddress.Text = "";
            txtPickUpDriverAdhaarNumber.Text = "";
            txtPickUpDriverContactNumber.Text = "";
            CheckBox1.Checked = false;
        }
    }
}