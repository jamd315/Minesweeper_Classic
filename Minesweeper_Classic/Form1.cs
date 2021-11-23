using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper_Classic
{
    public partial class Form1 : Form
    {
        private bool color = true;

        private int timerCount = 0;
        private int bombCount = 10;
        private int flagCount;
        private int rows = 9;
        private int cols = 9;
        private int unclickedRemaining;
        private bool gameRunning = true;

        private Tiles[,] gameboard;         // Array of displayed tiles
        private TileState[,] tileState;     // Whether the tile is a bomb or not
        private Bitmap gameboardBmp;        // The gameboard image displayed in picGameboard
        private Graphics gameboardGraphic;  // Edits gameboardBmp

        private enum Faces: int  // Used with imgFaces, imgFaces_BW
        {
            Dead = 0,
            Oh = 1,
            Smile = 2,
            SmilePressed = 3,
            Sunglasses = 4
        }

        private enum Tiles: int  // Used with imgTiles, imgTiles_BW, state management
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

        public Form1()
        {
            InitializeComponent();
        }

        private void timCountUp_Tick(object sender, EventArgs e)
        {
            timerCount++;
            drawTimer();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            newGame();
        }

        #region Toolstrip
        private void beginnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = true;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
        }

        private void intermediateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = true;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = false;
        }

        private void expertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = true;
            customToolStripMenuItem.Checked = false;
        }

        private void customToolStripMenuItem_Click(object sender, EventArgs e)
        {
            beginnerToolStripMenuItem.Checked = false;
            intermediateToolStripMenuItem.Checked = false;
            expertToolStripMenuItem.Checked = false;
            customToolStripMenuItem.Checked = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bestTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HighscoreScreen hs = new HighscoreScreen();
            hs.ShowDialog();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();
        }
        #endregion Toolstrip

        #region FaceManagement
        // Pair of functions to be used with any control that can flip the face if clicked
        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!gameRunning)
                return;
            drawFace(Faces.Oh);
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            if (!gameRunning)
                return;
            drawFace(Faces.Smile);

            if (sender == picGameboard)
            {
                gameboardClicked(sender, e);
            }
        }

        // Do a separate pair of functions for if the button is actually pressed
        private void picFace_MouseDown(object sender, MouseEventArgs e)
        {
            drawFace(Faces.SmilePressed);
        }

        private void picFace_MouseUp(object sender, MouseEventArgs e)
        {
            drawFace(Faces.Smile);
        }

        // Full click to do new game
        private void picFace_Click(object sender, EventArgs e)
        {
            newGame();
        }
        #endregion FaceManagement

        #region Drawing
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

        private void drawFlagCount()
        {
            int hundreds = (flagCount % 1000 - flagCount % 100) / 100;
            int tens = (flagCount % 100 - flagCount % 10) / 10;
            int ones = flagCount % 10;
            ImageList imList;
            if (color)
                imList = imgSevenSegment;
            else
                imList = imgSevenSegment_BW;
            if (picFlagCountH.Image != null)
                picFlagCountH.Image.Dispose();
            picFlagCountH.Image = imList.Images[hundreds];
            if (picFlagCountT.Image != null)
                picFlagCountT.Image.Dispose();
            picFlagCountT.Image = imList.Images[tens];
            if (picFlagCountO.Image != null)
                picFlagCountO.Image.Dispose();
            picFlagCountO.Image = imList.Images[ones];
        }

        private void drawFace(Faces f)
        {
            if (picFace.Image != null)
                picFace.Image.Dispose();
            picFace.Image = imgFaces.Images[(int)f];
        }

        // Render gameboard to a single image to improve performance
        private void drawGameboard()
        {
            if (gameboardBmp != null)
                gameboardBmp.Dispose();
            gameboardBmp = new Bitmap(cols * 16, rows * 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            if (gameboardGraphic != null)
                gameboardGraphic.Dispose();
            gameboardGraphic = Graphics.FromImage(gameboardBmp);
            // Just copy the source pixels as quickly as possible
            gameboardGraphic.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            // Not really sure what I want, just a direct copy so I went with AssumeLinear.  Could also use GammaCorrected or HighSpeed
            // https://docs.microsoft.com/en-us/dotnet/api/system.drawing.drawing2d.compositingquality?view=netframework-4.7.1
            gameboardGraphic.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.AssumeLinear;

            Point pt = new Point();
            for (int r = 0; r < rows * 16; r += 16)
            {
                for (int c = 0; c < cols * 16; c += 16)
                {
                    pt.X = c;
                    pt.Y = r;
                    imgTiles.Draw(gameboardGraphic, pt, (int)Tiles.Unclicked);
                }
            }

            picGameboard.Image = gameboardBmp;
        }

        private void changeGameboard(int r, int c, ImageList il, int index)
        {
            Point pt = new Point(16 * c, 16 * r);
            il.Draw(gameboardGraphic, pt, index);
            picGameboard.Image = gameboardBmp;
        }
        #endregion Drawing

        #region GameManagement
        private int getMineCount(int r, int c)
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

        private void newGame()
        {
            // Init the variables
            timCountUp.Stop();
            timerCount = 0;
            gameRunning = true;
            unclickedRemaining = rows * cols;
            flagCount = bombCount;
            drawFlagCount();
            drawTimer();
            drawFace(Faces.Smile);

            // Init gameboard to keep track of game state
            drawGameboard();
            gameboard = new Tiles[rows, cols];
            tileState = new TileState[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    gameboard[r, c] = Tiles.Unclicked;
                    tileState[r, c] = TileState.Nothing;
                }
            }
            
            // Add bombs
            int bombsAdded = 0;
            Random rand = new Random();
            while (bombsAdded != bombCount)  // Prevents adding bombs to an already bombed spot
            {
                int bombRow = rand.Next(rows);
                int bombCol = rand.Next(cols);
                if (tileState[bombRow, bombCol] != TileState.IsBomb)
                {
                    tileState[bombRow, bombCol] = TileState.IsBomb;
                }
                bombsAdded++;
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

            //MessageBox.Show($"Clicked (x={me.X}, y={me.Y}) row {row}, col {col}");

            if (me.Button == MouseButtons.Left)
            {
                if (!timCountUp.Enabled)  // Enable timer after first click
                    timCountUp.Start();

                if (gameboard[row, col] == Tiles.Flag)  // Don't click flags
                    return;

                // Switch based on the state of the clicked tile
                if (gameboard[row, col] == Tiles.Unclicked)
                {
                    int nearbyBombs = getMineCount(row, col);
                    changeGameboard(row, col, imgTiles, nearbyBombs);
                    gameboard[row, col] = (Tiles)nearbyBombs;
                    if (nearbyBombs == 0)
                    {
                        clickAllAdjacent(row, col, me);
                    }
                    unclickedRemaining--;
                    if (unclickedRemaining == bombCount)
                    {
                        win();
                    }
                }
                if (tileState[row, col] == TileState.IsBomb)
                {
                    gameOver();
                    changeGameboard(row, col, imgTiles, (int)Tiles.BombClicked);
                }
            }
            else if (me.Button == MouseButtons.Right)
            {

                switch (gameboard[row, col])
                {
                    case Tiles.Unclicked:  // Unclicked, make it a flag
                        changeGameboard(row, col, imgTiles, (int)Tiles.Flag);
                        gameboard[row, col] = Tiles.Flag;
                        flagCount--;
                        drawFlagCount();
                        break;
                    case Tiles.Flag:  // Flag, make it a question
                        changeGameboard(row, col, imgTiles, (int)Tiles.QuestionUnclicked);
                        gameboard[row, col] = Tiles.QuestionUnclicked;
                        flagCount++;
                        drawFlagCount();
                        break;
                    case Tiles.Question:
                    case Tiles.QuestionUnclicked:  // Question, make it unclicked
                        changeGameboard(row, col, imgTiles, (int)Tiles.Unclicked);
                        gameboard[row, col] = Tiles.Unclicked;
                        break;
                }
            }
        }

        // Used when a 0 adjacency tile is clicked to flood fill
        private void clickAllAdjacent(int r, int c, MouseEventArgs initialArgs)
        {
            MouseEventArgs me;
            if (r != rows - 1)  // South
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X, initialArgs.Y + 16, 0);
                gameboardClicked(null, me);
            }
            if (r != 0)  // North
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X, initialArgs.Y - 16, 0);
                gameboardClicked(null, me);
            }
            if (c != cols - 1)  // East
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y, 0);
                gameboardClicked(null, me);
            }
            if (c != 0)  // West
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y, 0);
                gameboardClicked(null, me);
            }
            if (r != rows - 1 && c != cols - 1)  // Southeast
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y + 16, 0);
                gameboardClicked(null, me);
            }
            if (r != rows - 1 && c != 0)  // Southwest
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y + 16, 0);
                gameboardClicked(null, me);
            }
            if (r != 0 && c != cols - 1)  // Northeast
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X + 16, initialArgs.Y - 16, 0);
                gameboardClicked(null, me);
            }
            if (r != 0 && c != 0)  // Northwest
            {
                me = new MouseEventArgs(MouseButtons.Left, 1, initialArgs.X - 16, initialArgs.Y - 16, 0);
                gameboardClicked(null, me);
            }
        }

        private void gameOver()
        {
            // Reveal un-flagged bombs
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // If a bomb is hidden, but not flagged, reveal it
                    if (tileState[r, c] == TileState.IsBomb && gameboard[r, c] != Tiles.Flag)
                    {
                        changeGameboard(rows, cols, imgTiles, (int)Tiles.Bomb);
                    }
                }
            }

            gameRunning = false;
            timCountUp.Stop();
            drawFace(Faces.Dead);
        }

        public void win()
        {
            gameRunning = false;
            timCountUp.Stop();
            drawFace(Faces.Sunglasses);

            // Set unflagged, unclicked bombs to flagged
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (tileState[r, c] == TileState.IsBomb)
                    {
                        gameboard[r, c] = Tiles.Flag;
                        changeGameboard(r, c, imgTiles, (int)Tiles.Flag);
                    }
                }
            }
            // TODO win sound
            // TODO high score storage
        }
        #endregion GameManagement

        #region Debug
        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test1");
            win();
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test2");
            drawGameboard();
        }
        #endregion Debug
    }
}
