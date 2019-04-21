using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortWay
{
    class RRT
    {
        Bitmap picture;
        private Point pBegin;
        private Point pGoal;
        Graphics graphics;
        Bitmap map;
        public RRT(Bitmap picture, Point b,Point g)
        {
            this.picture = picture;
            this.pBegin = b;this.pGoal = g;
            graphics = Graphics.FromImage((Image)picture);


           
        }
        public void findWay()
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "photo files (*.jpg)|*.jpg";
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.FileName = "newphoto";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                using (System.IO.MemoryStream mem = new MemoryStream())
                {
                    //这句很重要，不然不能正确保存图片或出错（关键就这一句）
                    //Bitmap bmp = new Bitmap(pictureBox_front.Image);
                    //保存到磁盘文件
                    picture.Save(@saveFileDialog1.FileName);
                    picture.Dispose();
                    MessageBox.Show("附件另存成功！", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        public Point randomNode()//图中产生随机点
        {
            Point p = new Point();
            Random r = new Random();
            p.X=r.Next(0, 500); ;p.Y = r.Next(0, 500);
            //if(picture.)
            return p;
        }
    }
}
