<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="AddEmloyee.aspx.cs" Inherits="ShopLapTop.Admin.ManagerEmloyee.AddEmloyee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/AddEmloyee.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <div class="container">
            <h1>Thêm Nhân Viên</h1>
            <div class="group">
                <asp:TextBox ID="txtLastName" CssClass="control" Placeholder="Nhập họ" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtFirstName" CssClass="control" Placeholder="Nhập tên" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtPhone" TextMode="Number" CssClass="control" Placeholder="Nhập số điện thoại" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="control" Placeholder="Nhập email" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtAddress" CssClass="control" Placeholder="Nhập địa chỉ" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="control" Placeholder="Nhập mật khẩu" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtChangePassword" TextMode="Password" CssClass="control" Placeholder="Nhập lại mật khẩu" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblRole" runat="server" Text="Quyền:"></asp:Label>
            </div>
            <div class="groups">
                <asp:Repeater ID="rptRole" runat="server">
                    <ItemTemplate>
                        <div class="roles">
                                <asp:CheckBox ID="cbRole" runat="server" Style=" display: flex; gap: 20px;" CssClass="role" Text='<%# Eval("RoleName") %>' Value='<%# Eval("RoleID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="lblError" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnAddEmloyee" runat="server" Text="Thêm" CssClass="btnsave" OnClick="btnAddEmloyee_Click" />
                <asp:Button ID="btnHomeEmloyee" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeEmloyee_Click" />
            </div>

        </div>
    </div>
</asp:Content>
