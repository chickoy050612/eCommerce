using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customers
{
    public partial class Products : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        string webSitePics = HttpContext.Current.Server.MapPath(".") + @"\Pictures";
       
        protected void lstPictures_SelectedIndexChanged(object sender, EventArgs e)
        {
            imgPictures.ImageUrl = "Pictures/" + lstPictures.SelectedItem.Text;
            txtPicture.Text = lstPictures.SelectedItem.Text;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string[] fileList = Directory.GetFiles(webSitePics, "*.*");
                lstPictures.Items.Clear();

                for (int i = 0; i < fileList.Length; i++)
                {
                    string fileName = Path.GetFileName(fileList[i]);
                    lstPictures.Items.Add(fileName);
                }
            }
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            flushData();

            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "INSERT INTO Products(ManufactCode, Description, Picture, Quantity, Price) VALUES(@MfCode, @Desc, @Pic, @Qty, @Price)";

            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@MfCode", txtManufact.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Pic", txtPicture.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                lblMessage2.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            string id = "SELECT IDENT_CURRENT('Products') FROM Products";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            txtProductID.Text = idValue.ToString();
            lblMessage2.Text = "New Product Added!";

            DisposeResource(ref connectCmd, ref cmd);
            //enable button once addedd
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "UPDATE Products SET ManufactCode=@MfCode, Description=@Desc, Picture=@Pic, Quantity=@Qty, Price=@Price WHERE ProductID=@Pid";
            //Step 2: Perform CRUD operation in this case Create/Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);
                cmd.Parameters.AddWithValue("@MfCode", txtManufact.Text);
                cmd.Parameters.AddWithValue("@Desc", txtDescription.Text);
                cmd.Parameters.AddWithValue("@Pic", txtPicture.Text);
                cmd.Parameters.AddWithValue("@Qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@Price", txtPrice.Text);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage2.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            lblMessage2.Text = "Products Information Updated!";

            DisposeResource(ref connectCmd, ref cmd);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "DELETE FROM Products WHERE ProductID=@Pid";
            //Step 2: Perform CRUD operation in this case Create/Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage2.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            lblMessage2.Text = "Product Information Deleted!";

            DisposeResource(ref connectCmd, ref cmd);
        }

        protected void btnFindCustomer_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = null;
            DataSet ds = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "SELECT * FROM Products WHERE ProductID=@Pid";

            try
            {
                ds = new DataSet();
                cmd = new SqlCommand(query, connectCmd);

                cmd.Parameters.AddWithValue("@Pid", txtProductID.Text);

                //create a new sql adapter to retrieve the data and store it in the dataset
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Products");


            }
            catch (Exception ex)
            {
                lblMessage2.Text = ex.Message;
            }
            if (ds.Tables["Products"].Rows.Count == 1)
            {
                txtManufact.Text = ds.Tables["Products"].Rows[0]["ManufactCode"].ToString();
                txtDescription.Text = ds.Tables["Products"].Rows[0]["Description"].ToString();
                txtPicture.Text = ds.Tables["Products"].Rows[0]["Picture"].ToString();
                txtQty.Text = ds.Tables["Products"].Rows[0]["Quantity"].ToString();
                txtPrice.Text = ds.Tables["Products"].Rows[0]["Price"].ToString();

                imgPictures.ImageUrl = "Pictures/" + txtPicture.Text;
           
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                flushData();
                lblMessage2.Text = "Products Record Not Found!";
            }
            DisposeResource_DataSet(ref connectCmd, ref cmd, ref dataAdapter, ref ds);
        }

        protected void btnVerify_Click(object sender, EventArgs e)
        {

        }

        private void flushData()
        {
            txtProductID.Text = "";
            txtManufact.Text = "";
            txtDescription.Text = "";
            txtPicture.Text = "";
            txtQty.Text = "";
            txtPrice.Text = "";
        }

        private void hideAll()
        {
            btnVerify.Visible = false;
            lblMessage.Visible = false;
        }

        private void showMessage(string msg)
        {
            lblMessage.Visible = true;
            lblMessage.Text = msg;
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
