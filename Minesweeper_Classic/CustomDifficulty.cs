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
    public partial class CustomDifficulty : Form
    {
        public CustomDifficulty()
        {
            InitializeComponent();
        }

        private void CustomDifficulty_Load(object sender, EventArgs e)
        {
            MainGame parent = (MainGame)Owner;
            if (parent == null)
                throw new NullReferenceException();

            this.Location = parent.Location;
        }
    }
}
