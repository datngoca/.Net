using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontap
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            DatabaseConnection db = new DatabaseConnection(connectionString);

            DataTable categories = db.ExecuteQuery("SELECT MaDM, TenDM FROM DanhMuc");

            CategoryRepeater.DataSource = categories;
            CategoryRepeater.DataBind();
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
        }
    }
}