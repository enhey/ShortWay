//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace shortWay
//{
//    class SNode
//    {
//        public SNode pre;
//        public int F, G, H;
//        public int X, Y;
//        Boolean obs;
//        //public SNode(int X, int Y)
//        //{
//        //    this.X = X; this.Y = Y;
//        //}
//        public SNode(SNode pre, int X, int Y)
//        {
//            this.pre = pre;
//            this.X = X; this.Y = Y;
//        }
//        public Boolean equal(SNode node)
//        {
//            if (this.X == node.X && this.Y == node.Y)
//                return true;
//            return false;
//        }
//    }
//    class ThetaStar
//    {
//        PictureBox picturebox;
//        Image image;
//        private Point pBegin;
//        private Point pGoal;
//        Bitmap innitMap;
//        Bitmap map;
//        Graphics graphics;
//        SNode GoalNode;
//        SNode beginNode;
//        List<SNode> openNode = new List<SNode>();
//        List<SNode> closeNode = new List<SNode>();
//        public const int unitLen = 10;
//        public const int unitOblique = 14;
//        SolidBrush scanBrush = new SolidBrush(Color.FromArgb(50,Color.LawnGreen));
//        SolidBrush scanedBrush = new SolidBrush(Color.FromArgb(100, Color.Gray));
//        public ThetaStar(PictureBox picturebox, Point b, Point g)
//        {
//            this.picturebox = picturebox;
//            image = picturebox.Image;
//            innitMap = (Bitmap)image;
//            map = (Bitmap)image;
//            //graphics = Graphics.FromImage((Image)map);
//            graphics = Graphics.FromImage(picturebox.Image);

//            this.pBegin = b; this.pGoal = g;
//            GoalNode = new SNode(null, pGoal.X / 10, pGoal.Y / 10);
//            GoalNode.H = 0;

//            beginNode = new SNode(null, pBegin.X / 10, pBegin.Y / 10);
//            beginNode.H = getH(beginNode);
//            beginNode.G = 0;
//            openNode.Add(beginNode);
//        }
//        public void findWay()
//        {
//            raste();
//            find();
//            drawWay();
//        }
//        public void raste()//栅格化
//        {
//            //SolidBrush sb = new SolidBrush(Color.FromArgb(128, 255, 255, 255));//1-（128/255）=1-0.5=0.5 透明度为0.5，即50%, 数字越低越透明
//            for (int i = 0; i <= 500 / unitLen; i++)
//            {
//                Point left = new Point(0, i * unitLen);
//                Point right = new Point(500, i * unitLen);
//                Point up = new Point(i * unitLen, 0);
//                Point down = new Point(i * unitLen, 500);
//                Pen darkLine = new Pen(Color.DarkGray, 1);
//                graphics.DrawLine(darkLine, left, right);
//                graphics.DrawLine(darkLine, up, down);
//            }
//            picturebox.Invalidate();
//        }
//        public void find()
//        {           
//            while (GoalNode.pre==null)
//            {
//                SNode minF = openNode.First();
//                for (int i = 0; i < openNode.Count; i++)
//                {
//                    if (openNode[i].F < minF.F)
//                        minF = openNode[i];
//                }
//                addRound(minF);
//                Rectangle re = new Rectangle(minF.X*10, minF.Y*10, 10, 10);
//                graphics.FillRectangle(scanedBrush, re);
//                closeNode.Add(minF);
//                openNode.Remove(minF);
//                Thread.Sleep(30);
//            }
//            MessageBox.Show("over");

//        }
//        public void addRound(SNode parent)//添加父节点周围的节点
//        {
//            addNode(parent, parent.X - 1, parent.Y - 1, 14);
//            addNode(parent, parent.X, parent.Y - 1, 10);
//            addNode(parent, parent.X + 1, parent.Y - 1, 14);

//            addNode(parent, parent.X - 1, parent.Y, 10);
//            addNode(parent, parent.X + 1, parent.Y, 10);

//            addNode(parent, parent.X - 1, parent.Y + 1, 14);
//            addNode(parent, parent.X, parent.Y + 1, 10);
//            addNode(parent, parent.X + 1, parent.Y + 1, 14);
//        }
//        public void addNode(SNode parent, int x, int y, int unit)
//        {
//            if (x >= 0 && y >= 0 && x <= 500 / unitLen && y <= 500 / unitLen)
//            {
//                SNode node = new SNode(parent, x, y);
//                Boolean contain = inOpenList(node);
//                if (notBlock(node) && !inCloseList(node) && !contain)//节点不存在于open和close，添加入open
//                {
//                    node.pre = parent;
//                    node.H = getH(node);
//                    node.G = parent.G + unit;
//                    node.F = node.G + node.H;
//                    openNode.Add(node);
//                    graphics.FillRectangle(scanBrush,node.X*10,node.Y*10,10,10);
//                    picturebox.Refresh();
//                    Thread.Sleep(30);
//                    if (node.equal(GoalNode))
//                        GoalNode = node;
//                }
//                if (contain)//如果已经存在opennode，判断是否更新父节点
//                {
//                    if (parent.G + unit < node.G)
//                    {
//                        node.pre = parent;
//                        node.G = parent.G + unit;
//                        node.F = node.G + node.H;
//                    }
//                }
//            }
//        }
//        public Boolean inCloseList(SNode node)
//        {
//            for (int i = 0; i < closeNode.Count; i++)
//            {
//                if (closeNode[i].equal(node))
//                    return true;
//            }
//            return false;
//        }
//        public Boolean inOpenList(SNode node)
//        {
//            for (int i = 0; i < openNode.Count; i++)
//            {
//                if (openNode[i].equal(node))
//                    return true;
//            }
//            return false;
//        }

//        public Boolean notBlock(SNode temp)
//        {
//            int x = temp.X*10;
//            for (int i = 0; i < 3; i++)
//            {
//                x = x + (int)(3 * i);
//                int y = temp.Y * 10;
//                for (int j = 0; j < 3; j++)
//                {
//                    y = y + (int)(3 * j);
//                    if (innitMap.GetPixel(x, y).Name == "ff000000")
//                    {
//                        return false;
//                    }
//                }
//            }
//            return true;
//        }
//        public int getH(SNode node)
//        {
//            return (Math.Abs(node.X - GoalNode.X)*10 + Math.Abs(node.Y - GoalNode.Y)*10);
//        }
//        public void drawWay()
//        {
//            SNode goal=GoalNode;
//            SolidBrush b = new SolidBrush(Color.Red);
//            while(goal.pre!=null)
//            {
//                Rectangle r = new Rectangle(goal.X * 10, goal.Y * 10, 10, 10);
//                graphics.FillRectangle(b, r);
//                goal = goal.pre;
//            }
//            picturebox.Refresh();
//            graphics.Dispose();
//        }

//    }
//}



//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace shortWay
//{
//    class pNode
//    {
//        public Point data;
//        public pNode pre = null;
//        public pNode(Point p)
//        {
//            this.data = p;
//        }
//    }
//    class PRM
//    {
//        PictureBox picturebox;
//        Image image;
//        Bitmap map;
//        Graphics graphics;
//        private Point pBegin;
//        private Point pGoal;
//        private pNode beg, goal;
//        private List<pNode> PointList = new List<pNode>();
//        int count;
//        private List<pNode> path = new List<pNode>();
//        int[,] distance;//两个随机点的路径距离
//        int[,] connetRelation;
//        public PRM(PictureBox picturebox, Point b, Point g)
//        {
//            this.picturebox = picturebox;
//            image = picturebox.Image;
//            map = (Bitmap)image;
//            graphics = Graphics.FromImage(picturebox.Image);
//            this.pBegin = b; this.pGoal = g;
//            beg = new pNode(pBegin); goal = new pNode(pGoal);
//        }
//        public void findWay()
//        {
//            //PointList.Add(new pNode(pBegin));PointList.Add(new pNode(pGoal));
//            int pointCount = 30;//随机点个数
//            generateRandomNode(pointCount);

//            count = PointList.Count;
//            distance = new int[count, count];
//            connetRelation = new int[count, count];
//            for (int i = 0; i < count; i++)
//            {
//                for (int j = i; j < count; j++)
//                {
//                    if (i == j)
//                        distance[i, j] = 0;
//                    else
//                    {
//                        int len = getDistance(PointList[i].data, PointList[j].data);
//                        distance[i, j] = distance[j, i] = len;
//                    }
//                }
//            }
//            int K = 5;
//            connetNear(K);//连接最近K个点，K<count
//            nearBegGoal();
//        }
//        public void generateRandomNode(int pointCount)//产生pointCount个随机点
//        {
//            Brush brush = new SolidBrush(Color.Blue);
//            Random r = new Random();
//            for (int i = 0; i < pointCount; i++)
//            {
//                Point p = new Point(r.Next(3, 497), r.Next(3, 497));
//                Color color = map.GetPixel(p.X, p.Y);
//                if (color.R + color.G + color.B > 10)//判断随机点是否在障碍物内
//                {
//                    PointList.Add(new pNode(p));
//                    graphics.FillEllipse(brush, new Rectangle(p.X - 3, p.Y - 3, 5, 5));
//                }
//            }
//            picturebox.Refresh();
//        }
//        public void connetNear(int K)//每个点与最近K个的点连接
//        {
//            Pen pen = new Pen(Color.Yellow, 2);
//            for (int i = 0; i < PointList.Count; i++)
//            {
//                int[] pdd = new int[K]; int m = 0;
//                for (int j = 0; j < PointList.Count; j++)
//                {
//                    if (m < K)
//                        pdd[m++] = j;
//                    else
//                    {
//                        int max = 0;
//                        for (int l = 0; l < K; l++)
//                        {
//                            if (distance[i, pdd[max]] < distance[i, pdd[l]])
//                                max = l;
//                        }
//                        if (distance[i, j] < distance[i, max])
//                            pdd[max] = j;

//                    }
//                    if (canConnet(PointList[i].data, PointList[j].data))//如果两点间有直线路径，更新两点间的距离并进行连接
//                    {
//                        int len = (int)getDistance(PointList[i].data, PointList[j].data);
//                        distance[i, j] = distance[j, i] = len;
//                        graphics.DrawLine(pen, PointList[i].data, PointList[j].data);
//                    }
//                }
//            }
//            picturebox.Refresh();
//        }
//        //public int[] smallN(int []list,int n)
//        //{
//        //    int []a=new int[10];
//        //    return a;
//        //}
//        public void nearBegGoal()//找距起终点最近点
//        {

//            pNode minBeg = null, minGoal = null;
//            int minB = 9999, minG = 9999;
//            for (int i = 0; i < count; i++)
//            {
//                int disB = getDistance(PointList[i].data, beg.data);
//                if (disB < minB)
//                {
//                    if (canConnet(PointList[i].data, beg.data))
//                    {
//                        minBeg = PointList[i]; minB = disB;
//                    }
//                }
//                int disG = getDistance(PointList[i].data, goal.data);
//                if (disG < minG)
//                {
//                    if (canConnet(PointList[i].data, goal.data))
//                    {
//                        minGoal = PointList[i]; minG = disG;
//                    }
//                }
//            }
//            if (minBeg != null && minGoal != null)
//            {
//                Pen p = new Pen(Color.Blue, 3);
//                minBeg.pre = beg; goal.pre = minGoal;
//                graphics.DrawLine(p, minBeg.data, beg.data);
//                graphics.DrawLine(p, minGoal.data, goal.data);
//            }
//            else
//            {
//                MessageBox.Show("起点或终点无法连接到随机网络，请重新执行");
//            }
//            picturebox.Refresh();
//        }
//        public void djstra()//用迪杰斯特拉寻找路径
//        {

//        }

//        public Boolean canConnet(Point front, Point back)//判断两点间是否有障碍物
//        {
//            int dtx = back.X - front.X, dty = back.Y - front.Y;
//            double opLength;
//            opLength = Math.Sqrt(dtx * dtx + dty * dty);

//            int check = (int)(opLength / 5);
//            for (int i = 1; i <= check; i++)
//            {
//                Color color = map.GetPixel((front.X + (dtx * i) / check), (front.Y + (dty * i) / check));
//                int colorNum = color.R + color.G + color.B;
//                if (colorNum < 15)
//                {
//                    return false;
//                }
//            }
//            return true;
//        }
//        public int getDistance(Point front, Point back)//计算两点最短距离
//        {
//            int dtx = back.X - front.X, dty = back.Y - front.Y;
//            double opLength;
//            opLength = Math.Sqrt(dtx * dtx + dty * dty);
//            return (int)opLength;
//        }
//    }
//}

