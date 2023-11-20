using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace PartyProduct
{
    public partial class assignPartyDelete : System.Web.UI.Page
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
                sqlConnection.Open();


                if (Request.QueryString["id"] != null)
                {
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "delete from assignparty where assignPartyId='" + Request.QueryString["id"].ToString() + "'";
                    cmd.ExecuteNonQuery();
                    Response.Redirect("assignPartyList.aspx");
                    DisplayAlert("Assign Party Deleted Successfully....");
                }
            }
            
        }


        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'partyEdit.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }
    }
    
    
}