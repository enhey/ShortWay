using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    public partial class Form1 : Form
    {
        public Point p = new Point(-1, -1);
        public Point pBegin;
        public Point pGoal;
        public Point mousePoint;
        public Point currentPoint;
        public short flag = 0;
        private Graphics graphic;//画板对象
        private int[,] block;//标记地图障碍物情况
        Boolean mdown=false;
        Boolean penclick = false;
        Brush wipe;
        Pen pen = new Pen(Color.Black, 10);
        public Form1()
        {
            InitializeComponent();
            innit();
        }
        private void innit()
        {
            graphic = this.panel1.CreateGraphics();
            block = new int[500, 500];
            pBegin = p;
            pGoal = p;
            wipe = new SolidBrush(Color.Snow);
        }
        private void begin_Click(object sender, EventArgs e)//触发起点标点
        {
            panel1.Cursor = Cursors.Cross;
            flag = 1;
        }
        private void goal_Click(object sender, EventArgs e)//触发终点标点
        {
            panel1.Cursor = Cursors.Cross;
            flag = 2;
        }

        private void mouse_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Arrow;
            flag = 0;
        }

        private void penobs_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Arrow;
            flag=3;
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (flag)
            {
                case 1: setBegin(e); break;//起点标点
                case 2: setGoal(e); break;//终点标点
                case 3:mdown = true; break;//画障碍物
                default: break;
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }
        private void setBegin(MouseEventArgs e)//起点标点
        {
            graphic.FillEllipse(wipe, pBegin.X, pBegin.Y, 10, 10);
            beignX.Text = e.X.ToString();
            beginY.Text = e.Y.ToString();
            pBegin = e.Location;
            Brush bush = new SolidBrush(Color.Green);
            graphic.FillEllipse(bush, e.X, e.Y, 10, 10);
        }
        private void setGoal(MouseEventArgs e)//终点标点
        {
            graphic.FillEllipse(wipe, pGoal.X, pGoal.Y, 10, 10);
            goalX.Text = e.X.ToString();
            goalY.Text = e.Y.ToString();
            pGoal = e.Location;
            Brush bush = new SolidBrush(Color.Red);
            graphic.FillEllipse(bush, e.X, e.Y, 10, 10);
        }
        //private void paintObs(MouseEventArgs e)
        //{
        //    Pen pen = new Pen(Color.Black,10);
        //    //pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
        //    //pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        //    //pen.LineJoin = System.Drawing.Drawing2D.LineJoin.Round;
        //    //graphic.DrawCurve(pen,)
        //    graphic.DrawLine(pen,mousePoint.X, mousePoint.Y, mousePoint.X+1, mousePoint.Y+1);

        //}

        private void obstacle_Click(object sender, EventArgs e)
        {
            if (pBegin != p || pGoal != p)
            {
                graphic.FillEllipse(wipe, pBegin.X, pBegin.Y, 10, 10);
                graphic.FillEllipse(wipe, pGoal.X, pGoal.Y, 10, 10);
                pGoal = p; pBegin = p;
                MessageBox.Show("添加障碍物必须前先清除起终点");
            }
            else
            {
                int shape, xloc, yloc, wid, hei;
                Brush obs = new SolidBrush(Color.Black);
                Random r = new Random();
                shape = r.Next(0, 3);
                xloc = r.Next(50, 450); yloc = r.Next(50, 450);
                wid = r.Next(50, 150); hei = r.Next(50, 150);
                switch (shape)
                {
                    case 0://正方形
                        {
                            graphic.FillRectangle(obs, xloc, yloc, wid, hei); break;

                        }
                    case 1://椭圆
                        graphic.FillEllipse(obs, xloc, yloc, wid, hei); break;
                    case 2://三角形
                        {
                            Point[] p = new Point[3];
                            p[0].X = xloc; p[0].Y = yloc;
                            double lenth = 100;
                            p[1].X = p[0].X + (int)(lenth * r.Next(8, 12) / 10 * Math.Cos(r.Next(0, 181)));
                            p[1].Y = p[0].X + (int)(lenth * r.Next(8, 12) / 10 * Math.Sin(r.Next(0, 181)));
                            p[2].X = p[0].X + (int)(lenth * r.Next(8, 12) / 10 * Math.Cos(r.Next(0, 181)));
                            p[2].Y = p[0].X + (int)(lenth * r.Next(8, 12) / 10 * Math.Sin(r.Next(0, 181)));
                            graphic.FillPolygon(obs, p); break;
                        }
                }

            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            pGoal = p; pBegin = p;
            graphic.Clear(Color.Snow);
        }

        private void star_Click(object sender, EventArgs e)
        {

        }



        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Thread.Sleep(20);
            currentPoint = e.Location;
            if (mdown==true)
            {               
                graphic.DrawLine(pen, mousePoint,currentPoint);
            }
            mousePoint = currentPoint;
        }


    }
}