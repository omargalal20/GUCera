using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;


namespace GUCera
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //Create a new Connection 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand DefineAssignment = new SqlCommand("DefineAssignmentOfCourseOfCertianType", conn);
            DefineAssignment.CommandType = CommandType.StoredProcedure;

            String instructID = insIdInput.Text;
            if (String.IsNullOrEmpty(instructID) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }

            String courseId = courseIdInput.Text;
            if (String.IsNullOrEmpty(courseId) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }
            String AssNum = assiNumbInput.Text;
            if (String.IsNullOrEmpty(AssNum) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }
            String type = typeInput.SelectedValue;
            String fullGrade = fGradeInput.Text;
            if (String.IsNullOrEmpty(fullGrade) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }
            String weight = weightInput.Text;
            if (String.IsNullOrEmpty(weight) == true)
            {
                Response.Redirect("errorsPage.aspx");
            }
            DateTime deadline = DateTime.Parse(deadLineInput.Text); 

                String content = contentInput.Text;
           if (String.IsNullOrEmpty(content) == true)
                {
                    Response.Redirect("errorsPage.aspx");

           }

                DefineAssignment.Parameters.Add(new SqlParameter("@instId", instructID));
                DefineAssignment.Parameters.Add(new SqlParameter("@cid", courseId));
                DefineAssignment.Parameters.Add(new SqlParameter("number", AssNum));
                DefineAssignment.Parameters.Add(new SqlParameter("@type", type));
                DefineAssignment.Parameters.Add(new SqlParameter("@fullGrade", fullGrade));
                DefineAssignment.Parameters.Add(new SqlParameter("@weight", weight));
                DefineAssignment.Parameters.Add(new SqlParameter("@deadline", deadline));
                DefineAssignment.Parameters.Add(new SqlParameter("@content", content));

               

                conn.Open();
                
                int i = DefineAssignment.ExecuteNonQuery();
                
                conn.Close();

                if (i != 0)
                {
                    Response.Write("Assingment Added");
                }
                
               

            



        }

        protected void deadLineCalender_SelectionChanged(object sender, EventArgs e)
        {
            deadLineInput.Text = deadLineCalender.SelectedDate.ToShortDateString();
        }
    }
}