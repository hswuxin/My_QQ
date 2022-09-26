using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace My_QQ
{
    public partial class Register : Form
    {
        //公有变量
        public string userid;//传递账号
        public bool is_updata =false;//更新账号
        //
        Timer t1 = new Timer();
        public Register(Timer t)
        {
            t1 = t;
            InitializeComponent();
        }
        public Register()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string MyqqName;
            sqlHelper s1 = new sqlHelper();
            //验证账号
            if (nickname.Text.Trim() == "" || nickname.Text.Length > 20)
            {
                MessageBox.Show("非法昵称！", "提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
                nickname.Focus();
                return;
            }
            //验证密码
            if (age.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                age.Focus();
                return;
            }
            //验证性别
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("请输入性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Focus();
                return;
            }
            //验证密码
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Focus();
                return;
            }
            if (passwordok.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordok.Focus();
                return;
            }
            if (password.Text.Trim() !=passwordok.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordok.Focus();
                return;
            }
            //获取性别
            string sex = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            //user类存储账号信息
            qq_User user = new qq_User();
            user.NickName = nickname.Text;
            user.Age = Convert.ToInt32(age.Text);
            user.Sex = sex;
            user.UserPwd = passwordok.Text;
            user.RealName = realname.Text;
            user.Email = email.Text;
            user.PersonalMsg = permessage.Text;
            //sql语句
            string sql = string.Format("insert into qq_User(nickName,age,sex,userPwd,realName,email,personalMsg,face)values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", user.NickName, user.Age, user.Sex, user.UserPwd, user.RealName, user.Email, user.PersonalMsg,pictureBox1.Tag);
            string sql2 = "SELECT TOP 1 * FROM qq_User order by userId desc";
            int result = s1.ExeNonQuery(sql);
            if (result == 1)
            {
                s1.connOpen();
                MyqqName = Convert.ToString(s1.ExeScalar(sql2));
                MessageBox.Show("注册成功,您的QQ号码为：" + MyqqName, "提示");
            }
            else
            {
                MessageBox.Show("注册失败，发生了意料之外的错误！","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            s1.connClose();
            MessageBox.Show("注册成功，数据库关闭！", "提示");
            this.Close();
        }
        //更新账号
        void updata()
        {
            is_updata = true;
            string MyqqName;
            sqlHelper s2 = new sqlHelper();
            //验证账号
            if (nickname.Text.Trim() == "" || nickname.Text.Length > 20)
            {
                MessageBox.Show("非法昵称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                nickname.Focus();
                return;
            }
            //验证密码
            if (age.Text.Trim() == "")
            {
                MessageBox.Show("请输入年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                age.Focus();
                return;
            }
            //验证性别
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("请输入性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label3.Focus();
                return;
            }
            //验证密码
            if (password.Text.Trim() == "")
            {
                MessageBox.Show("请输入密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Focus();
                return;
            }
            if (passwordok.Text.Trim() == "")
            {
                MessageBox.Show("请输入确认密码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordok.Focus();
                return;
            }
            if (password.Text.Trim() != passwordok.Text.Trim())
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                passwordok.Focus();
                return;
            }
            //获取性别
            string sex = radioButton1.Checked ? radioButton1.Text : radioButton2.Text;
            //user类存储账号信息
            qq_User user = new qq_User();
            user.NickName = nickname.Text;
            user.Age = Convert.ToInt32(age.Text);
            user.Sex = sex;
            user.UserPwd = passwordok.Text;
            user.RealName = realname.Text;
            user.Email = email.Text;
            user.PersonalMsg = permessage.Text;
            //sql语句
            string sql = string.Format("update qq_User set nickName='{0}',age='{1}',sex='{2}',userPwd='{3}',realName='{4}',email='{5}',personalMsg='{6}',face='{8}' where userId={7}", user.NickName, user.Age, user.Sex, user.UserPwd, user.RealName, user.Email, user.PersonalMsg,userid,pictureBox1.Tag);
            s2.ExeNonQuery(sql);
            s2.connClose();
            MessageBox.Show("上传成功，数据库关闭！", "提示");
            this.Close();
            
        }

        private void Register_Activated(object sender, EventArgs e)
        {
            nickname.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updata();
            t1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Face f = new Face(pictureBox1);
            f.Show();
        }
    }
}
