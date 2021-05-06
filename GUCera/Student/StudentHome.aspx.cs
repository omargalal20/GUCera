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
    public partial class StudentHome : System.Web.UI.Page
    {

        public void CreateLabel(string name)
        {
            Label lb = new Label();
            lb.Text = name;
            Panel2.Controls.Add(lb);
            Panel2.Controls.Add(new LiteralControl("</br >"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand courses = new SqlCommand("availableCourses", conn);
            courses.CommandType = System.Data.CommandType.StoredProcedure;
            Label1.Text = "ID :" + Convert.ToString((Int32)Session["user"]);
            conn.Open();
            SqlDataReader rdr = courses.ExecuteReader(CommandBehavior.CloseConnection);
            while (rdr.Read())
            {
                int cid = rdr.GetInt32(rdr.GetOrdinal("cid"));
                String courseName = rdr.GetString(rdr.GetOrdinal("name"));
                Label name = new Label();
                name.Text = courseName;
                name.ID = courseName + "<br >";

                Label name1 = new Label();
                name1.Text = cid + " ";

                Button b = new Button();
                b.ID = cid.ToString();
                b.Text = "Show Details";
                b.CssClass = "button";
                b.Click += new EventHandler(this.showcoursedetail_Click);
                Panel1.Controls.Add(b);
                Panel1.Controls.Add(name1);
                Panel1.Controls.Add(name);
                Panel1.Controls.Add(new LiteralControl("</br >"));
            }
            conn.Close();

            int sid = (Int32)Session["user"];

            SqlCommand view = new SqlCommand("ShowEnrolledCourses", conn);
            view.CommandType = System.Data.CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@id", sid));

            conn.Open();
            SqlDataReader rdr1 = view.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr1.HasRows == false)
            {
                Label lb = new Label();
                lb.Text = "You haven't enrolled in a course yet";
                Panel2.Controls.Add(lb);
            }
            else
            {
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
                    Button b = new Button();
                    b.ID = rdr1.GetInt32(rdr1.GetOrdinal("id")).ToString();
                    b.Text = "Show Assignment";
                    b.CssClass = "button";
                    b.Click += new EventHandler(this.showassignment_Click);
                    Panel2.Controls.Add(b);
                    Button b1 = new Button();
                    b1.ID = "s" + rdr1.GetInt32(rdr1.GetOrdinal("id")).ToString();
                    b1.Text = "Add Feedback";
                    b1.CssClass = "button";
                    b1.Click += new EventHandler(this.addFeedback_Click);
                    Panel2.Controls.Add(b1);
                    Button b2 = new Button();
                    b2.ID = "c" + rdr1.GetInt32(rdr1.GetOrdinal("id")).ToString();
                    b2.Text = "View Certificate";
                    b2.CssClass = "button";
                    b2.Click += new EventHandler(this.Certificate_Click);
                    Panel2.Controls.Add(b2);

                }
                
            }
                 conn.Close();
        }
        

        protected void Profile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Student Profile.aspx");
        }

        protected void showassignment_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Session["cid"] = Int32.Parse(clickedButton.ID);
            Response.Redirect("StudentAssignment.aspx");
        }
        protected void addFeedback_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string c = clickedButton.ID.Remove(0,1);
            Session["cid"] = Int32.Parse(c);
            Response.Redirect("AddFeedBack.aspx");
        }


        protected void showcoursedetail_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            Session["cid"] = Int32.Parse(clickedButton.ID);
            Response.Redirect("EnrollCourse.aspx");
        }
        protected void Certificate_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            string c = clickedButton.ID.Remove(0, 1);
            Session["cid"] = Int32.Parse(c);
            Response.Redirect("Certificates.aspx");
        }



    }
}