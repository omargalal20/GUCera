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
    public partial class feedbacks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //Create a new Connection 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand InsviewFeedbacks = new SqlCommand("ViewFeedbacksAddedByStudentsOnMyCourse", conn);
            InsviewFeedbacks.CommandType = CommandType.StoredProcedure;

            String courseID = courseInput.Text;
            if (String.IsNullOrEmpty(courseID) == true)
            {
                Response.Redirect("erfeedbackPage.aspx");

            }

            String instructID = insInput.Text;
            if (String.IsNullOrEmpty(instructID) == true)
            {
                Response.Redirect("erfeedbackPage.aspx");

            }

            InsviewFeedbacks.Parameters.Add(new SqlParameter("@instrId", instructID));
            InsviewFeedbacks.Parameters.Add(new SqlParameter("cid", courseID));


            
            
            conn.Open();

            InsviewFeedbacks.ExecuteNonQuery();
                SqlDataReader rdr = InsviewFeedbacks.ExecuteReader(CommandBehavior.CloseConnection);
                while (rdr.Read())
                {
                    String feedbacks = rdr.GetString(rdr.GetOrdinal("comment"));
                    Label Feedbacks = new Label();
                    Feedbacks.Text = feedbacks;
                    form1.Controls.Add(Feedbacks);
                }
            

        }
    }
}