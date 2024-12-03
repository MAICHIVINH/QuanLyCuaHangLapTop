<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="ShopLapTop.Login.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/ForgotPassword.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="form">
                <h2>Đổi Mật Khẩu</h2>
                <div class="group">
                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Nhập Email" CssClass="control"></asp:TextBox>
                </div>
                <br />
                <div>
                    <asp:Button ID="btnCheckEmail" runat="server" Text="Kiểm tra" OnClick="btnCheckEmail_Click" CssClass="btnCheck" />
                </div>
                <br />
                <div style="text-align: center;">
                    <asp:Label ID="lblMessage" Style="color: red; font-style: italic;" runat="server" CssClass="Message" />
                </div>
            </div>
            <div>
                <asp:Panel ID="pnlChangePassword" runat="server" Visible="false">
                    <div class="group">
                        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" placeholder="Nhập mật khẩu mới" CssClass="control"></asp:TextBox>
                    </div>
                    <div class="group">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Nhập mật lại khẩu" CssClass="control"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnUpdatePassword" runat="server" Text="Cập nhật mật khẩu" OnClick="btnUpdatePassword_Click" CssClass="btnUpdate" />
                    </div>
                    <br />
                   <a href="Logins.aspx" style="text-decoration: none;">Đăng nhập tại đây</a>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>
