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
    public partial class Institutions : System.Web.UI.Page
    {
        
        public DataTable GetDataFromDataBase()
        {
            DataTable dt = new DataTable();
            string connString = ConfigurationManager.ConnectionStrings["CitizenScienceDB"].ConnectionString;
            string idvalue = Request.QueryString["InstitutionID"]; 
            using (SqlConnection conn = new SqlConnection(connString))
            {
                //Opens a connection to the database and executes stored proecudre spGetAllInstitutions
                conn.Open();
                string query = "EXEC spGetAllInstitutions  @InstID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@InstID", idvalue);
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }


            return (dt);


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Institution.DataSource = GetDataFromDataBase();
                Institution.DataBind();
            }
            



        }
    }
}