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
    public partial class WebForm11 : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                DropDownList1.Items.Clear();
                DropDownList1.Items.Add("Select Value");
                SqlCommand cmd = new SqlCommand("select partyName from party", sqlConnection);
                sqlConnection.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DropDownList1.Items.Add(sdr.GetString(0));
                }
                sqlConnection.Close();
                
            }
            }
            
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select top 1 rate from productRate inner join product on product.productId=productRate.productId where productName=@productname order by productRateId desc", sqlConnection);
            cmd.Parameters.AddWithValue("@productname", DropDownList2.SelectedValue.ToString());
            sqlConnection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                TextBox1.Text = sdr.GetDecimal(0).ToString();
            }
            sqlConnection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string party_name = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
            string product_name = DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            int partyId = -1, productId = -1;
            sqlConnection.Open();
            SqlCommand ins = new SqlCommand("select party.partyid,product.productid from assignParty inner join party on assignParty.partyId = party.partyId inner join product on assignParty.productId = product.productId where product.productName = '"+product_name+"' and party.partyName = '"+party_name+"'", sqlConnection);
            SqlDataReader sdr = ins.ExecuteReader();
            while (sdr.Read())
            {
                partyId = sdr.GetInt32(0);
                productId = sdr.GetInt32(1);
            }
            sqlConnection.Close();
            sqlConnection.Open();
            SqlCommand ins1 = new SqlCommand("insert into invoice values(@partyId,@productId,@currentRate,@qty) ", sqlConnection);
            ins1.Parameters.AddWithValue("@partyid", partyId);
            ins1.Parameters.AddWithValue("@productid", productId);
            ins1.Parameters.AddWithValue("@currentRate", Convert.ToDecimal(TextBox1.Text));
            ins1.Parameters.AddWithValue("@qty", Convert.ToInt32(TextBox2.Text));
            ins1.ExecuteNonQuery();
            DropDownList1.Enabled = false;
            TextBox1.Text = "";
            TextBox2.Text = "";
            sqlConnection.Close();
            SqlCommand cmd1 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            Repeater1.DataSource = sdr1;
            Repeater1.DataBind();
            
            sqlConnection.Close();
            sqlConnection.Open();
            decimal sum = 0;
            SqlCommand cmd2 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", sqlConnection);
            SqlDataReader sdr2 = cmd2.ExecuteReader();
            while (sdr2.Read())
            {
                sum += sdr2.GetDecimal(5);
            }
            Label2.Text = sum.ToString();
            sqlConnection.Close();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DropDownList2.Items.Clear();
            DropDownList2.Items.Add("Select Value");
            SqlCommand cmd = new SqlCommand("select productName from assignParty inner join product on assignParty.productId=product.productId inner join party on assignParty.partyId=party.partyId where partyName=@partyName", sqlConnection);
            cmd.Parameters.AddWithValue("@partyName", DropDownList1.SelectedValue.ToString());
            sqlConnection.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                DropDownList2.Items.Add(sdr.GetString(0));
            }
            sqlConnection.Close();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from invoice";
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
            SqlCommand cmd1 = new SqlCommand("select invoiceId,partyName,productName,currentRate,qty,(qty*currentRate) as total from invoice inner join party on party.partyId=invoice.partyId inner join product on invoice.productId=product.productId", sqlConnection);
            sqlConnection.Open();
            SqlDataReader sdr1 = cmd1.ExecuteReader();
            Repeater1.DataSource = sdr1;
            Repeater1.DataBind();
            sqlConnection.Close();
            Response.Redirect("invoice.aspx");
        }
    }
}