using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerProduct
{
    public partial class HomeProduct : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int page = 1;

                if (Request.QueryString["page"] != null)
                {
                    int.TryParse(Request.QueryString["page"], out page);
                }
                if (Session["SearchProductAdmin"] != null)
                {
                    LoadProductSearch(Session["SearchProductAdmin"].ToString(), page);
                    txtSearch.Text = Session["SearchProductAdmin"].ToString();
                }
                else
                {
                    LoadProduct(page);
                }
                var roles = Session["Roles"] as List<String>;

                if(roles.Contains("Thêm sản phẩm"))
                {
                    btnAddProduct.Visible = true;
                }
            }
        }

        public string category(int id)
        {
            var category = data.ProductCategories.SingleOrDefault(c => c.CategoryID == id);
            return category.CategoryName;
        }

        public string brand(int id)
        {
            var brand = data.Brands.SingleOrDefault(c => c.BrandID == id);
            return brand.BrandName;
        }

        private void LoadProductSearch(string search,int page)
        {
            var productSearch = data.Products.Where(p => p.ProductName.Contains(search) || p.ProductID.ToString().Contains(search))
                                .OrderByDescending(p => p.ProductID).ToList();
            // Lấy tổng số sản phẩm
            int totalProducts = productSearch.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var products = productSearch.OrderByDescending(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptOrderList.DataSource = products;
            rptOrderList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();
        }


        private void LoadProduct(int page)
        {
            var category = data.Products.ToList();
            // Lấy tổng số sản phẩm
            int totalProducts = category.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var products = category.OrderByDescending(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptOrderList.DataSource = products;
            rptOrderList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int IdProduct = int.Parse(button.CommandArgument);

            Response.Redirect("./Function/UpdateProduct.aspx?id=" + IdProduct);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["SearchProductAdmin"] = txtSearch.Text;
            string nameSearch = txtSearch.Text;
            int page = 0;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out page);
            }
            LoadProductSearch(nameSearch, page);
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Function/AddProduct.aspx");
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("./Function/DeleteProduct.aspx?id=" + id);
        }

        protected void rptOrderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var roles = Session["Roles"] as List<string>;
                if (roles != null)
                {
                    var btnUpdate = (Button)e.Item.FindControl("btnUpdate");
                    var btnDelete = (Button)e.Item.FindControl("btnDelete");

                    if (btnUpdate != null)
                        btnUpdate.Visible = roles.Contains("Sửa sản phẩm");

                    if (btnDelete != null)
                        btnDelete.Visible = roles.Contains("Xóa sản phẩm");
                }
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}