using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCategories.Function
{
    public partial class DeleteCategories : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                LoadCategory(id);
            }
        }

        public void LoadCategory(int id)
        {
            var category = data.ProductCategories.SingleOrDefault(p => p.CategoryID == id);
            txtCategoriesName.Text = category.CategoryName;
            if (category.Status == false)
            {
                chkHidden.Checked = true;
            }
            else
            {
                chkPresently.Checked = true;
            }
        }

        private bool DeleteCatrgory(int id)
        {
            var category = data.ProductCategories.SingleOrDefault(p => p.CategoryID == id);
            if(category == null)
            {
                lblMessage.Text = "Dữ Liệu Này Đã Được Xóa";
                return false;
            } else
            {
                data.ProductCategories.DeleteOnSubmit(category);
                data.SubmitChanges();
                return true;
            }
        }

        protected void btnDeleteCategories_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            if (DeleteCatrgory(id))
            {
                lblMessage.Text = "Dữ Liệu Đã Xóa Thành Công! Quay Lại Trang Chủ Để Kiểm Tra";
                return; 
            }
        }

        protected void btnHomeCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeCategories.aspx");
        }
    }
}