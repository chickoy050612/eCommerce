<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="Customers.Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Details</title>
    <link href="Styles/details.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="TableDetailGrid" CssClass="CellStyle" Height="123px" Width="300px" BackColor="#D5FFD5" BorderStyle="Dashed" runat="server"></asp:Table>
        <br />
        <asp:Label ID="LabelTotal" CssClass="LabelTotal" runat="server" Text="0.00" style="left:156px; bottom:25px;"></asp:Label>
        <asp:CheckBox ID="CheckMailingList" runat="server" CssClass="Checkboxes" Text="Add Me To Your Mailing List"/>
        <asp:Button ID="PayButton" CssClass="Buttons" style="left:20px; bottom:25px" runat="server" Text="Pay For My Order" />
        <asp:Button ID="SalesReport" CssClass="Buttons" style="left:296px; bottom:25px" runat="server" Text="Sales Report" OnClick="SalesReport_Click" />
    </form>
</body>
</html>
