using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingZonderPong
{
    public partial class Form1 : Form
    {
        public int speed_left = 15;
        public int speed_top = 15;
        public int point = 0;

        public Form1()
        {
            InitializeComponent();

            timer1.Enabled = true;
            Cursor.Hide();

            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Bounds = Screen.PrimaryScreen.Bounds;

            racket.Top = playground.Bottom - (playground.Bottom / 10);
            gameOverLabel.Left = playground.Width / 2 - gameOverLabel.Width / 2;
            gameOverLabel.Top = playground.Height / 2 - gameOverLabel.Height / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += speed_left;
            ball.Top += speed_top;

            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 2;
                speed_left += 2;
                speed_top *= -1;
                point++;
                pointsCounter.Text = point.ToString();

                Random r = new Random();
                playground.BackColor = Color.FromArgb(r.Next(150, 250), r.Next(150, 250), r.Next(150, 250));
            }

            if (ball.Left <= playground.Left || ball.Right >= playground.Right)
            {
                speed_left *= -1;
            }
            if (ball.Top <= playground.Top)
            {
                speed_top *= -1;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                gameOverLabel.Visible = true;

            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyCode == Keys.R)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 20;
                speed_top = 20;
                point = 0;
                pointsCounter.Text = point.ToString();
                timer1.Enabled = true;
                gameOverLabel.Visible = false;
            }
        }
    }
}
