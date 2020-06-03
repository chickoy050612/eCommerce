<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Customers.Checkout" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <link href="Styles/checkout.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <iframe id="CustomerFrame" class="CheckoutFrame" src="Customers.aspx" runat="server" style="left:10px; top:10px">
        </iframe>
        <iframe id="DetailsFrame" class="CheckoutFrame" src="Details.aspx" runat="server" style="left:750px; top:10px">
        </iframe>
    </form>
</body>
</html>
