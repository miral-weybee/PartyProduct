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
    public partial class EditParty : System.Web.UI.Page
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
                    cmd.CommandText = "select * from party where partyId=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    foreach (DataRow dr in dt.Rows)
                    {
                        OldEditpartyNameTextBox.Text = dr["partyname"].ToString();
                    }
                    OldEditpartyNameTextBox.Enabled = false;
                    sqlConnection.Close();
                }
                else
                {
                    DisplayAlert("Not a Valid Request");
                }
            }
          
        }

        protected void EditPartySavebtn_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                if (String.IsNullOrEmpty(NewEditpartyNameTextBox.Text))
                {
                    DisplayAlert("Name can not be null....");
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand cmd = sqlConnection.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update party set partyname='" + NewEditpartyNameTextBox.Text + "' where partyId=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "";
                    cmd.ExecuteNonQuery();
                    DisplayAlert("Party Updated Successfully....");
                    sqlConnection.Close();
                }
                
            }
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'partyList.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }

        protected void CancelPartybtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("partyList.aspx");
        }
    }
}