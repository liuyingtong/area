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
    public partial class 管理员回复 : Form
    {
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        string report = "";
        string name = "";
        public 管理员回复(string c ,string x)
        {
            InitializeComponent();
            report = c;
            name = x;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = report;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql5 = string.Format("delete 回复 where name = '{0}'",name);
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
            this.Close();
        }
    }
}
