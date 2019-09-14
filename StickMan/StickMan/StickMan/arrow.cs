using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickMan
{
    class arrow
    {
        public string src { get; set; }
        public Bitmap img { get; set; }
        public Rectangle collision;
        public int x { get; set; }
        public int y { get; set; }
        public int lebar { get; set; }
        public int tinggi { get; set; }
        public int dy { get; set; }

        public arrow(string src, int x, int y, int lebar, int tinggi)
        {
            this.src = src;
            this.img = img;
            this.x = x;
            this.y = y;
            this.lebar = lebar;
            this.tinggi = tinggi;
            collision = new Rectangle(x, y, lebar, tinggi);
            dy = 1;
        }

        public Rectangle getBenda()
        {
            return new Rectangle(x, y, lebar, tinggi);
        }
        public void draw(Graphics g)
        {
            img = new Bitmap("Resources\\panah.png");
            g.DrawImage(img, x, y, lebar, tinggi);
        }

        public void geser(int pindah)
        {
            collision.X = pindah;
        }
    }
}
