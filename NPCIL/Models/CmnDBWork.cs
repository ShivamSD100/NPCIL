
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web;

public class CmnDBWork
{
    public static string strConnString = "server= 173.249.52.210,7160\\SQLEXPRESS; pwd=Jabit_7160;uid=sa;database=NPCIL_DB; pooling=true; Max Pool Size=1000000";
    SqlConnection ConStr = new SqlConnection(strConnString);
    SqlCommand cmd = new SqlCommand();
    SqlDataAdapter da;
    DataTable dt = new DataTable();
    DataSet ds = new DataSet();
    SqlDataReader dr;

    public void CreateConn()
    {
        try
        {
            if (ConStr.State == 0)
            {
                ConStr.ConnectionString = strConnString;
                ConStr.Open();
            }
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }
    public void CloseConn()
    {
        try
        {
            if (ConStr.State != 0)
                ConStr.Close();
        }
        catch (Exception exp)
        {
            throw exp;
        }
    }

    public DataTable GetDatatable(string Qstr)
    {
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = Qstr;
        cmd.Connection = ConStr;
        cmd.CommandTimeout = 60000;
        DataTable dt = new DataTable();
        try
        {
            CreateConn();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConn();
        }
        return dt;
    }

    public DataSet GetDataSet(string Qstr)
    {
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = Qstr;
        cmd.Connection = ConStr;
        // cmd.CommandTimeout = "60000"
        DataSet ds = new DataSet();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        try
        {
            CreateConn();
            sda.Fill(ds);
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConn();
        }
        return ds;
    }

    public string GetScalerValue(string Qstr)
    {
        string str = "";
        cmd.Parameters.Clear();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = Qstr;
        cmd.Connection = ConStr;
        // cmd.CommandTimeout = "60000"
        DataTable dt = new DataTable();
        try
        {
            CreateConn();
            str = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConn();
        }
        return str;
    }

    public string AddDelMod(string Qstr)
    {
        string ret = "0";
        cmd.Parameters.Clear();
        cmd.CommandText = Qstr;
        cmd.Connection = ConStr;
        DataTable dt = new DataTable();
        try
        {
            CreateConn();
            ret = cmd.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
        }
        finally
        {
            CloseConn();
        }
        return ret;
    }



}
