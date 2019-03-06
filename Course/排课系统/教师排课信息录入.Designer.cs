namespace 排课系统
{
    partial class 教师排课信息录入
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
            this.label1 = new System.Windows.Forms.Label();
            this.第一志愿星期 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.第二志愿星期 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.第三志愿星期 = new System.Windows.Forms.ComboBox();
            this.第一志愿时间1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.第二志愿时间1 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.第三志愿时间1 = new System.Windows.Forms.ComboBox();
            this.提交 = new System.Windows.Forms.Button();
            this.完成 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(257, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "意愿时段";
            // 
            // 第一志愿星期
            // 
            this.第一志愿星期.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第一志愿星期.FormattingEnabled = true;
            this.第一志愿星期.Items.AddRange(new object[] {
            "周一",
            "周二",
            "周三",
            "周四",
            "周五"});
            this.第一志愿星期.Location = new System.Drawing.Point(228, 106);
            this.第一志愿星期.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第一志愿星期.Name = "第一志愿星期";
            this.第一志愿星期.Size = new System.Drawing.Size(92, 20);
            this.第一志愿星期.TabIndex = 1;
            this.第一志愿星期.SelectedIndexChanged += new System.EventHandler(this.第一志愿星期_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(118, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "第一志愿：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(118, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "第二志愿：";
            // 
            // 第二志愿星期
            // 
            this.第二志愿星期.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第二志愿星期.FormattingEnabled = true;
            this.第二志愿星期.Items.AddRange(new object[] {
            "周一",
            "周二",
            "周三",
            "周四",
            "周五"});
            this.第二志愿星期.Location = new System.Drawing.Point(228, 167);
            this.第二志愿星期.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第二志愿星期.Name = "第二志愿星期";
            this.第二志愿星期.Size = new System.Drawing.Size(92, 20);
            this.第二志愿星期.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(118, 232);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "第三志愿：";
            // 
            // 第三志愿星期
            // 
            this.第三志愿星期.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第三志愿星期.FormattingEnabled = true;
            this.第三志愿星期.Items.AddRange(new object[] {
            "周一",
            "周二",
            "周三",
            "周四",
            "周五"});
            this.第三志愿星期.Location = new System.Drawing.Point(228, 232);
            this.第三志愿星期.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第三志愿星期.Name = "第三志愿星期";
            this.第三志愿星期.Size = new System.Drawing.Size(92, 20);
            this.第三志愿星期.TabIndex = 6;
            // 
            // 第一志愿时间1
            // 
            this.第一志愿时间1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第一志愿时间1.FormattingEnabled = true;
            this.第一志愿时间1.Items.AddRange(new object[] {
            "8",
            "10",
            "13",
            "15",
            "18"});
            this.第一志愿时间1.Location = new System.Drawing.Point(340, 104);
            this.第一志愿时间1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第一志愿时间1.Name = "第一志愿时间1";
            this.第一志愿时间1.Size = new System.Drawing.Size(40, 20);
            this.第一志愿时间1.TabIndex = 7;
            this.第一志愿时间1.SelectedIndexChanged += new System.EventHandler(this.第一志愿时间1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(383, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "时——";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(484, 106);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "时";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(484, 170);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "时";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(383, 169);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "时——";
            // 
            // 第二志愿时间1
            // 
            this.第二志愿时间1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第二志愿时间1.FormattingEnabled = true;
            this.第二志愿时间1.Items.AddRange(new object[] {
            "8",
            "10",
            "13",
            "15",
            "18"});
            this.第二志愿时间1.Location = new System.Drawing.Point(340, 168);
            this.第二志愿时间1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第二志愿时间1.Name = "第二志愿时间1";
            this.第二志愿时间1.Size = new System.Drawing.Size(40, 20);
            this.第二志愿时间1.TabIndex = 11;
            this.第二志愿时间1.SelectedIndexChanged += new System.EventHandler(this.第二志愿时间1_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(484, 234);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(22, 15);
            this.label9.TabIndex = 18;
            this.label9.Text = "时";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(383, 232);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 15);
            this.label10.TabIndex = 16;
            this.label10.Text = "时——";
            // 
            // 第三志愿时间1
            // 
            this.第三志愿时间1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.第三志愿时间1.FormattingEnabled = true;
            this.第三志愿时间1.Items.AddRange(new object[] {
            "8",
            "10",
            "13",
            "15",
            "18"});
            this.第三志愿时间1.Location = new System.Drawing.Point(340, 231);
            this.第三志愿时间1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.第三志愿时间1.Name = "第三志愿时间1";
            this.第三志愿时间1.Size = new System.Drawing.Size(40, 20);
            this.第三志愿时间1.TabIndex = 15;
            this.第三志愿时间1.SelectedIndexChanged += new System.EventHandler(this.第三志愿时间1_SelectedIndexChanged);
            // 
            // 提交
            // 
            this.提交.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.提交.Location = new System.Drawing.Point(203, 298);
            this.提交.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.提交.Name = "提交";
            this.提交.Size = new System.Drawing.Size(97, 25);
            this.提交.TabIndex = 19;
            this.提交.Text = "提交";
            this.提交.UseVisualStyleBackColor = true;
            this.提交.Click += new System.EventHandler(this.提交_Click);
            // 
            // 完成
            // 
            this.完成.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.完成.Location = new System.Drawing.Point(350, 298);
            this.完成.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.完成.Name = "完成";
            this.完成.Size = new System.Drawing.Size(97, 25);
            this.完成.TabIndex = 20;
            this.完成.Text = "完成";
            this.完成.UseVisualStyleBackColor = true;
            this.完成.Click += new System.EventHandler(this.完成_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(448, 104);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(32, 21);
            this.textBox1.TabIndex = 21;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(448, 168);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(32, 21);
            this.textBox2.TabIndex = 22;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(448, 231);
            this.textBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(32, 21);
            this.textBox3.TabIndex = 23;
            // 
            // 教师排课信息录入
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(671, 366);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.完成);
            this.Controls.Add(this.提交);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.第三志愿时间1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.第二志愿时间1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.第一志愿时间1);
            this.Controls.Add(this.第三志愿星期);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.第二志愿星期);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.第一志愿星期);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "教师排课信息录入";
            this.Text = "提交界面";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox 第一志愿星期;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox 第二志愿星期;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox 第三志愿星期;
        private System.Windows.Forms.ComboBox 第一志愿时间1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox 第二志愿时间1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox 第三志愿时间1;
        private System.Windows.Forms.Button 提交;
        private System.Windows.Forms.Button 完成;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}