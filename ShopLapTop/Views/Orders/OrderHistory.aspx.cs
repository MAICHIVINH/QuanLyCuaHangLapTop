using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Views.Orders
{
    public partial class OrderHistory : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Session["id"].ToString());
                LoadOrderHistories(id);
            }
        }


        private void LoadOrderHistories(int accountid)
        {
            var orderHistory = (from p in data.Products
                                join o in data.OrderHistoriyProducts on p.ProductID equals o.ProductID
                                where o.AccountID == accountid
                                select new { Product = p, OrderHistories = o }).ToList();
            rptOrderHistories.DataSource = orderHistory;
            rptOrderHistories.DataBind();
        }
    }
}