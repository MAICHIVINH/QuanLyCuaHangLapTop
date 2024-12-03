using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBill
{
    public partial class HomeBill : System.Web.UI.Page
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
                if(Session["SearchOrderAdmin"] != null)
                {
                    LoadOrderSearch(Session["SearchOrderAdmin"].ToString(), page);
                    txtSearch.Text = Session["SearchOrderAdmin"].ToString();
                }
                else
                {
                    LoadOrder(page);
                }



            }
        }

        public string LoadStatus(int statusid)
        {
            var status = data.StatusOrders.SingleOrDefault(p => p.status_id == statusid);
            return status.status_name;
        }

        private void LoadOrderSearch(string NameSearch,int page)
        {

            var Order = data.Orders.Where(p => p.OrderID.Contains(NameSearch) || p.FullName.Contains(NameSearch))
                        .OrderByDescending(p => p.OrderTime).ToList();
            // Lấy tổng số sản phẩm
            int totalProducts = Order.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var order = Order.OrderByDescending(p => p.OrderID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptOrderList.DataSource = order;
            rptOrderList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();


        }


        private void LoadOrder(int page)
        {
            
                var Order = data.Orders.ToList();
                // Lấy tổng số sản phẩm
                int totalProducts = Order.Count();
                //số trang muốn hiển thị
                int PageSize = 5;
                // Tính toán số trang và làm tròn
                int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

                // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
                var order = Order.OrderByDescending(p => p.OrderTime)
                                    .Skip((page - 1) * PageSize)
                                    .Take(PageSize)
                                    .ToList();

                // Gán sản phẩm vào Repeater
                rptOrderList.DataSource = order;
                rptOrderList.DataBind();

                // Gán số trang vào phần phân trang
                List<int> pages = new List<int>();
                for (int i = 1; i <= totalPages; i++)
                {
                    pages.Add(i);
                }
                RepeaterPagination.DataSource = pages;
                RepeaterPagination.DataBind();

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            Response.Redirect("./Function/UpdateStatusOrder.aspx?id=" + id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string id = btn.CommandArgument;
            var order = data.Orders.SingleOrDefault(p => p.OrderID == id);
            var orderDetail = data.OrderDetails.Where(p => p.OrderID == id).ToList();
            data.OrderDetails.DeleteAllOnSubmit(orderDetail);
            data.Orders.DeleteOnSubmit(order);
            data.SubmitChanges();
            int page = 1;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out page);
            }
            LoadOrder(page);

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["SearchOrderAdmin"] = txtSearch.Text;
            string NameSearch = txtSearch.Text;
            int page = 0;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out page);
            }
            LoadOrderSearch(NameSearch, page);

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

            LoadOrder(0);
            txtSearch.Text = "";
            Session["SearchOrderAdmin"] = txtSearch.Text;
        }

        protected void rptOrderList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var roles = Session["Roles"] as List<string>;
                if (roles != null)
                {
                    var btnUpdate = (Button)e.Item.FindControl("btnUpdate");
                    var btnDelete = (Button)e.Item.FindControl("btnDelete");
                    if (btnUpdate != null)
                        btnUpdate.Visible = roles.Contains("Sửa Đơn Hàng");
                    if (btnDelete != null)
                        btnDelete.Visible = roles.Contains("Xóa Đơn Hàng");
                }
            }
        }
    }
}