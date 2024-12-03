<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShopLapTop.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/LoginAdmin.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="group">
                <h1>Welcome to the admin page!</h1>
                <asp:TextBox ID="txtEmail" CssClass="textbox" Placeholder="Nhập email" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:TextBox ID="txtPassWord" runat="server" CssClass="textbox" Placeholder="Nhập password" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <asp:CheckBox ID="ckAdmin" OnCheckedChanged="ckAdmin_CheckedChanged" runat="server" CssClass="input" AutoPostBack="true" Style="display: flex; gap: 20px;" Text="Đăng Nhập với tư cách Admin" />
            <br />
            <div >
                <asp:Label ID="lblError" runat="server" CssClass="error" Text=""></asp:Label>
            </div>
            <br />
            <div class="group">
                <asp:Button ID="btnLogin" runat="server" CssClass="btnLogin" Text="Đăng nhập" OnClick="btnLogin_Click" />
            </div>
        </div>
    </form>
</body>
</html>
