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
        private int rows = 9;
        private int cols = 9;

        private PictureBox[,] gameboardPics;
        private Tiles[,] gameboard;

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
            Unclicked = 15,
            HiddenBomb = 16
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
            picFace.Image = imgFaces.Images[(int)Faces.Smile];
            drawBombCount();
            drawTimer();
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
            picFace.Image = imgFaces.Images[(int)Faces.Oh];
        }

        private void Control_MouseUp(object sender, MouseEventArgs e)
        {
            picFace.Image = imgFaces.Images[(int)Faces.Smile];
        }

        // Do a separate pair of functions for if the button is actually pressed
        private void picFace_MouseDown(object sender, MouseEventArgs e)
        {
            picFace.Image = imgFaces.Images[(int)Faces.SmilePressed];
        }

        private void picFace_MouseUp(object sender, MouseEventArgs e)
        {
            picFace.Image = imgFaces.Images[(int)Faces.Smile];
        }

        // Full click to do new game
        private void picFace_Click(object sender, EventArgs e)
        {
            newGame();
        }
        #endregion FaceManagement

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
            picTimerH.Image = imList.Images[hundreds];
            picTimerT.Image = imList.Images[tens];
            picTimerO.Image = imList.Images[ones];
        }

        private void drawBombCount()
        {
            int hundreds = (bombCount % 1000 - bombCount % 100) / 100;
            int tens = (bombCount % 100 - bombCount % 10) / 10;
            int ones = bombCount % 10;
            ImageList imList;
            if (color)
                imList = imgSevenSegment;
            else
                imList = imgSevenSegment_BW;
            picBombCountH.Image = imList.Images[hundreds];
            picBombCountT.Image = imList.Images[tens];
            picBombCountO.Image = imList.Images[ones];
        }

        private int getMineCount(int r, int c)
        {
            int count = 0;
            if (r != 0 && c != 0 && gameboard[r - 1, c - 1] == Tiles.HiddenBomb)
                count++;
            if (r != 0 && gameboard[r - 1, c] == Tiles.HiddenBomb)
                count++;
            if (r != 0 && c != cols - 1 && gameboard[r - 1, c + 1] == Tiles.HiddenBomb)
                count++;
            if (c != 0 && gameboard[r, c - 1] == Tiles.HiddenBomb)
                count++;
            if (c != cols - 1 && gameboard[r, c + 1] == Tiles.HiddenBomb)
                count++;
            if (r != rows - 1  && c != 0 && gameboard[r + 1, c - 1] == Tiles.HiddenBomb)
                count++;
            if (r != rows - 1 && gameboard[r + 1, c] == Tiles.HiddenBomb)
                count++;
            if (r != rows - 1 && c != cols - 1 && gameboard[r + 1, c + 1] == Tiles.HiddenBomb)
                count++;
            return count;
        }

        private void newGame()
        {
            // Init the variables
            timerCount = 0;
            drawBombCount();
            drawTimer();

            // Init gameboard to keep track of game state
            // Also set up pictureboxes
            gameboard = new Tiles[rows, cols];
            if (gameboardPics != null)  // Clear before creating new one, use old array dims instead of this.rows, this.cols in case those changed
            {
                for (int r = 0; r < gameboardPics.GetLength(0); r++)
                {
                    for (int c = 0; c < gameboardPics.GetLength(1); c++)
                    {
                        pnlGameboard.Controls.Remove(gameboardPics[r, c]);
                        gameboardPics[r, c].Dispose();
                    }
                }
            }
            gameboardPics = new PictureBox[rows, cols];
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    gameboard[r, c] = Tiles.Unclicked;

                    gameboardPics[r, c] = new PictureBox();
                    pnlGameboard.Controls.Add(gameboardPics[r, c]);
                    gameboardPics[r, c].Image = imgTiles.Images[(int)Tiles.Unclicked];
                    gameboardPics[r, c].SizeMode = PictureBoxSizeMode.AutoSize;
                    gameboardPics[r, c].Location = new Point(16 * c, 16 * r);
                    gameboardPics[r, c].Name = $"picGameboard_{r},{c}";  // Gets parsed later
                    gameboardPics[r, c].Click += gameboardClicked;
                    gameboardPics[r, c].MouseDown += Control_MouseDown;
                    gameboardPics[r, c].MouseUp += Control_MouseUp;
                }
            }
            
            // Add bombs
            int bombsAdded = 0;
            Random rand = new Random();
            while (bombsAdded != bombCount)  // Prevents adding bombs to an already bombed spot
            {
                int bombRow = rand.Next(rows);
                int bombCol = rand.Next(cols);
                if (gameboard[bombRow, bombCol] == Tiles.Unclicked)
                {
                    gameboard[bombRow, bombCol] = Tiles.HiddenBomb;
                }
                bombsAdded++;
            }
        }

        private void gameboardClicked(object sender, EventArgs e)
        {
            PictureBox clicked = (PictureBox)sender;
            string location = clicked.Name.Substring(13);  // length of "picGameboard_"
            int row = int.Parse(location.Substring(0, location.IndexOf(',')));
            int col = int.Parse(location.Substring(location.IndexOf(',') + 1));

            MouseEventArgs me = (MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                if (!timCountUp.Enabled)  // Enable timer after first click
                    timCountUp.Start();

                switch (gameboard[row, col])
                {
                    case Tiles.Unclicked:
                        int nearbyBombs = getMineCount(row, col);
                        clicked.Image = imgTiles.Images[nearbyBombs];
                        gameboard[row, col] = (Tiles)nearbyBombs;
                        if (nearbyBombs == 0)
                        {
                            clickAllAdjacent(row, col);
                        }
                        break;
                    case Tiles.HiddenBomb:
                        clicked.Image = imgTiles.Images[(int)Tiles.BombClicked];
                        break;
                    case Tiles.Blank:
                    case Tiles.Tile1:
                    case Tiles.Tile2:
                    case Tiles.Tile3:
                    case Tiles.Tile4:
                    case Tiles.Tile5:
                    case Tiles.Tile6:
                    case Tiles.Tile7:
                    case Tiles.Tile8:
                    case Tiles.Flag:
                        // Do nothing
                        break;
                }
            }
            else if (me.Button == MouseButtons.Right)
            {
                // TODO this doesn't work, maybe try something with tags to keep track of image state?
                switch (clicked.Tag)
                {
                    case null:
                    case "U":
                        clicked.Image = imgTiles.Images[(int)Tiles.Flag];
                        clicked.Tag = "F";
                        break;
                    case "F":
                        clicked.Image = imgTiles.Images[(int)Tiles.QuestionUnclicked];
                        clicked.Tag = "Q";
                        break;
                    case "Q":
                        clicked.Image = imgTiles.Images[(int)Tiles.Unclicked];
                        clicked.Tag = "U";
                        break;
                    default:
                        clicked.Image = imgTiles.Images[(int)Tiles.NoBomb];
                        break;
                }
            }
        }

        // Used when a 0 adjacency tile is clicked to flood fill
        private void clickAllAdjacent(int r, int c)
        {
            MouseEventArgs fakeArgs = new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0);

            if (r != rows - 1)
                gameboardClicked(gameboardPics[r + 1, c], fakeArgs);
            if (r != 0)
                gameboardClicked(gameboardPics[r - 1, c], fakeArgs);
            if (c != cols - 1)
                gameboardClicked(gameboardPics[r, c + 1], fakeArgs);
            if (c != 0)
                gameboardClicked(gameboardPics[r, c - 1], fakeArgs);
        }






        private void test1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test1");
        }

        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test2");
        }
    }
}
