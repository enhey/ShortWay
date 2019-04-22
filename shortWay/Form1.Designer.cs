namespace shortWay
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clear = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.stop = new System.Windows.Forms.Button();
            this.star = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mouse = new System.Windows.Forms.Button();
            this.goalY = new System.Windows.Forms.TextBox();
            this.beginY = new System.Windows.Forms.TextBox();
            this.goalX = new System.Windows.Forms.TextBox();
            this.beignX = new System.Windows.Forms.TextBox();
            this.obstacle = new System.Windows.Forms.Button();
            this.goal = new System.Windows.Forms.Button();
            this.begin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clear);
            this.groupBox2.Controls.Add(this.delete);
            this.groupBox2.Controls.Add(this.stop);
            this.groupBox2.Controls.Add(this.star);
            this.groupBox2.Location = new System.Drawing.Point(609, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 195);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(127, 128);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 3;
            this.clear.Text = "清除所有";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(24, 128);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(75, 23);
            this.delete.TabIndex = 2;
            this.delete.Text = "删除路径";
            this.delete.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(127, 51);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 1;
            this.stop.Text = "停止";
            this.stop.UseVisualStyleBackColor = true;
            // 
            // star
            // 
            this.star.Location = new System.Drawing.Point(24, 51);
            this.star.Name = "star";
            this.star.Size = new System.Drawing.Size(75, 23);
            this.star.TabIndex = 0;
            this.star.Text = "开始";
            this.star.UseVisualStyleBackColor = true;
            this.star.Click += new System.EventHandler(this.Star_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mouse);
            this.groupBox1.Controls.Add(this.goalY);
            this.groupBox1.Controls.Add(this.beginY);
            this.groupBox1.Controls.Add(this.goalX);
            this.groupBox1.Controls.Add(this.beignX);
            this.groupBox1.Controls.Add(this.obstacle);
            this.groupBox1.Controls.Add(this.goal);
            this.groupBox1.Controls.Add(this.begin);
            this.groupBox1.Location = new System.Drawing.Point(609, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 274);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // mouse
            // 
            this.mouse.Location = new System.Drawing.Point(24, 180);
            this.mouse.Name = "mouse";
            this.mouse.Size = new System.Drawing.Size(96, 23);
            this.mouse.TabIndex = 8;
            this.mouse.Text = "指针";
            this.mouse.UseVisualStyleBackColor = true;
            this.mouse.Click += new System.EventHandler(this.mouse_Click);
            // 
            // goalY
            // 
            this.goalY.Location = new System.Drawing.Point(177, 112);
            this.goalY.Name = "goalY";
            this.goalY.Size = new System.Drawing.Size(40, 25);
            this.goalY.TabIndex = 7;
            // 
            // beginY
            // 
            this.beginY.Location = new System.Drawing.Point(177, 35);
            this.beginY.Name = "beginY";
            this.beginY.Size = new System.Drawing.Size(40, 25);
            this.beginY.TabIndex = 6;
            // 
            // goalX
            // 
            this.goalX.Location = new System.Drawing.Point(117, 112);
            this.goalX.Name = "goalX";
            this.goalX.Size = new System.Drawing.Size(40, 25);
            this.goalX.TabIndex = 5;
            // 
            // beignX
            // 
            this.beignX.Location = new System.Drawing.Point(117, 35);
            this.beignX.Name = "beignX";
            this.beignX.Size = new System.Drawing.Size(40, 25);
            this.beignX.TabIndex = 4;
            // 
            // obstacle
            // 
            this.obstacle.Location = new System.Drawing.Point(141, 180);
            this.obstacle.Name = "obstacle";
            this.obstacle.Size = new System.Drawing.Size(96, 23);
            this.obstacle.TabIndex = 3;
            this.obstacle.Text = "随机障碍";
            this.obstacle.UseVisualStyleBackColor = true;
            this.obstacle.Click += new System.EventHandler(this.obstacle_Click);
            // 
            // goal
            // 
            this.goal.Location = new System.Drawing.Point(24, 111);
            this.goal.Name = "goal";
            this.goal.Size = new System.Drawing.Size(75, 23);
            this.goal.TabIndex = 2;
            this.goal.Text = "添加终点";
            this.goal.UseVisualStyleBackColor = true;
            this.goal.Click += new System.EventHandler(this.goal_Click);
            // 
            // begin
            // 
            this.begin.Location = new System.Drawing.Point(24, 35);
            this.begin.Name = "begin";
            this.begin.Size = new System.Drawing.Size(75, 23);
            this.begin.TabIndex = 0;
            this.begin.Text = "添加起点";
            this.begin.UseVisualStyleBackColor = true;
            this.begin.Click += new System.EventHandler(this.begin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Snow;
            this.pictureBox1.Image = global::shortWay.Properties.Resources.MapBackground;
            this.pictureBox1.Location = new System.Drawing.Point(30, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 567);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button begin;
        private System.Windows.Forms.Button goal;
        private System.Windows.Forms.Button obstacle;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button star;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.TextBox goalY;
        private System.Windows.Forms.TextBox beginY;
        private System.Windows.Forms.TextBox goalX;
        private System.Windows.Forms.TextBox beignX;
        private System.Windows.Forms.Button mouse;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

