<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateEmloyee.aspx.cs" Inherits="ShopLapTop.Admin.ManagerEmloyee.Function.UpdateEmloyee" %>
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
        <div class="container" style="height: 640px; position: fixed;">
            <h1 style="color: #D94A8C;">Cập Nhật Nhân Viên</h1>
            <div>
                <asp:Label ID="lblRole" class="label" runat="server" Text="Quyền:"></asp:Label>
            </div>
            <div class="groups">
                <asp:Repeater ID="rptRole" runat="server">
                    <ItemTemplate>
                        <div class="roles">
                            <asp:CheckBox ID="cbRole" runat="server" Style="display: flex; gap: 20px;" CssClass="role" Text='<%# Eval("RoleName") %>' Value='<%# Eval("RoleID") %>' />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />

            <div class="group">
                <asp:Label ID="lblStatus" runat="server" class="label" Text="Trạng Thái Nhân Viên:"></asp:Label><br /> <br />
                <div>
                    <asp:CheckBox ID="chkHidden" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Mở Nhân Viên" OnCheckedChanged="chkHidden_CheckedChanged" /><br />
                    <asp:CheckBox ID="chkPresently" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Khóa Nhân Viên" OnCheckedChanged="chkPresently_CheckedChanged" />
                </div>

            </div>
            <br />
            <div class="error">
                <asp:Label ID="lblMessage" runat="server" Style=" text-align:center; color: red; font-style: italic;" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnUpdateEmloyee" runat="server" Text="Cập Nhật" CssClass="btnsave" OnClick="btnUpdateEmloyee_Click" />
                <asp:Button ID="btnHomeEmloyee" runat="server" CssClass="btncancel" Text="Quay về" OnClick="btnHomeEmloyee_Click" />
            </div>
        </div>
    </div>
</asp:Content>
