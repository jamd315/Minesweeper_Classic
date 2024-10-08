﻿using Microsoft.Win32;
using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Minesweeper_Classic
{
    public partial class MainGame : Form
    {
        // Settings or gamestate
        private bool color = true;
        private int timerCount = 0;
        private int mineCount = 10;
        private int flagCount;
        private int rows = 9;
        private int cols = 9;
        private int unclickedRemaining;
        private bool gameRunning = false;
        private Face faceState;
        private bool useQuestionMarks = true;
        public Difficulty difficulty = Difficulty.Beginner;  // Used by HighscoreEntry form, so public
        private SoundState soundState = SoundState.SoundDisabled;
        private bool formLoaded = false;  // Just prevents the custom difficulty form from showing up on initial config load

        // Gameboard
        private Tile[,] displayedTile;         // Array of displayed tiles
        private TileState[,] tileState;     // Whether the tile is a bomb or not
        private Bitmap gameboardBmp;        // The gameboard image displayed in picGameboard
        private Graphics gameboardGraphic;  // Edits gameboardBmp

        // Store this way because this is how the registry stores them
        // Used by HighscoreScreen form, so public
        public string name1;
        public string name2;
        public string name3;
        public int time1;
        public int time2;
        public int time3;

        // Sounds
        SoundPlayer winSound = new SoundPlayer(Properties.Resources.win);
        SoundPlayer tickSound = new SoundPlayer(Properties.Resources.tick);
        SoundPlayer bombSound = new SoundPlayer(Properties.Resources.bomb);

        private Point initPos = new Point(80, 80);  // Where to start the form on the screen.  Loaded from registry, default (80, 80)

        #region Enums
        private enum Face: int  // Used with imgFaces, imgFaces_BW
        {
            Dead = 0,
            Oh = 1,
            Smile = 2,
            SmilePressed = 3,
            Sunglasses = 4
        }

        private enum Tile: int  // Used with imgTiles, imgTiles_BW, state management
        {
            Blank = 0,
            Tile1 = 1,
            Tile2 = 2,
            Tile3 = 3,
            Tile4 = 4,
            Tile5 = 5,
            Tile6 = 6,
            Tile7 = 7,
            Tile8 = 8,
            Bomb = 9,
            BombClicked = 10,
            Flag = 11,
            NoBomb = 12,
            Question = 13,
            QuestionUnclicked = 14,
            Unclicked = 15
        }

        private enum TileState  // Is it a bomb or not
        {
            Nothing,
            IsBomb
        }

        private enum SevenSegment: int  // Used with imgSevenSegment, imgSevenSegment_BW
        {
            // 0-9 are just indices 0-9
            Num0 = 0,
            Num1 = 1,
            Num2 = 2,
            Num3 = 3,
            Num4 = 4,
            Num5 = 5,
            Num6 = 6,
            Num7 = 7,
            Num8 = 8,
            Num9 = 9,
            Blank = 10,
            Dash = 11
        }

        public enum Difficulty: int  // Used when saving data, and by HighscoreEntry form
        {
            Beginner = 0,
            Intermediate = 1,
            Expert = 2,
            Custom = 3
        }

        private enum SoundState: int
        {
            SoundDisabled = 0,
            SoundEnabled = 3,  // Not sure why 3 is used, but it is.  10 also works
            SoundEnabledAlternate = 10
        }
        #endregion Enums

        #region Misc
        public MainGame()
        {
            InitializeComponent();
        }

        private void timCountUp_Tick(object sender, EventArgs e)
        {
            if (timerCount >= 999)
            {
                timCountUp.Stop();
                return;
            }
            if (soundState != SoundState.SoundDisabled)
                tickSound.Play();
            timerCount++;
            drawTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadConfig();
            loadScores();
            this.Location = initPos;  // Reset window to previous location
            newGame();
            formLoaded = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveConfig();
            saveScores();
        }
        #endregion Misc

        #region Toolstrip
        // Beginner difficulty
        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = true;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            rows = 9;
            cols = 9;
            mineCount = 10;
            difficulty = Difficulty.Beginner;
            newGame();
        }

        // Intermediate difficulty
        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = true;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
            rows = 16;
            cols = 16;
            mineCount = 40;
            difficulty = Difficulty.Intermediate;
            newGame();
        }

        // Expert difficulty
        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = true;
            customToolStripMenuItem.Checked = false;
            rows = 16;
            cols = 30;
            mineCount = 99;
            difficulty = Difficulty.Expert;
            newGame();
        }

        // Custom difficulty
        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = true;
            difficulty = Difficulty.Custom;
            getCustomDifficulty();
            newGame();
        }

        // Just exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Show the high scores
        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighscoreScreen hs = new HighscoreScreen();
            hs.ShowDialog(this);
        }

        // Start a new game
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }

        // Change the colors, then redraw
        private void colorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            color = !color;
            totalRedraw();
        }

        // Whether to use question marks or not
        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // In the original, existing question marks are not removed, only changes going forward
            useQuestionMarks = !useQuestionMarks;
        }

        // Enable or disable sound
        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle
            if (soundState == SoundState.SoundDisabled)
                soundState = SoundState.SoundEnabled;
            else
                soundState = SoundState.SoundDisabled;
        }

        // Contains attribution stuff
        private void aboutMinesweeperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.ShowDialog(this);
        }

        // Help dialog
        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, "Old style help files don't work past Vista, so this part I wasn't able to port", ":(", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }
        #endregion Toolstrip

        #region FaceManagement
        // Pair of functions to be used with any control that can flip the face if clicked
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!gameRunning)
                return;
            drawFace(Face.Oh);
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (!gameRunning)
                return;
            drawFace(Face.Smile);


            // If picGameboard is clicked use an additional handler
            if (sender == picGameboard)
            {
                gameboardClicked(sender, e);
            }
        }

        // Do a separate pair of functions for if the button is actually pressed
        private void picFace_MouseDown(object sender, MouseEventArgs e)
        {
            drawFace(Face.SmilePressed);
        }

        private void picFace_MouseUp(object sender, MouseEventArgs e)
        {
            drawFace(Face.Smile);
        }

        // Full click to do new game
        private void picFace_Click(object sender, EventArgs e)
        {
            newGame();
        }
        #endregion FaceManagement

        #region Drawing
        // Redraw timer, disposing of old images
        private void drawTimer()
        {
            int hundreds = (timerCount % 1000 - timerCount % 100) / 100;
            int tens = (timerCount % 100 - timerCount % 10) / 10;
            int ones = timerCount % 10;
            ImageList imList;
            if (color)
                imList = imgSevenSegment;
            else
                imList = imgSevenSegment_BW;
            if (picTimerH.Image != null)
                picTimerH.Image.Dispose();
            picTimerH.Image = imList.Images[hundreds];
            if (picTimerT.Image != null)
                picTimerT.Image.Dispose();
            picTimerT.Image = imList.Images[tens];
            if (picTimerO.Image != null)
                picTimerO.Image.Dispose();
            picTimerO.Image = imList.Images[ones];
        }

        // Redraw flag count, disposing of old images
        private void drawFlagCount()
        {
            int absFlagCount = Math.Abs(flagCount);
            int hundreds = (absFlagCount % 1000 - absFlagCount % 100) / 100;
            int tens = (absFlagCount % 100 - absFlagCount % 10) / 10;
            int ones = absFlagCount % 10;

            ImageList imList;
            if (color)
                imList = imgSevenSegment;
            else
                imList = imgSevenSegment_BW;

            if (picFlagCountH.Image != null)
                picFlagCountH.Image.Dispose();
            if (flagCount < 0)
                picFlagCountH.Image = imList.Images[(int)SevenSegment.Dash];
            else
                picFlagCountH.Image = imList.Images[hundreds];

            if (picFlagCountT.Image != null)
                picFlagCountT.Image.Dispose();
            picFlagCountT.Image = imList.Images[tens];

            if (picFlagCountO.Image != null)
                picFlagCountO.Image.Dispose();
            picFlagCountO.Image = imList.Images[ones];
        }

        // Redraw face and dispose the old image
        private void drawFace(Face f)
        {
            if (picFace.Image != null)
                picFace.Image.Dispose();

            ImageList imList;
            if (color)
                imList = imgFaces;
            else
                imList = imgFaces_BW;

            faceState = f;
            picFace.Image = imList.Images[(int)f];
        }

        // Draw the entire gameboardBmp
        private void drawGameboard()
        {
            // Render gameboard to a single image to improve performance
            if (gameboardBmp != null)  // If gameboardBmp exists, Dispose of the old one
                gameboardBmp.Dispose();
            gameboardBmp = new Bitmap(cols * 16, rows * 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            if (gameboardGraphic != null)  // If gameboardGraphic exists, Dispose of the old one
                gameboardGraphic.Dispose();
            gameboardGraphic = Graphics.FromImage(gameboardBmp);
            // Just copy the source pixels as quickly as possible
            gameboardGraphic.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            // Not really sure what I want, just a direct copy so I went with AssumeLinear.  Could also use GammaCorrected or HighSpeed
            // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.compositingquality?view=netframework-4.7.1
            gameboardGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

            ImageList imList;
            if (color)
                imList = imgTiles;
            else
                imList = imgTiles_BW;

            Point pt = new Point();
            for (int r = 0; r < rows * 16; r += 16)
            {
                for (int c = 0; c < cols * 16; c += 16)
                {
                    pt.X = c;
                    pt.Y = r;
                    imList.Draw(gameboardGraphic, pt, (int)Tile.Unclicked);
                }
            }

            picGameboard.Image = gameboardBmp;
        }

        // Just change part of the gameboardBmp
        private void changeGameboard(int r, int c, int index)
        {
            ImageList imList;
            if (color)
                imList = imgTiles;
            else
                imList = imgTiles_BW;

            Point pt = new Point(16 * c, 16 * r);
            imList.Draw(gameboardGraphic, pt, index);
            picGameboard.Image = gameboardBmp;
        }

        // Resize controls and the form after the gameboard size is changed
        private void resizeControls()
        {
            int newHeight;
            int newWidth;

            picGameboard.Size = gameboardBmp.Size;  // picGameboard is just the size of its bmp
            newWidth = gameboardBmp.Size.Width + 4;
            newHeight = gameboardBmp.Size.Height + 4;
            pnlGameboard.Size = new Size(newWidth, newHeight);
            pnlHeader.Width = newWidth;  // Reuse newWidth

            newWidth = 8 + 8 + pnlGameboard.Size.Width + 8 + 8;  // 8px margin either side plus 8px window border
            newHeight = pnlGameboard.Location.Y + pnlGameboard.Size.Height + 44;  // Gross guess and check number
            this.Size = new Size(newWidth, newHeight);
        }

        // Redraw everything (used for when color is enabled or disabled)
        private void totalRedraw()
        {
            drawTimer();
            drawFlagCount();
            drawFace(faceState);
            drawGameboard();
        }
        #endregion Drawing

        #region GameManagement
        // Gets the number of adjacent mines for a given tile
        private int adjacentMineCount(int r, int c)
        {
            int count = 0;
            if (r != 0 && c != 0 && tileState[r - 1, c - 1] == TileState.IsBomb)  // Northwest
                count++;
            if (r != 0 && tileState[r - 1, c] == TileState.IsBomb)  // North
                count++;
            if (r != 0 && c != cols - 1 && tileState[r - 1, c + 1] == TileState.IsBomb)  // Northeast
                count++;
            if (c != 0 && tileState[r, c - 1] == TileState.IsBomb)  // West
                count++;
            if (c != cols - 1 && tileState[r, c + 1] == TileState.IsBomb)  // East
                count++;
            if (r != rows - 1  && c != 0 && tileState[r + 1, c - 1] == TileState.IsBomb)  // Southwest
                count++;
            if (r != rows - 1 && tileState[r + 1, c] == TileState.IsBomb)  // South
                count++;
            if (r != rows - 1 && c != cols - 1 && tileState[r + 1, c + 1] == TileState.IsBomb)  // Southeast
                count++;
            return count;
        }

        // Gets the number of adjacent mines for a given tile
        private int adjacentDisplaystateCount(int r, int c, Tile searchTile)
        {
            int count = 0;
            if (r != 0 && c != 0 && displayedTile[r - 1, c - 1] == searchTile)  // Northwest
                count++;
            if (r != 0 && displayedTile[r - 1, c] == searchTile)  // North
                count++;
            if (r != 0 && c != cols - 1 && displayedTile[r - 1, c + 1] == searchTile)  // Northeast
                count++;
            if (c != 0 && displayedTile[r, c - 1] == searchTile)  // West
                count++;
            if (c != cols - 1 && displayedTile[r, c + 1] == searchTile)  // East
                count++;
            if (r != rows - 1 && c != 0 && displayedTile[r + 1, c - 1] == searchTile)  // Southwest
                count++;
            if (r != rows - 1 && displayedTile[r + 1, c] == searchTile)  // South
                count++;
            if (r != rows - 1 && c != cols - 1 && displayedTile[r + 1, c + 1] == searchTile)  // Southeast
                count++;
            return count;
        }

        // Reset game state variables and start a new game
        private void newGame()
        {
            // Init the variables
            timCountUp.Stop();
            timerCount = 0;
            gameRunning = true;
            unclickedRemaining = rows * cols;
            flagCount = mineCount;
            drawFlagCount();
            drawTimer();
            drawFace(Face.Smile);

            // Init gameboard to keep track of game state
            drawGameboard();
            resizeControls();
            displayedTile = new Tile[rows, cols];
            tileState = new TileState[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    displayedTile[r, c] = Tile.Unclicked;
                    tileState[r, c] = TileState.Nothing;
                }
            }
            
            // Add bombs
            int bombsAdded = 0;
            Random rand = new Random();
            while (bombsAdded != mineCount)  // Prevents adding bombs to an already bombed spot
            {
                int bombRow = rand.Next(rows);
                int bombCol = rand.Next(cols);
                if (tileState[bombRow, bombCol] != TileState.IsBomb)
                {
                    tileState[bombRow, bombCol] = TileState.IsBomb;
                    bombsAdded++;
                }
            }
        }

        // Called by picGameboard when clicked
        private void gameboardClicked(object sender, EventArgs e)
        {
            if (!gameRunning)
                return;

            MouseEventArgs me = (MouseEventArgs)e;

            int row = me.Y / 16;
            int col = me.X / 16;
            if (row >= rows)
                throw new IndexOutOfRangeException("Row overflow");
            if (row < 0)
                throw new IndexOutOfRangeException("Row underflow");
            if (col >= cols)
                throw new IndexOutOfRangeException("Column overflow");
            if (col < 0)
                throw new IndexOutOfRangeException("Column underflow");

            if (me.Button == MouseButtons.Left)
            {
                if (!timCountUp.Enabled)  // Enable timer after first click
                    timCountUp.Start();

                if (displayedTile[row, col] == Tile.Flag)  // Don't click flags
                    return;

                // If this is the very first click and we clicked a bomb, move the bomb
                if (tileState[row, col] == TileState.IsBomb && unclickedRemaining == rows * cols)
                {
                    moveBomb(row, col);
                }

                if (tileState[row, col] == TileState.IsBomb)  // If you click a bomb, game over
                {
                    gameOver();
                    changeGameboard(row, col, (int)Tile.BombClicked);
                }
                else if (displayedTile[row, col] == Tile.Unclicked)
                {
                    int nearbyBombs = adjacentMineCount(row, col);
                    changeGameboard(row, col, nearbyBombs);
                    displayedTile[row, col] = (Tile)nearbyBombs;
                    if (nearbyBombs == 0 && tileState[row, col] == TileState.Nothing)
                    {
                        clickAllAdjacent(row, col, me);
                    }
                    unclickedRemaining--;
                    if (unclickedRemaining == mineCount)
                    {
                        win();
                    }
                }
                // When a tile with a number is clicked, and the number of adjacent flags matches that number,
                // click the remaining un-clicked tiles
                else if ((int)displayedTile[row, col] >= 1 && (int)displayedTile[row, col] <= 8)
                {
                    if (adjacentDisplaystateCount(row, col, Tile.Flag) == (int)displayedTile[row, col])
                    {
                        clickAllAdjacent(row, col, me, onlyUnclicked: true);
                    }
                }
            }
            else if (me.Button == MouseButtons.Right)  // On a right click, mark with flag, question mark (if enabled), or clear mark
            {

                switch (displayedTile[row, col])
                {
                    case Tile.Unclicked:  // Unclicked, make it a flag
                        changeGameboard(row, col, (int)Tile.Flag);
                        displayedTile[row, col] = Tile.Flag;
                        flagCount--;
                        drawFlagCount();
                        break;
                    case Tile.Flag:  // Flag, make it a question, or unclicked if question marks aren't enabled
                        if (useQuestionMarks)
                        {
                            changeGameboard(row, col, (int)Tile.QuestionUnclicked);
                            displayedTile[row, col] = Tile.QuestionUnclicked;
                        }
                        else
                        {
                            changeGameboard(row, col, (int)Tile.Unclicked);
                            displayedTile[row, col] = Tile.Unclicked;
                        }
                        flagCount++;
                        drawFlagCount();
                        break;
                    case Tile.Question:
                    case Tile.QuestionUnclicked:  // Question, make it unclicked
                        changeGameboard(row, col, (int)Tile.Unclicked);
                        displayedTile[row, col] = Tile.Unclicked;
                        break;
                }
            }
        }

        // Used when a 0 adjacency tile is clicked to flood fill and for when a number is clicked
        private void clickAllAdjacent(int r, int c, MouseEventArgs initialArgs, bool onlyUnclicked = false)
        {
            MouseEventArgs me;
            if (r != rows - 1)  // South
            {
                if (!onlyUnclicked || displayedTile[r + 1, c] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X, initialArgs.Y + 16, 0);
                    gameboardClicked(null, me);
                }
            }
            if (r != 0)  // North
            {
                if (!onlyUnclicked || displayedTile[r - 1, c] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X, initialArgs.Y - 16, 0);
                    gameboardClicked(null, me);
                } 
            }
            if (c != cols - 1)  // East
            {
                if (!onlyUnclicked || displayedTile[r, c + 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y, 0);
                    gameboardClicked(null, me);
                }
            }
            if (c != 0)  // West
            {
                if (!onlyUnclicked || displayedTile[r, c - 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y, 0);
                    gameboardClicked(null, me);
                }
            }
            if (r != rows - 1 && c != cols - 1)  // Southeast
            {
                if (!onlyUnclicked || displayedTile[r + 1, c + 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y + 16, 0);
                    gameboardClicked(null, me);
                }
            }
            if (r != rows - 1 && c != 0)  // Southwest
            {
                if (!onlyUnclicked || displayedTile[r + 1, c - 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y + 16, 0);
                    gameboardClicked(null, me);
                }
            }
            if (r != 0 && c != cols - 1)  // Northeast
            {
                if (!onlyUnclicked || displayedTile[r - 1, c + 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y - 16, 0);
                    gameboardClicked(null, me);
                }
            }
            if (r != 0 && c != 0)  // Northwest
            {
                if (!onlyUnclicked || displayedTile[r - 1, c - 1] == Tile.Unclicked)
                {
                    me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y - 16, 0);
                    gameboardClicked(null, me);
                }
            }
        }

        // Stop the game after a loss condition
        private void gameOver()
        {
            gameRunning = false;
            timCountUp.Stop();
            drawFace(Face.Dead);
            if (soundState != SoundState.SoundDisabled)
                bombSound.Play();

            // Reveal un-flagged bombs
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // If a bomb is hidden, but not flagged, reveal it
                    if (tileState[r, c] == TileState.IsBomb && displayedTile[r, c] != Tile.Flag)
                    {
                        displayedTile[r, c] = Tile.Bomb;
                        changeGameboard(r, c, (int)Tile.Bomb);
                    }
                    // If incorrectly flagged, show the NoBomb tile
                    if (tileState[r, c] == TileState.Nothing && displayedTile[r, c] == Tile.Flag)
                    {
                        displayedTile[r, c] = Tile.NoBomb;
                        changeGameboard(r, c, (int)Tile.NoBomb);
                    }
                }
            }

        }

        // Stop the game after a win condition
        private void win()
        {
            gameRunning = false;
            timCountUp.Stop();
            drawFace(Face.Sunglasses);
            if (soundState != SoundState.SoundDisabled)
                winSound.Play();

            // Set unflagged, unclicked bombs to flagged
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (tileState[r, c] == TileState.IsBomb)
                    {
                        displayedTile[r, c] = Tile.Flag;
                        changeGameboard(r, c, (int)Tile.Flag);
                    }
                }
            }
            
            // Just in case they weren't using flags, set the count to 0 (they found them all, we flagged anything that was unflagged)
            flagCount = 0;
            drawFlagCount();

            switch (difficulty)
            {
                case Difficulty.Beginner:
                    if (timerCount < time1)
                    {
                        HighscoreEntry hse = new HighscoreEntry();
                        hse.ShowDialog(this);
                        name1 = hse.txtName.Text;
                        time1 = timerCount;
                        HighscoreScreen hs = new HighscoreScreen();
                        hs.ShowDialog(this);
                    }
                    break;

                case Difficulty.Intermediate:
                    if (timerCount < time2)
                    {
                        HighscoreEntry hse = new HighscoreEntry();
                        hse.ShowDialog(this);
                        name2 = hse.txtName.Text;
                        time2 = timerCount;
                        HighscoreScreen hs = new HighscoreScreen();
                        hs.ShowDialog(this);
                    }
                    break;

                case Difficulty.Expert:
                    if (timerCount < time3)
                    {
                        HighscoreEntry hse = new HighscoreEntry();
                        hse.ShowDialog(this);
                        name3 = hse.txtName.Text;
                        time3 = timerCount;
                        HighscoreScreen hs = new HighscoreScreen();
                        hs.ShowDialog(this);
                    }
                    break;

                case Difficulty.Custom:
                default:
                    break;
            }

            saveScores();
        }

        // Used in handler for Game->Custom in toolstrip.  Gets and limits custom values for height, width, mines
        private void getCustomDifficulty()
        {
            if (!formLoaded)  // Don't run if the form isn't loaded yet (config loads before form)
                return;

            CustomDifficulty cd = new CustomDifficulty();
            DialogResult dRes = cd.ShowDialog(this);
            if (dRes == DialogResult.Cancel)  // If the user cancels, don't change anything
                return;

            // Get height and bound from 9 to 24
            int tmpHeight = GetTextboxInt(cd.txtHeight, 9);
            if (tmpHeight > 24)
                tmpHeight = 24;
            if (tmpHeight < 9)
                tmpHeight = 9;

            // Get width and bound from 9 to 30
            int tmpWidth = GetTextboxInt(cd.txtWidth, 9);
            if (tmpWidth > 30)
                tmpWidth = 30;
            if (tmpWidth < 9)
                tmpWidth = 9;

            // Get mines and bound from 10 to (height - 1) * (width - 1)
            int tmpMines = GetTextboxInt(cd.txtMines, 10);
            int maxMines = (tmpHeight - 1) * (tmpWidth - 1);
            if (tmpMines > maxMines)
                tmpMines = maxMines;
            if (tmpMines < 10)
                tmpMines = 10;

            // Set the appropriate values
            rows = tmpHeight;
            cols = tmpWidth;
            mineCount = tmpMines;
        }

        // Prevent the user from clicking a bomb on the first click
        private void moveBomb(int r, int c)
        {
            Random rand = new Random();
            bool spotFound = false;
            int newRow;
            int newCol;
            while (!spotFound)
            {
                newRow = rand.Next(rows);
                newCol = rand.Next(cols);
                if (tileState[newRow, newCol] == TileState.Nothing)
                {
                    spotFound = true;
                    tileState[newRow, newCol] = TileState.IsBomb;
                }
            }
            tileState[r, c] = TileState.Nothing;  // Do it after so the new bomb algorithm doesn't pick the same spot
        }
        #endregion GameManagement

        #region Saving
        // Load the config from the registry
        private void loadConfig()
        {
            RegistryKey winmineKey = getWinmineKey();

            color = (int)winmineKey.GetValue("Color", 1) == 1;
            difficulty = (Difficulty)winmineKey.GetValue("Difficulty", 0);
            rows = (int)winmineKey.GetValue("Height", 9);
            useQuestionMarks = (int)winmineKey.GetValue("Mark", 1) == 1;
            mineCount = (int)winmineKey.GetValue("Mines", 10);
            soundState = (SoundState)winmineKey.GetValue("Sound", 0);
            cols = (int)winmineKey.GetValue("Width", 9);
            int x = (int)winmineKey.GetValue("Xpos", 80);
            int y = (int)winmineKey.GetValue("Ypos", 80);
            initPos = new Point(x, y);

            // Make the displayed toolstrip consistent with the internal settings variables
            colorsToolStripMenuItem.Checked = color;
            soundToolStripMenuItem.Checked = soundState == SoundState.SoundEnabled || soundState == SoundState.SoundEnabledAlternate;
            marksToolStripMenuItem.Checked = useQuestionMarks;
            switch (difficulty)
            {
                case (Difficulty.Beginner):
                    beginnerToolStripMenuItem.PerformClick();
                    break;
                case (Difficulty.Intermediate):
                    intermediateToolStripMenuItem.PerformClick();
                    break;
                case (Difficulty.Expert):
                    expertToolStripMenuItem.PerformClick();
                    break;
                case (Difficulty.Custom):
                default:
                    customToolStripMenuItem.PerformClick();
                    break;
            }
        }

        // Save config to the registry
        private void saveConfig()
        {
            RegistryKey winmineKey = getWinmineKey();

            winmineKey.SetValue("Color", color ? 1 : 0);
            winmineKey.SetValue("Difficulty", (int)difficulty);
            winmineKey.SetValue("Height", rows);
            winmineKey.SetValue("Mark", useQuestionMarks ? 1 : 0);
            winmineKey.SetValue("Mines", mineCount);
            winmineKey.SetValue("Sound", (int)soundState);
            winmineKey.SetValue("Width", cols);
            winmineKey.SetValue("Xpos", this.Location.X);
            winmineKey.SetValue("Ypos", this.Location.Y);
        }

        // Load scores from the registry
        private void loadScores()
        {
            RegistryKey winmineKey = getWinmineKey();

            name1 = (string)winmineKey.GetValue("Name1", "Anonymous");
            name2 = (string)winmineKey.GetValue("Name2", "Anonymous");
            name3 = (string)winmineKey.GetValue("Name3", "Anonymous");
            time1 = (int)winmineKey.GetValue("Time1", 999);
            time2 = (int)winmineKey.GetValue("Time2", 999);
            time3 = (int)winmineKey.GetValue("Time3", 999);
        }

        // Save scores to the registry
        private void saveScores()
        {
            RegistryKey winmineKey = getWinmineKey();

            winmineKey.SetValue("Name1", name1);
            winmineKey.SetValue("Name2", name2);
            winmineKey.SetValue("Name3", name3);
            winmineKey.SetValue("Time1", time1);
            winmineKey.SetValue("Time2", time2);
            winmineKey.SetValue("Time3", time3);
        }

        // Reset the scores
        public void resetScores()
        {
            name1 = "Anonymous";
            name2 = "Anonymous";
            name3 = "Anonymous";
            time1 = 999;
            time2 = 999;
            time3 = 999;
            saveScores();
        }

        // Set up the registry keys used with default values
        private RegistryKey initRegistry()
        {
            RegistryKey hkcu = Registry.CurrentUser;
            RegistryKey microsoftKey = hkcu.OpenSubKey("SOFTWARE\\Microsoft", true);
            MessageBox.Show(microsoftKey.ToString());
            RegistryKey winmineKey = microsoftKey.CreateSubKey("winmine", true);
            if (winmineKey == null)  // I don't think CreateSubKey should return null, but it could, so check it
                throw new Exception();

            // Some basic default values
            winmineKey.SetValue("AlreadyPlayed", 1);
            winmineKey.SetValue("Color", 1);
            winmineKey.SetValue("Difficulty", 0);
            winmineKey.SetValue("Height", 9);
            winmineKey.SetValue("Mark", 1);
            winmineKey.SetValue("Mines", 10);
            winmineKey.SetValue("Name1", "Anonymous");
            winmineKey.SetValue("Name2", "Anonymous");
            winmineKey.SetValue("Name3", "Anonymous");
            winmineKey.SetValue("Sound", 0);
            winmineKey.SetValue("Time1", 999);
            winmineKey.SetValue("Time2", 999);
            winmineKey.SetValue("Time3", 999);
            winmineKey.SetValue("Width", 9);
            winmineKey.SetValue("Xpos", 80);
            winmineKey.SetValue("Ypos", 80);

            return winmineKey;
        }

        // Shortcut for getting the subkey, also does checks and initialization if needed
        private RegistryKey getWinmineKey()
        {
            RegistryKey winmineKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\winmine", true);
            if (winmineKey == null)  // If the subkey doesn't yet exist, make it and get a new reference
            {
                winmineKey = initRegistry();
            }
            if ((int)winmineKey.GetValue("AlreadyPlayed") != 1)
                initRegistry();
            return winmineKey;
        }
        #endregion Saving

        #region Helpers
        private int GetTextboxInt(TextBox txt, int defaultValue = 0)
        {
            bool success = int.TryParse(txt.Text, out int result);
            if (success)
            {
                return result;
            }
            else
            {
                txt.Text = defaultValue.ToString();
                return defaultValue;
            }
        }
        #endregion Helpers
    }
}
