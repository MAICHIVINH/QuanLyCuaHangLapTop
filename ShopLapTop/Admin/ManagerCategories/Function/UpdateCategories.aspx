<%@ Page Title="" Language="C#" MasterPageFile="../../Manager.Master" AutoEventWireup="true" CodeBehind="UpdateCategories.aspx.cs" Inherits="ShopLapTop.Admin.ManagerCategories.Function.UpdateCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/UpdateBrand.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <div class="container">
            <h1>Cập Nhật Loại Sản Phẩm</h1>
            <div class="group">
                <asp:Label ID="lblCategory" runat="server" Text="Tên nhóm sản phẩm:" class="label"> </asp:Label>
                <asp:TextBox ID="txtCategoriesName" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblStatus" runat="server" class="label" Text="Trạng Thái Dữ Liệu"></asp:Label><br />
                <asp:CheckBox ID="chkHidden" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Ẩn Dữ Liệu" OnCheckedChanged="chkHidden_CheckedChanged" /><br />
                <br />
                <asp:CheckBox ID="chkPresently" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Hiển Thị Dữ Liệu" OnCheckedChanged="chkPresently_CheckedChanged" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" CssClass="lblError" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnUpdateCategories" runat="server" CssClass="btnupdate" Text="Cập nhật" OnClick="btnUpdateCategories_Click" />
                <asp:Button ID="btnHomeCategories" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeCategories_Click" />
            </div>
        </div>
    </div>
</asp:Content>
