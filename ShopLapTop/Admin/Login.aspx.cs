using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin
{
    public partial class Login : System.Web.UI.Page
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
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                lblError.Text = "Bạn Cần Nhập Đầy Đủ Thông Tin!";
                return;
            }
            string Email = txtEmail.Text;
            string password = txtPassWord.Text;
            var checkAdmin = data.AdminAdvices.SingleOrDefault(p => p.USERNAME == Email && p.PASSWORD == password);
            if (checkAdmin != null)
            {
               
            
                var roles = (from role in data.AccountEmloyeeRoles
                             select role.RoleName).ToList();

                Session["Roles"] = roles;
                Session["name"] = checkAdmin.FULLNAME;
                Session["idAdmin"] = checkAdmin.ID_ADMIN;
                Response.Redirect("Manager2.aspx");
                return;
            }

            // đăng nhập nhân viên phân quyền

            var check = data.Emloyees.SingleOrDefault(p => p.emloyee_email == Email);

            if (check == null)
            {
                lblError.Text = "Tài Khoản Không Tồn Tại";
            }
            else
            {
                if (VerifyPassword(password, check.PASSWORD_HASH, check.PASSWORD_SALT))
                {
                    check.emloyee_status = true;
                    data.SubmitChanges();
                    Session["name"] = check.emloyee_fullname;
                    Session["idEmloyee"] = check.emloyee_id;
                    var roles = (from role in data.AccountEmloyeeRoles
                                 join perm in data.AccountEmloyeePermissions on role.RoleID equals perm.RoleID
                                 where perm.EmloyeeID == check.emloyee_id // ID nhân viên đăng nhập
                                 select role.RoleName).ToList();

                    Session["Roles"] = roles;
                    Response.Redirect("Manager2.aspx");
                }
                else
                {
                    lblError.Text = "Mật Khẩu Không Chính Xác";
                    return;
                }

            }
        }

        protected void ckAdmin_CheckedChanged(object sender, EventArgs e)
        {
           
        }
    }
}