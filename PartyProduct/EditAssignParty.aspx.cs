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
    public partial class EditAssignParty : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select partyName,productName from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId where assignpartyid="+ Convert.ToInt32(Request.QueryString["id"].ToString())+ "", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PartyNameDropDown.Items.Add(sdr.GetString(0));
                    ProductNameDropDown.Items.Add(sdr.GetString(1));
                }
                PartyNameDropDown.Enabled = false;
                ProductNameDropDown.Enabled = false;
                sqlConnection.Close();
            }else
            {
                DisplayAlert("Not a valid request");
            }
            }
        }

        protected void AssignPartySavebtn_Click(object sender, EventArgs e)
        {
            string party = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
            string product = DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            SqlCommand cm = new SqlCommand("select * from party where partyName='"+party+"'", sqlConnection);
            sqlConnection.Open();
            int partyid = (int)cm.ExecuteScalar();
            SqlCommand cmd = new SqlCommand("select * from product where productName='"+product+"'", sqlConnection);
            int productid = (int)cmd.ExecuteScalar();
            SqlCommand ins = new SqlCommand("update assignparty set partyid=@partyid,productid=@productid where assignpartyid="+Request.QueryString["id"].ToString()+"", sqlConnection);
            ins.Parameters.AddWithValue("@partyid", partyid);
            ins.Parameters.AddWithValue("@productid", productid);
            ins.ExecuteNonQuery();
            DisplayAlert("Assignation Completed...");
            sqlConnection.Close();
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'assignPartyList.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }

        protected void AssignPartyCancelbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("assignPartyList.aspx");
        }
    }
}