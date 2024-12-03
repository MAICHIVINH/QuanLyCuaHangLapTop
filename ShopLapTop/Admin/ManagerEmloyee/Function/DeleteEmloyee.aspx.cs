using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerEmloyee.Function
{
    public partial class DeleteEmloyee : System.Web.UI.Page
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

        private void LoadPage(int emloyeeID)
        {
            var getAll = data.AccountEmloyeeRoles.ToList();
            var emloyeeRole = data.AccountEmloyeePermissions.Where(p => p.EmloyeeID == emloyeeID).Select(p => p.RoleID).ToList();
            var emloyee = data.Emloyees.SingleOrDefault(p => p.emloyee_id == emloyeeID);
            txtAddress.Text = emloyee.emloyee_address;
            txtEmail.Text = emloyee.emloyee_email;
            txtPhone.Text = emloyee.emloyee_phone;
            txtFullName.Text = emloyee.emloyee_fullname;
            txtEmloyeeID.Text = emloyee.emloyee_id.ToString();
            rptRole.DataSource = getAll;
            rptRole.DataBind();
            foreach (RepeaterItem item in rptRole.Items)
            {
                CheckBox cbRole = item.FindControl("cbRole") as CheckBox;
                int RoleID = int.Parse(cbRole.Attributes["Value"]);
                if (emloyeeRole.Contains(RoleID))
                {
                    cbRole.Checked = true;
                }
            }
        }

        protected void btnDeleteEmloyee_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            var emloyee = data.Emloyees.SingleOrDefault(p => p.emloyee_id == id);
            var orders = data.Orders.Where(p => p.emloyee_id == id).ToList();
            var emloyeeRoles = data.AccountEmloyeePermissions.Where(p => p.EmloyeeID == id).ToList();
            if (emloyee == null)
            {
                lblMessage.Text = "Dữ Liệu Này Đã Bị Xóa";
                return;
            }
            data.Emloyees.DeleteOnSubmit(emloyee);
            data.Orders.DeleteAllOnSubmit(orders);
            data.AccountEmloyeePermissions.DeleteAllOnSubmit(emloyeeRoles);
            data.SubmitChanges();
            lblMessage.Text = "Xóa Nhân Viên Thành Công! Bạn Có Thể Quay Lại Trang Chủ Để Kiểm Tra";

        }

        protected void btnHomeEmloyee_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeEmloyee.aspx");
        }
    }
}