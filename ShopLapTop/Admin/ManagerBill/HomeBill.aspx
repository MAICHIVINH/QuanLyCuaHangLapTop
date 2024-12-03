<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="HomeBill.aspx.cs" Inherits="ShopLapTop.Admin.ManagerBill.HomeBill" %>
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
        <h1>Quản Lý Đơn Hàng</h1>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Nhập thông tin cần tìm..." CssClass="txtSearch"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Tìm Kiếm" CssClass="btnSearch" OnClick="btnSearch_Click" />
        <asp:Button ID="btnLoad" runat="server" Text="Tải lại" CssClass="btnSearch" OnClick="btnLoad_Click" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <%--    <asp:Label ID="Label1" runat="server" Text="Search"></asp:Label>--%>
        <asp:Repeater ID="rptOrderList" OnItemDataBound="rptOrderList_ItemDataBound" runat="server">
            <HeaderTemplate>
                <table class="status-table">
                    <thead>
                        <tr>
                            <th width="50px">Mã</th>
                            <th width="150px">Tên Người Dùng</th>
                            <th width="200px">Địa Chỉ</th>
                            <th width="120px">Ngày Đặt</th>
                            <th width="140px">Số Điện Thoại</th>
                            <th width="120px">Tổng Tiền</th>
                            <th width="120px">Ghi Chú</th>
                            <th width="130px">Trạng Thái</th>
                            <th width="160px">Chức Năng</th>
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
                        <%# Eval("FullName") %>
                    </td>
                    <td>
                        <%# Eval("Address") %>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("OrderTime") %>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("PhoneNumber") %>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("TotalAmount", "{0:N0}đ") %>
                    </td>
                    <td style="text-align: justify">
                        <%# Eval("Note") %>
                    </td>
                    <td>
                        <%# LoadStatus(int.Parse(Eval("Status").ToString())) %>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnUpdate" runat="server" Text="Sửa" OnClick="btnUpdate_Click" CssClass="btnEdit" CommandArgument='<%# Eval("OrderID") %>' />
                        <asp:Button ID="btnDelete" runat="server" Text="Xóa" OnClick="btnDelete_Click" OnClientClick="return confirm('Bạn có muốn xóa hóa đơn này không!')" CssClass="btnDelete" CommandArgument='<%# Eval("OrderID") %>' />
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
                <a href="HomeBill.aspx?Order=<%# txtSearch.Text %>&page=<%# Container.DataItem %>"
                    class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                    <%# Container.DataItem %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
