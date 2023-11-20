using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace PartyProduct
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["user"] == null)
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
                    SqlCommand cmd = new SqlCommand("select * from party order by partyname", sqlConnection);
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
            Response.Redirect("partyEdit.aspx");
        }
    }
}