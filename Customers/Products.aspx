<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Customers.Products" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products Page</title>
    <link href="Styles/products.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="panMain" CssClass="MainPanel" style="left:10px; top:10px; height:280px; right:10px" runat="server">
            <asp:Label ID="lblProductID" CssClass="Labels" style="left:10px; top:20px" runat="server" Text="Product #:"></asp:Label>
            <asp:TextBox ID="txtProductID" CssClass="Textboxes" style="left:160px; top:20px; color:red; width: 199px;" runat="server"></asp:TextBox>

            <asp:Label ID="lblManufact" CssClass="Labels" style="left: 10px; top: 50px" runat="server" Text="Manufact Code:"></asp:Label>
            <asp:TextBox ID="txtManufact" CssClass="Textboxes" style="left: 160px; top: 50px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblDescription" CssClass="Labels" style="left: 10px; top: 80px" runat="server" Text="Description:"></asp:Label>
            <asp:TextBox ID="txtDescription" CssClass="Textboxes" style="left: 160px; top: 80px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblPicture" CssClass="Labels" style="left:10px; top:110px" runat="server" Text="Picture:"></asp:Label>
            <asp:TextBox ID="txtPicture" CssClass="Textboxes" style="left:160px; top:110px; width:200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblQty" CssClass="Labels" style="left: 10px; top: 140px" runat="server" Text="Quantity On Hand:"></asp:Label>
            <asp:TextBox ID="txtQty" CssClass="Textboxes" style="left: 160px; top: 140px; width: 200px" runat="server"></asp:TextBox>

            <asp:Label ID="lblPrice" CssClass="Labels" style="left: 10px; top: 170px" runat="server" Text="Price:"></asp:Label>
            <asp:TextBox ID="txtPrice" CssClass="Textboxes" style="left: 160px; top: 170px; width: 200px" runat="server"></asp:TextBox>

            <asp:Button ID="btnVerify" CssClass="Buttons" style="left: 366px; bottom: 218px; background-color:#FFB1B1" Visible="false" runat="server" Text="Verify?" ToolTip="Verify Deletion" OnClick="btnVerify_Click" />
            <asp:Button ID="btnNew" runat="server" CssClass="Buttons" OnClick="btnNew_Click" style="left: 10px; bottom: 10px" Text="New" ToolTip="Clear all Product fields" />
            <asp:Button ID="btnAdd" runat="server" CssClass="Buttons" OnClick="btnAdd_Click" style="left: 150px; bottom: 10px" Text="Add" ToolTip="Create a new product" />
            <asp:Button ID="btnUpdate" runat="server" CssClass="Buttons" Enabled="false" OnClick="btnUpdate_Click" style="left: 290px; bottom: 10px" Text="Update" ToolTip="Update the current Product" />
            <asp:Button ID="btnDelete" runat="server" CssClass="Buttons" Enabled="false" OnClick="btnDelete_Click" style="left: 430px; bottom: 10px" Text="Delete" ToolTip="Delete the current Product" />
            <asp:Button ID="btnFind" runat="server" CssClass="Buttons" OnClick="btnFindCustomer_Click" style="left: 572px; bottom: 10px" Text="Find" ToolTip="Find the current Product" />
            <asp:Label ID="lblMessage" CssClass="MessageLabels" style="left: 366px; bottom: 239px" Visible="false" runat="server" Text=""></asp:Label>
            <asp:Image ID="imgPictures" runat="server" CssClass="Images" style="left:522px; bottom:79px; height:180px; width:234px" />
            <asp:ListBox ID="lstPictures" runat="server" AutoPostBack="True" CssClass="ListBoxes" OnSelectedIndexChanged="lstPictures_SelectedIndexChanged" style="top:22px; left:775px; height:180px; width: 128px;"></asp:ListBox>
        </asp:Panel>
        <asp:Label ID="lblMessage2" runat="server" CssClass="Messages" style="left:10px; top:300px; right:10px; height:16px; height:16px; background-color:whitesmoke" Text=""></asp:Label>
    </form>
</body>
</html>
