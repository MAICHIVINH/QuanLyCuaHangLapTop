using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerEmloyee.Function
{
    public partial class UpdateEmloyee : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                LoadPage(id);
            }
        }
        protected void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHidden.Checked == true)
            {
                chkPresently.Checked = false;
            }
        }

        protected void chkPresently_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPresently.Checked == true)
            {
                chkHidden.Checked = false;
            }
        }
        private void LoadPage(int emloyeeID)
        {
            var getAll = data.AccountEmloyeeRoles.ToList();
            var emloyeeRole = data.AccountEmloyeePermissions.Where(p => p.EmloyeeID == emloyeeID).Select(p => p.RoleID).ToList();
            var emloyeeStatus = data.Emloyees.SingleOrDefault(p => p.emloyee_id == emloyeeID);
            if (emloyeeStatus.emloyee_status == true)
                chkHidden.Checked = true;
            else
                chkPresently.Checked = true;
            rptRole.DataSource = getAll;
            rptRole.DataBind();
            foreach(RepeaterItem item in rptRole.Items)
            {
                CheckBox cbRole = item.FindControl("cbRole") as CheckBox;
                int RoleID = int.Parse(cbRole.Attributes["Value"]);
                if (emloyeeRole.Contains(RoleID))
                {
                    cbRole.Checked = true;
                }
            }
        }
     

        protected void btnUpdateEmloyee_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = true;
                int id = int.Parse(Request.QueryString["id"]);
                var statusEmloyee = data.Emloyees.SingleOrDefault(p => p.emloyee_id == id);
                if (chkHidden.Checked != true)
                    status = false;
                statusEmloyee.emloyee_status = status;
                //để cập nhật lại thông tin quyền nhan viên ta cần xóa đi dữ liệu quyền cũ của nhân viên
                var emloyeeRole = data.AccountEmloyeePermissions.Where(p => p.EmloyeeID == id).ToList();
                data.AccountEmloyeePermissions.DeleteAllOnSubmit(emloyeeRole);
                data.SubmitChanges();
                foreach (RepeaterItem item in rptRole.Items)
                {
                    CheckBox chkRole = (CheckBox)item.FindControl("cbRole");// lấy tên dữ liệu bạn muốn xét
                    if (chkRole != null && chkRole.Checked)
                    {
                        int roleId = Convert.ToInt32(chkRole.Attributes["value"]); // lấy giá trị của dữ liệu đó

                        var accountEmloyeePermission = new AccountEmloyeePermission
                        {
                            EmloyeeID = id,
                            RoleID = roleId
                        };

                        data.AccountEmloyeePermissions.InsertOnSubmit(accountEmloyeePermission);
                    }
                }
                lblMessage.Text = "Cập Nhật Dữ Liệu Thành Công!";
                data.SubmitChanges();
            } catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex;
            }
        }

        protected void btnHomeEmloyee_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeEmloyee.aspx");
        }
    }
}