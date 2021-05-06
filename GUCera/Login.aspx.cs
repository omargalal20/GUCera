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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            if (username.Text=="" || password.Text=="")
            {
                error.Text = "You forget to fill an input";
            }
            else { 
            int id = Int16.Parse(username.Text);
            String pass = password.Text;

            SqlCommand loginproc = new SqlCommand("userlogin", conn);
            loginproc.CommandType = CommandType.StoredProcedure;
            loginproc.Parameters.Add(new SqlParameter("@ID", id));
            loginproc.Parameters.Add(new SqlParameter("@password", pass));

            SqlParameter success = loginproc.Parameters.Add("@success",SqlDbType.Int);
            SqlParameter type = loginproc.Parameters.Add("@type",SqlDbType.Int);

            success.Direction = ParameterDirection.Output;
            type.Direction = ParameterDirection.Output;

            conn.Open();
            loginproc.ExecuteNonQuery();
            conn.Close();

            if (success.Value.ToString() == "0")
            {
                error.Text = "Incorrect username or password";
            }
            if (success.Value.ToString() == "1")
            {
                Session["user"] = id;
                if (type.Value.ToString() == "0")
                {
                    Response.Redirect("Instructor/Instructor.aspx");
                }
                else if(type.Value.ToString() == "1")
                {

                }
                else
                {
                    Response.Redirect("Student/StudentHome.aspx");
                }

            }
            }

        }
        protected void register_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student/Register.aspx");
        }
    }
}