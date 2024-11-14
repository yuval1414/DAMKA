using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class GamePanel : Form
    {
        public GamePanel()
        {
            InitializeComponent();
        }

        private void checkBoxPlayer2_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
            {
                textBox2.Enabled = true;
                textBox2.Text = "";
            }
            else
            {
                textBox2.Enabled = false;
                textBox2.Text = "[Computer]";
            }
        }

        private void buttonDone_MouseClick(object sender, MouseEventArgs e)
        {
            int boardSize = 0;
            int playersNumber = 1;

            if(radioButton6X6.Checked == true)
            {
                boardSize = 6;
            }
            else if (radioButton8X8.Checked == true)
            {
                boardSize = 8;
            }
            else if(radioButton10X10.Checked == true)
            {
                boardSize = 10;
            }

            if(checkBoxPlayer2.Checked == true)
            {
                playersNumber = 2;
            }

            UI.BoardGame boardGame = new UI.BoardGame(boardSize, playersNumber, this.textBox1.Text, this.textBox2.Text);
            boardGame.Show();
            this.Hide();
        }
    }
}
