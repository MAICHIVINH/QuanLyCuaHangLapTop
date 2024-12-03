<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="ProductGroup.aspx.cs" Inherits="ShopLapTop.Views.Pages.ProductGroup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="new-products">
      <asp:Label ID="lblMongNhe" runat="server" CssClass="MongNhe" Text='<%# Eval("ProductCategory") %>'></asp:Label>
     <div class="product-grid">
         <asp:Repeater ID="ProductRepeaterSearch" runat="server">
             <ItemTemplate>
                 <div class="product-card">
                     <asp:ImageButton ID="ProductImage" runat="server" ImageUrl='<%# "~/Style/Images/" + Eval("Image") %>' AlternateText="Laptop" PostBackUrl='<%# "~/Views/Pages/DetailProduct.aspx?idp=" + Eval("ProductID") %>' />
                     <p class="product-name">
                         <asp:HyperLink ID="ProductNameLabel" Color="Black" CssClass="product-link" runat="server" Text='<%# Eval("ProductName") %>' NavigateUrl='<%# "~/Views/Pages/DetailProduct.aspx?idp=" + Eval("ProductID") %>'></asp:HyperLink>
                     </p>
                     <br />
                     <p class="product-price">
                         <asp:Label ID="ProductPriceLabel" runat="server" Text='<%# Eval("Price", "{0:N0}đ") %>'></asp:Label>
                     </p>
                     <br />
                     <p class="product-detail">
                         <asp:Label ID="Label2" runat="server" Text='<%# Eval("Details").ToString().Trim().Replace("\n", "<br />") %>'></asp:Label>
                     </p>
                 </div>
             </ItemTemplate>
         </asp:Repeater>
     </div>
     <br />
     <br />
     <asp:Repeater ID="RepeaterPagination" runat="server">
         <ItemTemplate>
             <a href="ProductGroup.aspx?idg=<%# Request.QueryString["idg"] %>&page=<%# Container.DataItem %>"
                 class="pagination-link <%# Request.QueryString["page"] != null && Request.QueryString["page"] == Container.DataItem.ToString() ? "active" : "" %>">
                 <%# Container.DataItem %>
                 </a>
         </ItemTemplate>
     </asp:Repeater>
 </div>
</asp:Content>
