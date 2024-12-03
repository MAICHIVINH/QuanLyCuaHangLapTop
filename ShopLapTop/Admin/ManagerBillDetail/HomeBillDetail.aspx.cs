using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerBillDetail
{
    public partial class BillDetail : System.Web.UI.Page
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
                if (Session["SearchBillDetail"] != null)
                {
                    LoadAllBillSearch(Session["SearchBillDetail"].ToString(), page);
                    txtSearch.Text = Session["SearchBillDetail"].ToString();
                }
                else
                {
                    LoadAllBill(page);
                }
            }
        }


        private void LoadAllBillSearch(string NameSearch, int page)
        {
            var orderDetail = (from p in data.Products
                               join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                               where ord.OrderID.Contains(NameSearch)
                               select new
                               {
                                   OrderID = ord.OrderID,
                                   OrderDetailID = ord.OrderDetailID,
                                   ProductName = p.ProductName,
                                   ProductImage = p.Image,
                                   Quantity = ord.Quantity,
                                   Total = ord.UnitPrice
                               }
                              ).ToList();           // Lấy tổng số sản phẩm
            int totalProducts = orderDetail.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var brands = orderDetail.OrderByDescending(p => p.OrderDetailID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptBillDetail.DataSource = brands;
            rptBillDetail.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();
        }

        private void LoadAllBill( int page)
        {
            var orderDetail = (from p in data.Products
                               join ord in data.OrderDetails on p.ProductID equals ord.ProductID
                               select new
                               {
                                   OrderID = ord.OrderID,
                                   OrderDetailID = ord.OrderDetailID,
                                   ProductName = p.ProductName,
                                   ProductImage = p.Image,
                                   Quantity = ord.Quantity,
                                   Total = ord.UnitPrice
                               }
                              ).ToList();           // Lấy tổng số sản phẩm
            int totalProducts = orderDetail.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var brands = orderDetail.OrderByDescending(p => p.OrderDetailID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptBillDetail.DataSource = brands;
            rptBillDetail.DataBind();

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
            Session["SearchBillDetail"] = txtSearch.Text;
            LoadAllBillSearch(txtSearch.Text, 0);
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {

        }
    }
}