using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin.ManagerCategories
{
    public partial class HomeCategories : System.Web.UI.Page
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
                if (Session["SearchCategoriesAdmin"] != null)
                {
                    LoadAllCategoriesSearch(Session["SearchCategoriesAdmin"].ToString(), page);
                    txtSearch.Text = Session["SearchCategoriesAdmin"].ToString();
                }
                else
                {
                    LoadAllCategories(page);
                }
                var roles = Session["Roles"] as List<String>;

                if (roles.Contains("Thêm Loại Sản Phẩm"))
                {
                    btnAddCategory.Visible = true;
                }
            }
        }

        public string LoadStatus(bool status)
        {
            if(status == true)
            {
                return "Dữ Liệu Đang Hiển Thị";
            } else
            {
                return "Dữ Liệu Đang Ẩn";
            }
        }

        public int TotalQuantityProductCategories(int categoriId)
        {
            var CountCategories = data.Products.Where(p => p.CategoryID == categoriId).Count();
            return CountCategories;
        }
        private void LoadAllCategoriesSearch(string search,int page)
        {
            var CategoriesSearch = data.ProductCategories.Where(p => p.CategoryName.Contains(search) || p.CategoryID.ToString().Contains(search))
                .OrderByDescending(p => p.CategoryID).ToList();            // Lấy tổng số sản phẩm
            int totalProducts = CategoriesSearch.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var category = CategoriesSearch.OrderByDescending(p => p.CategoryID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptCategoriesList.DataSource = category;
            rptCategoriesList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();


        }


        private void LoadAllCategories(int page)
        {
            var categories = data.ProductCategories.ToList();
            // Lấy tổng số sản phẩm
            int totalProducts = categories.Count();
            //số trang muốn hiển thị
            int PageSize = 5;
            // Tính toán số trang và làm tròn
            int totalPages = (int)Math.Ceiling((double)totalProducts / PageSize);

            // Truy vấn sản phẩm theo thứ tự ID giảm dần và phân trang
            var category = categories.OrderByDescending(p => p.CategoryID).Skip((page - 1) * PageSize).Take(PageSize).ToList();

            // Gán sản phẩm vào Repeater
            rptCategoriesList.DataSource = category;
            rptCategoriesList.DataBind();

            // Gán số trang vào phần phân trang
            List<int> pages = new List<int>();
            for (int i = 1; i <= totalPages; i++)
            {
                pages.Add(i);
            }
            RepeaterPagination.DataSource = pages;
            RepeaterPagination.DataBind();


        }

        protected void btnAddCategory_Click(object sender, EventArgs e)
        {
            Response.Redirect("./Function/AddCategories.aspx");

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("./Function/UpdateCategories.aspx?id=" + id);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = int.Parse(button.CommandArgument);
            Response.Redirect("./Function/DeleteCategories.aspx?id=" + id);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Session["SearchCategoriesAdmin"] = txtSearch.Text;
            string NameSearch = txtSearch.Text;
            int page = 0;
            if (Request.QueryString["page"] != null)
            {
                int.TryParse(Request.QueryString["page"], out page);
            }
            LoadAllCategoriesSearch(NameSearch, page);
        }

        protected void btnExel_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var pages = data.ProductCategories.OrderByDescending(p => p.CategoryID).ToList();

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Loại Sản Phẩm";
                    sheet.Cells[1, 2].Value = "Tên Loại Sản Phẩm";
                    sheet.Cells[1, 3].Value = "Trạng Thái";
                    sheet.Cells[1, 4].Value = "Tổng Số Lượng Sản Phẩm";

                    int row = 2;
                    foreach (var item in pages)
                    {
                        sheet.Cells[row, 1].Value = item.CategoryID;
                        sheet.Cells[row, 2].Value = item.CategoryName;
                        sheet.Cells[row, 3].Value = LoadStatus(bool.Parse(item.Status.ToString()));
                        sheet.Cells[row, 4].Value = TotalQuantityProductCategories(item.CategoryID);
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=ExportedData.xlsx");
                    Response.BinaryWrite(excel.GetAsByteArray());
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có
                Response.Write($"<script>alert('Đã xảy ra lỗi: {ex.Message}');</script>");
            }

        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            LoadAllCategories(0);
            txtSearch.Text = "";
            Session["SearchCategoriesAdmin"] = txtSearch.Text;
        }

        protected void rptCategoriesList_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var roles = Session["Roles"] as List<string>;
                if (roles != null)
                {
                    var btnUpdate = (Button)e.Item.FindControl("btnUpdate");
                    var btnDelete = (Button)e.Item.FindControl("btnDelete");

                    if (btnUpdate != null)
                        btnUpdate.Visible = roles.Contains("Sửa Loại Sản Phẩm");

                    if (btnDelete != null)
                        btnDelete.Visible = roles.Contains("Xóa Loại Sản Phẩm");
                }
            }
        }
    }
}