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
    public partial class Customers : System.Web.UI.Page
    {
        string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void NewButton_Click(object sender, EventArgs e)
        {
            flushData();

            DeleteButton.Enabled = false;
            UpdateButton.Enabled = false;

            lblMessage.Text = "";
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "INSERT INTO Customers(FirstName, LastName, Address, City, Province, PostalCode) VALUES (@fn, @ln, @ad, @ct, @pr, @pc)";
            //Step 2: Perform CRUD operation in this case Create/Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@fn", FirstNameTxt.Text);
                cmd.Parameters.AddWithValue("@ln", LastNameTxt.Text);
                cmd.Parameters.AddWithValue("@ad", AddressTxt.Text);
                cmd.Parameters.AddWithValue("@ct", CityTxt.Text);
                cmd.Parameters.AddWithValue("@pr", ProvTxt.Text);
                cmd.Parameters.AddWithValue("@pc", PostalTxt.Text);
                cmd.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            string id = "SELECT IDENT_CURRENT('Customers') FROM Customers";
            cmd = new SqlCommand(id, connectCmd);
            int idValue = Convert.ToInt32(cmd.ExecuteScalar());
            CustomerTxtID.Text = idValue.ToString();
            lblMessage.Text = "New Customer Added!";

            Default.customerID = idValue;

            DisposeResource(ref connectCmd, ref cmd);
            //enable button once addedd
            DeleteButton.Enabled = true;
            UpdateButton.Enabled = true;

        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "UPDATE Customers SET FirstName=@fn, LastName=@ln, Address=@ad, City=@ct, Province=@pr, PostalCode=@pc WHERE CustomerID=@cid";
            //Step 2: Perform CRUD operation in this case Create/Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@fn", FirstNameTxt.Text);
                cmd.Parameters.AddWithValue("@ln", LastNameTxt.Text);
                cmd.Parameters.AddWithValue("@ad", AddressTxt.Text);
                cmd.Parameters.AddWithValue("@ct", CityTxt.Text);
                cmd.Parameters.AddWithValue("@pr", ProvTxt.Text);
                cmd.Parameters.AddWithValue("@pc", PostalTxt.Text);
                cmd.Parameters.AddWithValue("@cid", CustomerTxtID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            lblMessage.Text = "Customer Information Updated!";

            DisposeResource(ref connectCmd, ref cmd);
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "DELETE FROM Customers WHERE CustomerID=@cid";
            //Step 2: Perform CRUD operation in this case Create/Insert
            try
            {
                cmd = new SqlCommand(query, connectCmd);
                cmd.Parameters.AddWithValue("@cid", CustomerTxtID.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResource(ref connectCmd, ref cmd);
                return;
            }

            lblMessage.Text = "Customer Information Deleted!";

            DisposeResource(ref connectCmd, ref cmd);
        }

        protected void FindButton_Click(object sender, EventArgs e)
        {
            SqlDataAdapter dataAdapter = null;
            DataSet ds = null;
            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            //Step 1: opening connection to the database
            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "SELECT * FROM Customers WHERE CustomerID=@cid";

            try
            {
                ds = new DataSet();
                cmd = new SqlCommand(query, connectCmd);

                cmd.Parameters.AddWithValue("@cid", CustomerTxtID.Text);

                //create a new sql adapter to retrieve the data and store it in the dataset
                dataAdapter = new SqlDataAdapter();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(ds, "Customers");


            }
            catch(Exception ex)
            {
                lblMessage.Text = ex.Message;
                DisposeResource_DataSet(ref connectCmd, ref cmd, ref dataAdapter, ref ds);
                return;
            }
            if (ds.Tables["Customers"].Rows.Count == 1)
            {
                Default.customerID = Convert.ToInt32((ds.Tables["Customers"].Rows[0]["CustomerID"]));
                FirstNameTxt.Text = ds.Tables["Customers"].Rows[0]["FirstName"].ToString();
                LastNameTxt.Text = ds.Tables["Customers"].Rows[0]["LastName"].ToString();
                AddressTxt.Text = ds.Tables["Customers"].Rows[0]["Address"].ToString();
                CityTxt.Text = ds.Tables["Customers"].Rows[0]["City"].ToString();
                ProvTxt.Text = ds.Tables["Customers"].Rows[0]["Province"].ToString();
                PostalTxt.Text = ds.Tables["Customers"].Rows[0]["PostalCode"].ToString();
                DeleteButton.Enabled = true;
                UpdateButton.Enabled = true;
                lblMessage.Text = "";
            }
            else
            {
                flushData();
                lblMessage.Text = "Customer Record Not Found!";
            }
        }

        private void flushData()
        {
            CustomerTxtID.Text = "";
            FirstNameTxt.Text = "";
            LastNameTxt.Text = "";
            AddressTxt.Text = "";
            CityTxt.Text = "";
            ProvTxt.Text = "";
            PostalTxt.Text = "";
        }

        private static void DisposeResource(ref SqlConnection connectCmd, ref SqlCommand cmd)
        {
            if(connectCmd != null)
            {
                connectCmd.Dispose();
            }if(cmd !=null)
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