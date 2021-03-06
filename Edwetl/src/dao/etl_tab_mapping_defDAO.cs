﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edwetl.src.model;
using Edwetl.src.common;
using System.Data;
using System.Data.OracleClient;
namespace Edwetl.src.dao
{
    class etl_tab_mapping_defDAO
    {
        private etl_tab_mapping_def _etlt;
        public etl_tab_mapping_def get_etl_map_defbympping_id(string var_mapping_id)
        {
            _etlt = new etl_tab_mapping_def();
            string sql = "select * from etl_tab_mapping_def where mapping_id='" + var_mapping_id + "'" ;
            DataSet ds = getdsbysql(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count == 1)
            {
                DataRow dr= dt.Rows[0];
                _etlt.set_mapping_id(int.Parse(dr["MAPPING_ID"].ToString()));
                _etlt.set_batch_id(int.Parse(dr["BATCH_ID"].ToString()));
                _etlt.set_sys_code(dr["SYS_CODE"].ToString());
                _etlt.set_src_tab_name(dr["SRC_TAB_NAME"].ToString());
                _etlt.set_des_tab_name(dr["DES_TAB_NAME"].ToString());
                _etlt.set_conv_type(dr["CONV_TYPE"].ToString());
                _etlt.set_conv_type_desc(dr["CONV_TYPE_DESC"].ToString());
                _etlt.set_delete_sql(dr["DELETE_SQL"].ToString());
                _etlt.set_sql_str(dr["SQL_STR"].ToString());
                _etlt.set_job_name(dr["JOB_NAME"].ToString());
                _etlt.set_job_desc(dr["JOB_DESC"].ToString());
                _etlt.set_mapping_desc(dr["MAPPING_DESC"].ToString());
                _etlt.set_remark(dr["REMARK"].ToString());
                _etlt.set_st_date(dr["ST_DATE"].ToString());
                _etlt.set_mnt_date(dr["MNT_DATE"].ToString());
                _etlt.set_end_date(dr["END_DATE"].ToString());
            }
            return _etlt;
        }
        public void set_etl_tab_mapping_def(etl_tab_mapping_def etlt)
        {
            this._etlt=etlt;
        }
        public DataSet getdsbysql(string var_sql)
        {
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            DataSet ds = new DataSet();
            ds=orcl.getdsbysql(var_sql);
            orcl = null;
            db = null;
            return ds;
        }
        public void insert(etl_tab_mapping_def etlt,string str_where)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("INSERT INTO ETL_TAB_MAPPING_DEF VALUES (:MAPPING_ID,");
            sb.Append("\n");
            sb.Append(":BATCH_ID,");
            sb.Append("\n");
            sb.Append(":SYS_CODE,");
            sb.Append("\n");
            sb.Append(":SRC_TAB_NAME,");
            sb.Append("\n");
            sb.Append(":DES_TAB_NAME,");
            sb.Append("\n");
            sb.Append(":CONV_TYPE,");
            sb.Append("\n");
            sb.Append(":CONV_TYPE_DESC,");
            sb.Append("\n");
            sb.Append(":DELETE_SQL,");
            sb.Append("\n");
            sb.Append(":SQL_STR,");
            sb.Append("\n");
            sb.Append(":JOB_NAME,");
            sb.Append("\n");
            sb.Append(":JOB_DESC,");
            sb.Append("\n");
            sb.Append(":MAPPING_DESC,");
            sb.Append("\n");
            sb.Append(":REMARK,");
            sb.Append("\n");
            sb.Append("TO_DATE('"+DateTime.Now.ToString("yyyyMMdd")+"','YYYYMMDD'),");
            sb.Append("\n");
            sb.Append("TO_DATE('" + DateTime.Now.ToString("yyyyMMdd") + "','YYYYMMDD'),");
            sb.Append("\n");
            sb.Append("TO_DATE('23991231','YYYYMMDD') )"); 
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            OracleConnection cnn = orcl.getconn();
            cnn.Open();
            OracleCommand cmd = new OracleCommand(sb.ToString(),cnn);
            OracleParameter op1 = new OracleParameter("MAPPING_ID",OracleType.Int32);
            OracleParameter op2 = new OracleParameter("BATCH_ID", OracleType.Int32);
            OracleParameter op3 = new OracleParameter("SYS_CODE", OracleType.VarChar);
            OracleParameter op4 = new OracleParameter("SRC_TAB_NAME", OracleType.VarChar);
            OracleParameter op5 = new OracleParameter("DES_TAB_NAME", OracleType.VarChar);
            OracleParameter op6 = new OracleParameter("CONV_TYPE", OracleType.VarChar);
            OracleParameter op7 = new OracleParameter("CONV_TYPE_DESC", OracleType.VarChar);
            OracleParameter op8 = new OracleParameter("DELETE_SQL", OracleType.VarChar);
            OracleParameter op9 = new OracleParameter("SQL_STR", OracleType.Clob);
            OracleParameter op10 = new OracleParameter("JOB_NAME", OracleType.VarChar);
            OracleParameter op11 = new OracleParameter("JOB_DESC", OracleType.VarChar);
            OracleParameter op12 = new OracleParameter("MAPPING_DESC", OracleType.VarChar);
            OracleParameter op13 = new OracleParameter("REMARK", OracleType.VarChar);
            //OracleParameter op14 = new OracleParameter("ID_WHERE", OracleType.VarChar);
            op1.Value = etlt.get_mapping_id();
            op2.Value = etlt.get_batch_id();
            op3.Value = etlt.get_sys_code();
            op4.Value = etlt.get_src_tab_name();
            op5.Value = etlt.get_des_tab_name();
            op6.Value = etlt.get_conv_type();
            op7.Value = etlt.get_conv_type_desc();
            op8.Value = etlt.get_delete_sql();
            op9.Value = etlt.get_sql_str();
            op10.Value = etlt.get_job_name();
            op11.Value = etlt.get_job_desc();
            op12.Value = etlt.get_mapping_desc();
            op13.Value = etlt.get_remark();
            //op14.Value = str_where;
            cmd.Parameters.Add(op1);
            cmd.Parameters.Add(op2);
            cmd.Parameters.Add(op3);
            cmd.Parameters.Add(op4);
            cmd.Parameters.Add(op5);
            cmd.Parameters.Add(op6);
            cmd.Parameters.Add(op7);
            cmd.Parameters.Add(op8);
            cmd.Parameters.Add(op9);
            cmd.Parameters.Add(op10);
            cmd.Parameters.Add(op11);
            cmd.Parameters.Add(op12);
            cmd.Parameters.Add(op13);
            //cmd.Parameters.Add(op14);
            cmd.ExecuteNonQuery();
            try
            {
                cnn.Close();
                cmd = null;
                cnn = null;
                orcl = null;
                db = null;
            }
            catch { }
        }
        public void updateby_mapping_id(etl_tab_mapping_def etlt, string str_where)
        {
            StringBuilder sb = new StringBuilder("");
            sb.Append("UPDATE ETL_TAB_MAPPING_DEF SET MAPPING_ID=:MAPPING_ID,");
            sb.Append("\n");
            sb.Append("BATCH_ID=:BATCH_ID,");
            sb.Append("\n");
            sb.Append("SYS_CODE=:SYS_CODE,");
            sb.Append("\n");
            sb.Append("SRC_TAB_NAME=:SRC_TAB_NAME,");
            sb.Append("\n");
            sb.Append("DES_TAB_NAME=:DES_TAB_NAME,");
            sb.Append("\n");
            sb.Append("CONV_TYPE=:CONV_TYPE,");
            sb.Append("\n");
            sb.Append("CONV_TYPE_DESC=:CONV_TYPE_DESC,");
            sb.Append("\n");
            sb.Append("DELETE_SQL=:DELETE_SQL,");
            sb.Append("\n");
            sb.Append("SQL_STR=:SQL_STR,");
            sb.Append("\n");
            sb.Append("JOB_NAME=:JOB_NAME,");
            sb.Append("\n");
            sb.Append("JOB_DESC=:JOB_DESC,");
            sb.Append("\n");
            sb.Append("MAPPING_DESC=:MAPPING_DESC,");
            sb.Append("\n");
            sb.Append("REMARK=:REMARK ");
            sb.Append("\n");
            sb.Append("WHERE ");
            sb.Append("MAPPING_ID=:ID_WHERE");
            dbcommon db = new dbcommon();
            oporacle orcl = new oporacle(db.get_ora_str());
            OracleConnection cnn = orcl.getconn();
            cnn.Open();
            OracleCommand cmd = new OracleCommand(sb.ToString(), cnn);
            OracleParameter op1 = new OracleParameter("MAPPING_ID", OracleType.Int32);
            OracleParameter op2 = new OracleParameter("BATCH_ID", OracleType.Int32);
            OracleParameter op3 = new OracleParameter("SYS_CODE", OracleType.VarChar);
            OracleParameter op4 = new OracleParameter("SRC_TAB_NAME", OracleType.VarChar);
            OracleParameter op5 = new OracleParameter("DES_TAB_NAME", OracleType.VarChar);
            OracleParameter op6 = new OracleParameter("CONV_TYPE", OracleType.VarChar);
            OracleParameter op7 = new OracleParameter("CONV_TYPE_DESC", OracleType.VarChar);
            OracleParameter op8 = new OracleParameter("DELETE_SQL", OracleType.VarChar);
            OracleParameter op9 = new OracleParameter("SQL_STR", OracleType.Clob);
            OracleParameter op10 = new OracleParameter("JOB_NAME", OracleType.VarChar);
            OracleParameter op11 = new OracleParameter("JOB_DESC", OracleType.VarChar);
            OracleParameter op12 = new OracleParameter("MAPPING_DESC", OracleType.VarChar);
            OracleParameter op13 = new OracleParameter("REMARK", OracleType.VarChar);
            OracleParameter op14 = new OracleParameter("ID_WHERE", OracleType.VarChar);
            op1.Value = etlt.get_mapping_id();
            op2.Value = etlt.get_batch_id();
            op3.Value = etlt.get_sys_code();
            op4.Value = etlt.get_src_tab_name();
            op5.Value = etlt.get_des_tab_name();
            op6.Value = etlt.get_conv_type();
            op7.Value = etlt.get_conv_type_desc();
            op8.Value = etlt.get_delete_sql();
            op9.Value = etlt.get_sql_str();
            op10.Value = etlt.get_job_name();
            op11.Value = etlt.get_job_desc();
            op12.Value = etlt.get_mapping_desc();
            op13.Value = etlt.get_remark();
            op14.Value = str_where;
            cmd.Parameters.Add(op1);
            cmd.Parameters.Add(op2);
            cmd.Parameters.Add(op3);
            cmd.Parameters.Add(op4);
            cmd.Parameters.Add(op5);
            cmd.Parameters.Add(op6);
            cmd.Parameters.Add(op7);
            cmd.Parameters.Add(op8);
            cmd.Parameters.Add(op9);
            cmd.Parameters.Add(op10);
            cmd.Parameters.Add(op11);
            cmd.Parameters.Add(op12);
            cmd.Parameters.Add(op13);
            cmd.Parameters.Add(op14);
            cmd.ExecuteNonQuery();
            try
            {
                cnn.Close();
                cmd = null;
                cnn = null;
                orcl = null;
                db = null;
            }
            catch { }
        }
    }
}
