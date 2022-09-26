using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;//SQL命名空间
using System.Runtime.InteropServices;

namespace My_QQ
{
    public partial class Form1 : Form
    {
        public bool sql_conn = false;
        public Form1()
        {
            InitializeComponent();
        }
        //窗体拖动API
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern int ReleaseCapture();
        public const int WM_SysCommand = 0x0112;
        public const int SC_MOVE = 0xF012;
        //
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //登录
        void login()
        {
            //使用数据库类实现登陆操作
            sqlHelper s1 = new sqlHelper();
            s1.connOpen();
            string sql = string.Format("select userId,userPwd from qq_User where userId={0} and userPwd={1}", textBox1.Text, textBox2.Text);
            if (s1.ExeScalar(sql) != null)
            {
                //进入主界面，传递登陆账号信息
                Main m = new Main();
                //传递登陆账号
                m.userId = textBox1.Text;
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("未检测到帐号！", "提示");
            }
            s1.connClose();
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            #region 没有使用类
            ////登陆
            ////操作数据库
            ////连接数据库
            //string SqlStr = "Server=.;Database=MyQQ2;Integrated Security=SSPI";
            //SqlConnection con = new SqlConnection(SqlStr);
            ////连接打开
            //con.Open();
            ////字符串连接方式
            //string sql = "select * from qq_User where userId="+textBox1.Text+ "and userPwd="+textBox2.Text;
            ////格式化字符串方式
            //string sql2 = string.Format("select userId,userPwd from qq_User where userId={0} and userPwd={1}",textBox1.Text,textBox2.Text);
            //SqlCommand com = new SqlCommand(sql2,con);
            ////按照语句种类的不同选择执行方式
            ////返回值为object类，如果ob又返回值说明数据库里有我们要查的数据
            //object ob = com.ExecuteScalar();
            //if (ob != null)
            //{
            //    MessageBox.Show("登录成功！","提示" );
            //}
            //else
            //{
            //    MessageBox.Show( "未检测到帐号！","提示");
            //}
            ////关闭连接
            //con.Close();
            #endregion
            login();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(13))
            {
                login();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register fr2 = new Register();
            fr2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //窗体设计，picturebox的层级显示关系
            pictureBox1.Parent = label1;
            pictureBox2.Parent = label1;
        }
        

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            //窗体拖动
            ReleaseCapture();
            SendMessage(this.Handle, WM_SysCommand, SC_MOVE, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
