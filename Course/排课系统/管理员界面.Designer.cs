namespace 排课系统
{
    partial class 管理员界面
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(管理员界面));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.录入信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程信息录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排课时间段录入ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排课ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排课界面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空排课信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课表清空ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单周课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双周课程表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new 排课系统.MergeDataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mergeDataGridView1 = new 排课系统.MergeDataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.paikeDataSet = new 排课系统.paikeDataSet();
            this.kB1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kB1TableAdapter = new 排课系统.paikeDataSetTableAdapters.KB1TableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.课程查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paikeDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kB1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.录入信息ToolStripMenuItem,
            this.排课ToolStripMenuItem,
            this.课程表ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.导出课程表ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1115, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出系统ToolStripMenuItem});
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
            // 录入信息ToolStripMenuItem
            // 
            this.录入信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.课程信息录入ToolStripMenuItem,
            this.排课时间段录入ToolStripMenuItem});
            this.录入信息ToolStripMenuItem.Name = "录入信息ToolStripMenuItem";
            this.录入信息ToolStripMenuItem.Size = new System.Drawing.Size(81, 24);
            this.录入信息ToolStripMenuItem.Text = "录入信息";
            // 
            // 课程信息录入ToolStripMenuItem
            // 
            this.课程信息录入ToolStripMenuItem.Name = "课程信息录入ToolStripMenuItem";
            this.课程信息录入ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.课程信息录入ToolStripMenuItem.Text = "课程信息录入";
            this.课程信息录入ToolStripMenuItem.Click += new System.EventHandler(this.课程信息录入ToolStripMenuItem_Click);
            // 
            // 排课时间段录入ToolStripMenuItem
            // 
            this.排课时间段录入ToolStripMenuItem.Name = "排课时间段录入ToolStripMenuItem";
            this.排课时间段录入ToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.排课时间段录入ToolStripMenuItem.Text = "排课时间段录入";
            this.排课时间段录入ToolStripMenuItem.Click += new System.EventHandler(this.排课时间段录入ToolStripMenuItem_Click);
            // 
            // 排课ToolStripMenuItem
            // 
            this.排课ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.排课界面ToolStripMenuItem,
            this.清空排课信息ToolStripMenuItem,
            this.课表清空ToolStripMenuItem});
            this.排课ToolStripMenuItem.Name = "排课ToolStripMenuItem";
            this.排课ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.排课ToolStripMenuItem.Text = "排课";
            // 
            // 排课界面ToolStripMenuItem
            // 
            this.排课界面ToolStripMenuItem.Name = "排课界面ToolStripMenuItem";
            this.排课界面ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.排课界面ToolStripMenuItem.Text = "排课";
            this.排课界面ToolStripMenuItem.Click += new System.EventHandler(this.排课界面ToolStripMenuItem_Click);
            // 
            // 清空排课信息ToolStripMenuItem
            // 
            this.清空排课信息ToolStripMenuItem.Name = "清空排课信息ToolStripMenuItem";
            this.清空排课信息ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.清空排课信息ToolStripMenuItem.Text = "清空排课信息";
            this.清空排课信息ToolStripMenuItem.Click += new System.EventHandler(this.清空排课信息ToolStripMenuItem_Click);
            // 
            // 课表清空ToolStripMenuItem
            // 
            this.课表清空ToolStripMenuItem.Name = "课表清空ToolStripMenuItem";
            this.课表清空ToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.课表清空ToolStripMenuItem.Text = "课表清空";
            this.课表清空ToolStripMenuItem.Click += new System.EventHandler(this.课表清空ToolStripMenuItem_Click);
            // 
            // 课程表ToolStripMenuItem
            // 
            this.课程表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.课程查询ToolStripMenuItem});
            this.课程表ToolStripMenuItem.Name = "课程表ToolStripMenuItem";
            this.课程表ToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.课程表ToolStripMenuItem.Text = "课程表";
            this.课程表ToolStripMenuItem.Click += new System.EventHandler(this.课程表ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.联系管理员ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.帮助ToolStripMenuItem.Text = "联系";
            // 
            // 联系管理员ToolStripMenuItem
            // 
            this.联系管理员ToolStripMenuItem.Name = "联系管理员ToolStripMenuItem";
            this.联系管理员ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.联系管理员ToolStripMenuItem.Text = "联系教师";
            this.联系管理员ToolStripMenuItem.Click += new System.EventHandler(this.联系管理员ToolStripMenuItem_Click);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 59);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 59);
            this.button1.TabIndex = 24;
            this.button1.Text = "一键排课";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(139, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "有老师的留言";
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 31);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(132, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(91, 139);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(901, 350);
            this.tabControl1.TabIndex = 28;
            this.tabControl1.Visible = false;
            this.tabControl1.VisibleChanged += new System.EventHandler(this.tabControl1_VisibleChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(893, 321);
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
            this.dataGridView1.Size = new System.Drawing.Size(887, 317);
            this.dataGridView1.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mergeDataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(893, 321);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "双周";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mergeDataGridView1
            // 
            this.mergeDataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.mergeDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mergeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeDataGridView1.Location = new System.Drawing.Point(3, 2);
            this.mergeDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mergeDataGridView1.MergeColumnCells = ((System.Collections.Generic.List<string>)(resources.GetObject("mergeDataGridView1.MergeColumnCells")));
            this.mergeDataGridView1.MergeRows = ((System.Collections.Generic.List<int>)(resources.GetObject("mergeDataGridView1.MergeRows")));
            this.mergeDataGridView1.Name = "mergeDataGridView1";
            this.mergeDataGridView1.RowTemplate.Height = 23;
            this.mergeDataGridView1.Size = new System.Drawing.Size(887, 317);
            this.mergeDataGridView1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(917, 568);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "label2";
            // 
            // paikeDataSet
            // 
            this.paikeDataSet.DataSetName = "paikeDataSet";
            this.paikeDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kB1BindingSource
            // 
            this.kB1BindingSource.DataMember = "KB1";
            this.kB1BindingSource.DataSource = this.paikeDataSet;
            // 
            // kB1TableAdapter
            // 
            this.kB1TableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // 课程查询ToolStripMenuItem
            // 
            this.课程查询ToolStripMenuItem.Name = "课程查询ToolStripMenuItem";
            this.课程查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.课程查询ToolStripMenuItem.Text = "课程查询";
            this.课程查询ToolStripMenuItem.Click += new System.EventHandler(this.课程查询ToolStripMenuItem_Click);
            // 
            // 管理员界面
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1115, 599);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "管理员界面";
            this.Text = "管理员界面";
            this.TransparencyKey = System.Drawing.SystemColors.ActiveBorder;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.管理员界面_FormClosing_1);
            this.Load += new System.EventHandler(this.管理员界面_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paikeDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kB1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 录入信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程信息录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排课ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排课界面ToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private paikeDataSet paikeDataSet;
        private System.Windows.Forms.BindingSource kB1BindingSource;
        private paikeDataSetTableAdapters.KB1TableAdapter kB1TableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem 清空排课信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课表清空ToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private MergeDataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage2;
        private MergeDataGridView mergeDataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 单周课程表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双周课程表ToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem 排课时间段录入ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 课程查询ToolStripMenuItem;
    }
}