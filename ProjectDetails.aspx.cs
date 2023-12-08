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
                string projectID = Request.QueryString["ID"];
                if (string.IsNullOrEmpty(projectID))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    Session["ProjectID"] = projectID;
                    LoadProjectDetails(projectID);
                }
            }
            



        }
        private void LoadProjectDetails(string projectID)
        {
            string connStr = ConfigurationManager.ConnectionStrings["SportsStoreDB"].ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM ProjectDetails WHERE ProjectID = @ProjectID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ProjectID", projectID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblName.Text = reader["Name"].ToString();
                }
                reader.Close();
            }
        }

        //Runs a query that pulls the proper projectid that correlates to the projectid selected from the RA page and then displays all the information in the project table that correlates to said projectid
    }

}