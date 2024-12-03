using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop
{
    public partial class SubPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadProductMongNhe();
            LoadProductVanPhong();
            LoadProductGaming();
            LoadProductMacbook();
            LoadProductCaoCap();

            LoadCategory(1, lblMongNhe);
            LoadCategory(2, lblVanPhong);
            LoadCategory(3, lblGaming);
            LoadCategory(4, lblMacBook);
            LoadCategory(5, lblCaoCap);




        }



        private void LoadCategory(int categoryid, Label lblCategory)
        {
            ShopDataContext data = new ShopDataContext();
            var category = data.ProductCategories.Where(n => n.CategoryID == categoryid && n.Status == true).FirstOrDefault();
            lblCategory.Text = category.CategoryName;
        }

        private void LoadProductMongNhe()
        {
            ShopDataContext data = new ShopDataContext();
            // Lấy danh sách sản phẩm mới từ bảng SanPham 
            var products = (from p in data.Products where p.CategoryID == 1 orderby p.ProductID descending select new { p.ProductID, p.ProductName, p.Price, p.Image, p.Details }).Take(5).ToList();

            // Gán danh sách sản phẩm vào Repeater
            RepeaterMongNhe.DataSource = products;
            RepeaterMongNhe.DataBind();

        }

        private void LoadProductVanPhong()
        {
            ShopDataContext data = new ShopDataContext();
            // Lấy danh sách sản phẩm mới từ bảng SanPham 
            var products = (from p in data.Products where p.CategoryID == 2 orderby p.ProductID descending select new { p.ProductID, p.ProductName, p.Price, p.Image, p.Details }).Take(5).ToList();

            RepeaterVanPhong.DataSource = products;
            RepeaterVanPhong.DataBind();

        }

        private void LoadProductGaming()
        {
            ShopDataContext data = new ShopDataContext();
            // Lấy danh sách sản phẩm mới từ bảng SanPham 
            var products = (from p in data.Products where p.CategoryID == 3 orderby p.ProductID descending select new { p.ProductID, p.ProductName, p.Price, p.Image, p.Details }).Take(5).ToList();

            RepeaterGaming.DataSource = products;
            RepeaterGaming.DataBind();

        }
        private void LoadProductMacbook()
        {
            ShopDataContext data = new ShopDataContext();
            // Lấy danh sách sản phẩm mới từ bảng SanPham 
            var products = (from p in data.Products where p.CategoryID == 4 orderby p.ProductID descending select new { p.ProductID, p.ProductName, p.Price, p.Image, p.Details }).Take(5).ToList();

            RepeaterMacBook.DataSource = products;
            RepeaterMacBook.DataBind();

        }

        private void LoadProductCaoCap()
        {
            ShopDataContext data = new ShopDataContext();
            // Lấy danh sách sản phẩm mới từ bảng SanPham 
            var products = (from p in data.Products where p.CategoryID == 5 orderby p.ProductID descending select new { p.ProductID, p.ProductName, p.Price, p.Image, p.Details }).Take(5).ToList();

            RepeaterCaoCap.DataSource = products;
            RepeaterCaoCap.DataBind();

        }

        protected void LoadMoreMongNhe_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ProductGroup.aspx?idg=" + 1);
        }

        protected void LoadMoreVanPhong_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ProductGroup.aspx?idg=" + 2);
        }

        protected void LoadMoreGaming_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ProductGroup.aspx?idg=" + 3);
        }

        protected void LoadMoreMacbook_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ProductGroup.aspx?idg=" + 4);
        }

        protected void LoadMoreCaoCap_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Pages/ProductGroup.aspx?idg=" + 5);
        }
    }
}