using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerContact
{
    public partial class HomeContact : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int page = 1;
                if (Request.QueryString["page"] != null)
                {
                    int.TryParse(Request.QueryString["page"], out page);
                }
                else
                {
                    LoadAllContact(page);
                }
            }
        }

        protected void rptContact_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("./Function/UpdateContact.aspx?id=" + id);
        }

        private void LoadAllContact(int page)
        {
            var contact = data.Contacts.ToList();
            // Lấy tổng số sản phẩm
            int totalContact = contact.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalContact / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var contacts = contact.OrderByDescending(p => p.ContactID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptContact.DataSource = contacts;
            rptContact.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();
        }
    }
}