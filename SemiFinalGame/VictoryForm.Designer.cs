namespace SemiFinalGame
{
    partial class VictoryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnPlayAgain = new Button();
            btnExit = new Button();
            lblScore = new Label();
            lblCoins = new Label();
            lblLives = new Label();
            lblScoreTitle = new Label();
            lblCoinsTitle = new Label();
            lblLivesTitle = new Label();
            btnLevel2 = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // btnPlayAgain
            // 
            btnPlayAgain.BackColor = Color.ForestGreen;
            btnPlayAgain.FlatAppearance.BorderSize = 0;
            btnPlayAgain.FlatStyle = FlatStyle.Flat;
            btnPlayAgain.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnPlayAgain.ForeColor = Color.White;
            btnPlayAgain.Location = new Point(273, 673);
            btnPlayAgain.Margin = new Padding(5, 6, 5, 6);
            btnPlayAgain.Name = "btnPlayAgain";
            btnPlayAgain.Size = new Size(267, 115);
            btnPlayAgain.TabIndex = 1;
            btnPlayAgain.Text = "Play Again";
            btnPlayAgain.UseVisualStyleBackColor = false;
            btnPlayAgain.Click += btnPlayAgain_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.Crimson;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(627, 673);
            btnExit.Margin = new Padding(5, 6, 5, 6);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(267, 115);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.BackColor = Color.Transparent;
            lblScore.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblScore.ForeColor = Color.White;
            lblScore.Location = new Point(667, 385);
            lblScore.Margin = new Padding(5, 0, 5, 0);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(42, 46);
            lblScore.TabIndex = 3;
            lblScore.Text = "0";
            // 
            // lblCoins
            // 
            lblCoins.AutoSize = true;
            lblCoins.BackColor = Color.Transparent;
            lblCoins.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblCoins.ForeColor = Color.White;
            lblCoins.Location = new Point(667, 481);
            lblCoins.Margin = new Padding(5, 0, 5, 0);
            lblCoins.Name = "lblCoins";
            lblCoins.Size = new Size(42, 46);
            lblCoins.TabIndex = 4;
            lblCoins.Text = "0";
            // 
            // lblLives
            // 
            lblLives.AutoSize = true;
            lblLives.BackColor = Color.Transparent;
            lblLives.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblLives.ForeColor = Color.White;
            lblLives.Location = new Point(667, 577);
            lblLives.Margin = new Padding(5, 0, 5, 0);
            lblLives.Name = "lblLives";
            lblLives.Size = new Size(42, 46);
            lblLives.TabIndex = 5;
            lblLives.Text = "0";
            // 
            // lblScoreTitle
            // 
            lblScoreTitle.AutoSize = true;
            lblScoreTitle.BackColor = Color.Transparent;
            lblScoreTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblScoreTitle.ForeColor = Color.White;
            lblScoreTitle.Location = new Point(333, 385);
            lblScoreTitle.Margin = new Padding(5, 0, 5, 0);
            lblScoreTitle.Name = "lblScoreTitle";
            lblScoreTitle.Size = new Size(312, 46);
            lblScoreTitle.TabIndex = 6;
            lblScoreTitle.Text = "FINAL SCORE :";
            // 
            // lblCoinsTitle
            // 
            lblCoinsTitle.AutoSize = true;
            lblCoinsTitle.BackColor = Color.Transparent;
            lblCoinsTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblCoinsTitle.ForeColor = Color.White;
            lblCoinsTitle.Location = new Point(333, 481);
            lblCoinsTitle.Margin = new Padding(5, 0, 5, 0);
            lblCoinsTitle.Name = "lblCoinsTitle";
            lblCoinsTitle.Size = new Size(426, 46);
            lblCoinsTitle.TabIndex = 7;
            lblCoinsTitle.Text = "COINS COLLECTED :";
            // 
            // lblLivesTitle
            // 
            lblLivesTitle.AutoSize = true;
            lblLivesTitle.BackColor = Color.Transparent;
            lblLivesTitle.Font = new Font("Arial", 20F, FontStyle.Bold);
            lblLivesTitle.ForeColor = Color.White;
            lblLivesTitle.Location = new Point(333, 577);
            lblLivesTitle.Margin = new Padding(5, 0, 5, 0);
            lblLivesTitle.Name = "lblLivesTitle";
            lblLivesTitle.Size = new Size(396, 46);
            lblLivesTitle.TabIndex = 8;
            lblLivesTitle.Text = "LIVES REMAINING :";
            // 
            // btnLevel2
            // 
            btnLevel2.BackColor = Color.DarkOrange;
            btnLevel2.FlatAppearance.BorderSize = 0;
            btnLevel2.FlatStyle = FlatStyle.Flat;
            btnLevel2.Font = new Font("Arial", 16F, FontStyle.Bold);
            btnLevel2.ForeColor = Color.White;
            btnLevel2.Location = new Point(904, 673);
            btnLevel2.Margin = new Padding(5, 6, 5, 6);
            btnLevel2.Name = "btnLevel2";
            btnLevel2.Size = new Size(267, 115);
            btnLevel2.TabIndex = 9;
            btnLevel2.Text = "Level 2";
            btnLevel2.UseVisualStyleBackColor = false;
            btnLevel2.Visible = false;
            btnLevel2.Click += btnLevel2_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblMessage.ForeColor = Color.Yellow;
            lblMessage.Location = new Point(333, 192);
            lblMessage.Margin = new Padding(5, 0, 5, 0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(0, 56);
            lblMessage.TabIndex = 10;
            lblMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblMessage.Visible = false;
            // 
            // VictoryForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Victory2;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1333, 865);
            Controls.Add(lblLivesTitle);
            Controls.Add(lblCoinsTitle);
            Controls.Add(lblScoreTitle);
            Controls.Add(lblLives);
            Controls.Add(lblCoins);
            Controls.Add(lblScore);
            Controls.Add(btnExit);
            Controls.Add(btnPlayAgain);
            Controls.Add(btnLevel2);
            Controls.Add(lblMessage);
            Margin = new Padding(5, 6, 5, 6);
            Name = "VictoryForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Victory!";
            ResumeLayout(false);
            PerformLayout();

        }

        private System.Windows.Forms.Button btnPlayAgain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblCoins;
        private System.Windows.Forms.Label lblLives;
        private System.Windows.Forms.Label lblScoreTitle;
        private System.Windows.Forms.Label lblCoinsTitle;
        private System.Windows.Forms.Label lblLivesTitle;
        private System.Windows.Forms.Button btnLevel2;
        private System.Windows.Forms.Label lblMessage;

        #endregion
    }
}