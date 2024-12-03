<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="ShopLapTop.Views.Orders.Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/Cart.css" rel="stylesheet" />
    <style>
        .group {
            display: flex;
            gap: 20px;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 90px;">
        <h1 style="text-align: center; color: #D94A8C;">Giỏ hàng</h1>
        <br />
        <h2>Danh sách sản phẩm</h2>
        <asp:Label ID="lblError" Style="color: red; font-style: italic;" runat="server" Text=""></asp:Label>
        <br />
        <br />
        <asp:Repeater ID="OrderRepeater" runat="server">
            <HeaderTemplate>
                <table class="product-list">
                    <thead>
                        <tr>
                            <th>Chọn</th>
                            <th>Sản phẩm</th>
                            <th>Đơn giá</th>
                            <th>Số lượng</th>
                            <th>Tổng tiền</th>
                            <th>Thao tác</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="ChkChoose" runat="server" />
                    </td>
                    <td>
                        <asp:Image ID="IMAGE" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("Image")%>' />
                        <%# Eval("ProductName") %>

                    </td>
                    <td>
                        <asp:Label ID="lbl" runat="server" Text='<%# Eval("Price", "{0:N0} đ") %>'></asp:Label>
                        <asp:Label Visible="false" ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>

                    </td>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                        <asp:Label ID="lblProductId" Visible="false" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label>

                    </td>
                    <td><%# Eval("TotalPrice", "{0:N0} đ") %></td>

                    <td>
                        <asp:Button ID="btnDelete" runat="server" CssClass="Delete" Text="Xóa" CommandArgument='<%# Eval("ProductId") %>' OnClick="btnDelete_Click" OnClientClick="return confirm('Bạn có thật sự muốn xóa sản phẩm này không?');" />
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <div class="Infor">
            <h3>Mua hàng</h3>
            <asp:TextBox ID="txtFullname" runat="server" Placeholder="Họ tên" CssClass="control" />
            <asp:TextBox ID="txtPhone" runat="server" CssClass="control" Placeholder="Số điện thoại" />
            <div class="group">
                <asp:CheckBox ID="ChkHis" runat="server" Text="Nam" AutoPostBack="true" OnCheckedChanged="ChkHis_CheckedChanged" />
                <asp:CheckBox ID="ChkHer" runat="server" Text="Nữ" AutoPostBack="true" OnCheckedChanged="ChkHer_CheckedChanged" />
            </div>
            <br />
            <asp:TextBox ID="txtAddress" runat="server" CssClass="control" Placeholder="Địa chỉ" />
            <asp:TextBox ID="txtCity" runat="server" CssClass="control" Placeholder="Thành phố"></asp:TextBox>
            <asp:TextBox ID="txtNote" runat="server" CssClass="control" Placeholder="Ghi chú"></asp:TextBox>
            <asp:Button ID="btnSubmit" runat="server" CssClass="Submit" Text="Mua hàng" OnClick="btnSubmit_Click" />
        </div>
    </div>
</asp:Content>

