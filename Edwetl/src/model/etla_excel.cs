using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Edwetl.src.common;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Data;
namespace Edwetl.src.model
{
    class etla_excel
    {
        private string file_des;
        System.Data.DataTable dt;
        public etla_excel(System.Data.DataTable v_dt, string v_file_des)
        {
            dt = v_dt;
            file_des = v_file_des;
        }
        public void write_etla_excel()
        { 
            opexcel op = new opexcel(file_des);
            Workbook wb = op.open2();
            Worksheet whs_job = (Worksheet)wb.Worksheets["任务"];
            Worksheet whs_setp = (Worksheet)wb.Worksheets["任务步骤"];
            write_sheet_job(whs_job, dt);
            write_sheet_step(whs_setp, dt);
            op.save(wb, file_des);
            wb.Close();
            op.close2();
        }
        public void write_sheet_job(Worksheet whs, System.Data.DataTable dt)
        {
            int row = 1;
            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                string group_name = dt.Rows[i][1].ToString();
                string group_temp = dt.Rows[i + 1][1].ToString();
                if (group_name != group_temp)
                {
                    write_job_row(whs, dt.Rows[i],row);
                    row++;
                }
            }
            write_job_row(whs, dt.Rows[dt.Rows.Count - 1],row);
        }
        public void write_job_row(Worksheet whs, DataRow dr,int row)
        {
            string col2 = dr[1].ToString();
            string col4 = dr[0].ToString();
            string col5 = "转换任务";
            string col12 = "555";
            string col31 = "DWETL1;DWETL2";
            whs.Cells[row + 4, 2] = col2;
            whs.Cells[row + 4, 4] = col4;
            whs.Cells[row + 4, 5] = col5;
            whs.Cells[row + 4, 12] = col12;
            whs.Cells[row + 4, 31] = col31;
        }
        public void write_sheet_step(Worksheet whs, System.Data.DataTable dt)
        {
            int row = 1;
            foreach (DataRow dr in dt.Rows)
            {
                whs.Cells[row + 4, 2] = row;
                whs.Cells[row + 4, 3] = dr[0].ToString();
                whs.Cells[row + 4, 4] = dr[1].ToString();
                whs.Cells[row + 4, 5] = dr[2].ToString();
                whs.Cells[row + 4, 6] = "";
                whs.Cells[row + 4, 7] = dr[5].ToString();
                whs.Cells[row + 4, 8] = "转换任务";
                whs.Cells[row + 4, 9] = dr[0].ToString() + "/App";
                whs.Cells[row + 4, 10] = dr[2].ToString();
                whs.Cells[row + 4, 11] = "perl ${SCRIPT} ${TXDATE}";
                whs.Cells[row + 4, 12] = "PERL";
                whs.Cells[row + 4, 13] = "LOGIN_" + dr[0].ToString();
                whs.Cells[row + 4, 14] = "ASCII";
                row++;
            }
        }
    }
}
