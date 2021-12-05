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
    public partial class HighscoreScreen : Form
    {
        MainGame parent;  // Reference to Form1 object, requires .ShowDialog(this) from parent

        public HighscoreScreen()
        {
            InitializeComponent();
        }

        private void HighscoreScreen_Load(object sender, EventArgs e)
        {
            parent = (MainGame)Owner;
            if (parent == null)
                throw new NullReferenceException();

            Point initLocation = parent.Location;
            initLocation.X += 8;
            initLocation.Y += 100;
            this.Location = initLocation;

            displayScores();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            parent.resetScores();
            displayScores();
        }

        private void displayScores()
        {
            lblBeginnerName.Text = parent.name1;
            lblIntermediateName.Text = parent.name2;
            lblExpertName.Text = parent.name3;
            lblBeginnerTime.Text = parent.time1.ToString() + " seconds";
            lblIntermediateTime.Text = parent.time2.ToString() + " seconds";
            lblExpertTime.Text = parent.time3.ToString() + " seconds";
        }
    }
}
