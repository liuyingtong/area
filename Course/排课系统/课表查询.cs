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
    public partial class 课表查询 : Form
    {

        DataSet ds = new DataSet("paike");
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter da1 = new SqlDataAdapter();//双周
        DataSet ds1 = new DataSet("paike");
        string t1 = "";
        string t2 = "";
        string t3 = "";
        string c1 = "";
        string c2 = "";
        string c3 = "";
        string tc1 = "";
        string tc2 = "";
        string tc3 = "";
        string cn1 = "";
        string cn2 = "";
        string cn3 = "";
        string m1 = "";
        string m2 = "";
        string m3 = "";
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 课表查询()
        {
            InitializeComponent();
        }
        public void get()
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("select name,teacher from course where wid ='1'");
            SqlCommand comm = new SqlCommand(sql, conn);
            SqlDataAdapter da1 = new SqlDataAdapter();//新建新的da以及ds表
            DataSet ds1 = new DataSet("paike");
            da1.SelectCommand = comm;
            SqlCommandBuilder builder = new SqlCommandBuilder(da1);
            da1.Fill(ds1, "course");
            c1 = (string)ds1.Tables["course"].Rows[0][0];
            string[] ta1 = ((string)ds1.Tables["course"].Rows[0][1]).Split(' ');
            foreach (string f in ta1)
            {
                t1 += f;
            }
            tc1 = c1 + "(" + t1 + ")";
            c2 = (string)ds1.Tables["course"].Rows[1][0];
            string[] ta2 = ((string)ds1.Tables["course"].Rows[1][1]).Split(' ');
            foreach (string f in ta2)
            {
                t2 += f;
            }
            tc2 = c2 + "(" + t2 + ")";
            c3 = (string)ds1.Tables["course"].Rows[2][0];
            string[] ta3 = ((string)ds1.Tables["course"].Rows[2][1]).Split(' ');
            foreach (string f in ta3)
            {
                t3 += f;
            }
            tc3 = c3 + "(" + t3 + ")";
        }
        public void  showa()
        {
            ds.Clear();
            showcourse();
            ds1.Clear();
            showcorse2();
            
        }
        public string return1(string x)
        {
            string s = "";
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql1 = string.Format("select * from KB1 where MON='{0}'", x);
            SqlCommand comm1 = new SqlCommand(sql1, conn);
            if (comm1.ExecuteScalar() != null)
            {
                s = "周一";

            }
            string sql2 = string.Format("select * from KB1 where TUE='{0}'", x);
            SqlCommand comm2 = new SqlCommand(sql2, conn);
            if (comm2.ExecuteScalar() != null)
            {
                s = "周二";

            }
            string sql3 = string.Format("select * from KB1 where WEN='{0}'", x);
            SqlCommand comm3 = new SqlCommand(sql3, conn);
            if (comm3.ExecuteScalar() != null)
            {
                s = "周三";
            }
            string sql4 = string.Format("select * from KB1 where THU='{0}'", x);
            SqlCommand comm4 = new SqlCommand(sql4, conn);
            if (comm4.ExecuteScalar() != null)
            {
                s = "周四";
            }
            string sql5 = string.Format("select * from KB1 where FRT='{0}'", x);
            SqlCommand comm5 = new SqlCommand(sql5, conn);
            if (comm5.ExecuteScalar() != null)
            {
                s = "周五";
            }
            return s;  
        }
        public string return2(string x,string y)
        {
            int s = 0;
            string m="";
            for (int  i = 1; i <= 5; i++)
            {
                if (dataGridView1.Columns[i].Name == x)
                {
                    s = i;
                    break;
                }
            }
            if (((string)dataGridView1.Rows[1].Cells[s].Value) == y)
            {
                m = "1";
            }
            else
            {
                m = "6";
            }
            return m;
        }
        private void comboBox1_ChangeUICues(object sender, UICuesEventArgs e)
        {
            showa();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ds.Clear();
            showcourse();
            ds1.Clear();
            showcorse2();
            get();
            cn1 = return1(tc1);
            cn2 = return1(tc2);
            cn3 = return1(tc3);
            m1 = return2(cn1, tc1);
            m2 = return2(cn2, tc2);
            m3 = return2(cn3, tc3);
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
            dataGridView2.DataSource = ds1.Tables["KB1"];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                if (comboBox1.Text == "1" || comboBox1.Text == "2")
                {

                    int s = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn1)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m1 == "1")
                    {
                        dataGridView1.Rows[2].Cells[s].Value = "无";
                        dataGridView1.Rows[3].Cells[s].Value = "无";
                        dataGridView2.Rows[2].Cells[s].Value = "无";
                        dataGridView2.Rows[3].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[7].Cells[s].Value = "无";
                        dataGridView1.Rows[8].Cells[s].Value = "无";
                        dataGridView2.Rows[7].Cells[s].Value = "无";
                        dataGridView2.Rows[8].Cells[s].Value = "无";
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn2)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m2 == "1")
                    {
                        dataGridView1.Rows[2].Cells[s].Value = "无";
                        dataGridView1.Rows[3].Cells[s].Value = "无";
                        dataGridView2.Rows[2].Cells[s].Value = "无";
                        dataGridView2.Rows[3].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[7].Cells[s].Value = "无";
                        dataGridView1.Rows[8].Cells[s].Value = "无";
                        dataGridView2.Rows[7].Cells[s].Value = "无";
                        dataGridView2.Rows[8].Cells[s].Value = "无";
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn3)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m3 == "1")
                    {
                        dataGridView1.Rows[2].Cells[s].Value = "无";
                        dataGridView1.Rows[3].Cells[s].Value = "无";
                        dataGridView2.Rows[2].Cells[s].Value = "无";
                        dataGridView2.Rows[3].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[7].Cells[s].Value = "无";
                        dataGridView1.Rows[8].Cells[s].Value = "无";
                        dataGridView2.Rows[7].Cells[s].Value = "无";
                        dataGridView2.Rows[8].Cells[s].Value = "无";
                    }
                }
                else
                {
                    int s = 0;
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn1)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m1 == "1")
                    {
                        dataGridView1.Rows[0].Cells[s].Value = "无";
                        dataGridView1.Rows[1].Cells[s].Value = "无";
                        dataGridView2.Rows[0].Cells[s].Value = "无";
                        dataGridView2.Rows[1].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[5].Cells[s].Value = "无";
                        dataGridView1.Rows[6].Cells[s].Value = "无";
                        dataGridView2.Rows[5].Cells[s].Value = "无";
                        dataGridView2.Rows[6].Cells[s].Value = "无";
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn2)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m2 == "1")
                    {
                        dataGridView1.Rows[0].Cells[s].Value = "无";
                        dataGridView1.Rows[1].Cells[s].Value = "无";
                        dataGridView2.Rows[0].Cells[s].Value = "无";
                        dataGridView2.Rows[1].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[5].Cells[s].Value = "无";
                        dataGridView1.Rows[6].Cells[s].Value = "无";
                        dataGridView2.Rows[5].Cells[s].Value = "无";
                        dataGridView2.Rows[6].Cells[s].Value = "无";
                    }
                    for (int i = 1; i <= 5; i++)
                    {
                        if (dataGridView1.Columns[i].Name == cn3)
                        {
                            s = i;
                            break;
                        }
                    }
                    if (m3 == "1")
                    {
                        dataGridView1.Rows[0].Cells[s].Value = "无";
                        dataGridView1.Rows[1].Cells[s].Value = "无";
                        dataGridView2.Rows[0].Cells[s].Value = "无";
                        dataGridView2.Rows[1].Cells[s].Value = "无";
                    }
                    else
                    {
                        dataGridView1.Rows[5].Cells[s].Value = "无";
                        dataGridView1.Rows[6].Cells[s].Value = "无";
                        dataGridView2.Rows[5].Cells[s].Value = "无";
                        dataGridView2.Rows[6].Cells[s].Value = "无";
                    }
                }
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            showa();
        }
    }
}
