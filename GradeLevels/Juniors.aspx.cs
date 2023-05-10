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
                string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "UPDATE dbo.Students SET CurrentGradeLevel = @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@selected", ddGradeLevel3.SelectedValue.ToString());
                command.Parameters.AddWithValue("@eNumber", (string)Session["username"]);

                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();

                string gradeLevel = (string)Session["username"];
                if (gradeLevel == "Fr")
                {
                    Response.Redirect("gradelevels/freshmen.aspx");
                }
                else if (gradeLevel == "So")
                {
                    Response.Redirect("gradelevels/sophomores.aspx");
                }
                else if (gradeLevel == "Jr")
                {
                    Response.Redirect("gradelevels/Juniors.aspx");
                }
                else if (gradeLevel == "Sn")
                {
                    Response.Redirect("gradelevels/Seniors.aspx");
                }

            }
        }
    }
}