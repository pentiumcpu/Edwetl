using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using Edwetl.src.common;
using System.Data.OracleClient;
using System.Data;
using System.Reflection;
using System.Threading;
using System.Collections;

namespace Edwetl.src.common
{
    class jgjc
    {
        private string str_excel_path;
        public jgjc(string var)
        {
            this.str_excel_path = var;
        }
        public string get()
        {
            return str_excel_path;
        }
        public void inserdb()
        {
            string var = this.str_excel_path;
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            OracleConnection conn = orcl.getconn();
            conn.Open();
            OracleCommand cmd;
            string str_insert2 = "truncate table xqwd_excel";
            OracleTransaction transaction;
            transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd = conn.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = str_insert2;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            StringBuilder sb = new StringBuilder("");
            dbcommon to2 = new dbcommon();
            //执行数据库插入
            System.Data.DataTable dt = dbcommon.GetSchemaTable(to2.formatstrconn(var));
            foreach (DataRow dr in dt.Rows)
            {
                string str_tbname = dr["TABLE_NAME"].ToString();
                if (str_tbname.Contains("字段") && !str_tbname.Contains("_"))
                {
                    exceltodbbyds(to2.ImportExcel(var, str_tbname.Replace("$","").Replace("'","")));
                }
            }
            
            //调用存储过程
            string str_procname = "PKG_JGJC.JGJC_MAIN";
            string str_in_1 = "Y";
            string str_in_2 = "Y";
            string str_in_3 = "Y";
            int int_out_1;
            string str_out_2 = "";
            cmd = new OracleCommand(str_procname, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter op1 = new OracleParameter("I_TB", OracleType.Char, 1);
            OracleParameter op2 = new OracleParameter("I_COLNAME_IS", OracleType.Char, 1);
            OracleParameter op3 = new OracleParameter("I_COLTYPE_IS", OracleType.Char, 1);
            OracleParameter op4 = new OracleParameter("O_RET_CODE", OracleType.Int32);
            OracleParameter op5 = new OracleParameter("O_RET_MSG", OracleType.VarChar, 200);
            op1.Value = str_in_1;
            op2.Value = str_in_2;
            op3.Value = str_in_3;
            op1.Direction = ParameterDirection.Input;
            op2.Direction = ParameterDirection.Input;
            op3.Direction = ParameterDirection.Input;
            op4.Direction = ParameterDirection.Output;
            op5.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(op4);
            cmd.Parameters.Add(op5);
            cmd.Parameters.Add(op1);
            cmd.Parameters.Add(op2);
            cmd.Parameters.Add(op3);
            cmd.ExecuteNonQuery();
            try
            {
                //shs = null;
                //wbk.Close();
                //wbk = null;
                ////opxls.close();
                //opxls.close2();  
                conn.Close();
            }
            catch { };
            //int_out_1 = int.Parse(op4.Value.ToString());
            //return op4.Value.ToString()+op5.Value.ToString();

        }
        public void inserdb(string var)
        {
            //string var = this.str_excel_path;
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            OracleConnection conn = orcl.getconn();
            conn.Open();
            OracleCommand cmd;
            string str_insert2 = "truncate table xqwd_excel";
            OracleTransaction transaction;
            transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd = conn.CreateCommand();
            cmd.Transaction = transaction;
            cmd.CommandText = str_insert2;
            cmd.ExecuteNonQuery();
            transaction.Commit();
            //string str_sheetname = "04接口迁移改造字段信息";
            opexcel opxls = new opexcel(var.ToString());
            _Workbook wbk = opxls.open();
            Sheets shs = wbk.Worksheets;
            //_Worksheet wsh = (_Worksheet)shs.get_Item(str_sheetname);
            StringBuilder sb = new StringBuilder("");
            td_to_orcl to2 = new td_to_orcl();
//            string str_insert = @"insert into xqwd_excel
//                                (TB_NAME,col_id,col_name,col_type) 
//                                values (:tb_name,:col_id,:col_name,:col_type)";
            //string str_insert2 = "truncate table xqwd_excel";
            //cmd = new OracleCommand(str_insert2, conn);
            //cmd.ExecuteNonQuery();
            //执行数据库插入
            foreach (Worksheet wsh in shs)
            {
                if (wsh.Name.Contains("字段") && !wsh.Name.Contains("_"))
                {
                    //jgjc jc2 = new jgjc();
                    //t = new Thread(jc2.exceltodb);
                    //t.Start(wsh, conn, cmd);
                    //exceltodb(wsh);
                    exceltodbbyds(to2.ImportExcel(var, wsh.Name));
                }
            }
                      
            //调用存储过程
            string str_procname = "PKG_JGJC.JGJC_MAIN";
            string str_in_1 = "Y";
            string str_in_2 = "Y";
            string str_in_3 = "Y";
            int int_out_1;
            string str_out_2 = "";
            cmd = new OracleCommand(str_procname, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleParameter op1 = new OracleParameter("I_TB", OracleType.Char, 1);
            OracleParameter op2 = new OracleParameter("I_COLNAME_IS", OracleType.Char, 1);
            OracleParameter op3 = new OracleParameter("I_COLTYPE_IS", OracleType.Char, 1);
            OracleParameter op4 = new OracleParameter("O_RET_CODE", OracleType.Int32);
            OracleParameter op5 = new OracleParameter("O_RET_MSG", OracleType.VarChar, 200);
            op1.Value = str_in_1;
            op2.Value = str_in_2;
            op3.Value = str_in_3;
            op1.Direction = ParameterDirection.Input;
            op2.Direction = ParameterDirection.Input;
            op3.Direction = ParameterDirection.Input;
            op4.Direction = ParameterDirection.Output;
            op5.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(op4);
            cmd.Parameters.Add(op5);
            cmd.Parameters.Add(op1);
            cmd.Parameters.Add(op2);
            cmd.Parameters.Add(op3);
            cmd.ExecuteNonQuery();
            try
            {
                shs = null;
                wbk.Close();
                wbk = null;
                opxls.close(); 
                //opxls.close2();  
                conn.Close();
            }
            catch { };
            //int_out_1 = int.Parse(op4.Value.ToString());
            //return op4.Value.ToString()+op5.Value.ToString();
            
        }
        public void exceltodb(Worksheet wsh)
        {
            string tb_name = "";
            int col_id = 0;
            string col_name = "";
            string col_type = "";
            Range rg_tb_name;
            Range rg_col_id;
            Range rg_col_name;
            Range rg_col_type;
            string str_insert2 = "truncate table xqwd_excel";
            ArrayList al = new ArrayList();
            for (int i = 2; i <= wsh.Rows.Count; i++)
            {
                //tb_name = (string)(wsh.Cells[i, 10]);
                rg_tb_name = (Range)(wsh.Cells[i, 10]);
                tb_name = (rg_tb_name.Value == null )? "" : rg_tb_name.Text.ToString();
                if (tb_name.Trim().Length < 1)
                {
                    break;
                }
                else
                {
                    //col_id = int.Parse((string)(wsh.Cells[i, 11]));
                    //col_name = (string)(wsh.Cells[i, 12]);
                    //col_type = (string)(wsh.Cells[i, 13]);
                    rg_col_id = (Range)(wsh.Cells[i, 11]);
                    
                    rg_col_name = (Range)(wsh.Cells[i, 12]);
                    rg_col_type = (Range)(wsh.Cells[i, 13]);
                    col_id = (rg_col_id == null) ? 0 : int.Parse(rg_col_id.Text.ToString());
                    col_name = (rg_col_name == null) ? "" : rg_col_name.Text.ToString();
                    col_type = (rg_col_type == null) ? "" : rg_col_type.Text.ToString();
                    tb_name = tb_name.Replace("'", "").Trim().ToUpper();
                    col_name = col_name.Replace("'", "").Trim().ToUpper();
                    col_type = col_type.Replace("'", "").Trim().ToUpper().Replace("VARCHAR(", "VARCHAR2(");
                    col_type = col_type.Replace("INTEGER", "NUMBER");
                    col_type = col_type.Replace("DECIMAL", "NUMBER");
                    col_type = col_type.Replace(",0)", ")");
                    str_insert2 = @"insert into xqwd_excel
                                (TB_NAME,col_id,col_name,col_type) 
                                values ('";
                    str_insert2 = str_insert2 + tb_name + "','";
                    str_insert2 = str_insert2 + col_id + "','";
                    str_insert2 = str_insert2 + col_name + "','";
                    str_insert2 = str_insert2 + col_type + "')";
                    al.Add(str_insert2);
                    
                    //cmd = new OracleCommand(str_insert, conn);
                    //op = new OracleParameter("tb_name", OracleType.Clob);
                    //op.Value = tb_name;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_id", OracleType.VarChar);
                    //op.Value = col_id;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_name", OracleType.Number);
                    //op.Value = col_name;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_type", OracleType.VarChar);
                    //op.Value = col_type;
                    //cmd.Parameters.Add(op);
                    //cmd.ExecuteNonQuery();
                }
                //
            }
            insertoracle(al);
            al = null;
           
        }
        public void exceltodbbyds(DataSet ds)
        {
            System.Data.DataTable dt = ds.Tables[0];
            
            string tb_name = "";
            int col_id = 0;
            string col_name = "";
            string col_type = "";
            string rg_tb_name;
            string rg_col_id;
            string rg_col_name;
            string rg_col_type;
            string str_insert2 = "truncate table xqwd_excel";
            ArrayList al = new ArrayList();
            foreach(System.Data.DataRow dr in dt.Rows)
            {
            
                //tb_name = (string)(wsh.Cells[i, 10]);
                rg_tb_name = dr[9].ToString();
                tb_name = (rg_tb_name == null) ? "" : rg_tb_name;
                if (tb_name.Trim().Length < 1)
                {
                    break;
                }
                else
                {
                    //col_id = int.Parse((string)(wsh.Cells[i, 11]));
                    //col_name = (string)(wsh.Cells[i, 12]);
                    //col_type = (string)(wsh.Cells[i, 13]);
                    rg_col_id = dr[10].ToString();
                    rg_col_name = dr[11].ToString();
                    rg_col_type = dr[12].ToString();
                    col_id = (rg_col_id == null) ? 0 : int.Parse(rg_col_id);
                    col_name = (rg_col_name == null) ? "" : rg_col_name;
                    col_type = (rg_col_type == null) ? "" : rg_col_type;
                    tb_name = tb_name.Replace("'", "").Trim().ToUpper();
                    col_name = col_name.Replace("'", "").Trim().ToUpper();
                    col_type = col_type.Replace("'", "").Trim().ToUpper().Replace("VARCHAR(", "VARCHAR2(");
                    col_type = col_type.Replace("INTEGER", "NUMBER");
                    col_type = col_type.Replace("DECIMAL", "NUMBER");
                    col_type = col_type.Replace(",0)", ")");
                    str_insert2 = @"insert into xqwd_excel
                                (TB_NAME,col_id,col_name,col_type) 
                                values ('";
                    str_insert2 = str_insert2 + tb_name + "','";
                    str_insert2 = str_insert2 + col_id + "','";
                    str_insert2 = str_insert2 + col_name + "','";
                    str_insert2 = str_insert2 + col_type + "')";
                    al.Add(str_insert2);

                    //cmd = new OracleCommand(str_insert, conn);
                    //op = new OracleParameter("tb_name", OracleType.Clob);
                    //op.Value = tb_name;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_id", OracleType.VarChar);
                    //op.Value = col_id;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_name", OracleType.Number);
                    //op.Value = col_name;
                    //cmd.Parameters.Add(op);
                    //op = new OracleParameter("col_type", OracleType.VarChar);
                    //op.Value = col_type;
                    //cmd.Parameters.Add(op);
                    //cmd.ExecuteNonQuery();
                }
                //
            }
            insertoracle(al);
            al = null;

        }
        public void insertoracle(ArrayList al)
        {
            string str_insert2 = "";
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            OracleConnection conn = orcl.getconn();
            conn.Open();
            OracleCommand cmd;
            OracleParameter op;
            OracleTransaction transaction;
            transaction = conn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd = conn.CreateCommand();
            cmd.Transaction = transaction;
            for (int i=0 ;i<al.Count;i++)
            {
                str_insert2=al[i].ToString();
                cmd.CommandText = str_insert2;
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            
            try
            {
                conn.Close();
                
            }
            catch { };
            //int_out_1 = int.Parse(op4.Value.ToString());
            //return op4.Value.ToString()+op5.Value.ToString();
        }
        public DataSet view(string etl_date)
        {
            string sql = "select * from temp_" + etl_date + "_02";
            DataSet ds;
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            ds = orcl.getdsbysql(sql);
            return ds;
        }
    }
}
