using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareerPlanning.GradeLevels
{
    public partial class sophomore : System.Web.UI.Page
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
        protected string getENum()
        {
            if (Session["username"] != null)
            {
                // ensures student is logged in before retrieving the session variable 
                string studentENumber = (string)Session["username"];
                return studentENumber;
            }
            else
            {
                Response.Redirect("/LogOn.aspx");
            }
            return "Error";
        }

        protected void populateCheckBoxes()
        {
            if (Session["username"] != null)
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                // retieves task data from the database 
                string SQL = "SELECT JobShadowing, ElevatorPitch, BrandStatement, ExcelTips FROM dbo.Students WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                string eNumber = getENum();
                command.Parameters.AddWithValue("@eNumber", eNumber);

                SqlDataReader reader = command.ExecuteReader();

                //checks check box if student has checked it previously 
                if (reader.Read())
                {
                    bool JobShadowing = reader.GetBoolean(0);
                    bool ElevatorPitch = reader.GetBoolean(1);
                    bool BrandStatement = reader.GetBoolean(2);
                    bool ExcelTips = reader.GetBoolean(3);

                    if (JobShadowing)
                    {
                        cbSo1.Checked = true;
                    }
                    if (ElevatorPitch)
                    {
                        cbSo2.Checked = true;
                    }
                    if (BrandStatement)
                    {
                        cbSo3.Checked = true;
                    }
                    if (ExcelTips)
                    {
                        cbSo4.Checked = true;
                    }

                    reader.Close();
                    command.Dispose();
                    connection.Close();
                }
            }
            else
            {
                Response.Redirect("/LogOn.aspx");
            }
        }

        //updates database if student checks a check box 
        protected void updateTaskCompleted(string task)
        {
            if (Session["username"] != null)
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "UPDATE dbo.Students SET " + task + "= @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                string eNumber = getENum();
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

        //updates database if student unchecks a check box 
        protected void updateTaskNotCompleted(string task)
        {
            if (Session["username"] != null)
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                SqlConnection connection = new SqlConnection(strConnection);
                connection.Open();

                string SQL = "UPDATE dbo.Students SET " + task + "= @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                SqlCommand command = new SqlCommand(SQL, connection);
                string eNumber = getENum();
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

        protected void ddGradeLevel2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // ensures selected grade level is a valid grade level 
            if (ddGradeLevel2.SelectedIndex != 0)
            {
                if (Session["username"] != null)
                {

                    string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                    SqlConnection connection = new SqlConnection(strConnection);
                    connection.Open();

                    string SQL = "UPDATE dbo.Students SET CurrentGradeLevel = @selected WHERE CAST(eNumber as VARCHAR) = @eNumber";
                    SqlCommand command = new SqlCommand(SQL, connection);
                    string eNumber = getENum();
                    command.Parameters.AddWithValue("@selected", ddGradeLevel2.SelectedValue.ToString());
                    command.Parameters.AddWithValue("@eNumber", eNumber);

                    command.ExecuteNonQuery();


                    // redirects to the new grade level dashboard 
                    string gradeLevel = ddGradeLevel2.SelectedValue.ToString();
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

        protected void cbSo1_CheckedChanged(object sender, EventArgs e)
        {
            string studentENumber = getENum();
            if (cbSo1.Checked)
            {
                updateTaskCompleted("JobShadowing");
                // used for back-end record keeping 
                AddUpdateTaskComplete("JobShadowing", studentENumber);
                // awards points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) + 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) + 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) + 2));
            }
            else
            {
                updateTaskNotCompleted("JobShadowing");
                // removes points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) - 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) - 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) - 2));
            }
        }

        protected void cbSo2_CheckedChanged(object sender, EventArgs e)
        {
            string studentENumber = getENum();
            if (cbSo2.Checked)
            {
                updateTaskCompleted("ElevatorPitch");
                // used for back-end record keeping 
                AddUpdateTaskComplete("ElevatorPitch", studentENumber);
                // awards points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) + 1));
                ChangeSkillLevel("Communication", studentENumber, (GetCurrentSkillLevel("Communication", studentENumber) + 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) + 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) + 3));
            }
            else
            {
                updateTaskNotCompleted("ElevatorPitch");
                // removes points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) - 1));
                ChangeSkillLevel("Communication", studentENumber, (GetCurrentSkillLevel("Communication", studentENumber) - 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) - 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) - 3));
            }
        }

        protected void cbSo3_CheckedChanged(object sender, EventArgs e)
        {
            string studentENumber = getENum();
            if (cbSo3.Checked)
            {
                updateTaskCompleted("BrandStatement");
                // used for back-end record keeping 
                AddUpdateTaskComplete("BrandStatement", studentENumber);
                // awards points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) + 1));
                ChangeSkillLevel("Communication", studentENumber, (GetCurrentSkillLevel("Communication", studentENumber) + 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) + 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) + 2));
            }
            else
            {
                updateTaskNotCompleted("BrandStatement");
                // removes points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) - 1));
                ChangeSkillLevel("Communication", studentENumber, (GetCurrentSkillLevel("Communication", studentENumber) - 1));
                ChangeSkillLevel("CriticalThinking", studentENumber, (GetCurrentSkillLevel("CriticalThinking", studentENumber) - 1));
                ChangeSkillLevel("Leadership", studentENumber, (GetCurrentSkillLevel("Leadership", studentENumber) - 2));
            }
        }

        protected void cbSo4_CheckedChanged(object sender, EventArgs e)
        {
            string studentENumber = getENum();
            if (cbSo4.Checked)
            {
                updateTaskCompleted("ExcelTips");
                // used for back-end record keeping 
                AddUpdateTaskComplete("ExcelTips", studentENumber);
                // awards points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) + 1));
                ChangeSkillLevel("Technology", studentENumber, (GetCurrentSkillLevel("Technology", studentENumber) + 2));
            }
            else
            {
                updateTaskNotCompleted("ExcelTips");
                // removes points based on task completed toward achievements
                ChangeSkillLevel("SelfDevelopment", studentENumber, (GetCurrentSkillLevel("SelfDevelopment", studentENumber) - 1));
                ChangeSkillLevel("Technology", studentENumber, (GetCurrentSkillLevel("Technology", studentENumber) - 2));
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

        //used for back-end record keeping, records each acheivement earned by each student 
        protected bool AddUpdateAchievement(string achieveID, string stdntENumber)
        {
            try
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();

                    string SQL = "SELECT COUNT(*) FROM StudentAchievementsObtained WHERE eNumber = @eNumber AND AchievementID = @AchievementID";

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("eNumber", stdntENumber);
                        command.Parameters.AddWithValue("AchievementID", achieveID);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // record already present, updates time completed 
                            SQL = "UPDATE StudentAchievementsCompleted SET CompletedOnDate = @CompletedOnDate WHERE eNumber = @eNumber AND AchievementID = @AchievementID";
                        }
                        else
                        {
                            // new record added 
                            SQL = "INSERT INTO StudentAchievementsObtained (eNumber, AchievementID, CompletedOnDate) VALUES (@eNumber, @AchievementID, @CompletedOnDate)";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(SQL, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@eNumber", stdntENumber);
                            updateCommand.Parameters.AddWithValue("@AchievementID", achieveID);
                            updateCommand.Parameters.AddWithValue("@CompletedOnDate", DateTime.Now);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        //used for back-end record keeping 
        protected bool AddUpdateTaskComplete(string taskID, string stdntENumber)
        {
            try
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                using (SqlConnection connection = new SqlConnection(strConnection))
                {
                    connection.Open();

                    string SQL = "SELECT COUNT(*) FROM StudentTasksCompleted WHERE eNumber = @eNumber AND TaskID = @TaskID";

                    using (SqlCommand command = new SqlCommand(SQL, connection))
                    {
                        command.Parameters.AddWithValue("eNumber", stdntENumber);
                        command.Parameters.AddWithValue("TaskID", taskID);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            // record already present, updates time completed 
                            SQL = "UPDATE StudentTasksCompleted SET CompletedOnDate = @CompletedOnDate WHERE eNumber = @eNumber AND TaskID = @TaskID";
                        }
                        else
                        {
                            // new record added 
                            SQL = "INSERT INTO StudentTasksCompleted (eNumber, TaskID, CompletedOnDate) VALUES (@eNumber, @TaskID, @CompletedOnDate)";
                        }

                        using (SqlCommand updateCommand = new SqlCommand(SQL, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@eNumber", stdntENumber);
                            updateCommand.Parameters.AddWithValue("@TaskID", taskID);
                            updateCommand.Parameters.AddWithValue("@CompletedOnDate", DateTime.Now);

                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // returns the points currently awarded toward an achievement 
        protected int GetCurrentSkillLevel(string skillID, string stdntENumber)
        {
            string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
            string currLevelString = "";
            int currLevel = 0;
            // linkedInCreated can only earn one point, checked separately
            if (skillID == "LinkedinCreated")
            {
                string SQL = "SELECT LinkedInCreated FROM Students WHERE eNumber = '" + stdntENumber + "'";
                SqlConnection objConnection = new SqlConnection(strConnection);
                SqlCommand objCommand = new SqlCommand(SQL);
                objCommand.Connection = objConnection;
                objCommand.Connection.Open();


                SqlDataReader objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        currLevelString = objReader["LinkedinCreated"].ToString();
                    }
                }
                objReader.Close();
                objConnection.Close();

                objReader = null;
                objCommand = null;
                objConnection = null;
                if (currLevelString == "False")
                {
                    return 0;
                }
                else return 1;
            }
            else
            {
                //other acheivements handeled here
                string SQL = "SELECT Lvl" + skillID + " FROM Students WHERE eNumber = '" + stdntENumber + "'";
                SqlConnection objConnection = new SqlConnection(strConnection);
                SqlCommand objCommand = new SqlCommand(SQL);
                objCommand.Connection = objConnection;
                objCommand.Connection.Open();


                SqlDataReader objReader = objCommand.ExecuteReader();
                if (objReader.HasRows)
                {
                    while (objReader.Read())
                    {
                        currLevelString = objReader["Lvl" + skillID].ToString();
                    }
                }
                objReader.Close();
                objConnection.Close();

                objReader = null;
                objCommand = null;
                objConnection = null;

                currLevel = int.Parse(currLevelString);
                return currLevel;
            }
        }

        //updates skill level depending on points earned 
        protected bool ChangeSkillLevel(string skillID, string stdntENumber, int newLevel)
        {
            try
            {
                string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
                // linkedIn is simply 1 or 0, handled separately 
                if (skillID == "LinkedinCreated")
                {
                    string SQL = "UPDATE Students SET LinkedinCreated = @LinkedinCreated WHERE eNumber = @stdntENumber";
                    using (SqlConnection connection = new SqlConnection(strConnection))
                    {
                        SqlCommand cmdUpdate = new SqlCommand(SQL, connection);

                        if (newLevel != 0)
                        {
                            cmdUpdate.Parameters.AddWithValue("@LinkedinCreated", true);
                        }
                        else cmdUpdate.Parameters.AddWithValue("@LinkedinCreated", false);

                        cmdUpdate.Parameters.AddWithValue("@stdntENumber", stdntENumber);

                        connection.Open();
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                else
                {
                    // otherwise new points awarded based on input 
                    string SQL = "UPDATE Students SET Lvl" + skillID + " = @" + skillID + " WHERE eNumber = @stdntENumber";
                    using (SqlConnection connection = new SqlConnection(strConnection))
                    {
                        SqlCommand cmdUpdate = new SqlCommand(SQL, connection);

                        cmdUpdate.Parameters.AddWithValue("@" + skillID, Convert.ToInt32(newLevel));
                        cmdUpdate.Parameters.AddWithValue("@stdntENumber", stdntENumber);

                        connection.Open();
                        cmdUpdate.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch
            {
                return false;
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

                string levelToDisplay = FindAchievementLevel(stdntENumber, (string)dbCurrRow["AchievementID"]);
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
            this.PopulateAchievements(getENum());
        }

    }
}