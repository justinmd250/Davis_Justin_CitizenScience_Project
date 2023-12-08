using Microsoft.AspNet.Identity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Davis_Justin_CitizenScience_Project
{
    public partial class ObservationSubmission : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string ReportID = Session["ReportID"] as string;
            if(ReportID != null)
            {

                // If we have a report ID, we are submitting an observation for an existing report
                ObservationSubmissionID.Visible = true;
            }
            else
            {
                CreateReport();
            }
        }    
    

        protected void ShowObservation()
        {

            if(User.Identity.IsAuthenticated) 
            { 
                ObservationSubmissionID.Visible=true;
            
            
            
            }
            else
            {
                Response.Redirect("Login.aspx");

            }




        }


        private void CreateReport()
        {
            // This method creates a new report and stores the report ID in the session
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            string userID = HttpContext.Current.User.Identity.GetUserId();
            string ProjectID = Session["ProjectID"] as string;

            if (ProjectID != null & userID != null)
            {

                //We have a project ID and a user ID, so we can create a new report
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spCreateNewReport", conn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                        cmd.Parameters.AddWithValue("@VolunteerID", userID);
                        cmd.Parameters.Add("@ReportID", SqlDbType.Int);
                        //These are the parameters that will be passed to the stored procedure
                        cmd.Parameters["@ReportID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        Session["ReportID"] = cmd.Parameters["@ReportID"].Value.ToString();

                    }


                }
                ObservationSubmissionID.Visible = true;


            }

           

            else
            {
                //If we don't have a project ID or a user ID, we can't create a new report
                errorMsgPan.Visible = true;

            }


        }

       


        private void InsertintoObservations()
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            int ReportID = int.Parse(Session["ReportID"].ToString());
            string Notes = NotesBox.Text;
            using(SqlConnection conn = new SqlConnection(connString))
            {
                //This method inserts the observation into the database

                conn.Open();

                using(SqlCommand cmd = new SqlCommand("spCreateNewObservations", conn))
                {


                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReportID", ReportID);
                    cmd.Parameters.Add("@ObservationID", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("@Notes", Notes); 
                    cmd.Parameters["@ObservationID"].Direction = ParameterDirection.Output;//The parameterdirection.output means that the parameter is an output parameter
                    cmd.ExecuteNonQuery();
                    ObservationSubmissionID.Visible = true;

                    if (cmd.Parameters["@ObservationID"].Value != DBNull.Value) // If the parameter is not null, then the observation was successfully inserted into the database
                    {

                        SubmissionSuccess.Visible = true;
                        SubmissionNumber.Text = cmd.Parameters["@ObservationID"].Value.ToString();


                    }
                }

            
            
            }







        }
   
     

        public void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                InsertintoObservations();
                // This method is called when the user clicks the submit button
                ObservationSubmissionID.Visible = false;
                System.Threading.Thread.Sleep(5000);

                Response.Redirect("ReportDetails.aspx?ID=" + Session["ReportID"]);
            }
        
        
        }
    } 
}

    
