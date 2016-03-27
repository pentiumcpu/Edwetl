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
    class sxt_excel
    {
        private string file_des;
        private string file_src;
        public sxt_excel(string v_file_src, string v_file_des)
        {
            file_src = v_file_src;
            file_des = v_file_des;
        }
        public void write_sxt_excel()
        {
            dbcommon db = new dbcommon();
            System.Data.DataTable dt = db.getdt();
            string sheet_name;
            System.Data.DataTable dtsrc ;
            opexcel op = new opexcel(file_des);
            Workbook wb = op.open2();
            foreach (Worksheet wh in wb.Worksheets)
            {
                sheet_name = wh.Name;
                if (sheet_name.Contains("调度历史"))
                {
                    dtsrc = db.ImportExcel(file_src, sheet_name).Tables[0];
                    write_sheet_def(wh, dt, dtsrc);
                }
            }
            op.save(wb,file_des);
            wb.Close();
            op.close2();
        }
        public void write_sheet_def(Worksheet whs, System.Data.DataTable dt, System.Data.DataTable dtsrc)
        {
            //开始结束位置
            int i_s_time_pos, i_e_time_pos;
            //是否找到标志
            Boolean s_zt = false;
            Boolean e_zt = false;
            //开始，结束时间
            string str_s_time, str_e_time;
            //耗时,分钟
            int i_hs = 0;
            string[] temp;
            //range
            Range rg;
            //初始化表头
            whs.Cells[1, 4] = "用时（分钟）";
            for (int t = 0; t < dt.Rows.Count; t++)
            {
                whs.Cells[1, t + 9] = "TIME "+dt.Rows[t][1].ToString();
            }
            StringBuilder sb = new StringBuilder();
            
            for (int i = 2; i < dtsrc.Rows.Count+2; i++)
            {
                i_s_time_pos = 0;
                i_e_time_pos = 0;
                s_zt = false;
                e_zt = false;
                System.Drawing.Color[] color = new System.Drawing.Color[6];
                color[0] = System.Drawing.Color.Blue;
                color[1] = System.Drawing.Color.Yellow;
                color[2] = System.Drawing.Color.Red;
                color[3] = System.Drawing.Color.Cyan;
                color[4] = System.Drawing.Color.Green;
                color[5] = System.Drawing.Color.Magenta;
               // System.Drawing.Color []={System.Drawing.Color.Blue,System.Drawing.Color.Yellow};
                //str_s_time = whs.Cells[i, 7].ToString();
                //str_e_time = whs.Cells[i, 8].ToString();
                str_s_time = dtsrc.Rows[i - 2][6].ToString() == "" ? "0 0:00" : dtsrc.Rows[i - 2][6].ToString();
                str_e_time = dtsrc.Rows[i - 2][7].ToString() == "" ? "0 0:00" : dtsrc.Rows[i - 2][7].ToString();
                //DateTime dt1 = DateTime.ParseExact(str_s_time,"YYYY-MM-DD hh24:mm:ss",null);
                //DateTime dt2 = DateTime.ParseExact(str_e_time, "YYYY-MM-DD hh24:mm:ss", null);
                
                sb.Append("行"+i+":开始时间" + str_s_time + "，结束时间" + str_e_time+"\n");
                temp = str_s_time.Split(' ');
                str_s_time = temp[1].Trim();
                str_s_time = str_s_time.Substring(0, str_s_time.Length - 3) + ":00";
                //str_s_time = str_s_time.Substring(0, 1) == "0" ? str_s_time.Substring(1, str_s_time.Length-1) : str_s_time;
                temp = str_e_time.Split(' ');
                str_e_time = temp[1].Trim();
                str_e_time = str_e_time.Substring(0, str_e_time.Length - 3)+":00";
                //str_e_time = str_e_time.Substring(0, 1) == "0" ? str_e_time.Substring(1, str_e_time.Length - 1) : str_e_time;
                for (int t = 0; t < dt.Rows.Count; t++)
                {

                    //if (!s_zt & str_s_time.Contains(dt.Rows[t][1].ToString()))
                    //{
                    //    i_s_time_pos = t;
                    //    sb.Append("行" + i + ":开始时间" + dt.Rows[t][1].ToString());
                    //    s_zt = true;
                    //}
                    //if (!e_zt & str_e_time.Contains(dt.Rows[t][1].ToString()))
                    //{
                    //    i_e_time_pos = t;
                    //    sb.Append("行" + i + ":结束时间" + dt.Rows[t][1].ToString());
                    //    e_zt = true;
                    //}
                    if (!s_zt & str_s_time == dt.Rows[t][1].ToString())
                    {
                        i_s_time_pos = t;
                        sb.Append("行" + i + ":开始时间" + dt.Rows[t][1].ToString());
                        s_zt = true;
                    }
                    if (!e_zt & str_e_time == dt.Rows[t][1].ToString())
                    {
                        i_e_time_pos = t;
                        sb.Append("行" + i + ":结束时间" + dt.Rows[t][1].ToString());
                        e_zt = true;
                    }
                }
                i_hs = (i_e_time_pos - i_s_time_pos) < 0 ? i_e_time_pos - i_s_time_pos + 1440 : i_e_time_pos - i_s_time_pos;
                whs.Cells[i, 4] = i_hs;
                sb.Append("行" + i + ":耗时（分）" + i_hs + "\n");
                if (i_hs >=0)
                {
                    rg = (Range)whs.get_Range(whs.Cells[i, i_s_time_pos + 9], whs.Cells[i, i_s_time_pos + i_hs + 9]);
                    rg.Interior.Color = color[random()];//System.Drawing.Color.FromArgb(random(), random(), random());
                    rg.Value = 1;
                }
                
                
            }
            ResultHelper.WriteLog("1.log", sb.ToString());
        }
        private int random()
        {
            Random rd = new Random();
            //return rd.Next(0, 4) * rd.Next(0, 4) * rd.Next(0, 4) * rd.Next(0, 4);
            return rd.Next(0, 5);
        }
    }
}
