using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PongGame
{
    public partial class Form2 : Form
    {
        public int speed_left = 4; //Speed of the ball
        public int speed_top = 4;
        public int point = 0;
        
        public Form2()
        {
            InitializeComponent();
            //this.KeyPreview = true; //http://stackoverflow.com/questions/3172731/forms-not-responding-to-keydown-events
            timer1.Enabled = true;
            Cursor.Hide();
            //this.FormBorderStyle = FormBorderStyle.None; // remove borders
            this.TopMost = true; // bring form to the front
            this.Bounds = Screen.PrimaryScreen.Bounds;  // Full screen
            racket.Top = playground.Bottom - (playground.Bottom / 10); // sets position of racket
        }

        private void timer1_Tick(object sender, EventArgs e) {

            racket.Left = Cursor.Position.X - (racket.Width/2);
            // Move the ball
            ball.Left += speed_left;
            ball.Top += speed_top;

			if(ball.Bounds.IntersectsWith(racket.Bounds)){
				speed_top += 2;
                speed_left += 2;
                speed_top= -speed_top; // Change direction
                point+=1;
            }

            if (ball.Left <= playground.Left|| ball.Right >= playground.Right) 
            {
                speed_left = -speed_left;
            }

           // if (ball.Right >= playground.Right) { speed_left = -speed_left; }

            if (ball.Top <= playground.Top) { speed_top = -speed_top; }

            if (ball.Bottom>= playground.Bottom){
                timer1.Enabled = false; // Game over
            }
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.Control && e.Alt && e.KeyCode == Keys.O)
            {
                Cursor.Show();
                MessageBox.Show("Magic!");
            }
        }

    }

    
}
