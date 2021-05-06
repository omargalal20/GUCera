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
    public partial class StudentAssignment : System.Web.UI.Page
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

            int sid = (Int32)Session["user"];
            int cname = (Int32)Session["cid"];

            SqlCommand view = new SqlCommand("viewAssign", conn);
            view.CommandType = System.Data.CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@courseId", cname));
            view.Parameters.Add(new SqlParameter("@Sid", sid));

            conn.Open();
            SqlDataReader rdr1 = view.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr1.HasRows == false)
            {
                Label lb = new Label();
                lb.Text = "You dont have any assignments";
                Panel1.Controls.Add(lb);
            }
            else
            {
                while (rdr1.Read())
                {
                    this.CreateLabel("Course ID : " + rdr1.GetInt32(rdr1.GetOrdinal("cid")));
                    this.CreateLabel("Course Name : " + rdr1.GetString(rdr1.GetOrdinal("cname")));
                    this.CreateLabel("Assignment Type : " + rdr1.GetString(rdr1.GetOrdinal("type")));
                    this.CreateLabel("Assignment Number : " + rdr1.GetInt32(rdr1.GetOrdinal("number")));
                    this.CreateLabel("Full Grade : " + rdr1.GetInt32(rdr1.GetOrdinal("fullGrade")));
                    this.CreateLabel("Assignment Weight : " + rdr1.GetDecimal(rdr1.GetOrdinal("weight")));
                    this.CreateLabel("Assignment Deadline : " + rdr1.GetDateTime(rdr1.GetOrdinal("deadline")));


                    Panel1.Controls.Add(new LiteralControl("</br >"));

                    Button b = new Button();
                    b.ID = rdr1.GetInt32(rdr1.GetOrdinal("number")).ToString();
                    b.CssClass = "button";
                    Session[rdr1.GetInt32(rdr1.GetOrdinal("number")).ToString()] = rdr1.GetInt32(rdr1.GetOrdinal("number"));
                    b.Text = "Submit Assignment";
                    b.Click += new EventHandler(this.submitAssignment_Click);
                    Panel1.Controls.Add(b);

                    Button b1 = new Button();
                    b1.ID = "n" + rdr1.GetInt32(rdr1.GetOrdinal("number")).ToString();
                    b1.CssClass = "button";
                    b1.Text = "View Assignment Grade";
                    b1.Click += new EventHandler(this.ViewAssignmentGrade_Click);
                    Panel1.Controls.Add(b1);
                    Panel1.Controls.Add(new LiteralControl("</br >"));
                }
                Session["cid"] = cname;
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
        protected void submitAssignment_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            int number = Int32.Parse(clickedButton.ID);
            int cid = (Int32)Session["cid"];
            int sid = (Int32)Session["user"];

            string connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            SqlConnection conn = new SqlConnection(connStr);

            SqlCommand view = new SqlCommand("viewSpecificAssign", conn);
            view.CommandType = System.Data.CommandType.StoredProcedure;

            view.Parameters.Add(new SqlParameter("@cid", cid));
            view.Parameters.Add(new SqlParameter("@sid", sid));
            view.Parameters.Add(new SqlParameter("@number", number));

            conn.Open();
            SqlDataReader rdr1 = view.ExecuteReader(CommandBehavior.CloseConnection);
            string type = "";
            while (rdr1.Read())
            {
              type += rdr1.GetString(rdr1.GetOrdinal("type"));
            }
            conn.Close();


            SqlCommand submit = new SqlCommand("submitAssign", conn);
            submit.CommandType = System.Data.CommandType.StoredProcedure;
            submit.Parameters.Add(new SqlParameter("@assigntype", type));
            submit.Parameters.Add(new SqlParameter("@assignnumber", number));
            submit.Parameters.Add(new SqlParameter("@sid", sid));
            submit.Parameters.Add(new SqlParameter("@cid", cid));
            try
            {
                conn.Open();
                submit.ExecuteNonQuery();
                conn.Close();
                error.Text = "Assignment Submitted";
            }
            catch (Exception)
            {
                error.Text = "Assignment Already Submitted";
            }
        }

        protected void ViewAssignmentGrade_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            String x = clickedButton.ID.Remove(0, 1);
            Session["number"] = Int32.Parse(x);
            Session["cid"] = (Int32)Session["cid"];
            Response.Redirect("AssignmentGrade.aspx");

        }
    }
}