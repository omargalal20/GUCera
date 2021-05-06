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
    public partial class AddFeedBack : System.Web.UI.Page
    {
        public void CreateLabel(string name)
        {
            Label lb = new Label();
            lb.Text = name;
            Panel1.Controls.Add(lb);
            Panel1.Controls.Add(new LiteralControl("</br >"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("availableCourses", conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;
            int sid = (Int32)Session["user"];
            int cid = (Int32)Session["cid"];

            SqlCommand course = new SqlCommand("enrollInCourseViewContent", conn);
            course.CommandType = System.Data.CommandType.StoredProcedure;

            course.Parameters.Add(new SqlParameter("@id", sid));
            course.Parameters.Add(new SqlParameter("@cid", cid));

            conn.Open();
            SqlDataReader rdr1 = course.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr1.Read())
            {
                this.CreateLabel("Course ID : " + rdr1.GetInt32(rdr1.GetOrdinal("id")));
                this.CreateLabel("Course Name : " + rdr1.GetString(rdr1.GetOrdinal("name")));
                this.CreateLabel("Course Credit Hours : " + rdr1.GetInt32(rdr1.GetOrdinal("creditHours")));
                this.CreateLabel("Course Description : " + rdr1.GetString(rdr1.GetOrdinal("courseDescription")));
                this.CreateLabel("Course Price : " + rdr1.GetDecimal(rdr1.GetOrdinal("price")));
                this.CreateLabel("Course Content : " + rdr1.GetString(rdr1.GetOrdinal("content")));
                this.CreateLabel("Admin ID : " + rdr1.GetInt32(rdr1.GetOrdinal("adminid")));
                this.CreateLabel("Instructor ID : " + rdr1.GetInt32(rdr1.GetOrdinal("instructorid")));
            }
            conn.Close();
            if (Session["error"] != null)
            {
                error.Text = (string)Session["error"];
            }
        }
        protected void addfeedback_Click(object sender, EventArgs e)
        {
            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            int sid = (Int32)Session["user"];
            int cid = (Int32)Session["cid"];
            string feedback = TextBox1.Text;

            if (TextBox1.Text == "")
            {
                error.Text = "Must Enter Feedback";
            }
            else
            {
                SqlCommand addfeedback = new SqlCommand("addFeedBack", conn);
                addfeedback.CommandType = System.Data.CommandType.StoredProcedure;

                addfeedback.Parameters.Add(new SqlParameter("@comment", feedback));
                addfeedback.Parameters.Add(new SqlParameter("@cid", cid));
                addfeedback.Parameters.Add(new SqlParameter("@sid", sid));

                conn.Open();
                addfeedback.ExecuteNonQuery();
                conn.Close();


                Session["error"] = "Feedback Saved";
            }
            

        }
        protected void Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student/Student Profile.aspx");
        }
        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentHome.aspx");
        }
    }
}