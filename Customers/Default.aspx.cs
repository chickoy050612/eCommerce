using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Customers
{
    public partial class Default : System.Web.UI.Page
    {
        public static string webSiteData = HttpContext.Current.Server.MapPath(".") + @"\Data\productsData";

        public static string[] countFiles;
        public static string[] pics;
        public static string[] descrip;
        public static string[] price;

        //public static string[] totalprice;

        //use these later in handling the cart
        public static int[] cartInfo = new int[100];
        public static int numItems = 0;
        public static string[] qty = new string[100];

        //use it to add data to sales tables
        public static int customerID;
        public static int[] productID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                resetArrays();

                for (int i = 0; i < qty.Length; i++)
                {
                    qty[i] = "1";
                }
            }
        }

        protected void btnPromo_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCatalog_Click(object sender, EventArgs e)
        {
            Myframe.Attributes.Add("src", "Catalog.aspx");
        }

        protected void btnCart_Click(object sender, EventArgs e)
        {
            Myframe.Attributes.Add("src", "Cart.aspx");
        }

        protected void btnWeather_Click(object sender, EventArgs e)
        {
            Myframe.Attributes.Add("src", "https://weather.gc.ca/city/pages/on-137_metric_e.html");
        }

        protected void btnCustomers_Click(object sender, EventArgs e)
        {
            Myframe.Attributes.Add("src", "Customers.aspx");
        }

        protected void btnProducts_Click(object sender, EventArgs e)
        {
            Myframe.Attributes.Add("src", "Products.aspx");
        }

        public static void resetArrays()
        {
            //get a list of product files
            //countFiles = Directory.GetFiles(webSiteData, "*.*");
            string dbConnect = @"integrated security=True;data source=(localdb)\ProjectsV13;persist security info=False;initial catalog=eStore";

            SqlConnection connectCmd = null;
            SqlCommand cmd = null;

            connectCmd = new SqlConnection(dbConnect);
            connectCmd.Open();

            string query = "SELECT COUNT(*) FROM Products";

            cmd = new SqlCommand(query, connectCmd);
            int countRows = Convert.ToInt32(cmd.ExecuteScalar());

            pics = new string[countRows];
            descrip = new string[countRows];
            price = new string[countRows];

            customerID = 0;
            productID = new int[countRows];
        }
    }
}