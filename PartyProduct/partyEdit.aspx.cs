using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PartyProduct
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
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
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("partyList.aspx");
        }

        protected void partyNameSavebtn_Click(object sender, EventArgs e)
        {
            if(partyNameTextBox.Text == string.Empty)
            {
                DisplayAlert("Party Name can't be empty....");
            }
            else
            {
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into party values('"+ partyNameTextBox.Text+"')";
                DisplayAlert("Party Added Successfully...");
                cmd.ExecuteNonQuery();
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