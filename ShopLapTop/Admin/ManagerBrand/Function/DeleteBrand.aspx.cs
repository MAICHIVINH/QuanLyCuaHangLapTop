using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBrand.Function
{
    public partial class DeleteBrand : System.Web.UI.Page
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
            var category = data.Brands.SingleOrDefault(p => p.BrandID == id);
            txtBrandName.Text = category.BrandName;
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
            var brand = data.Brands.SingleOrDefault(p => p.BrandID == id);
            if (brand == null)
            {
                lblMessage.Text = "Dữ Liệu Này Đã Được Xóa";
                return false;
            }
            else
            {
                data.Brands.DeleteOnSubmit(brand);
                data.SubmitChanges();
                return true;
            }
        }

        protected void btnDeleteBrand_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);
            if (DeleteCatrgory(id))
            {
                lblMessage.Text = "Dữ Liệu Đã Xóa Thành Công! Quay Lại Trang Chủ Để Kiểm Tra";
                return;
            }
        }

        protected void btnHomeBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeBrand.aspx");
        }
    }
}