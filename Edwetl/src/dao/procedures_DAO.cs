using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edwetl.src.model;
using Edwetl.src.common;
using System.Data;
using System.Data.OracleClient;
namespace Edwetl.src.dao
{
    class procedures_DAO
    {
        string _lx;
        public procedures_DAO(string var_lx)
        {
            this._lx = var_lx;
        }
        public DataSet getdsbysql(string var_sql)
        {
            dbcommon db = new dbcommon();
            string temp = db.get_conn(_lx);
            string[] results = temp.Split('|');
            oporacle orcl = new oporacle(results[0].ToString());
            DataSet ds = new DataSet();
            ds = orcl.getdsbysql(var_sql);
            orcl = null;
            db = null;
            return ds;
        }
        public DataSet getdsbysql()
        {
            string var_sql = "select object_name,procedure_name from user_procedures where object_name <>'FUNCTION' order by procedure_name";
            dbcommon db = new dbcommon();
            string temp = db.get_conn(_lx);
            string[] results = temp.Split('|');
            oporacle orcl = new oporacle(results[0].ToString());
            DataSet ds = new DataSet();
            ds = orcl.getdsbysql(var_sql);
            orcl = null;
            db = null;
            return ds;
        }
    }
}
