using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RAWGAPI;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private APIResponse<APIGameResult> apiResponse = new APIGames("1d28751350144a4e835b8e6a355f9113").GetAPIResponse(new Tuple<string, string>("page", "3"));

        public Form1()
        {
            InitializeComponent();
            AddGames();
        }

        private void AddGames()
        {
            //comboBox1.Items.AddRange(apiResponse.GameResults.Select(g => g.Name));
            foreach (APIGameResult game in apiResponse.GameResults)
            {
                comboBox1.Items.Add(game.Name);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBackgroundImage();
            PopulateRatingsTextBox();
        }

        private void UpdateBackgroundImage()
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] dataArr = webClient.DownloadData(apiResponse.GameResults[comboBox1.SelectedIndex].Background_Image);
                File.WriteAllBytes(CleanString($"{apiResponse.GameResults[comboBox1.SelectedIndex].Name}BackgroundImage.png"), dataArr);
            }

            pictureBox1.ImageLocation = CleanString($"{apiResponse.GameResults[comboBox1.SelectedIndex].Name}BackgroundImage.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void PopulateRatingsTextBox()
        {
            ratings.Clear();
            foreach (APIGameResult game in apiResponse.GameResults)
            {
                List<APIGameRating> gameRatings = game.GameRatings;
                foreach (APIGameRating gameRating in gameRatings)
                {
                    ratings.Text += $"Critics are saying: {gameRating.Title} with an score of {gameRating.Percent}{Environment.NewLine}";
                }
                ratings.Text += Environment.NewLine;
            }
        }

        private string CleanString(string input)
        {
            foreach (char invalidChar in Path.GetInvalidFileNameChars())
            {
                input = input.Replace(invalidChar, '_');
            }

            return input;
        }
    }
}
