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
    public partial class Form1 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql1 = string.Format("select id as 课程id,name as 课程,youxianji as 优先级设立 from course");
            conn.Open();
            SqlCommand comm = new SqlCommand(sql1, conn);
            da.SelectCommand = comm;
            SqlCommandBuilder bulider = new SqlCommandBuilder(da);
            da.Fill(ds, "工学院");
            dataGridView1.DataSource = ds.Tables["工学院"];
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {

            }
            else
            {
                MessageBox.Show("不能为空", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
