using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Views.Pages
{
    public partial class DetailProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Chỉ thực hiện khi không có postback
            {
                int id = 0;
                if (Request.QueryString["idp"] != null)
                {
                    id = Convert.ToInt32(Request.QueryString["idp"]);
                    ViewState["ProductId"] = id;
                    viewData(id);

                    // Hiển thị ảnh chính
                    var images = GetImages(id);
                    var mainImage = images.FirstOrDefault(i => i.IsPrimary);
                    if (mainImage != null)
                    {
                        ImageMain.ImageUrl = "~/Style/Images/" + mainImage.ImagePath;
                    }

                    // Hiển thị ảnh phụ
                    ChooseImage.DataSource = images.Where(i => !i.IsPrimary).ToList();
                    ChooseImage.DataBind();
                }
            }
        }

        public class ImageModel
        {
            public string ImagePath { get; set; }
            public bool IsPrimary { get; set; }
        }
        //Save Image
        public List<ImageModel> GetImages(int idProduct)
        {
            using(var data = new ShopDataContext())
            {
                var images = new List<ImageModel>();
                // lay anh chinh tu bangr procut
                var mainImagePath = data.Products.Where(p => p.ProductID == idProduct)
                                                  .Select(p => p.Image).FirstOrDefault();
                if(mainImagePath != null)
                {
                    images.Add(new ImageModel
                    {
                        ImagePath = mainImagePath,
                        IsPrimary = true
                    });
                }
                // lay cac anh phu

                var additinalImage = data.Images.Where(p => p.ProductID == idProduct)
                                                .Select(img => new ImageModel
                                                {
                                                    ImagePath = img.ImageName,
                                                    IsPrimary = false
                                                });
                images.AddRange(additinalImage);
                return images;
            }
        }

        private void viewData(int id)
        {
            ShopDataContext data = new ShopDataContext();
            Product sp = data.Products.SingleOrDefault(sa => sa.ProductID == id);
            /*Lấy các sản phẩm theo category*/
            var productcategory = (from p in data.Products join c in data.ProductCategories on p.CategoryID equals c.CategoryID where p.CategoryID == sp.CategoryID select p).Take(5).ToList();
            RelatedRepeater.DataSource = productcategory;
            RelatedRepeater.DataBind();
            if (sp != null)
            {
                lblTenSanPham.Text = sp.ProductName;
                lblThongTin.Text = sp.Description;
                lblImage.Text = sp.Image;
                lblGia.Text = ((decimal)sp.Price).ToString("N0"); // Chuyển kiểu và định dạng giá
                                                                                //}
                                                                                //else
                                                                                //{
                                                                                //    lblGia.Text = "Liên hệ"; // Hiển thị thông báo nếu giá trị Giá là null
                                                                                //}
                lblChiTiet.Text = sp.Details.ToString().Replace("\n", "<br />");
                lblEvaluate.Text = sp.Evaluate.ToString();
                lblTotalRatings.Text = sp.TotalRatings.ToString();
            }
        }
        // Xử lý thêm vào giỏ hàng
        public class CartItem
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public string Image { get; set; }
            public string ProductName { get; set; }
            public int IdUser { get; set; }
            public decimal TotalPrice => Price * Quantity;
        }

        private List<CartItem> GetCarts()
        {
            //kiểm tra xem Session đã từng tạo bao giờ chưa
            if(Session["Cart"] == null)
            {
                Session["Cart"] = new List<CartItem>();
            }
            return (List<CartItem>)Session["Cart"];
        }

        protected void AddCart(int idproduct, int quantity, decimal price, string Image, string productname, int iduser)
        {
            List<CartItem> cartItems = GetCarts();
            // kiểm tra xem id đã tồn tại trong danh sách hay chưa nếu có thì chỉ cộng quantity
            CartItem cart = cartItems.Find(item => item.ProductId == idproduct);
            if(cart != null)
            {
                cart.Quantity += quantity;
            } else
            {
                cartItems.Add(new CartItem
                {
                    ProductId = idproduct,
                    Quantity = quantity,
                    Price = price,
                    Image = Image,
                    ProductName = productname,
                    IdUser = iduser
                });
            }

            Session["Cart"] = cartItems;
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int IdProduct = int.Parse(Request.QueryString["idp"]);
            int quantity = int.Parse(txtquantity.Text);
            string Image = lblImage.Text;
            decimal price = decimal.Parse(lblGia.Text);
            string productname = lblTenSanPham.Text;
            int id = 0;
            if(Session["id"] == null)
            {

            } else
            {
                id = int.Parse(Session["id"].ToString());
            }
            AddCart(IdProduct, quantity, price, Image, productname, id);
            Response.Redirect("~/Views/Orders/Carts.aspx");
        }

        protected void ChooseImage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "ChangeImage")
            {
                string selectedimagepath = e.CommandArgument.ToString();

                // Thay đổi ảnh chính
                ImageMain.ImageUrl = "~/Style/Images/" + selectedimagepath;

                // Cập nhật lại danh sách ảnh phụ để không bao gồm ảnh chính mới
                int productId = (int)ViewState["ProductId"];
                var images = GetImages(productId);
                ChooseImage.DataSource = images.Where(i => i.ImagePath != selectedimagepath).ToList();
                ChooseImage.DataBind();
            }

        }

        protected void RelatedRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}