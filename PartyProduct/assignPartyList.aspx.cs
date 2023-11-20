using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PartyProduct
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }


            if (!IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("select assignPartyId,partyName,productName from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                Repeater1.DataSource = sdr;
                Repeater1.DataBind();
                sqlConnection.Close();
            }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("assignPartyEdit.aspx");
        }
    }
}