using SemiFinalGame.FileHandling;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SemiFinalGame
{
    public partial class MenuForm : Form
    {
        private Label lblLastScore;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Click Sound
            SemiFinalGame.Sound.SoundManager.PlaySoundEffect(Properties.Resources.computer_mouse_click_02_383961__1_);

            // Stop menu music
            SemiFinalGame.Sound.SoundManager.StopMusic();

            // Hide menu
            this.Hide();

            // Show Game Form (Start Level 1)
            using (var gameForm = new GameForm(1))
            {
                gameForm.ShowDialog();
            }

            // Show menu again when game closes
            this.Show();
            
            // Restart menu music
            SemiFinalGame.Sound.SoundManager.PlayMusic(Properties.Resources.MenuFormsound);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Click Sound - though app might exit too fast to hear it perfectly, it's good practice
            SemiFinalGame.Sound.SoundManager.PlaySoundEffect(Properties.Resources.computer_mouse_click_02_383961__1_);
            Application.Exit();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

             // Make full screen like game
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            
            // Play Menu Music
            SemiFinalGame.Sound.SoundManager.PlayMusic(Properties.Resources.MenuFormsound);

            // --- CREATE LABEL ---
            lblLastScore = new Label();
            lblLastScore.AutoSize = true;
            lblLastScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblLastScore.ForeColor = Color.White;
            lblLastScore.BackColor = Color.Transparent;
            lblLastScore.Location = new Point(20, 20); // Top-left corner
            this.Controls.Add(lblLastScore);
            // --- LOAD DATA ---
            // Load the history list
            System.Collections.Generic.List<string> history = SaveData.LoadHistory();

            if (history.Count > 0)
            {
                // Get the last item in the list
                string lastRun = history[history.Count - 1];
                lblLastScore.Text = "Last: " + lastRun;
            }
            else
            {
                lblLastScore.Text = "No games played yet.";
            }
        }
    }
    }

