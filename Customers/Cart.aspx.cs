using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customers
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = Default.pics[0];
            btnCalculate.Click += new EventHandler(btnCalculate_Click);
            btnCheckout.Click += new EventHandler(LoadCheckoutPage);
            createCartGrid();
            recalculateTotal();
        }

        protected void removeButtonTemplate_Click(object sender, EventArgs e)
        {
            Button removeButton = (Button)sender;
            string id = removeButton.ID;

            string[] idParts = id.Split('_');

            int row = int.Parse(idParts[1]);
            lblRowSelected.Text = "You Selected row " + row;

            Default.qty[Default.cartInfo[row]] = "1";

            for (int i = row; i < Default.numItems; i++)
            {
                Default.cartInfo[i] = Default.cartInfo[i + 1];
            }

            Default.numItems--;

            createCartGrid();
            recalculateTotal();
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            recalculateTotal();
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {

        }

        private void createCartGrid()
        {
            cartTable.Rows.Clear();

            for (int i = 0; i < Default.numItems; i++)
            {
                TableRow row = new TableRow();
                for (int x = 0; x < 5; x++)
                {
                    TableCell cell = new TableCell();

                    if (x == 0)
                    {
                        Image image = new Image();
                        image.ImageUrl = Default.pics[Default.cartInfo[i]];
                        image.Height = 100;
                        image.Width = 120;
                        cell.Controls.Add(image);
                    }
                    else if (x == 1)
                    {
                        Label label = new Label();
                        label.Text = Default.descrip[Default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        label.Style["color"] = "green";
                        label.Style["background-color"] = "#BFC9DC";
                        cell.Controls.Add(label);
                    }
                    else if (x == 2)
                    {
                        Label label = new Label();
                        label.Text = Default.price[Default.cartInfo[i]];
                        label.Style["font-family"] = "helvetica";
                        label.Style["color"] = "green";
                        label.Style["background-color"] = "#BFC9DC";
                        cell.Controls.Add(label);
                    }
                    else if (x == 3)
                    {
                        Button btnRemoveFromCart = new Button();
                        btnRemoveFromCart.ID = "btnSelect_" + i + "_" + x;
                        btnRemoveFromCart.Click += new EventHandler(removeButtonTemplate_Click);
                        btnRemoveFromCart.Text = "Remove";
                        cell.Controls.Add(btnRemoveFromCart);
                    }
                    else if (x == 4)
                    {
                        TextBox text = new TextBox();
                        text.Text = Default.qty[Default.cartInfo[i]];
                        text.Style["font-family"] = "helvetica";
                        text.Style["color"] = "green";
                        text.Style["background-color"] = "white";
                        text.Style["width"] = "20px";
                        text.Style["border"] = "solid 2px #002594";
                        cell.Controls.Add(text);
                    }
                    row.Cells.Add(cell);
                }
                cartTable.Rows.Add(row);
            }
        }

        private void recalculateTotal()
        {
            decimal total = 0;

            for (int i = 0; i < Default.numItems; i++)
            {
                TableRow row = cartTable.Rows[i];
                decimal rowPrice = 0;
                for (int y = 0; y < 5; y++)
                {
                    TableCell cell = row.Cells[y];
                    if (y == 2)
                    {
                        Control ctrlCell = cell.Controls[0];
                        Label lblCell = (Label)ctrlCell;
                        string price = lblCell.Text;
                        rowPrice = decimal.Parse(price);

                    }
                    else if (y == 4)
                    {
                        Control ctrlText = cell.Controls[0];
                        TextBox txt = (TextBox)ctrlText;
                        string qty = txt.Text;
                        Default.qty[Default.cartInfo[i]] = qty;
                        decimal rowTotal = rowPrice * int.Parse(qty);
                        total += rowTotal;
                    }
                }
            }
            lblTotal.Text = total.ToString("$##,##0.##");
        }
        protected void LoadCheckoutPage(object sender, EventArgs e)
        {
            //server.transfer replaces the current page with a new page
            Server.Transfer("Checkout.aspx");
        }

        protected void PayforOrder(object sender, EventArgs e)
        {

        }

    }
}