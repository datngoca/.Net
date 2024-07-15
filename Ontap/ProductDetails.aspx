<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="Ontap.ProductDetails" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Chi Tiết Sản Phẩm</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Chi Tiết Sản Phẩm</h2>
    <asp:Image ID="ProductImage" runat="server" Width="200px" Height="200px" />
    <h3><asp:Label ID="ProductName" runat="server" /></h3>
    <p>Giá: <asp:Label ID="ProductPrice" runat="server" /></p>
    <p>Đơn vị tính: <asp:Label ID="ProductUnit" runat="server" /></p>
    <p><asp:Label ID="ProductDescription" runat="server" /></p>
</asp:Content>
