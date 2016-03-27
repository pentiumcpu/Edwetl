using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OracleClient;
using System.Data;
namespace Edwetl
{
    
    class oporacle
    {

        private OracleConnection cnn;
        
        public oporacle(string str)
        {
            cnn = new OracleConnection(str);
        }
        public OracleConnection getconn()
        {
            return this.cnn;
        }
        public void insert(string str_1,string str_2)
        {
            if (str_2.Length < 10)
            {
                str_2 = "     ";
            }
            cnn.Open();
            //string cmdText = "INSERT INTO GWEXPOINTLIST(id, name, content) VALUES(1, ‘name', :clob)"; 
            string cmdText = str_1;
            OracleCommand cmd = new OracleCommand(cmdText, cnn); 
            OracleParameter op = new OracleParameter("clob", OracleType.Clob); 
            op.Value = str_2; 
            cmd.Parameters.Add(op); 
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        public DataSet getds()
        {
            DataSet ds = new DataSet();
            cnn.Open();
            string sql = "select * from CUST_DM.ETL_TAB_MAPPING_DEF";
            OracleDataAdapter odsa = new OracleDataAdapter(sql, cnn);
            odsa.Fill(ds);
            cnn.Close();
            return ds;
        }
        public DataSet getdsbysql(string sql)
        {
            DataSet ds = new DataSet();
            cnn.Open();
            //string sql = "select * from CUST_DM.ETL_TAB_MAPPING_DEF";
            OracleDataAdapter odsa = new OracleDataAdapter(sql, cnn);
            odsa.Fill(ds);
            cnn.Close();
            return ds;
        }
        public string findstr(string str_sql)
        {
            cnn.Open();
            string str = str_sql;
            //OracleCommand cmm = new OracleCommand(str, cnn);
            OracleDataAdapter odsa = new OracleDataAdapter(str, cnn);
            DataSet ds = new DataSet();
            odsa.Fill(ds);            
            string aaa = ds.Tables[0].Rows[0]["SQL_STR"].ToString();
            cnn.Close();
            return aaa;    
        }
        public int Exesql(string sql) //执行sql
        {
            cnn.Open();
            int i = 0;
            OracleCommand ocmd = new OracleCommand(sql, cnn);
            i= ocmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }
        public int Exesql(string sql,string str_clob) //执行sql
        {
            cnn.Open();
            int i = 0;
            OracleCommand cmd = new OracleCommand(sql, cnn);
            OracleParameter op = new OracleParameter("clob", OracleType.Clob);
            op.Value = str_clob;
            cmd.Parameters.Add(op);
            i = cmd.ExecuteNonQuery();
            cnn.Close();
            return i;
        }
    }
}
