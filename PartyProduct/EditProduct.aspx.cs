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
    public partial class EditProduct : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                sqlConnection.Open();
                SqlCommand cmd = sqlConnection.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from product where productId=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    OldProductNameTextBox.Text = dr["productname"].ToString();
                }
                OldProductNameTextBox.Enabled = false;
                sqlConnection.Close();
            }
            else
            {
                DisplayAlert("Not a Valid Request");
            }
            }
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'productList.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }

        protected void ProductSavebtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (String.IsNullOrEmpty(NewProductNameTextBox.Text))
                {
                    DisplayAlert("Name can not be null....");
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update product set productname='" + NewProductNameTextBox.Text + "' where productId=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
                    cmd.ExecuteNonQuery();
                    DisplayAlert("Product Updated Successfully....");
                    sqlConnection.Close();
                }
                
            }
            else
            {
                DisplayAlert("Something went wrong...");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("productList.aspx");
        }
    }
}