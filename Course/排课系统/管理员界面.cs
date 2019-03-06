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
    public partial class 管理员界面 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();//单周
        DataSet ds = new DataSet("paike");
        SqlDataAdapter da1 = new SqlDataAdapter();//双周
        DataSet ds1 = new DataSet("paike");
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        string[,] tea=new string[5,10];//第一次排课存储信息
        string[,] tea2 = new string[5, 10];//第二轮排课储存的信息
        int[,] co = new int[,] { { 1, 2, 3, 4, 5 }, { 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0 } };//单双周单周的时间表
        int[,] co2 = new int[,] { { 1, 2, 3, 4, 5 }, { 0, 0, 0, 0, 0, }, { 0, 0, 0, 0, 0 } };//单双周双周的时间表
        int x = 5;
        int[] xyz = new int[5]{0,1,2,3,4};//删除已经拍课得信息
        string id = "";
        public void get_teacher_course()//获取老师上课信息
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            for (int i = 1; i <=5; i++)
            {
                conn.Open();
                string sql1 = string.Format("select * from 工学院 where id = '{0}'", i);
                SqlCommand comm1 = new SqlCommand(sql1, conn);
                SqlDataReader read = comm1.ExecuteReader();
                if (read.Read())
                {
                    string[] tname = ((string)read["name"]).Split(' ');
                    string name = "";
                    foreach (string f in tname)
                    {
                        name += f;//教师姓名
                    }
                    conn.Close();
                    conn.Open();
                    string sql2 = string.Format("select teacher,name,特殊情况 from course where teacher = '{0}'", name);
                    SqlCommand comm2 = new SqlCommand(sql2, conn);
                    SqlDataAdapter da1 = new SqlDataAdapter();//新建新的da以及ds表
                    DataSet ds1 = new DataSet("paike");
                    da1.SelectCommand = comm2;
                    SqlCommandBuilder builder = new SqlCommandBuilder(da1);
                    da1.Fill(ds1, "course");
                    if (int.Parse((string)ds1.Tables["course"].Rows[0][2]) > int.Parse((string)ds1.Tables["course"].Rows[1][2]))
                    {
                        tea[0, i - 1] = name;
                        tea[1, i - 1] = (string)ds1.Tables["course"].Rows[0][1];
                        tea[2, i - 1] = (string)ds1.Tables["course"].Rows[1][1];
                        tea[3, i - 1] = (string)ds1.Tables["course"].Rows[0][2];
                        tea[4, i - 1] = (string)ds1.Tables["course"].Rows[1][2];
                    }
                    else
                    {
                        tea[0, i - 1] = name;
                        tea[2, i - 1] = (string)ds1.Tables["course"].Rows[0][1];
                        tea[1, i - 1] = (string)ds1.Tables["course"].Rows[1][1];
                        tea[4, i - 1] = (string)ds1.Tables["course"].Rows[0][2];
                        tea[3, i - 1] = (string)ds1.Tables["course"].Rows[1][2];
                    }
                    conn.Close();
                    continue;
                }
                else
                {

                }
            }
        }
        public 管理员界面(string x)
        {
            InitializeComponent();
            id = x;
        }
        public int panduan(string x, int m)//判断志愿的时间并返回相应代码
        {
            int a = 0;
            switch (x)
            {
                case "周一":
                    if (m < 12 && m > 7)
                    {
                        a = 110;
                    }
                    else
                    {
                        a = 101;
                    }
                    break;
                case "周二":
                    if (m < 12 && m > 7)
                    {
                        a = 210;
                    }
                    else
                    {
                        a = 201;
                    }
                    break;
                case "周三":
                    if (m < 12 && m > 7)
                    {
                        a = 310;
                    }
                    else
                    {
                        a = 301;
                    }
                    break;
                case "周四":
                    if (m < 12 && m > 7)
                    {
                        a = 410;
                    }
                    else
                    {
                        a = 401;
                    }
                    break;
                case "周五":
                    if (m < 12 && m > 7)
                    {
                        a = 501;
                    }
                    else
                    {
                        a = 510;
                    }
                    break;
            }
            return a;
        }
        public int xuanze(int x,int y,int z)//根据志愿排课的函数
        {
            int p = x / 100;
            int q = 0;
            int w = x / 10 - p * 10;
            int e = x - q * 100 - w * 10;
            int r = 0;
            for (int i = 0; i <= 4; i++)
            {
                if (co[0, i] == p)
                {
                    q = i;
                    break;
                }
            }
            if ((co[0, q] * 100 + co[1, q] * 10 + co[2, q]) == co[0,q]*100)
            {
                if (w == 1)
                {
                    co[1, q] = 1;
                    r = co[0, q] * 100 + 10;
                    return r;
                }
                else
                {
                    co[2, q] = 1;
                    r = co[0, q] * 100 + 1;
                    return r;
                }
            }
            else if (w == 1)
            {
                if (co[1, q] == 1)
                {
                    q = 0;
                }
                else
                {
                    co[1, q] = 1;
                    r = co[0, q] * 100 + 10;
                    return r;
                }
            }
            else
            {
                if (co[2, q] == 1)
                {
                    q = 0;
                }
                else
                {
                    co[2, q] = 1;
                    r = co[0, q] * 100 + 1;
                    return r;
                }
            }
            if (q == 0)
            {
                p = y / 100;
                w = y / 10 - p * 10;
                e = y - q * 100 - w * 10;
                for (int i = 0; i <= 4; i++)
                {
                    if (co[0, i] == p)
                    {
                        q = i;
                        break;
                    }
                }
                if ((co[0, q] * 100 + co[1, q] * 10 + co[2, q]) == co[0, q] * 100)
                {
                    if (w == 1)
                    {
                        co[1, q] = 1;
                        r = co[0, q] * 100 + 10;
                        return r;
                    }
                    else
                    {
                        co[2, q] = 1;
                        r = co[0, q] * 100 + 1;
                        return r;
                    }
                }
                else if (w == 1)
                {
                    if (co[1, q] == 1)
                    {
                        q = 0;
                    }
                    else
                    {
                        co[1, q] = 1;
                        r = co[0, q] * 100 + 10;
                        return r;
                    }
                }
                else
                {
                    if (co[2, q] == 1)
                    {
                        q = 0;
                    }
                    else
                    {
                        co[2, q] = 1;
                        r = co[0, q] * 100 + 1;
                        return r;
                    }
                }
            }
            if (q == 0)
            {
                p = z / 100;
                w = z / 10 - p * 10;
                e = z - q * 100 - w * 10;
                for (int i = 0; i <= 4; i++)
                {
                    if (co[0, i] == p)
                    {
                        q = i;
                        break;
                    }
                }
                if ((co[0, q] * 100 + co[1, q] * 10 + co[2, q]) == co[0, q] * 100)
                {
                    if (w == 1)
                    {
                        co[1,q] = 1;
                        r = co[0,q] * 100 + 10;
                        return r;
                    }
                    else
                    {
                        co[2,q] = 1;
                        r = co[0,q] * 100 + 1;
                        return r;
                    }
                }
                else if (w == 1)
                {
                    if (co[1,q] == 1)
                    {
                        q = 0;
                    }
                    else
                    {
                        co[1, q] = 1;
                        r = co[0,q] * 100 + 10;
                        return r;
                    }
                }
                else
                {
                    if (co[2,q] == 1)
                    {
                        q = 0;
                    }
                    else
                    {
                        co[2,q] = 1;
                        r = co[0,q] * 100 + 1;
                        return r;
                    }
                }
            }
            return r;
        }
        private void 管理员界面_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
        public int compare(System.DateTime x, System.DateTime y)//时间比较
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
        private void 排课界面ToolStripMenuItem_Click(object sender, EventArgs e)
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
                    string message = "志愿截止时间还未到，截止时间：" + time1;
                    MessageBox.Show(message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                else
                {
                    button1.Visible = true;
                }

            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            get_teacher_course();
            int second = 0;
            if (x==0)
            {
                MessageBox.Show("请先输入排课信息", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DialogResult dr= MessageBox.Show("是否进行排课？","确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection(strconnecting);
                    conn.Open();
                    string sql12 = "select  * from LIUYAN";
                    SqlCommand comm12 = new SqlCommand(sql12, conn);
                    if (comm12.ExecuteScalar() == null)
                    {
                        conn.Close();
                        for (int i = 0; i < xyz.Length; i++)
                        {
                            tea2[0, second] = tea[0, xyz[i]];
                            tea2[1, second] = tea[1, xyz[i]];
                            tea2[2, second] = tea[3, xyz[i]];
                            second++;
                            tea2[0, second] = tea[0, xyz[i]];
                            tea2[1, second] = tea[2, xyz[i]];
                            tea2[2, second] = tea[4, xyz[i]];
                            second++;
                        }
                        //判断第二轮
                        if (second == 0)
                        {

                            MessageBox.Show("排课成功，点击课程表显示课程表", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            for (int k = 0; k < second; k++)//获取每个课程的优先级
                            {
                                conn.Open();
                                string sqllan = string.Format("select * from course where name ='{0}'", tea2[1, k]);
                                SqlCommand commlan = new SqlCommand(sqllan, conn);
                                SqlDataReader read = commlan.ExecuteReader();
                                if (read.Read())
                                {
                                    tea2[3, k] = (string)read["youxianji"];

                                }
                                conn.Close();
                            }//获取成功

                            for (int k = 0; k < second; k++)//第二轮排课将数组根据优先级排序好
                            {
                                for (int s = k + 1; s < second; s++)
                                {
                                    if (int.Parse(tea2[3, k]) < int.Parse(tea2[3, s]))//交换在数组中的顺序
                                    {
                                        string temp1, temp2, temp3, temp4;
                                        temp1 = tea2[0, k];
                                        temp2 = tea2[1, k];
                                        temp3 = tea2[2, k];
                                        temp4 = tea2[3, k];
                                        tea2[0, k] = tea2[0, s];
                                        tea2[1, k] = tea2[1, s];
                                        tea2[2, k] = tea2[2, s];
                                        tea2[3, k] = tea2[3, s];
                                        tea2[0, s] = temp1;
                                        tea2[1, s] = temp2;
                                        tea2[2, s] = temp3;
                                        tea2[3, s] = temp4;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                            }//交换成功

                            for (int k = 0; k < second; k++)
                            {
                                int h = 0;
                                for (int i = 0; i <= 4; i++)
                                {
                                    if (co[1, i] == 0)
                                    {
                                        h = co[0, i] * 100 + 10;
                                        co[1, i] = 1;
                                        break;
                                    }
                                    else if (co[2, i] == 0)
                                    {
                                        h = co[0, i] * 100 + 1;
                                        co[2, i] = 1;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                if (int.Parse(tea2[2, k]) == 1)
                                {
                                    string ziduan = tea2[1, k] + "(" + tea2[0, k] + ")";
                                    conn.Open();
                                    switch (h)
                                    {
                                        case 101:
                                            string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm = new SqlCommand(sql, conn);
                                            int n1 = comm.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 110:
                                            string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                                            int n2 = comm2.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 210:
                                            string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm3 = new SqlCommand(sql3, conn);
                                            int n3 = comm3.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 201:
                                            string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                                            int n4 = comm4.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 301:
                                            string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm5 = new SqlCommand(sql5, conn);
                                            int n5 = comm5.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 310:
                                            string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm6 = new SqlCommand(sql6, conn);
                                            int n6 = comm6.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 401:
                                            string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm7 = new SqlCommand(sql7, conn);
                                            int n7 = comm7.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 410:
                                            string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm8 = new SqlCommand(sql8, conn);
                                            int n8 = comm8.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 501:
                                            string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm9 = new SqlCommand(sql9, conn);
                                            int n9 = comm9.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 510:
                                            string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm10 = new SqlCommand(sql10, conn);
                                            int n10 = comm10.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                    }
                                }
                                else
                                {
                                    conn.Open();
                                    string ziduan = tea2[1, k] + "(" + tea2[0, k] + ")";

                                    switch (h)
                                    {
                                        case 101:
                                            string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm = new SqlCommand(sql, conn);
                                            int n1 = comm.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql21 = string.Format("update KB2 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm21 = new SqlCommand(sql21, conn);
                                            int n21 = comm21.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 110:
                                            string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                                            int n2 = comm2.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql22 = string.Format("update KB2 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm22 = new SqlCommand(sql22, conn);
                                            int n22 = comm22.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 210:
                                            string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm3 = new SqlCommand(sql3, conn);
                                            int n3 = comm3.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql23 = string.Format("update KB2 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm23 = new SqlCommand(sql23, conn);
                                            int n23 = comm23.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 201:
                                            string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                                            int n4 = comm4.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql24 = string.Format("update KB2 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm24 = new SqlCommand(sql24, conn);
                                            int n24 = comm24.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 301:
                                            string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm5 = new SqlCommand(sql5, conn);
                                            int n5 = comm5.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql25 = string.Format("update KB2 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm25 = new SqlCommand(sql25, conn);
                                            int n25 = comm25.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 310:
                                            string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm6 = new SqlCommand(sql6, conn);
                                            int n6 = comm6.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql26 = string.Format("update KB2 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm26 = new SqlCommand(sql26, conn);
                                            int n26 = comm26.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 401:
                                            string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm7 = new SqlCommand(sql7, conn);
                                            int n7 = comm7.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql27 = string.Format("update KB2 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm27 = new SqlCommand(sql27, conn);
                                            int n27 = comm27.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 410:
                                            string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm8 = new SqlCommand(sql8, conn);
                                            int n8 = comm8.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql28 = string.Format("update KB2 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm28 = new SqlCommand(sql28, conn);
                                            int n28 = comm28.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 501:
                                            string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm9 = new SqlCommand(sql9, conn);
                                            int n9 = comm9.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql29 = string.Format("update KB2 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm29 = new SqlCommand(sql29, conn);
                                            int n29 = comm29.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 510:
                                            string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm10 = new SqlCommand(sql10, conn);
                                            int n10 = comm10.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql210 = string.Format("update KB2 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm210 = new SqlCommand(sql210, conn);
                                            int n210 = comm210.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                    }
                                }
                                conn.Close();
                            }
                            MessageBox.Show("排课成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else// having message
                    {
                        conn.Close();
                        conn.Open();
                        string sql13 = "select Max(liuyan) from LIUYAN ";
                        SqlCommand comm13 = new SqlCommand(sql13, conn);
                        da.SelectCommand = comm13;
                        SqlCommandBuilder builder = new SqlCommandBuilder(da);
                        da.Fill(ds, "LIUYAN");
                        string x1 = (string)ds.Tables["LIUYAN"].Rows[0][0];//教师排课信息剩余人数
                        int w = int.Parse(x1);
                        conn.Close();
                        string[] b = new string[5];

                        string ziduan = "";
                        for (int i = 1; i <= int.Parse(x1); i++)
                        {
                            conn.Open();
                            string sql1 = string.Format("select * from LIUYAN where liuyan = '{0}'", i);
                            SqlCommand comm1 = new SqlCommand(sql1, conn);
                            SqlDataReader read = comm1.ExecuteReader();
                            if (read.Read())
                            {
                                string[] xingming = ((string)read["name"]).Split(' ');
                                string name1 = "";
                                string[] yizhou = ((string)read["yizhou"]).Split(' ');
                                string[] erzhou = ((string)read["erzhou"]).Split(' ');
                                string[] sanzhou = ((string)read["sanzhou"]).Split(' ');
                                string yizhou1 = "";
                                foreach (string f in yizhou)
                                {
                                    yizhou1 += f;
                                }
                                foreach (string f in xingming)
                                {
                                    name1 += f;
                                }
                                string erzhou1 = "";
                                foreach (string f in erzhou)
                                {
                                    erzhou1 += f;
                                }
                                string sanzhou1 = "";
                                foreach (string f in sanzhou)
                                {
                                    sanzhou1 += f;
                                }
                                string yishiduan = (string)read["yishiduan"];
                                string ershiduan = (string)read["ershiduan"];
                                string sanshiduan = (string)read["sanshiduan"];
                                conn.Close();
                                string[] na = new string[5];
                                for (int p = 0; p < 5; p++)
                                {
                                    na[p] = tea[0, p];
                                }
                                int index = Array.IndexOf(na, name1);
                                int a1 = int.Parse(yishiduan);
                                int a2 = int.Parse(ershiduan);
                                int a3 = int.Parse(sanshiduan);
                                int b1 = panduan(yizhou1, a1);
                                int b2 = panduan(erzhou1, a2);
                                int b3 = panduan(sanzhou1, a3);
                                int h = xuanze(b1, b2, b3);
                                for (int y1 = 0; y1 < 5; y1++)
                                {
                                    if (xyz[y1] == index)
                                    {
                                        xyz[y1] = 5;
                                        break;
                                    }
                                }
                                if (int.Parse(tea[3, index]) == 1)
                                {
                                    if (h == 0)//排课失败
                                    {
                                        tea2[0, second] = tea[0, index];
                                        tea2[1, second] = tea[1, index];
                                        tea2[2, second] = tea[3, index];
                                        second++;
                                    }
                                    else
                                    {

                                        ziduan = tea[1, index] + "(" + name1 + ")";
                                        conn.Open();
                                        switch (h)
                                        {
                                            case 101:
                                                string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm = new SqlCommand(sql, conn);
                                                int n1 = comm.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 110:
                                                string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm2 = new SqlCommand(sql2, conn);
                                                int n2 = comm2.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 210:
                                                string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm3 = new SqlCommand(sql3, conn);
                                                int n3 = comm3.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 201:
                                                string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm4 = new SqlCommand(sql4, conn);
                                                int n4 = comm4.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 301:
                                                string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                                int n5 = comm5.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 310:
                                                string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm6 = new SqlCommand(sql6, conn);
                                                int n6 = comm6.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 401:
                                                string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm7 = new SqlCommand(sql7, conn);
                                                int n7 = comm7.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 410:
                                                string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm8 = new SqlCommand(sql8, conn);
                                                int n8 = comm8.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 501:
                                                string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm9 = new SqlCommand(sql9, conn);
                                                int n9 = comm9.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 510:
                                                string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm10 = new SqlCommand(sql10, conn);
                                                int n10 = comm10.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (h == 0)//排课失败
                                    {
                                        tea2[0, second] = tea[0, index];
                                        tea2[1, second] = tea[1, index];
                                        tea2[2, second] = tea[3, index];
                                        second++;
                                    }
                                    else
                                    {
                                        ziduan = tea[1, index] + "(" + name1 + ")";
                                        conn.Open();
                                        switch (h)
                                        {
                                            case 101:
                                                string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm = new SqlCommand(sql, conn);
                                                int n1 = comm.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql21 = string.Format("update KB2 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm21 = new SqlCommand(sql21, conn);
                                                int n21 = comm21.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 110:
                                                string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm2 = new SqlCommand(sql2, conn);
                                                int n2 = comm2.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql22 = string.Format("update KB2 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm22 = new SqlCommand(sql22, conn);
                                                int n22 = comm22.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 210:
                                                string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm3 = new SqlCommand(sql3, conn);
                                                int n3 = comm3.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql23 = string.Format("update KB2 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm23 = new SqlCommand(sql23, conn);
                                                int n23 = comm23.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 201:
                                                string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm4 = new SqlCommand(sql4, conn);
                                                int n4 = comm4.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql24 = string.Format("update KB2 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm24 = new SqlCommand(sql24, conn);
                                                int n24 = comm24.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 301:
                                                string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                                int n5 = comm5.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql25 = string.Format("update KB2 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm25 = new SqlCommand(sql25, conn);
                                                int n25 = comm25.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 310:
                                                string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm6 = new SqlCommand(sql6, conn);
                                                int n6 = comm6.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql26 = string.Format("update KB2 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm26 = new SqlCommand(sql26, conn);
                                                int n26 = comm26.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 401:
                                                string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm7 = new SqlCommand(sql7, conn);
                                                int n7 = comm7.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql27 = string.Format("update KB2 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm27 = new SqlCommand(sql27, conn);
                                                int n27 = comm27.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 410:
                                                string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm8 = new SqlCommand(sql8, conn);
                                                int n8 = comm8.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql28 = string.Format("update KB2 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm28 = new SqlCommand(sql28, conn);
                                                int n28 = comm28.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 501:
                                                string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm9 = new SqlCommand(sql9, conn);
                                                int n9 = comm9.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql29 = string.Format("update KB2 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm29 = new SqlCommand(sql29, conn);
                                                int n29 = comm29.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 510:
                                                string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm10 = new SqlCommand(sql10, conn);
                                                int n10 = comm10.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql210 = string.Format("update KB2 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm210 = new SqlCommand(sql210, conn);
                                                int n210 = comm210.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("读取失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        for (int i = 1; i <= int.Parse(x1); i++)
                        {
                            conn.Open();
                            string sql1 = string.Format("select * from LIUYAN where liuyan = '{0}'", i);
                            SqlCommand comm1 = new SqlCommand(sql1, conn);
                            SqlDataReader read = comm1.ExecuteReader();
                            if (read.Read())
                            {
                                string[] xingming = ((string)read["name"]).Split(' ');
                                string name1 = "";
                                string[] yizhou = ((string)read["yizhou"]).Split(' ');
                                string[] erzhou = ((string)read["erzhou"]).Split(' ');
                                string[] sanzhou = ((string)read["sanzhou"]).Split(' ');
                                string yizhou1 = "";
                                foreach (string f in yizhou)
                                {
                                    yizhou1 += f;
                                }
                                foreach (string f in xingming)
                                {
                                    name1 += f;
                                }
                                string erzhou1 = "";
                                foreach (string f in erzhou)
                                {
                                    erzhou1 += f;
                                }
                                string sanzhou1 = "";
                                foreach (string f in sanzhou)
                                {
                                    sanzhou1 += f;
                                }
                                string yishiduan = (string)read["yishiduan"];
                                string ershiduan = (string)read["ershiduan"];
                                string sanshiduan = (string)read["sanshiduan"];
                                conn.Close();
                                int a1 = int.Parse(yishiduan);
                                int a2 = int.Parse(ershiduan);
                                int a3 = int.Parse(sanshiduan);
                                int b1 = panduan(yizhou1, a1);
                                int b2 = panduan(erzhou1, a2);
                                int b3 = panduan(sanzhou1, a3);
                                int h = xuanze(b1, b2, b3);
                                string[] na = new string[5];
                                for (int p = 0; p < 5; p++)
                                {
                                    na[p] = tea[0, p];
                                }
                                int index = Array.IndexOf(na, name1);
                                if (int.Parse(tea[4, index]) == 1)
                                {
                                    if (h == 0)//排课失败
                                    {
                                        tea2[0, second] = tea[0, index];
                                        tea2[1, second] = tea[2, index];
                                        tea2[2, second] = tea[4, index];
                                        second++;
                                    }
                                    else
                                    {

                                        ziduan = tea[2, index] + "(" + name1 + ")";
                                        conn.Open();
                                        switch (h)
                                        {
                                            case 101:
                                                string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm = new SqlCommand(sql, conn);
                                                int n1 = comm.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 110:
                                                string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm2 = new SqlCommand(sql2, conn);
                                                int n2 = comm2.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 210:
                                                string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm3 = new SqlCommand(sql3, conn);
                                                int n3 = comm3.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 201:
                                                string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm4 = new SqlCommand(sql4, conn);
                                                int n4 = comm4.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 301:
                                                string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                                int n5 = comm5.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 310:
                                                string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm6 = new SqlCommand(sql6, conn);
                                                int n6 = comm6.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 401:
                                                string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm7 = new SqlCommand(sql7, conn);
                                                int n7 = comm7.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 410:
                                                string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm8 = new SqlCommand(sql8, conn);
                                                int n8 = comm8.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 501:
                                                string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm9 = new SqlCommand(sql9, conn);
                                                int n9 = comm9.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 510:
                                                string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm10 = new SqlCommand(sql10, conn);
                                                int n10 = comm10.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (h == 0)//排课失败
                                    {
                                        tea2[0, second] = tea[0, index];
                                        tea2[1, second] = tea[2, index];
                                        tea2[2, second] = tea[4, index];
                                        second++;
                                    }
                                    else
                                    {
                                        ziduan = tea[2, index] + "(" + name1 + ")";
                                        conn.Open();
                                        switch (h)
                                        {
                                            case 101:
                                                string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm = new SqlCommand(sql, conn);
                                                int n1 = comm.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql21 = string.Format("update KB2 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm21 = new SqlCommand(sql21, conn);
                                                int n21 = comm21.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 110:
                                                string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm2 = new SqlCommand(sql2, conn);
                                                int n2 = comm2.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql22 = string.Format("update KB2 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm22 = new SqlCommand(sql22, conn);
                                                int n22 = comm22.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 210:
                                                string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm3 = new SqlCommand(sql3, conn);
                                                int n3 = comm3.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql23 = string.Format("update KB2 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm23 = new SqlCommand(sql23, conn);
                                                int n23 = comm23.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 201:
                                                string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm4 = new SqlCommand(sql4, conn);
                                                int n4 = comm4.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql24 = string.Format("update KB2 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm24 = new SqlCommand(sql24, conn);
                                                int n24 = comm24.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 301:
                                                string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm5 = new SqlCommand(sql5, conn);
                                                int n5 = comm5.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql25 = string.Format("update KB2 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm25 = new SqlCommand(sql25, conn);
                                                int n25 = comm25.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 310:
                                                string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm6 = new SqlCommand(sql6, conn);
                                                int n6 = comm6.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql26 = string.Format("update KB2 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm26 = new SqlCommand(sql26, conn);
                                                int n26 = comm26.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 401:
                                                string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm7 = new SqlCommand(sql7, conn);
                                                int n7 = comm7.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql27 = string.Format("update KB2 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm27 = new SqlCommand(sql27, conn);
                                                int n27 = comm27.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 410:
                                                string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm8 = new SqlCommand(sql8, conn);
                                                int n8 = comm8.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql28 = string.Format("update KB2 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm28 = new SqlCommand(sql28, conn);
                                                int n28 = comm28.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 501:
                                                string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm9 = new SqlCommand(sql9, conn);
                                                int n9 = comm9.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql29 = string.Format("update KB2 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                                SqlCommand comm29 = new SqlCommand(sql29, conn);
                                                int n29 = comm29.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                            case 510:
                                                string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm10 = new SqlCommand(sql10, conn);
                                                int n10 = comm10.ExecuteNonQuery();
                                                conn.Close();
                                                conn.Open();
                                                string sql210 = string.Format("update KB2 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                                SqlCommand comm210 = new SqlCommand(sql210, conn);
                                                int n210 = comm210.ExecuteNonQuery();
                                                conn.Close();
                                                break;
                                        }

                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("读取失败", "重试", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        //第一轮排课结束
                        for (int i = 0; i < xyz.Length; i++)
                        {
                            if (xyz[i] == 5)
                            {
                                continue;
                            }
                            else
                            {
                                tea2[0, second] = tea[0, xyz[i]];
                                tea2[1, second] = tea[1, xyz[i]];
                                tea2[2, second] = tea[3, xyz[i]];
                                second++;
                                tea2[0, second] = tea[0, xyz[i]];
                                tea2[1, second] = tea[2, xyz[i]];
                                tea2[2, second] = tea[4, xyz[i]];
                                second++;
                            }
                        }
                        //判断第二轮
                        if (second == 0)
                        {

                            MessageBox.Show("排课成功，点击课程表显示课程表", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            for (int k = 0; k < second; k++)//获取每个课程的优先级
                            {
                                conn.Open();
                                string sqllan = string.Format("select * from course where name ='{0}'", tea2[1, k]);
                                SqlCommand commlan = new SqlCommand(sqllan, conn);
                                SqlDataReader read = commlan.ExecuteReader();
                                if (read.Read())
                                {
                                    tea2[3, k] = (string)read["youxianji"];

                                }
                                conn.Close();
                            }//获取成功

                            for (int k = 0; k < second; k++)//第二轮排课将数组根据优先级排序好
                            {
                                for (int s = k + 1; s < second; s++)
                                {
                                    if (int.Parse(tea2[3, k]) < int.Parse(tea2[3, s]))//交换在数组中的顺序
                                    {
                                        string temp1, temp2, temp3, temp4;
                                        temp1 = tea2[0, k];
                                        temp2 = tea2[1, k];
                                        temp3 = tea2[2, k];
                                        temp4 = tea2[3, k];
                                        tea2[0, k] = tea2[0, s];
                                        tea2[1, k] = tea2[1, s];
                                        tea2[2, k] = tea2[2, s];
                                        tea2[3, k] = tea2[3, s];
                                        tea2[0, s] = temp1;
                                        tea2[1, s] = temp2;
                                        tea2[2, s] = temp3;
                                        tea2[3, s] = temp4;
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                            }//交换成功

                            for (int k = 0; k < second; k++)
                            {
                                int h = 0;
                                for (int i = 0; i <= 4; i++)
                                {
                                    if (co[1, i] == 0)
                                    {
                                        h = co[0, i] * 100 + 10;
                                        co[1, i] = 1;
                                        break;
                                    }
                                    else if (co[2, i] == 0)
                                    {
                                        h = co[0, i] * 100 + 1;
                                        co[2, i] = 1;
                                        break;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                if (int.Parse(tea2[2, k]) == 1)
                                {
                                    ziduan = tea2[1, k] + "(" + tea2[0, k] + ")";
                                    conn.Open();
                                    switch (h)
                                    {
                                        case 101:
                                            string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm = new SqlCommand(sql, conn);
                                            int n1 = comm.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 110:
                                            string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                                            int n2 = comm2.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 210:
                                            string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm3 = new SqlCommand(sql3, conn);
                                            int n3 = comm3.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 201:
                                            string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                                            int n4 = comm4.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 301:
                                            string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm5 = new SqlCommand(sql5, conn);
                                            int n5 = comm5.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 310:
                                            string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm6 = new SqlCommand(sql6, conn);
                                            int n6 = comm6.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 401:
                                            string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm7 = new SqlCommand(sql7, conn);
                                            int n7 = comm7.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 410:
                                            string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm8 = new SqlCommand(sql8, conn);
                                            int n8 = comm8.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 501:
                                            string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm9 = new SqlCommand(sql9, conn);
                                            int n9 = comm9.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 510:
                                            string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm10 = new SqlCommand(sql10, conn);
                                            int n10 = comm10.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                    }
                                }
                                else
                                {
                                    conn.Open();
                                    ziduan = tea2[1, k] + "(" + tea2[0, k] + ")";

                                    switch (h)
                                    {
                                        case 101:
                                            string sql = string.Format("update KB1 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm = new SqlCommand(sql, conn);
                                            int n1 = comm.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql21 = string.Format("update KB2 set MON='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm21 = new SqlCommand(sql21, conn);
                                            int n21 = comm21.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 110:
                                            string sql2 = string.Format("update KB1 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm2 = new SqlCommand(sql2, conn);
                                            int n2 = comm2.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql22 = string.Format("update KB2 set MON='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm22 = new SqlCommand(sql22, conn);
                                            int n22 = comm22.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 210:
                                            string sql3 = string.Format("update KB1 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm3 = new SqlCommand(sql3, conn);
                                            int n3 = comm3.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql23 = string.Format("update KB2 set TUE='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm23 = new SqlCommand(sql23, conn);
                                            int n23 = comm23.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 201:
                                            string sql4 = string.Format("update KB1 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm4 = new SqlCommand(sql4, conn);
                                            int n4 = comm4.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql24 = string.Format("update KB2 set TUE='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm24 = new SqlCommand(sql24, conn);
                                            int n24 = comm24.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 301:
                                            string sql5 = string.Format("update KB1 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm5 = new SqlCommand(sql5, conn);
                                            int n5 = comm5.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql25 = string.Format("update KB2 set WEN='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm25 = new SqlCommand(sql25, conn);
                                            int n25 = comm25.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 310:
                                            string sql6 = string.Format("update KB1 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm6 = new SqlCommand(sql6, conn);
                                            int n6 = comm6.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql26 = string.Format("update KB2 set WEN='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm26 = new SqlCommand(sql26, conn);
                                            int n26 = comm26.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 401:
                                            string sql7 = string.Format("update KB1 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm7 = new SqlCommand(sql7, conn);
                                            int n7 = comm7.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql27 = string.Format("update KB2 set THU='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm27 = new SqlCommand(sql27, conn);
                                            int n27 = comm27.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 410:
                                            string sql8 = string.Format("update KB1 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm8 = new SqlCommand(sql8, conn);
                                            int n8 = comm8.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql28 = string.Format("update KB2 set THU='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm28 = new SqlCommand(sql28, conn);
                                            int n28 = comm28.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 501:
                                            string sql9 = string.Format("update KB1 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm9 = new SqlCommand(sql9, conn);
                                            int n9 = comm9.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql29 = string.Format("update KB2 set FRT='{0}' where JIE ='6' or JIE='7' or JIE='8' or JIE='9'", ziduan);
                                            SqlCommand comm29 = new SqlCommand(sql29, conn);
                                            int n29 = comm29.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                        case 510:
                                            string sql10 = string.Format("update KB1 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm10 = new SqlCommand(sql10, conn);
                                            int n10 = comm10.ExecuteNonQuery();
                                            conn.Close();
                                            conn.Open();
                                            string sql210 = string.Format("update KB2 set FRT='{0}' where JIE ='1' or JIE='2' or JIE='3' or JIE='4'", ziduan);
                                            SqlCommand comm210 = new SqlCommand(sql210, conn);
                                            int n210 = comm210.ExecuteNonQuery();
                                            conn.Close();
                                            break;
                                    }
                                }
                                conn.Close();
                            }
                            MessageBox.Show("排课成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                }

                else
                {

                }
            }
        }

        private void 管理员界面_Load(object sender, EventArgs e)
        {
            timer1.Start();
            SqlConnection conn = new SqlConnection(strconnecting);
            string sqlc = string.Format("select * from connection");
            conn.Open();
            SqlCommand commc = new SqlCommand(sqlc, conn);
            if (commc.ExecuteScalar() == null)
            {

            }
            else
            {
                pictureBox1.Visible = true;
                label1.Visible = true;
            }
            conn.Close();
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
            mergeDataGridView1.DataSource = ds1.Tables["KB1"];
            conn.Close();
        }
        private void 联系管理员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            管理员会话界面 fom = new 管理员会话界面();
            fom.Show();
            调课界面 fom1 = new 调课界面();
            fom1.Show();
        }

        private void 管理员界面_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("update 教务 set state ='{0}' where id ='{1}'", '0', id);
            SqlCommand comm = new SqlCommand(sql, conn);
            int n = comm.ExecuteNonQuery();
            System.Environment.Exit(0);
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("update 教务 set state ='{0}' where id ='{1}'", '0', id);
            SqlCommand comm = new SqlCommand(sql, conn);
            int n = comm.ExecuteNonQuery();
            System.Environment.Exit(0);
        }

        private void 导出课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
        public static void ExportExcel(string fileName, DataGridView myDGV)//导出为excel表格
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

        private void 清空排课信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("是否删除？","确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(strconnecting);
                conn.Open();
                string sql = "delete from LIUYAN";
                SqlCommand comm = new SqlCommand(sql, conn);
                int n = comm.ExecuteNonQuery();
                if (n < 0)
                {
                    MessageBox.Show("删除失败", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
                }

            }
        }

        private void 课程信息录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            课程优先级设立 fom = new 课程优先级设立();
            fom.Show();
        }

        private void tabControl1_VisibleChanged(object sender, EventArgs e)
        {
            showcourse();
            showcorse2();
        }

        private void 单周课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = "单周课表";
            ExportExcel(x, dataGridView1);
        }

        private void 双周课程表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string x = "双周课表";
            ExportExcel(x, mergeDataGridView1);
        }

        private void 课表清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            for (int i = 1; i < 10; i++)
            {
                conn.Open();
                if (i == 5)
                {
                    conn.Close();
                    continue;
                }
                else
                {
                    string W = "无";
                    string sql = string.Format("update KB1 set MON = '{0}',TUE ='{1}',WEN='{2}',THU ='{3}',FRT ='{4}' where JIE ='{5}'",W,W,W,W,W,i);
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int n = comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            for (int i = 1; i < 10; i++)
            {
                conn.Open();
                if (i == 5)
                {
                    conn.Close();
                    continue;
                }
                else
                {
                    string W = "无";
                    string sql = string.Format("update KB2 set MON = '{0}',TUE ='{1}',WEN='{2}',THU ='{3}',FRT ='{4}' where JIE ='{5}'", W, W, W, W, W, i);
                    SqlCommand comm = new SqlCommand(sql, conn);
                    int n = comm.ExecuteNonQuery();
                    conn.Close();
                }
            }
            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            System.DateTime dt = System.DateTime.Now;
            label5.Text = dt.ToString();
        }

        private void 排课时间段录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            设置排课时间 fom = new 设置排课时间();
            fom.Show();
        }

        private void 课程班级设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 课程查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            课表查询 fom = new 课表查询();
            fom.Show();
        }
       
    }
}
