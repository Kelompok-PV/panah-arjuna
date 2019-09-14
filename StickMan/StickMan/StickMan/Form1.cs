using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StickMan
{
    public partial class Form1 : Form
    {
        player pl;
        public Form1()
        {
            InitializeComponent();
            globalConfig.height = this.Height;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pl = new player("stick.png",400,200,200,200);
            this.DoubleBuffered = true;
        }
        List<arrow> arrows = new List<arrow>();
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            pl.draw(g);

            if(arrows.Count > -1)
            {
                for (int i = 0; i < arrows.Count; i++)
                {
                    arrows[i].draw(g);
                }
            }
        }
        
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            Random rand = new Random();

            int randx = rand.Next(this.Width);
            arrows.Add(new arrow("Resources\\arrow.jpg", randx, 0, 10, 10));
        }

        public void cek()
        {

            for (int i = 0; i < arrows.Count; i++)
            {
                arrows[i].y += arrows[i].dy;
                arrows[i].geser(arrows[i].y);
                if (arrows[i].y > globalConfig.height-200)
                {
                    arrows.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < arrows.Count; i++)
            {
                if (pl.getBenda().IntersectsWith(arrows[i].getBenda()))
                {
                    arrows.RemoveAt(i);
                    i--;
                }
            }
            Invalidate();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            cek();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Left)
            {
                pl.x -= 10;
                pl.geser(pl.x);
            }
            else if (e.KeyData == Keys.Right)
            {
                pl.x += 10;
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
