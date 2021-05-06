using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUCera
{
    public partial class Instructor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void addCoruse(object sender, EventArgs e)
        {
            Response.Redirect("addCoursePage.aspx");
        }

        protected void aepView_Click(object sender, EventArgs e)
        {
            Response.Redirect("AEP.aspx");
        }

        protected void feedBacksView_Click(object sender, EventArgs e)
        {
            Response.Redirect("feedbacks.aspx");
        }

        protected void certificatesissue_Click(object sender, EventArgs e)
        {
            Response.Redirect("Certificate.aspx");
        }
    }
}