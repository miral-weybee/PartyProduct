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
    public partial class WebForm7 : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select assignPartyId,partyName,productName from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId", con);
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
            Response.Redirect("assignPartyEdit.aspx");
        }
    }
}