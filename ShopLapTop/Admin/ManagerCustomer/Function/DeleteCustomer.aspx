<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="DeleteCustomer.aspx.cs" Inherits="ShopLapTop.Admin.ManagerCustomer.Function.DeleteCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../../Style/UpdateStatusCustomer.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="wapper">
        <div class="container">
            <h1 style="color: #D94A8C;">Xóa Khách Hàng</h1>
            <div class="group">
                <asp:Label ID="lblCategory" runat="server" Text="Mã Khách Hàng" class="label"></asp:Label>
                <asp:TextBox ID="txtAccountId" ReadOnly="true" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="Label1" runat="server" Text="Tên Khách Hàng" class="label"></asp:Label>
                <asp:TextBox ID="txtNameCustomer" ReadOnly="true" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblStatus" runat="server" class="label" Text="Trạng Thái Khách Hàng"></asp:Label><br />
                <asp:CheckBox ID="chkHidden" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Mở Khách Hàng"/><br />
                <asp:CheckBox ID="chkPresently" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Khóa Khách Hàng" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="lblError" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnDeleteCustomer" runat="server" OnClientClick="return confirm('Bạn muốn Xóa tài khoản này không?')" CssClass="btnsave" Text="Xóa" OnClick="btnDeleteCustomer_Click" />
                <asp:Button ID="btnHomeCustomer" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeCustomer_Click" />
            </div>
        </div>
    </div>

</asp:Content>
