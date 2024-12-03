using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBrand.Function
{
    public partial class AddBrand : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool AddBrands(string NameBrand, bool status)
        {
            var CheckCategories = data.Brands.SingleOrDefault(p => p.BrandName == NameBrand);
            if (CheckCategories == null)
            {
                Brand productBrands = new Brand
                {
                    BrandName = NameBrand,
                    Status = status
                };
                data.Brands.InsertOnSubmit(productBrands);
                data.SubmitChanges();
                return true;
            }
            else
            {
                return false;
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

        protected void btnHomeBrand_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeBrand.aspx");
        }

        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrandName.Text))
            {
                lblMessage.Text = "Vui lòng bạn điền đầy đủ thông tin!";
                return;
            }
            else
            {
                string NameBrand = txtBrandName.Text;
                bool Static = false;
                if (chkPresently.Checked == true)
                {
                    Static = true;
                }

                if (AddBrands(NameBrand, Static))
                {
                    lblMessage.Text = "Dữ Liệu Đã Thêm Thành Công Bạn Có Thể Quay Lại Để Kiểm Tra!";

                    return;
                }
                else
                {
                    lblMessage.Text = "Dường Như Dữ Liệu Này Đã Tồn Tại Vui lòng Bạn Kiểm Tra Lại!";
                    return;
                }
            }
        }
    }
}