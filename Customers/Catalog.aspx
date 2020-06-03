<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Catalog.aspx.cs" Inherits="Customers.Catalog" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catalog Home Page</title>
    <link href="Styles/catalog.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="catalogTable" CssClass="CellStyle" runat="server" Height="123px" Width="567" BackColor="#D5FFD5" BorderStyle="Groove"></asp:Table>
        <asp:Button ID="buttonTemp" runat="server" Text="Button" Visible="False" OnClick="buttonTemp_Click" />
        <br />
        <br />
        <asp:Label ID="rowSelectedTable" runat="server" CssClass="Labels" Text="Select Button" ForeColor="black" BackColor="#D5FFD5"></asp:Label>
    </form>
</body>
</html>
