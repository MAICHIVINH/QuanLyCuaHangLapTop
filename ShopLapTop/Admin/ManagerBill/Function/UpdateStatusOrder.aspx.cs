using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBill
{
    public partial class UpdateStatusOrder : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];
                LoadPage(id);
            }
        }

        public string LoadStatus(int statusid)
        {
            var status = data.StatusOrders.SingleOrDefault(p => p.status_id == statusid);
            return status.status_name;
        }

        private void LoadPage(string id)
        {
            var order = data.Orders.SingleOrDefault(p => p.OrderID == id);
            if(order == null)
            {
                lblMessage.Text = "Đơn Hàng Không Tồn Tại!";
                return;
            }
            if (order.Status == 5)
            {
                lblMessage.Text = "Đang Chờ Khách Hàng Đánh Giá";
                btnUpdateStatus.Visible = false;
            }
            else
            {
                btnUpdateStatus.Text = LoadStatus(int.Parse(order.Status.ToString()) + 1);
            }
            txtAddress.Text = order.Address;
            txtOrderID.Text = order.OrderID;
            txtPhone.Text = order.PhoneNumber;
            txtNote.Text = order.Note;
            txtFullName.Text = order.FullName;
            txtStatus.Text = LoadStatus(int.Parse(order.Status.ToString()));

        }

        protected void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            var order = data.Orders.SingleOrDefault(p => p.OrderID == id);
            int idEmloyee;
            int idAdmin;
            if (Session["idEmloyee"] != null)
            {
                idEmloyee = int.Parse(Session["idEmloyee"].ToString());
                order.emloyee_id = idEmloyee;
            }
            if (Session["idAdmin"] != null)
            {
                idAdmin = int.Parse(Session["idAdmin"].ToString());
                order.Admin = idAdmin;
            }
            order.Status += 1;
            data.SubmitChanges();
            Response.Redirect("../HomeBill.aspx");
        }
    }
}