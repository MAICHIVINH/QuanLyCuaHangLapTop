<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="AddBrand.aspx.cs" Inherits="ShopLapTop.Admin.ManagerBrand.Function.AddBrand" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/AddBrand.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <div class="container">
            <h1>Thêm Thương Hiệu Sản Phẩm</h1>
            <div class="group">
                <asp:Label ID="lblBrandName" runat="server" Text="Tên thương hiệu: " class="label"></asp:Label>
                <asp:TextBox ID="txtBrandName" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="lblStatus" class="label" runat="server" Text="Trạng Thái Dữ Liệu: "></asp:Label><br />
                <asp:CheckBox ID="chkHidden" runat="server" CssClass="input" AutoPostBack="true" Text="Ẩn Dữ Liệu" Style="display: flex; gap: 20px;" OnCheckedChanged="chkHidden_CheckedChanged" /><br />
                <br />
                <asp:CheckBox ID="chkPresently" runat="server" CssClass="input" AutoPostBack="true" Text="Hiển Thị Dữ Liệu" Style="display: flex; gap: 20px;" OnCheckedChanged="chkPresently_CheckedChanged" />
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" CssClass="lblError" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnAddBrand" runat="server" CssClass="btnsave" Text="Lưu" OnClick="btnAddBrand_Click" />
                <asp:Button ID="btnHomeBrand" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeBrand_Click" />
            </div>

        </div>
    </div>
</asp:Content>
