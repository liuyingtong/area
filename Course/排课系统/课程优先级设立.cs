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
    public partial class 课程优先级设立 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        int count = 0;
        public 课程优先级设立()
        {
            InitializeComponent();
        }
        public void  getnumber()
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("select * from course where id ='1'");
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {
                string num = (string)read["count"];
                count = int.Parse(num);
            }
        }
        public void showcourse()//显示数据表
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql1 = string.Format("select name as 课程,youxianji as 优先级设立,wid as 大课 from course order by youxianji");
            conn.Open();
            SqlCommand comm = new SqlCommand(sql1, conn);
            da.SelectCommand = comm;
            SqlCommandBuilder bulider = new SqlCommandBuilder(da);
            da.Fill(ds, "工学院");
            dataGridView1.DataSource = ds.Tables["工学院"];
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            getnumber();
            showcourse();//调用
            for (int i = 1; i <= 10; i++)
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                conn.Open();
                string sql1 = string.Format("select * from course where id = '{0}'", i);
                SqlCommand comm = new SqlCommand(sql1, conn);
                SqlDataReader read = comm.ExecuteReader();
                if (read.Read())
                {
                    comboBox1.Items.Add((string)read["name"]);
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != ""&&comboBox3.Text!="")
            {
                if (comboBox3.Text == "0")
                {
                    SqlConnection conn = new SqlConnection(strconnecting);
                    conn.Open();
                    string sql = string.Format("update course set youxianji ='{0}',wid='{1}' where name = '{2}'", comboBox2.Text, int.Parse(comboBox3.Text), comboBox1.Text);//修改
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int n = comm.ExecuteNonQuery();
                    if (n < 0)
                    {
                        MessageBox.Show("当前无此课程或者输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("设置成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        ds.Clear();
                        showcourse();
                    }
                    conn.Close();
                }
                else
                {
                    if (count < 3)
                    {
                        count++;
                        SqlConnection conn = new SqlConnection(strconnecting);
                        conn.Open();
                        string sql = string.Format("update course set youxianji ='{0}',wid='{1}',count='{2}' where name = '{3}'", comboBox2.Text, int.Parse(comboBox3.Text), count,comboBox1.Text);//修改
                        SqlCommand comm = new SqlCommand(sql, conn);
                        int n = comm.ExecuteNonQuery();
                        if (n < 0)
                        {
                            MessageBox.Show("当前无此课程或者输入错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("设置成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            conn.Close();
                            conn.Open();
                            string sql1 = string.Format("update course set count='{0}' where id='1'", count);
                            SqlCommand comm1 = new SqlCommand(sql1, conn);
                            int q = comm1.ExecuteNonQuery();
                            ds.Clear();
                            showcourse();
                        }
                        conn.Close();

                    }
                    else
                    {
                        MessageBox.Show("无法再添加大课为一", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
