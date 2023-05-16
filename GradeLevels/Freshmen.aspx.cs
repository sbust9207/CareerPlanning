using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareerPlanning.GradeLevels
{
    public partial class Freshman : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    populateCheckBoxes();
                    PopulateAchievements((string)Session["username"]);
                }
                else
                {
                    Response.Redirect("/LogOn.aspx");
                }
            }
        }
        protected void populateCheckBoxes()
        {

            string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
            SqlConnection connection = new SqlConnection(strConnection);
            connection.Open();

            string SQL = "SELECT LinkedinCreated, HandshakeCreated, ResumeCreated, BusinessEtiquette FROM dbo.Students WHERE CAST(eNumber as VARCHAR) = @eNumber";
            SqlCommand command = new SqlCommand(SQL, connection);
            string eNumber = (string)Session["username"];
            command.Parameters.AddWithValue("@eNumber", eNumber);

            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                bool LinkedinCreated = reader.GetBoolean(0);
                bool HandshakeCreated = reader.GetBoolean(1);
                bool ResumeCreated = reader.GetBoolean(2);
                bool BusinessEtiquette = reader.GetBoolean(3);

                if (LinkedinCreated)
                {
                    cbFr2.Checked = true;
                }
                if (HandshakeCreated)
                {
                    cbFr1.Checked = true;
                }
                if (ResumeCreated)
                {
                    cbFr3.Checked = true;
                }
                if (BusinessEtiquette)
                {
                    cbFr4.Checked = true;
                }

                reader.Close();
                command.Dispose();
                connection.Close();
            }

        }

        protected void ddGradeLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddGradeLevel.SelectedIndex != 0)
            {
                if (Session["username"] != null)
                {

                    string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                    SqlConnection connection = new SqlConnection(strConnection);
                    connection.Open();

                    string SQL = "UPDATE dbo.Students SET CurrentGradeLevel = @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    string eNumber = (string)Session["username"];
                    command.Parameters.AddWithValue("@selected", ddGradeLevel.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@eNumber", eNumber);

                    command.ExecuteNonQuery();

                    string gradeLevel = ddGradeLevel.SelectedValue.ToString();
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

        protected void updateTaskCompleted(string task)
        {
            if (Session["username"] != null)
            {
                string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "UPDATE dbo.Students SET " + task + "= @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                string eNumber = (string)Session["username"];
                command.Parameters.AddWithValue("@selected", true);
                command.Parameters.AddWithValue("@eNumber", eNumber);

                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
            }
            else
            {
                Response.Redirect("/LogOn.aspx");
            }
        }

        protected void updateTaskNotCompleted(string task)
        {
            if (Session["username"] != null)
            {
                string strConnection = "Data source=sql.elmcsis.com;Initial catalog=CAREER_READINESS_DB;User ID=careers;Password=kpg7J2R9wHjR!;";
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "UPDATE dbo.Students SET " + task + "= @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                string eNumber = (string)Session["username"];
                command.Parameters.AddWithValue("@selected", false);
                command.Parameters.AddWithValue("@eNumber", eNumber);

                command.ExecuteNonQuery();

                command.Dispose();
                connection.Close();
            }
            else
            {
                Response.Redirect("/LogOn.aspx");
            }
        }

        protected void cbFr1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFr1.Checked)
            {
                updateTaskCompleted("HandshakeCreated");
            }
            else
            {
                updateTaskNotCompleted("HandshakeCreated");
            }
        }

        protected void cbFr2_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFr2.Checked)
            {
                updateTaskCompleted("LinkedinCreated");
            }
            else
            {
                updateTaskNotCompleted("LinkedinCreated");
            }
        }

        protected void cbFr3_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFr3.Checked)
            {
                updateTaskCompleted("ResumeCreated");
            }
            else
            {
                updateTaskNotCompleted("ResumeCreated");
            }
        }

        protected void cbFr4_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFr4.Checked)
            {
                updateTaskCompleted("BusinessEtiquette");
            }
            else
            {
                updateTaskNotCompleted("BusinessEtiquette");
            }
        }

        protected void PopulateAchievements(string eNumber)
        {
            // this function fills the achievement table with images of all achievements
            //  which are stored at the database and what level the current user has achieved
            string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection connectionObj = new SqlConnection(strConnection))
            {
                using (SqlDataAdapter sqlAdapterObj = new SqlDataAdapter("SELECT * FROM Achievements", connectionObj))
                {
                    DataTable dt = new DataTable();
                    sqlAdapterObj.Fill(dt);
                    lstAchievements.DataSource = dt;
                    lstAchievements.DataBind();
                }
            }
        }

        protected string FindAchievementLevel(string eNumber, string achieveName)
        {
            // this function determines whether student with parameterized eNumber has
            //  the required level to achieve the parameterized achieveName at no level,
            //  bronze level, silver, or gold level
            string strConnection = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; // note this reference
            if (achieveName == "LinkedinCreated")
            {
                // create query string
                //  this query extracts whether the student has created a linkedin account
                string SQL = "SELECT Students.LinkedinCreated FROM Students WHERE Students.eNumber = '" + eNumber + "';";

                SqlConnection objConnection = new SqlConnection(strConnection);

                // create a command object
                SqlCommand objCommand = new SqlCommand(SQL);

                // open database connection
                objCommand.Connection = objConnection;
                objCommand.Connection.Open();

                // create a data reader
                SqlDataReader objReader = objCommand.ExecuteReader();

                // string to be returned (default is locked)
                string returnVal = "";

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        if ((bool)objReader["LinkedinCreated"])
                        {
                            returnVal = "Gold";
                        }
                    }
                }
                else returnVal = "Error";

                // close connection
                objReader.Close();
                objConnection.Close();

                // remove connection objects
                objReader = null;
                objCommand = null;
                objConnection = null;

                return returnVal;
            }
            else
            {
                // create SQL query string
                //  this query extracts the level of progress for the current student and current achievement
                //  it also pulls the level required for bronze, silver, and gold for the achievement
                string SQL = "SELECT  Students.Lvl" + achieveName + " AS CurrLevel, Achievements.AchieveBronzeLevel AS BronzeLevel, Achievements.AchieveSilverLevel AS SilverLevel," +
                    " Achievements.AchieveGoldLevel AS GoldLevel FROM Achievements, Students " +
                    "WHERE Students.eNumber = '" + eNumber + "' AND Achievements.AchievementID = '" + achieveName + "'; ";

                // Response.Write("<p>" + SQL + "<p>");
                // SQL debugging write statement

                SqlConnection objConnection = new SqlConnection(strConnection);

                // create a command object
                SqlCommand objCommand = new SqlCommand(SQL);

                // open database connection
                objCommand.Connection = objConnection;
                objCommand.Connection.Open();

                // create a data reader
                SqlDataReader objReader = objCommand.ExecuteReader();

                // string to be returned
                string returnVal = "";

                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        // convert db vals to integers
                        int currLevel = Convert.ToInt32(objReader["CurrLevel"].ToString());
                        int bronzeLevel = Convert.ToInt32(objReader["BronzeLevel"].ToString());
                        int silverLevel = Convert.ToInt32(objReader["SilverLevel"].ToString());
                        int goldLevel = Convert.ToInt32(objReader["GoldLevel"].ToString());

                        // determine applicable level
                        if (currLevel < bronzeLevel) returnVal = ""; // indicates locked
                        else if (currLevel < silverLevel) returnVal = "Bronze"; // indicates Bronze
                        else if (currLevel < goldLevel) returnVal = "Silver"; // indicates Silver
                        else returnVal = "Gold"; // indicates Gold
                    }
                }
                else returnVal = "Error";

                // close connection
                objReader.Close();
                objConnection.Close();

                // remove connection objects
                objReader = null;
                objCommand = null;
                objConnection = null;

                return returnVal;
            }
        }

        protected void lstAchievements_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            // this function binds the data fields from the DB to the fields on the page
            //  it is needed specifically so the images can be converted from bitmaps to .pngs
            string stdntENumber = (string)Session["username"];

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                // create view of the current row (achievement) in DB
                DataRowView dbCurrRow = (DataRowView)e.Item.DataItem;

                string levelToDisplay = FindAchievementLevel(stdntENumber, (string)dbCurrRow["AchievementID"]); // needs session variable value
                if (levelToDisplay == "Error") // an error was encountered
                {
                    e.Item.FindControl("medalToDisplay").Visible = false;
                }
                else if (levelToDisplay == "") // achievement is locked
                {
                    // create image url string from database byte values
                    string imageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])dbCurrRow["AchieveImageBronze"]);

                    // add gray overlay
                    e.Item.FindControl("achieveLockedOverlay").Visible = true;

                    // update HTML to have new image link URL
                    (e.Item.FindControl("achievementLink") as HyperLink).NavigateUrl = "AchievementInfo.aspx?AchievementID=" + (string)dbCurrRow["AchievementID"];
                    (e.Item.FindControl("medalToDisplay") as Image).ImageUrl = imageUrl;
                }
                else
                {
                    // create image url string from database byte values
                    string imageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])dbCurrRow["AchieveImage" + levelToDisplay]);

                    // update HTML to have new image link URL
                    (e.Item.FindControl("achievementLink") as HyperLink).NavigateUrl = "AchievementInfo.aspx?AchievementID=" + (string)dbCurrRow["AchievementID"];
                    (e.Item.FindControl("medalToDisplay") as Image).ImageUrl = imageUrl;
                }
            }
        }

        protected void lstAchievements_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            // this function handles the changing of pages in the achievement view
            (lstAchievements.FindControl("pgrAchievements") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            this.PopulateAchievements((string)Session["username"]);
        }

    }

}
