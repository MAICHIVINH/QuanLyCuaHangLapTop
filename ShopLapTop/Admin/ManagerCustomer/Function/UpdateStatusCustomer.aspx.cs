using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCustomer.Function
{
    public partial class UpdateStatusCustomer : System.Web.UI.Page
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

        private void LoadPage(int id)
        {
            var customer = data.Accounts.SingleOrDefault(p => p.AccountID == id);
            txtAccountId.Text = customer.AccountID.ToString();
            txtNameCustomer.Text = customer.FullName;
            if(customer.Status == false)
            {
                chkHidden.Checked = true;
            } else
            {
                chkPresently.Checked = true;
            }
        }

        protected void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHidden.Checked == true)
            {
                chkPresently.Checked = false;
            }
        }

        protected void chkPresently_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPresently.Checked == true)
            {
                chkHidden.Checked = false;
            }
        }

        protected void btnHomeCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeCustomer.aspx");
        }

        protected void btnUpdateSatus_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            bool status = false;
            if (chkPresently.Checked == true)
                status = true;
            var updateStatus = data.Accounts.SingleOrDefault(p => p.AccountID == id);
            updateStatus.Status = status;
            data.SubmitChanges();
            lblMessage.Text = "Đã cập nhật trạng thái khách hàng thành công!";
        }
    }
}