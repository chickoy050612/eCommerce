<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customers.aspx.cs" Inherits="Customers.Customers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/customers.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="CustomerPanel" CssClass="MainPanel" runat="server">
            <asp:Label ID="CustomerLabelID" runat="server" CssClass="Labels" style="left:10px; top:20px;" Text="Customer ID:"></asp:Label>
            <asp:TextBox ID="CustomerTxtID" CssClass="Textboxes" style="left:130px; top:20px; width:200px; color:red;" runat="server"></asp:TextBox>

            <asp:Label ID="FirstNameLabel" runat="server" CssClass="Labels" style="left:10px; top:50px;" Text="First Name:"></asp:Label>
            <asp:TextBox ID="FirstNameTxt" CssClass="Textboxes" style="left:130px; top:50px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Label ID="LastNameLabel" runat="server" CssClass="Labels" style="left:10px; top:80px;" Text="Last Name:"></asp:Label>
            <asp:TextBox ID="LastNameTxt" CssClass="Textboxes" style="left:130px; top:80px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Label ID="AddressLabel" runat="server" CssClass="Labels" style="left:10px; top:110px;" Text="Address:"></asp:Label>
            <asp:TextBox ID="AddressTxt" CssClass="Textboxes" style="left:130px; top:110px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Label ID="CityLabel" runat="server" CssClass="Labels" style="left:10px; top:140px;" Text="City:"></asp:Label>
            <asp:TextBox ID="CityTxt" CssClass="Textboxes" style="left:130px; top:140px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Label ID="ProvLabel" runat="server" CssClass="Labels" style="left:10px; top:170px;" Text="Province:"></asp:Label>
            <asp:TextBox ID="ProvTxt" CssClass="Textboxes" style="left:130px; top:170px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Label ID="PostalLabel" runat="server" CssClass="Labels" style="left:10px; top:200px;" Text="Postal Code:"></asp:Label>
            <asp:TextBox ID="PostalTxt" CssClass="Textboxes" style="left:130px; top:200px; width:200px; color:black;" runat="server"></asp:TextBox>

            <asp:Button ID="NewButton" CssClass="Buttons" style="left:10px; bottom:10px;" runat="server" Text="New" OnClick="NewButton_Click" />
            <asp:Button ID="AddButton" CssClass="Buttons" style="left:150px; bottom:10px;" runat="server" Text="Add" OnClick="AddButton_Click" />
            <asp:Button ID="UpdateButton" CssClass="Buttons" style="left:290px; bottom:10px;" Enabled="false" runat="server" Text="Update" OnClick="UpdateButton_Click" />
            <asp:Button ID="DeleteButton" CssClass="Buttons" style="left:430px; bottom:10px;" Enabled="false" runat="server" Text="Delete" OnClick="DeleteButton_Click" />
            <asp:Button ID="FindButton" CssClass="Buttons" style="left:570px; bottom:10px;" runat="server" Text="Find" OnClick="FindButton_Click" />
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" CssClass="Messages" style="left:10px; top:300px; right:10px; height:16px; height:16px; background-color:whitesmoke" Text=""></asp:Label>
    </form>
</body>
</html>
