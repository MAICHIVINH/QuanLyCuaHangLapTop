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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if(ChkTerms.Checked == false)
            {
                lblError.Text = "Bạn cần cần đồng ý các điều khoản của chúng tôi mới được đăng ký!";
                return;
            }
            string name = txtYourName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string password = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;
            bool gender;
            if (chkHis.Checked == true)
            {
                gender = true;
            }
            else
            {
                gender = false;
            }

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(phone)
                    && !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(password))
            {

                if (password == confirm)
                {


                    ShopDataContext data = new ShopDataContext();
                    var existingCustomer = data.Accounts.SingleOrDefault(p => p.Email == email);
                    string salt = GenerateSalt();
                    string hashedPassword = HashPassword(password, salt);
                    if (existingCustomer == null)
                    {
                        Account account = new Account();
                        account.Email = email;
                        account.Address = address;
                        account.City = city;
                        account.FullName = name;
                        account.PhoneNumber = phone;
                        account.Gender = gender;
                        account.Status = false;
                        account.PASSWORD_HASH = hashedPassword;
                        account.PASSWORD_SALT = salt;
                        account.Points = 0;
                        try
                        {
                            data.Accounts.InsertOnSubmit(account);
                            data.SubmitChanges();
                            lblError.Text = "Đã thêm thành công !";
                            Response.Redirect("Logins.aspx");
                        }
                        catch (Exception ex)
                        {
                            lblError.Text = "<p style='color:red;'>Đã có lỗi xảy ra trong quá trình đăng ký. Vui lòng thử lại.</p>";
                            // Optional: Ghi log lỗi nếu cần
                            Console.WriteLine(ex.Message); ;
                        }
                    }
                    else
                    {
                        lblError.Text = "<p style='color:red;'>Tài Khoản Đã Tồn Tại</p>"; ;
                    }
                }
                else
                {
                    lblError.Text = "<p style = 'color:red;'> Mật Khẩu Không trùng Khớp </p> ";
                }
            }
            else
            {
                lblError.Text = "<p style='color:red;'>Bạn Cần Nhập Đầy Đủ Thông tin</p>";
            }

        }
        // Tạo Salt ngẫu nhiên
        private static string GenerateSalt()
        {
            var randomNumber = new byte[32];
            string refreshToken = "";

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refreshToken = Convert.ToBase64String(randomNumber);
            }
            return refreshToken;
        }

        // Mã hóa mật khẩu với Password Hashing và Salt
        private string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                // Kết hợp mật khẩu với salt và băm
                var saltedPassword = password + salt;
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                // Chuyển đổi băm thành chuỗi Base64
                return Convert.ToBase64String(hashBytes);
            }
        }

        protected void ChkTerms_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkTerms.Checked == true)
            {
                btnRegister.BackColor = System.Drawing.Color.Blue;
            }
            else
                btnRegister.BackColor = System.Drawing.Color.Gray;


        }

        protected void chkHis_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHis.Checked)
                chkHer.Checked = false;
        }

        protected void chkHer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHer.Checked)
                chkHis.Checked = false;
        }
    }
}