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
            this.components = new System.ComponentModel.Container();
            this.btnPlayAgain = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.lblCoins = new System.Windows.Forms.Label();
            this.lblLives = new System.Windows.Forms.Label();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.lblCoinsTitle = new System.Windows.Forms.Label();
            this.lblScoreTitle = new System.Windows.Forms.Label();
            this.lblCoinsTitle = new System.Windows.Forms.Label();
            this.lblLivesTitle = new System.Windows.Forms.Label();
            this.btnLevel2 = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // 
            // btnPlayAgain
            // 
            this.btnPlayAgain.BackColor = System.Drawing.Color.ForestGreen;
            this.btnPlayAgain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAgain.FlatAppearance.BorderSize = 0;
            this.btnPlayAgain.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnPlayAgain.ForeColor = System.Drawing.Color.White;
            this.btnPlayAgain.Location = new System.Drawing.Point(250, 350);
            this.btnPlayAgain.Name = "btnPlayAgain";
            this.btnPlayAgain.Size = new System.Drawing.Size(160, 60);
            this.btnPlayAgain.TabIndex = 1;
            this.btnPlayAgain.Text = "Play Again";
            this.btnPlayAgain.UseVisualStyleBackColor = false;
            this.btnPlayAgain.Click += new System.EventHandler(this.btnPlayAgain_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Crimson;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(430, 350);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(160, 60);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLevel2
            // 
            this.btnLevel2.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLevel2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLevel2.FlatAppearance.BorderSize = 0;
            this.btnLevel2.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.btnLevel2.ForeColor = System.Drawing.Color.White;
            this.btnLevel2.Location = new System.Drawing.Point(340, 350); // Centered between others? Logic in OnResize
            this.btnLevel2.Name = "btnLevel2";
            this.btnLevel2.Size = new System.Drawing.Size(160, 60);
            this.btnLevel2.TabIndex = 9;
            this.btnLevel2.Text = "Level 2";
            this.btnLevel2.UseVisualStyleBackColor = false;
            this.btnLevel2.Visible = false; // Hidden by default
            this.btnLevel2.Click += new System.EventHandler(this.btnLevel2_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.lblMessage.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold);
            this.lblMessage.ForeColor = System.Drawing.Color.Yellow;
            this.lblMessage.Location = new System.Drawing.Point(200, 100); 
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 37);
            this.lblMessage.TabIndex = 10;
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMessage.Visible = false;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.White;
            this.lblScore.Location = new System.Drawing.Point(400, 200); 
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(30, 32);
            this.lblScore.TabIndex = 3;
            this.lblScore.Text = "0";
            // 
            // lblCoins
            // 
            this.lblCoins.AutoSize = true;
            this.lblCoins.BackColor = System.Drawing.Color.Transparent;
            this.lblCoins.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblCoins.ForeColor = System.Drawing.Color.White;
            this.lblCoins.Location = new System.Drawing.Point(400, 250); 
            this.lblCoins.Name = "lblCoins";
            this.lblCoins.Size = new System.Drawing.Size(30, 32);
            this.lblCoins.TabIndex = 4;
            this.lblCoins.Text = "0";
            // 
            // lblLives
            // 
            this.lblLives.AutoSize = true;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblLives.ForeColor = System.Drawing.Color.White;
            this.lblLives.Location = new System.Drawing.Point(400, 300); 
            this.lblLives.Name = "lblLives";
            this.lblLives.Size = new System.Drawing.Size(30, 32);
            this.lblLives.TabIndex = 5;
            this.lblLives.Text = "0";
            // 
            // lblScoreTitle
            // 
            this.lblScoreTitle.AutoSize = true;
            this.lblScoreTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblScoreTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblScoreTitle.ForeColor = System.Drawing.Color.White;
            this.lblScoreTitle.Location = new System.Drawing.Point(200, 200); 
            this.lblScoreTitle.Name = "lblScoreTitle";
            this.lblScoreTitle.Size = new System.Drawing.Size(180, 32);
            this.lblScoreTitle.TabIndex = 6;
            this.lblScoreTitle.Text = "FINAL SCORE :";
            // 
            // lblCoinsTitle
            // 
            this.lblCoinsTitle.AutoSize = true;
            this.lblCoinsTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCoinsTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblCoinsTitle.ForeColor = System.Drawing.Color.White;
            this.lblCoinsTitle.Location = new System.Drawing.Point(200, 250); 
            this.lblCoinsTitle.Name = "lblCoinsTitle";
            this.lblCoinsTitle.Size = new System.Drawing.Size(280, 32);
            this.lblCoinsTitle.TabIndex = 7;
            this.lblCoinsTitle.Text = "COINS COLLECTED :";
            // 
            // lblLivesTitle
            // 
            this.lblLivesTitle.AutoSize = true;
            this.lblLivesTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblLivesTitle.Font = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Bold);
            this.lblLivesTitle.ForeColor = System.Drawing.Color.White;
            this.lblLivesTitle.Location = new System.Drawing.Point(200, 300); 
            this.lblLivesTitle.Name = "lblLivesTitle";
            this.lblLivesTitle.Size = new System.Drawing.Size(270, 32);
            this.lblLivesTitle.TabIndex = 8;
            this.lblLivesTitle.Text = "LIVES REMAINING :";
            // 
            // VictoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SemiFinalGame.Properties.Resources.Victory2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblLivesTitle);
            this.Controls.Add(this.lblCoinsTitle);
            this.Controls.Add(this.lblScoreTitle);
            this.Controls.Add(this.lblLives);
            this.Controls.Add(this.lblCoins);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPlayAgain);
            this.Controls.Add(this.btnLevel2);
            this.Controls.Add(this.lblMessage);
            this.Name = "VictoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Victory!";
            this.ResumeLayout(false);
            this.PerformLayout();

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