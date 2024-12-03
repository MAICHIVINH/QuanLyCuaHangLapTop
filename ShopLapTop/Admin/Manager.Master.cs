using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin
{
    public partial class Manager1 : System.Web.UI.MasterPage
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var roles = Session["Roles"] as List<String>;
                if (roles.Contains("Thêm sản phẩm") || roles.Contains("Sửa sản phẩm") || roles.Contains("Xóa sản phẩm"))
                {
                    hlProduct.Visible = true;
                }
                if(roles.Contains("Thêm Thương Hiệu") || roles.Contains("Sửa Thương Hiệu") || roles.Contains("Xóa Thương Hiệu"))
                {
                    hlBrand.Visible = true;
                }
                if(roles.Contains("Thêm Loại Sản Phẩm") || roles.Contains("Sửa Loại Sản Phẩm") || roles.Contains("Xóa Loại Sản Phẩm"))
                {
                    
                    hlCategories.Visible = true;
                }
                if(roles.Contains("Sửa Đơn Hàng") || roles.Contains("Xóa Đơn Hàng"))
                {
                    hlBill.Visible = true;
                }
                if(roles.Contains("Thêm Tài Khoản Nhân Viên") || roles.Contains("Sửa Tài Khoản Nhân Viên") || roles.Contains("Xóa Tài Khoản Nhân Viên"))
                {
                    hlEmloyee.Visible = true;
                }
                if(roles.Contains("Sửa Trạng Thái Khách Hàng") || roles.Contains("Xóa Khách Hàng"))
                {
                    hlCustomer.Visible = true;
                }


                if (Session["name"] != null) //Kiểm tra xe ngdung đăng nhập hay chưa.Session["name"] != NULLngdung da dăng nhập 
                {
                    lblAccount.Text = Session["name"].ToString();//Hiển thị tên tk đăng nhập trên lable
                    btnLogOut.Visible = true;
                }

                if (Session["idAdmin"] != null)
                {
                    int idAdmin = int.Parse(Session["idAdmin"].ToString());
                    hlContact.Visible = true;
                } /*else if (Session["idEmloyee"] != null)
                {

                }
                else
                {
                    lblAccount.Text = "<a href='~/Admin/Login.aspx'class='Login'></a>";
*//*                    btnLogOut.Visible = false;
*//*               }*/
            }
        }

        public int LoadRole(int idEmloyee)
        {
            var roleId = (from permission in data.AccountEmloyeePermissions
                          where permission.EmloyeeID == idEmloyee
                          select permission.RoleID).FirstOrDefault();

            return roleId;       
        }

        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("~/Admin/Login.aspx");
        }
    }
}