using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static ShopLapTop.Views.Pages.DetailProduct;

namespace ShopLapTop.Views.Orders
{
    public partial class Carts : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                if(Session["id"] == null)
                {

                } else
                {

                    id = int.Parse(Session["id"].ToString());
                }
                Show2(id);

                
            }
        }



        // cach nay lay duoc nhieu thong tin
        private List<CartItem> GetCarts()
        {
            //kiểm tra xem Session đã từng tạo bao giờ chưa
            if (Session["Cart"] == null)
            {
                Session["Cart"] = new List<CartItem>();
            }
            return (List<CartItem>)Session["Cart"];
        }

        public string LoadPoints(int id)
        {
            var user = data.Accounts.SingleOrDefault(p => p.AccountID == id);
            if (user != null)
                return user.Points.ToString();
            else
                return "100";
        }

        protected void Show2(int iduser)
        {
            List<CartItem> cartItems = GetCarts();
            if(iduser == 0)
            {
                if (cartItems != null && cartItems.Count > 0)
                {
                    OrderRepeater.DataSource = cartItems;
                    OrderRepeater.DataBind();
                }
            } else
            {
                var userCartItems = cartItems.Where(item => item.IdUser == iduser).ToList();
                var user = data.Accounts.SingleOrDefault(p => p.AccountID == iduser);
                txtAddress.Text = user.Address;
                txtCity.Text = user.City;
                txtFullname.Text = user.FullName;
                txtPhone.Text = user.PhoneNumber;
                if (user.Gender == true)
                {
                    ChkHis.Checked = true;
                } else
                {
                    ChkHer.Checked = true;
                }
                if (userCartItems != null && userCartItems.Count > 0)
                {
                    OrderRepeater.DataSource = userCartItems;
                    OrderRepeater.DataBind();
                }
            }

        }
        // cách này chỉ lấy 2 dữ liệu id và dữ liệu còn lại




        private void BuyProduct(string idorder,string fullName, bool gender, string address,
            string phone, string city, string Note, decimal total, int? accountId)
        {
            //danh sách để lưu các thông tin đã chọn
            Order order = new Order
            {
                OrderID = idorder,
                FullName = fullName,
                Gender = gender,
                Address = address,
                TotalAmount = total,
                PhoneNumber = phone,
                City = city,
                Note = Note,
                Status = 1,
                AccountID = accountId,
                OrderTime = DateTime.Now
            };
            data.Orders.InsertOnSubmit(order);

            data.SubmitChanges();

        }
        private void AddOrderDetails(int productId, int quantity, decimal total, string orderId)
        {
                OrderDetail orderDetails = new OrderDetail
                {
                    Quantity = quantity,
                    UnitPrice = total,
                    ProductID = productId,
                    OrderID = orderId
                };
                data.OrderDetails.InsertOnSubmit(orderDetails);
            var productQuantity = data.Products.SingleOrDefault(p => p.ProductID == productId);
            if(quantity > productQuantity.StockQuantity)
            {
                lblError.Text = "Số lưởng sản phẩm trong kho không đủ cho bạn hãy giảm số lượng mua giúp tôi";
                return;
            }
            productQuantity.StockQuantity -= quantity;
            data.SubmitChanges();
        }
        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; // Ký tự sử dụng
            Random random = new Random();
            char[] stringChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new string(stringChars);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int idproduct = int.Parse(btnDelete.CommandArgument);
            List<CartItem> cart = GetCarts();
            var productToRemove = cart.FirstOrDefault(c => c.ProductId == idproduct);
            if (productToRemove != null)
            {
                cart.Remove(productToRemove);
            }
            BindCart();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullname.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtCity.Text))
            {
                lblError.Text = "Nhập đầy đủ thông tin!";
                return;
            }

            List<CartItem> selectedItems = new List<CartItem>();
            string orderid = RandomString(6);
            List<CartItem> cart = GetCarts();
            int? iduser;
            int point = 0;
            if(Session["id"] != null)
            {
                iduser = int.Parse(Session["id"].ToString());
                var userpoint = data.Accounts.SingleOrDefault(p => p.AccountID == iduser);
                data.SubmitChanges();
            } else
            {
                iduser = null;
            }
            decimal totalPrice = 0;
            foreach(RepeaterItem item in OrderRepeater.Items)
            {
                //lấy checkbox của mỗi sản phẩm
                CheckBox check = (CheckBox)item.FindControl("ChkChoose");
                if(check !=null && check.Checked){
                    int productId = int.Parse(((Label)item.FindControl("lblProductId")).Text);
                    int quantity = int.Parse(((Label)item.FindControl("lblQuantity")).Text);
                    decimal price = decimal.Parse(((Label)item.FindControl("lblPrice")).Text);
                    var productToRemove = cart.FirstOrDefault(c => c.ProductId == productId);
                    if (productToRemove != null)
                    {
                        cart.Remove(productToRemove);
                    }
                    CartItem cartItem = new CartItem
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Price = price,
                    };

                    selectedItems.Add(cartItem);
                }
            }
            // Tiến hành xử lý các sản phẩm đã chọn
            if (selectedItems.Count > 0)
            {
                // Gọi hàm BuyProduct với các sản phẩm đã chọn
                foreach (var item in selectedItems)
                {
                    totalPrice += item.TotalPrice - point;
                }
                string fullName = txtFullname.Text;
                string phone = txtPhone.Text;
                string address = txtAddress.Text;
                string city = txtCity.Text;
                string note = txtNote.Text;
                bool gender = !ChkHis.Checked;

                BuyProduct(orderid, fullName, gender, address, phone, city, note, totalPrice, iduser);
                foreach (var item in selectedItems)
                {
                    totalPrice += item.Price;
                    AddOrderDetails(item.ProductId, item.Quantity, item.TotalPrice, orderid); // Hoặc gọi các hàm tương tự
                }
                Session["idOrder"] = orderid;
                Response.Redirect("OrderStatus.aspx");
            }
            else
            {
                // Thông báo giỏ hàng trống hoặc không có sản phẩm được chọn
                Response.Write("Vui lòng chọn ít nhất một sản phẩm để mua.");
            }
            BindCart();
        }
        private void BindCart()
        {
            List<CartItem> carts = GetCarts();
            // Bind giỏ hàng vào Repeater
            OrderRepeater.DataSource = carts;
            OrderRepeater.DataBind();
        }
        protected void ChkHis_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn "Nam", bỏ chọn "Nữ"
            if (ChkHis.Checked)
            {
                ChkHer.Checked = false;
            }
        }

        protected void ChkHer_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu chọn "Nữ", bỏ chọn "Nam"
            if (ChkHer.Checked)
            {
                ChkHis.Checked = false;
            }
        }

    }
}