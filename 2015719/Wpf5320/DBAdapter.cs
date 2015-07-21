
using System;
using System.Data;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Configuration;
using System.Text;


namespace Wpf5320
{
    /// <summary> 
    /// 模块编号：DBAdapter
    /// 作用：
    /// 作者：杨立君 
    /// 编写日期： 2015-5-1 
    /// </summary>

    public class DBAdapter
    {
        #region 获取数据库连接字符串
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="connectionKey">连接字符串的Key</param>
        /// <returns>返回数据库连接字符串</returns>
        public static string GetConnectionString(string connectionKey)
        {
            //endecode aa = new endecode();
            string dBConnectionString ="Provider=SQLOLEDB.1;Password=sde;Persist Security Info=True;User ID=sde;Initial Catalog=sde;Data Source=hyj";
            //string dBConnectionString = aa.Decrypto(ConfigurationManager.ConnectionStrings[connectionKey].ConnectionString);
            return dBConnectionString;
        }
        #endregion
        #region  
        /// <summary>
        /// 获取打开的数据连接对象
        /// </summary>
        /// <returns>返回打开的数据连接对象</returns>
        public static OleDbConnection GetOleDBConnection()
        {
          //  endecode aa = new endecode();
            string dBConnectionString = GetConnectionString("connectionKey");
            OleDbConnection conn = new OleDbConnection(dBConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// 获取打开的数据连接对象
        /// </summary>
        /// <param name="dBConnectionString">数据库连接字符串</param>
        /// <returns>返回打开的数据连接对象</returns>
        public static OleDbConnection GetOleDBConnection(string connectionKey)
        {
            string dBConnectionString = GetConnectionString(connectionKey);
            OleDbConnection conn = new OleDbConnection(dBConnectionString);
            conn.Open();
            return conn;
        }
        #endregion
        #region 打开关闭的数据连接对象
        /// <summary>
        /// 打开关闭的数据连接对象
        /// </summary>
        /// <param name="conn">数据库连接对象</param>
        public static void GetOpenAgainOleDBConnection(OleDbConnection conn)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

        }
        #endregion
        #region 获取数据集
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>返回数据集</returns>
        public static DataSet GetSqlDataSet(OleDbConnection conn, string sqlString)
        {
            DataSet dsName = null;

            GetOpenAgainOleDBConnection(conn);
            OleDbDataAdapter dAdapName = new OleDbDataAdapter(sqlString,conn);
            dsName = new DataSet();
            dAdapName.Fill(dsName);

            return dsName;
        }
        #endregion
        #region 获取DataReader对象
        /// <summary>
        /// 获取DataReader对象
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>返回DataReader对象</returns>
        public static OleDbDataReader GetSqlDataReader(OleDbConnection conn, string sqlString)
        {
            OleDbDataReader dRead = null;

            GetOpenAgainOleDBConnection(conn);
            OleDbCommand comm = new OleDbCommand(sqlString, conn);
            dRead = comm.ExecuteReader();

            return dRead;
        }
        #endregion
        #region 获取数据表

        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <param name="conn">ole连接</param>
        /// <param name="sqlString">查询语句</param>
        /// <returns></returns>
        public static DataTable GetSqlDataTable(OleDbConnection conn,string sqlString)
        {
            DataTable dTable = null;
            GetOpenAgainOleDBConnection(conn);
            OleDbDataAdapter dAdapName = new OleDbDataAdapter(sqlString, conn);
            dTable = new  DataTable();
            dAdapName.Fill(dTable);
            return dTable;
        }
        #endregion



        #region 获取表字段的描述信息（提示信息）
        /// <summary>
        /// 获取表字段的描述信息（提示信息）
        /// </summary>
        /// <param name="conn">ole连接</param>
        /// <param name="TableName">表名</param>
        /// <param name="ZiDuanName">字段名</param>
        /// <returns></returns>
        public static string GetTableOptionDescrip(OleDbConnection conn, string TableName, string ZiDuanName)
        {
            GetOpenAgainOleDBConnection(conn);
            string tempStr = "";
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select a.name N'字段名',g.[value] AS [说明] from syscolumns a inner join sysobjects d on a.id=d.id and d.xtype='U' and d.name<>'dtproperties' left join sys.extended_properties g on a.id=g.major_id AND a.colid=g.minor_id WHERE d.name='" + TableName + "'";
            OleDbDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    if (dr.GetString(0) == ZiDuanName)
                    {

                        tempStr = dr.GetString(1);
                    }
                }
            }
            catch (System.InvalidCastException )
            {
                tempStr = "该字段提示信息无法显示，请检查是否有误";
            }
            finally
            {
                conn.Close();

            }
            return tempStr;



        }

        #endregion


        #region 获取Sql语句的插入、修改、删除操作影响的行数
        /// <summary>
        /// 获取Sql语句的插入、修改、删除操作影响的行数
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>返回影响的行数</returns>
        public static int GetSqlExecuteNum(OleDbConnection conn,string sqlString)
        {
            int rowNum = 0;

            GetOpenAgainOleDBConnection(conn);
            OleDbCommand comm = new OleDbCommand(sqlString, conn);
            rowNum = comm.ExecuteNonQuery();
            comm.Dispose();

            return rowNum;
        }
        #endregion

        #region 批量Sql语句的插入、修改、删除操作
        /// <summary>
        /// 批量Sql语句的插入、修改、删除操作
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlStringList">Sql语句数组</param>
        /// <returns>返回执行是否成功</returns>
        public static bool SqlExecute(OleDbConnection conn, System.Collections.ArrayList sqlStringList)
        {
            bool result = true;
            OleDbTransaction transaction = null;
            OleDbCommand comm = new OleDbCommand();
            try
            {
                GetOpenAgainOleDBConnection(conn);
                transaction = conn.BeginTransaction();
                comm.Connection = conn;
                comm.Transaction = transaction;
                foreach (string cmd in sqlStringList)
                {
                    comm.CommandText = cmd;
                    comm.ExecuteNonQuery();
                }
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                result = false;
            }
            comm.Dispose();
            return result;
        }
        #endregion

        #region 获取是否存在数据
        /// <summary>
        /// 获取是否存在数据
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>返回是否存在数据行</returns>
        public static bool GetSqlDataHasRows(OleDbConnection conn, string sqlString)
        {
            bool bflag = false;
            OleDbDataReader dRead = GetSqlDataReader(conn, sqlString);
            if (dRead != null)
            {
                bflag = dRead.HasRows;
            }
            dRead.Close();

            return bflag;
        }
        #endregion
        #region 获取第一行第一列的值
        /// <summary>
        /// 获取第一行第一列的值
        /// </summary>
        /// <param name="conn"> 数据库连接对象</param>
        /// <param name="sqlString">Sql语句</param>
        /// <returns>返回第一行第一列的值</returns>
        public static object GetDataTableFirstColumn(OleDbConnection conn, string sqlString)
        {
            object objName = null;
            GetOpenAgainOleDBConnection(conn);
            OleDbCommand comm = new OleDbCommand(sqlString, conn);
            objName = comm.ExecuteScalar();
            comm.Dispose();
            return objName;
        }
        #endregion

        /*
        #region 判断是否存在相同记录
        /// <summary>
        /// 判断唯一性
        /// </summary>
        /// <param name="Strcon">连接数据库</param>
        /// <param name="sql">sql语句</param>
        /// <returns>存在同名文件返回true,反之false</returns>
        public static bool IsExist(OleDbConnection conn, string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql,conn);

            OleDbDataReader sdr = cmd.ExecuteReader();
     
            if (sdr.Read())
            {
                return true;
            }
            else
            {
                return false;
            }
            sdr.Close();
            conn.Close();
            cmd.Dispose();
        }
        #endregion
*/
    }

}
