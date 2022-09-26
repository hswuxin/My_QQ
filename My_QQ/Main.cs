using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Media;

namespace My_QQ
{
    public partial class Main : Form
    {
 
        //窗体拖动API
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        public static extern int ReleaseCapture();
        public const int WM_SysCommand = 0x0112;
        public const int SC_MOVE = 0xF012;
        //

        //创建公有变量
        public string userId;
        public bool is_pluse;
        public Main()
        {
            InitializeComponent();
        }
        //窗体加载时显示个人信息
        void showInfo()
        {
            sqlHelper s1 = new sqlHelper();
            string sql = string.Format("select * from qq_User where userId='{0}'", userId);
            SqlDataReader sdr = s1.ExeDataReader(sql);
            try
            {
                while (sdr.Read())
                {
                    label1.Text = Convert.ToString(sdr["nickName"]);
                    label2.Text = Convert.ToString(sdr["personalMsg"]);
                    int i =Convert.ToInt32(sdr["face"]);
                    pictureBox1.Image=imageList1.Images[i];
                }

            }
            catch(Exception)
            { 
            }
            s1.connClose();
        }
        //显示好友信息
        public void showFriendsInfo()
        {
            sqlHelper s1 = new sqlHelper();
            string sql = string.Format("select * from qq_Friends where hostId='{0}'", userId);
            SqlDataReader sdr = s1.ExeDataReader(sql);
            while (sdr.Read())
            {
                //读取一个对应好友的用户信息
                qq_User friend = new qq_User();
                friend.UserId = Convert.ToInt32(sdr["friendId"]);
                string sql2 = string.Format("	select * from qq_User where userId='{0}'",friend.UserId);
                sqlHelper s2 = new sqlHelper();
                SqlDataReader fdr = s2.ExeDataReader(sql2);
                fdr.Read();
                friend.NickName =Convert.ToString(fdr["nickName"]);//好友昵称
                friend.Face = Convert.ToInt32(fdr["face"]);//好友头像
                friend.PersonalMsg = Convert.ToString(fdr["personalMsg"]);
                //将好友信息展示在listview里
                ListViewItem lv1 = new ListViewItem();
                lv1.ImageIndex = friend.Face;
                lv1.Text = friend.NickName;
                //个人信息列
                ColumnHeader ch = new ColumnHeader();
                ch.TextAlign = HorizontalAlignment.Left;
                listView1.Columns.Add(ch);
                lv1.SubItems.Add(friend.PersonalMsg);
                lv1.ToolTipText = friend.UserId.ToString();
                listView1.Items.Add(lv1);
                lv1.Tag = friend.Face;
            }
            s1.connClose();
        }

        //圆形图片框头像
        void circleImg()
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
        }
        //查找数据库中有没有账号的未读消息，如果有消息则头像闪
        void is_message()
        {
                string sql = string.Format("select * from qq_Messages where toId='{0}' and state=0", userId);
                sqlHelper s1 = new sqlHelper();
                SqlDataReader sdr = s1.ExeDataReader(sql);
                while (sdr.Read())
                {
                    //查看谁发的消息()
                    for (int i = 0; i < listView1.Items.Count; i++)//遍历好友列表
                    {
                        if (listView1.Items[i].ToolTipText == Convert.ToString(sdr["fromId"]))
                        {
                            if (listView1.Items[i].ImageIndex < 100)
                                listView1.Items[i].ImageIndex = 100;

                            else
                                listView1.Items[i].ImageIndex = Convert.ToInt32(listView1.Items[i].Tag);
                            //SoundPlayer player = new SoundPlayer(Properties.Resources.msg);
                            //player.Play();
                        }
                    }
                }
                s1.connClose();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            showInfo();
            showFriendsInfo();
            circleImg();
            textBox1.Hide();
            timer2.Stop();
            timer3.Stop();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            //窗体拖动
            ReleaseCapture();
            SendMessage(this.Handle, WM_SysCommand, SC_MOVE, 0);
            //搜索隐藏
            textBox1.Hide();
            textBox1.Text = "";
        }
        //圆角
        public void SetWindowRegion()
        {
            System.Drawing.Drawing2D.GraphicsPath FormPath;

            FormPath = new System.Drawing.Drawing2D.GraphicsPath();

            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height - 22);//this.Left-10,this.Top-10,this.Width-10,this.Height-10);                

            FormPath = GetRoundedRectPath(rect,5);

            this.Region = new Region(FormPath);

        }
        //圆角
        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {

            int diameter = radius;

            Rectangle arcRect = new Rectangle(rect.Location, new Size(diameter, diameter));

            GraphicsPath path = new GraphicsPath();

            //   左上角  

            path.AddArc(arcRect, 180, 90);

            //   右上角  

            arcRect.X = rect.Right - diameter;

            path.AddArc(arcRect, 270, 90);

            //   右下角  

            arcRect.Y = rect.Bottom - diameter;

            path.AddArc(arcRect, 0, 90);

            //   左下角  

            arcRect.X = rect.Left;

            path.AddArc(arcRect, 90, 90);

            path.CloseFigure();

            return path;

        }
        //圆角
        private void Main_Resize(object sender, EventArgs e)
        {
            SetWindowRegion();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            textBox1.Show();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            //双击好友，打开聊天窗体
            listView1.SelectedItems[0].ImageIndex = Convert.ToInt32(listView1.Tag);//恢复头像
            qq_User friend = new qq_User();
            friend.NickName= listView1.SelectedItems[0].Text;
            friend.UserId=Convert.ToInt32(listView1.SelectedItems[0].ToolTipText);
            friend.Face = listView1.SelectedItems[0].ImageIndex;
            Chat c = new Chat();
            c.friendId =Convert.ToString(friend.UserId);//传递好友
            c.userId = userId;//传递个人账号
            c.nickname = friend.NickName;//传递好友名称
            c.Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            is_message();
        }

        private void listView_tm1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Search s1 = new Search(listView1,timer2);
            s1.Show();
            s1.userId = userId;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            //listView1.Clear();
            showFriendsInfo();
            timer2.Stop();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Register r = new Register(timer3);
            r.userid = userId;
            r.Show();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
        }

        private void timer3_Tick_1(object sender, EventArgs e)
        {
            showInfo();
            timer3.Stop();
        }
    }
}
