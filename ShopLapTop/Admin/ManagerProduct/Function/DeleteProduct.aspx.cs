using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerProduct.Function
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadBrand();
                int id = int.Parse(Request.QueryString["id"]);
                LoadPage(id);
            }
        }

        private void LoadCategories()
        {
            var categories = data.ProductCategories.ToList();
            foreach (var item in categories)
            {
                // Thêm Tên và ID tương ứng với Categories
                ListItem listItem = new ListItem(item.CategoryName, item.CategoryID.ToString());
                ddlCategories.Items.Add(listItem);
            }
        }
        private void LoadBrand()
        {
            var brand = data.Brands.ToList();
            foreach (var item in brand)
            {
                // Thêm Tên và ID tương ứng với Categories
                ListItem listItem = new ListItem(item.BrandName, item.BrandID.ToString());
                ddlBrand.Items.Add(listItem);
            }
        }

        private void LoadPage(int id)
        {
            var Product = data.Products.SingleOrDefault(p => p.ProductID == id);
            txtDetails.Text = Product.Details;
            txtDiscount.Text = Product.Discount.ToString();
            txtProductName.Text = Product.ProductName;
            txtPrice.Text = ((int)Product.Price).ToString();
            txtStockQuantity.Text = Product.StockQuantity.ToString();
            txtNameFile.Text = Product.Image;
            // Sử dụng ClientScript để inject giá trị vào textarea

            addScript.Text = $"<script src=\"https://cdn.tiny.cloud/1/oeu3yhycyrj0lqa722zpeyqh5xj7r8imoh31ctunafgvtgmz/tinymce/7/tinymce.min.js\" referrerpolicy=\"origin\"></script>\r\n" +
             "<script>" +
             "tinymce.init({" +
             "    selector: '#tiny'," +
             "    plugins: 'advcode advtable autocorrect autolink checklist codesample editimage emoticons image link linkchecker lists media mediaembed powerpaste table tinymcespellchecker'," +
             "    toolbar: 'bold italic forecolor backcolor | numlist bullist | link image emoticons codesample blockquote '," +
             "    placeholder: 'Add a comment...'," +
             "    setup: (editor) => { " +
             "        editor.on('init', () => {" +
             $"            editor.setContent('{HttpUtility.JavaScriptStringEncode(Product.Description)}');" + // Chèn nội dung từ C#
             "        });" +
             "    }" +
             "});" +
             "</script>";

            ddlBrand.SelectedValue = Product.BrandID.ToString();
            ddlCategories.SelectedValue = Product.CategoryID.ToString();
        }

        protected void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            var product = data.Products.SingleOrDefault(p => p.ProductID == id);
            var order_history = data.OrderHistoriyProducts.Where(p => p.ProductID == id).ToList();
            var order_detail = data.OrderDetails.Where(p => p.ProductID == id).ToList();
            var Image = data.Images.Where(p => p.ProductID == id).ToList();
            // duyệt tất cả dữ liệu ở các bảng đã kết nối khóa ngoại với product 
            if (order_detail != null && order_detail.Any())
            {
                foreach(var item in order_detail)
                data.OrderDetails.DeleteOnSubmit(item);
            }
            if (Image != null && Image.Any())
            {
                foreach (var item in Image)
                {
                    data.Images.DeleteOnSubmit(item);
                }
            }
            if (order_history != null && order_history.Any())
            {
                foreach (var item in order_history)
                {
                    data.OrderHistoriyProducts.DeleteOnSubmit(item);
                }
            }
            data.Products.DeleteOnSubmit(product);
            data.SubmitChanges();
            lblMessage.Text = "Dữ Liệu Đã Được xóa Mời bạn quay về trang chủ!";
            btnHomeProduct.Visible = true;
        }
        protected void btnHomeProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeProduct.aspx");
        }
    }
}