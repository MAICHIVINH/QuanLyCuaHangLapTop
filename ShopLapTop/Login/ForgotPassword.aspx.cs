using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Login
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
       

        protected void btnCheckEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                lblMessage.Text = "Vui lòng nhập email!";
                return;
            }

            ShopDataContext data = new ShopDataContext();
            var account = data.Accounts.SingleOrDefault(a => a.Email == email);

            if (account != null)
            {
                lblMessage.Text = "Email hợp lệ! Vui lòng nhập mật khẩu mới.";
                pnlChangePassword.Visible = true; // Hiển thị form đổi mật khẩu
            }
            else
            {
                lblMessage.Text = "Email không tồn tại!";
                pnlChangePassword.Visible = false; // Ẩn form đổi mật khẩu
            }
        }

        public string GenerateSalt(int length = 32)
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[length];
                rng.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
        }

        public string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Kết hợp mật khẩu và salt
                string saltedPassword = password + salt;

                // Chuyển mật khẩu đã được salt thành mảng byte và tính hash
                byte[] passwordBytes = Encoding.UTF8.GetBytes(saltedPassword);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Chuyển hash thành chuỗi hex (Base64 hoặc Hex đều được)
                return Convert.ToBase64String(hashBytes);
            }
        }




        protected void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            // Kiểm tra mật khẩu mới có nhập hay không
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                lblMessage.Text = "Vui lòng nhập mật khẩu mới!";
                return;
            }

            // Kiểm tra mật khẩu xác nhận có nhập hay không
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                lblMessage.Text = "Vui lòng nhập lại mật khẩu!";
                return;
            }

            // Kiểm tra mật khẩu và xác nhận mật khẩu có khớp hay không
            if (newPassword != confirmPassword)
            {
                lblMessage.Text = "Mật khẩu không khớp!";
                return;
            }

            // Tiến hành cập nhật mật khẩu
            ShopDataContext data = new ShopDataContext();
            var account = data.Accounts.SingleOrDefault(a => a.Email == email);

            if (account != null)
            {
                // Sinh salt và hash mật khẩu
                string salt = GenerateSalt();
                string hashedPassword = HashPassword(newPassword, salt);

                // Cập nhật vào cơ sở dữ liệu
                account.PASSWORD_SALT = salt;
                account.PASSWORD_HASH = hashedPassword;
                data.SubmitChanges();

                lblMessage.Text = "Mật khẩu đã được cập nhật thành công!";
            }
            else
            {
                lblMessage.Text = "Email không tồn tại!";
            }
        }
    }
}