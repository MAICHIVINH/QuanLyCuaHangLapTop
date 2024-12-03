using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCustomer
{
    public partial class HomeCustomer : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCustomers();
            }
        }

        public string LoadStatus(bool status)
        {
            if(status == true)
            {
                return "Đang bị Khóa";
            } else
            {
                return "Đang Hoạt Động";
            }
        }

        private void LoadCustomers()
        {
            var customer = data.Accounts.OrderByDescending(p => p.AccountID).ToList();
            rptCustomerList.DataSource = customer;
            rptCustomerList.DataBind();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("Function/UpdateStatusCustomer.aspx?id=" + id);

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("Function/DeleteCustomer.aspx?id=" + id);
        }

        private void LoadCustomerSearch(string search, int page)
        {
            var CustomerSearch = data.Accounts.Where(p => p.FullName.Contains(search) || p.AccountID.ToString().Contains(search))
                                .OrderByDescending(p => p.AccountID).ToList();
            // Lấy tổng số sản phẩm
            int totalCustomer = CustomerSearch.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalCustomer / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var customers = CustomerSearch.OrderByDescending(p => p.AccountID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptCustomerList.DataSource = customers;
            rptCustomerList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void rptCustomerList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var roles = Session["Roles"] as List<string>;
                if (roles != null)
                {
                    var btnUpdate = (Button)e.Item.FindControl("btnUpdate");
                    var btnDelete = (Button)e.Item.FindControl("btnDelete");

                    if (btnUpdate != null)
                        btnUpdate.Visible = roles.Contains("Sửa Trạng Thái Khách Hàng");

                    if (btnDelete != null)
                        btnDelete.Visible = roles.Contains("Xóa Khách Hàng");
                }
            }
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}