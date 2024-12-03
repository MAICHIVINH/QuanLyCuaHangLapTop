<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="ShopLapTop.Views.Orders.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/OrderStatus.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 90px;">
        <h1 style="text-align: center; color: #D94A8C;">Lịch sử đơn hàng</h1>
        <br />
        <h2>Danh sách sản phẩm</h2>
        <asp:Repeater ID="rptOrderHistories" runat="server">
            <HeaderTemplate>
                <table class="productlist">
                    <thead>
                        <tr>
                            <th width="100px">Mã đơn hàng</th>
                            <th width="150px">Hình ảnh</th>
                            <th width="250px">Tên sản phẩm</th>
                            <th width="350px">Chi tiết</th>
                            <th width="130px">Giá</th>
                            <th width="100px">Số lượng</th>
                            <th width="250px">Tổng tiền</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("OrderHistories.OrderID") %>'></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="IMAGE" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("Product.Image")%>' />
                    </td>
                    <td style="text-align: justify">
                        <%# Eval("Product.ProductName") %>

                    </td>
                    <td style="text-align: justify">
                        <%# Eval("Product.Details") %>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("Product.Price", "{0:N0} đ") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("OrderHistories.Quantity") %>'></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblTotalAmount" runat="server" Text='<%# Eval("OrderHistories.TotalAmount", "{0:N0} đ") %>'></asp:Label>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
