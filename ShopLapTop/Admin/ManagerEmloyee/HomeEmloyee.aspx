<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="HomeEmloyee.aspx.cs" Inherits="ShopLapTop.Admin.ManagerEmloyee.HomeEmloyee" %>
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
        <h1>Quản Lý Nhân Viên</h1>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Nhập thông tin cần tìm..." CssClass="txtSearch"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" CssClass="btnSearch" />
        <asp:Button ID="btnLoad" runat="server" Text="Tải lại" OnClick="btnLoad_Click" CssClass="btnSearch" />
        <asp:Button ID="btnAddEmloyee" CssClass="btnAdd" runat="server" Text="Thêm" OnClick="btnAddEmloyee_Click" />
        <asp:Repeater ID="rptEmloyeeList" OnItemDataBound="rptEmloyeeList_ItemDataBound" runat="server">
            <HeaderTemplate>
                <table class="status-table">
                    <thead>
                        <tr>
                            <th width="50px">Mã Nhân Viên</th>
                            <th width="180px">Họ Tên Nhân Viên</th>
                            <th width="100px">Số Điện Thoại</th>
                            <th width="120px">Email</th>
                            <th width="150px">Địa Chỉ</th>
                            <th width="120px">Ngày Vào</th>
                            <th width="110px">Trạng Thái</th>
                            <th width="150px">Chức Năng</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="text-align: center">
                        <%# Eval("emloyee_id") %>

                    </td>
                    <td>
                        <%# Eval("emloyee_fullname") %>
                    </td>

                    <td style="text-align: center">
                        <%# Eval("emloyee_phone") %>

                    </td>
                    <td>
                        <%# Eval("emloyee_email")%>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("emloyee_address")%>
                    </td>
                    <td style="text-align: center">
                        <%# Eval("emloyee_date")%>
                    </td>
                    <td style="text-align: center">
                        <%# LoadStatus(bool.Parse(Eval("emloyee_status").ToString())) %>
                    </td>
                    <%--                <td>
                    <%# Eval("Description") %>
                </td>--%>


                    <td style="text-align: center">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btnEdit" CommandArgument='<%# Eval("emloyee_id") %>' OnClick="btnUpdate_Click" Text="Sửa" />
                        <asp:Button ID="btnDelete" runat="server" CssClass="btnDelete" CommandArgument='<%# Eval("emloyee_id") %>' OnClick="btnDelete_Click" Text="Xóa" />
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
                <a href="HomeEmloyee.aspx?product=<%# txtSearch.Text %>&page=<%# Container.DataItem %>"
                    class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                    <%# Container.DataItem %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
