using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Davis_Justin_CitizenScience_Project
{
    public partial class ObservationManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {
                
                LoadObservations();
            }
        }

        public void LoadObservations()
        {

            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString(); 

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "EXEC spGetAllfromObservations"; //basic sql command that will return all observations
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    
                    
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        
                        da.Fill(dt);

                        
                    }
                }
            }
            ObservationRepeater.DataSource = dt;
            ObservationRepeater.DataBind();
        }
            
        

       
    }
}