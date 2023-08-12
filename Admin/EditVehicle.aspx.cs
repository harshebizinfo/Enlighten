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
    public partial class EditVehicle : System.Web.UI.Page
    {
        TransportBLL transportBLL = new TransportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int editingId = int.Parse(Session["EditVehicleDetailId"].ToString());
                DataTable dt = new DataTable();
                dt = transportBLL.GetVehicleMasterById(editingId);
                if (dt.Rows.Count > 0)
                {
                    txtVehicleNumber.Text = dt.Rows[0]["VehicleNumber"].ToString();
                    txtVehicleDescription.Text = dt.Rows[0]["VehicleDescription"].ToString();
                    txtPickUpDriverName.Text = dt.Rows[0]["PickUpDriverName"].ToString();
                    txtPickUpDriverAddress.Text = dt.Rows[0]["PickUpDriverAddress"].ToString();
                    txtPickUpDriverContactNumber.Text = dt.Rows[0]["PickUpDriverContactNumber"].ToString();
                    txtPickUpDriverAdhaarNumber.Text = dt.Rows[0]["PickUpDriverAdhaarNumber"].ToString();
                    txtDropDriverName.Text = dt.Rows[0]["DropDriverName"].ToString();
                    txtDropDriverAddress.Text = dt.Rows[0]["DropDriverAddress"].ToString();
                    txtDropDriverContactNumber.Text = dt.Rows[0]["DropDriverContactNumber"].ToString();
                    txtDropriverAdhaarNumber.Text = dt.Rows[0]["DropDriverAdhaarNumber"].ToString();
                    CheckBox1.Checked = Boolean.Parse(dt.Rows[0]["IsActive"].ToString());
                }
            }
        }

        protected void Button9_Click(object sender, EventArgs e)
        {
            Boolean checkedValue = false;
            if (CheckBox1.Checked == true)
            {
                checkedValue = true;
            }
            AddVehicleList vehicleList = new AddVehicleList();
            vehicleList.Id = int.Parse(Session["EditVehicleDetailId"].ToString());
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
            vehicleList.IsActive = checkedValue;
            var result = transportBLL.UpdateVehicleMaster(vehicleList);
            if (result > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Vehicle Updated Sucessfully')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong')", true);
            }
        }
    }
}