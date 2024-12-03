<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="HomeContact.aspx.cs" Inherits="ShopLapTop.Admin.ManagerContact.HomeContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
         .container {
             width: 1250px;
         }
        .img {
            width: 100px;
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

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Quản Lý Thông Tin Liên Hệ</h1>
        <asp:Repeater ID="rptContact" OnItemDataBound="rptContact_ItemDataBound" runat="server">
            <HeaderTemplate>
                <table class="status-table">
                    <thead>
                        <tr>
                            <th width="50px">Mã</th>
                            <th width="370px">Địa chỉ</th>
                            <th width="250px">Điện thoại</th>
                            <th width="250px">Email</th>
                            <th width="250px">Chức Năng</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style="text-align: center">
                        <%# Eval("ContactID") %>

                    </td>
                    <td>
                        <%# Eval("Address") %>
                    </td>
                    <td>
                        <%# Eval("Phone") %>
                    </td>
                    <td>
                        <%# Eval("Email") %>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btnEdit" CommandArgument='<%# Eval("ContactID") %>' OnClick="btnUpdate_Click" Text="Sửa" />
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
                <a href="HomeContact.aspx?categories=<%# Request.QueryString["product"] %>&page=<%# Container.DataItem %>"
                    class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                    <%# Container.DataItem %>
                </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
