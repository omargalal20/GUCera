using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Student_Profile : System.Web.UI.Page
    {
        public void CreateLabel(string name)
        {
            Label lb = new Label();
            lb.Text = name;
            infoPanel.Controls.Add(lb);
            infoPanel.Controls.Add(new LiteralControl("</br >"));
        }
        public void CreateMobileTextBox(string id)
        {
            TextBox txt = new TextBox();
            txt.ID = id;
            mobilesPanel.Controls.Add(txt);
            Literal lt = new Literal();
            lt.Text = "<br />";
            mobilesPanel.Controls.Add(lt);
        }

        public void CreatePromoTextBox(string name)
        {
            Label lb = new Label();
            lb.Text = name;
            promoPanel.Controls.Add(lb);
            promoPanel.Controls.Add(new LiteralControl("</br >"));
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            infolabel.Text = "ID: " + Convert.ToString((Int32)Session["user"]);
            int id = (Int32)Session["user"];

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand profile = new SqlCommand("viewMyProfile", conn);
            profile.CommandType = System.Data.CommandType.StoredProcedure;

            profile.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            SqlDataReader rdr = profile.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                this.CreateLabel("First Name : "+rdr.GetString(rdr.GetOrdinal("firstname")));
                this.CreateLabel("Last Name : " + rdr.GetString(rdr.GetOrdinal("lastname")));
                this.CreateLabel("Password : " + rdr.GetString(rdr.GetOrdinal("password")));
                if (rdr.GetSqlBinary((rdr.GetOrdinal("gender"))).ToString() == "0x00")
                {
                    this.CreateLabel("Gender : male");
                }
                else{
                    this.CreateLabel("Gender : Female");
                }
                this.CreateLabel("Email : " + rdr.GetString(rdr.GetOrdinal("email")));
                this.CreateLabel("Address : " + rdr.GetString(rdr.GetOrdinal("Address")));

            }

            if (Session["mobileerror"] != null)
            {
                Label2.Text = (string)Session["mobileerror"];
            }
            if(Session["error"] != null)
            {
                error.Text = (string)Session["error"];
            }
        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
        protected void addmobile_Click(object sender, EventArgs e)
        {
            int index = mobilesPanel.Controls.OfType<TextBox>().ToList().Count + 1;
            CreateMobileTextBox("txtbox" + index);
        }
        protected void savemobile_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TextBox textBox in mobilesPanel.Controls.OfType<TextBox>())
            {
                if (textBox.Text == "")
                {
                    i++;
                }
            }
            if (i!=0) {
                Session["mobileerror"] = "There was an empty input";
                Response.Redirect("Student Profile.aspx");
            }
            else
            {
                foreach (TextBox textBox in mobilesPanel.Controls.OfType<TextBox>())
                {
                    savedata(textBox.Text);
                }
                Label2.Text = "Data Has Been Saved Successfully";
            }
        }

        protected void savedata(string text)
        {
            int id = (Int32)Session["user"];
            string number = text;
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand addmobile = new SqlCommand("addMobile", conn);
            addmobile.CommandType = CommandType.StoredProcedure;
            addmobile.Parameters.Add(new SqlParameter("@ID", id));
            addmobile.Parameters.Add(new SqlParameter("@mobile_number", number));
            conn.Open();
            addmobile.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Student Profile.aspx");
        }

        protected void addcredit_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TextBox textBox in creditPanel.Controls.OfType<TextBox>())
            {
                if (textBox.Text == "")
                {
                    i++;
                }
            }
            if (i != 0)
            {
                error.Text = "Empty Input";
            }
            else
            {
                int id = (Int32)Session["user"];
                string num = number.Text;
                string chn = cardholdername.Text;
                DateTime edate = Convert.ToDateTime(expirydate.Text);
                string c = cvv.Text;
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                SqlCommand addCreditCard = new SqlCommand("addCreditCard", conn);
                addCreditCard.CommandType = CommandType.StoredProcedure;
                addCreditCard.Parameters.Add(new SqlParameter("@sid", id));
                addCreditCard.Parameters.Add(new SqlParameter("@number", num));
                addCreditCard.Parameters.Add(new SqlParameter("@cardHolderName", chn));
                addCreditCard.Parameters.Add(new SqlParameter("@expiryDate", edate));
                addCreditCard.Parameters.Add(new SqlParameter("@cvv", c));
                conn.Open();
                addCreditCard.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Student Profile.aspx");
                Session["error"] = "Data Has Been Saved Successfully";
            }

        }
        protected void viewpromo_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int id = (Int32)Session["user"];
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand promos = new SqlCommand("viewPromocode", conn);
            promos.CommandType = System.Data.CommandType.StoredProcedure;

            promos.Parameters.Add(new SqlParameter("@sid", id));
            conn.Open();
            SqlDataReader rdr = promos.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows==false)
            {
                Label lb = new Label();
                lb.Text = "No promo codes has been issued";
                promoPanel.Controls.Add(lb);
            }
            else { 
            while (rdr.Read())
            {
                this.CreatePromoTextBox("Code : " + rdr.GetString(rdr.GetOrdinal("code")));
                this.CreatePromoTextBox("IssueDate : " + rdr.GetDateTime(rdr.GetOrdinal("isuueDate")));
                this.CreatePromoTextBox("ExpiryDate : " + rdr.GetDateTime(rdr.GetOrdinal("expiryDate")));
                this.CreatePromoTextBox("Discount : " + rdr.GetDecimal(rdr.GetOrdinal("discount")));
                this.CreatePromoTextBox("AdminId : " + rdr.GetInt32(rdr.GetOrdinal("adminId")));
            }
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            List<string> keys = Request.Form.AllKeys.Where(key => key.Contains("txtbox")).ToList();
            int i = 1;
            foreach (string key in keys)
            {
                this.CreateMobileTextBox("txtbox" + i);
                i++;
            }
        }
    }
}