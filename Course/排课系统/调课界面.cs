using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace 排课系统
{
    public partial class 调课界面 : Form
    {
        public 调课界面()
        {
            InitializeComponent();
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "")
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                conn.Open();
                string sql = string.Format("select * from KB1 where JIE = '{0}'", comboBox2.Text);
                SqlCommand comm = new SqlCommand(sql, conn);
                SqlDataReader read = comm.ExecuteReader();
                if (read.Read())
                {
                    string x = (string)read[comboBox1.Text];
                    conn.Close();
                    conn.Open();
                    string temp = x;
                    string sql1 = string.Format("select * from KB1 where JIE = '{0}'", comboBox3.Text);
                    SqlCommand comm1 = new SqlCommand(sql1, conn);
                    SqlDataReader rea = comm1.ExecuteReader();
                    if (rea.Read())
                    {
                        string y = (string)rea[comboBox4.Text];
                        conn.Close();
                        conn.Open();
                        int m = int.Parse(comboBox3.Text);
                        int n = int.Parse(comboBox2.Text);
                        string sql2 = string.Format("update KB1 set {0} = '{1}' where JIE ='{2}' or JIE ='{3}' or JIE = '{4}' or JIE = '{5}'", comboBox4.Text, x, m, m + 1, m + 2, m + 3);
                        SqlCommand comm2 = new SqlCommand(sql2, conn);
                        int c = comm2.ExecuteNonQuery();
                        if (n < 0)
                        {
                            MessageBox.Show("更新失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            conn.Close();
                            conn.Open();
                            string sql3 = string.Format("update KB1 set {0} = '{1}' where JIE ='{2}' or JIE ='{3}' or JIE = '{4}' or JIE = '{5}'", comboBox1.Text, y, n, n + 1, n + 2, n + 3);
                            SqlCommand comm3 = new SqlCommand(sql3, conn);
                            int f = comm3.ExecuteNonQuery();
                            if (f < 0)
                            {
                                MessageBox.Show("更新失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("调课成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                ds.Clear();
                                sh();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("读取失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("读取失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("不能为空", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sh();
        }
        public void sh()
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

}
