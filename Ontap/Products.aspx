<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Ontap.Products" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Sản Phẩm</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Sản Phẩm</h2>
    <asp:Repeater ID="ProductRepeater" runat="server">
        <ItemTemplate>
            <div>
                <asp:Image ID="ProductImage" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' Width="100px" Height="100px" />
                <asp:HyperLink ID="ProductLink" runat="server" NavigateUrl='<%# "ProductDetails.aspx?ProductID=" + Eval("MaHang") %>' Text='<%# Eval("TenHang") %>' />
                <p>Giá: <%# Eval("DonGia") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
