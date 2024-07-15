using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontap
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProducts();
            }
        }

        private void LoadProducts()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            DatabaseConnection db = new DatabaseConnection(connectionString);

            string categoryID = Request.QueryString["CategoryID"];
            string query = $"SELECT * FROM HangHoa WHERE MaDM = '{categoryID}'";
            DataTable products = db.ExecuteQuery(query);

            ProductRepeater.DataSource = products;
            ProductRepeater.DataBind();
        }
    }
}