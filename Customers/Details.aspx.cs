using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customers
{
    public partial class Details : System.Web.UI.Page
    {
        private object lblMessage;

        protected void Page_Load(object sender, EventArgs e)
        {
            PayButton.Click += new EventHandler(PayForOrder);
            
            CreateDetailGrid();
            CalculateTotal();
        }

        private void CreateDetailGrid()
        {
            TableDetailGrid.Rows.Clear();

            for (int i = 0; i < Default.numItems; i++)
            {
                TableRow row = new TableRow();
                for (int x = 0; x < 3; x++)
                {
                    TableCell cell = new TableCell();
                    if (x == 0)
                    {
                        Label label = new Label();
                        label.Text = Default.descrip[Default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        label.Style["color"] = "green";
                        label.Style["background-color"] = "#BFC9DC";
                        cell.Controls.Add(label);
                    }
                    else if (x == 1)
                    {
                        Label label = new Label();
                        label.Text = Default.price[Default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        label.Style["color"] = "green";
                        label.Style["background-color"] = "#BFC9DC";
                        cell.Controls.Add(label);
                    }
                    else if (x == 2)
                    {
                        TextBox text = new TextBox();
                        text.Text = Default.qty[Default.cartInfo[i]];
                        text.Style["font-family"] = "helvetica";
                        text.Style["color"] = "green";
                        text.Style["background-color"] = "white";
                        text.Style["width"] = "20px";
                        text.Style["border"] = "solid 2px #002594";
                        text.Enabled = false;
                        cell.Controls.Add(text);
                    }
                    row.Cells.Add(cell);
                }
                TableDetailGrid.Rows.Add(row);
            }
        }

        private void CalculateTotal()
        {
            decimal grandTotal = 0;

            for (int i = 0; i < Default.numItems; i++)
            {
                decimal rowPrice = Decimal.Parse(Default.price[Default.cartInfo[i]]);
                string qty = Default.qty[Default.cartInfo[i]];
                decimal rowTotal = rowPrice * int.Parse(qty);
                grandTotal += rowTotal;
            }
            LabelTotal.Text = grandTotal.ToString("$##,##0.#0");
        }

        protected void PayForOrder(object sender, EventArgs e)
        {
            string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";

            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string sqlString = "INSERT INTO Sales(ProductID, CusID, QtySold, SellingPrice, OrderDate) VALUES (@PID, @CID, @qtySld, @SP, @Odate)";

            try
            {
                for(int i = 0; i < Default.numItems; i++)
                {
                    cmd = new SqlCommand(sqlString, connectCmd);
                    cmd.Parameters.AddWithValue("@PID", Default.productID[Default.cartInfo[i]]);
                    cmd.Parameters.AddWithValue("@CID", Default.customerID);
                    cmd.Parameters.AddWithValue("@qtySld", Default.qty[Default.cartInfo[i]]);
                    cmd.Parameters.AddWithValue("@SP", Default.price[Default.cartInfo[i]]);
                    cmd.Parameters.AddWithValue("@Odate", DateTime.Now.ToString("yyyy-MM-dd h:mm tt"));
                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }
            DisposeResource(ref connectCmd, ref cmd);

            
        }

        private static void DisposeResource(ref SqlConnection connectCmd, ref SqlCommand cmd)
        {
            if (connectCmd != null)
            {
                connectCmd.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }

        }

        protected void SalesReport_Click(object sender, EventArgs e)
        {
            Server.Transfer("SalesReport.aspx");
        }
    }
}