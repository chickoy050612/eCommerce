using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Customers
{
    public partial class SalesReport : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlCon = new SqlConnection(dbConnect))
            {
                sqlCon.Open();
                SqlDataAdapter sqlData = new SqlDataAdapter("SELECT Sales.SalesID, (CONVERT(varchar(50),Customers.LastName) + ', ' + CONVERT(varchar(50),Customers.FirstName)) AS 'Customer Name',  Products.ManufactCode, Products.Description, Sales.QtySold, Sales.SellingPrice, (Sales.QtySold*Sales.SellingPrice) AS 'Total_Selling_Price' FROM Customers INNER JOIN Sales ON Customers.CustomerID = Sales.CusID INNER JOIN Products ON Products.ProductID = Sales.ProductID ORDER BY 1;", sqlCon);
                DataTable datatbl = new DataTable();
                sqlData.Fill(datatbl);
                dataSalesRep.DataSource = datatbl;
                dataSalesRep.DataBind();

                // sum all the quantity sold in
                object qtysum;
                qtysum = datatbl.Compute("Sum(QtySold)", string.Empty);
                //output for total quantity
                lblQtyTotalSold.Text = qtysum.ToString();

                //sum all the total selling price
                object sellingPriceSum;
                sellingPriceSum = datatbl.Compute("Sum(Total_Selling_Price)", string.Empty);
                //output for total selling price
                lblTotalSellingPrice.Text = Convert.ToDecimal(sellingPriceSum).ToString("$###,##0.00");

            }
            
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Server.Transfer("Details.aspx");
        }
    }
}