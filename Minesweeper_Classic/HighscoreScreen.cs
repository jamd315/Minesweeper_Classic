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
        Form1 parent;  // Reference to Form1 object, requires .ShowDialog(this) from parent

        public HighscoreScreen()
        {
            InitializeComponent();
        }

        private void HighscoreScreen_Load(object sender, EventArgs e)
        {
            parent = (Form1)Owner;
            if (parent == null)
                throw new NullReferenceException();
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
