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
        public Point pBegin;
        public Point pGoal;
        public short flag = 0;
        private Graphics graphic;
        public Form1()
        {
            InitializeComponent();
            graphic = this.panel1.CreateGraphics();
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (flag)
            {
                case 1: setBegin(e); break;//起点标点
                case 2:; setGoal(e); break;//终点标点
                default: break;
            }
        }

        private void setBegin(MouseEventArgs e)//起点标点
        {
            Brush wipe = new SolidBrush(Color.Snow);
            graphic.FillEllipse(wipe, pBegin.X, pBegin.Y, 10, 10);
            beignX.Text = e.X.ToString();
            beginY.Text = e.Y.ToString();
            pBegin = e.Location;
            Brush bush = new SolidBrush(Color.Green);
            graphic.FillEllipse(bush, e.X,e.Y,10,10);
        }
        private void setGoal(MouseEventArgs e)//终点标点
        {
            Brush wipe = new SolidBrush(Color.Snow);
            graphic.FillEllipse(wipe, pGoal.X, pGoal.Y, 10, 10);
            goalX.Text = e.X.ToString();
            goalY.Text = e.Y.ToString();
            pGoal = e.Location;
            Brush bush = new SolidBrush(Color.Red);
            graphic.FillEllipse(bush, e.X, e.Y, 10, 10);
        }
    }
}