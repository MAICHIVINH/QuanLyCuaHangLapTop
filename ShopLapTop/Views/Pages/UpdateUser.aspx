<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="ShopLapTop.Views.Pages.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            width: 100%;
            max-width: 500px;
            background-color: #fff;
            padding: 20px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
            margin: 0 auto;
        }

        .Infor .control {
            width: 100%;
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ddd;
            border-radius: 4px;
        }

        .group {
            display: flex;
            gap: 20px;
            align-items: center;
        }

        .error {
            text-align: center;
        }
        .btnUpdate {
            display: block;
            width: 100%;
            padding: 10px;
            font-size: 14px;
            color: #fff;
            background-color: #007bff;
            border: none;
            border-radius: 4px;
            cursor: pointer;
        }

        .btnUpdate:hover {
            background-color: #0056b3;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 30px;">
        <h2 style="text-align: center; color: #D94A8C;">Cập Nhật Thông Tin</h2>
        <br />
        <div class="Infor">
            <asp:TextBox ID="txtFullName" runat="server" CssClass="control" placeholder="Nhập họ tên"></asp:TextBox>
            <div class="group">
                <asp:CheckBox ID="ChkHis" runat="server" Text="Nam" AutoPostBack="true" />
                <asp:CheckBox ID="ChkHer" runat="server" Text="Nữ" AutoPostBack="true" /><br />
            </div>
            <br />
            <asp:TextBox ID="txtPhone" runat="server" CssClass="control" placeholder="Nhập số điện thoại"></asp:TextBox><br />
            <asp:TextBox ID="txtAddress" runat="server" CssClass="control" placeholder="Nhập địa chỉ"></asp:TextBox><br />
            <asp:TextBox ID="txtCity" runat="server" CssClass="control" placeholder="Nhập tỉnh/ thành phố"></asp:TextBox>
        </div>
        <br />
        <div class="error" >
            <asp:Label ID="lblMessage"  runat="server" Style="color: red; font-style: italic;"></asp:Label>
        </div>
        <br />
        <div>
            <asp:Button ID="btnUpdate" runat="server" CssClass="btnUpdate" Text="Cập nhật" />
        </div>
    </div>
</asp:Content>
