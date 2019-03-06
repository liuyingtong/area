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
    
    public partial class 教师排课信息录入 : Form
    {
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        private SqlDataAdapter da = new SqlDataAdapter();
        private DataSet ds = new DataSet("paike");
        string uid = "";
        string name = "";
        public 教师排课信息录入(string x)
        {
            InitializeComponent();
            uid = x;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 第一志愿时间1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (第一志愿时间1.SelectedIndex)
            {
                case 0:
                    textBox1.Text = "10";
                    break;
                case 1:
                    textBox1.Text = "12";
                    break;
                case 2:
                    textBox1.Text = "15";
                    break;
                case 3:
                    textBox1.Text = "17";
                    break;
                case 4:
                    textBox1.Text = "20";
                        break;
            }

                    
            }

        private void 第二志愿时间1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (第二志愿时间1.SelectedIndex)
            {
                case 0:
                    textBox2.Text = "10";
                    break;
                case 1:
                    textBox2.Text = "12";
                    break;
                case 2:
                    textBox2.Text = "15";
                    break;
                case 3:
                    textBox2.Text = "17";
                    break;
                case 4:
                    textBox2.Text = "20";
                    break;
            }
        }

        private void 第三志愿时间1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (第三志愿时间1.SelectedIndex)
            {
                case 0:
                    textBox3.Text = "10";
                    break;
                case 1:
                    textBox3.Text = "12";
                    break;
                case 2:
                    textBox3.Text = "15";
                    break;
                case 3:
                    textBox3.Text = "17";
                    break;
                case 4:
                    textBox3.Text = "20";
                    break;
            }
        }

        private void 提交_Click(object sender, EventArgs e)
        {
            if (第一志愿星期.Text != "" && 第一志愿时间1.Text != "" && 第二志愿星期.Text != "" && 第二志愿时间1.Text != "" && 第三志愿星期.Text != "" && 第三志愿时间1.Text != "")
            {
                if((第一志愿星期.Text == 第二志愿星期.Text&&第一志愿时间1.Text == 第二志愿时间1.Text) || (第一志愿星期.Text == 第三志愿星期.Text&&第一志愿时间1.Text == 第三志愿时间1.Text) ||((第三志愿星期.Text == 第二志愿星期.Text&&第三志愿时间1.Text == 第二志愿时间1.Text)))
                {
                    MessageBox.Show("不能有重复选项", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlConnection conn = new SqlConnection(strconnecting);
                    string sql7 = string.Format("select * from 工学院 where id = '{0}'", uid);
                    conn.Open();
                    SqlCommand comm7 = new SqlCommand(sql7, conn);
                    SqlDataReader read = comm7.ExecuteReader();
                    if (read.Read())
                    {
                        name = (string)read["name"];
                    }
                    else
                    {
                        MessageBox.Show("提交失败", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    string sql1 = string.Format("select * from LIUYAN where id = '{0}'",uid);
                    conn.Close();
                    conn.Open();
                    SqlCommand comm1 = new SqlCommand(sql1, conn);
                    if (comm1.ExecuteScalar() == null)
                    {
                        conn.Close();
                        conn.Open();
                        string sql3 ="select * from LIUYAN";
                        SqlCommand comm3 = new SqlCommand(sql3, conn);
                        if (comm3.ExecuteScalar() == null)
                        {
                            string sql2 = string.Format("insert into LIUYAN(liuyan,id,yizhou,yishiduan,yishijian,erzhou,ershiduan,ershijian,sanzhou,sanshiduan,sanshijian,name) values ('1','{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", uid, 第一志愿星期.Text, 第一志愿时间1.Text, textBox1.Text, 第二志愿星期.Text, 第二志愿时间1.Text, textBox2.Text, 第三志愿星期.Text, 第三志愿时间1.Text, textBox3.Text,name);
                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                            int n = comm2.ExecuteNonQuery();
                            if (n < 0)
                            {
                                MessageBox.Show("提交失败", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                MessageBox.Show("提交成功", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        else
                        {
                            conn.Close();
                            conn.Open();
                            string sql4 = "select Max(liuyan) from LIUYAN";
                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                            if (comm4.ExecuteScalar() == null)
                            {
                                MessageBox.Show("查找失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                da.SelectCommand = comm4;
                                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                                da.Fill(ds,"LIUYAN");
                                string x = (string)ds.Tables["LIUYAN"].Rows[0][0];
                                int m = int.Parse(x);
                                m++;
                                conn.Close();
                                conn.Open();
                                string sql5 = string.Format("insert into LIUYAN(liuyan,id,yizhou,yishiduan,yishijian,erzhou,ershiduan,ershijian,sanzhou,sanshiduan,sanshijian,name) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}')",m, uid, 第一志愿星期.Text, 第一志愿时间1.Text, textBox1.Text, 第二志愿星期.Text, 第二志愿时间1.Text, textBox2.Text, 第三志愿星期.Text, 第三志愿时间1.Text, textBox3.Text,name);
                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                int n = comm5.ExecuteNonQuery();
                                if (n < 0)
                                {
                                    MessageBox.Show("提交失败", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                else
                                {
                                    MessageBox.Show("提交成功", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                                conn.Close();

                            }
                    }
                    
                }
                else
                {
                    string sql6 = string.Format("update LIUYAN set yizhou= '{0}',yishiduan='{1}',yishijian='{2}',erzhou='{3}',ershiduan='{4}',ershijian='{5}',sanzhou='{6}',sanshiduan='{7}',sanshijian='{8}',name ='{9}' where id = '{10}'",第一志愿星期.Text, 第一志愿时间1.Text, textBox1.Text, 第二志愿星期.Text, 第二志愿时间1.Text, textBox2.Text, 第三志愿星期.Text, 第三志愿时间1.Text, textBox3.Text,name,uid);
                    SqlCommand comm6 = new SqlCommand(sql6, conn);
                    int n = comm6.ExecuteNonQuery();
                    if (n < 0)
                    {
                        MessageBox.Show("更新失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("更新成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    conn.Close();
                }
                }
            }
            else
            {
                MessageBox.Show("所有空格不能为空", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void 第一志愿星期_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 完成_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        }
}
