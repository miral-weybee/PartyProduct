using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace PartyProduct
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=.; database=PartyProduct; integrated security=SSPI");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("login.aspx");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("productRateList.aspx");
        }

        protected void productRateListEditSavebtn_Click(object sender, EventArgs e)
        {
            int pr_id = -1;
            if (TextBox1.Text == string.Empty || 
                TextBox2.Text == string.Empty || 
                Convert.ToInt32(TextBox1.Text) < 0 || 
                int.TryParse(TextBox1.Text, out _) == false ||
                DateTime.TryParseExact(TextBox2.Text,"yyyy-dd-MM",CultureInfo.InvariantCulture,DateTimeStyles.None,out _) == false)
                
            {
                DisplayAlert("Product Rate or Date of Rate is invalid or empty....");
            }
            else
            {
                string product = DropDownList1.Items[DropDownList1.SelectedIndex].Text;
                SqlCommand productcmd = new SqlCommand("select * from product", con);
                con.Open();
                SqlDataReader sdr1 = productcmd.ExecuteReader();
                while (sdr1.Read())
                {
                    if (sdr1.GetString(1) == product)
                    {
                        pr_id = sdr1.GetInt32(0);
                        break;
                    }
                }
                con.Close();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into productRate values('"+pr_id+"','"+TextBox1.Text+"','"+TextBox2.Text+"')";
                cmd.ExecuteNonQuery();
                DisplayAlert("Product Rate Added Successfully....");
                con.Close();
            }
        }
        protected virtual void DisplayAlert(string message)
        {
            ClientScript.RegisterStartupScript(
              this.GetType(),
              Guid.NewGuid().ToString(),
              string.Format("alert('{0}');window.location.href = 'productRateListEdit.aspx'",
                message.Replace("'", @"\'").Replace("\n", "\\n").Replace("\r", "\\r")),
                true);
        }
    }
}