using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data.OleDb;
using System.Data;
using Edwetl;
using System.Collections;
namespace Edwetl.src.common
{
    class dbcommon
    {
        private string ora_str;
        public void set_ora_str(string var)
        {
            if (var.Length < 1)
            {
                this.ora_str = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=103.160.120.173)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=cmm2)));User ID=cust_dm;Password=cust_dm";
            }
            else
            {
                this.ora_str = var;
            }
        }
        public string get_ora_str()
        {
            return get_conn();
        }
        public string get_conn()
        {
            string filename=@"C:\dwetl.conf";
            filename = "dwetl.conf";
            try
            {
            StreamReader sr = new StreamReader(filename);
            string fileLine;
            fileLine = sr.ReadLine();
            
            sr = null;
            return fileLine;
            }
            catch(System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
        }
        public void isexist(string filename)
        {
            //如果不存在文件，创建文件
            //string filename = "dwetl.conf";
            if (!File.Exists(filename))
            {
                StringBuilder sb = new StringBuilder() ;
                
                sb.Append("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=103.160.120.173)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=cmm1)));User ID=cust_dm;Password=cust_dm");
                sb.Append("\n");
                sb.Append("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=103.160.120.173)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=cmm2)));User ID=cust_dm;Password=cust_dm");
                sb.Append("\n");
                sb.Append("Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=103.160.120.173)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=cmm3)));User ID=cust_dm;Password=cust_dm");
                sb.Append("\n");
                sb.Append("Data Source = 103.160.98.49;User ID = T3_CMM_ADM_DEV1;Password = pwd|cmm_data_dev1.cmm_etl_tab_mapping_def");
                sb.Append("\n");
                sb.Append("Data Source = 103.160.98.49;User ID = T3_CMM_ADM_SIT1;Password = pwd|cmm_data_sit1.cmm_etl_tab_mapping_def");
                sb.Append("\n");
                sb.Append("Data Source = 103.160.98.49;User ID = u_browser_dev1;Password = pwd|cmm_data_dev1.cmm_etl_tab_mapping_def");
                ResultHelper.WriteLog(filename, sb.ToString());
            }
        }
        public string get_conn(string lx)
        {
            string filename = @"C:\dwetl.conf";
            filename = "dwetl.conf";
            isexist(filename);
            try
            {
                StreamReader sr = new StreamReader(filename);
                string result;
                //20150831改进
                ArrayList al = new ArrayList();
                while (!sr.EndOfStream)
                {
                    al.Add(sr.ReadLine());
                }
                //string fileLine1;
                //string fileLine2;
                //string fileLine3;
                //fileLine1 = sr.ReadLine();
                //fileLine2 = sr.ReadLine();
                //fileLine3 = sr.ReadLine();
                //sr = null;
                //switch (lx){
                //    case "1":
                //    result=fileLine1;
                //    break;
                //    case "2":
                //    result = fileLine2;
                //    break;
                //    case "3":
                //    result = fileLine3;
                //    break;
                //    default:
                //    result = "";
                //    break;

                //}
                int i = int.Parse(lx) - 1;
                result = al[i].ToString();
                return result;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                throw ex;
            }
        }
        public static System.Data.DataTable GetSchemaTable(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();
                System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                //OleDbSchemaGuid.Tables, null);
                
                return schemaTable;
            }
        }
        public string formatstrconn(string strFileName)
        {
            if (strFileName != "")
            {
                excelrw(strFileName);
                string subfile = strFileName.Substring(strFileName.LastIndexOf(".") + 1);
                DataSet ds = new DataSet();
                string strCon = "";

                if (subfile.ToUpper() == "XLS")
                {

                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + strFileName;
                }

                if (subfile.ToUpper() == "XLSX")//excel2007读取
                {
                    strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                }
                return strCon;
            }
            else
            {
                return strFileName;
            }
        }
        public DataSet ImportExcel(string strFileName, string str_sheetname)         //strFileName指定的路径+文件名.xls
        {
            if (strFileName != "")
            {
                excelrw(strFileName);
                string subfile = strFileName.Substring(strFileName.LastIndexOf(".") + 1);
                DataSet ds = new DataSet();
                string strCon = "";

                if (subfile.ToUpper() == "XLS")
                {

                    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;data source=" + strFileName;
                }

                if (subfile.ToUpper() == "XLSX")//excel2007读取
                {
                    strCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                }

                //string conn = "Provider=Microsoft.Jet.OLEDB.12.0;Data Source=" + strFileName + ";Extended Properties=Excel 8.0";
                string sql = "select * from [" + str_sheetname + "$]";
                System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
                Conn.Open();

                OleDbDataAdapter da = new OleDbDataAdapter(sql, Conn);

                try
                {
                    da.Fill(ds, str_sheetname);
                    Conn.Close();
                }
                catch
                {

                }
                return ds;
            }
            else
            {
                return null;
            }
        }
        public void excelrw(string filename)
        {
            opexcel op = new opexcel(filename);
            op.opensafe2();
            
        }
        public DataTable  getdt()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add("ID");
            dt.Columns.Add("TIME");
            for (int i = 0; i < 24; i++)
            {
                for (int j = 0; j < 60; j++)
                {
                    dr = dt.NewRow();
                    dr[0] = i * 60 + j;
                    dr[1] = ""+(i < 10 ? ("0" + i) : "" + i) + ":" + (j < 10 ? ("0" + j) : "" + j) + ":00";
                    //dr[1] = "" + i + ":" + (j < 10 ? ("0" + j) : "" + j);
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }
    }
}
