using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


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
                string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";

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
            if (createGradeLevel.SelectedIndex == 0)
            {
                valGradeLevel.Visible = true;
                SetFocus(createGradeLevel);
                return;
            }
            if (AddAccount() == true)
            {
                Session["username"] = cAinputENumber.Text;
                Session["isLoggedIn"] = true;

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
                else
                {
                    Response.Redirect("itWorkeds.aspx");
                }
            }
            else
            {
                Response.Redirect("ERROR.aspx");
            }
        }
    }
}