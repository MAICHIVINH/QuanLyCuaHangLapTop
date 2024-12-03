using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop
{
    public partial class Index : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                LoadThuongHieu();
                LoadCategories();
                LoadContact();
                if (Session["name"] != null) //Kiểm tra xe ngdung đăng nhập hay chưa.Session["name"] != NULLngdung da dăng nhập 
                {
                    lblTaiKhoan.Text = Session["name"].ToString();//Hiển thị tên tk đăng nhập trên lable
                    btnLogOut.Visible = true;
                    hlUser.Visible = false;
                    hlOrderHistories.Visible = true;
                }

                if(Session["search"] != null)
                {
                    txtSearch.Text = Session["search"].ToString();
                }
            } 
           


            if (Session["id"] != null)
            {
                int id = int.Parse(Session["id"].ToString());
            }

            else
            {
                lblTaiKhoan.Text = "<a href='~/Login/Logins.aspx'class='Login'></a>";
                btnLogOut.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text;
            Session["search"] = txtSearch.Text;
            Response.Redirect($"~/Views/Pages/Search.aspx?search={query}");

        }

        private void LoadCategories()
        {
            ShopDataContext data = new ShopDataContext();
            var Json = data.ProductCategories.Where(p => p.Status == true).ToList();

            RepeaterLoai.DataSource = Json;
            RepeaterLoai.DataBind();
        }

        private void LoadThuongHieu()
        {
            ShopDataContext data = new ShopDataContext();
            var Json = data.Brands.Where(p => p.Status == true).ToList();

            RepeaterThuongHieu.DataSource = Json;
            RepeaterThuongHieu.DataBind();
        }

        private void LoadContact()
        {
            ShopDataContext data = new ShopDataContext();
            var contact = data.Contacts.ToList();
            rptContact.DataSource = contact;
            rptContact.DataBind();
        }
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();//Xóa hết dữ liêu trong sesion hiện tại (LogOut)
            Session.Abandon();

            Server.Transfer("~/SubPage.aspx");
        }
    }
}