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
    public partial class AssignmentGrade : System.Web.UI.Page
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
            int cid = (Int32)Session["cid"];
            int number = (Int32)Session["number"];

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
                    this.CreateLabel("Course ID : " + rdr1.GetInt32(rdr1.GetOrdinal("cid")));
                    this.CreateLabel("Assignment Type : " + rdr1.GetString(rdr1.GetOrdinal("type")));
                    type += rdr1.GetString(rdr1.GetOrdinal("type"));
                    this.CreateLabel("Assignment Number : " + rdr1.GetInt32(rdr1.GetOrdinal("number")));
                    this.CreateLabel("Full Grade : " + rdr1.GetInt32(rdr1.GetOrdinal("fullGrade")));
                    this.CreateLabel("Assignment Weight : " + rdr1.GetDecimal(rdr1.GetOrdinal("weight")));
                    this.CreateLabel("Assignment Deadline : " + rdr1.GetDateTime(rdr1.GetOrdinal("deadline")));
                    Panel1.Controls.Add(new LiteralControl("</br >"));
            }
            conn.Close();

            conn.Open();
            SqlCommand viewAssign = new SqlCommand("viewAssignGrades", conn);
            viewAssign.CommandType = System.Data.CommandType.StoredProcedure;
            viewAssign.Parameters.Add(new SqlParameter("@assignnumber", number));
            viewAssign.Parameters.Add(new SqlParameter("@assignType", type));
            viewAssign.Parameters.Add(new SqlParameter("@cid", cid));
            viewAssign.Parameters.Add(new SqlParameter("@sid", sid));
            
            SqlDataReader rdr = viewAssign.ExecuteReader(CommandBehavior.CloseConnection);
            if(rdr.HasRows == false)
            {
                Label1.Text = "You haven't submitted this assignment";
            }
            else
            {
                while (rdr.Read())
                {
                    try
                    {
                        Label1.Text = rdr.GetInt32(rdr.GetOrdinal("grade")).ToString();
                    }
                    catch (Exception )
                    {
                        Label1.Text = "Assignment still not graded";
                    }
                    
                }
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