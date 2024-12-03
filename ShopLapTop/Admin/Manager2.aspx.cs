using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopLapTop.Admin
{
    public partial class Manager2 : System.Web.UI.Page
    {
        ShopDataContext data = new ShopDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadRevenue();
            LoadTopCustomer();
            LoadTopBranch();
            LoadTopProduct();
        }

        private void LoadRevenue()
        {
            var revenue = data.Products.ToList();
            decimal totalrevenue = 0;
            foreach(var item in revenue)
            {
                totalrevenue += (decimal)item.quantity_sold * (decimal)item.Price;
            }
            //txtrevenue.Text = totalrevenue.ToString("#,0") + "đ";
        }

        private void LoadTopCustomer()
        {
            var today = DateTime.Today;
            var topCustomers = (from or in data.Orders
                                join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                join p in data.Products on ord.ProductID equals p.ProductID
                                where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                                group new { ord.Quantity, p.Price, or.AccountID, or.FullName , or.PhoneNumber} by new { or.AccountID, or.FullName , or.PhoneNumber} into g
                                select new
                                {
                                    AccountID = g.Key.AccountID,
                                    FullName = g.Key.FullName,
                                    Phone = g.Key.PhoneNumber,
                                    Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                    Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                }
                                ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                                .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                                .ToList();

            rptTopCustomers.DataSource = topCustomers;
            rptTopCustomers.DataBind();
            btnExelCustomerDay.Visible = true;
            btnExelCustomerMonth.Visible = false;
            btnExelCustomerYear.Visible = false;

        }

        private void LoadTopBranch()
        {
            var today = DateTime.Today;
            var Brand = (from or in data.Orders
                           join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                           join p in data.Products on ord.ProductID equals p.ProductID
                           join br in data.Brands on p.BrandID equals br.BrandID
                           where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                           group new { ord.Quantity, p.Price, br.BrandName} by new {br.BrandName} into g
                           select new
                           {
                               BrandName = g.Key.BrandName,
                               TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                               TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                           }
                           ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
            rptTopBrands.DataSource = Brand;
            rptTopBrands.DataBind();
            btnExelBrandDay.Visible = true;
            btnExelBrandMonth.Visible = false;
            btnExelBrandYear.Visible = false;
        }

        private void LoadTopProduct()
        {
            var today = DateTime.Today;
            var product = (from or in data.Orders
                           join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                           join p in data.Products on ord.ProductID equals p.ProductID
                           where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                           group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                           select new
                           {
                               ProductsName = g.Key.ProductName,
                               ProductImage = g.Key.Image,
                               TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                               TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                           }
                          ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
            rptTopProducts.DataSource = product;
            rptTopProducts.DataBind();
            btnExelProdductDay.Visible = true;
            btnExelProductMonth.Visible = false;
            btnExelProductYear.Visible = false;
        }

        protected void btnView_Click(object sender, EventArgs e)
        {

        }

        protected void drlrevenue_SelectedIndexChanged(object sender, EventArgs e)
        {
            var today = DateTime.Today;
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ngày đầu tháng
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1); // Ngày đầu tháng kế tiếp
            var firstDayOfYear = new DateTime(DateTime.Now.Year, 1, 1); // Ngày đầu năm hiện tại
            var firstDayOfNextYear = firstDayOfYear.AddYears(1); // Ngày đầu năm kế tiếp
            if (drlrevenue.SelectedValue == "ddlDay")
            {
                // Top sản phẩm bán ra nhiều nhất
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                               ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                rptTopProducts.DataSource = product;
                rptTopProducts.DataBind();

                // Top khách hàng mua sản phẩm với số lượng nhiều nhất
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();

                rptTopCustomers.DataSource = topCustomers;
                rptTopCustomers.DataBind();

                //Top Thương hiệu được mua nhiều nhất
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandName } into g
                             select new
                             {
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                rptTopBrands.DataSource = Brand;
                rptTopBrands.DataBind();

                btnExelBrandDay.Visible = true;
                btnExelBrandMonth.Visible = false;
                btnExelBrandYear.Visible = false;
                btnExelBrandDay.Visible = true;
                btnExelBrandMonth.Visible = false;
                btnExelBrandYear.Visible = false;
                btnExelProdductDay.Visible = true;
                btnExelProductMonth.Visible = false;
                btnExelProductYear.Visible = false;
            }


            if (drlrevenue.SelectedValue == "ddlMonth")
            {
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                               ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                rptTopProducts.DataSource = product;
                rptTopProducts.DataBind();

                // Top khách hàng mua sản phẩm với số lượng nhiều nhất
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();

                rptTopCustomers.DataSource = topCustomers;
                rptTopCustomers.DataBind();

                //Top Thương hiệu được mua nhiều nhất
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandName } into g
                             select new
                             {
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                rptTopBrands.DataSource = Brand;
                rptTopBrands.DataBind();

                btnExelBrandDay.Visible = false;
                btnExelBrandMonth.Visible =true;
                btnExelBrandYear.Visible = false;
                btnExelBrandDay.Visible = false;
                btnExelBrandMonth.Visible = true;
                btnExelBrandYear.Visible = false;
                btnExelProdductDay.Visible = false;
                btnExelProductMonth.Visible = true;
                btnExelProductYear.Visible = false;
            }

            if (drlrevenue.SelectedValue == "ddlYear")
            {
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                               ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                rptTopProducts.DataSource = product;
                rptTopProducts.DataBind();

                // Top khách hàng mua sản phẩm với số lượng nhiều nhất
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();

                rptTopCustomers.DataSource = topCustomers;
                rptTopCustomers.DataBind();

                //Top Thương hiệu được mua nhiều nhất
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandName } into g
                             select new
                             {
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                rptTopBrands.DataSource = Brand;
                rptTopBrands.DataBind();

                btnExelBrandDay.Visible = false;
                btnExelBrandMonth.Visible = false;
                btnExelBrandYear.Visible = true;
                btnExelBrandDay.Visible = false;
                btnExelBrandMonth.Visible = false;
                btnExelBrandYear.Visible = true;
                btnExelProdductDay.Visible = false;
                btnExelProductMonth.Visible = false;
                btnExelProductYear.Visible = true;
            }

        }

        protected void btnExelProdduct_Click(object sender, EventArgs e)
        {

        }

        protected void btnExelBrand_Click(object sender, EventArgs e)
        {

        }

        protected void btnExelCustomer_Click(object sender, EventArgs e)
        {

        }

        protected void btnExelProdductDay_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsID = g.Key.ProductID,
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                              ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Sản Phẩm";
                    sheet.Cells[1, 2].Value = "Tên Sản Phẩm";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in product)
                    {
                        sheet.Cells[row, 1].Value = item.ProductsID;
                        sheet.Cells[row, 2].Value = item.ProductsName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3ProductDay.xlsx");
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

        protected void btnExelProductMonth_Click(object sender, EventArgs e)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ngày đầu tháng
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1); // Ngày đầu tháng kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsID = g.Key.ProductID,
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                              ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Sản Phẩm";
                    sheet.Cells[1, 2].Value = "Tên Sản Phẩm";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in product)
                    {
                        sheet.Cells[row, 1].Value = item.ProductsID;
                        sheet.Cells[row, 2].Value = item.ProductsName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Product_Month.xlsx");
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

        protected void btnExelProductYear_Click(object sender, EventArgs e)
        {
            var firstDayOfYear = new DateTime(DateTime.Now.Year, 1, 1); // Ngày đầu năm hiện tại
            var firstDayOfNextYear = firstDayOfYear.AddYears(1); // Ngày đầu năm kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var product = (from or in data.Orders
                               join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                               join p in data.Products on ord.ProductID equals p.ProductID
                               where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                               group new { ord.Quantity, p.Price, p.ProductName } by new { p.ProductID, p.ProductName, p.Image } into g
                               select new
                               {
                                   ProductsID = g.Key.ProductID,
                                   ProductsName = g.Key.ProductName,
                                   ProductImage = g.Key.Image,
                                   TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                   TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                               }
                              ).OrderByDescending(x => x.TotalSold).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Sản Phẩm";
                    sheet.Cells[1, 2].Value = "Tên Sản Phẩm";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in product)
                    {
                        sheet.Cells[row, 1].Value = item.ProductsID;
                        sheet.Cells[row, 2].Value = item.ProductsName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Product_Year.xlsx");
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

        protected void btnExelBrandDay_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandID, br.BrandName } into g
                             select new
                             {
                                 BrandId = g.Key.BrandID,
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Thương Hiệu";
                    sheet.Cells[1, 2].Value = "Tên Thương Hiệu";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in Brand)
                    {
                        sheet.Cells[row, 1].Value = item.BrandId;
                        sheet.Cells[row, 2].Value = item.BrandName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Brand_Day.xlsx");
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

        protected void btnExelBrandMonth_Click(object sender, EventArgs e)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ngày đầu tháng
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1); // Ngày đầu tháng kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandID, br.BrandName } into g
                             select new
                             {
                                 BrandId = g.Key.BrandID,
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Thương Hiệu";
                    sheet.Cells[1, 2].Value = "Tên Thương Hiệu";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in Brand)
                    {
                        sheet.Cells[row, 1].Value = item.BrandId;
                        sheet.Cells[row, 2].Value = item.BrandName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Brand_Month.xlsx");
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

        protected void btnExelBrandYear_Click(object sender, EventArgs e)
        {
            var firstDayOfYear = new DateTime(DateTime.Now.Year, 1, 1); // Ngày đầu năm hiện tại
            var firstDayOfNextYear = firstDayOfYear.AddYears(1); // Ngày đầu năm kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var Brand = (from or in data.Orders
                             join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                             join p in data.Products on ord.ProductID equals p.ProductID
                             join br in data.Brands on p.BrandID equals br.BrandID
                             where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                             group new { ord.Quantity, p.Price, br.BrandName } by new { br.BrandID, br.BrandName } into g
                             select new
                             {
                                 BrandId = g.Key.BrandID,
                                 BrandName = g.Key.BrandName,
                                 TotalSold = g.Sum(x => x.Quantity), // Tổng số lượng bán
                                 TotalRevenue = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu
                             }
                               ).OrderByDescending(x => x.TotalRevenue).Take(3).ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Thương Hiệu";
                    sheet.Cells[1, 2].Value = "Tên Thương Hiệu";
                    sheet.Cells[1, 3].Value = "Số Lượng Bán";
                    sheet.Cells[1, 4].Value = "Tổng Số Doanh Thu";

                    int row = 2;
                    foreach (var item in Brand)
                    {
                        sheet.Cells[row, 1].Value = item.BrandId;
                        sheet.Cells[row, 2].Value = item.BrandName;
                        sheet.Cells[row, 3].Value = item.TotalSold;
                        sheet.Cells[row, 4].Value = item.TotalRevenue;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Brand_Year.xlsx");
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

        protected void btnExelCustomerMonth_Click(object sender, EventArgs e)
        {
            var firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1); // Ngày đầu tháng
            var firstDayOfNextMonth = firstDayOfMonth.AddMonths(1); // Ngày đầu tháng kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= firstDayOfMonth && or.OrderTime < firstDayOfNextMonth
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Khách Hàng";
                    sheet.Cells[1, 2].Value = "Tên Khách Hàng";
                    sheet.Cells[1, 3].Value = "Số Điện Thoại";
                    sheet.Cells[1, 4].Value = "Tổng Số Lượng Sản Phẩm";
                    sheet.Cells[1, 4].Value = "Tổng Doanh Thu Của Khách Hàng";


                    int row = 2;
                    foreach (var item in topCustomers)
                    {
                        sheet.Cells[row, 1].Value = item.AccountID;
                        sheet.Cells[row, 2].Value = item.FullName;
                        sheet.Cells[row, 3].Value = item.Phone;
                        sheet.Cells[row, 4].Value = item.Quantity;
                        sheet.Cells[row, 5].Value = item.Total;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3ProductDay.xlsx");
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

        protected void btnExelCustomerDay_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= today && or.OrderTime < today.AddDays(1)
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Khách Hàng";
                    sheet.Cells[1, 2].Value = "Tên Khách Hàng";
                    sheet.Cells[1, 3].Value = "Số Điện Thoại";
                    sheet.Cells[1, 4].Value = "Tổng Số Lượng Sản Phẩm";
                    sheet.Cells[1, 4].Value = "Tổng Doanh Thu Của Khách Hàng";


                    int row = 2;
                    foreach (var item in topCustomers)
                    {
                        sheet.Cells[row, 1].Value = item.AccountID;
                        sheet.Cells[row, 2].Value = item.FullName;
                        sheet.Cells[row, 3].Value = item.Phone;
                        sheet.Cells[row, 4].Value = item.Quantity;
                        sheet.Cells[row, 5].Value = item.Total;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3 Khách Hàng Theo Tháng.xlsx");
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

        protected void btnExelCustomerYear_Click(object sender, EventArgs e)
        {
            var firstDayOfYear = new DateTime(DateTime.Now.Year, 1, 1); // Ngày đầu năm hiện tại
            var firstDayOfNextYear = firstDayOfYear.AddYears(1); // Ngày đầu năm kế tiếp
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var today = DateTime.Today;
                var topCustomers = (from or in data.Orders
                                    join ord in data.OrderDetails on or.OrderID equals ord.OrderID
                                    join p in data.Products on ord.ProductID equals p.ProductID
                                    where or.OrderTime >= firstDayOfYear && or.OrderTime < firstDayOfNextYear
                                    group new { ord.Quantity, p.Price, or.AccountID, or.FullName, or.PhoneNumber } by new { or.AccountID, or.FullName, or.PhoneNumber } into g
                                    select new
                                    {
                                        AccountID = g.Key.AccountID,
                                        FullName = g.Key.FullName,
                                        Phone = g.Key.PhoneNumber,
                                        Quantity = g.Sum(x => x.Quantity), // Tổng số lượng sản phẩm của khách hàng
                                        Total = g.Sum(x => x.Quantity * x.Price) // Tổng doanh thu của khách hàng
                                    }
                    ).OrderByDescending(x => x.Quantity) // Sắp xếp theo tổng số lượng sản phẩm mua
                    .Take(3) // Lấy 3 khách hàng mua nhiều sản phẩm nhất
                    .ToList();
                using (ExcelPackage excel = new ExcelPackage())
                {
                    var sheet = excel.Workbook.Worksheets.Add("Sheet1");

                    // Thêm tiêu đề cột
                    sheet.Cells[1, 1].Value = "Mã Khách Hàng";
                    sheet.Cells[1, 2].Value = "Tên Khách Hàng";
                    sheet.Cells[1, 3].Value = "Số Điện Thoại";
                    sheet.Cells[1, 4].Value = "Tổng Số Lượng Sản Phẩm";
                    sheet.Cells[1, 4].Value = "Tổng Doanh Thu Của Khách Hàng";


                    int row = 2;
                    foreach (var item in topCustomers)
                    {
                        sheet.Cells[row, 1].Value = item.AccountID;
                        sheet.Cells[row, 2].Value = item.FullName;
                        sheet.Cells[row, 3].Value = item.Phone;
                        sheet.Cells[row, 4].Value = item.Quantity;
                        sheet.Cells[row, 5].Value = item.Total;
                        row++;
                    }

                    // Tự động điều chỉnh độ rộng các cột
                    sheet.Cells[sheet.Dimension.Address].AutoFitColumns();

                    // Cấu hình phản hồi và tải file Excel
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Top3_Customer_Year.xlsx");
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
    }
}