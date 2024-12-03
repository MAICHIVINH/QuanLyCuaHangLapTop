using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerProduct.Function
{
    public partial class UpdateProduct : System.Web.UI.Page
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
            var product = data.Products.SingleOrDefault(p => p.ProductID == id);
            txtDetails.Text = product.Details;
            txtDiscount.Text = product.Discount.ToString();
            txtProductName.Text = product.ProductName;
            txtPrice.Text = ((int)product.Price).ToString();
            txtStockQuantity.Text = product.StockQuantity.ToString();
            txtNameFile.Text = product.Image; 
            // Sử dụng ClientScript để inject giá trị vào textarea

            addScript.Text = $"<script src=\"https://cdn.tiny.cloud/1/qfa0385ogmclp69zgu32jxhpps8qymdvxv9iehmdlbikl7lp/tinymce/7/tinymce.min.js\" referrerpolicy=\"origin\"></script>\r\n" +
             "<script>" +
             "tinymce.init({" +
             "    selector: '#tiny'," +
             "    plugins: 'advcode advtable autocorrect autolink checklist codesample editimage emoticons image link linkchecker lists media mediaembed powerpaste table tinymcespellchecker'," +
             "    toolbar: 'bold italic forecolor backcolor | numlist bullist | link image emoticons codesample blockquote '," +
             "    placeholder: 'Add a comment...'," +
             "    setup: (editor) => { " +
             "        editor.on('init', () => {" +
             $"            editor.setContent('{HttpUtility.JavaScriptStringEncode(product.Description)}');" + // Chèn nội dung từ C#
             "        });" +
             "    }" +
             "});" +
             "</script>";

            ddlBrand.SelectedValue = product.BrandID.ToString();
            ddlCategories.SelectedValue = product.CategoryID.ToString();
        }


        private bool UpdateProducts(int id, string productName, 
                                    string details, int discount, decimal price, 
                                    int stockQuantity, string description, int brand, int category, string image)
        {
            try
            {
                var product = data.Products.SingleOrDefault(p => p.ProductID == id);

                product.ProductName = productName;
                product.Details = details;
                product.Discount = discount;
                product.Price = price;
                product.StockQuantity = stockQuantity;
                product.Description = description;
                product.BrandID = brand;
                product.CategoryID = category;
                product.Image = image;
                data.SubmitChanges();
                return true;
            } catch (Exception ex)
            {
                lblMessage.Text = "Lỗi : " + ex.Message;
                return false;
            }
        }
        private string UploadFileImage(string Upload)
        {
            string nameFile = Upload;
            string[] array = { ".jpg", ".png" };

            if (!string.IsNullOrWhiteSpace(nameFile) && FileImage.HasFiles)
            {
                if (FileImage.HasFiles)
                {
                    string tailFileUpload = Path.GetExtension(FileImage.FileName).ToLower(); // lấy đuôi file
                    if (array.Contains(tailFileUpload))
                    {
                        nameFile += tailFileUpload;
                        string path = Server.MapPath("~") + "Style/Images/" + nameFile;
                        FileImage.SaveAs(path);
                        txtNameFile.Visible = true;
                    }

                } else
                {
                    txtNameFile.Visible = false;
                }
            }
            return nameFile;
        }
        protected void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            int discount = 0;
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                lblMessage.Text = "Vui lòng bạn nhập đầy đủ thông tin cần thiết!";
                return;
            }
            else
            {
                if (!int.TryParse(txtDiscount.Text, out discount))
                {
                    lblMessage.Text = "Giảm giá phải là một số hợp lệ!";
                    return;
                }
            }
            int id = int.Parse(Request.QueryString["id"]);
            string productName = txtProductName.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string imageName = UploadFileImage(txtNameFile.Text);
            string details = txtDetails.Text;
            string description = Request.Unvalidated["content"];
            int idCategories = int.Parse(ddlCategories.SelectedValue);
            int idBrand = int.Parse(ddlBrand.SelectedValue);
            int quantity = int.Parse(txtStockQuantity.Text);
            if (string.IsNullOrWhiteSpace(productName)
               || string.IsNullOrWhiteSpace(details) || string.IsNullOrWhiteSpace(description))
            {
                lblMessage.Text = "Vui lòng bạn nhập đầy đủ thông tin cần thiết!";
                btnHomeProduct.Visible = false;
                return;
            }
            else
            {
                if (UpdateProducts(id, productName, details, discount, price, quantity,
                    description, idBrand, idCategories, imageName))
                {
                    lblMessage.Text = "Dữ liệu đã được cập nhật";
                    btnHomeProduct.Visible = true;
                }
            }
            LoadPage(id);
        }

        protected void btnHomeProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeProduct.aspx");
        }
    }
}