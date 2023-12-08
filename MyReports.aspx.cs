using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Davis_Justin_CitizenScience_Project
{
    public partial class MyReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

           string UserID = HttpContext.Current.User.Identity.GetUserId();
            if (UserID != null )
            {
                
                ShowReports();

            }
            else 
            {

                Response.Redirect("Login.aspx");
            }
        }
        protected void ShowReports()
        {

            if(User.Identity.IsAuthenticated) 
            {
                //We are logged in

                MyReportsPanel.Visible = true;
                string UserID = HttpContext.Current.User.Identity.GetUserId();
                string query = "SELECT * from Reports R Inner Join Projects P on P.ProjectID = R.ProjectID where VolunteerID = @UserID";    //This query will show all reports that the user has submitted where volunteerID = UserID   
                DataTable dt = new DataTable();
                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
                using(SqlConnection conn = new SqlConnection(connString)) //This will connect to the database
                {
                    conn.Open();
                    using(SqlCommand cmd =  new SqlCommand(query, conn))
                    {

                        cmd.Parameters.AddWithValue("@UserID", UserID); //`@UserID` is a parameter that will be replaced with the value of UserID
                         
                        cmd.ExecuteNonQuery();
                        using(SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                        }

                     
                    }


                }
                ReportsTable.DataSource = dt;
                ReportsTable.DataBind();

                
            }
            else
            {
                Response.Redirect("/Login.aspx");

            }


        }
    }
}