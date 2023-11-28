using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PartyProduct
{
    public partial class WebForm8 : System.Web.UI.Page
    {
        
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        protected void Button2_Click(object sender, EventArgs e)
        {
           Response.Redirect("assignPartyList.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string partyName = PartyNameDropDown.Items[PartyNameDropDown.SelectedIndex].Text;
            string productName = ProductNameDropDown.Items[ProductNameDropDown.SelectedIndex].Text;

            SqlCommand cm = new SqlCommand("select * from party where partyName='"+partyName+"'", sqlConnection);
            sqlConnection.Open();
            int partyid = (int)(cm.ExecuteScalar());
            SqlCommand cmd = new SqlCommand("select * from product where productName='"+productName+"'", sqlConnection);
            int productid = (int)(cmd.ExecuteScalar());
            sqlConnection.Close();

            sqlConnection.Open();
            SqlCommand ins = new SqlCommand("insert into assignparty values(@partyid,@productid)", sqlConnection);
            ins.Parameters.AddWithValue("@partyid", partyid);
            ins.Parameters.AddWithValue("@productid", productid);
            ins.ExecuteNonQuery();
            DisplayAlert("Assignation done....");
            sqlConnection.Close();
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'assignPartyEdit.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }
    }
}