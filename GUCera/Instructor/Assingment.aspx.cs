using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace GUCera
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //Create a new Connection 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand viewAssignments = new SqlCommand("InstructorViewAssignmentsStudents", conn);
            viewAssignments.CommandType = CommandType.StoredProcedure;


            String instructID = insID.Text;
            if (String.IsNullOrEmpty(instructID) == true)
            {
                Response.Redirect("erAddAssiPage.aspx");

            }
            String courseid = cid.Text;
            if (String.IsNullOrEmpty(courseid) == true)
            {
                Response.Redirect("erAddAssiPage.aspx");

            }

            viewAssignments.Parameters.Add(new SqlParameter("@instrId", instructID));
            viewAssignments.Parameters.Add(new SqlParameter("cid", courseid));


            conn.Open();
            SqlDataReader rdr = viewAssignments.ExecuteReader(CommandBehavior.CloseConnection);
            if (rdr.HasRows == false)
            {
                Label1.Text = "No assignments has been submitted";
            }
            while (rdr.Read())
            {
                int Assignments = rdr.GetInt32(rdr.GetOrdinal("assignmentNumber"));
                string type = rdr.GetString(rdr.GetOrdinal("assignmenttype"));
                Label assignmentNumber = new Label();
                assignmentNumber.Text = "Assignment number: " + Assignments.ToString();
                form1.Controls.Add(assignmentNumber);
                form1.Controls.Add(new LiteralControl("<br />"));
                Label typelabel = new Label();
                typelabel.Text = type.ToString();
                form1.Controls.Add(typelabel);
            }
        }
    }
}