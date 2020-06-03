<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SalesReport.aspx.cs" Inherits="Customers.SalesReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sales Report</title>
    <link href="Styles/salesreport.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Lexend+Deca&display=swap" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Sales Report</h1>
        </div>
        <div>
            <asp:GridView ID="dataSalesRep" runat="server" AutoGenerateColumns="False" CellPadding="3" CellSpacing="5" ForeColor="#003366" Height="2px" Width="825px">
                <Columns>
                    <asp:BoundField DataField="SalesID" HeaderText ="Sales ID" />
                    <asp:BoundField DataField="Customer Name" HeaderText ="Customer Name" />
                    <asp:BoundField DataField="ManufactCode" HeaderText ="Product Manufacturing Code" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Description" HeaderText ="Product Description" />
                    <asp:BoundField DataField="QtySold" HeaderText ="Quantity Sold" >
                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="SellingPrice" HeaderText ="Selling Price" DataFormatString="{0:C}" >
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Total_Selling_Price" HeaderText ="Total Selling Price" DataFormatString="{0:C}" >  
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
            <p><b>Quantity Sold Total:</b> <asp:Label ID="lblQtyTotalSold" runat="server" Text="Label" ></asp:Label></p>
            <p><b>Total Amount of Selling Price:</b> <asp:Label ID="lblTotalSellingPrice" runat="server" Text="Label" ></asp:Label></p>
            <asp:Button ID="backButton" runat="server" CssClass="Button" Text="Back" OnClick="backButton_Click" />
        </div>
    </form>
</body>
</html>
