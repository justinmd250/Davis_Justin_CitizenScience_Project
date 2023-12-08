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
    public partial class Projects : System.Web.UI.Page
    {
        public DataTable GetDataFromDataBase()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string idValue = Request.QueryString["RA"];
            //Sets the RA idvalue that will be used later in an aspx to match the researchID to the project that corresponds
            if (!string.IsNullOrEmpty(idValue))
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "EXEC spGetProjectsbyResearchAreas @RA";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@RA", idValue);
                        cmd.ExecuteNonQuery();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }

                //Executes the stored procedure and adds values to the datatable where the RA matches the researchid
            }
            return dt;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ResearchAreasID = Request.QueryString["RA"];
                if (string.IsNullOrEmpty(ResearchAreasID))
                {
                    Response.Redirect("ResearchAreas.aspx");
                }
                else
                {
                    Project.DataSource = GetDataFromDataBase();
                    Project.DataBind();
                }
            }
        }

        //IF not researchid is given, it redirects to the base researchareas page and if one is given it spits out the proper projectname for the data.

    }
}