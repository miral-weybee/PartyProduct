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
    public partial class WebForm11 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Select Value");
                SqlCommand cmd = new SqlCommand("select partyName from party", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DropDownList1.Items.Add(sdr.GetString(0));
                }
                con.Close();
                
            }
            }
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select top 1 rate from productRate inner join product on product.productId=productRate.productId where productName=@productname order by productRateId desc", con);
            cmd.Parameters.AddWithValue("@productname", DropDownList2.SelectedValue.ToString());
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TextBox1.Text = sdr.GetDecimal(0).ToString();
            }
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string party_name = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
            string product_name = DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            int partyId = -1, productId = -1;
            con.Open();
            SqlCommand ins = new SqlCommand("select party.partyid,product.productid from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId where product.productName = '"+product_name+"' and party.partyName = '"+party_name+"'", con);
            SqlDataReader sdr = ins.ExecuteReader();
            while (sdr.Read())
            {
                partyId = sdr.GetInt32(0);
                productId = sdr.GetInt32(1);
            }
            con.Close();
            con.Open();
            SqlCommand ins1 = new SqlCommand("insert into invoice values(@partyId,@productId,@currentRate,@qty) ", con);
            ins1.Parameters.AddWithValue("@partyid", partyId);
            ins1.Parameters.AddWithValue("@productid", productId);
            ins1.Parameters.AddWithValue("@currentRate", Convert.ToDecimal(TextBox1.Text));
            ins1.Parameters.AddWithValue("@qty", Convert.ToInt32(TextBox2.Text));
            ins1.ExecuteNonQuery();
            DropDownList1.Enabled = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            con.Close();
            SqlCommand cmd1 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", con);
            con.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            Repeater1.DataSource = sdr1;
            Repeater1.DataBind();
            
            con.Close();
            con.Open();
            decimal sum = 0;
            SqlCommand cmd2 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", con);
            SqlDataReader sdr2 = cmd1.ExecuteReader();
            while (sdr2.Read())
            {
                sum += sdr2.GetDecimal(5);
            }
            Label2.Text = sum.ToString();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select Value");
            SqlCommand cmd = new SqlCommand("select productName from assignParty inner join product on assignParty.productId=product.productId inner join party on assignParty.partyId=party.partyId where partyName=@partyName", con);
            cmd.Parameters.AddWithValue("@partyName", DropDownList1.SelectedValue.ToString());
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                DropDownList2.Items.Add(sdr.GetString(0));
            }
            con.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from invoice";
            cmd.ExecuteNonQuery();
            con.Close();
            SqlCommand cmd1 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", con);
            con.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            Repeater1.DataSource = sdr1;
            Repeater1.DataBind();
            con.Close();
            Response.Redirect("invoice.aspx");
        }
    }
}