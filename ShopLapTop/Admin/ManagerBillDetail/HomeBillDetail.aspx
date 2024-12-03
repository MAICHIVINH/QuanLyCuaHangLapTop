<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="HomeBillDetail.aspx.cs" Inherits="ShopLapTop.Admin.ManagerBillDetail.BillDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 1250px;
        }
        .img {
            width: 100px;
        }

        .txtSearch {
            padding: 8px;
            font-size: 16px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 200px;
        }

        .btnSearch {
            margin-left: 10px;
            padding: 8px 12px;
            background-color: #5cb85c;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
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

        h1 {
            margin: 10px 0;
            font-size: 35px;
            color: hotpink;
            text-align: center;
        }

        .btnEdit {
            margin-left: 10px;
            padding: 8px 12px;
            background-color: #5cb85c;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btnDelete {
            margin-left: 10px;
            padding: 8px 12px;
            background-color: #f80000;
            color: white;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Chi tiết đơn hàng</h1>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Nhập thông tin cần tìm..." CssClass="txtSearch"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" CssClass="btnSearch" />
        <asp:Button ID="btnLoad" runat="server" Text="Tải lại" OnClick="btnLoad_Click" CssClass="btnSearch" />
        <asp:Repeater ID="rptBillDetail" runat="server">
            <HeaderTemplate>
                <table class="status-table">
                    <thead>
                        <tr>
                            <th width="130px">Mã ĐơnHàng</th>
                            <th width="200px">Tên Sản Phẩm</th>
                            <th width="130px">Hình Ảnh</th>
                            <th width="120px">Số Lượng</th>
                            <th width="150px">Tổng Tiền</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="text-align: center">
                        <%# Eval("OrderID") %>

                    </td>
                    <td>
                        <%# Eval("ProductName") %>
                    </td>

                    <td style="text-align: center">
                        <asp:Image ID="image" Width="100px" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("ProductImage")%>' />
                    </td>
                    <td style="text-align: center">
                        <%# Eval("Quantity")%>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("Total", "{0:N0}đ")%>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
               
            </FooterTemplate>
        </asp:Repeater>
        <br />
        <br />
        <asp:Repeater ID="RepeaterPagination" runat="server">
            <ItemTemplate>
                <a href="HomeBillDetail.aspx?product=<%# txtSearch.Text %>&page=<%# Container.DataItem %>"
                    class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                    <%# Container.DataItem %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
