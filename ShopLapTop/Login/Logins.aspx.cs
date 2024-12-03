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
    public partial class Logins : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Kết hợp mật khẩu với salt và băm
                var saltedPassword = password + salt;
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Chuyển đổi băm thành chuỗi ký tự
                return Convert.ToBase64String(hashBytes);
            }
        }
        // Kiểm tra mật khẩu
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword, string storedSalt)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword, storedSalt);
            return hashedEnteredPassword == storedHashedPassword;
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            var check = data.Accounts.SingleOrDefault(p => p.Email == email);
            if (check == null)
            {
                lblError.Text = "Bạn nhập sai tên đăng nhập hoặc mật khẩu";
                return;
            }
            if (VerifyPassword(password, check.PASSWORD_HASH, check.PASSWORD_SALT))
            {

                if (check.Status == false)
                {
                    Session["name"] = check.FullName;
                    Session["id"] = check.AccountID;
                    Server.Transfer("~/SubPage.aspx");
                    return;
                } else
                {
                    lblError.Text = "Tài Khoản Bạn Đang Bị Khóa";
                    return;
                }

               
            } else
            {
                lblError.Text = "Tài Khoản không chính xác!";
            }
        }
    }
}