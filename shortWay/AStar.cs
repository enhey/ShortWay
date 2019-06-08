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
    class SNode
    {
        public SNode pre;
        public int F, G, H;
        public int X, Y;
        //public SNode(int X, int Y)
        //{
        //    this.X = X; this.Y = Y;
        //}
        public SNode(SNode pre, int X, int Y)
        {
            this.pre = pre;
            this.X = X; this.Y = Y;
        }
        public Boolean equal(SNode node)
        {
            if (this.X == node.X && this.Y == node.Y)
                return true;
            return false;
        }
    }
    class AStar
    {
        PictureBox picturebox;
        Image image;
        private Point pBegin;
        private Point pGoal;
        Bitmap innitMap;
        Graphics graphics;
        SNode GoalNode;
        SNode beginNode;
        List<SNode> openNode = new List<SNode>();
        List<SNode> closeNode = new List<SNode>();
        public const int unitLen = 10;
        public const int unitOblique = 14;
        SolidBrush scanBrush = new SolidBrush(Color.FromArgb(50, Color.LawnGreen));
        SolidBrush scanedBrush = new SolidBrush(Color.FromArgb(100, Color.Gray));
        public AStar(PictureBox picturebox, Point b, Point g)
        {
            this.picturebox = picturebox;
            image = picturebox.Image;
            innitMap =(Bitmap)image.Clone() ;//copy一份初始的障碍物，防止划线对障碍物的颜色影响
            //graphics = Graphics.FromImage((Image)map);
            graphics = Graphics.FromImage(picturebox.Image);

            this.pBegin = b; this.pGoal = g;
            GoalNode = new SNode(null, pGoal.X / 10, pGoal.Y / 10);
            GoalNode.H = 0;

            beginNode = new SNode(null, pBegin.X / 10, pBegin.Y / 10);
            beginNode.H = getH(beginNode);
            beginNode.G = 0;
            openNode.Add(beginNode);
        }
        public void findWay()
        {
            raste();
            find();
            drawWay();
        }
        public void raste()//栅格化
        {
            //SolidBrush sb = new SolidBrush(Color.FromArgb(128, 255, 255, 255));//1-（128/255）=1-0.5=0.5 透明度为0.5，即50%, 数字越低越透明
            for (int i = 0; i <= 500 / unitLen; i++)
            {
                Point left = new Point(0, i * unitLen);
                Point right = new Point(500, i * unitLen);
                Point up = new Point(i * unitLen, 0);
                Point down = new Point(i * unitLen, 500);
                Pen darkLine = new Pen(Color.DarkGray, 1);
                graphics.DrawLine(darkLine, left, right);
                graphics.DrawLine(darkLine, up, down);
            }
        }
        public void find()
        {
            while (GoalNode.pre == null)
            {
                SNode minF = openNode.First();
                for (int i = 0; i < openNode.Count; i++)
                {
                    if (openNode[i].F < minF.F)
                        minF = openNode[i];
                }
                addRound(minF);
                Rectangle re = new Rectangle(minF.X * 10, minF.Y * 10, 10, 10);
                graphics.FillRectangle(scanedBrush, re);
                closeNode.Add(minF);
                openNode.Remove(minF);
                //Thread.Sleep(10);
            }
            //MessageBox.Show("over");

        }
        public void addRound(SNode parent)//添加父节点周围的节点
        {
            addNode(parent, parent.X - 1, parent.Y - 1, unitOblique);
            addNode(parent, parent.X, parent.Y - 1, 10);
            addNode(parent, parent.X + 1, parent.Y - 1, unitOblique);

            addNode(parent, parent.X - 1, parent.Y, 10);
            addNode(parent, parent.X + 1, parent.Y, 10);

            addNode(parent, parent.X - 1, parent.Y + 1, unitOblique);
            addNode(parent, parent.X, parent.Y + 1, 10);
            addNode(parent, parent.X + 1, parent.Y + 1, unitOblique);
        }
        public void addNode(SNode parent, int x, int y, int unit)
        {
            if (x >= 0 && y >= 0 && x < 500 / unitLen && y < 500 / unitLen)
            {
                SNode node = new SNode(parent, x, y);
                Boolean contain = inOpenList(node);
                if (notBlock(node) && !inCloseList(node) && !contain)//节点不存在于open和close，添加入open
                {
                    node.pre = parent;
                    node.H = getH(node);
                    node.G = parent.G + unit;
                    node.F = node.G + node.H;
                    openNode.Add(node);
                    graphics.FillRectangle(scanBrush, node.X * 10, node.Y * 10, 10, 10);
                    picturebox.Refresh();
                    Thread.Sleep(30);
                    if (node.equal(GoalNode))
                        GoalNode = node;
                }
                if (contain)//如果已经存在opennode，判断是否更新父节点
                {
                    if (parent.G + unit < node.G)
                    {
                        node.pre = parent;
                        node.G = parent.G + unit;
                        node.F = node.G + node.H;
                    }
                }
            }
        }
        public Boolean inCloseList(SNode node)
        {
            for (int i = 0; i < closeNode.Count; i++)
            {
                if (closeNode[i].equal(node))
                    return true;
            }
            return false;
        }
        public Boolean inOpenList(SNode node)
        {
            for (int i = 0; i < openNode.Count; i++)
            {
                if (openNode[i].equal(node))
                    return true;
            }
            return false;
        }

        public Boolean notBlock(SNode temp)
        {
            
            for (int i = 0; i < 3; i++)
            {
                int x = temp.X * 10+(int)(4.5*i);               
                for (int j = 0; j < 3; j++)
                {
                    int y = temp.Y * 10+(int)(4.5 * j);
                    if (innitMap.GetPixel(x, y).Name == "ff000000")
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int getH(SNode node)
        {
            return (Math.Abs(node.X - GoalNode.X) * 10 + Math.Abs(node.Y - GoalNode.Y) * 10);
        }
        public void drawWay()
        {
            SNode goal = GoalNode;
            SolidBrush b = new SolidBrush(Color.Blue);
            while (goal!= null)
            {
                Rectangle r = new Rectangle(goal.X * 10, goal.Y * 10, 10, 10);
                graphics.FillRectangle(b, r);
                goal = goal.pre;
            }
            picturebox.Refresh();
            graphics.Dispose();
        }

    }
}
