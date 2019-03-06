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
    public partial class 课程信息 : Form
    {
        SqlDataAdapter da = new SqlDataAdapter();
        DataSet ds = new DataSet("paike");
        string tname = "";
        string strconnecting = @"Data Source=.\kirito;Initial Catalog=paike;Integrated Security=True";
        public 课程信息(string g)
        {
            InitializeComponent();
            tname = g;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(strconnecting);
            conn.Open();
            string sql = string.Format("select name as 课程名称,id as 课程id,teacher as 授课教师,特殊情况 as 是否单双周只上一节 from course where teacher = '{0}'",tname);
            SqlCommand comm = new SqlCommand(sql, conn);
            da.SelectCommand = comm;
            SqlCommandBuilder bulider = new SqlCommandBuilder(da);
            da.Fill(ds, "course");
            mergeDataGridView1.DataSource = ds.Tables["course"];
            conn.Close();
        }
    }
}
