using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBrand.Function
{
    public partial class UpdateBrand : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request.QueryString["id"]);
                LoadBrand(id);
            }
        }

        protected void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHidden.Checked)
            {
                chkPresently.Checked = false;
            }
        }

        protected void chkPresently_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPresently.Checked)
            {
                chkHidden.Checked = false;
            }
        }

        public void LoadBrand(int id)
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
        private bool UpdateBrands(int id, string NameBrand, bool status)
        {
            var Category = data.Brands.SingleOrDefault(p => p.BrandID == id);
            var CheckCategories = data.Brands.SingleOrDefault(p => p.BrandName == NameBrand && p.BrandID != id);
            if (CheckCategories == null)
            {
                Category.BrandName = NameBrand;
                Category.Status = status;
                data.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                lblMessage.Text = "Vui lòng bạn điền đầy đủ thông tin!";
                return;
            }
            else
            {
                int id = int.Parse(Request.QueryString["id"]);
                string NameBrand = txtBrandName.Text;
                bool Static = false;
                if (chkPresently.Checked == true)
                {
                    Static = true;
                }

                if (UpdateBrands(id, NameBrand, Static))
                {
                    lblMessage.Text = "Dữ Liệu Đã Cập Nhật Thành Công Bạn Có Thể Quay Lại Để Kiểm Tra!";
                    LoadBrand(id);
                    return;
                }
                else
                {
                    lblMessage.Text = "Dường Như Dữ Liệu Này Đã Tồn Tại Vui lòng Bạn Kiểm Tra Lại!";
                    return;
                }
            }
        }

        protected void btnHomeBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeBrand.aspx");
        }
    }
}