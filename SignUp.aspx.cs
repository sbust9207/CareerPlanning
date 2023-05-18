using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace CareerPlanning
{
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            valGradeLevel.Visible = false;
        }

        private bool AddAccount()
        {
            try
            {
                //Connects to the database to add student information into a new record
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];

                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "INSERT INTO dbo.Students (StudentGUID, eNumber, Password, CurrentGradeLevel, DateCreated) VALUES (@StudentGUID, @eNumber, @Password, @CurrentGradeLevel, @DateCreated)";
                SqlCommand command = new SqlCommand(SQL, connection);

                command.Parameters.AddWithValue("StudentGUID", Guid.NewGuid().ToString());
                command.Parameters.AddWithValue("eNumber", cAinputENumber.Text);
                command.Parameters.AddWithValue("Password", cAPassword.Text);
                command.Parameters.AddWithValue("CurrentGradeLevel", createGradeLevel.SelectedValue);
                command.Parameters.AddWithValue("DateCreated", DateTime.Now.ToString());

                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            //Checks if all input fields are validated 
            if (IsValid)
            {
                // validates that drop down list has a selection
                if (createGradeLevel.SelectedIndex == 0)
                {
                    // if no selection is made, an error label is made visible and the page focuses on the drop down list
                    valGradeLevel.Visible = true;
                    SetFocus(createGradeLevel);
                    return;
                }
                // if all fields are valid
                if (AddAccount() == true)
                {
                    // session variable to store eNumber across different pages
                    Session["username"] = cAinputENumber.Text;

                    // redirects to the student dashboard according to the grade selected 
                    if (createGradeLevel.SelectedValue == "Fr")
                    {
                        Response.Redirect("gradelevels/freshmen.aspx");
                    }
                    else if (createGradeLevel.SelectedValue == "So")
                    {
                        Response.Redirect("gradelevels/sophomores.aspx");
                    }
                    else if (createGradeLevel.SelectedValue == "Jr")
                    {
                        Response.Redirect("gradelevels/Juniors.aspx");
                    }
                    else if (createGradeLevel.SelectedValue == "Sn")
                    {
                        Response.Redirect("gradelevels/Seniors.aspx");
                    }
                }
                else
                {
                    // error collection
                    Response.Redirect("SignUp.aspx");
                }
            }
        }
    }
}