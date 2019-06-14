using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    class pNode
    {
        public Point data;
        public pNode pre = null;
        public int dis = 9999;
        public pNode(Point p)
        {
            this.data = p;
        }
    }
    class PRM
    {
        PictureBox picturebox;
        Image image;
        Bitmap map;
        Graphics graphics;
        //private Point pBegin;
        //private Point pGoal;
        private pNode beg, goal;
        int begAfter, goalBefore;
        private List<pNode> PointList = new List<pNode>();
        int count;
        private List<pNode> path = new List<pNode>();
        int[,] distance;//两个随机点的路径距离
        int[,] connetRelation;
        public PRM(PictureBox picturebox, Point b, Point g)
        {
            this.picturebox = picturebox;
            image = picturebox.Image;
            map = (Bitmap)image;
            graphics = Graphics.FromImage(picturebox.Image);
            //this.pBegin = b; this.pGoal = g;
            beg = new pNode(b); goal = new pNode(g);
        }
        public void findWay()
        {
            //PointList.Add(new pNode(pBegin));PointList.Add(new pNode(pGoal));
            int pointCount = 20;//随机点个数
            generateRandomNode(pointCount);

            count = PointList.Count;
            distance = new int[count, count];
            connetRelation = new int[count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    if (i == j)
                        distance[i, j] = 0;
                    else
                    {
                        distance[i, j] = 9999;
                    }
                }
            }
            //int K = 5;
            connetNear();//连接最近K个点，K<count
            if (!nearBegGoal())
                return;
            djstra();
            drawPath();
        }
        public void generateRandomNode(int pointCount)//产生pointCount个随机点
        {
            Brush brush = new SolidBrush(Color.Blue);
            Random r = new Random();
            for (int i = 0; i < pointCount; i++)
            {
                Point p = new Point(r.Next(3, 497), r.Next(3, 497));
                Color color = map.GetPixel(p.X, p.Y);
                if (color.R + color.G + color.B > 10)//判断随机点是否在障碍物内
                {
                    PointList.Add(new pNode(p));
                    graphics.FillEllipse(brush, new Rectangle(p.X - 3, p.Y - 3, 5, 5));
                }
            }
            picturebox.Refresh();
        }
        public void connetNear()//每个点与最近K个的点连接
        {
            Pen pen = new Pen(Color.Yellow, 2);
            for (int i = 0; i < PointList.Count; i++)
            {
                for (int j = 0; j < PointList.Count; j++)
                {

                    if (canConnet(PointList[i].data, PointList[j].data))//如果两点间有直线路径，更新两点间的距离并进行连接
                    {
                        int len = (int)getDistance(PointList[i].data, PointList[j].data);
                        distance[i, j] = distance[j, i] = len;
                        graphics.DrawLine(pen, PointList[i].data, PointList[j].data);
                    }
                }
            }
            picturebox.Refresh();
        }
        public Boolean nearBegGoal()//找距起终点最近点
        {

            pNode minBeg = null, minGoal = null;
            int minB = 9999, minG = 9999;
            for (int i = 0; i < count; i++)
            {
                int disB = getDistance(PointList[i].data, beg.data);
                if (disB < minB)
                {
                    if (canConnet(PointList[i].data, beg.data))
                    {
                        minBeg = PointList[i]; minB = disB;
                        begAfter = i;
                    }
                }
                int disG = getDistance(PointList[i].data, goal.data);
                if (disG < minG)
                {
                    if (canConnet(PointList[i].data, goal.data))
                    {
                        minGoal = PointList[i]; minG = disG;
                        goalBefore = i;
                    }
                }
            }
            if (minBeg != null && minGoal != null)
            {
                Pen p = new Pen(Color.Blue, 3);
                minBeg.pre = beg; goal.pre = minGoal;
                PointList[begAfter].dis = 0;//把起点到自己的距离记作0
                graphics.DrawLine(p, minBeg.data, beg.data);
                graphics.DrawLine(p, minGoal.data, goal.data);
            }
            else
            {
                MessageBox.Show("起点或终点无法连接到随机网络，请重新执行");
                return false;
            }
            picturebox.Refresh();
            return true;
        }
        public void djstra()//用迪杰斯特拉寻找路径
        {
            //Boolean []close=new Boolean[count];
            for (int i = 0; i<count; i++)
            {
                int current = (begAfter + i) % count;
                for (int j = 0; j < count; j++)
                {                   
                    if (distance[current, j]+PointList[current].dis < PointList[j].dis)
                    {
                        PointList[j].pre = PointList[current];
                        PointList[j].dis = distance[current, j] + PointList[current].dis;
                    }
                }
                //if (PointList[i].dis >= 9999)
                //{
                //    MessageBox.Show("有不通路径，请重新执行");
                //    return;
                //}
            }
        }
        public void drawPath()
        {
            pNode temp=goal.pre;
            Pen p = new Pen(Color.Blue, 3);
            while (temp.pre!=null)
            {
                graphics.DrawLine(p, temp.data, temp.pre.data);
                temp = temp.pre;
            }
            if (temp != beg)
                MessageBox.Show("路径断开");
            picturebox.Refresh();
        }

        public Boolean canConnet(Point front, Point back)//判断两点间是否有障碍物
        {
            int dtx = back.X - front.X, dty = back.Y - front.Y;
            double opLength;
            opLength = Math.Sqrt(dtx * dtx + dty * dty);

            int check = (int)(opLength / 5);
            for (int i = 1; i <= check; i++)
            {
                Color color = map.GetPixel((front.X + (dtx * i) / check), (front.Y + (dty * i) / check));
                int colorNum = color.R + color.G + color.B;
                if (colorNum < 15)
                {
                    return false;
                }
            }
            return true;
        }
        public int getDistance(Point front, Point back)//计算两点最短距离
        {
            int dtx = back.X - front.X, dty = back.Y - front.Y;
            double opLength;
            opLength = Math.Sqrt(dtx * dtx + dty * dty);
            return (int)opLength;
        }
    }
}
