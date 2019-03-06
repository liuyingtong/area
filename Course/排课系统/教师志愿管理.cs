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
    public partial class 教师志愿管理 : Form
    {
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 教师志愿管理()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            string sql = "delete LIUYAN";
            conn.Open();
            SqlCommand comm = new SqlCommand(sql, conn);
            int n = comm.ExecuteNonQuery();
            if (n < 0)
            {
                MessageBox.Show("删除失败", "失败", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("删除成功", "成功", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
