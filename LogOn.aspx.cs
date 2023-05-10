using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareerPlanning
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            lbInvalidLogIn.Visible = false;
        }

        string AttemptLogIn()
        {
            try
            {
                string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "SELECT CurrentGradeLevel FROM dbo.Students WHERE CAST(eNumber as VARCHAR) = @inputENumber AND Password = @signInPass";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@inputENumber", inputENumber.Text);
                command.Parameters.AddWithValue("@signInPass", signInPass.Text);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string gradeLevel = reader.GetString(0);
                    return gradeLevel;
                }
                else
                {
                    return "Error";
                }

                reader.Close();
                command.Dispose();
                connection.Close();
            }
            catch
            {
                return "Error";
            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            string gradeLevel = AttemptLogIn();
            if (gradeLevel != "Error")
            {
                Session["username"] = inputENumber.Text;
                Session["isLoggedIn"] = true;

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
                else
                {
                    Response.Redirect("ERROR.aspx");
                }
            }
            else
            {
                lbInvalidLogIn.Visible = true;
                SetFocus(inputENumber);
            }

        }

        protected void ddGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}