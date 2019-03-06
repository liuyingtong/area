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
    public partial class 管理员会话界面 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        int x = 1;
        int m;
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 管理员会话界面()
        {
            InitializeComponent();
        }
        public void message(int d)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("select * from connection where id = '{0}'", x);
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataReader read = comm.ExecuteReader();
            if (read.Read())
            {

                textBox1.Text = (string)read["name"];
                textBox2.Text = (string)read["course"];
                textBox3.Text = (string)read["time1"];
                textBox4.Text = (string)read["time2"];
                conn.Close();
                conn.Open();
                string sql1 = string.Format("select Max(id) from connection");
                SqlCommand comm1 = new SqlCommand(sql1, conn);
                da.SelectCommand = comm1;
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Fill(ds, "connection");
                string q = (string)ds.Tables["connection"].Rows[0][0];
                m = int.Parse(q);
            }
            else
            {
                MessageBox.Show("没有老师信息", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            message(x);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (x < m)
            {
                x++;
                message(x);
            }
            else
            {
                MessageBox.Show("接下来没有信息了，可以点击清除信息按钮了", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                button6.Visible = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (x > 1)
            {
                x--;
                message(x);
            }
            else
            {
                MessageBox.Show("前面没有信息了", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定同意？", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                conn.Open();
                string sql1 = string.Format("select * from 回复 where name = '{0}'", textBox1.Text);
                SqlCommand comm1 = new SqlCommand(sql1, conn);
                if (comm1.ExecuteScalar() == null)
                {
                    conn.Close();
                    conn.Open();
                    string g = textBox2.Text + "同意";
                    string sql = string.Format("insert into 回复 (name,reason) values ('{0}','{1}')", textBox1.Text, g);
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int n = comm.ExecuteNonQuery();
                }
                else
                {
                    SqlDataReader read = comm1.ExecuteReader();
                    if (read.Read())
                    {
                        string[] text = ((string)read["reason"]).Split(' ');
                        string g = "";
                        foreach (string f in text)
                        {
                            g += f;
                        }
                        conn.Close();
                        conn.Open();
                        g = g + textBox2.Text + "同意";
                        string sql3 = string.Format("update 回复 set reason ='{0}' where name ='{1}'", g, textBox1.Text);
                        SqlCommand comm3 = new SqlCommand(sql3, conn);
                        int p = comm3.ExecuteNonQuery();

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定驳回？", "确定", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                conn.Open();
                string sql1 = string.Format("select * from 回复 where name = '{0}'", textBox1.Text);
                SqlCommand comm1 = new SqlCommand(sql1, conn);
                if (comm1.ExecuteScalar() == null)
                {
                    conn.Close();
                    conn.Open();
                    string sql = string.Format("insert into 回复 (name,reason) values ('{0}','{1}')", textBox1.Text, textBox5.Text);
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int n = comm.ExecuteNonQuery();
                    if (n < 0)
                    {
                        MessageBox.Show("驳回失败", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("驳回成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
                else
                {
                    SqlDataReader read = comm1.ExecuteReader();
                    if (read.Read())
                    {
                        string[] text = ((string)read["reason"]).Split(' ');
                        string g = "";
                        foreach (string f in text)
                        {
                            g += f;
                        }
                        conn.Close();
                        conn.Open();
                        g = g + textBox2.Text + "驳回" + textBox5.Text;
                        string sql3 = string.Format("update 回复 set reason ='{0}' where name ='{1}'", g, textBox1.Text);
                        SqlCommand comm3 = new SqlCommand(sql3, conn);
                        int p = comm3.ExecuteNonQuery();
                        if (p < 0)
                        {
                            MessageBox.Show("驳回失败", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            MessageBox.Show("驳回成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        }
                    }

                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql5 = "delete connection";
            conn.Open();
            SqlCommand com5 = new SqlCommand(sql5, conn);
            int n = com5.ExecuteNonQuery();
            if (n < 0)
            {
                MessageBox.Show("清除失败", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("清除成功", "OK", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
