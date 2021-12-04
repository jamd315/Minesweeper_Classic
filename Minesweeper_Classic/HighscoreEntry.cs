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
    public partial class HighscoreEntry : Form
    {
        public HighscoreEntry()
        {
            InitializeComponent();
        }

        private void HighscoreEntry_Load(object sender, EventArgs e)
        {
            MainGame parent = (MainGame)Owner;
            if (parent == null)
                throw new NullReferenceException();

            Point initLocation = parent.Location;
            initLocation.X += 8;
            initLocation.Y += 100;
            this.Location = initLocation;

            lblPrompt.Text = $"You have the fastest time for\n{parent.difficulty.ToString().ToLower()} level.\nPlease enter your name.";
        }
    }
}
