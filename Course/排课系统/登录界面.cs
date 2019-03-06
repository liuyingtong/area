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
    public partial class 登录界面 : Form
    {
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 登录界面()
        {
            InitializeComponent();
        }

        private void 登录界面_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("学院不能为空", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                string sql = string.Format("select * from {0} where id = '{1}'", comboBox1.Text, id.Text);//查询数据库id密码
                conn.Open();
                SqlCommand comm1 = new SqlCommand(sql, conn);
                if (comm1.ExecuteScalar() == null)
                {
                    MessageBox.Show("未查询到该账号", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    SqlDataReader read = comm1.ExecuteReader();
                    if (read.Read())
                    {
                        string uid = (string)read["id"];
                        string umm = (string)read["pass"];
                        string x = (string)read["state"];
                        int y = int.Parse(x);
                        if (y == 0)
                        {
                            conn.Close();
                            conn.Open();
                            string sql2 = string.Format("update {0} set state ='{1}' where id ='{2}'", comboBox1.Text, '1', id.Text);
                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                            int n = comm2.ExecuteNonQuery();
                            if (n < 0)
                            {
                            }
                            else
                            {
                                if (uid == id.Text && umm == mm.Text)//判断密码正确错误
                                {
                                    if (comboBox1.Text == "教务")
                                    {
                                        管理员界面 fom = new 管理员界面(uid);//打开界面
                                        fom.Show();
                                        Visible = false;
                                    }
                                    else
                                    {
                                        老师界面 fom = new 老师界面(uid);//打开界面
                                        fom.Show();
                                        Visible = false;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("账户密码不对", "请重新输入", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("该账户已经在别处登录", "不能登陆", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
