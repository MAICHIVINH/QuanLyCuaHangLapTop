<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShopLapTop.Login.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Style/Register.css" rel="stylesheet" />
    <style>
        .groups {
            display: flex;
            gap: 20px;
            align-items: center;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server" style="position: fixed;">
        <div class="container">
            <div class="images">
                <asp:Image ID="img" runat="server" ImageUrl="../Style/Images/resignter.png" AlternateText="Illustration" />
            </div>
            <div class="form">
                <h1>Tạo tài khoản mới</h1>
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtYourName" runat="server" CssClass="textbox" placeholder="Nhập tên" />
                    </div>
                </div>
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" TextMode="Email" placeholder="Nhập email" />
                    </div>
                </div>
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox" TextMode="Phone" placeholder="Số Điện Thoại" />
                    </div>
                </div>
                <div class="groups">
                    <asp:CheckBox ID="chkHis" runat="server" AutoPostBack="true" OnCheckedChanged="chkHis_CheckedChanged" Text="Nam" />
                    <asp:CheckBox ID="chkHer" runat="server" AutoPostBack="true" OnCheckedChanged="chkHer_CheckedChanged" Text="Nữ" />
                </div>
                <br />
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtAddress" runat="server" CssClass="textbox" placeholder="Nhập địa chỉ" />
                    </div>
                </div>
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtCity" runat="server" CssClass="textbox" placeholder="Tỉnh/Thành Phố bạn sinh sống" />
                    </div>
                </div>
                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" TextMode="Password" placeholder="Nhập mật khẩu" />
                    </div>
                </div>

                <div class="group">
                    <div class="wrapper">
                        <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="textbox" TextMode="Password" placeholder="Nhập lại mật khẩu" />
                    </div>
                </div>

                <div class="terms">
                    <asp:CheckBox ID="ChkTerms" AutoPostBack="true" OnCheckedChanged="ChkTerms_CheckedChanged" runat="server" />
                    <asp:Label ID="lblClause"  runat="server" Text="Tôi đồng ý tất cả các tuyên bố trong"></asp:Label>
                        <a href="#" style="text-decoration: none; font-style: italic;">Điều khoản dịch vụ</a>
                </div>

                <asp:Button ID="btnRegister" runat="server" Text="Đăng Ký" CssClass="btnregister" OnClick="btnRegister_Click" BackColor="Gray" />

                <asp:Literal ID="lblError" runat="server"></asp:Literal>

                <asp:Label ID="lbl" runat="server" Text="Bạn đã có tài khoản?"></asp:Label>
                    <a href="Logins.aspx" style="text-decoration: none;">Đăng nhập tại đây</a>
            </div>
        </div>
    </form>
</body>
</html>
