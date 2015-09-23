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
            private static string odbcConnStr="Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
            private OleDbConnection conn = new OleDbConnection(odbcConnStr);

            public static OleDbConnection getConn() //获取数据表
            {
                OleDbConnection mydata = new OleDbConnection(odbcConnStr);
                mydata.Open();
                return mydata;
            }

            public DBClass() { }

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
            public static DataSet ConditionQuery(string sql)
            {
                try
                {
                    OleDbConnection conn = new OleDbConnection(odbcConnStr);
                    conn.Open();
                    OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    conn.Close();
                    return ds;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
                      
            public static void Manipulation(string sql)
            {
                try
                {
                    OleDbConnection conn = new OleDbConnection(odbcConnStr);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            public static void Manipulation_CMD(string sql)
            {
                try
                {
                    OleDbConnection conn = new OleDbConnection(odbcConnStr);
                    conn.Open();
                    OleDbCommand cmd = new OleDbCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            public static bool Judge(string sql)  //用来查询表中是否存在相同数据,存在返回TRUE,不存在则返回Fasle
            {

                try
                {
                    bool judge_;
                    DataSet ds = ConditionQuery(sql);
                    judge_ = (ds.Tables[0].Rows.Count != 0);
                    return judge_;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
       
    }




    class ACEESSDB        //数据库数据操纵类
    {
        private static string odbcConnStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppDomain.CurrentDomain.BaseDirectory + "\\TSISData.accdb";
        private OleDbConnection conn = new OleDbConnection(odbcConnStr);
        public static void Manipulation(string s)  //数据库数据操纵方法
        {
            try 
            { 
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                string sql = s;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static DataSet ConditionQuery(string sql)
        {
            try
            {
                OleDbConnection conn = new OleDbConnection(odbcConnStr);
                OleDbDataAdapter adp = new OleDbDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                conn.Close();
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static bool Judge(string sql)  //用来查询表中是否存在相同数据,存在返回TRUE,不存在则返回Fasle
        {

            try
            {
                bool judge_;
                DataSet ds = ConditionQuery(sql);
                judge_ = (ds.Tables[0].Rows.Count != 0);
                return judge_;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
