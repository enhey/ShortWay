using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    class Node
    {
        public Node pre;
        public Point data;
        public Node() { }
        public Node(Node pre, Point data)
        {
            this.pre = pre;
            this.data = data;
        }
    }
    class RRT
    {
        PictureBox picturebox;
        Image image;
        Graphics graphics;
        Pen connetPen = new Pen(Color.Yellow, 3);
        private Point pBegin;
        private Point pGoal;
        Point newNode = new Point();
        Bitmap map;
        List<Node> allNode = new List<Node>();
        List<Node> optNode = new List<Node>();
        const int length = 30;
        public RRT(PictureBox picturebox, Point b, Point g)
        {
            this.picturebox = picturebox;
            image = picturebox.Image;
            map = (Bitmap)image;
            graphics = Graphics.FromImage((Image)map);
            this.pBegin = b; this.pGoal = g;
            Node beginPoint = new Node(null, pBegin);
            allNode.Add(beginPoint);
        }
        public void findWay()
        {
            double GoadLenght;
            //int i = 50;
            while (true)
            {
                Point random = randomNode();
                Node nearest = findNearest(random);
                if (canConnet(nearest, random))
                {
                    connet(nearest, random);
                    allNode.Add(new Node(nearest, newNode));
                    GoadLenght = Math.Sqrt((newNode.X - pGoal.X) * (newNode.X - pGoal.X) + (newNode.Y - pGoal.Y) * (newNode.Y - pGoal.Y));
                    //GoadLenght = Math.Sqrt((allNode.Last().data.X - pGoal.X) * (allNode.Last().data.X - pGoal.X) + (allNode.Last().data.Y - pGoal.Y) * (allNode.Last().data.Y - pGoal.Y));
                    if (GoadLenght < 30)
                    {
                        Node goalPoint = new Node(allNode.Last(), pGoal);
                        allNode.Add(goalPoint);
                        connet(goalPoint, pGoal);
                        drawWay();
                        picturebox.Image = map;
                        optimize();
                        // picturebox.Invalidate();
                        picturebox.Image = map;
                        graphics.Dispose();
                        break;
                    }

                }
                //             i--;
            }
        }
        public Point randomNode()//图中产生随机点
        {
            Point randomNode = new Point();
            Random r = new Random();
            if (r.Next(0, 11) < 2)
            {
                randomNode = pGoal;
            }
            else
            {
                randomNode.X = r.Next(0, 500);
                randomNode.Y = r.Next(0, 500);
            }
            return randomNode;
        }
        public Node findNearest(Point randomNode)
        {
            //找距离随机点最近的节点
            Node nearest = allNode[0];
            double shortLength = Math.Sqrt((nearest.data.X - randomNode.X) * (nearest.data.X - randomNode.X) + (nearest.data.Y - randomNode.Y) * (nearest.data.Y - randomNode.Y));
            double tempLenght;
            for (int i = 1; i < allNode.Count; i++)
            {
                tempLenght = Math.Sqrt((allNode[i].data.X - randomNode.X) * (allNode[i].data.X - randomNode.X) + (allNode[i].data.Y - randomNode.Y) * (allNode[i].data.Y - randomNode.Y));
                if (shortLength > tempLenght)
                {
                    nearest = allNode[i];
                    shortLength = tempLenght;
                }
            }
            return nearest;
        }
        public Boolean canConnet(Node nearest, Point random)//以一个阀值的长度连接radomNode和nearest
        {
            double theta;
            // theta = Math.Atan(Math.Abs((random.Y - nearest.data.Y) / (random.X - nearest.data.X)));
            theta = Math.Atan2((random.Y - nearest.data.Y), (random.X - nearest.data.X));
            int dtx = (int)(length * Math.Cos(theta)), dty = (int)(length * Math.Sin(theta));
            newNode.X = nearest.data.X + dtx;
            newNode.Y = nearest.data.Y + dty;
            if (newNode.X > 500 || newNode.Y > 500 || newNode.X < 0 || newNode.Y < 0)
                return false;
            for (int i = 1; i <= 6; i++)
            {
                if (map.GetPixel((nearest.data.X + ((dtx* i) / 6) ), (nearest.data.Y + ((dty * i) / 6))).Name == "ff000000")
                {
                    return false;
                }
            }
            return true;
        }
        public void connet(Node nearest, Point newnode)
        {
            graphics.DrawLine(connetPen, nearest.data, newNode);
            //picturebox.Invalidate();
            //picturebox.Image = (Image)map;
            picturebox.Refresh();
            //allNode.Add(new Node(nearest, newNode));
            Thread.Sleep(30);
        }

        public void drawWay()
        {
            Node temp = allNode.Last();
            Pen firPen = new Pen(Color.Blue, 5);
            while (temp.pre != null)
            {
                graphics.DrawLine(firPen, temp.data, temp.pre.data);
                optNode.Add(temp);
                temp = temp.pre;
            }
            optNode.Add(temp);
        }

        public void optimize()
        {
            Pen opPen = new Pen(Color.Pink, 5);
            Node back = optNode.First();
            while (back.pre != null)
            {
                Node front;
                for (int i = optNode.Count - 1; i >= 0; i--)
                {
                    front = optNode[i];
                    if (opConnet(front, back))
                    {
                        graphics.DrawLine(opPen, front.data, back.data);                       
                        back = front;
                        break;
                    }
                }
            }
        }

        public Boolean opConnet(Node front, Node back)//以一个阀值的长度连接radomNode和nearest
        {
            double theta;
            theta = Math.Atan2((back.data.Y - front.data.Y), (back.data.X - front.data.X));
            double opLength;
            opLength = Math.Sqrt((back.data.X - front.data.X) * (back.data.X - front.data.X) + (back.data.Y - front.data.Y) * (back.data.Y - front.data.Y));
            int dtx = (int)(opLength * Math.Cos(theta)), dty = (int)(opLength * Math.Sin(theta));
            int check =(int) (opLength / 5);
            for (int i = 1; i <= check; i++)
            {

                if (map.GetPixel((front.data.X + (dtx* i) / check) , (front.data.Y + (dty* i) / check) ).Name == "ff000000")
                {
                    return false;
                }
            }
            return true;
        }
    }
}
