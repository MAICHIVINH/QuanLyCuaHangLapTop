<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateContact.aspx.cs" Inherits="ShopLapTop.Admin.ManagerContact.Function.UpdateContact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/UpdateContact.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <div class="container">
            <h1>Cập Nhật Thông Tin Liên Hệ</h1>
            <div class="group">
                <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:" class="label"> </asp:Label>
                <asp:TextBox ID="txtAddress" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
               <asp:Label ID="lblPhone" runat="server" Text="Điện thoại:" class="label"> </asp:Label>
                <asp:TextBox ID="txtPhone" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
               <asp:Label ID="lblEmail" runat="server" Text="Email:" class="label"> </asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" CssClass="lblError" runat="server" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnUpdateContact" runat="server" CssClass="btnupdate" Text="Cập nhật" OnClick="btnUpdateContact_Click" />
                <asp:Button ID="btnHomeContact" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeContact_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
