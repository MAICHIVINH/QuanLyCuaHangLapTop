<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ProductCategory.aspx.cs" Inherits="ShopLapTop.Views.Pages.ProductCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="new-products">
        <asp:Label ID="lblAcer" runat="server" CssClass="MongNhe" Text='<%# Eval("BrandName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="ProductRepeaterSearch" runat="server">
                <ItemTemplate>
                    <div class="product-card">
                        <asp:ImageButton ID="ProductImage" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("Image") %>' AlternateText="Laptop" PostBackUrl='<%# "~/Views/Pages/DetailProduct.aspx?idp=" + Eval("ProductID") %>' />
                        <p class="product-name">
                            <asp:HyperLink ID="ProductName" Color="Black" CssClass="product-link" runat="server" Text='<%# Eval("ProductName") %>' NavigateUrl='<%# "~/Views/Pages/DetailProduct.aspx?idp=" + Eval("ProductID") %>'></asp:HyperLink>
                        </p>
                        <br />
                        <p class="product-price">
                            <asp:Label ID="ProductPrice" runat="server" Text='<%# Eval("Price", "{0:N0}đ") %>'></asp:Label>
                        </p>
                        <br />
                        <p class="product-detail">
                            <asp:Label ID="ProductDetails" runat="server" Text='<%# Eval("Details").ToString().Trim().Replace("\n", "<br />") %>'></asp:Label>
                        </p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <br />
        <asp:Repeater ID="RepeaterPagination" runat="server">
            <ItemTemplate>
                <a href="ProductCategory.aspx?idc=<%# Request.QueryString["idc"] %>&page=<%# Container.DataItem %>"
                    class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                    <%# Container.DataItem %>
                 </a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
