using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using SemiFinalGame.Entities;
using SemiFinalGame.Movements;


namespace SemiFinalGame
{
    public partial class GameForm : Form
    {
        private List<Obstacle> obstacles = new List<Obstacle>();
        private List<Coin> coins = new List<Coin>();
        private int score = 0;
        private int coinsCollectedCount = 0;
        private Label scoreLabel;
        private Label levelLabel; // Logic Level Indicator

        private PictureBox playerSprite;
        private GameObject player;

        private HorizontalMovement horizontalMovement;
        private VerticalMovement verticalMovement;
        private bool gameEnded = false;

        private int initialFormWidth;
        private int initialFormHeight;
        private int lives = 3;
        private Label livesLabel;
        
        // Level System
        private int currentLevel;
        //private bool isInvincible = false;

        private Panel healthBarBackground;
        private Panel healthBarForeground;
        private int maxLives = 3;  // total lives
        private bool isInvincible = false; // to prevent multi-hit per frame




        // movement flags
        private bool moveLeft, moveRight, moveUp, moveDown;

        // Countdown Timer Fields
        private Label countdownLabel;
        private System.Windows.Forms.Timer startTimer;
        private int countdownValue = 3;

        // Background Animation Fields
        private float backgroundX = 0;
        private float backgroundSpeed = 2.0f; // Positive for Left-to-Right
        private Image backgroundImage;
        private Image backgroundImageFlipped;
        private bool isCurrentTileFlipped = false;

        private void CreateCountdownLabel()
        {
            countdownLabel = new Label();
            countdownLabel.Text = "";
            countdownLabel.Font = new Font("Arial", 72, FontStyle.Bold);
            countdownLabel.ForeColor = Color.DarkBlue;
            countdownLabel.BackColor = Color.Transparent;
            countdownLabel.AutoSize = true;
            countdownLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            // Center it (approximate, will be refined in StartCountdown or Update)
            countdownLabel.Location = new Point(this.ClientSize.Width / 2 - 50, this.ClientSize.Height / 2 - 50);
            
            this.Controls.Add(countdownLabel);
            countdownLabel.BringToFront();
        }

        private void StartCountdown()
        {
            countdownValue = 3;
            countdownLabel.Text = countdownValue.ToString();
            countdownLabel.Location = new Point((this.ClientSize.Width - countdownLabel.Width) / 2, (this.ClientSize.Height - countdownLabel.Height) / 2); // Recenter
            countdownLabel.Visible = true;

            startTimer = new System.Windows.Forms.Timer();
            startTimer.Interval = 1000; // 1 second
            startTimer.Tick += StartTimer_Tick;
            startTimer.Start();
        }

        private void StartTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;

            if (countdownValue > 0)
            {
                countdownLabel.Text = countdownValue.ToString();
            }
            else if (countdownValue == 0)
            {
                countdownLabel.Text = "GO!";
            }
            else
            {
                // Countdown finished
                startTimer.Stop();
                startTimer.Dispose();
                countdownLabel.Visible = false;

                // START THE ACTUAL GAME
                gameTimer.Start();
            }
            
            // Keep centered
            countdownLabel.Location = new Point((this.ClientSize.Width - countdownLabel.Width) / 2, (this.ClientSize.Height - countdownLabel.Height) / 2);
        }

        private void CreatePlayer()
        {
            playerSprite = new PictureBox();
            playerSprite.Size = new Size(64, 64);   // Increased from 48,48
            playerSprite.Location = new Point(100, 300);

            //  IMAGE FROM RESOURCES
            playerSprite.Image = Properties.Resources.tile000;
            playerSprite.SizeMode = PictureBoxSizeMode.StretchImage;
            playerSprite.BackColor = Color.Transparent;

            this.Controls.Add(playerSprite);

            // Link GameObject with sprite
            player = new GameObject();
            player.Position = new PointF(playerSprite.Left, playerSprite.Top);

            // --- ANIMATION SETUP ---
            var anims = new Dictionary<string, List<Image>>();

            // Helper to load range
            List<Image> LoadFrames(string baseName, int start, int count)
            {
                var frames = new List<Image>();
                for (int i = 0; i < count; i++)
                {
                    // Assuming resource names like tile000, tile001, etc.
                    string resName = $"tile{(start + i).ToString("D3")}";
                    var img = (Image)Properties.Resources.ResourceManager.GetObject(resName);
                    if (img != null) frames.Add(img);
                }
                return frames;
            }

            // Mapping based on tile indices
            // Mapping based on tile indices (Corrected based on visual feedback)
            anims["Down"] = LoadFrames("tile", 0, 8);   // 000-007
            anims["Up"] = LoadFrames("tile", 8, 8);     // 008-015
            anims["Left"] = LoadFrames("tile", 16, 8);  // 016-023
            anims["Right"] = LoadFrames("tile", 24, 8); // 024-031

            // Fallback if resources miss - ensure NO list is empty
            if (anims["Down"].Count == 0) anims["Down"].Add(Properties.Resources.tile000);
            if (anims["Up"].Count == 0) anims["Up"].AddRange(anims["Down"]); // Fallback to Down if Up missing
            if (anims["Left"].Count == 0) anims["Left"].AddRange(anims["Down"]); // Fallback
            if (anims["Right"].Count == 0) anims["Right"].AddRange(anims["Down"]); // Fallback

            if (player is Player p)
            {
                 p.SetAnimation(anims, "Down");
            }
            else
            {
                // Re-create as Player if it was just GameObject
                var oldPos = player.Position;
                player = new Player(); 
                player.Position = oldPos;
                ((Player)player).SetAnimation(anims, "Down");
            }
        }

        public GameForm(int level = 1)
        {
            this.currentLevel = level;
            
            InitializeComponent();
            this.Resize += GameForm_Resize;
            initialFormWidth = this.ClientSize.Width;
            initialFormHeight = this.ClientSize.Height;

            this.DoubleBuffered = true;
            this.KeyPreview = true;

            // Prevent runtime logic from running in the Designer
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            SetupLevelDifficulty(currentLevel);

            CreatePlayer();     // Add player first
            CreateScoreLabel(); // Add score label last
            CreateLevelLabel(); // Add level label
            SpawnCoins();       // Add coins next
            SetupObstacles();   // Add obstacles

            scoreLabel.BringToFront();

            CreateCountdownLabel(); // Init countdown label
            StartCountdown();       // Start the 3-2-1 sequence

            horizontalMovement = new HorizontalMovement(14f);
            verticalMovement = new VerticalMovement(14f);

            // Adjust player speed for Level 2
            if (currentLevel >= 2)
            {
                 horizontalMovement = new HorizontalMovement(28f);
                 verticalMovement = new VerticalMovement(28f);
            }

            gameTimer.Interval = 20;
            gameTimer.Tick -= GameTimer_Tick; // safety
            gameTimer.Tick += GameTimer_Tick;
            // gameTimer.Start(); // Removed: Handled by StartTimer_Tick now

            this.KeyDown += GameForm_KeyDown;
            this.KeyUp += GameForm_KeyUp;
            //CreateLivesLabel();
            CreateLivesLabel();
            CreateHealthBar();

            // Background Setup
            backgroundImage = Properties.Resources.background_still;
            
            // Create the flipped version for seamless tiling
            backgroundImageFlipped = (Image)backgroundImage.Clone();
            backgroundImageFlipped.RotateFlip(RotateFlipType.RotateNoneFlipX);

            this.BackgroundImage = null; // Disable default background rendering
            this.DoubleBuffered = true; // Ensure this is definitely on
        }

        private void SetupLevelDifficulty(int level)
        {
            if (level == 1)
            {
                backgroundSpeed = 2.0f;
            }
            else if (level == 2)
            {
                backgroundSpeed = 5.0f; // Faster background
            }
            else
            {
                // Default fallback
                backgroundSpeed = 2.0f;
            }
        }
        private async void HandlePlayerHit()
        {
            if (isInvincible) return;
            isInvincible = true;

            // 1️⃣ Reduce lives
            lives--;
            livesLabel.Text = "Lives: " + lives;

            // 2️⃣ Update health
            float healthPercentage = (lives / (float)maxLives);
            player.Health = (int)(healthPercentage * 100);
            healthBarForeground.Width = (int)(healthPercentage * healthBarBackground.Width);

            // 3️⃣ Reset player position
            player.Position = new PointF(100, 300);
            playerSprite.Left = 100;
            playerSprite.Top = 300;

            await Task.Delay(500);
            isInvincible = false;

            if (lives <= 0)
                GameOver();
        }


        private void CreateHealthBar()
        {
            // Background (gray)
            healthBarBackground = new Panel
            {
                Size = new Size(150, 20),
                BackColor = Color.Gray,
                Location = new Point(this.ClientSize.Width - 160, 40),
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(healthBarBackground);

            // Foreground (red)
            healthBarForeground = new Panel
            {
                Size = healthBarBackground.Size,
                BackColor = Color.Green,
                Location = healthBarBackground.Location,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };
            this.Controls.Add(healthBarForeground);
            healthBarForeground.BringToFront();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (gameEnded) return;

            // ================= PLAYER MOVEMENT =================
            string newDirection = null;

            if (moveLeft)
            {
                horizontalMovement.MoveLeft(player);
                newDirection = "Left";
            }

            if (moveRight)
            {
                horizontalMovement.MoveRight(player, this.ClientSize.Width - playerSprite.Width);
                newDirection = "Right";
            }

            if (moveUp)
            {
                verticalMovement.MoveUp(player);
                newDirection = "Up";
            }

            if (moveDown)
            {
                verticalMovement.MoveDown(player, this.ClientSize.Height - playerSprite.Height);
                newDirection = "Down";
            }

            // Update Animation
            if (player is Player p)
            {
                if (newDirection != null)
                {
                    p.ChangeDirection(newDirection);
                    p.Update(new GameTime { DeltaTime = 0.02f }); // approx for 20ms interval
                }
                
                if (p.Sprite != null)
                    playerSprite.Image = p.Sprite;
            }

            // Apply position to sprite
            playerSprite.Left = (int)player.Position.X;
            playerSprite.Top = (int)player.Position.Y;

            // ================= OBSTACLE UPDATE =================
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Update();

                // Only detect collision, DO NOT call GameOver here
                if (playerSprite.Bounds.IntersectsWith(obstacle.Sprite.Bounds))
                {
                    HandlePlayerHit();
                    break; // prevent multiple hits in same frame
                }
            }


            // ================= COINS UPDATE =================
            UpdateCoins();

            // ================= BACKGROUND ANIMATION =================
            UpdateBackground();
            this.Invalidate(); // trigger OnPaint
        }

        private void UpdateBackground()
        {
            // Move Background Left to Right
            backgroundX += backgroundSpeed;

            // Reset based on FORM WIDTH (since we stretch the image to form width)
            if (backgroundX >= this.ClientSize.Width)
            {
                backgroundX = 0;
                // Toggle the tile type to alternate between Normal and Flipped
                isCurrentTileFlipped = !isCurrentTileFlipped;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (backgroundImage != null && backgroundImageFlipped != null)
            {
                // STRETCH Logic to fix "patches"
                int drawWidth = this.ClientSize.Width;
                int drawHeight = this.ClientSize.Height;

                // OPTIMIZATION: Use NearestNeighbor for performance and pixel-perfect look
                // HighQualityBicubic is too slow for large scrolling backgrounds
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.None; // or HighSpeed
                e.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
                e.Graphics.SmoothingMode = SmoothingMode.HighSpeed;

                // Determine which image is "Current" (leaving right) and "Incoming" (entering from left)
                Image currentImage = isCurrentTileFlipped ? backgroundImageFlipped : backgroundImage;
                Image incomingImage = isCurrentTileFlipped ? backgroundImage : backgroundImageFlipped;

                // Convert float to int to prevent sub-pixel rendering gaps
                int x = (int)Math.Round(backgroundX);

                // 1. Draw current cycle (Moving from 0 to Width)
                // Draw slightly wider (+1) or ensure overlap logic
                e.Graphics.DrawImage(currentImage, x, 0, drawWidth, drawHeight);
                
                // 2. Draw incoming cycle (Moving from -Width to 0)
                if (x > 0)
                {
                    // Overlap by 1 pixel to remove the seam line
                    // Position: x - drawWidth + 1 (The +1 moves it 1 pixel to the right, creating overlap)
                    e.Graphics.DrawImage(incomingImage, x - drawWidth + 1, 0, drawWidth, drawHeight);
                }
            }
        }
        private void GameOver()
        {
            if (gameEnded) return;
            ResetMovementFlags();
            gameEnded = true;
            gameTimer.Stop();

            // Use custom GameOver form
            using (var gameOverForm = new GameOver(score, coinsCollectedCount, lives))
            {
                DialogResult result = gameOverForm.ShowDialog();

                if (result == DialogResult.Yes)
                    RestartGame();
                else
                    this.Close();
            }
            this.Focus();
        }




        private void RestartGame()
        {
            ResetMovementFlags();
            gameEnded = false;

            // Reset score
            score = 0;
            coinsCollectedCount = 0;
            scoreLabel.Text = "Score: 0";

            // ===== Reset lives and health =====
            lives = maxLives;                      // Set lives to max
            livesLabel.Text = "Lives: " + lives;   // Update label

            player.Health = 100;                   // Reset player health
            livesLabel.Text = "Lives: " + lives;   // Update label

            // Update Level Label
            if (levelLabel != null) levelLabel.Text = "Level: " + currentLevel;

            player.Health = 100;                   // Reset player health

            // Reset player position
            player.Position = new PointF(100, 300);
            playerSprite.Left = 100;
            playerSprite.Top = 300;

            // Remove OLD coins from form
            foreach (Coin coin in coins)
            {
                if (this.Controls.Contains(coin.Sprite))
                    this.Controls.Remove(coin.Sprite);
            }
            coins.Clear();

            // Remove OLD obstacles
            foreach (Obstacle obs in obstacles)
            {
                if (this.Controls.Contains(obs.Sprite))
                    this.Controls.Remove(obs.Sprite);
            }
            obstacles.Clear();

            // Re-setup Difficulty (in case it changed or for cleanliness)
            SetupLevelDifficulty(currentLevel);

            // Spawn fresh game objects
            SpawnCoins();        // IMPORTANT
            SetupObstacles();    // IMPORTANT

            gameTimer.Stop();
            gameTimer.Start();

            this.Focus();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) moveLeft = true;
            if (e.KeyCode == Keys.Right) moveRight = true;
            if (e.KeyCode == Keys.Up) moveUp = true;
            if (e.KeyCode == Keys.Down) moveDown = true;
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) moveLeft = false;
            if (e.KeyCode == Keys.Right) moveRight = false;
            if (e.KeyCode == Keys.Up) moveUp = false;
            if (e.KeyCode == Keys.Down) moveDown = false;
        }
        private void CreateScoreLabel()
        {
            scoreLabel = new Label();
            scoreLabel.Text = "Score: 0";
            scoreLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            scoreLabel.ForeColor = Color.Black;
            scoreLabel.BackColor = Color.Transparent; // optional
            scoreLabel.AutoSize = true;
            scoreLabel.Location = new Point(10, 10);

            this.Controls.Add(scoreLabel);
            scoreLabel.BringToFront(); // make sure it's on top of all PictureBoxes
        }

        private void CreateLevelLabel()
        {
            levelLabel = new Label();
            levelLabel.Text = "Level: " + currentLevel;
            levelLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            levelLabel.ForeColor = Color.Cyan;
            levelLabel.BackColor = Color.Transparent;
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(this.ClientSize.Width - 120, 10);
            levelLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(levelLabel);
            levelLabel.BringToFront();
        }

        private void SpawnCoins()
        {
            coins.Clear();

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                // Random position but spread across the form
                int x = rnd.Next(50, formWidth - 50);
                int y = rnd.Next(50, formHeight - 50);

                Image coinImage;
                int coinValue;

                // Alternate silver and gold
                if (i % 2 == 0)
                {
                    coinImage = Properties.Resources.giphy; // Silver coin
                    coinValue = 2;
                }
                else
                {
                    coinImage = Properties.Resources.giphy1; // Gold coin
                    coinValue = 5;
                }

                // Horizontal bounds for patrol ±50 pixels from start X
                float leftBound = Math.Max(0, x - 50);
                float rightBound = Math.Min(formWidth - 32, x + 50); // 32 = coin width

        Coin coin = new Coin(coinImage, new Point(x, y), coinValue, new Size(48, 48), leftBound, rightBound, formWidth, formHeight);

                this.Controls.Add(coin.Sprite);
                coins.Add(coin);
            }

            scoreLabel.BringToFront(); // Ensure score is on top
        }
        private void UpdateCoins()
        {
            if (gameEnded) return;

            foreach (Coin coin in coins.ToList())
            {
                coin.Movement.Move(coin.Body, null);

                coin.Sprite.Left = (int)coin.Body.Position.X;
                coin.Sprite.Top = (int)coin.Body.Position.Y;

                if (playerSprite.Bounds.IntersectsWith(coin.Sprite.Bounds))
                {
                    score += coin.Value;
                    coinsCollectedCount++; // Track count
                    scoreLabel.Text = "Score: " + score;

                    this.Controls.Remove(coin.Sprite);
                    coins.Remove(coin);
                }
            }

            // ✅ WIN CONDITION
            if (coins.Count == 0 && !gameEnded)
            {
                gameEnded = true;
                gameTimer.Stop();
                ShowWinMessage();
            }
        }
        private void ShowWinMessage()
        {
            // Use custom VictoryForm
            // Use custom VictoryForm
            // Pass the current level so VictoryForm can decide to show "Next Level"
            using (var victoryForm = new VictoryForm(score, coinsCollectedCount, lives, currentLevel))
            {
                DialogResult result = victoryForm.ShowDialog();

                if (result == DialogResult.Yes) // Played clicked "Level 2" or "Restart"
                {
                    // VictoryForm sets a static property or we handle leveling up?
                    // Simpler: VictoryForm returns "Yes", but we need to know if it's NEXT LEVEL.
                    // Actually, if we want to change level, we might need to close this Generic Form and open a NEW one
                    // OR just update currentLevel and RestartGame().
                    
                    if (victoryForm.GoToNextLevel)
                    {
                        currentLevel++;
                        RestartGame(); // Restart with new level difficulty
                    }
                    else
                    {
                        RestartGame(); // Just restart same level
                    }
                }
                else
                {
                    this.Close();
                }
            }
        }
        private void ResetMovementFlags()
        {
            moveLeft = false;
            moveRight = false;
            moveUp = false;
            moveDown = false;
        }
        private void SetupObstacles()
        {
            obstacles.Clear();

            int obstacleCount;
            if (currentLevel == 2) 
                obstacleCount = 20; // 20 obstacles for Level 2
            else
                obstacleCount = 10; // Default Level 1

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            Random rnd = new Random();

            // Even horizontal spacing
            int spacing = formWidth / (obstacleCount + 1);

            for (int i = 0; i < obstacleCount; i++)
            {
                PictureBox box = new PictureBox();
                box.Size = new Size(80, 30); // Increased from 60,20

                int x = spacing * (i + 1);
                int y = rnd.Next(0, formHeight - box.Height);

                box.Location = new Point(x, y);
                box.Image = Properties.Resources.box;
                box.SizeMode = PictureBoxSizeMode.StretchImage;
                box.BackColor = Color.Transparent;

                this.Controls.Add(box);

                // Vertical patrol bounds
                float topBound = 0;
                float bottomBound = formHeight - box.Height;

                // Random up/down speed
                // Random up/down speed based on Level
                int minSpeed, maxSpeed;
                if (currentLevel >= 2)
                {
                    minSpeed = 10;
                    maxSpeed = 14;
                }
                else
                {
                    minSpeed = 5;  // Increased from 3
                    maxSpeed = 10; // Increased from 7
                }

                float speed = rnd.Next(minSpeed, maxSpeed);
                if (rnd.Next(2) == 0)
                    speed = -speed;

                obstacles.Add(new Obstacle(
                    box,
                    new VerticalPatrolMovement(topBound, bottomBound, speed)
                ));
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;   // optional
        }

        //private int initialFormWidth;
        //private int initialFormHeight;

        private void CreateLivesLabel()
        {
            livesLabel = new Label();
            livesLabel.Text = "Lives: 3";
            livesLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            livesLabel.ForeColor = Color.Red;
            livesLabel.BackColor = Color.Transparent;
            livesLabel.AutoSize = true;

            // Place near top-right initially
            livesLabel.Location = new Point(
                this.ClientSize.Width - livesLabel.PreferredWidth - 10,
                10
            );

            // 🔴 THIS is the key line
            livesLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            this.Controls.Add(livesLabel);
            livesLabel.BringToFront();
        }



        private void GameForm_Resize(object sender, EventArgs e)
        {
            if (gameEnded) return;

            // Store initial form size on first call
            if (initialFormWidth == 0 || initialFormHeight == 0)
            {
                initialFormWidth = this.ClientSize.Width;
                initialFormHeight = this.ClientSize.Height;
                return;
            }

            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // ====== Player ======
            float playerXRatio = player.Position.X / (float)initialFormWidth;
            float playerYRatio = player.Position.Y / (float)initialFormHeight;

            playerSprite.Left = (int)(playerXRatio * formWidth);
            playerSprite.Top = (int)(playerYRatio * formHeight);
            player.Position = new PointF(playerSprite.Left, playerSprite.Top);

            // ====== Coins ======
            foreach (Coin coin in coins)
            {
                float coinXRatio = coin.Body.Position.X / (float)initialFormWidth;
                float coinYRatio = coin.Body.Position.Y / (float)initialFormHeight;

                coin.Sprite.Left = (int)(coinXRatio * formWidth);
                coin.Sprite.Top = (int)(coinYRatio * formHeight);
                coin.Body.Position = new PointF(coin.Sprite.Left, coin.Sprite.Top);

                // Update horizontal patrol bounds
                coin.Movement = new HorizontalPatrolMovement(
                    Math.Max(0, coin.Sprite.Left - 50),
                    Math.Min(formWidth - coin.Sprite.Width, coin.Sprite.Left + 50)
                );
            }
            // ====== Obstacles ======
            foreach (Obstacle obs in obstacles)
            {
                float obsXRatio = obs.Sprite.Left / (float)initialFormWidth;
                float obsYRatio = obs.Sprite.Top / (float)initialFormHeight;

                obs.Sprite.Left = (int)(obsXRatio * formWidth);
                obs.Sprite.Top = (int)(obsYRatio * formHeight);
                obs.Body.Position = new PointF(obs.Sprite.Left, obs.Sprite.Top);
                // Update vertical patrol bounds
                if (obs.Movement is VerticalPatrolMovement)
                {
                    obs.Movement = new VerticalPatrolMovement(
                        0, // top bound
                        formHeight - obs.Sprite.Height, // bottom bound
                        2f // default speed
                    );
                }
            }
        }

    }
}

