<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="EvaluateProduct.aspx.cs" Inherits="ShopLapTop.Views.Orders.EvaluateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/Evaluate.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 90px;">
        <h1 style="text-align: center; color: #D94A8C;">Đánh Giá Sản Phẩm</h1>
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

                <tr>
                    <td>
                        <asp:Label ID="lblOrderID" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:Image ID="lblIMAGE" runat="server" />
                    </td>
                    <td style="text-align: justify">
                        <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label>

                    </td>
                    <td style="text-align: justify">
                        <asp:Label ID="lblDetails" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblPrice" runat="server" Text=""></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblQuantity" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align: center">
                        <asp:Label ID="lblTotalAmount" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
            </tbody>
        </table>

        <div class="groupstar" style="display: block;">
            <asp:RadioButtonList ID="rbRating" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="⭐" Value="1"></asp:ListItem>
                <asp:ListItem Text="⭐⭐" Value="2"></asp:ListItem>
                <asp:ListItem Text="⭐⭐⭐" Value="3"></asp:ListItem>
                <asp:ListItem Text="⭐⭐⭐⭐" Value="4"></asp:ListItem>
                <asp:ListItem Text="⭐⭐⭐⭐⭐" Value="5"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <br />
        <div>
            <asp:Label ID="lblTest" CssClass="lblError" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnEvaluate" runat="server" CssClass="btnEvaluate" Text="Đánh Giá" OnClick="btnEvaluate_Click" />
        </div>
    </div>
</asp:Content>
