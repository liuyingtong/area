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
    public partial class 教师提交申请界面 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        string tid = "";
        string cou1 = "";
        string cou2 = "";
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 教师提交申请界面(string x)
        {
            InitializeComponent();
            tid = x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            教师联系方式 fom = new 教师联系方式();
            fom.Show();
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql1 = string.Format("select * from 工学院 where id ='{0}'",tid);
            conn.Open();
            SqlCommand comm1 = new SqlCommand(sql1,conn);
            SqlDataReader read = comm1.ExecuteReader();
            if (read.Read())
            {
                label7.Text = (string)read["name"];
                conn.Close();
                conn.Open();
                string sql2 = string.Format("select name from course where tid = '{0}'",tid);
                SqlCommand comm2 = new SqlCommand(sql2, conn);
                SqlDataAdapter da1 = new SqlDataAdapter();//新建新的da以及ds表
                DataSet ds1 = new DataSet("paike");
                da1.SelectCommand = comm2;
                SqlCommandBuilder builder = new SqlCommandBuilder(da1);
                da1.Fill(ds1, "course");
                cou1 = (string)ds1.Tables["course"].Rows[0][0];
                cou2 = (string)ds1.Tables["course"].Rows[1][0];
                comboBox3.Items.Add(cou1);
                comboBox3.Items.Add(cou2);
            }
            else
            {
                MessageBox.Show("读取失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            if (comboBox1.Text == comboBox2.Text)
            {
                MessageBox.Show("调整时间不能相同", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (comboBox2.Text == "" || comboBox1.Text == "" || comboBox3.Text == "")
                {
                    MessageBox.Show("不能为空", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    string sql2 = string.Format("select * from connection");
                    SqlCommand comm2 = new SqlCommand(sql2, conn);
                    if (comm2.ExecuteScalar() == null)
                    {
                        conn.Close();
                        conn.Open();
                        string sql3 = string.Format("insert into connection values ('1','{0}','{1}','{2}','{3}','{4}')", label7.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text,tid);
                        SqlCommand comm3 = new SqlCommand(sql3, conn);
                        int n = comm3.ExecuteNonQuery();
                        if (n < 0)
                        {
                            MessageBox.Show("提交失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("提交成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        conn.Close();
                        conn.Open();
                        string sql6 = string.Format("select * from connection where tid ='{0}' and course = '{1}'", tid, comboBox3.Text);
                        SqlCommand comm6 = new SqlCommand(sql6, conn);
                        if (comm6.ExecuteScalar() == null)
                        {
                            conn.Close();
                            conn.Open();
                            string sql4 = "select Max(id) from connection";
                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                            if (comm4.ExecuteScalar() == null)
                            {
                                MessageBox.Show("出错", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                da.SelectCommand = comm4;
                                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                                da.Fill(ds, "connection");
                                string q = (string)ds.Tables["connection"].Rows[0][0];
                                int m = int.Parse(q) + 1;
                                conn.Close();
                                conn.Open();
                                string sql5 = string.Format("insert into connection values ('{0}','{1}','{2}','{3}','{4}','{5}')", m, label7.Text, comboBox1.Text, comboBox2.Text, comboBox3.Text,tid);
                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                int n = comm5.ExecuteNonQuery();
                                if (n < 0)
                                {
                                    MessageBox.Show("提交失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("提交成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            conn.Close();
                            conn.Open();
                            string sql7 = string.Format("update connection set time1 ='{0}',time2 ='{1}' where tid ='{2}' and course = '{3}'",comboBox1.Text,comboBox2.Text, tid, comboBox3.Text);
                            SqlCommand comm7 = new SqlCommand(sql7, conn);
                            int n = comm7.ExecuteNonQuery();
                            if (n < 0)
                            {
                                MessageBox.Show("提交失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("提交成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                    }
                }
            }
        }
    }
}
