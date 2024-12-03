using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerProduct.Function
{
    public partial class AddProduct : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBrand();
                LoadCategories();
            }
        }


        private void LoadPage()
        {
            txtDetails.Text = string.Empty;
            txtDiscount.Text = "0";
            txtPrice.Text = "0";
            txtProductName.Text = string.Empty;
            txtStockQuantity.Text = "0";
            txtNameFile.Text = string.Empty;
        }
        private string UploadFileImage(string Upload)
        {
            string NameFile = Upload;
            string[] array = { ".jpg", ".png" };

            if (!string.IsNullOrWhiteSpace(NameFile) && FileImage.HasFiles)
            {
                if (FileImage.HasFiles)
                {
                    string tailFileUpload = Path.GetExtension(FileImage.FileName).ToLower(); // lấy đuôi file
                    if (array.Contains(tailFileUpload))
                    {
                        NameFile += tailFileUpload;
                        string path = Server.MapPath("~") + "Style/Images/" + NameFile;
                        FileImage.SaveAs(path);
                    }

                }
            }
            return NameFile;
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
        private void ImagePermistion(FileUpload FileImagePermistion, int productId)
        {
            // Tạo mảng chứa các phần mở rộng hợp lệ
            string[] validExtensions = new string[] { ".jpg", ".png" };

            // Danh sách lưu các tên ảnh đã tải lên
            List<string> uploadedImages = new List<string>();

            if (FileImagePermistion.HasFiles)
            {
                int maxImages = 4;
                int uploadedImageCount = 0;

                // Duyệt qua tất cả các tệp đã tải lên
                foreach (HttpPostedFile file in FileImagePermistion.PostedFiles)
                {
                    // Lấy phần mở rộng của tệp tải lên và chuyển thành chữ thường
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();

                    // Kiểm tra phần mở rộng của tệp có hợp lệ không
                    if (validExtensions.Contains(fileExtension))
                    {
                        // Kiểm tra xem đã tải lên đủ 4 tệp chưa
                        if (uploadedImageCount < maxImages)
                        {
                            // Tạo tên cho ảnh (có thể kết hợp tên với số để tránh trùng)
                            string imageName = Guid.NewGuid().ToString() + fileExtension;

                            // Lưu tệp vào thư mục Image
                            string path = Server.MapPath("~/Style/Images/") + imageName;
                            file.SaveAs(path);

                            // Thêm tên ảnh vào danh sách
                            uploadedImages.Add(imageName);

                            // Tăng số lượng ảnh đã tải lên
                            uploadedImageCount++;
                        }
                        else
                        {
                            // Nếu tải lên quá 4 hình ảnh, hiển thị thông báo lỗi
                            lblMessage.Text = "Bạn chỉ có thể tải lên tối đa 4 hình ảnh.";
                            return;
                        }
                    }
                    else
                    {
                        // Nếu tệp không phải là ảnh hợp lệ, hiển thị thông báo lỗi
                        lblMessage.Text = "Chỉ hỗ trợ các định dạng ảnh .jpg và .png.";
                        return;
                    }
                }
            }
            foreach(var item in uploadedImages)
            {
                Image image = new Image
                {
                    ProductID = productId,
                    ImageName = item
                };
                data.Images.InsertOnSubmit(image);
            }
            data.SubmitChanges();
        }


        private int AddProducts(string productname, decimal price, string imageName, string details, string description, int idCategories, int idBrand, int quantity, int discount)
        {
            Product product = new Product
            {
                ProductName = productname,
                Price = price,
                Image = imageName,
                Details = details,
                Description = description,
                StockQuantity = quantity,
                Discount = discount,
                CategoryID = idCategories,
                BrandID = idBrand,
                Evaluate = 0,
                TotalRatings = 0,
                SumRatings = 0,
                quantity_sold = 0
            };
            data.Products.InsertOnSubmit(product);
            data.SubmitChanges();

            return product.ProductID;
        }

        protected void btnAddProduct_Click(object sender, EventArgs e)
        {
            int discount = 0;
            if (string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                lblMessage.Text = "Vui lòng bạn nhập đầy đủ thông tin cần thiết!";
            }
            else
            {
                if (!int.TryParse(txtDiscount.Text, out discount))
                {
                    lblMessage.Text = "Giảm giá phải là một số hợp lệ!";
                }
            }

            string productname = txtProductName.Text;
            decimal price = decimal.Parse(txtPrice.Text);
            string ImageName = UploadFileImage(txtNameFile.Text);
            string Details = txtDetails.Text;
            string Description = Request.Unvalidated["content"];
            int IdCategories = int.Parse(ddlCategories.SelectedValue);
            int IdBrand = int.Parse(ddlBrand.SelectedValue);
            int quantity = int.Parse(txtStockQuantity.Text);
            if(string.IsNullOrWhiteSpace(productname)
               || string.IsNullOrWhiteSpace(Details) || string.IsNullOrWhiteSpace(Description)){
                lblMessage.Text = "Vui lòng bạn nhập đầy đủ thông tin cần thiết!";
                btnHomeProduct.Visible = false;
            } else
            {
                int productId = AddProducts(productname, price, ImageName, Details, Description, IdCategories, IdCategories, quantity, discount);
                ImagePermistion(FileImagePermistion, productId);
                LoadPage();
                lblMessage.Text = "Them du lieu Thanh Cong!, quay lai trang chu de kiem tra";
                btnHomeProduct.Visible = true;
            }
        }

        protected void btnHomeProduct_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeProduct.aspx");
        }
    }
}