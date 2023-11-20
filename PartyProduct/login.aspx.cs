using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PartyProduct
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        private SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PartyProductConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
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
                SqlCommand cmd = new SqlCommand("select * from users", sqlConnection);
                sqlConnection.Open();
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
                    sqlConnection.Close();
                }
                else
                {
                    DisplayAlert("Incorrect Username or Password...");
                    sqlConnection.Close();
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