using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;

namespace My_QQ
{
    class sqlHelper
    {

        //数据库操作类
        //机房
        //string conStr = "Server=.;Database=MyQQ2;Integrated Security=SSPI";
        
        //宿舍机器
        string conStr2 = @"Server=DESKTOP-5OF4LA4\SQLEXPRESS;Database=MyQQ2;Integrated Security=SSPI";
        SqlConnection conn;
        SqlCommand comm;
        //构造函数
        public sqlHelper()
        {
            //创建连接对象
            conn = new SqlConnection(conStr);
            conn.Open();
            
        }
        //打开数据库的方法
        public void connOpen()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
        }
        //关闭数据库的方法
        public void connClose()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        //访问数据库的方法
        //增删查改
        //ExecuteNonQuery
        public int ExeNonQuery(string sqlText)
        {
            comm = new SqlCommand(sqlText, conn);
            int o=comm.ExecuteNonQuery();
            conn.Close();
            return o;
        }
        //ExecuteScalar
        public object ExeScalar(string sqlText)
        {
            comm = new SqlCommand(sqlText, conn);
            object o=comm.ExecuteScalar();
            conn.Close();
            return o;
        }
        //执行select语句方法——ExecuteReader
        public SqlDataReader ExeDataReader(string sqlText)
        {
            comm = new SqlCommand(sqlText,conn);
            return comm.ExecuteReader();
        }
        //执行select查询操作——DataSet数据集
        public DataSet ExeDataSet(string sqlText)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sqlText, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            connClose();
            return ds;
        }
        //关闭链接
        public void coloseconn()
        {
            conn.Close();
        }
    }
}
