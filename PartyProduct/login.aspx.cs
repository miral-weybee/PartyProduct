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
    public partial class WebForm12 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTb.Text;
            string password = PassTb.Text;
            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                DisplayAlert("Username or Password is empty..");
            }
            else
            {
                bool flag = false;
                SqlCommand cmd = new SqlCommand("select * from users", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    if (sdr.GetString(1) == username && sdr.GetString(2) == password)
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    Session["user"] = username;
                    Response.Redirect("partyList.aspx");
                    con.Close();
                }
                else
                {
                    DisplayAlert("Incorrect Username or Password...");
                    con.Close();
                }
            }
            
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'login.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }
    }
}