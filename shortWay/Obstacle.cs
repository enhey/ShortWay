using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    class Obstacle
    {
        Bitmap picture;
        Graphics graphic;
        Brush brush = new SolidBrush(Color.Black);
        public Obstacle(Bitmap picture)
        {
            this.picture = picture;
            graphic = Graphics.FromImage((Image)picture);
        }
        public void getRandom()
        {
            int num;
            Random r = new Random();
            num = r.Next(0, 2);
            switch (num)
            {
                case 0: default0(); break;
                case 1:default1();break;
            }
            graphic.Dispose();
        }
        public void default0()
        {
            Rectangle r = new Rectangle();
            r.Size = new Size(40, 250);
            r.Location = new Point(120, 120);
            graphic.FillRectangle(brush, r);
            r.Size = new Size(250, 40);
            r.Location = new Point(120, 120);
            graphic.FillRectangle(brush, r);
            r.Location = new Point(120, 330);
            graphic.FillRectangle(brush, r);

            graphic.FillEllipse(brush, 210, 200, 100, 100);

        }

        public void default1()
        {
            Rectangle r = new Rectangle();

            r.Size = new Size(40, 250);
            r.Location = new Point(50, 50);
            graphic.FillRectangle(brush, r);

            r.Size = new Size(250, 40);
            r.Location = new Point(50, 50);
            graphic.FillRectangle(brush, r);
            r.Location = new Point(50, 260);
            graphic.FillRectangle(brush, r);

            graphic.TranslateTransform(100, 100);

            r.Size = new Size(250, 40);
            r.Location = new Point(50, 50);
            graphic.FillRectangle(brush, r);
            r.Location = new Point(50, 260);
            graphic.FillRectangle(brush, r);
            r.Size = new Size(40, 250);
            r.Location = new Point(260, 50);
            graphic.FillRectangle(brush, r);

        }
        public void wangzheMap()
        {

        }
    }
}
