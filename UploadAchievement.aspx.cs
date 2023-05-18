using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CareerPlanning
{
    public partial class UploadAchievement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // declare byte arrays for each image
            byte[] bronzeImage;
            byte[] silverImage;
            byte[] goldImage;

            // read all images
            using (BinaryReader br = new BinaryReader(bronzeFile.PostedFile.InputStream))
            {
                bronzeImage = br.ReadBytes(bronzeFile.PostedFile.ContentLength);
            }
            using (BinaryReader br = new BinaryReader(silverFile.PostedFile.InputStream))
            {
                silverImage = br.ReadBytes(silverFile.PostedFile.ContentLength);
            }
            using (BinaryReader br = new BinaryReader(goldFile.PostedFile.InputStream))
            {
                goldImage = br.ReadBytes(goldFile.PostedFile.ContentLength);
            }

            // create connection to database
            string strConnection = ConfigurationManager.AppSettings["ConnectionString"];
            using (SqlConnection conn = new SqlConnection(strConnection))
            {
                string SQL = "INSERT INTO Achievements VALUES (@AchievementID, @AchieveDescription, @AchieveBronzeLevel, @AchieveSilverLevel, @AchieveGoldLevel, @AchieveImageBronze, @AchieveImageSilver, @AchieveImageGold)";
                using (SqlCommand cmd = new SqlCommand(SQL, conn))
                {
                    cmd.Parameters.AddWithValue("@AchievementID", txtAchievementName.Text);
                    cmd.Parameters.AddWithValue("@AchieveDescription", txtAchievementDescription.Text);
                    cmd.Parameters.AddWithValue("@AchieveBronzeLevel", txtBronzeLevel.Text);
                    cmd.Parameters.AddWithValue("@AchieveSilverLevel", txtSilverLevel.Text);
                    cmd.Parameters.AddWithValue("@AchieveGoldLevel", txtGoldLevel.Text);
                    cmd.Parameters.AddWithValue("@AchieveImageBronze", bronzeImage);
                    cmd.Parameters.AddWithValue("@AchieveImageSilver", silverImage);
                    cmd.Parameters.AddWithValue("@AchieveImageGold", goldImage);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}