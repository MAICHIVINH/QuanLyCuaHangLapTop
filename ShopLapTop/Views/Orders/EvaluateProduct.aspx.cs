using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ShopLapTop.Views.Orders.OrderStatus;

namespace ShopLapTop.Views.Orders
{
    public partial class EvaluateProduct : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                LoadPage(id, int.Parse(Session["lblQuantity"].ToString()), Session["lblOrdersID"].ToString());
            }
        }

        private void LoadPage(int productid, int quantity, string orderID)
        {
            var product = data.Products.SingleOrDefault(p => p.ProductID == productid);
            lblIMAGE.ImageUrl = "~/Style/Images/" + product.Image;
            lblDetails.Text = product.Details.ToString().Replace("\n", "<br />");
            lblOrderID.Text = orderID;
            lblPrice.Text = product.Price.ToString();
            lblProductName.Text = product.ProductName;
            lblQuantity.Text = quantity.ToString();
            lblTotalAmount.Text = (product.Price * quantity).ToString();
        }

        private void UpdateEvaluate(int rating,int id)
        {
            var product = data.Products.SingleOrDefault(p => p.ProductID == id);
            product.TotalRatings += 1;
            product.SumRatings += rating;
            product.Evaluate = (float)product.SumRatings / (float)product.TotalRatings;
            data.SubmitChanges();
        }

        protected void btnEvaluate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(Request.QueryString["id"], out int id))
                {
                    lblTest.Text = "Lỗi: ID sản phẩm không hợp lệ.";
                    return;
                }

                if (!int.TryParse(rbRating.SelectedValue, out int rating) || rating < 1 || rating > 5)
                {
                    lblTest.Text = "Lỗi: Vui lòng chọn mức đánh giá từ 1 đến 5.";
                    return;
                }

                var product = data.Products.SingleOrDefault(p => p.ProductID == id);
                if (product == null)
                {
                    lblTest.Text = $"Lỗi: Không tìm thấy sản phẩm với ID {id}.";
                    return;
                }
                int quantityProduct = int.Parse(Session["lblQuantity"].ToString());
                product.TotalRatings += 1;
                product.SumRatings += rating; 
                product.Evaluate = (float)product.SumRatings / product.TotalRatings;
                product.quantity_sold += quantityProduct;
                data.SubmitChanges();
                string orderID = Session["lblOrdersID"].ToString();

                // nếu có tài khoản đăng nhập thì lưu dữ liệu đó vào HistoryOrder
                OrderHistoriyProduct orderHistoriy = new OrderHistoriyProduct();
                if (Session["id"] != null)
                {
                    int idAccount = int.Parse(Session["id"].ToString());
                    var Account = data.Accounts.SingleOrDefault(p => p.AccountID == idAccount);
                    orderHistoriy = new OrderHistoriyProduct
                    {
                        AccountID = idAccount,
                        Quantity = quantityProduct,
                        ProductID = id,
                        OrderID = orderID,
                        TotalAmount = decimal.Parse(Session["lbltotalprice"].ToString())
                    };
                    data.OrderHistoriyProducts.InsertOnSubmit(orderHistoriy);
                    data.SubmitChanges();
                }

                var updateStatusOrder = data.Orders.SingleOrDefault(p => p.OrderID == orderID);

                updateStatusOrder.Status++;

                data.SubmitChanges();

           
                lblTest.Text = $"Cảm ơn bạn đã đánh giá sản phẩm! Điểm trung bình hiện tại: {product.Evaluate:F2} sao.";
                Response.Redirect("~/SubPage.aspx");
            }
            catch (Exception ex)
            {
                lblTest.Text = $"Đã xảy ra lỗi: {ex.Message}";
            }
        }

        protected void btnEvaluates_Click(object sender, EventArgs e)
        {

        }
    }
}