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
    public partial class EditAssignParty : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else
            {

            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }


            if (Request.QueryString["id"] != null)
            {
                SqlCommand cmd = new SqlCommand("select partyName,productName from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId where assignpartyid="+ Convert.ToInt32(Request.QueryString["id"].ToString())+ "", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    PartyNameDropDown.Items.Add(sdr.GetString(0));
                    ProductNameDropDown.Items.Add(sdr.GetString(1));
                }
                PartyNameDropDown.Enabled = false;
                ProductNameDropDown.Enabled = false;
                con.Close();
            }else
            {
                DisplayAlert("Not a valid request");
            }
            }
        }

        protected void AssignPartySavebtn_Click(object sender, EventArgs e)
        {
            string party = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
            int partyid = -1;
            int productid = -1;
            string product = DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            SqlCommand cm = new SqlCommand("select * from party", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                if (sdr.GetString(1) == party)
                {
                    partyid = sdr.GetInt32(0);
                    break;
                }
            }
            con.Close();

            SqlCommand cmd = new SqlCommand("select * from product", con);
            con.Open();
            SqlDataReader sdr1 = cmd.ExecuteReader();
            while (sdr1.Read())
            {
                if (sdr1.GetString(1) == product)
                {
                    productid = sdr1.GetInt32(0);
                    break;
                }
            }
            con.Close();

            con.Open();
            SqlCommand ins = new SqlCommand("update assignparty set partyid=@partyid,productid=@productid where assignpartyid="+Request.QueryString["id"].ToString()+"", con);
            ins.Parameters.AddWithValue("@partyid", partyid);
            ins.Parameters.AddWithValue("@productid", productid);
            ins.ExecuteNonQuery();
            DisplayAlert("Assignation Completed...");
            con.Close();
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