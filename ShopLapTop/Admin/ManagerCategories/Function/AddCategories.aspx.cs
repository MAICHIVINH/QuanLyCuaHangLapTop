using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCategories.Function
{
    public partial class AddCategories : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool AddCategoriy(string NameCategories, bool status)
        {
            var CheckCategories = data.ProductCategories.SingleOrDefault(p => p.CategoryName == NameCategories);
            if(CheckCategories == null)
            {
                ProductCategory productCategory = new ProductCategory
                {
                    CategoryName = NameCategories,
                    Status = status
                };
                data.ProductCategories.InsertOnSubmit(productCategory);
                data.SubmitChanges();
                return true;
            } else
            {
                return false;
            }
        }

        protected void btnHomeCategories_Click(object sender, EventArgs e)
        {
            


        }

        protected void chkHidden_CheckedChanged(object sender, EventArgs e)
        {
            if(chkHidden.Checked)
            {
                chkPresently.Checked = false;
            }
        }

        protected void chkPresently_CheckedChanged(object sender, EventArgs e)
        {
            if(chkPresently.Checked)
            {
                chkHidden.Checked = false;
            }
        }

        protected void btnHomeCategories_Click1(object sender, EventArgs e)
        {
            Response.Redirect("../HomeCategories.aspx");
        }

        protected void btnAddCategories_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoriesName.Text))
            {
                lblMessage.Text = "Vui lòng bạn điền đầy đủ thông tin!";
                return;
            }
            else
            {
                string NameCategories = txtCategoriesName.Text;
                bool Static = false;
                if (chkPresently.Checked == true)
                {
                    Static = true;
                }

                if (AddCategoriy(NameCategories, Static))
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