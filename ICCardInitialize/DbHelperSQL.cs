using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;

/// <summary>
/// 数据访问抽象基础类
/// </summary>
public abstract class DbHelperSQL
{
    //数据库连接字符串(Settings.ini来配置)，可以动态更改connectionString支持多数据库.		

    //public static string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 

    public DbHelperSQL()
    {
    }


    #region 公用方法

    public static string connectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
    }

    /// <summary>
    /// 判断是否存在某表的某个字段
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="columnName">列名称</param>
    /// <returns>是否存在</returns>
    public static bool ColumnExists(string tableName, string columnName)
    {
        string sql = "select count(1) from syscolumns where [id]=object_id('" + tableName + "') and [name]='" + columnName + "'";
        object res = GetSingle(sql);
        if (res == null)
        {
            return false;
        }
        return Convert.ToInt32(res) > 0;
    }
    public static int GetMaxID(string FieldName, string TableName)
    {
        string strsql = "select max(" + FieldName + ")+1 from " + TableName;
        object obj = DbHelperSQL.GetSingle(strsql);
        if (obj == null)
        {
            return 1;
        }
        else
        {
            return int.Parse(obj.ToString());
        }
    }
    public static bool Exists(string strSql)
    {
        object obj = DbHelperSQL.GetSingle(strSql);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    /// <summary>
    /// 表是否存在
    /// </summary>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public static bool TabExists(string TableName)
    {
        string strsql = "select count(*) from sysobjects where id = object_id(N'[" + TableName + "]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
        //string strsql = "SELECT count(*) FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[" + TableName + "]') AND type in (N'U')";
        object obj = DbHelperSQL.GetSingle(strsql);
        int cmdresult;
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
        {
            cmdresult = 0;
        }
        else
        {
            cmdresult = int.Parse(obj.ToString());
        }
        if (cmdresult == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
   
    #endregion

    #region  执行简单SQL语句

    /// <summary>
    /// 执行SQL语句，返回影响的记录数
    /// </summary>
    /// <param name="SQLString">SQL语句</param>
    /// <returns>影响的记录数</returns>
    public static int ExecuteSql(string SQLString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows;
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }

    /// <summary>
    /// 执行一条计算查询结果语句，返回查询结果（object）。
    /// </summary>
    /// <param name="SQLString">计算查询结果语句</param>
    /// <returns>查询结果（object）</returns>
    public static object GetSingle(string SQLString)
    {
        using (SqlConnection  connection = new SqlConnection (connectionString()))
        {
            using (SqlCommand cmd = new SqlCommand(SQLString, connection))
            {
                try
                {
                    connection.Open();
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (System.Data.SqlClient.SqlException e)
                {
                    connection.Close();
                    throw e;
                }
            }
        }
    }
   
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataSet</returns>
    public static DataSet Query(string SQLString)
    {
        using (SqlConnection  connection = new SqlConnection (connectionString()))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }
    }
    public static DataSet Query(string SQLString, int Times)
    {
        using (SqlConnection  connection = new SqlConnection (connectionString()))
        {
            DataSet ds = new DataSet();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.SelectCommand.CommandTimeout = Times;
                command.Fill(ds, "ds");
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;
        }
    }


    /// <summary>
    /// 执行查询语句，返回DataTable
    /// </summary>
    /// <param name="SQLString">查询语句</param>
    /// <returns>DataTable</returns>
    public static DataTable ReturnTableQuery(string SQLString)
    {
        using (SqlConnection  connection = new SqlConnection (connectionString()))
        {
            DataTable dtbl = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.Fill(dtbl);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dtbl;
        }
    }
    public static DataTable ReturnTableQuery(string SQLString, int Times)
    {
        using (SqlConnection  connection = new SqlConnection (connectionString()))
        {
            DataTable dtbl = new DataTable();
            try
            {
                connection.Open();
                SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                command.SelectCommand.CommandTimeout = Times;
                command.Fill(dtbl);
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return dtbl;
        }
    }



    #endregion


    #region 用户自定义方法
    public static void ComboxBind(System.Windows.Forms.ComboBox combControl, string strTableName, string strText, string strValue, string strWhere, string strOrder)
    {
        string strSql = "SELECT * FROM " + strTableName + " Where " + strWhere + " Order By " + strOrder;
        DataTable dt = new DataTable();
        dt = DbHelperSQL.ReturnTableQuery(strSql);
        if (dt.Rows.Count > 0)
        {
            combControl.DataSource = dt;
            combControl.DisplayMember = strText;
            combControl.ValueMember = strValue;
        }
        else
        {
            combControl.DataSource = null;
        }
    }

    /// <summary>
    /// 判断用户输入的卡号是否已经存在
    /// </summary>
    /// <param name="CardNO"></param>
    /// <returns></returns>
    public static bool isExistCardNO(string CardNO,string CardType)
    {
        string strSql = "select Count(0) from TT_InitialCard where CardNO='" + CardNO + "' and CardType='"+CardType+"'";
        return Exists(strSql);
    }

    /// <summary>
    /// 判断IC卡自带的卡号是否已经存在
    /// </summary>
    /// <param name="CardNOSelf"></param>
    /// <returns></returns>
    public static bool isExistCardID(string CardID, string CardType)
    {
        string strSql = "select Count(0) from TT_InitialCard where CardID='" + CardID + "' and CardType='" + CardType + "'";
        return Exists(strSql);
    }

    public static bool isExistCardID(string CardID)
    {
        string strSql = "select Count(0) from TT_InitialCard where CardID='" + CardID + "'";
        return Exists(strSql);
    }

    public static bool isExistCardNO(string CardNO, string CardID, string CardType)
    {
        string strSql = "";
        if(CardID=="")
            strSql = "select Count(0) from TT_InitialCard where CardNO='" + CardNO + "' and CardType='" + CardType + "'";
        else
            strSql = "select Count(0) from TT_InitialCard where CardNO='" + CardNO + "' and CardType='" + CardType + "' and CardID<>'"+CardID+"'";
        return Exists(strSql);
    }


    /// <summary>
    /// 添加记录
    /// </summary>
    /// <param name="CardNO">用户输入的卡号</param>
    /// <param name="CardNOSelf">IC卡自带的卡号</param>
    /// <returns></returns>
    public static bool bolInsertInitialCard(string CardNO, string CardID, string CardType)
    {
        RWini ini = new RWini();
        string IntialPerson=ini.IniReadValue("UserInfo", "UserCode");
        string strSql="";
        if (isExistCardID(CardID, CardType))
            strSql = "Update TT_InitialCard set CardNO='" + CardNO + "' where CardID='" + CardID + "' and CardType='"+CardType+"'";
        else
            strSql = "Insert into TT_InitialCard(CardID,CardNO,CardType,InitialTime,IntialPerson)"
                    + "Values('" + CardID + "','" + CardNO + "','"+CardType+"',getdate(),'" + IntialPerson.Replace("'","''")+ "')";
        return ExecuteSql(strSql) > 0 ? true : false;
    }

    /// <summary>
    /// 判断用户是否登录成功
    /// </summary>
    /// <param name="UserCode">用户名</param>
    /// <param name="UserPsw">密码</param>
    /// <returns></returns>
    public static bool bolIsLogin(string UserCode, string UserPsw)
    {
        string strSql = "Select count(UserCode) from T_User where UserCode='" + UserCode.Replace("'", "''") + "' and UserPsw='" + UserPsw.Replace("'", "''") + "'";
        return Convert.ToInt32(GetSingle(strSql)) > 0 ? true : false;
    }

    public static string strGetCoalKindByCode(string CoalKindCode)
    {
        string strSql = "select CoalKindName from TT_CoalKind where CoalKindCode='" + CoalKindCode + "'";
        Object obj= GetSingle(strSql).ToString();
        if (obj == null)
            return "";
        else
            return obj.ToString();
    }
    /// <summary>
    /// 判断字符串是否是数字
    /// </summary>
    /// <param name="str">输入的字符串</param>
    /// <param name="ilen">要输入的位数</param>
    /// <returns></returns>
    public static bool bolIsNumber(string str,int ilen)
    {
        Regex reg = new Regex(@"\d{"+ilen+"}");
        if (reg.IsMatch(str))
            return true;
        else
             return false;
    }
 
    #endregion 

}
