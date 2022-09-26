using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace My_QQ
{
    public partial class Search : Form
    {
        //公共变量
        public string userId;
        string friendId;
        Main m = new Main();
        ListView v1 = new ListView();
        Timer t1 = new Timer();
        public Search(ListView v,Timer t)
        {
            v1 = v;
            t1 = t;
            InitializeComponent();

        }
        public Search()
        {
            InitializeComponent();
        }
        //精确查找账号
        public void serch()
        {
            string sql = string.Format("select * from qq_User where userId='{0}'", textBox1.Text);
            sqlHelper s1 = new sqlHelper();
            SqlDataReader sdr = s1.ExeDataReader(sql);
            if (sdr.Read())
            {
                ListViewItem lv1 = new ListViewItem();
                lv1.ImageIndex = Convert.ToInt32(sdr["face"]);
                lv1.Text = Convert.ToString(sdr["nickName"]);
                lv1.SubItems.Add(sdr["personalMsg"].ToString());
                lv1.SubItems.Add(sdr["sex"].ToString());
                listView1.Items.Add(lv1);

                ColumnHeader ch = new ColumnHeader();
                ch.Text="昵称";
                this.listView1.Columns.Add(ch);
                ColumnHeader ch2 = new ColumnHeader();
                ch2.Text = "个性签名";
                this.listView1.Columns.Add(ch2);
                ColumnHeader ch3 = new ColumnHeader();
                ch3.Text = "性别";
                this.listView1.Columns.Add(ch3);
                friendId =Convert.ToString(sdr["userId"]);
            }
            else
            {
                MessageBox.Show("没有此账号！", "提示");
            }
            s1.connClose();
        }
        //添加好友
        void plus_friend()
        {
            string sql = string.Format("insert into qq_Friends(hostId,friendId,state) values('{0}','{1}',1)", userId, friendId);
            sqlHelper s1 = new sqlHelper();
            int n=s1.ExeNonQuery(sql);
            if (n == 0)
            {
                MessageBox.Show("添加好友失败，请尝试重新添加", "提示");
            }
            else
            { 
            }
            s1.connClose();
            v1.Clear();
            t1.Start();
        }
        //模糊查找
        void search_mh()
        {
            string sqltext;
            string sql = string.Format("select * from qq_User ");
            string sex = string.Format("");
            string age = string.Format("");
            if (radioButton1.Checked)
                sex = "sex = '男'";
            else if (radioButton2.Checked)
                sex = "sex = '女'";
            if (comboBox1.SelectedIndex == 0)
                age = "age <= 15";
            else if (comboBox1.SelectedIndex == 1)
                age = "age >= 16 and age <= 25";
            else if (comboBox1.SelectedIndex == 2)
                age = "age >= 6 and age <= 50";
            else if (comboBox1.SelectedIndex == 3)
                age = "age > 50";
            if (sex == "" & age == "")
                sqltext = sql;
            else
            {
                sql = sql + " where ";
                if (sex != "" & age != "")
                    sqltext = sql + sex +" and "+ age;
                else
                    sqltext = sql + sex + age;
            }
            sqlHelper s1 = new sqlHelper();
            DataSet ds= s1.ExeDataSet(sqltext);
            dataGridView1.DataSource = ds.Tables[0];
            //隐藏隐私列
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
            dataGridView1.Columns[12].Visible = false;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            plus_friend();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serch();
        }

        private void Search_Load(object sender, EventArgs e)
        {
            Main m=new Main();
            listView1.LargeImageList = m.imageList1;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            search_mh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //获取选中ID                  
            //第一次查询的异常被处理
            try
            {
                friendId = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            }
            catch (Exception) { }
        }
    }
}
