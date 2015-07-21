using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.OleDb;

namespace Wpf5320
{
    class DBClass
    {
            private  static string odbcConnStr="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb"; 
            private OleDbConnection conn = new OleDbConnection(odbcConnStr);

            public string OdbcConStr
            {
                get { return odbcConnStr; }
                set { odbcConnStr = value; }
            }
            public  void  DbClose()
            {
                conn.Close();
            }
            public void DbOpen()
            {  
                conn.Open();
                
            }

            //条件查询
            public DataSet ConditionQuery(string sql)
            {
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                return ds;
            }
                      
            public DBClass()
            {
                
            }
            public void Manipulation(string s)
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = s;
                conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            public void Manipulation_CMD(string sql)
            {
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
       
    }




    class ACEESSDB        //数据库数据操纵类
    {
        private static string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        private OleDbConnection conn = new OleDbConnection(odbcConnStr);
        public void Manipulation(string s)  //数据库数据操纵方法
        {
            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            string sql = s;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool Judge(string s)  //用来查询表中是否存在相同数据,存在返回TRUE,不存在则返回Fasle
        {

            OleDbConnection conn = new OleDbConnection(odbcConnStr);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string sql = s;
            bool B;
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            B = (cmd.ExecuteScalar() != null);
            conn.Close();
            return B;
        }
    }
}
