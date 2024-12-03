<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="Manager2.aspx.cs" Inherits="ShopLapTop.Admin.Manager2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Style/statistic.css" rel="stylesheet" />
    <style>
        .table img {
            max-width: 100px;
            width: 100px;
            height: auto;
            vertical-align: middle;
            margin-right: 10px;
        }
        .btnAdd {
            margin-left: 10px;
            padding: 8px 12px;
            background-color: #5cb85c;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            float: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1 style="color: #D94A8C;">Dashboard Avdice</h1>
        <div class="group">
            <div>
                <asp:Label ID="lblrevenue" runat="server" Text="Doanh thu theo: "></asp:Label>
            </div>
            <div>
                <asp:DropDownList ID="drlrevenue" AutoPostBack="true" class="drlRevenue" runat="server" OnSelectedIndexChanged="drlrevenue_SelectedIndexChanged">
                    <asp:ListItem Value="ddlDay">Ngày</asp:ListItem>
                    <asp:ListItem Value="ddlMonth">Tháng</asp:ListItem>
                    <asp:ListItem Value="ddlYear">Năm</asp:ListItem>
                </asp:DropDownList>
            </div>
       <%-- <div>
            <asp:Label ID="lblTongDoanhThu" runat="server" Text="Tổng doanh thu:" class="revenue"></asp:Label>
            <asp:Label ID="txtrevenue"  runat="server"></asp:Label>

        </div>--%>
        </div>

        <div class="group">
            <h2 style="color: #D94A8C;">Top 3 sản phẩm bán ra nhiều nhất</h2>
            <asp:Repeater ID="rptTopProducts" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th width="60px">Hạng</th>
                                <th width="250px">Tên Sản Phẩm</th>
                                <th width="100px">Hình Ảnh</th>
                                <th width="100px">Số lượng bán</th>
                                <th width="100px">Tổng giá</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;"><%# Container.ItemIndex + 1 %></td>
                        <td><%# Eval(" ProductsName") %></td>
                        <td style="text-align: center;"><asp:Image ID="Image" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("ProductImage")%>' /></td>
                        <td style="text-align: center;"><%# Eval("TotalSold ").ToString() %></td>
                        <td style="text-align: center;"><%# Eval("TotalRevenue", "{0:N0}đ") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="btnExelProdductDay" runat="server" Visible="false" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelProdductDay_Click" />
            <asp:Button ID="btnExelProductMonth" runat="server" Visible="false" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelProductMonth_Click" />
            <asp:Button ID="btnExelProductYear" runat="server" Visible="false" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelProductYear_Click" />

        </div>

        <div class="group">
            <h2 style="color: #D94A8C;">Top 3 thương hiệu có doanh thu cao nhất</h2>
            <asp:Repeater ID="rptTopBrands" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th width="100px">Hạng</th>
                                <th width="100px">Thương Hiệu</th>
                                <th width="100px">Số Lượng</th>
                                <th width="100px">Doanh Thu</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;"><%# Container.ItemIndex + 1 %></td>
                        <td style="text-align: center;"><%# Eval("BrandName") %></td>
                        <td style="text-align: center;"><%# Eval("TotalSold") %></td>
                        <td style="text-align: center;"><%# Eval("TotalRevenue", "{0:N0}đ") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
                        <asp:Button ID="btnExelBrandDay" runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelBrandDay_Click" />
                        <asp:Button ID="btnExelBrandMonth"  runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelBrandMonth_Click"/>
                        <asp:Button ID="btnExelBrandYear" runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelBrandYear_Click" />
        </div>


        <div class="group">
            <h2 style="color: #D94A8C;">Top 3 khách hàng đặt nhiều số lượng sản phẩm nhất</h2>
            <asp:Repeater ID="rptTopCustomers" runat="server">
                <HeaderTemplate>
                    <table class="table">
                        <thead>
                            <tr>
                                <th width="100px">Hạng</th>
                                <th width="100px">Mã Khách Hàng</th>
                                <th width="100px">Tên Khách Hàng</th>
                                <th width="100px">Số điện thoại</th>
                                <th width="100px">Số Đơn Hàng</th>
                                <th width="100px">Tổng Giá Trị</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style="text-align: center;"><%# Container.ItemIndex + 1 %></td>
                        <td style="text-align: center;"><%# Eval("AccountID") %></td>
                        <td style="text-align: center;"><%# Eval("FullName") %></td>
                        <td style="text-align: center;"><%# Eval("Phone") %></td>
                        <td style="text-align: center;"><%# Eval("Quantity") %></td>
                        <td style="text-align: center;"><%# Eval("Total", "{0:N0}đ") %></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
               
                </FooterTemplate>
            </asp:Repeater>
            <asp:Button ID="btnExelCustomerDay" runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelCustomerDay_Click" />
            <asp:Button ID="btnExelCustomerMonth" runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelCustomerMonth_Click" />
            <asp:Button ID="btnExelCustomerYear" runat="server" CssClass="btnAdd" Text="Xuất Exel" OnClick="btnExelCustomerYear_Click" />
        </div>
    </div>
</asp:Content>
