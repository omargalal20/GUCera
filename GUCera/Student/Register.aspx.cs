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
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submit_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (TextBox textBox in registerPanel.Controls.OfType<TextBox>())
            {
                if (textBox.Text == "")
                {
                    i++;
                }
            }
            if (IorS.SelectedValue == "")
            {
                i++;
            }
            if (gender.SelectedValue == "")
            {
                i++;
            }

            if (i != 0)
            {
                error.Text = "You Forgot to fill all info";
            }
            else {
                string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
                SqlConnection conn = new SqlConnection(connStr);
                String fn = firstname.Text;
                String ln = lastname.Text;
                String pass = password.Text;
                String em = email.Text;
                String addrs = address.Text;
                String gend = gender.SelectedValue;
                int gen;
                if (gend == "0")
                {
                    gen = 0;
                }
                else
                {
                    gen = 1;
                }

                if (IorS.SelectedValue == "0")
                {

                    SqlCommand Iregproc = new SqlCommand("InstructorRegister", conn);
                    Iregproc.CommandType = CommandType.StoredProcedure;
                    Iregproc.Parameters.Add(new SqlParameter("@first_name", fn.ToString()));
                    Iregproc.Parameters.Add(new SqlParameter("@last_name", ln.ToString()));
                    Iregproc.Parameters.Add(new SqlParameter("@password", pass.ToString()));
                    Iregproc.Parameters.Add(new SqlParameter("@email", em.ToString()));
                    Iregproc.Parameters.Add(new SqlParameter("@gender", gen));
                    Iregproc.Parameters.Add(new SqlParameter("@address", addrs.ToString()));

                    conn.Open();
                    Iregproc.ExecuteNonQuery();
                    conn.Close();
                }
                if (IorS.SelectedValue == "1")
                {

                    SqlCommand sregproc = new SqlCommand("StudentRegister", conn);
                    sregproc.CommandType = CommandType.StoredProcedure;
                    sregproc.Parameters.Add(new SqlParameter("@first_name", fn));
                    sregproc.Parameters.Add(new SqlParameter("@last_name", ln));
                    sregproc.Parameters.Add(new SqlParameter("@password", pass));
                    sregproc.Parameters.Add(new SqlParameter("@email", em));
                    sregproc.Parameters.Add(new SqlParameter("@gender", gen));
                    sregproc.Parameters.Add(new SqlParameter("@address", addrs));
                    conn.Open();
                    sregproc.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("StudentHome.aspx");
                }

                Session["userpass"] = password.Text;
                
            }
        }

    }
}