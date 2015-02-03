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
/// ���ݷ��ʳ��������
/// </summary>
public abstract class DbHelperSQL
{
    //���ݿ������ַ���(Settings.ini������)�����Զ�̬����connectionString֧�ֶ����ݿ�.		

    //public static string connectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"]; 

    public DbHelperSQL()
    {
    }


    #region ���÷���

    public static string connectionString()
    {
        return System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
    }

    /// <summary>
    /// �ж��Ƿ����ĳ���ĳ���ֶ�
    /// </summary>
    /// <param name="tableName">������</param>
    /// <param name="columnName">������</param>
    /// <returns>�Ƿ����</returns>
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
    /// ���Ƿ����
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

    #region  ִ�м�SQL���

    /// <summary>
    /// ִ��SQL��䣬����Ӱ��ļ�¼��
    /// </summary>
    /// <param name="SQLString">SQL���</param>
    /// <returns>Ӱ��ļ�¼��</returns>
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
    /// ִ��һ�������ѯ�����䣬���ز�ѯ�����object����
    /// </summary>
    /// <param name="SQLString">�����ѯ������</param>
    /// <returns>��ѯ�����object��</returns>
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
    /// ִ�в�ѯ��䣬����DataSet
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
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
    /// ִ�в�ѯ��䣬����DataTable
    /// </summary>
    /// <param name="SQLString">��ѯ���</param>
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


    #region �û��Զ��巽��
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
    /// �ж��û�����Ŀ����Ƿ��Ѿ�����
    /// </summary>
    /// <param name="CardNO"></param>
    /// <returns></returns>
    public static bool isExistCardNO(string CardNO,string CardType)
    {
        string strSql = "select Count(0) from TT_InitialCard where CardNO='" + CardNO + "' and CardType='"+CardType+"'";
        return Exists(strSql);
    }

    /// <summary>
    /// �ж�IC���Դ��Ŀ����Ƿ��Ѿ�����
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
    /// ��Ӽ�¼
    /// </summary>
    /// <param name="CardNO">�û�����Ŀ���</param>
    /// <param name="CardNOSelf">IC���Դ��Ŀ���</param>
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
    /// �ж��û��Ƿ��¼�ɹ�
    /// </summary>
    /// <param name="UserCode">�û���</param>
    /// <param name="UserPsw">����</param>
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
    /// �ж��ַ����Ƿ�������
    /// </summary>
    /// <param name="str">������ַ���</param>
    /// <param name="ilen">Ҫ�����λ��</param>
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
