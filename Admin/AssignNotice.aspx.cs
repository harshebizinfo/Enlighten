using LMS.Admin.DepartmentClassFile;
using LMS.Admin.NoticeClassFile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS.Admin
{
    public partial class AssignNotice : System.Web.UI.Page
    {
        DeptBLL deptbll = new DeptBLL();
        NoticeBLL noticebll = new NoticeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindFeeMonthddl();
            }
        }
        public void bindFeeMonthddl()
        {
            DataTable dt = new DataTable();
            dt = deptbll.GetDepartmentStandardList("Active");
            var value = Request.QueryString["nid"].ToString();
            DataTable datat = new DataTable();
            datat = noticebll.GetAssignNotice(int.Parse(value));
            foreach (DataRow dr in dt.Rows)
            {
                CheckBoxList1.Items.Add(new ListItem { Text = dr["DepartmentStandardName"].ToString(), Value = dr["Id"].ToString() });
            }
            if (datat.Rows.Count>0)
            {
                List<int> standardidList = new List<int>();
                foreach(DataRow dr in datat.Rows)
                {
                    standardidList.Add(int.Parse(dr["StandardId"].ToString()));
                }
                foreach (ListItem item in CheckBoxList1.Items)
                {
                    var idValue = item.Value;
                    if (standardidList.Contains(int.Parse(idValue)))
                    {
                        item.Selected = true;
                    }
                }
                var isforStudent = Boolean.Parse(datat.Rows[0]["IsForStudent"].ToString());
                CheckBox1.Checked = isforStudent;
                btnSubmit.Visible = false;
            }
            
            

        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var value = Request.QueryString["nid"].ToString();
            var resultCount = 0;
            var checkedCount = 0;
            var deleteResult = noticebll.DeleteAssignNotice(int.Parse(value));
            if (CheckBoxList1.SelectedValue != null && CheckBoxList1.SelectedValue != "")
            {

                foreach (ListItem item in CheckBoxList1.Items)
                {
                    if (item.Selected)
                    {
                        checkedCount += 1;
                        int departmentIdValue = int.Parse(item.Value);
                        
                        bool isChecked = false;
                        if (CheckBox1.Checked == true)
                        {
                            isChecked = true;
                        }
                        var result = noticebll.AddAssignNotice(int.Parse(value),departmentIdValue,isChecked);
                        if (result > 0)
                        {
                            resultCount += 1;
                        }
                    }
                }

                if (resultCount == checkedCount)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Notice assigned Successfully')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Something went wrong!')", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Select Standard to assign notice')", true);
            }
        }

        protected void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

            foreach (ListItem item in CheckBoxList1.Items)
            {
                item.Selected = CheckBox2.Checked;
            }
        }
    }
}