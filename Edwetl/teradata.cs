using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Teradata.Client.Provider;
using System.Data;
namespace Edwetl
{
    class teradata
    {
        
        TdConnection cn =null;
        public  teradata(string str_cnn)
        {
            cn = new TdConnection(str_cnn);
        }
        public TdConnection getconn()
        {
            return this.cn;
        }
        public void open()
        {
            cn.Open();
        }
        public void close()
        {
            cn.Close();
        }
        public DataSet getdsbysql(string sql)
        {
            cn.Open();
            DataSet ds = new DataSet();
            try
            {
                TdDataAdapter tdda = new TdDataAdapter(sql, cn);
                cn.Close();
                tdda.Fill(ds);
                cn.Close();
            }
            catch { }
            return ds;
        }
        public int exesql(string sql)
        {
            cn.Open();
            int i = 0;
            TdCommand tdc = new TdCommand(sql, cn);
            i = tdc.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public int Exesql(string sql)
        {
            cn.Open();
            int i = 0;
            TdCommand tdc = new TdCommand(sql, cn);
            i = tdc.ExecuteNonQuery();
            cn.Close();
            return i;
        }
        public int Exesql(string sql,string str_clob)
        {
            cn.Open();
            int i = 0;
            TdCommand tdc = new TdCommand(sql, cn);
            TdParameter op = new TdParameter("sql_str", TdType.VarChar);
            op.Value = str_clob;
            tdc.Parameters.Add(op);
            i = tdc.ExecuteNonQuery();
            cn.Close();
            return i;
        }
    }
}
