using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Diagnostics;
using Microsoft.Office.Interop.Excel;



namespace 排课系统
{
    public partial class 老师界面 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        SqlDataAdapter da1 = new SqlDataAdapter();//双周
        DataSet ds1 = new DataSet("paike");
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        string tid = "";
        string tname = "";
        string name1 = "";
        public 老师界面(string x)
        {
            InitializeComponent();
            tid = x;
        }
        public int compare(System.DateTime x, System.DateTime y)
        {
            if (System.DateTime.Compare(x, y) > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        private void 课程信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = "select * from Time where id ='1'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {
                string time1 = (string)read["time1"];
                System.DateTime dt1 = Convert.ToDateTime(time1);
                System.DateTime dt = System.DateTime.Now;
                int x1 = compare(dt1, dt);
                string time2 = (string)read["time2"];
                System.DateTime dt2 = Convert.ToDateTime(time2);
                int x2 = compare(dt, dt2);
                if (x1 == 0)
                {
                    string message = "排课提交时间还未开始,开始时间：" + time1;
                    MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (x2 == 0)
                    {
                        MessageBox.Show("志愿提交已经结束", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        教师排课信息录入 fom = new 教师排课信息录入(tid);
                        fom.Show();
                    }
                }
            }
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("update 工学院 set state ='{0}' where id ='{1}'", '0', tid);
            SqlCommand comm = new SqlCommand(sql, conn);
            int n = comm.ExecuteNonQuery();
            System.Environment.Exit(0);
        }

        private void 老师界面_FormClosing(object sender, FormClosingEventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("update 工学院 set state ='{0}' where id ='{1}'", '0', tid);
            SqlCommand comm = new SqlCommand(sql, conn);
            int n = comm.ExecuteNonQuery();
            System.Environment.Exit(0);
        }

        private void 课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
          
        }
        public void showcourse()//单周课表
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql1 = string.Format("select JIE as 课程节数,MON as 周一,TUE as 周二,WEN as 周三,THU as 周四,FRT as 周五 from KB1");
            conn.Open();
            SqlCommand comm = new SqlCommand(sql1, conn);
            da.SelectCommand = comm;
            SqlCommandBuilder bulider = new SqlCommandBuilder(da);
            da.Fill(ds, "KB1");
            dataGridView1.DataSource = ds.Tables["KB1"];
            conn.Close();
        }
        public void showcorse2()//双周课表
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql1 = string.Format("select JIE as 课程节数,MON as 周一,TUE as 周二,WEN as 周三,THU as 周四,FRT as 周五 from KB2");
            conn.Open();
            SqlCommand comm = new SqlCommand(sql1, conn);
            da1.SelectCommand = comm;
            SqlCommandBuilder bulider = new SqlCommandBuilder(da1);
            da1.Fill(ds1, "KB1");
            mergeDataGridView2.DataSource = ds1.Tables["KB1"];
            conn.Close();
        }

        private void 本学院教师联系方式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            教师联系方式 fom = new 教师联系方式();
            fom.Show();
        }

        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = "select * from Time where id ='1'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {
                string time1 = (string)read["time3"];
                System.DateTime dt1 = Convert.ToDateTime(time1);
                System.DateTime dt = System.DateTime.Now;
                int x1 = compare(dt1, dt);
                string time2 = (string)read["time4"];
                System.DateTime dt2 = Convert.ToDateTime(time2);
                int x2 = compare(dt2, dt);
                if (x1 == 0)
                {
                    string message = "课程表还未公布" + time1;
                    MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (x2 == 0)
                    {
                        MessageBox.Show("已到申请截止时间", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        教师提交申请界面 fom = new 教师提交申请界面(tid);
                        fom.Show();
                    }
                }
            }
           
        }

        private void 管理员回复ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理员回复 fom = new 管理员回复(tname,name1);
            fom.Show();
        }

        private void 老师界面_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql = string.Format("select * from 工学院 where id = '{0}'", tid);
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {
                string name = (string)read["name"];
                tname = name;
                conn.Close();
                conn.Open();
                string sql2 = string.Format("select * from 回复 where name = '{0}'", name);
                SqlCommand comm2 = new SqlCommand(sql2, conn);
                if (comm2.ExecuteScalar() == null)
                {
                    
                }
                else
                {
                    SqlDataReader rea = comm2.ExecuteReader();
                    if (rea.Read())
                    {
                        string[] x = ((string)rea["reason"]).Split(' ');
                        string na2me = (string)rea["name"];
                        foreach (string f in x)
                        {
                            tname += f;
                        }
                        name1 = na2me;
                        
                    }
                    else
                    {
                        MessageBox.Show("失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    pictureBox1.Visible = true;
                    label1.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void 导出课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        public static void ExportExcel(string fileName, DataGridView myDGV)
        {
            if (myDGV.Rows.Count > 0)
            {

                string saveFileName = "";
                //bool fileSaved = false;  
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xls";
                saveDialog.Filter = "Excel文件|*.xls";
                saveDialog.FileName = fileName;
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;
                if (saveFileName.IndexOf(":") < 0) return; //被点了取消   
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                    return;
                }

                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1  

                //写入标题  
                for (int i = 0; i < myDGV.ColumnCount; i++)
                {
                    worksheet.Cells[1, i + 1] = myDGV.Columns[i].HeaderText;
                }
                //写入数值  
                for (int r = 0; r < myDGV.Rows.Count; r++)
                {
                    for (int i = 0; i < myDGV.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = myDGV.Rows[r].Cells[i].Value;
                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应  
                                                      //   if (Microsoft.Office.Interop.cmbxType.Text != "Notification")  
                                                      //   {  
                                                      //       Excel.Range rg = worksheet.get_Range(worksheet.Cells[2, 2], worksheet.Cells[ds.Tables[0].Rows.Count + 1, 2]);  
                                                      //      rg.NumberFormat = "00000000";  
                                                      //   }  

                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);
                        //fileSaved = true;  
                    }
                    catch (Exception ex)
                    {
                        //fileSaved = false;  
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }

                }
                //else  
                //{  
                //    fileSaved = false;  
                //}  
                xlApp.Quit();
                GC.Collect();//强行销毁   
                             // if (fileSaved && System.IO.File.Exists(saveFileName)) System.Diagnostics.Process.Start(saveFileName); //打开EXCEL  
                MessageBox.Show("导出文件成功", "提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("报表为空,无表格需要导出", "提示", MessageBoxButtons.OK);
            }

        }

        private void 课程安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            课程信息 fom = new 课程信息(tname);//tname 是教师姓名
            fom.Show();
        }

        private void 单周课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = "单周课表";
            ExportExcel(x, dataGridView1);
        }

        private void 双周课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = "双周课表";
            ExportExcel(x, mergeDataGridView2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.DateTime dt = System.DateTime.Now;
            label2.Text = dt.ToString();
        }

        private void 排课时间录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 课表查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = "select * from Time where id ='1'";
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {
                string time1 = (string)read["time3"];
                System.DateTime dt1 = Convert.ToDateTime(time1);
                System.DateTime dt = System.DateTime.Now;
                int x1 = compare(dt1, dt);
                if (x1 == 0)
                {
                    string message = "课程还未公布,公布时间：" + time1;
                    MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {

                    课表查询 fom = new 课表查询();
                    fom.Show();

                }
            }
        }
    }
}
