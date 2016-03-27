using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Edwetl.src.common;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Data;
namespace Edwetl.src.model
{
    class zysj_excel
    {
        private string file_des;
        private string file_src;
        public zysj_excel(string v_file_src,string v_file_des)
        {
            file_src = v_file_src;
            file_des = v_file_des;
        }
        public void write_zysj_excel()
        {
            dbcommon db = new dbcommon();
            string sheet_name = "Sheet1";
            System.Data.DataTable dt = db.ImportExcel(file_src, sheet_name).Tables[0];
            opexcel op = new opexcel(file_des);
            Workbook wb = op.open2();
            Worksheet whs_etl = (Worksheet)wb.Worksheets["ETL调度"];
            Worksheet whs_def = (Worksheet)wb.Worksheets["表级映射定义表初始化"];
            write_sheet_etl(whs_etl, dt);
            write_sheet_def(whs_def, dt);
            op.save(wb,file_des);
            wb.Close();
            op.close2();
        }
        public void write_sheet_etl(Worksheet whs, System.Data.DataTable dt)
        {
            string IS_DEAL;
            int row = 0;
            foreach (DataRow dr in dt.Rows)
            {
                IS_DEAL = dr[5].ToString();
                if (IS_DEAL.ToUpper().Contains("Y") || IS_DEAL.ToUpper().Contains("是"))
                {
                    write_row1(whs, dr, row);
                    write_row2(whs, dr, row);
                    write_row3(whs, dr, row);
                    row++;
                }
            }
        }
        public void write_row1(Worksheet whs, DataRow dr,int row)
        {
            int cur_row = row * 3 + 2;
            string GROUP_NAME, BATCH_ID, SRC_TAB, DES_TAB, DATABASE;
            GROUP_NAME = dr[0].ToString();
            BATCH_ID = dr[1].ToString();
            SRC_TAB = dr[2].ToString();
            DES_TAB = dr[3].ToString();
            DES_TAB = DES_TAB.Substring(DES_TAB.IndexOf(".")+1);//从"."位置以后开始截取
            DATABASE = dr[4].ToString();
            //string JXJC = "";
            string JXtemp = GROUP_NAME.Substring(0, 1).ToUpper();
            //JXJC = JXtemp != "R" && JXtemp != "K" ? "C" : JXtemp;
            string col1 = GROUP_NAME;
            string col2 = GROUP_NAME +"_JG_" + DES_TAB;
            string col3 = GROUP_NAME + "_J_" + DES_TAB + "_BEGIN.pl";
            string col6 = "1-预处理作业";
            string col7 = "";
            if (DATABASE == "Oracle")
            {
                col7 = "cmm_ETL_begin_templet.pl";
            }
            else if (DATABASE == "Teradata")
            {
                col7 = "cmm_ETL_begin_templet_TD.pl";
            }
            
            whs.Cells[cur_row, 1] = col1;
            whs.Cells[cur_row, 2] = col2;
            whs.Cells[cur_row, 3] = col3;
            whs.Cells[cur_row, 6] = col6;
            whs.Cells[cur_row, 7] = col7;
        }
        public void write_row2(Worksheet whs, DataRow dr, int row)
        {
            int cur_row = row * 3 + 3;
            string GROUP_NAME, BATCH_ID, SRC_TAB, DES_TAB, DATABASE;
            GROUP_NAME = dr[0].ToString();
            BATCH_ID = dr[1].ToString();
            SRC_TAB = dr[2].ToString();
            DES_TAB = dr[3].ToString();
            DES_TAB = DES_TAB.Substring(DES_TAB.IndexOf(".")+1);//从"."位置以后开始截取
            DATABASE = dr[4].ToString();
            string col1 = GROUP_NAME;
            string col2 = GROUP_NAME + "_JG_" + DES_TAB;
            string col3 = GROUP_NAME + "_J_" + DES_TAB + "_" + BATCH_ID + ".pl";
            string col4 = BATCH_ID;
            string col5 = "";
            string col6 = "2-数据处理作业";
            string col7 = "";
            if (DATABASE == "Oracle")
            {
                col5 = "PKG_CMM.C_ETL_DATA_BY_MAPPING";
                col7 = "cmm_ETL_call_templet.pl";
            }
            else if (DATABASE == "Teradata")
            {
                col5 = "BTEQ";
                col7 = "cmm_ETL_call_templet_TD.pl";
            }
            whs.Cells[cur_row, 1] = col1;
            whs.Cells[cur_row, 2] = col2;
            whs.Cells[cur_row, 3] = col3;
            whs.Cells[cur_row, 4] = col4;
            whs.Cells[cur_row, 5] = col5;
            whs.Cells[cur_row, 6] = col6;
            whs.Cells[cur_row, 7] = col7;
        }
        public void write_row3(Worksheet whs, DataRow dr, int row)
        {
            int cur_row = row * 3 + 4;
            string GROUP_NAME, BATCH_ID, SRC_TAB, DES_TAB, DATABASE;
            GROUP_NAME = dr[0].ToString();
            BATCH_ID = dr[1].ToString();
            SRC_TAB = dr[2].ToString();
            DES_TAB = dr[3].ToString();
            DES_TAB = DES_TAB.Substring(DES_TAB.IndexOf(".")+1);//从"."位置以后开始截取
            DATABASE = dr[4].ToString();
            string col1 = GROUP_NAME;
            string col2 = GROUP_NAME + "_JG_" + DES_TAB;
            string col3 = GROUP_NAME + "_J_" + DES_TAB + "_END.pl";
            string col6 = "9-后处理作业";
            string col7 = "";
            if (DATABASE == "Oracle")
            {
                col7 = "cmm_ETL_end_templet.pl";
            }
            else if (DATABASE == "Teradata")
            {
                col7 = "cmm_ETL_end_templet_TD.pl";
            }
            whs.Cells[cur_row, 1] = col1;
            whs.Cells[cur_row, 2] = col2;
            whs.Cells[cur_row, 3] = col3;
            whs.Cells[cur_row, 6] = col6;
            whs.Cells[cur_row, 7] = col7;
        }
        public void write_sheet_def(Worksheet whs, System.Data.DataTable dt)
        {
            int cur_row = 3;
            string IS_DEAL;
            string GROUP_NAME, BATCH_ID, SRC_TAB, DES_TAB, DATABASE;
            foreach (DataRow dr in dt.Rows)
            {
                IS_DEAL = dr[5].ToString();
                if (IS_DEAL.ToUpper().Contains("Y") || IS_DEAL.ToUpper().Contains("是"))
                {
                    GROUP_NAME = dr[0].ToString();
                    BATCH_ID = dr[1].ToString();
                    SRC_TAB = dr[2].ToString();
                    DES_TAB = dr[3].ToString();
                    DATABASE = dr[4].ToString();
                    string MAPPING_ID = BATCH_ID + "01";
                    string SYS_CODE = "CMM";
                    string SRC_TAB_NAME = SRC_TAB;
                    string DES_TAB_NAME = DES_TAB;
                    string CONV_TYPE = "10031";
                    string CONV_TYPE_DESC = "10031-指定SQL增量追加";
                    string DELETE_SQL = "";
                    string SQL_STR = "";
                    string JOB_NAME = "PKG_CMM.J_ETL_DATA_BY_SQL_APPEND";
                    string JOB_DESC = "公共映射抽取作业-指定SQL增量追加";
                    string MAPPING_DESC = SRC_TAB;
                    string REMARK = "";
                    string ST_DATE = "1700-01-01";
                    string MNT_DATE = DateTime.Now.ToString("yyyy-MM-dd");// "2014-09-30";
                    string END_DATE = "2399-12-31";
                    whs.Cells[cur_row, 5] = MAPPING_ID;
                    whs.Cells[cur_row, 6] = BATCH_ID;
                    whs.Cells[cur_row, 7] = SYS_CODE;
                    whs.Cells[cur_row, 8] = SRC_TAB_NAME;
                    whs.Cells[cur_row, 9] = DES_TAB_NAME;
                    whs.Cells[cur_row, 10] = CONV_TYPE;
                    whs.Cells[cur_row, 11] = CONV_TYPE_DESC;
                    whs.Cells[cur_row, 12] = DELETE_SQL;
                    whs.Cells[cur_row, 13] = SQL_STR;
                    whs.Cells[cur_row, 14] = "";
                    whs.Cells[cur_row, 15] = JOB_NAME;
                    whs.Cells[cur_row, 16] = JOB_DESC;
                    whs.Cells[cur_row, 17] = MAPPING_DESC;
                    whs.Cells[cur_row, 18] = REMARK;
                    whs.Cells[cur_row, 19] = ST_DATE;
                    whs.Cells[cur_row, 20] = MNT_DATE;
                    whs.Cells[cur_row, 21] = END_DATE;
                    cur_row++;
                }
            }
        }
    }
}
