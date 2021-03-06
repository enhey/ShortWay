﻿using System;
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
//赖志卿
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
        Brush wipe;
        Pen pen = new Pen(Color.Black, 10);
        Bitmap backBit;
        public Form1()
        {
            InitializeComponent();
            PictureBox.CheckForIllegalCrossThreadCalls = false;
            innit();
        }
        private void innit()
        {
            comboBox1.SelectedIndex = 0;
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
            //pictureBox1.Invalidate();
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
           // pictureBox1.Invalidate();
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
        //赖志卿
        private void Star_Click(object sender, EventArgs e)
        {
            if (pBegin.Equals(p) || pGoal.Equals(p))
            {
                MessageBox.Show("请添加起点终点");
                return;
            }
            if (comboBox1.SelectedIndex == 0)
            {
                RRT find0 = new RRT(pictureBox1, pBegin, pGoal);
                Thread thread0 = new Thread(find0.findWay);
                thread0.Start();
                //thread2.Join();
                //find0.findWay();
            }
            if (comboBox1.SelectedIndex == 1)
            {
                AStar find1 = new AStar(pictureBox1, pBegin, pGoal);
                Thread thread1 = new Thread(find1.findWay);
                thread1.Start();
                //thread2.Join();
                //find1.findWay();
            }
            if (comboBox1.SelectedIndex == 2)
            {
                Theta find2 = new Theta(pictureBox1, pBegin, pGoal);
                Thread thread2 = new Thread(find2.findWay);
                thread2.Start();
                //thread2.Join();
                //find2.findWay();
            }
            if (comboBox1.SelectedIndex == 3)
            {
                PRM find3 = new PRM(pictureBox1, pBegin, pGoal);
                Thread thread2 = new Thread(find3.findWay);
                thread2.Start();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            //System.Environment.Exit(0);
            //Application.ExitThread();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            textBoxX.Text = e.X.ToString();
            textBoxY.Text = e.Y.ToString();
        }

    }
}
