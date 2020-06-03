using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customers
{
    public partial class Catalog : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = null;
            DataSet ds = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //connectCmd.Open();

            try
            {
                ds = new DataSet();

                connectCmd = new SqlConnection(dbConnect);

                string sqlString = "SELECT * FROM Products";

                cmd = new SqlCommand(sqlString, connectCmd);

                //cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);

                //create a new sql adapter to retrieve the data and store it in the dataset
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Products");


            }
            catch (Exception ex)
            {
                DisposeResource_DataSet(ref connectCmd, ref cmd, ref dataAdapter, ref ds);
                return;
            }
            //Iterate through all the products in dataset and display in table format.

            if(ds.Tables["Products"].Rows.Count > 0)
            { 

                for(int i = 0; i < ds.Tables["Products"].Rows.Count; i++)
                {
                    TableRow row = new TableRow();
                    for (int x = 0; x < 4; x++)
                    {
                        TableCell cell = new TableCell();
                        if (x == 0)
                        {
                            Image image = new Image();
                            image.ImageUrl = "Pictures/" + ds.Tables["Products"].Rows[i]["Picture"].ToString();
                            image.Height = 100;
                            image.Width = 120;

                            Default.pics[i] = image.ImageUrl;

                            cell.Controls.Add(image);

                            Default.productID[i] = Convert.ToInt32(ds.Tables["Products"].Rows[i]["ProductID"]);
                        }
                        else if (x == 1)
                        {
                            Label label = new Label();
                            label.Text = ds.Tables["Products"].Rows[i]["Description"].ToString();

                            Default.descrip[i] = label.Text;

                            cell.Controls.Add(label);
                        }
                        else if (x == 2)
                        {
                            cell.Text = ds.Tables["Products"].Rows[i]["Price"].ToString();

                            Default.price[i] = cell.Text;
                        }
                        else if (x == 3)
                        {
                            Button addCartButton = new Button();
                            addCartButton.ID = "btnSelect_" + i + "_" + x;
                            addCartButton.Click += new EventHandler(buttonTemp_Click);
                            addCartButton.Text = "Add to Cart";

                            cell.Controls.Add(addCartButton);
                        }

                        row.Cells.Add(cell);
                    }
                    catalogTable.Rows.Add(row);
                }
            }

            DisposeResource_DataSet(ref connectCmd, ref cmd, ref dataAdapter, ref ds);

        }

        protected void buttonTemp_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string id = b.ID;

            //begin the process of change
            //when the user has added 
            b.Style["color"] = "gray";

            string[] idParts = id.Split('_');

            int rowNum = int.Parse(idParts[1]);
            rowSelectedTable.Text = "You Selected " + Default.descrip[rowNum];

            if (Default.numItems > 0)
            {
                bool matchRow = false;
                for (int i = 0; i < Default.numItems; i++)
                {
                    if (rowNum == Default.cartInfo[i])
                    {
                        matchRow = true;
                    }
                }

                if (!matchRow)
                {
                    Default.cartInfo[Default.numItems] = rowNum;
                    Default.numItems++;
                }
            }
            else
            {
                Default.cartInfo[Default.numItems] = rowNum;
                Default.numItems++;
            }
        }

        private static void DisposeResource_DataSet(ref SqlConnection connectCmd, ref SqlCommand cmd, ref SqlDataAdapter dataAdapter, ref DataSet ds)
        {
            if (connectCmd != null)
            {
                connectCmd.Dispose();
            }
            if (cmd != null)
            {
                cmd.Dispose();
            }
            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
            }
            if (ds != null)
            {
                ds.Dispose();
            }
        }
    }
}