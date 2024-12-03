using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCategories.Function
{
    public partial class UpdateCategories : System.Web.UI.Page
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

        private bool UploadCategory(int id, string NameCategories, bool status)
        {
            var Category = data.ProductCategories.SingleOrDefault(p => p.CategoryID == id);
            var CheckCategories = data.ProductCategories.SingleOrDefault(p => p.CategoryName == NameCategories && p.CategoryID != id);
            if (CheckCategories == null)
            {
                Category.CategoryName = NameCategories;
                Category.Status = status;
                data.SubmitChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void btnHomeCategories_Click(object sender, EventArgs e)
        {
            Response.Redirect("../HomeCategories.aspx");
        }

        protected void btnUpdateCategories_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoriesName.Text))
            {
                lblMessage.Text = "Vui lòng bạn điền đầy đủ thông tin!";
                return;
            }
            else
            {
                int id = int.Parse(Request.QueryString["id"]);
                string NameCategories = txtCategoriesName.Text;
                bool Static = false;
                if (chkPresently.Checked == true)
                {
                    Static = true;
                }

                if (UploadCategory(id,NameCategories, Static))
                {
                    lblMessage.Text = "Dữ Liệu Đã Cập Nhật Thành Công Bạn Có Thể Quay Lại Để Kiểm Tra!";
                    LoadCategory(id);
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