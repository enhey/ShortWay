using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW
{
    public partial class SW : Form
    {

        private bool initial = true, startDraw;
        List<Point> pList = new List<Point>();

        public SW()
        {
            InitializeComponent();
        }

        //private void begin_Click(object sender, EventArgs e)
        //{
        //    panel1.Cursor = Cursors.Cross;
        //    panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDownB);
        //}

        //private void goal_Click(object sender, EventArgs e)
        //{
        //    panel1.Cursor = Cursors.Cross;
        //    panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDownG);
        //}

        //private void panel1_MouseDownG(object sender, MouseEventArgs e)
        //{
        //    Point pPanel = new Point();
        //    pPanel = panel1.PointToClient(Control.MousePosition);
        //    goalX.Text = pPanel.X.ToString();
        //}
        //private void panel1_MouseDownB(object sender, MouseEventArgs e)
        //{
        //    Point pPanel = new Point();
        //    pPanel = panel1.PointToClient(Control.MousePosition);
        //    beignX.Text = pPanel.X.ToString();
        //}
        //private void mouse_Click(object sender, EventArgs e)
        //{
        //    panel1.Cursor = Cursors.Arrow;
        //}

        //private void panel1_Paint(object sender, PaintEventArgs e)
        //{

        //}


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (initial) //窗体刚加载时不重绘
            {
                return;
            }
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen p = new Pen(Color.Black, 10))
            {
                //设置起止点线帽
                p.StartCap = LineCap.Round;
                p.EndCap = LineCap.Round;

                //设置连续两段的联接样式
                p.LineJoin = LineJoin.Round;

                g.DrawCurve(p, pList.ToArray()); //画平滑曲线
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initial = false;
                startDraw = true;
                pList.Add(e.Location);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && startDraw)
            {
                pList.Add(e.Location);
                this.Refresh();
            }
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                startDraw = false;
            }
        }
    }
}
