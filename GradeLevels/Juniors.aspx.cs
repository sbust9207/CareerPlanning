using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareerPlanning.GradeLevels
{
    public partial class Junior : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddGradeLevel3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddGradeLevel3.SelectedIndex != 0)
            {
                    bool isLoggedIn = (bool)Session["isLoggedIn"];
                    if (isLoggedIn)
                    {
                        string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                        SqlConnection connection = new SqlConnection(strConnection);
                        connection.Open();

                        string SQL = "UPDATE dbo.Students SET CurrentGradeLevel = @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                        SqlCommand command = new SqlCommand(SQL, connection);
                        string eNumber = (string)Session["username"];
                        command.Parameters.AddWithValue("@selected", ddGradeLevel3.SelectedValue.ToString());
                        command.Parameters.AddWithValue("@eNumber", eNumber);

                        command.ExecuteNonQuery();


                        string gradeLevel = ddGradeLevel3.SelectedValue.ToString();
                        if (gradeLevel == "Fr")
                        {
                            Response.Redirect("freshmen.aspx");
                        }
                        else if (gradeLevel == "So")
                        {
                            Response.Redirect("sophomores.aspx");
                        }
                        else if (gradeLevel == "Jr")
                        {
                            Response.Redirect("Juniors.aspx");
                        }
                        else if (gradeLevel == "Sn")
                        {
                            Response.Redirect("Seniors.aspx");
                        }

                        command.Dispose();
                        connection.Close();

                    }
                    else
                    {
                        Response.Redirect("/LogOn.aspx");
                    }

            }
        }
    }
}