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
    public partial class signup : System.Web.UI.Page
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
            string username = TextBox2.Text;
            string password = TextBox3.Text;

            if(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(TextBox1.Text))
            {
                DisplayAlert("Username or Password is empty..");
            }
            else
            {
                
                SqlCommand cmd = new SqlCommand("select * from users where username='"+username+"'", sqlConnection);
                sqlConnection.Open();
                bool user = (bool)cmd.ExecuteScalar();
                sqlConnection.Close();
                if (user)
                {
                    DisplayAlert("User Already Exists...");

                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand ins = new SqlCommand("insert into users values(@username,@password)", sqlConnection);
                    ins.Parameters.AddWithValue("@username", username);
                    ins.Parameters.AddWithValue("@password", password);
                    ins.ExecuteNonQuery();
                    DisplayAlert1("User Created Successfully...");
                    sqlConnection.Close();
                }
            }

            
            
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'signup.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }
        protected virtual void DisplayAlert1(string message)
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