using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edwetl.src.model
{
    class deal
    {
        private string _str_conn;
        private string _str_etl_date;
        private string _del_str;
        private string _sql_str;
        public deal(string s1, string s2, string s3, string s4)
        {
            this._str_conn = s1;
            this._str_etl_date = s2;
            this._del_str = s3;
            this._sql_str = s4;
        }
        public void worker()
        {
            try
            {
                oporacle db = new oporacle(this._str_conn);
                int i_del = db.Exesql(this._del_str);
                int i = db.Exesql(this._sql_str);
            }
            catch
            {
                
            }
        }
    }
}
