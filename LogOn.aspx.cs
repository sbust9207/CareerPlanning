using System;
using System.Collections.Generic;
using System.Configuration;
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
                // connects to database
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "SELECT CurrentGradeLevel FROM dbo.Students WHERE CAST(eNumber as VARCHAR) = @inputENumber AND Password = @signInPass";
                SqlCommand command = new SqlCommand(SQL, connection);
                command.Parameters.AddWithValue("@inputENumber", inputENumber.Text);
                command.Parameters.AddWithValue("@signInPass", signInPass.Text);
                SqlDataReader reader = command.ExecuteReader();

                // checks if entered eNumber and password are in the database in the same record
                if (reader.Read())
                {
                    // gets the grade level of the student if there is a record of them in the database
                    string gradeLevel = reader.GetString(0);
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    return gradeLevel;
                }
                else
                {
                    // returns error if no record of the student is found 
                    reader.Close();
                    command.Dispose();
                    connection.Close();
                    return "Error";
                }


            }
            catch
            {
                return "Error";
            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            // ensures all input fields are valid 
            if (IsValid)
            {
                string gradeLevel = AttemptLogIn();
                // if the password and username match
                if (gradeLevel != "Error")
                {
                    // session variable created to carry eNumber across pages 
                    this.Session["username"] = inputENumber.Text;

                    // redirects to the grade level recorded in the database
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
                    // if the record is not found, invalid log in label displayed 
                    lbInvalidLogIn.Visible = true;
                    SetFocus(inputENumber);
                }
            }

        }
    }
}