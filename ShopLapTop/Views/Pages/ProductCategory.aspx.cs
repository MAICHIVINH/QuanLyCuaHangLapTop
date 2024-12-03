using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Views.Pages
{
    public partial class ProductCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idgroup = int.Parse(Request.QueryString["idc"]);
                LoadThuongHieu(idgroup);



                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    int.TryParse(Request.QueryString["page"], out page);
                }

                LoadAcer(page, idgroup);
            }
        }

        private void LoadThuongHieu(int brandid)
        {
            ShopDataContext data = new ShopDataContext();
            var category = data.Brands.Where(n => n.BrandID== brandid).FirstOrDefault();
            lblAcer.Text = category.BrandName;
        }
        private void LoadAcer(int page, int brandid)
        {
            try
            {
                ShopDataContext data = new ShopDataContext();
                // Lấy tổng số sản phẩm 
                int totalproducts = data.Products.Count(p => p.BrandID == brandid);
                //số lượng sản phẩm hiển thị
                int PageSize = 5;
                // Tính toán số trang và làm tròn
                int totalPages = (int)Math.Ceiling((double)totalproducts / PageSize);

                // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
                var products = data.Products.Where(p => p.BrandID == brandid)
                .OrderByDescending(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

                // Gán sản phẩm vào Repeater
                ProductRepeaterSearch.DataSource = products;
                ProductRepeaterSearch.DataBind();

                // Gán số trang vào phần phân trang
                List<int> pages = new List<int>();
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(i);
                }
                RepeaterPagination.DataSource = pages;
                RepeaterPagination.DataBind();
            }
            catch (Exception ex)
            {
                // Xử lý lỗi: có thể ghi vào log hoặc hiển thị thông báo
                Response.Write("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}