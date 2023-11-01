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
    public partial class EditPoductRate : System.Web.UI.Page
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
                SqlCommand cmd = new SqlCommand("select product.productName,productrate.rate,productrate.dateofrate from productrate inner join product on product.productid=productrate.productid where productrateid=" + Convert.ToInt32(Request.QueryString["id"].ToString()) + "", con);
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    DropDownList1.Items.Add(sdr.GetString(0));
                    TextBox1.Text = sdr.GetDecimal(1).ToString();
                    TextBox2.Text = sdr.GetDateTime(2).ToString();
                }

                DropDownList1.Enabled = false;
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                con.Close();
            }
            else
            {
                DisplayAlert("Not a valid request");
            }
            }
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'productRateList.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }

        protected void productRateListEditSavebtn_Click(object sender, EventArgs e)
        {
            string product = DropDownList2.Items[DropDownList2.SelectedIndex].Text;
            int productid = -1;
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
            SqlCommand cmd1 = new SqlCommand("update productrate set productid="+productid+ ",rate="+ TextBox3 .Text+ ",dateofrate='"+ TextBox4.Text+ "'", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            DisplayAlert("Product Rate updated successfully....");
            con.Close();
        }
            

    }
}
    
