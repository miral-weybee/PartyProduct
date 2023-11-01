using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PartyProduct
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            if (!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("select * from product order by productname", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                ProductRepeater.DataSource = sdr;
                ProductRepeater.DataBind();
                con.Close();
            }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("productListEdit.aspx");
        }
    }
}