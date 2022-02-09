using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Button[,] buttons = new Button[7, 7];
        int score = 0;
        int counter = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();


            int top = 0;
            int left = 0;

            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j] = new Button();
                    buttons[i, j].Width = 80;
                    buttons[i, j].Height = 80;
                    buttons[i, j].BackColor = Color.LightBlue;
                    buttons[i, j].Name = rnd.Next(0, 2).ToString();
                    buttons[i, j].Top = top;
                    buttons[i, j].Left = left;
                    this.Controls.Add(buttons[i, j]);
                    left += 80;
                }
                left = 0;
                top += 80;
            }

            for (int i = 0; i <= buttons.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                {
                    buttons[i, j].Click += new EventHandler(buttons_Click);
                }
            }
        }
        private void buttons_Click(object sender, EventArgs e)
        {
            Button btn = (sender as Button);  // Hangi butona tıklandığını öğreniyoruz
            if(btn.Name=="0")
            {
                btn.BackColor = Color.Red;
                counter += 1;
                score -= 5;
                if(counter==3)
                {
                    MessageBox.Show("Game Over! Your score: " + score.ToString(), "To Inform");

                    for (int i = 0; i <= buttons.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= buttons.GetUpperBound(1); j++)
                        {
                            buttons[i, j].BackColor = Color.LightBlue;
                        }
                    }
                    counter = 0;
                    score = 0;
                }    
            }
            else
            {
                btn.BackColor = Color.Green;
                score += 10;
            }
        }
    }
}
