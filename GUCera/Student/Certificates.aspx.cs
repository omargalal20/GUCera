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
    public partial class Certificates : System.Web.UI.Page
    {
        public void CreateLabel(string name)
        {
            Label lb = new Label();
            lb.Text = name;
            infoPanel.Controls.Add(lb);
            infoPanel.Controls.Add(new LiteralControl("</br >"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("viewCertificate", conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;

            courses.Parameters.Add(new SqlParameter("@cid", Session["cid"]));
            courses.Parameters.Add(new SqlParameter("@sid", Session["user"]));

            conn.Open();
            SqlDataReader rdr1 = courses.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr1.HasRows == false)
            {
                Label lb = new Label();
                lb.Text = "You haven't finished this course";
                infoPanel.Controls.Add(lb);
            }
            else
            {
                this.CreateLabel("Course ID : " + rdr1.GetInt32(rdr1.GetOrdinal("id")));
                this.CreateLabel("Course Name : " + rdr1.GetString(rdr1.GetOrdinal("name")));
                this.CreateLabel("IssueDate : " + rdr1.GetDateTime(rdr1.GetOrdinal("issueDate")));

            }
            conn.Close();
        }
        protected void Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student Profile.aspx");
        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}