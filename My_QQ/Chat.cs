using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace My_QQ
{
    public partial class Chat : Form
    {
        //窗体拖动API
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern int ReleaseCapture();
        public const int WM_SysCommand = 0x0112;
        public const int SC_MOVE = 0xF012;
        //
        //创建公共变量
        //接受好友数据
        public string friendId;
        //接受当前账号信息
        public string userId;
        //接受好友昵称
        public string nickname;
        public Chat()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //展示好友信息
        void showinfo()
        {
            qq_User friend=new qq_User();
            friend.UserId = Convert.ToInt32(friendId);
            string sql = string.Format("	select * from qq_User where userId='{0}'", friend.UserId);
            sqlHelper s1 = new sqlHelper();
            SqlDataReader sdr = s1.ExeDataReader(sql);
            sdr.Read();
            friend.NickName = Convert.ToString(sdr["nickName"]);//好友昵称
            friend.Face = Convert.ToInt32(sdr["face"]);//好友头像
            friend.PersonalMsg = Convert.ToString(sdr["personalMsg"]);
            label1.Text = friend.NickName;
            int i = friend.Face;
            pictureBox1.Image = imageList1.Images[i];
            label2.Text = friend.PersonalMsg;
            label3.Text =Convert.ToString("("+friend.UserId+")");
        }
        //发送消息
        void send_Text()
        {
            DateTime d;//时间
            //文本框展示
            if (richTextBox_tm2.Text == "")
            {
                MessageBox.Show("未输入内容！", "提示");
            }
            else 
            {
                richTextBox_tm1.SelectionAlignment = HorizontalAlignment.Right;//右对齐
                richTextBox_tm1.SelectionFont = new Font("黑体", 10);//字体样式
                richTextBox_tm1.SelectionColor = Color.BlanchedAlmond;//
                d = DateTime.Now;
                richTextBox_tm1.AppendText("我  " + d);//消息发送者+时间
                richTextBox_tm1.AppendText("\n");
                richTextBox_tm1.SelectionFont = new Font("宋体", 10);//字体样式
                richTextBox_tm1.AppendText(richTextBox_tm2.Text);//消息
                richTextBox_tm1.AppendText("\n");
            }
            d = DateTime.Now;
            //写入数据库
            string sql = string.Format("insert into qq_Messages(fromId,toId,mInfo,state,sendTime) values('{0}','{1}','{2}',0,'{3}')select *from qq_Messages where fromId='{0}'", userId, friendId, richTextBox_tm2.Text,d);
            sqlHelper s1 = new sqlHelper();
            int t = s1.ExeNonQuery(sql);
        }
        //richtextbox1的样式
        void rich_style()
        {
            richTextBox_tm1.SelectionStart = int.MaxValue;
            richTextBox_tm1.SelectionLength = 1;
            this.richTextBox_tm1.HideSelection = false;
            richTextBox_tm1.ScrollToCaret();
        }
        //实时的消息展示
        void show_message()
        {
            //定时搜索数据库，找到未读消息现实到文本框
            string sql_receive = string.Format("select * from qq_Messages where fromId='{0}' and toId='{1}' and state=0", friendId, userId);
            sqlHelper s1 = new sqlHelper();
            SqlDataReader sdr = s1.ExeDataReader(sql_receive);
            while (sdr.Read())
            {
                DateTime d;
                richTextBox_tm1.SelectionAlignment = HorizontalAlignment.Left;//右对齐
                richTextBox_tm1.SelectionFont = new Font("黑体", 10);//字体样式
                richTextBox_tm1.SelectionColor = Color.BlanchedAlmond;//
                d = DateTime.Now;
                richTextBox_tm1.AppendText(nickname + "(" + friendId + ")" + " " + d);//消息发送者+时间
                richTextBox_tm1.AppendText("\n");
                richTextBox_tm1.SelectionFont = new Font("宋体", 10);//字体样式
                richTextBox_tm1.AppendText(sdr["mInfo"].ToString());//消息
                richTextBox_tm1.AppendText("\n");
                //将消息已读
                sqlHelper s2 = new sqlHelper();
                string sql_change = string.Format("update qq_Messages set state=1 where fromId={0} and toId={1} or state=0 select * from qq_Messages where toId='{1}'", friendId, userId);
                s2.ExeNonQuery(sql_change);
            }
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            rich_style();
            showinfo();
            richTextBox_tm2.Focus();//输入框焦点
        }

        private void Chat_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_SysCommand, SC_MOVE, 0);
        }

        private void sendText_Click(object sender, EventArgs e)
        {
            send_Text();
            richTextBox_tm2.Clear();
        }

        private void richTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            show_message();
        }

        private void closeText_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}