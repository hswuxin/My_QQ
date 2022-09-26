using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace My_QQ
{
    class qq_User
    {
        //封装用户表所有字段
        //属性
        public int UserId { get; set; }
        public string UserPwd { get; set; }
        public string NickName { get; set; }
        public string RealName { get; set; }
        public string PersonalMsg { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public int Face { get; set; }
        public DateTime RegTime { get; set; }
        public int UserType { get; set; }
        public string StudentID { get; set; }
        public string Appid { get; set; }
    }
}
