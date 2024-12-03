<%@ Page Title="" Language="C#" MasterPageFile="~/Index.Master" AutoEventWireup="true" CodeBehind="SubPage.aspx.cs" Inherits="ShopLapTop.SubPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="new-products">
        <%--  Sản phẩm nhóm mỏng nhẹ--%>
        <asp:Label ID="lblMongNhe" runat="server" CssClass="MongNhe" Text='<%# Eval("CategoryName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="RepeaterMongNhe" runat="server">
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
        <asp:Button ID="LoadMoreMongNhe" runat="server" Text="Xem thêm" CssClass="btnMore" OnClick="LoadMoreMongNhe_Click" />
    </div>

    <div class="new-products">
        <%--Sản phẩm nhóm văn phòng --%>
        <asp:Label ID="lblVanPhong" runat="server" CssClass="MongNhe" Text='<%# Eval("CategoryName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="RepeaterVanPhong" runat="server">
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
        <asp:Button ID="LoadMoreVanPhong" runat="server" Text="Xem thêm" CssClass="btnMore" OnClick="LoadMoreVanPhong_Click" />
    </div>


    <div class="new-products">
        <%--Sản phẩm nhóm Gaming --%>
        <asp:Label ID="lblGaming" runat="server" CssClass="MongNhe" Text='<%# Eval("CategoryName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="RepeaterGaming" runat="server">
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
        <asp:Button ID="LoadMoreGaming" runat="server" Text="Xem thêm" CssClass="btnMore" OnClick="LoadMoreGaming_Click" />
    </div>

    <div class="new-products">
        <%--Sản phẩm nhóm Macbook --%>
        <asp:Label ID="lblMacBook" runat="server" CssClass="MongNhe" Text='<%# Eval("CategoryName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="RepeaterMacBook" runat="server">
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
        <asp:Button ID="LoadMoreMacbook" runat="server" Text="Xem thêm" CssClass="btnMore" OnClick="LoadMoreMacbook_Click" />
    </div>

    <div class="new-products">
        <%--Sản phẩm nhóm cao cấp --%>
        <asp:Label ID="lblCaoCap" runat="server" CssClass="MongNhe" Text='<%# Eval("CategoryName") %>'></asp:Label>
        <div class="product-grid">
            <asp:Repeater ID="RepeaterCaoCap" runat="server">
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
        <asp:Button ID="LoadMoreCaoCap" runat="server" Text="Xem thêm" CssClass="btnMore" OnClick="LoadMoreCaoCap_Click" />
    </div>
</asp:Content>
