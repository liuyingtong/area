namespace 排课系统
{
    partial class 课程信息
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(课程信息));
            this.mergeDataGridView1 = new 排课系统.MergeDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // mergeDataGridView1
            // 
            this.mergeDataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.mergeDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mergeDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mergeDataGridView1.Location = new System.Drawing.Point(0, 0);
            this.mergeDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mergeDataGridView1.MergeColumnCells = ((System.Collections.Generic.List<string>)(resources.GetObject("mergeDataGridView1.MergeColumnCells")));
            this.mergeDataGridView1.MergeRows = ((System.Collections.Generic.List<int>)(resources.GetObject("mergeDataGridView1.MergeRows")));
            this.mergeDataGridView1.Name = "mergeDataGridView1";
            this.mergeDataGridView1.RowTemplate.Height = 23;
            this.mergeDataGridView1.Size = new System.Drawing.Size(569, 172);
            this.mergeDataGridView1.TabIndex = 0;
            // 
            // 课程信息
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 172);
            this.Controls.Add(this.mergeDataGridView1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "课程信息";
            this.Text = "课程信息";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mergeDataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MergeDataGridView mergeDataGridView1;

    }
}