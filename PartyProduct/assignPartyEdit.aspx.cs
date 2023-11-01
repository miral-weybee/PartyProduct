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
    public partial class WebForm8 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
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
            string party = PartyNameDropDown.Items[PartyNameDropDown.SelectedIndex].Text;
            int partyid = -1;
            int productid = -1;
            string product = ProductNameDropDown.Items[ProductNameDropDown.SelectedIndex].Text;
            SqlCommand cm = new SqlCommand("select * from party", con);
            con.Open();
            SqlDataReader sdr = cm.ExecuteReader();
            while (sdr.Read())
            {
                if(sdr.GetString(1) == party)
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
                if(sdr1.GetString(1) == product)
                {
                    productid = sdr1.GetInt32(0);
                    break;
                }
            }
            con.Close();

            con.Open();
            SqlCommand ins = new SqlCommand("insert into assignparty values(@partyid,@productid)",con);
            ins.Parameters.AddWithValue("@partyid", partyid);
            ins.Parameters.AddWithValue("@productid", productid);
            ins.ExecuteNonQuery();
            DisplayAlert("Assignation done....");
            con.Close();
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