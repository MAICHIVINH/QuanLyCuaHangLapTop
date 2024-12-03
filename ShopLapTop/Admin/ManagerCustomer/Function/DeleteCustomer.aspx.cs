using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCustomer.Function
{
    public partial class DeleteCustomer : System.Web.UI.Page
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
            if(customer == null)
            {
                lblMessage.Text = "Dữ Liệu Này Đã Được Xóa!";
                return;
            }
            if (customer.Status == false)
            {
                chkHidden.Checked = true;
            }
            else
            {
                chkPresently.Checked = true;
            }
            txtAccountId.Text = customer.AccountID.ToString();
            txtNameCustomer.Text = customer.FullName;
        }

        protected void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtAccountId.Text);
                var customer = data.Accounts.SingleOrDefault(p => p.AccountID == id);
                if (customer == null)
                {
                    lblMessage.Text = "Dữ Liệu Đã Được Xóa!";
                    return;
                }
                var orderHistories = data.OrderHistoriyProducts.Where(p => p.AccountID == id).ToList();
                data.OrderHistoriyProducts.DeleteAllOnSubmit(orderHistories);
                data.Accounts.DeleteOnSubmit(customer);
                data.SubmitChanges();
                lblMessage.Text = "Đã Xóa Khách Hàng Thành Công! Bạn Có Thể Quay Lại Trang Để Kiểm Tra!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex;
                return;
            }
        }

        protected void btnHomeCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeCustomer.aspx");
        }
    }
}