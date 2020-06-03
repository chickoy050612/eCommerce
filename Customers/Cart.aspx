<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Customers.Cart" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart Home Page</title>
    <link href="Styles/cart.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="cartTable" CssClass="CellStyle"  runat="server" Height="123px" Width="567px" BackColor="#D5FFD5" BorderStyle="Groove"></asp:Table>
        <asp:Button ID="removeButtonTemplate" runat="server" Text="Button" style="visibility:hidden"/>
        <br />
        <br />
        <asp:Label ID="lblRowSelected" CssClass="Labels" runat="server" Text="...select a button" ForeColor="black" BackColor="#D5FFD5"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblTotal" CssClass="LabelTotal" runat="server" Text="0.00" ForeColor="red"></asp:Label>
        <asp:Button ID="btnCalculate" runat="server" Text="Recalculate Total" Width="134px" />
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout" Width="134px" OnClick="btnCheckout_Click"/>
    </form>
</body>
</html>
