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
    public partial class EnrollCourse : System.Web.UI.Page
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
            int id = (Int32)Session["cid"];

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand course = new SqlCommand("courseInformation", conn);
            course.CommandType = System.Data.CommandType.StoredProcedure;

            course.Parameters.Add(new SqlParameter("@id", id));
            conn.Open();
            SqlDataReader rdr = course.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                this.CreateLabel("Course Name : " + rdr.GetString(rdr.GetOrdinal("name")));
                this.CreateLabel("Credit Hours : " + rdr.GetInt32(rdr.GetOrdinal("creditHours")));
                this.CreateLabel("Course Description : " + rdr.GetString(rdr.GetOrdinal("courseDescription")));
            }
            conn.Close();
            this.CreateLabel("</br >" + "Instructors who teach course :" + "</br >");
            SqlCommand info = new SqlCommand("ShowInstructors", conn);
            info.CommandType = System.Data.CommandType.StoredProcedure;

            info.Parameters.Add(new SqlParameter("@cid", id));
            conn.Open();
            SqlDataReader rdr1 = info.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr1.Read())
            {
                this.CreateLabel("Instructor id : " + rdr1.GetInt32(rdr1.GetOrdinal("id")));
                this.CreateLabel("Instructor First Name : " + rdr1.GetString(rdr1.GetOrdinal("firstName")));
                this.CreateLabel("Instructor Last Name : " + rdr1.GetString(rdr1.GetOrdinal("lastName")));
            }
            conn.Close();
        }

        protected void enroll_Click(object sender, EventArgs e)
        {
            int cid = (Int32)Session["cid"];
            int sid = (Int32)Session["user"];
            if (TextBox1.Text == "")
            {
                Label2.Text = "Must enter instructor id";
            }
            else { 
            int Iid = Int32.Parse(TextBox1.Text);

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand enroll = new SqlCommand("enrollInCourse", conn);
            enroll.CommandType = System.Data.CommandType.StoredProcedure;

            enroll.Parameters.Add(new SqlParameter("@sid", sid));
            enroll.Parameters.Add(new SqlParameter("@cid", cid));
            enroll.Parameters.Add(new SqlParameter("@instr", Iid));
                conn.Open();
                enroll.ExecuteNonQuery();
                conn.Close();
                Session["enrolledcid"] = cid;
            Session["enrolledsid"] = sid;

            Response.Redirect("StudentHome.aspx");
            }
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