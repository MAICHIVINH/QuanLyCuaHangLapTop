<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Logins.aspx.cs" Inherits="ShopLapTop.Login.Logins" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/Logins.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="image">
                <asp:Image ID="Image" runat="server" ImageUrl="../Style/Images/resignter.png" AlternateText="Image" />
            </div>
            <div class="loginform">
                <h2>Đăng nhập</h2>
                <asp:Panel ID="LoginForm" runat="server">
                    <div>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="input" Style="margin-bottom: 20px" placeholder="Nhập Email" />
                    </div>
                    <div>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="input" TextMode="Password" placeholder="Nhập Mật Khẩu" />
                    </div>
                    <div class="links">
                        <a href="Register.aspx">Đăng ký tài khoản</a> |
                    <a href="ForgotPassword.aspx">Quên mật khẩu?</a>
                    </div>
                    <br />
                    <asp:Label ID="lblError" Style="color: red; font-style: italic;" runat="server"></asp:Label>
                    <br />
                    <br />
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" CssClass="submit" OnClick="btnLogin_Click" />
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
