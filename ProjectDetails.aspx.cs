using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Davis_Justin_CitizenScience_Project
{
    public partial class ProjectDetails : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string projectID = Request.QueryString["ProjectID"];
                if (string.IsNullOrEmpty(projectID))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    LoadProjectDetails(projectID);
                }
            }
            



        }
        private void LoadProjectDetails(string projectID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Projects WHERE ProjectID = @ProjectID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = reader["ProjectName"].ToString();
                    lblProjectID.Text = reader["ProjectID"].ToString();
                    lblDescription.Text = reader["Description"].ToString();
                    lblStartDate.Text = reader["StartDate"].ToString();
                    lblEndDate.Text = reader["EndDate"].ToString();
                    lblCoordinator.Text = reader["Coordinator"].ToString();
                    lblResearchID.Text = reader["ResearchID"].ToString();
                }
                reader.Close();
            }
        }


    }

}