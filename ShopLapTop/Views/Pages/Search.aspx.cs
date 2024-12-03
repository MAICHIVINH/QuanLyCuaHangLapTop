using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Views.Pages
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string search = Request.QueryString["search"];
                

                //LoadSearch(1, search);

                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    int.TryParse(Request.QueryString["page"], out page);
                }

                LoadProducts(page, search);
            }
        }
        private void LoadProducts(int page, string search)
        {
            try
            {

                ShopDataContext data = new ShopDataContext();

                var productsquery = data.Products.Where(p => !string.IsNullOrEmpty(search) && (p.ProductName.Contains(search) || p.Details.Contains(search)));

                // Lấy tổng số sản phẩm
                int totalproducts = productsquery.Count();
                //số trang muốn hiển thị
                int PageSize = 5;
                // Tính toán số trang và làm tròn
                int totalPages = (int)Math.Ceiling((double)totalproducts / PageSize);

                // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
                var products = productsquery.OrderByDescending(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

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
            catch (Exception)
            {
                return;
            }
        }
    }
}