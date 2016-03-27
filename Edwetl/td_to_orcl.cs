using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OracleClient;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Data.OleDb;
namespace Edwetl
{
    class td_to_orcl
    {
        public StringBuilder f_gen_sql(string str_xls, string tname_td, string tname)
        {
            opexcel opxls = new opexcel(str_xls);
            _Workbook wbk = opxls.open();
            StringBuilder sb = new StringBuilder("select top 500 ");
            //sb.Append("* from STG_DATA_DEV1." + tname_td);
            //return sb;
            string sheetname = "04特殊数据输入接口字段信息";
            Sheets shs = wbk.Sheets;
            _Worksheet wsh = (_Worksheet)shs.get_Item(sheetname);
            int ccount = 0;
            for (int i = 2; i < 21041; i++)
            {
                //sheetname = "特殊数据输入接口字段信息";
                if (tname.Equals(find_str(wsh, i, 10)) && tname.Equals(find_str(wsh, i + 1, 10)))
                {
                    sb = sb.Append(find_str(wsh, i, 6));
                    sb.Append(" ");
                    sb = sb.Append(find_str(wsh, i, 12));
                    sb.Append(",\n\t");
                    ccount++;
                }
                else if (tname.Equals(find_str(wsh, i, 10)) && !tname.Equals(find_str(wsh, i + 1, 10)))
                {
                    sb = sb.Append(find_str(wsh, i, 6));
                    sb.Append(" ");
                    sb = sb.Append(find_str(wsh, i, 12));
                    ccount++;
                    break;
                }

            }
            if (ccount > 0)
            {
                sb.Append(" from STG_DATA_DEV1." + tname_td);
            }
            else
            {
                sb.Append("* from STG_DATA_DEV1." + tname_td);
            }
            return sb;
        }
        public string find_str(_Worksheet wsh, int r, int c)
        {

            return (string)(wsh.Cells[r, c].ToString());
        }
        public string find_str(_Workbook wbk, string str_sheetname, int r, int c)
        {

            Sheets shs = wbk.Sheets;
            _Worksheet wsh = (_Worksheet)shs.get_Item(str_sheetname);
            return (string)(wsh.Cells[r, c].ToString());
        }
        public DataSet f_get_ds(string td_conn_str, string sql)
        {
            teradata td = new teradata(td_conn_str);
            DataSet ds = td.getdsbysql(sql);
            return ds;
        }
        public int f_to_orcl(string or_conn_str, string tname_c1, DataSet ds)
        {
            int rst = 0;
            //oporacle dbo = new oporacle(or_conn_str);
            OracleConnection myConn = new OracleConnection(or_conn_str);
            string sql = getsqlbyds(ds, tname_c1).ToString();
            OracleDataAdapter myDataAdapter = new OracleDataAdapter();
            myDataAdapter.SelectCommand = new OracleCommand(sql, myConn);
            OracleCommandBuilder cb = new OracleCommandBuilder(myDataAdapter);
            myConn.Open();
            DataSet dsn = new DataSet();
            myDataAdapter.Fill(dsn);
            int max = ds.Tables[0].Columns.Count;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                DataRow drn = dsn.Tables[0].NewRow();
                //dsn.Tables[0].ImportRow(dr);
                for (int i = 0; i < max; i++)
                {
                    drn[i] = dr[i];
                }
                //drn[0] = "12002";
                dsn.Tables[0].Rows.Add(drn);
                //dsn.Tables[tname_c1].Rows.Add(dr);
            }
            //DataRow drn = dsn.Tables[tname_c1].NewRow();
            //drn[0] = "1111";
            //drn[1] = "aaa";
            //dsn.Tables[0].Rows.Add(drn);
            rst = myDataAdapter.Update(dsn.Tables[0]);
            
            myConn.Close();
            return rst;
        }
        public StringBuilder getsqlbyds(DataSet ds, string tname)
        {
            StringBuilder sb = new StringBuilder("select  ");

            //sb.Append("(");
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                sb.Append(dc.Caption.ToString());
                sb.Append(",\n");
            }
            sb = sb.Remove(sb.Length - 2, 2);
            sb.Append(" from ");
            sb.Append(tname);
            return sb;
        }

        public StringBuilder f_gen_sql_c1(string str_xls, string tname)
        {
            opexcel opxls = new opexcel(str_xls);
            _Workbook wbk = opxls.open();
            StringBuilder sb = new StringBuilder("select  ");
            //sb.Append("* from STG_DATA_DEV1." + tname_td);
            //return sb;
            string sheetname = "04特殊数据输入接口字段信息";
            Sheets shs = wbk.Sheets;
            _Worksheet wsh = (_Worksheet)shs.get_Item(sheetname);
            int ccount = 0;
            for (int i = 2; i < 21050; i++)
            {
                //sheetname = "特殊数据输入接口字段信息";
                if (tname.Equals(find_str(wsh, i, 10)) && tname.Equals(find_str(wsh, i + 1, 10)))
                {
                    //sb = sb.Append(find_str(wsh, i, 6));
                    //sb.Append(" ");
                    sb = sb.Append(find_str(wsh, i, 12));
                    sb.Append(",\n\t");
                    ccount++;
                }
                else if (tname.Equals(find_str(wsh, i, 10)) && !tname.Equals(find_str(wsh, i + 1, 10)))
                {
                    //sb = sb.Append(find_str(wsh, i, 6));
                    //sb.Append(" ");
                    sb = sb.Append(find_str(wsh, i, 12));
                    ccount++;
                    break;
                }

            }
            if (ccount > 0)
            {
                sb.Append(" from " + tname);
            }
            else
            {
                sb.Append("* from " + tname);
            }
            return sb;
        }
        public System.Data.DataTable getdtbyexcel(string str_filename)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            
            opexcel opxls = new opexcel(str_filename);
            _Workbook wbk = opxls.open();
            Sheets shs = wbk.Sheets;
            _Worksheet ws = (_Worksheet)shs.get_Item(1);
            //int rowNum = ws.UsedRange.Cells.Rows.Count;
            //int colNum = ws.UsedRange.Cells.Columns.Count;
            //Range range=ws.get_Range(ws.Cells[2,1],ws.Cells[10,2]);
            string cellContent;
            int iRowCount = ws.UsedRange.Rows.Count;
            int iColCount = 2;
            //iRowCount = 500;
            Range range;
            for (int iRow = 1; iRow <= iRowCount; iRow++)
            {
                DataRow dr = dt.NewRow();

                for (int iCol = 1; iCol <= iColCount; iCol++)
                {
                    range = (Range)ws.Cells[iRow, iCol];

                    cellContent = (range.Value2 == null) ? "" : range.Value2.ToString();

                    if (iRow == 1)
                    {
                        dt.Columns.Add(cellContent);
                    }
                    else
                    {
                        dr[iCol - 1] = cellContent;
                    }
                    
                    
                }
                if (iRow != 1)
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public System.Data.DataTable getdtbyexceljkxq(string str_filename)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            opexcel opxls = new opexcel(str_filename);
            _Workbook wbk = opxls.open();
            Sheets shs = wbk.Sheets;
            _Worksheet ws = (_Worksheet)shs.get_Item("04特殊数据输入接口字段信息");
            //int rowNum = ws.UsedRange.Cells.Rows.Count;
            //int colNum = ws.UsedRange.Cells.Columns.Count;
            //Range range=ws.get_Range(ws.Cells[2,1],ws.Cells[10,2]);
            string cellContent;
            int iRowCount = ws.UsedRange.Rows.Count;
            iRowCount = 21050;
            Range range;
            for (int iRow = 1; iRow <= iRowCount; iRow++)
            {
                DataRow dr = dt.NewRow();
                if (iRow == 1)
                {
                    dt.Columns.Add("TNAME");
                    dt.Columns.Add("TDCNAME");
                    dt.Columns.Add("C1CNAME");
                }
                else
                {
                    range = (Range)ws.Cells[iRow, 10];
                    cellContent = (range.Value2 == null) ? "" : range.Value2.ToString();
                    dr[0] = cellContent;
                    range = (Range)ws.Cells[iRow, 6];
                    cellContent = (range.Value2 == null) ? "" : range.Value2.ToString();
                    dr[1] = cellContent;
                    range = (Range)ws.Cells[iRow, 12];
                    cellContent = (range.Value2 == null) ? "" : range.Value2.ToString();
                    dr[2] = cellContent;
                }
                if (iRow != 1)
                    dt.Rows.Add(dr);
            }
            return dt;
        }

        public StringBuilder f_gen_sql_td(System.Data.DataTable dt, string tname_td, string tname,string schema)
        {
            StringBuilder sb = new StringBuilder("select top 200 ");
            DataRow[] drs = dt.Select("TNAME='"+tname+"'");
            foreach (DataRow dr in drs)
            {
                //sheetname = "特殊数据输入接口字段信息";
                    sb = sb.Append(dr[1]);
                    sb.Append(" ");
                    sb.Append("\"");
                    sb = sb.Append(dr[2]);
                    sb.Append("\"");
                    sb.Append(",\n\t");

            }
            sb=sb.Remove(sb.Length-3,3);
            if (drs.Length > 0)
            {
                sb.Append(" from " + schema + "." + tname_td);
            }
            else
            {
                sb.Append("* from " + schema + "." + tname_td);
            }
            return sb;
        }
        public StringBuilder f_gen_sql_oracle(System.Data.DataTable dt,string tname)
        {
            StringBuilder sb = new StringBuilder("select top 500 ");
            DataRow[] drs = dt.Select("TNAME='" + tname + "'");
            foreach (DataRow dr in drs)
            {
                sb = sb.Append(dr[2]);
                sb.Append(",\n\t");

            }
            sb = sb.Remove(sb.Length - 3, 3);
            if (drs.Length > 0)
            {
                sb.Append(" from " + tname);
            }
            else
            {
                sb.Append("* from " + tname);
            }
            return sb;
        }
        public static System.Data.DataTable GetSchemaTable(string connectionString)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(connectionString))
            {
                connection.Open();
                System.Data.DataTable schemaTable = connection.GetOleDbSchemaTable(
                    OleDbSchemaGuid.Tables,
                    new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }
        public string formatstrconn(string strFileName)
        {
            if (strFileName != "")
            {
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
        public DataSet ImportExcel(string strFileName,string str_sheetname)         //strFileName指定的路径+文件名.xls
        {
            if (strFileName != "")
            {
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
    }
}