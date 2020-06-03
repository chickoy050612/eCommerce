<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Customers.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Default Page</title>
    <link href="Styles/default.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panMain" runat="server" Height="100px" BorderStyle="Solid" BorderWidth="3" Font-Names="Jokerman" Font-Size="XX-Large" BackColor="#D5FFD5" BorderColor="#404744" CssClass="MainPanel" ForeColor="#000000">Roman Exotic Pet Store
            <asp:Button ID="btnPromo" runat="server" style="top:50px; left:200px" Text="Promotions" CssClass="Buttons" OnClick="btnPromo_Click" BorderStyle="Dotted" Font-Size="Large" />
            <asp:Button ID="btnCatalog" runat="server" style="top:50px; left:370px" Text="Catalog" CssClass="Buttons" OnClick="btnCatalog_Click" BorderStyle="Dotted" Font-Size="Large" />
            <asp:Button ID="btnCart" runat="server" style="top:50px; left:540px" Text="Cart" CssClass="Buttons" OnClick="btnCart_Click" BorderStyle="Dotted" Font-Size="Large" />
            <asp:Button ID="btnWeather" runat="server" style="top:50px; left:710px" Text="Weather Page" CssClass="Buttons" OnClick="btnWeather_Click" BorderStyle="Dotted" Font-Size="Large" />
            <asp:Button ID="btnCustomers" runat="server" style="top:50px; left:880px" Text="Customers" CssClass="Buttons" OnClick="btnCustomers_Click" BorderStyle="Dotted" Font-Size="Large" />
            <asp:Button ID="btnProducts" runat="server" style="top:50px; left:1050px" Text="Products" CssClass="Buttons" OnClick="btnProducts_Click" BorderStyle="Dotted" Font-Size="Large" />
        </asp:Panel>
        <iframe id="Myframe" class="MainFrame" src="" runat="server">
        </iframe>
    </form>
</body>
</html>