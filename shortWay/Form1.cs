using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public List<Point> pList = new List<Point>();
        public short flag = 0;
        private Graphics graphic;//画板对象
        private Boolean[,] block;//标记地图障碍物情况
        Boolean mdown = false;
        Brush wipe;
        Pen pen = new Pen(Color.Black, 10);
        Bitmap backBit;
        public Form1()
        {
            InitializeComponent();
            innit();
        }
        private void innit()
        {
            backBit = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);
            pictureBox1.DrawToBitmap(backBit, pictureBox1.ClientRectangle);
            pictureBox1.Image = (Image)backBit;
            //graphic = Graphics.FromImage((Image)backBit);
            pBegin = p;
            pGoal = p;
            wipe = new SolidBrush(Color.Snow);        
        }
        private void begin_Click(object sender, EventArgs e)//触发起点标点
        {
            pictureBox1.Cursor = Cursors.Cross;
            flag = 1;
        }
        private void goal_Click(object sender, EventArgs e)//触发终点标点
        {
            pictureBox1.Cursor = Cursors.Cross;
            flag = 2;
        }

        private void mouse_Click(object sender, EventArgs e)//鼠标变成指针
        {
            pictureBox1.Cursor = Cursors.Arrow;
            flag = 0;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (flag)
            {
                case 1: setBegin(e); break;//起点标点
                case 2: setGoal(e); break;//终点标点
                                          //               case 3:mdown = true; break;//画障碍物
                default: break;
            }
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            mdown = false;
        }
        private void setBegin(MouseEventArgs e)//起点标点
        {
            if(backBit.GetPixel(e.X,e.Y).Name=="ff000000")
            {
                MessageBox.Show("起点不看设置在障碍物内");
                return;
            }
            graphic = Graphics.FromImage((Image)backBit);
            graphic.FillEllipse(wipe, pBegin.X, pBegin.Y, 10, 10);
            beignX.Text = e.X.ToString();
            beginY.Text = e.Y.ToString();
            pBegin = e.Location;
            Brush bush = new SolidBrush(Color.Green);
            graphic.FillEllipse(bush, e.X, e.Y, 10, 10);
            pictureBox1.Image = backBit;
            graphic.Dispose();
        }
        private void setGoal(MouseEventArgs e)//终点标点
        {
            if (backBit.GetPixel(e.X, e.Y).Name == "ff000000")
            {
                MessageBox.Show("终点不看设置在障碍物内");
                return;
            }
            graphic = Graphics.FromImage((Image)backBit);
            graphic.FillEllipse(wipe, pGoal.X, pGoal.Y, 10, 10);
            goalX.Text = e.X.ToString();
            goalY.Text = e.Y.ToString();
            pGoal = e.Location;
            Brush bush = new SolidBrush(Color.Red);
            graphic.FillEllipse(bush, e.X, e.Y, 10, 10);
            pictureBox1.Image = backBit;
            graphic.Dispose();
        }

        private void obstacle_Click(object sender, EventArgs e)//设置随机障碍物
        {
            clear_Click(sender, e);
            Obstacle ob = new Obstacle(this.backBit);
            ob.getRandom();

        }

        private void clear_Click(object sender, EventArgs e)
        {
            graphic = Graphics.FromImage((Image)backBit);
            pGoal = p; pBegin = p;
            beignX.Text = beginY.Text = goalX.Text = goalY.Text = null;
            graphic.Clear(Color.Snow);
            pictureBox1.Image = backBit;
            graphic.Dispose();
        }

        private void Star_Click(object sender, EventArgs e)
        {
            RRT find = new RRT(backBit, pBegin, pGoal);
            //Thread thread = new Thread(find.findWay);
            //thread.Start();
            find.findWay();
        }
    }
}