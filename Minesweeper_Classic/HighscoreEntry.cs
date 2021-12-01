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
            
            lblPrompt.Text = $"You have the fastest time for\n{Form1.difficulty.ToString().ToLower()} level.\nPlease enter your name.";
        }
    }
}
