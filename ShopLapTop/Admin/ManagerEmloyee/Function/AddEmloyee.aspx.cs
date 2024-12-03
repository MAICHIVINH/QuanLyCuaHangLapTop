using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerEmloyee
{
    public partial class AddEmloyee : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRole();
            }
        }

        private void LoadRole()
        {

            var role = data.AccountEmloyeeRoles.ToList();
            rptRole.DataSource = role;
            rptRole.DataBind();
        }

        private bool checkEmail(string email)
        {
            var checkEmail = data.Emloyees.SingleOrDefault(p => p.emloyee_email == email);
            if (checkEmail == null)
                return true;
            else
            {
                lblMessage.Text = "Tài Khoản Đã Tồn Tại";
                return false;
            }
        }






        protected void btnAddEmloyee_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtChangePassword.Text)
                )
            {
                lblMessage.Text = "Nhập Đầy Đủ Thông Tin!";
                return;
            }
            else
            {
                
                string LastName = txtLastName.Text;
                string FirstName = txtFirstName.Text;
                string FullName = LastName + " " + FirstName;
                string Email = txtEmail.Text;
                string Address = txtAddress.Text;
                string Phone = txtPhone.Text;
                string password = txtPassword.Text;
                if (password == txtChangePassword.Text)
                {
                    if (checkEmail(Email))
                    {   // Mã hóa mật khẩu
                        try
                        {
                            string salt = GenerateSalt();
                            string hashedPassword = HashPassword(password, salt);
                            Emloyee emloyee = new Emloyee
                            {
                                emloyee_fullname = FullName,
                                emloyee_address = Address,
                                emloyee_email = Email,
                                emloyee_phone = Phone,
                                emloyee_status = false,
                                emloyee_date = DateTime.Now,
                                PASSWORD_HASH = hashedPassword,
                                PASSWORD_SALT = salt
                            };
                            data.Emloyees.InsertOnSubmit(emloyee);
                            data.SubmitChanges();
                            int emloyeeId = emloyee.emloyee_id;

                            List<int> Role = new List<int>();


                            // duyệt Repeater và phân quyền cho nhân viên đó
                            foreach (RepeaterItem item in rptRole.Items)
                            {
                                CheckBox chkRole = (CheckBox)item.FindControl("cbRole");// lấy tên dữ liệu bạn muốn xét
                                if (chkRole != null && chkRole.Checked)
                                {
                                    int roleId = Convert.ToInt32(chkRole.Attributes["value"]); // lấy giá trị của dữ liệu đó

                                    var accountEmloyeePermission = new AccountEmloyeePermission
                                    {
                                        EmloyeeID = emloyee.emloyee_id,
                                        RoleID = roleId
                                    };

                                    data.AccountEmloyeePermissions.InsertOnSubmit(accountEmloyeePermission);
                                }
                            }

                            data.SubmitChanges();
                            lblMessage.Text = "Thêm Nhân Viên Thành Công";
                        }
                        catch (Exception ex)
                        {
                            lblMessage.Text = "Lỗi: " + ex.Message;
                        }
                    }
                }
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

        protected void btnHomeEmloyee_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeEmloyee.aspx");
        }
    }
}