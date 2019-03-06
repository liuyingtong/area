namespace 排课系统
{
    partial class 老师界面
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(老师界面));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程安排ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程信息录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单周课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双周课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.本学院教师联系方式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理员回复ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new 排课系统.MergeDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mergeDataGridView2 = new 排课系统.MergeDataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.课表查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.录入信息ToolStripMenuItem,
            this.课程表ToolStripMenuItem,
            this.导出课程表ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1316, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出系统ToolStripMenuItem,
            this.课程安排ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 课程安排ToolStripMenuItem
            // 
            this.课程安排ToolStripMenuItem.Name = "课程安排ToolStripMenuItem";
            this.课程安排ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.课程安排ToolStripMenuItem.Text = "课程安排";
            this.课程安排ToolStripMenuItem.Click += new System.EventHandler(this.课程安排ToolStripMenuItem_Click);
            // 
            // 录入信息ToolStripMenuItem
            // 
            this.录入信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.课程信息录入ToolStripMenuItem});
            this.录入信息ToolStripMenuItem.Name = "录入信息ToolStripMenuItem";
            this.录入信息ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.录入信息ToolStripMenuItem.Text = "录入信息";
            // 
            // 课程信息录入ToolStripMenuItem
            // 
            this.课程信息录入ToolStripMenuItem.Name = "课程信息录入ToolStripMenuItem";
            this.课程信息录入ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.课程信息录入ToolStripMenuItem.Text = "排课信息录入";
            this.课程信息录入ToolStripMenuItem.Click += new System.EventHandler(this.课程信息录入ToolStripMenuItem_Click);
            // 
            // 课程表ToolStripMenuItem
            // 
            this.课程表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.课表查询ToolStripMenuItem});
            this.课程表ToolStripMenuItem.Name = "课程表ToolStripMenuItem";
            this.课程表ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.课程表ToolStripMenuItem.Text = "课程表";
            this.课程表ToolStripMenuItem.Click += new System.EventHandler(this.课程表ToolStripMenuItem_Click);
            // 
            // 导出课程表ToolStripMenuItem
            // 
            this.导出课程表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单周课程表ToolStripMenuItem,
            this.双周课程表ToolStripMenuItem});
            this.导出课程表ToolStripMenuItem.Name = "导出课程表ToolStripMenuItem";
            this.导出课程表ToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.导出课程表ToolStripMenuItem.Text = "导出课程表";
            this.导出课程表ToolStripMenuItem.Click += new System.EventHandler(this.导出课程表ToolStripMenuItem_Click);
            // 
            // 单周课程表ToolStripMenuItem
            // 
            this.单周课程表ToolStripMenuItem.Name = "单周课程表ToolStripMenuItem";
            this.单周课程表ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.单周课程表ToolStripMenuItem.Text = "单周课程表";
            this.单周课程表ToolStripMenuItem.Click += new System.EventHandler(this.单周课程表ToolStripMenuItem_Click);
            // 
            // 双周课程表ToolStripMenuItem
            // 
            this.双周课程表ToolStripMenuItem.Name = "双周课程表ToolStripMenuItem";
            this.双周课程表ToolStripMenuItem.Size = new System.Drawing.Size(153, 24);
            this.双周课程表ToolStripMenuItem.Text = "双周课程表";
            this.双周课程表ToolStripMenuItem.Click += new System.EventHandler(this.双周课程表ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.联系管理员ToolStripMenuItem,
            this.本学院教师联系方式ToolStripMenuItem,
            this.管理员回复ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "联系";
            // 
            // 联系管理员ToolStripMenuItem
            // 
            this.联系管理员ToolStripMenuItem.Name = "联系管理员ToolStripMenuItem";
            this.联系管理员ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.联系管理员ToolStripMenuItem.Text = "联系管理员";
            this.联系管理员ToolStripMenuItem.Click += new System.EventHandler(this.联系管理员ToolStripMenuItem_Click);
            // 
            // 本学院教师联系方式ToolStripMenuItem
            // 
            this.本学院教师联系方式ToolStripMenuItem.Name = "本学院教师联系方式ToolStripMenuItem";
            this.本学院教师联系方式ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.本学院教师联系方式ToolStripMenuItem.Text = "本学院教师联系方式";
            this.本学院教师联系方式ToolStripMenuItem.Click += new System.EventHandler(this.本学院教师联系方式ToolStripMenuItem_Click);
            // 
            // 管理员回复ToolStripMenuItem
            // 
            this.管理员回复ToolStripMenuItem.Name = "管理员回复ToolStripMenuItem";
            this.管理员回复ToolStripMenuItem.Size = new System.Drawing.Size(213, 24);
            this.管理员回复ToolStripMenuItem.Text = "管理员回复";
            this.管理员回复ToolStripMenuItem.Click += new System.EventHandler(this.管理员回复ToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, 34);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(156, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "有管理员回复";
            this.label1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(120, 106);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1037, 378);
            this.tabControl1.TabIndex = 29;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(1029, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "单周";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 2);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MergeColumnCells = ((System.Collections.Generic.List<string>)(resources.GetObject("dataGridView1.MergeColumnCells")));
            this.dataGridView1.MergeRows = ((System.Collections.Generic.List<int>)(resources.GetObject("dataGridView1.MergeRows")));
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1023, 345);
            this.dataGridView1.TabIndex = 29;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mergeDataGridView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(1029, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "双周";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mergeDataGridView2
            // 
            this.mergeDataGridView2.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.mergeDataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mergeDataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeDataGridView2.Location = new System.Drawing.Point(3, 2);
            this.mergeDataGridView2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mergeDataGridView2.MergeColumnCells = ((System.Collections.Generic.List<string>)(resources.GetObject("mergeDataGridView2.MergeColumnCells")));
            this.mergeDataGridView2.MergeRows = ((System.Collections.Generic.List<int>)(resources.GetObject("mergeDataGridView2.MergeRows")));
            this.mergeDataGridView2.Name = "mergeDataGridView2";
            this.mergeDataGridView2.RowTemplate.Height = 23;
            this.mergeDataGridView2.Size = new System.Drawing.Size(1023, 345);
            this.mergeDataGridView2.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1083, 490);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 30;
            this.label2.Text = "label2";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 课表查询ToolStripMenuItem
            // 
            this.课表查询ToolStripMenuItem.Name = "课表查询ToolStripMenuItem";
            this.课表查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.课表查询ToolStripMenuItem.Text = "课表查询";
            this.课表查询ToolStripMenuItem.Click += new System.EventHandler(this.课表查询ToolStripMenuItem_Click);
            // 
            // 老师界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1316, 524);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "老师界面";
            this.Text = "老师界面";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.老师界面_FormClosing);
            this.Load += new System.EventHandler(this.老师界面_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程信息录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 本学院教师联系方式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理员回复ToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 课程安排ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MergeDataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private MergeDataGridView mergeDataGridView2;
        private System.Windows.Forms.ToolStripMenuItem 单周课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双周课程表ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 课表查询ToolStripMenuItem;
    }
}