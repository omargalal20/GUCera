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
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        protected void Button1_Click(object sender, EventArgs e)
        {
            String connStr = WebConfigurationManager.ConnectionStrings["GUCera"].ToString();
            //Create a new Connection 
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand certificateIssue = new SqlCommand("InstructorIssueCertificateToStudent", conn);
            certificateIssue.CommandType = CommandType.StoredProcedure;


            String courseID = cidInput.Text;
            if (String.IsNullOrEmpty(courseID) == true)
            {
                Response.Redirect("erCertificatePage.aspx");

            }
            String studentID = sidInput.Text;
            if (String.IsNullOrEmpty(studentID) == true)
            {
                Response.Redirect("erCertificatePage.aspx");

            }
            String instructID = insIdInput.Text;
            if (String.IsNullOrEmpty(instructID) == true)
            {
                Response.Redirect("erCertificatePage.aspx");

            }
            DateTime issueDate = DateTime.Parse(dateInput.Text);

            certificateIssue.Parameters.Add(new SqlParameter("@cid", courseID));
            certificateIssue.Parameters.Add(new SqlParameter("@sid", studentID));
            certificateIssue.Parameters.Add(new SqlParameter("@insId", instructID));
            certificateIssue.Parameters.Add(new SqlParameter("@issueDate", issueDate));

            conn.Open();
            int i = certificateIssue.ExecuteNonQuery();
            conn.Close();
            if (i != 0)
            {
                Response.Write("Certificate issued");
            }

        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            dateInput.Text = Calendar1.SelectedDate.ToShortDateString();
        }

    }
}