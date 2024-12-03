<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="OrderStatus.aspx.cs" Inherits="ShopLapTop.Views.Orders.OrderStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Style/OrderStatus.css" rel="stylesheet" />
    <style>
        .Info {
            display: flex;
            gap: 20px;
        }

        .Info-Left, .Info-Right {
            flex: 1;
            padding: 10px;
            box-sizing: border-box;
        }

        .fcontrol {
            width: 100%;
            padding: 8px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .fgroup {
            display: flex;
            gap: 20px;
            align-items: center;
            margin-bottom: 15px;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 90px;">
        <h2>Danh sách sản phẩm</h2>
        <div>
            <asp:TextBox ID="txtSearchOrder" placeholder="Nhập thông tin cần tìm..." CssClass="txtSearch" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchOrder" CssClass="btnSearch" OnClick="btnSearchOrder_Click" runat="server" Text="Tìm Kiếm" />
            <asp:Label ID="lblError" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <asp:Repeater ID="rptCart" runat="server">
            <HeaderTemplate>
                <table class="productlist">
                    <thead>
                        <tr>
                            <th width="100px">Mã Đơn</th>
                            <th width="150px">Hình ảnh</th>
                            <th width="250px">Tên sản phẩm</th>
                            <th width="350px">Chi tiết</th>
                            <th width="130px">Đơn giá</th>
                            <th width="100px">Số lượng</th>
                            <th width="100px">Trạng Thái Đơn</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:Label ID="lblOrderID" runat="server" Text='<%# Eval("Orders.OrderID") %>'></asp:Label>
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
                    <td style="text-align: center">
                        <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("OrderDetails.Quantity") %>'></asp:Label>
                        <asp:Label ID="lbltotalprice" Visible="false" runat="server" Text='<%# Eval("OrderDetails.UnitPrice") %>'></asp:Label>
                        <asp:Label ID="lblProductId" Visible="false" runat="server" Text='<%# Eval("Product.ProductId") %>'></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblStatus"
                            Visible='<%# int.Parse(Eval("Orders.Status").ToString()) < 5 %>'
                            Text='<%# LoadStatus(int.Parse(Eval("Orders.Status").ToString())) %>'
                            runat="server"></asp:Label>

                        <asp:Button ID="btnStatus" CssClass="btnSearch"
                            Visible='<%# int.Parse(Eval("Orders.Status").ToString()) == 5 %>'
                            Text="Hàng đã được giao"
                            runat="server" OnClick="btnStatus_Click" CommandArgument='<%# Eval("Product.ProductId") %>' />
                    </td>

                    <%--<td><%# Eval("OrderDetails.UnitPrice", "{0:N0} đ") %></td>--%>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <h3>Tổng tiền:</h3>
        <asp:Label ID="lbltotalprice" runat="server" Text=""></asp:Label>
        <h3 style="text-align: center;">Thông tin khách hàng</h3>
        <div class="Info">
            <div class="Info-Left">
                <%--<asp:Label ID="lblFullName" runat="server" Text="Họ tên:"></asp:Label><br />--%>
                <asp:TextBox ID="txtFullname" runat="server" placeholder="Họ tên" CssClass="fcontrol" ReadOnly="True"></asp:TextBox><br />
                <div class="fgroup">
                    <%--<asp:Label ID="lblGender" runat="server" Text="Giới tính:"></asp:Label><br />
                    <br />--%>
                    <asp:CheckBox ID="ChkHis" Enabled="false" runat="server" Text="Nam" AutoPostBack="true" />
                    <asp:CheckBox ID="ChkHer" Enabled="false" runat="server" Text="Nữ" AutoPostBack="true" />
                </div>
               <%-- <asp:Label ID="lblPhone" runat="server" Text="Điện thoại:"></asp:Label><br />--%>
                <asp:TextBox ID="txtPhone" runat="server" placeholder="Điện thoại" CssClass="fcontrol" ReadOnly="True"></asp:TextBox>
                <%--<asp:Label ID="address" runat="server" Text="Địa chỉ:"></asp:Label><br />--%>
                <asp:TextBox ID="txtAddress" runat="server" placeholder="Địa chỉ" CssClass="fcontrol" ReadOnly="True"></asp:TextBox><br />
            </div>
            <div class="Info-Right">
                <%--<asp:Label ID="lblCity" runat="server" Text="Thành phố:"></asp:Label><br />--%>
                <asp:TextBox ID="txtCity" runat="server" placeholder="Tỉnh/Thành phố" CssClass="fcontrol" ReadOnly="True"></asp:TextBox><br />
                <%--<asp:Label ID="lblOrderDate" runat="server" Text="Ngày đặt:"></asp:Label><br />--%>
                <asp:TextBox ID="txtDate" runat="server" placeholder="Ngày đặt" CssClass="fcontrol" ReadOnly="True"></asp:TextBox><br />
                <%--<asp:Label ID="lblNote" runat="server" Text="Ghi chú:"></asp:Label><br />--%>
                <asp:TextBox ID="txtNote" runat="server" placeholder="Ghi chú" CssClass="fcontrol" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
