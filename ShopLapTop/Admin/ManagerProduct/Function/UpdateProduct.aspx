<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Manager.Master" AutoEventWireup="true" CodeBehind="UpdateProduct.aspx.cs" Inherits="ShopLapTop.Admin.ManagerProduct.Function.UpdateProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script src="https://cdn.tiny.cloud/1/1ltwngmor0as1pm1fyqud4iuiz9xu5p3es2xwfwtg7rh12zk/tinymce/7/tinymce.min.js" referrerpolicy="origin"></script>
    <link href="../../../Style/UpdateProduct.css" rel="stylesheet" />
     <script>
     tinymce.init({
         selector: '#tiny',
         plugins: [
             'a11ychecker', 'advlist', 'advcode', 'advtable', 'autolink', 'checklist', 'markdown',
             'lists', 'link', 'image', 'charmap', 'preview', 'anchor', 'searchreplace', 'visualblocks',
             'powerpaste', 'fullscreen', 'formatpainter', 'insertdatetime', 'media', 'table', 'help', 'wordcount'
         ],
         toolbar: 'undo redo | a11ycheck casechange blocks | bold italic backcolor | alignleft aligncenter alignright alignjustify |' +
             'bullist numlist checklist outdent indent | removeformat | code table help'
     });
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wapper">
        <h1 style="color: #D94A8C;">Cập Nhật Thông Tin Sản Phẩm</h1>
        <div class="container">
            <div class="group">
                <asp:Label ID="lblProductName" runat="server" Text="Tên sản phẩm: " class="label"> </asp:Label>
                <asp:TextBox ID="txtProductName" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="Label1" runat="server" Text="Giá: " class="label"> </asp:Label>
                <asp:TextBox ID="txtPrice" CssClass="control" TextMode="Number" runat="server" Text=""></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="Label2" runat="server" Text="Chi tiết: " class="label"> </asp:Label>
                <asp:TextBox ID="txtDetails" TextMode="MultiLine" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <div class="group">
                <asp:Label ID="Label3" runat="server" Text="Số lượng: " class="label"> </asp:Label>
                <asp:TextBox ID="txtStockQuantity" TextMode="Number" CssClass="control" runat="server"></asp:TextBox>
            </div>

            <div class="group">
                <asp:Label ID="Label4" runat="server" Text="Hình ảnh: " class="label"> </asp:Label>
                <asp:TextBox ID="txtNameFile" Visible="true" CssClass="control" runat="server"></asp:TextBox>

                <asp:FileUpload ID="FileImage" CssClass="control" runat="server" />
            </div>

            <div class="group">
                <asp:Label ID="Label5" runat="server" Text="Mô tả: " class="label"> </asp:Label>
                <div>
                    <textarea id="tiny" name="content"></textarea>
                </div>
            </div>
            <div class="group">
                <asp:Label ID="Label6" runat="server" Text="Nhóm sản phẩm: " class="label"> </asp:Label>
                <asp:DropDownList ID="ddlCategories" CssClass="control" runat="server"></asp:DropDownList>
            </div>
            <div class="group">
                <asp:Label ID="Label7" runat="server" Text="Thương hiệu: " class="label"> </asp:Label>
                <asp:DropDownList ID="ddlBrand" CssClass="control" runat="server"></asp:DropDownList>
            </div>
            <div class="group">
                <asp:Label ID="Label8" runat="server" Text="Giảm giá: " class="label"> </asp:Label>
                <asp:TextBox ID="txtDiscount" Text="0" TextMode="Number" CssClass="control" runat="server"></asp:TextBox>
            </div>
            <br />
            <div>
                <asp:Label ID="lblMessage" runat="server" CssClass="lblError" Text=""></asp:Label>
            </div>
            <br />
            <div>
                <asp:Button ID="btnUpdateProduct" runat="server" CssClass="btnsave" Text="Cập nhật" OnClick="btnUpdateProduct_Click" />
                <asp:Button ID="btnHomeProduct" runat="server" CssClass="btncancel" Text="Quay về"  OnClick="btnHomeProduct_Click" />
            </div>
        </div>
    </div>


    <asp:Literal ID="addScript" runat="server"></asp:Literal>
    <script>
        setup: (editor) => {
            editor.on('change', () => {
                editor.save(); // Đồng bộ nội dung về <textarea>
            });
        }

    </script>
</asp:Content>
