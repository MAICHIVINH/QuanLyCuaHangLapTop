<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="DeleteEmloyee.aspx.cs" Inherits="ShopLapTop.Admin.ManagerEmloyee.Function.DeleteEmloyee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../../../Style/AddEmloyee.css" rel="stylesheet" />
    <style>
        .error {
            text-align: center;
        }
        .label {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="wapper">
        <div class="container">
            <h1 style="color: #D94A8C;">Xóa Nhân Viên</h1>
            <div class="group">
                <asp:TextBox ID="txtEmloyeeID" CssClass="control" Placeholder="Mã Nhân Viên" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtFullName" CssClass="control" Placeholder="Họ và Tên" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtPhone" TextMode="Number" CssClass="control" Placeholder="Số điện thoại" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="control" Placeholder="Email" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtAddress" CssClass="control" Placeholder="Địa chỉ" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblRole" runat="server" class="label" Text="Quyền:"></asp:Label>
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
            <div class="error">
                <asp:Label ID="lblMessage" runat="server" Style=" text-align:center; color: red; font-style: italic;" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnDeleteEmloyee" runat="server" Text="Xóa" OnClientClick="return confirm('Bạn có muốn xóa nhân viên này không!')" CssClass="btnsave" OnClick="btnDeleteEmloyee_Click" />
                <asp:Button ID="btnHomeEmloyee" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeEmloyee_Click" />
            </div>

        </div>
    </div>
</asp:Content>
