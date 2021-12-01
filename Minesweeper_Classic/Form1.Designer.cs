namespace Minesweeper_Classic
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timCountUp = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.beginnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intermediateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.marksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bestTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMinesweeperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlTimer = new System.Windows.Forms.Panel();
            this.picTimerO = new System.Windows.Forms.PictureBox();
            this.picTimerT = new System.Windows.Forms.PictureBox();
            this.picTimerH = new System.Windows.Forms.PictureBox();
            this.pnlFlagCount = new System.Windows.Forms.Panel();
            this.picFlagCountO = new System.Windows.Forms.PictureBox();
            this.picFlagCountT = new System.Windows.Forms.PictureBox();
            this.picFlagCountH = new System.Windows.Forms.PictureBox();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.imgFaces = new System.Windows.Forms.ImageList(this.components);
            this.imgFaces_BW = new System.Windows.Forms.ImageList(this.components);
            this.imgSevenSegment = new System.Windows.Forms.ImageList(this.components);
            this.imgSevenSegment_BW = new System.Windows.Forms.ImageList(this.components);
            this.imgTiles = new System.Windows.Forms.ImageList(this.components);
            this.imgTiles_BW = new System.Windows.Forms.ImageList(this.components);
            this.pnlGameboard = new System.Windows.Forms.Panel();
            this.picGameboard = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.pnlTimer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerH)).BeginInit();
            this.pnlFlagCount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.pnlGameboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picGameboard)).BeginInit();
            this.SuspendLayout();
            // 
            // timCountUp
            // 
            this.timCountUp.Interval = 1000;
            this.timCountUp.Tick += new System.EventHandler(this.timCountUp_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(164, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripSeparator1,
            this.beginnerToolStripMenuItem,
            this.intermediateToolStripMenuItem,
            this.expertToolStripMenuItem,
            this.customToolStripMenuItem,
            this.toolStripSeparator2,
            this.marksToolStripMenuItem,
            this.colorsToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.toolStripSeparator3,
            this.bestTimesToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeyDisplayString = "F2";
            this.newToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // beginnerToolStripMenuItem
            // 
            this.beginnerToolStripMenuItem.Checked = true;
            this.beginnerToolStripMenuItem.CheckOnClick = true;
            this.beginnerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.beginnerToolStripMenuItem.Name = "beginnerToolStripMenuItem";
            this.beginnerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.beginnerToolStripMenuItem.Text = "Beginner";
            this.beginnerToolStripMenuItem.Click += new System.EventHandler(this.beginnerToolStripMenuItem_Click);
            // 
            // intermediateToolStripMenuItem
            // 
            this.intermediateToolStripMenuItem.CheckOnClick = true;
            this.intermediateToolStripMenuItem.Name = "intermediateToolStripMenuItem";
            this.intermediateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.intermediateToolStripMenuItem.Text = "Intermediate";
            this.intermediateToolStripMenuItem.Click += new System.EventHandler(this.intermediateToolStripMenuItem_Click);
            // 
            // expertToolStripMenuItem
            // 
            this.expertToolStripMenuItem.CheckOnClick = true;
            this.expertToolStripMenuItem.Name = "expertToolStripMenuItem";
            this.expertToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.expertToolStripMenuItem.Text = "Expert";
            this.expertToolStripMenuItem.Click += new System.EventHandler(this.expertToolStripMenuItem_Click);
            // 
            // customToolStripMenuItem
            // 
            this.customToolStripMenuItem.Name = "customToolStripMenuItem";
            this.customToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.customToolStripMenuItem.Text = "Custom...";
            this.customToolStripMenuItem.Click += new System.EventHandler(this.customToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // marksToolStripMenuItem
            // 
            this.marksToolStripMenuItem.Checked = true;
            this.marksToolStripMenuItem.CheckOnClick = true;
            this.marksToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.marksToolStripMenuItem.Name = "marksToolStripMenuItem";
            this.marksToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.marksToolStripMenuItem.Text = "Marks (?)";
            this.marksToolStripMenuItem.Click += new System.EventHandler(this.marksToolStripMenuItem_Click);
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.Checked = true;
            this.colorsToolStripMenuItem.CheckOnClick = true;
            this.colorsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            this.colorsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorsToolStripMenuItem.Text = "Colors";
            this.colorsToolStripMenuItem.Click += new System.EventHandler(this.colorsToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.CheckOnClick = true;
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // bestTimesToolStripMenuItem
            // 
            this.bestTimesToolStripMenuItem.Name = "bestTimesToolStripMenuItem";
            this.bestTimesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bestTimesToolStripMenuItem.Text = "Best Times";
            this.bestTimesToolStripMenuItem.Click += new System.EventHandler(this.bestTimesToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem1,
            this.aboutMinesweeperToolStripMenuItem,
            this.test1ToolStripMenuItem,
            this.test2ToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.ShortcutKeyDisplayString = "F1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // aboutMinesweeperToolStripMenuItem
            // 
            this.aboutMinesweeperToolStripMenuItem.Name = "aboutMinesweeperToolStripMenuItem";
            this.aboutMinesweeperToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutMinesweeperToolStripMenuItem.Text = "About Minesweeper";
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.test1ToolStripMenuItem.Text = "Test1";
            this.test1ToolStripMenuItem.Click += new System.EventHandler(this.test1ToolStripMenuItem_Click);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.test2ToolStripMenuItem.Text = "Test2";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.pnlTimer);
            this.pnlHeader.Controls.Add(this.pnlFlagCount);
            this.pnlHeader.Controls.Add(this.picFace);
            this.pnlHeader.Location = new System.Drawing.Point(8, 32);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(148, 32);
            this.pnlHeader.TabIndex = 6;
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pnlHeader.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // pnlTimer
            // 
            this.pnlTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTimer.Controls.Add(this.picTimerO);
            this.pnlTimer.Controls.Add(this.picTimerT);
            this.pnlTimer.Controls.Add(this.picTimerH);
            this.pnlTimer.Location = new System.Drawing.Point(102, 3);
            this.pnlTimer.Name = "pnlTimer";
            this.pnlTimer.Size = new System.Drawing.Size(39, 23);
            this.pnlTimer.TabIndex = 3;
            // 
            // picTimerO
            // 
            this.picTimerO.Location = new System.Drawing.Point(26, 0);
            this.picTimerO.Margin = new System.Windows.Forms.Padding(0);
            this.picTimerO.Name = "picTimerO";
            this.picTimerO.Size = new System.Drawing.Size(13, 23);
            this.picTimerO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTimerO.TabIndex = 2;
            this.picTimerO.TabStop = false;
            this.picTimerO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picTimerO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picTimerT
            // 
            this.picTimerT.Location = new System.Drawing.Point(13, 0);
            this.picTimerT.Margin = new System.Windows.Forms.Padding(0);
            this.picTimerT.Name = "picTimerT";
            this.picTimerT.Size = new System.Drawing.Size(13, 23);
            this.picTimerT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTimerT.TabIndex = 1;
            this.picTimerT.TabStop = false;
            this.picTimerT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picTimerT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picTimerH
            // 
            this.picTimerH.Location = new System.Drawing.Point(0, 0);
            this.picTimerH.Margin = new System.Windows.Forms.Padding(0);
            this.picTimerH.Name = "picTimerH";
            this.picTimerH.Size = new System.Drawing.Size(13, 23);
            this.picTimerH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTimerH.TabIndex = 0;
            this.picTimerH.TabStop = false;
            this.picTimerH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picTimerH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // pnlFlagCount
            // 
            this.pnlFlagCount.Controls.Add(this.picFlagCountO);
            this.pnlFlagCount.Controls.Add(this.picFlagCountT);
            this.pnlFlagCount.Controls.Add(this.picFlagCountH);
            this.pnlFlagCount.Location = new System.Drawing.Point(3, 3);
            this.pnlFlagCount.Margin = new System.Windows.Forms.Padding(0);
            this.pnlFlagCount.Name = "pnlFlagCount";
            this.pnlFlagCount.Size = new System.Drawing.Size(39, 23);
            this.pnlFlagCount.TabIndex = 0;
            // 
            // picFlagCountO
            // 
            this.picFlagCountO.Location = new System.Drawing.Point(26, 0);
            this.picFlagCountO.Margin = new System.Windows.Forms.Padding(0);
            this.picFlagCountO.Name = "picFlagCountO";
            this.picFlagCountO.Size = new System.Drawing.Size(13, 23);
            this.picFlagCountO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFlagCountO.TabIndex = 2;
            this.picFlagCountO.TabStop = false;
            this.picFlagCountO.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picFlagCountO.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picFlagCountT
            // 
            this.picFlagCountT.Location = new System.Drawing.Point(13, 0);
            this.picFlagCountT.Margin = new System.Windows.Forms.Padding(0);
            this.picFlagCountT.Name = "picFlagCountT";
            this.picFlagCountT.Size = new System.Drawing.Size(13, 23);
            this.picFlagCountT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFlagCountT.TabIndex = 1;
            this.picFlagCountT.TabStop = false;
            this.picFlagCountT.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picFlagCountT.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picFlagCountH
            // 
            this.picFlagCountH.Location = new System.Drawing.Point(0, 0);
            this.picFlagCountH.Margin = new System.Windows.Forms.Padding(0);
            this.picFlagCountH.Name = "picFlagCountH";
            this.picFlagCountH.Size = new System.Drawing.Size(13, 23);
            this.picFlagCountH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFlagCountH.TabIndex = 0;
            this.picFlagCountH.TabStop = false;
            this.picFlagCountH.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picFlagCountH.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picFace
            // 
            this.picFace.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.picFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFace.InitialImage = null;
            this.picFace.Location = new System.Drawing.Point(59, 1);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(26, 26);
            this.picFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picFace.TabIndex = 1;
            this.picFace.TabStop = false;
            this.picFace.Click += new System.EventHandler(this.picFace_Click);
            this.picFace.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFace_MouseDown);
            this.picFace.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picFace_MouseUp);
            // 
            // imgFaces
            // 
            this.imgFaces.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFaces.ImageStream")));
            this.imgFaces.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFaces.Images.SetKeyName(0, "face_dead.png");
            this.imgFaces.Images.SetKeyName(1, "face_oh.png");
            this.imgFaces.Images.SetKeyName(2, "face_smile.png");
            this.imgFaces.Images.SetKeyName(3, "face_smile_pressed.png");
            this.imgFaces.Images.SetKeyName(4, "face_sunglasses.png");
            // 
            // imgFaces_BW
            // 
            this.imgFaces_BW.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFaces_BW.ImageStream")));
            this.imgFaces_BW.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFaces_BW.Images.SetKeyName(0, "BW_face_dead.bmp");
            this.imgFaces_BW.Images.SetKeyName(1, "BW_face_oh.bmp");
            this.imgFaces_BW.Images.SetKeyName(2, "BW_face_smile.bmp");
            this.imgFaces_BW.Images.SetKeyName(3, "BW_face_smile_pressed.bmp");
            this.imgFaces_BW.Images.SetKeyName(4, "BW_face_sunglasses.bmp");
            // 
            // imgSevenSegment
            // 
            this.imgSevenSegment.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSevenSegment.ImageStream")));
            this.imgSevenSegment.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSevenSegment.Images.SetKeyName(0, "seven_segment_0.png");
            this.imgSevenSegment.Images.SetKeyName(1, "seven_segment_1.png");
            this.imgSevenSegment.Images.SetKeyName(2, "seven_segment_2.png");
            this.imgSevenSegment.Images.SetKeyName(3, "seven_segment_3.png");
            this.imgSevenSegment.Images.SetKeyName(4, "seven_segment_4.png");
            this.imgSevenSegment.Images.SetKeyName(5, "seven_segment_5.png");
            this.imgSevenSegment.Images.SetKeyName(6, "seven_segment_6.png");
            this.imgSevenSegment.Images.SetKeyName(7, "seven_segment_7.png");
            this.imgSevenSegment.Images.SetKeyName(8, "seven_segment_8.png");
            this.imgSevenSegment.Images.SetKeyName(9, "seven_segment_9.png");
            this.imgSevenSegment.Images.SetKeyName(10, "seven_segment_blank.png");
            this.imgSevenSegment.Images.SetKeyName(11, "seven_segment_dash.png");
            // 
            // imgSevenSegment_BW
            // 
            this.imgSevenSegment_BW.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSevenSegment_BW.ImageStream")));
            this.imgSevenSegment_BW.TransparentColor = System.Drawing.Color.Transparent;
            this.imgSevenSegment_BW.Images.SetKeyName(0, "BW_seven_segment_0.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(1, "BW_seven_segment_1.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(2, "BW_seven_segment_2.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(3, "BW_seven_segment_3.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(4, "BW_seven_segment_4.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(5, "BW_seven_segment_5.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(6, "BW_seven_segment_6.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(7, "BW_seven_segment_7.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(8, "BW_seven_segment_8.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(9, "BW_seven_segment_9.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(10, "BW_seven_segment_blank.bmp");
            this.imgSevenSegment_BW.Images.SetKeyName(11, "BW_seven_segment_dash.bmp");
            // 
            // imgTiles
            // 
            this.imgTiles.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTiles.ImageStream")));
            this.imgTiles.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTiles.Images.SetKeyName(0, "tile_blank.png");
            this.imgTiles.Images.SetKeyName(1, "tile_1.png");
            this.imgTiles.Images.SetKeyName(2, "tile_2.png");
            this.imgTiles.Images.SetKeyName(3, "tile_3.png");
            this.imgTiles.Images.SetKeyName(4, "tile_4.png");
            this.imgTiles.Images.SetKeyName(5, "tile_5.png");
            this.imgTiles.Images.SetKeyName(6, "tile_6.png");
            this.imgTiles.Images.SetKeyName(7, "tile_7.png");
            this.imgTiles.Images.SetKeyName(8, "tile_8.png");
            this.imgTiles.Images.SetKeyName(9, "tile_bomb.png");
            this.imgTiles.Images.SetKeyName(10, "tile_bomb_clicked.png");
            this.imgTiles.Images.SetKeyName(11, "tile_flag.png");
            this.imgTiles.Images.SetKeyName(12, "tile_nobomb.png");
            this.imgTiles.Images.SetKeyName(13, "tile_question.png");
            this.imgTiles.Images.SetKeyName(14, "tile_question_unclicked.png");
            this.imgTiles.Images.SetKeyName(15, "tile_unclicked.png");
            // 
            // imgTiles_BW
            // 
            this.imgTiles_BW.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgTiles_BW.ImageStream")));
            this.imgTiles_BW.TransparentColor = System.Drawing.Color.Transparent;
            this.imgTiles_BW.Images.SetKeyName(0, "BW_tile_blank.bmp");
            this.imgTiles_BW.Images.SetKeyName(1, "BW_tile_1.bmp");
            this.imgTiles_BW.Images.SetKeyName(2, "BW_tile_2.bmp");
            this.imgTiles_BW.Images.SetKeyName(3, "BW_tile_3.bmp");
            this.imgTiles_BW.Images.SetKeyName(4, "BW_tile_4.bmp");
            this.imgTiles_BW.Images.SetKeyName(5, "BW_tile_5.bmp");
            this.imgTiles_BW.Images.SetKeyName(6, "BW_tile_6.bmp");
            this.imgTiles_BW.Images.SetKeyName(7, "BW_tile_7.bmp");
            this.imgTiles_BW.Images.SetKeyName(8, "BW_tile_8.bmp");
            this.imgTiles_BW.Images.SetKeyName(9, "BW_tile_bomb.bmp");
            this.imgTiles_BW.Images.SetKeyName(10, "BW_tile_bomb_clicked.bmp");
            this.imgTiles_BW.Images.SetKeyName(11, "BW_tile_flag.bmp");
            this.imgTiles_BW.Images.SetKeyName(12, "BW_tile_nobomb.bmp");
            this.imgTiles_BW.Images.SetKeyName(13, "BW_tile_question.bmp");
            this.imgTiles_BW.Images.SetKeyName(14, "BW_tile_question_unclicked.bmp");
            this.imgTiles_BW.Images.SetKeyName(15, "BW_tile_unclicked.bmp");
            // 
            // pnlGameboard
            // 
            this.pnlGameboard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlGameboard.Controls.Add(this.picGameboard);
            this.pnlGameboard.Location = new System.Drawing.Point(7, 72);
            this.pnlGameboard.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGameboard.Name = "pnlGameboard";
            this.pnlGameboard.Size = new System.Drawing.Size(148, 148);
            this.pnlGameboard.TabIndex = 2;
            this.pnlGameboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.pnlGameboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // picGameboard
            // 
            this.picGameboard.Location = new System.Drawing.Point(0, 0);
            this.picGameboard.Name = "picGameboard";
            this.picGameboard.Size = new System.Drawing.Size(144, 144);
            this.picGameboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picGameboard.TabIndex = 0;
            this.picGameboard.TabStop = false;
            this.picGameboard.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.picGameboard.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(164, 229);
            this.Controls.Add(this.pnlGameboard);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Control_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Control_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTimer.ResumeLayout(false);
            this.pnlTimer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTimerH)).EndInit();
            this.pnlFlagCount.ResumeLayout(false);
            this.pnlFlagCount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFlagCountH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.pnlGameboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picGameboard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timCountUp;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem beginnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intermediateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem marksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem bestTimesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutMinesweeperToolStripMenuItem;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.ImageList imgFaces;
        private System.Windows.Forms.ImageList imgFaces_BW;
        private System.Windows.Forms.ImageList imgSevenSegment;
        private System.Windows.Forms.ImageList imgSevenSegment_BW;
        private System.Windows.Forms.ImageList imgTiles;
        private System.Windows.Forms.ImageList imgTiles_BW;
        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Panel pnlGameboard;
        private System.Windows.Forms.Panel pnlFlagCount;
        private System.Windows.Forms.PictureBox picFlagCountO;
        private System.Windows.Forms.PictureBox picFlagCountT;
        private System.Windows.Forms.PictureBox picFlagCountH;
        private System.Windows.Forms.Panel pnlTimer;
        private System.Windows.Forms.PictureBox picTimerO;
        private System.Windows.Forms.PictureBox picTimerT;
        private System.Windows.Forms.PictureBox picTimerH;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.PictureBox picGameboard;
    }
}

