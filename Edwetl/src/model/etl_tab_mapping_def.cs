using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Edwetl.src.model
{
    class etl_tab_mapping_def
    {
        private int _mapping_id;
        private int _batch_id;
        private string _sys_code;
        private string _src_tab_name;
        private string _des_tab_name;
        private string _conv_type;
        private string _conv_type_desc;
        private string _delete_sql;
        private string _sql_str;
        private string _job_name;
        private string _job_desc;
        private string _mapping_desc;
        private string _remark;
        private string _st_date;
        private string _mnt_date;
        private string _end_date;
        public void set_mapping_id(int _mapping_id)
        {
            this._mapping_id = _mapping_id;
        }
        public void set_batch_id(int _batch_id)
        {
            this._batch_id = _batch_id;
        }
        public void set_sys_code(string _sys_code)
        {
            this._sys_code = _sys_code;
        }
        public void set_src_tab_name(string _src_tab_name)
        {
            this._src_tab_name = _src_tab_name;
        }
        public void set_des_tab_name(string _des_tab_name)
        {
            this._des_tab_name = _des_tab_name;
        }
        public void set_conv_type(string _conv_type)
        {
            this._conv_type = _conv_type;
        }
        public void set_conv_type_desc(string _conv_type_desc)
        {
            this._conv_type_desc = _conv_type_desc;
        }
        public void set_delete_sql(string _delete_sql)
        {
            this._delete_sql = _delete_sql;
        }
        public void set_sql_str(string _sql_str)
        {
            this._sql_str = _sql_str;
        }
        public void set_job_name(string _job_name)
        {
            this._job_name = _job_name;
        }
        public void set_job_desc(string _job_desc)
        {
            this._job_desc = _job_desc;
        }
        public void set_mapping_desc(string _mapping_desc)
        {
            this._mapping_desc = _mapping_desc;
        }
        public void set_remark(string _remark)
        {
            this._remark = _remark;
        }
        public void set_st_date(string _st_date)
        {
            this._st_date = _st_date;
        }
        public void set_mnt_date(string _mnt_date)
        {
            this._mnt_date = _mnt_date;
        }
        public void set_end_date(string _end_date)
        {
            this._end_date = _end_date;
        }
        public int get_mapping_id()
        {
            return this._mapping_id;
        }
        public int get_batch_id()
        {
            return this._batch_id;
        }
        public string get_sys_code()
        {
            return this._sys_code;
        }
        public string get_src_tab_name()
        {
            return this._src_tab_name;
        }
        public string get_des_tab_name()
        {
            return this._des_tab_name;
        }
        public string get_conv_type()
        {
            return this._conv_type;
        }
        public string get_conv_type_desc()
        {
            return this._conv_type_desc;
        }
        public string get_delete_sql()
        {
            return this._delete_sql;
        }
        public string get_sql_str()
        {
            return this._sql_str;
        }
        public string get_job_name()
        {
            return this._job_name;
        }
        public string get_job_desc()
        {
            return this._job_desc;
        }
        public string get_mapping_desc()
        {
            return this._mapping_desc;
        }
        public string get_remark()
        {
            return this._remark;
        }
        public string get_st_date()
        {
            return this._st_date;
        }
        public string get_mnt_date()
        {
            return this._mnt_date;
        }
        public string get_end_date()
        {
            return this._end_date;
        }
    }
}
