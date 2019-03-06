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
    public partial class 设置排课时间 : Form
    {
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 设置排课时间()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

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
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql = string.Format("update Time set time1 ='{0}',time2 = '{1}',time3 ='{2}',time4 ='{3}' where id ='1'", dateTimePicker1.Text, dateTimePicker2.Text, dateTimePicker3.Text, dateTimePicker4.Text);
            System.DateTime dt1 = Convert.ToDateTime(dateTimePicker1.Text);
            System.DateTime dt2 = Convert.ToDateTime(dateTimePicker2.Text);
            System.DateTime dt3 = Convert.ToDateTime(dateTimePicker3.Text);
            System.DateTime dt4 = Convert.ToDateTime(dateTimePicker4.Text);
            System.DateTime dt = DateTime.Now;
            int x1 = compare(dt, dt1);
            int x2 = compare(dt1, dt2);
            int x3 = compare(dt2, dt3);
            int x4 = compare(dt3, dt4);
            if (dateTimePicker1.Text == dateTimePicker2.Text || dateTimePicker2.Text == dateTimePicker3.Text || dateTimePicker4.Text == dateTimePicker3.Text)
            {
                MessageBox.Show("时间输入有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (x1 == 1 || x2 == 0 || x3 == 0 || x4 == 0)
                {
                    MessageBox.Show("时间输入有误", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    conn.Open();
                    SqlCommand commc = new SqlCommand(sql, conn);
                    int n = commc.ExecuteNonQuery();
                    if (n < 0)
                    {

                    }
                    else
                    {
                        MessageBox.Show("提交时间成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                }
            }
        }
    }
}
