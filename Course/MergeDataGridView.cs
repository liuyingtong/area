using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace CourseArrangement
{
    public partial class MergeDataGridView : DataGridView
    {
        public MergeDataGridView()
        {
            InitializeComponent();
        }


        #region 重写的事件

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && e.ColumnIndex > -1)
                {
                    DrawCell(e);
                }
                base.OnCellPainting(e);
            }
            catch
            { }
        }
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);
        }
        #endregion

        #region 自定义方法

        private void DrawCell(DataGridViewCellPaintingEventArgs e)
        {
            if (e.CellStyle.Alignment == DataGridViewContentAlignment.NotSet)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            Brush gridBrush = new SolidBrush(this.GridColor);
            SolidBrush backBrush = new SolidBrush(e.CellStyle.BackColor);
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);

            Pen gridLinePen = new Pen(gridBrush);

            #region 合并行单元格
            if (this.MergeRows.Contains(e.RowIndex)&&e.ColumnIndex>0)
            {
                int cellHeight = e.CellBounds.Height;
                int leftCol = e.ColumnIndex, rightCol = this.ColumnCount - leftCol;

                if (this.Rows[e.RowIndex].Selected)
                {
                    backBrush.Color = e.CellStyle.SelectionBackColor;
                    fontBrush.Color = e.CellStyle.SelectionForeColor;
                }
                //以背景色填充
                e.Graphics.FillRectangle(backBrush, e.CellBounds);
                PaintingFont(e, leftCol, 0, rightCol, 1);
                //最右侧边线
                if (rightCol == 1)
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);
                    
                }
                // 底边线
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);

                e.Handled = true;
                return;
            }
            #endregion

            #region 合并列单元格
            int cellWidth = e.CellBounds.Width;
            int DownRows = 0, UpRows = 0, count = 0;
            string value = e.Value.ToString().Trim();
            if (value != "")
            {
                for (int i = e.RowIndex; i < this.Rows.Count; i++)
                {
                    if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Trim().Equals(value))
                    {
                        DownRows++;
                    }
                    else
                        break;
                }
                for (int i = e.RowIndex-1; i >= 0; i--)
                {
                    if (this.Rows[i].Cells[e.ColumnIndex].Value.ToString().Trim().Equals(value))
                    {
                        UpRows++;
                    }
                    else
                        break;
                }

                count = DownRows + UpRows;
                if (count < 2)
                {
                    return;
                }
                if (this.Rows[e.RowIndex].Selected)
                {
                    backBrush.Color = e.CellStyle.SelectionBackColor;
                    fontBrush.Color = e.CellStyle.SelectionForeColor;
                }
                //以背景色填充
                e.Graphics.FillRectangle(backBrush, e.CellBounds);
                //画字符串
                PaintingFont(e, 0, UpRows, 1, DownRows);
                if (DownRows == 1)
                {
                    e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left, e.CellBounds.Bottom - 1, e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    count = 0;
                }
                // 画右边线
                e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1, e.CellBounds.Top, e.CellBounds.Right - 1, e.CellBounds.Bottom);

                e.Handled = true;

            }
            #endregion

        }
        /// <summary>
        /// 画字符串
        /// </summary>
        /// <param name="e"></param>
        /// <param name="cellwidth"></param>
        /// <param name="UpRows"></param>
        /// <param name="DownRows"></param>
        /// <param name="count"></param>
        private void PaintingFont(System.Windows.Forms.DataGridViewCellPaintingEventArgs e, int left, int up, int right, int down)
        {
            SolidBrush fontBrush = new SolidBrush(e.CellStyle.ForeColor);
            String content = e.Value.ToString();
            int fontheight = (int)e.Graphics.MeasureString(content, e.CellStyle.Font).Height;
            int fontwidth = (int)e.Graphics.MeasureString(content, e.CellStyle.Font).Width;
            int cellheight = e.CellBounds.Height;
            int cellwidth = e.CellBounds.Width;
            int L = e.CellBounds.X - left * cellwidth;
            int U = e.CellBounds.Y - up * cellheight;
            int R = e.CellBounds.X + right * cellwidth;
            int B = e.CellBounds.Y + down * cellheight;

            int i = 1, l = content.Length;
            String str = content;
            while (R - L < fontwidth && i < 6)
            {//字符串过长，分段
                i++;
                str = "";
                int j, m = l / i;
                for (j = 0; j < i - 1; j++)
                {

                    str += content.Substring(j * m, m) + "\n";
                }
                str += content.Substring(j *m);
                fontheight = (int)e.Graphics.MeasureString(str, e.CellStyle.Font).Height;
                fontwidth = (int)e.Graphics.MeasureString(str, e.CellStyle.Font).Width;
            }

            e.Graphics.DrawString(str, e.CellStyle.Font, fontBrush, L + (R - L - fontwidth) / 2, U + (B - U - fontheight) / 2);


        }
        #endregion

        

        #region 属性
        [MergableProperty(false)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Description("设置或获取合并的各列单元格集合"), Browsable(true), Category("列单元格合并")]

        public List<string> MergeColumnCells
        {
            get
            {
                return _mergeColumnCells;
            }
            set
            {
                _mergeColumnCells = value;
            }
        }
        private List<string> _mergeColumnCells = new List<string>();

        [MergableProperty(false)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Visible)]
        [Localizable(true)]
        [Description("设置或获取合并的行集合"), Browsable(true), Category("行单元格合并")]

        public List<int> MergeRows
        {
            get
            {
                return _mergeRows;
            }
            set
            {
                _mergeRows = value;
            }
        }
        private List<int> _mergeRows = new List<int>();

        #endregion



    }
}
