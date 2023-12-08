using Microsoft.Ajax.Utilities;
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
    public partial class ReportDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ReportID = Request.QueryString["ID"];
            if(ReportID != null)
            {
                Session["ReportID"] = ReportID;
            }
            else
            {
                CreateReport();
            }
            ShowObservations();
        }
        
        protected void ShowObservations()
        {
            if(User.Identity.IsAuthenticated)
            {
                DataTable dt = new DataTable(); 
                string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
                int ReportID = int.Parse(Session["ReportID"].ToString());
                string query = "spViewAllObservations @ReportID";
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = connString;
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query,conn))
                    {
                        cmd.Parameters.AddWithValue("@ReportID", ReportID);
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);

                        }
                    }
                }
                ObservationTable.DataSource = dt;
                ObservationTable.DataBind();
                ObservationTablePanel.Visible = true;
                

            }
            else
            {
                Response.Redirect("Login.aspx");
            }


        }
        


        private void CreateReport()
        {
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string userID = HttpContext.Current.User.Identity.GetUserId();
            string ProjectID = Session["ProjectID"] as string;
            if (ProjectID != null & userID != null)
            {


                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("spCreateNewReport", conn))
                    {

                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
                        cmd.Parameters.AddWithValue("@VolunteerID", userID);
                        cmd.Parameters.Add("@ReportID", SqlDbType.Int);

                        cmd.Parameters["@ReportID"].Direction = ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        Session["ReportID"]  = int.Parse(cmd.Parameters["@ReportID"].Value.ToString());

                    }


                }


            
            }



            else
            {

                errorMsgPan.Visible = true;

            }        
        }
    
    }


}