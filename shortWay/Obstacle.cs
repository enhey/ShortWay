using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    class Obstacle
    {
        PictureBox picturebox;
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
            num = r.Next(0, 5);
            switch (num)
            {
                case 0: default0(); break;
                case 1:default1();break;
                case 2:default2();break;
                case 3: default3(); break;
                case 4: default4(); break;
            }
            graphic.Dispose();
        }
        //赖志卿
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
        public void default2()
        {
            Point p1 = new Point(200, 15);
            Point p2 = new Point(135, 70);
            Point p3 = new Point(265, 70);
            Point[] pntArr = { p1, p2, p3 };
            graphic.FillPolygon(Brushes.Black, pntArr);

            //画矩形
            Brush brush = new SolidBrush(Color.Black);
            graphic.FillRectangle(brush, 160, 70, 80, 190);

            Point pa = new Point(160, 200);
            Point pb = new Point(160, 260);
            Point pc = new Point(100, 260);
            Point[] pt = { pa, pb, pc };
            Point pd = new Point(240, 200);
            Point pe = new Point(240, 260);
            Point pf = new Point(300, 260);
            Point[] pt1 = { pd, pe, pf };
            graphic.FillPolygon(Brushes.Black, pt);
            graphic.FillPolygon(Brushes.Black, pt1);

        }
        public void default3()
        {
            Bitmap bitmap = new Bitmap(@"..\..\Resources\timg1.jpg");
            graphic.DrawImage(bitmap,0,0);
        }
        public void default4()
        {
            Bitmap bitmap = new Bitmap(@"..\..\Resources\map4.png");
            graphic.DrawImage(bitmap, 0, 0);
        }
    }
}
