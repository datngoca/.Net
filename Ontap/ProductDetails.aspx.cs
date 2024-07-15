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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductDetails();
            }
        }

        private void LoadProductDetails()
        {
            string productID = Request.QueryString["ProductID"];
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            DatabaseConnection db = new DatabaseConnection(connectionString);

            string query = $"SELECT * FROM HangHoa WHERE MaHang = '{productID}'";
            DataTable product = db.ExecuteQuery(query);

            if (product.Rows.Count > 0)
            {
                DataRow row = product.Rows[0];
                ProductImage.ImageUrl = "~/Images/" + row["HinhAnh"].ToString();
                ProductName.Text = row["TenHang"].ToString();
                ProductPrice.Text = row["DonGia"].ToString();
                ProductUnit.Text = row["DonViTinh"].ToString();
                ProductDescription.Text = row["MoTa"].ToString();
            }
        }
    }
}
