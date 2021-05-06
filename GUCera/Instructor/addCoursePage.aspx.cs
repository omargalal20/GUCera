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
    public partial class addCoursePage : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //Create a new Connection 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand InstAddCourseProc = new SqlCommand("InstAddCourse", conn);
            InstAddCourseProc.CommandType = CommandType.StoredProcedure;
            SqlCommand CourseDescription = new SqlCommand("UpdateCourseDescription", conn);
            SqlCommand InsertedCourses = new SqlCommand("SELECT * FROM Course", conn);



            String courseName = cName.Text;

            if (String.IsNullOrEmpty(courseName) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }


            String instructID = instID.Text;
            if (String.IsNullOrEmpty(instructID) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }

            String courseContent = contentInput.Text;
            if (String.IsNullOrEmpty(courseContent) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }
            String descri = descInput.Text;
            if (String.IsNullOrEmpty(descri) == true)
            {
                Response.Redirect("errorsPage.aspx");

            }
            int cHours = Int16.Parse(creditHours.Text);
            int coursePrise = Int32.Parse(price.Text);

           


          
            InstAddCourseProc.Parameters.Add(new SqlParameter("@instructorId", instructID));
            InstAddCourseProc.Parameters.Add(new SqlParameter("@cContent", courseContent));
            InstAddCourseProc.Parameters.Add(new SqlParameter("@descripiton", descri));
            InstAddCourseProc.Parameters.Add(new SqlParameter("@name", courseName));
            InstAddCourseProc.Parameters.Add(new SqlParameter("@creditHours", cHours));
            InstAddCourseProc.Parameters.Add(new SqlParameter("@price", coursePrise));

            conn.Open();
            SqlDataReader rdr = InsertedCourses.ExecuteReader();
            while (rdr.Read())
            {
                String cName = rdr.GetString(rdr.GetOrdinal("name"));
                if (cName == courseName)
                {
                    Response.Redirect("errorsPage.aspx");
                }
            }           
            int i =InstAddCourseProc.ExecuteNonQuery();



            conn.Close();
            if (i != 0)
            {
                Response.Write("Course Added");
            }
        }

        
    }
}