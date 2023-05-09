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

                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void createGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (AddAccount() == true)
            {
                Response.Redirect("itWorked.aspx");
            }
            else
            {
                Response.Redirect("ERROR.aspx");
            }
        }
    }
}