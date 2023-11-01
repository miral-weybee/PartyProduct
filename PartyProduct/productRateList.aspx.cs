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
    public partial class WebForm9 : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select productRateId,productName,rate,convert(date, dateOfRate) as dateOfRate from productRate inner join product on productRate.productId = product.productId", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                Repeater1.DataSource = sdr;
                Repeater1.DataBind();
                con.Close();
            }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("productRateListEdit.aspx");
        }

       
    }
}