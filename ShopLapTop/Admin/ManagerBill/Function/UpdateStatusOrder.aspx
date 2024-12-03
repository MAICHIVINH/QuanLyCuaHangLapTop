<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateStatusOrder.aspx.cs" Inherits="ShopLapTop.Admin.ManagerBill.UpdateStatusOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../Style/UpdateStatusOrder.css" rel="stylesheet" />
    <style>
        h1 {
            text-align: center;
            margin-bottom: 20px;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <div class="container">
            <h1 style="color: #D94A8C; font-size: 28px;">Cập Nhật Trạng Thái Đơn Hàng</h1>
            <div class="group">
                <asp:Label ID="lblOrderID" runat="server" Text="Mã đơn hàng:" class="label" ></asp:Label>
                <asp:TextBox ID="txtOrderID" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblName" runat="server" class="label" Text="Họ tên khách hàng:"> </asp:Label>
                <asp:TextBox ID="txtFullName" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblAddress" runat="server" class="label" Text="Địa chỉ:"></asp:Label>
                <asp:TextBox ID="txtAddress" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblPhone" runat="server" class="label" Text="Số điện thoại:"></asp:Label>
                <asp:TextBox ID="txtPhone" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblNote" runat="server" class="label" Text="Ghi chú:"></asp:Label>
                <asp:TextBox ID="txtNote" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="lblStatus" runat="server" class="label" Text="Trạng thái:"></asp:Label>
                <asp:TextBox ID="txtStatus" Enabled="False" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="lblError" Text=""></asp:Label>
            </div>
            <br />
            <asp:Button ID="btnUpdateStatus" runat="server" CssClass="btnupdate" Text="Cập nhật" OnClick="btnUpdateStatus_Click" />
            
        </div>
    </div>
</asp:Content>
