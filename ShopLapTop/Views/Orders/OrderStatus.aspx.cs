using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Views.Orders
{
    public partial class OrderStatus : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string orderId = "";
                string orderSearch = "";
                orderSearch += txtSearchOrder.Text;

                if (Session["idOrder"] != null)
                {
                    orderId = Session["idOrder"].ToString();
                }
                if (Session["id"] != null)
                {
                    int id = int.Parse(Session["id"].ToString());
                    if (CheckLoadOrderID(id))
                    {
                        LoadAllOrderStatus(id, orderSearch);
                        return;
                    }
                }

                LoadOrderStatus(orderId);
            }
        }



        private string LoadOrderID(int idUser)
        {
            var orderStatus = (from p in data.Products
                               join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                               join o in data.Orders on ord.OrderID equals o.OrderID
                               where o.AccountID == idUser
                               select
                                   o.OrderID
                               ).FirstOrDefault();

            return orderStatus;
        }
        private bool CheckLoadOrderID(int idUser)
        {
            var orderStatus = (from p in data.Products
                               join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                               join o in data.Orders on ord.OrderID equals o.OrderID
                               where o.AccountID == idUser
                               select 
                                   o.OrderID
                               ).FirstOrDefault();           
            return orderStatus != null;
        }

        private void LoadAllOrderStatus(int id, string orderSearch)
        {
            var orderStatus = (from p in data.Products
                               join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                               join o in data.Orders on ord.OrderID equals o.OrderID
                               where o.AccountID == id && o.OrderID.Contains(orderSearch) && o.Status != 6
                               select new
                               {
                                   Product = p,
                                   OrderDetails = ord,
                                   Orders = o,
                               }).ToList();
            if (orderStatus != null)
            {
                rptCart.DataSource = orderStatus;
                rptCart.DataBind();
            }

            var order = data.Orders.FirstOrDefault(p => p.AccountID == id && p.Status != 6);
            if (order != null)
            {
                txtFullname.Text = order.FullName;
                txtPhone.Text = order.PhoneNumber;
                txtDate.Text = order.OrderTime.ToString();
                txtNote.Text = order.Note;
                txtCity.Text = order.City;
                txtAddress.Text = order.Address;
                if (order.Gender == false)
                    ChkHis.Checked = true;
                else
                    ChkHer.Checked = true;
/*                ChkHis.Checked = !order.Gender;
                ChkHis.Checked = order.Gender;*/

            }
            decimal total = 0;
            var loadTotal = data.Orders.Where(p => p.AccountID == id && p.Status != 6).ToList();
            foreach(var item in loadTotal)
            {
                total += (decimal)item.TotalAmount;
            }
            lbltotalprice.Text = total.ToString("N0") + " đ";
        }

        private void LoadOrderStatus(string order)
        {
            // sql: select * from Product p join OrderDetails ord on p.Product_id = ord.Product_id
                             // join orders o on o.Order_id = ord.Order_id where order_id = ...
            // aspx = (From p in data.Product join ord in data.OrderDetails on p.Product_id equals ord.Product_id
            // //           join o in data.Orders on o.Order_id equals ord.Order_Details).ToList();
            var orderstatus = (from p in data.Products join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                       join o in data.Orders on ord.OrderID equals o.OrderID  where o.OrderID == order && o.Status != 6
                               select new 
                       {
                           Product = p,
                           OrderDetails = ord,
                           Orders = o,
                       } ).ToList();
            if(orderstatus == null)
            {
                lblError.Text = "Bạn cần nhập mã đơn để biết thông tin của đơn mình!";
                return;
            }
            rptCart.DataSource = orderstatus;
            rptCart.DataBind();

            var orders = data.Orders.FirstOrDefault(p => p.OrderID == order && p.Status != 6);
            if (orders != null)
            {
                lbltotalprice.Text = decimal.Parse(orders.TotalAmount.ToString()).ToString("N0") + "đ";
                txtFullname.Text = orders.FullName;
                txtPhone.Text = orders.PhoneNumber;
                txtDate.Text = orders.OrderTime.ToString();
                txtNote.Text = orders.Note;
                txtCity.Text = orders.City;
                txtAddress.Text = orders.Address;
                if (orders.Gender == false)
                    ChkHis.Checked = true;
                else
                    ChkHer.Checked = true;
            }

        }
        public string LoadStatus(int status)
        {
            var statusorder = data.StatusOrders.SingleOrDefault(p => p.status_id == status);
            return statusorder.status_name;
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int id = int.Parse(btn.CommandArgument);
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            Label lblQuantity = item.FindControl("lblQuantity") as Label;
            Label lblOrdersID = item.FindControl("lblOrderID") as Label;
            Label lbltotalprice = item.FindControl("lbltotalprice") as Label;
            Session["lblQuantity"] = lblQuantity.Text;
            Session["lblOrdersID"] = lblOrdersID.Text;
            Session["lbltotalprice"] = lbltotalprice.Text;
            Response.Redirect("EvaluateProduct.aspx?id=" + id);
        }

        protected void btnSearchOrder_Click(object sender, EventArgs e)
        {
            string orderSearch = txtSearchOrder.Text;
            LoadOrderStatus(orderSearch);
        }
    }
}