using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple
{
    public partial class Form1 : Form
    {

        bool goRight, goLeft, jumping;


        int playerSpeed = 10;
        int jumpSpeed = 10;
        int force = 8;
        int score = 0;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
            }
          
            if (e.KeyCode == Keys.D)
            {
                goRight = true;     
            }
            if (e.KeyCode == Keys.Space && !jumping)
            {
                jumping = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                GameRestart();
            }
        }

        private void GameTimeEvent(object sender, EventArgs e)
        {
            player.Top += jumpSpeed;
          
            

            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goLeft)
            {
                player.Left -= 5;
            }
            if (goRight)
            {
                player.Left += 5;
            }
            if (jumping)
            {
                jumpSpeed = -11;
                force -= 1;
            }
            else
            {
                jumpSpeed = 11;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "platform")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }

                if (x.Tag == "home")
                {              
                   if (player.Bounds.IntersectsWith(home.Bounds))
                    {
                        GameTime.Stop();
                        MessageBox.Show("You WIN");                       
                        this.Hide();

                        var lvl2 = new Form2();
                        lvl2.Show();

                        var l1 = new Form1();
                        l1.Close();
                    }

                }

                if (x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        GameTime.Stop();
                        MessageBox.Show("You Deid");
                        
                       

                        GameRestart();
                    }

                }



            }
        }

        private void onClose(object sender, EventArgs e)
        {
           // Application.Exit();
        }

        private void KeyIsUP(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }     
            
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (jumping)
            {
                jumping = false;
            }

        }

        private void GameRestart()
        {
            player.Left = 114;
            player.Top = 377;

            enemy1.Left = 221;
            enemy1.Top = 406;


            GameTime.Start();
           
        }




    }
}
