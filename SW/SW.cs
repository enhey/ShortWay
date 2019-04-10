using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SW
{
    public partial class SW : Form
    {
        public SW()
        {
            InitializeComponent();
        }

        private void begin_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Cross;
            panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDownB);
        }

        private void goal_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Cross;
            panel1.MouseDown += new MouseEventHandler(this.panel1_MouseDownG);
        }

        private void panel1_MouseDownG(object sender, MouseEventArgs e)
        {
            Point pPanel = new Point();
            pPanel = panel1.PointToClient(Control.MousePosition);
            goalX.Text = pPanel.X.ToString();
        }
        private void panel1_MouseDownB(object sender, MouseEventArgs e)
        {
            Point pPanel = new Point();
            pPanel = panel1.PointToClient(Control.MousePosition);
            beignX.Text = pPanel.X.ToString();
        }
        private void mouse_Click(object sender, EventArgs e)
        {
            panel1.Cursor = Cursors.Arrow;
        }
    }
}
