﻿   
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
    public partial class ResearchAreas : System.Web.UI.Page
    {
        public DataTable GetDataFromDataBase()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ToString();
            string idValue = Request.QueryString["InstID"];


            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "EXEC spGetResearchAreasbyInstitution @InstitutionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InstitutionID", idValue);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            // If an institutionID is given, the first cmd is ran and only values that match the institutionID are shown. If none is given, the second cmd is ran and all researchareas are shown.


            return dt;
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string InstitutionID = Request.QueryString["InstID"];
                if (string.IsNullOrEmpty(InstitutionID))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {


                    ResearchAreasPage.DataSource = GetDataFromDataBase();
                    ResearchAreasPage.DataBind();
                }
            }
        }
    }// If instid is not given, then the select* from researchareas is ran and if it is given, the getresearchbyinstitutions stored proceudre is ran.
}