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
    class Crm_model
    {
        private string file_des;
        private string file_src;
        public Crm_model(string v_file_src, string v_file_des)
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
            System.Data.DataTable dt_model;
            opexcel op = new opexcel(file_des);
            Workbook wb = op.open2();
            //foreach (Worksheet wh in wb.Worksheets)
            //{
            //    sheet_name = wh.Name;
            //    if (sheet_name.Contains("调度历史"))
            //    {
            //        dtsrc = db.ImportExcel(file_src, sheet_name).Tables[0];
            //        write_sheet_def(wh, dt, dtsrc);
            //    }
            //}
            sheet_name = "模型配置";
            Worksheet wh = (Worksheet)wb.Worksheets.get_Item(sheet_name);
            dtsrc = db.ImportExcel(file_src, sheet_name).Tables[0];
            dt=write_sheet_def(wh, dtsrc);
            sheet_name = "模型模板";
            Worksheet ws_model = (Worksheet)wb.Worksheets.get_Item(sheet_name);
            //wh = (Worksheet)wb.Worksheets.get_Item(sheet_name);
            dt_model = db.ImportExcel(file_src, sheet_name).Tables[0];
            write_sheet_model(wb, ws_model, dt, dt_model);
            write_sheet_workflow(wb, dtsrc, dt_model);
            write_sheet_xqwd(wb, dtsrc, dt_model);
            op.save(wb,file_des);
            wb.Close();
            op.close2();
        }
        public System.Data.DataTable write_sheet_def(Worksheet whs, System.Data.DataTable dtsrc)
        {
            //dtsrc.Columns
            System.Data.DataTable dt_lx = new System.Data.DataTable();
            System.Data.DataTable dt_src = new System.Data.DataTable();
            System.Data.DataTable dt_model = new System.Data.DataTable();
            System.Data.DataTable dt_list = new System.Data.DataTable();
            dt_lx.Columns.Add("NAME");
            dt_src.Columns.Add("NAME");
            dt_model.Columns.Add("NAME");
            dt_list.Columns.Add("NAME");
            DataRow dr;
            string temp = "";
            string temp_x = "";
            string temp_y = "";
            string temp_z = "";
            for (int i = 0; i < dtsrc.Rows.Count; i++)
            {
                temp=dtsrc.Rows[i][0].ToString().Trim();
                if (temp.Length != 0)
                {
                    dr = dt_lx.NewRow();
                    dr[0] = temp;
                    dt_lx.Rows.Add(dr);
                }
            }
            for (int i = 0; i < dtsrc.Rows.Count; i++)
            {
                temp = dtsrc.Rows[i][1].ToString().Trim();
                if (temp.Length != 0)
                {
                    dr = dt_src.NewRow();
                    dr[0] = temp;
                    dt_src.Rows.Add(dr);
                }
            }
            for (int i = 0; i < dtsrc.Rows.Count; i++)
            {
                temp = dtsrc.Rows[i][2].ToString().Trim();
                if (temp.Length != 0)
                {
                    dr = dt_model.NewRow();
                    dr[0] = temp;
                    dt_model.Rows.Add(dr);
                }
            }
            
            //foreach(DataRow dr_lx in dt_lx.Rows)
            //{
                //temp_x = dr_lx[0].ToString().Trim();
                foreach (DataRow dr_model in dt_model.Rows)
                {
                    temp_y = dr_model[0].ToString().Trim();
                    temp = temp_y;
                    //temp = temp_y.Substring(0, 2) + temp_x + temp_y.Substring(2, temp_y.Length-2);
                    if (temp_y.Contains("XXX"))
                    {
                        foreach (DataRow dr_src in dt_src.Rows)
                        {
                            temp_z = dr_src[0].ToString().Trim();
                            temp_z = temp.Replace("XXX", temp_z);
                            dr = dt_list.NewRow();
                            dr[0] = temp_z;
                            dt_list.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        dr = dt_list.NewRow();
                        dr[0] = temp;
                        dt_list.Rows.Add(dr);
                    }
                }
            //}
            for (int i = 0; i < dt_list.Rows.Count; i++)
            {
                temp = dt_list.Rows[i][0].ToString();
                whs.Cells[i+2, 4] = temp;
            }
            return dt_list;
        }
        public void write_sheet_model(Workbook wb, Worksheet whs, System.Data.DataTable dt, System.Data.DataTable dtsrc)
        {
            string sht_name = whs.Name;
            string cell_name = "";
            string temp_name = "";
            string sht_newname="";
            string str_caps = " CHARACTER SET LATIN NOT CASESPECIFIC ";
            
            StringBuilder sb_td = new StringBuilder();//创建Td表语句
            StringBuilder sb_ora = new StringBuilder();//创建Oracle所有表语句
            StringBuilder sb_ora_sub = new StringBuilder();//创建Oracle 单表语句
            StringBuilder sb_ora_c1 = new StringBuilder();//创建Oracle 所有C1表语句
            
            StringBuilder sb_ora_common = new StringBuilder();//Oracle表字段注释语句
            StringBuilder sb_ora_c1_common = new StringBuilder();//Oracle C1表字段注释语句
            StringBuilder sb_td_drop = new StringBuilder();
            StringBuilder sb_ora_drop = new StringBuilder(); //Oracle删除表语句
            StringBuilder sb_ora_c1_drop = new StringBuilder();//Oracle C1删除表语句
            StringBuilder sb_ora_primary = new StringBuilder();
            StringBuilder sb_ora_grant = new StringBuilder();//C1 grant语句
            StringBuilder sb_ora_synonym = new StringBuilder();//创建同义词语句
            StringBuilder sb_td_view = new StringBuilder();//创建Td VIEW语句
            StringBuilder sb_td_drop_view = new StringBuilder();//Td DROP VIEW语句
            string str_s = "COMMENT ON COLUMN ";
            int cnt = wb.Worksheets.Count;
            string str_key = ""; //主键字段拼接字符串
            Worksheet whsnew ;
            cnt = wb.Worksheets.Count;
            whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
           
            foreach (DataRow dr in dt.Rows)
            {
                whs.Copy(Type.Missing, whsnew);
                cnt = wb.Worksheets.Count;
                whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
                sht_newname=dr[0].ToString();
                whsnew.Name = sht_newname;

                for (int i = 0; i < dtsrc.Rows.Count; i++)
                {
                    cell_name = dtsrc.Rows[i][0].ToString();
                    //temp_name = sht_newname.Substring(0, 3) +"_"+ cell_name + sht_newname.Substring(3, sht_newname.Length-3);
                    temp_name = sht_newname +"_"+ cell_name;
                    whsnew.Cells[i + 2, 1] = temp_name;
                    if (sht_newname.StartsWith("C0")) //TD建表
                    {
                        if ((i == 0) || ((i != 0) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i - 1][0].ToString())))
                        {
                            str_key = "";//主键拼接后字符串置空
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            sb_td_drop.Append("DROP TABLE ${CMM_DATA}." + temp_name + ";\n");
                            sb_td.Append("CREATE MULTISET TABLE ${CMM_DATA}." + temp_name + "\n");
                            sb_td.Append("\t(" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + (dtsrc.Rows[i][2].ToString().Contains("VARCHAR")?str_caps:"")+" TITLE '" + dtsrc.Rows[i][3].ToString() + "',\n");
                            sb_td_view.Append("CREATE VIEW ${CMM_VIEW}." + "V0" + temp_name.Substring(2));
                            sb_td_view.Append(" AS SELECT * FROM ${CMM_DATA}." +  temp_name + ";\n");
                            sb_td_drop_view.Append("DROP VIEW ${CMM_VIEW}." + "V0" + temp_name.Substring(2) + ";\n");
                        }
                        else if ((i != 0) && (i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i + 1][0].ToString()) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i - 1][0].ToString()))
                        {
                            
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            sb_td.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + (dtsrc.Rows[i][2].ToString().Contains("VARCHAR") ? str_caps : "") + " TITLE '" + dtsrc.Rows[i][3].ToString() + "',\n");
                        }
                        else if ((i == dtsrc.Rows.Count - 1) || ((i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i + 1][0].ToString())))
                        {
                            
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            sb_td.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + (dtsrc.Rows[i][2].ToString().Contains("VARCHAR") ? str_caps : "") + " TITLE '" + dtsrc.Rows[i][3].ToString() + "')");
                            if (str_key != "")
                            {
                                sb_td.Append(" PRIMARY INDEX(" + str_key + ");\n");
                            }
                            else
                            {
                                sb_td.Append(";\n");
                            }
                        }

                    }
                    else if(sht_newname.EndsWith("_H"))//Oracle建表
                    {
                        if ((i == 0) || ((i != 0) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i - 1][0].ToString())))
                        {
                            str_key = "";//主键拼接后字符串置空
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            sb_ora_drop.Append("DROP TABLE " + temp_name + ";\n");
                            sb_ora.Append("CREATE TABLE " + temp_name + "\n");
                            sb_ora.Append("\t(" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ",\n");
                            
                        }
                        else if ((i != 0) && (i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i + 1][0].ToString()) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i - 1][0].ToString()))
                        {
                            sb_ora.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ",\n");
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                        }
                        else if ((i == dtsrc.Rows.Count - 1) || ((i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i + 1][0].ToString())))
                        {
                            sb_ora.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ",\n");
                            sb_ora.Append("\tST_DATE DATE" + ",\n");
                            sb_ora.Append("\tMNT_DATE DATE" + ",\n");
                            sb_ora.Append("\tEND_DATE DATE" + "\n");
                            
                            //sb_ora.Append("\tPARTITION P_MAX VALUES LESS THAN (MAXVALUE)");
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            if (!sht_newname.StartsWith("C1"))
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + "ST_DATE";
                                    sb_ora_primary.Append("ALTER TABLE " + temp_name + " ADD PRIMARY KEY (" + str_key + ") USING INDEX TABLESPACE TBS_CUST_IDX;\n");
                                    sb_ora.Append(", PRIMARY KEY (" + str_key + ") USING INDEX TABLESPACE TBS_CUST_IDX)");
                                }
                                else
                                {
                                    sb_ora.Append(")");
                                }
                            }
                            sb_ora.Append("\tPARTITION BY RANGE(ST_DATE)(" + "\n");
                            sb_ora.Append("\tPARTITION P_201601 VALUES LESS THAN (TO_DATE('2016-02-01','YYYY-MM-DD'))," + "\n");
                            sb_ora.Append("\tPARTITION P_MAX VALUES LESS THAN (MAXVALUE));\n");
                        }
                        sb_ora_common.Append(str_s + temp_name + "." + dtsrc.Rows[i][1].ToString() + " IS '" + dtsrc.Rows[i][3].ToString() + "';\n");

                    }
                    else //非TD、ORACLE 历史拉链表
                    {
                        if ((i == 0) || ((i != 0) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i - 1][0].ToString())))
                        {
                            str_key = "";//主键拼接后字符串置空
                            if (dtsrc.Rows[i][4].ToString() == "Y") //判断是否是主键
                            {
                                if (str_key != "") //
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            sb_ora_sub = null;
                            sb_ora_sub = new StringBuilder();
                            
                            sb_ora_sub.Append("CREATE TABLE " + temp_name + "\n");
                            sb_ora_sub.Append("\t(" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ",\n");
                            
                        }
                        else if ((i != 0) && (i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i + 1][0].ToString()) && (dtsrc.Rows[i][0].ToString() == dtsrc.Rows[i - 1][0].ToString()))
                        {
                            sb_ora_sub.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ",\n");
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                        }
                        else if ((i == dtsrc.Rows.Count - 1) || ((i != dtsrc.Rows.Count - 1) && (dtsrc.Rows[i][0].ToString() != dtsrc.Rows[i + 1][0].ToString())))
                        {
                            //sb_ora_sub.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString() + ");\n");
                            sb_ora_sub.Append("\t" + dtsrc.Rows[i][1].ToString() + " " + dtsrc.Rows[i][2].ToString());//为了添加主键，20160217修改
                            if (dtsrc.Rows[i][4].ToString() == "Y")//判断是否是主键
                            {
                                if (str_key != "")
                                {
                                    str_key = str_key + "," + dtsrc.Rows[i][1].ToString();
                                }
                                else
                                {
                                    str_key = dtsrc.Rows[i][1].ToString();
                                }
                            }
                            
                            if (!sht_newname.StartsWith("C1"))
                            {
                                if (str_key != "")
                                {
                                    sb_ora_primary.Append("ALTER TABLE " + temp_name + " ADD PRIMARY KEY (" + str_key + ") USING INDEX TABLESPACE TBS_CUST_IDX;\n");//主键拼接
                                    sb_ora_sub.Append(", PRIMARY KEY (" + str_key + ") USING INDEX TABLESPACE TBS_CUST_IDX);\n"); //添加主键，20160217修改
                                }
                                else
                                {
                                    sb_ora_sub.Append(");\n");
                                }
                                sb_ora.Append(sb_ora_sub.ToString());//非C1表Oracle建表语句拼接
                                sb_ora_drop.Append("DROP TABLE " + temp_name + ";\n");//非C1表Oracle删除表语句拼接
                            }
                            else
                            {
                                sb_ora_sub.Append(");\n");
                                sb_ora_c1.Append(sb_ora_sub.ToString());//C1表Oracle建表语句拼接
                                sb_ora_c1_drop.Append("DROP TABLE " + temp_name + ";\n");//C1表Oracle删除表语句拼接
                                sb_ora_grant.Append("GRANT SELECT ON " + temp_name + " TO CUST_DM;\n");//C1表Oracle删除表语句拼接
                                sb_ora_synonym.Append("CREATE OR REPLACE SYNONYM  " + temp_name + " FOR ETL_DS." + temp_name + ";\n");
                            }
                        }
                        if (!sht_newname.StartsWith("C1"))//非C1表Oracle注释语句拼接
                        {
                            sb_ora_common.Append(str_s + temp_name + "." + dtsrc.Rows[i][1].ToString() + " IS '" + dtsrc.Rows[i][3].ToString() + "';\n");
                        }
                        else//C1表Oracle注释语句拼接
                        {
                            sb_ora_c1_common.Append(str_s + temp_name + "." + dtsrc.Rows[i][1].ToString() + " IS '" + dtsrc.Rows[i][3].ToString() + "';\n");
                        }
                    }
                }
                
            }
            //获取当前时间,用于建表语句输出
            string path = AppDomain.CurrentDomain.BaseDirectory + "Result\\sql\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str_now = DateTime.Now.ToString("yyyyMMddHHmmss");
            str_now = "_" + str_now;
            ResultHelper.WriteLog(path + "TD_CREATE_TB" + str_now + ".SQL", sb_td.ToString());
            ResultHelper.WriteLog(path + "TD_DROP_TB" + str_now + ".SQL", sb_td_drop.ToString());
            ResultHelper.WriteLog(path + "ORACLE_CREATE_TB" + str_now + ".SQL", sb_ora.ToString() + sb_ora_common.ToString());
            ResultHelper.WriteLog(path + "ORACLE_DROP_TB" + str_now + ".SQL", sb_ora_drop.ToString());
            ResultHelper.WriteLog(path + "ORACLE_CREATE_TB_C1" + str_now + ".SQL", sb_ora_c1.ToString() + sb_ora_c1_common.ToString());
            ResultHelper.WriteLog(path + "ORACLE_DROP_TB_C1" + str_now + ".SQL", sb_ora_c1_drop.ToString());
            ResultHelper.WriteLog(path + "ORACLE_GRANT_C1" + str_now + ".SQL", sb_ora_grant.ToString());
            ResultHelper.WriteLog(path + "ORACLE_CREATE_SYNONYM" + str_now + ".SQL", sb_ora_synonym.ToString());
            ResultHelper.WriteLog(path + "TD_CREATE_VIEW" + str_now + ".SQL", sb_td_view.ToString());
            ResultHelper.WriteLog(path + "TD_DROP_VIEW" + str_now + ".SQL", sb_td_drop_view.ToString());
            //ResultHelper.WriteLog("C:\\COMMON_Oracle" + str_now + ".SQL", sb_ora_common.ToString());
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
        /*
         * Function name:write_sheet_workflow
         * date:2015-12-28
         * author:齐朝普
         * purpos:生成加工作业流程
         * wb:工作簿对象
         * dtdef:模型配置工作表
         * dtmodel:模型模板工作表
         */
        public void write_sheet_workflow(Workbook wb, System.Data.DataTable dtdef, System.Data.DataTable dtmodel)
        {
            //第一步创建workflow的工作表
            string sht_name = "workflow";
            int cnt = wb.Worksheets.Count;
            Worksheet whsnew ;
            cnt = wb.Worksheets.Count;
            whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
            wb.Worksheets.Add(Type.Missing,whsnew);
            cnt = wb.Worksheets.Count;
            whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
            whsnew.Name = sht_name;
            //第二步写入数据
            System.Data.DataTable dt_src = new System.Data.DataTable(); //源系统列表
            System.Data.DataTable dt_model = dtmodel;
            System.Data.DataTable dt_list = new System.Data.DataTable();
            dt_src.Columns.Add("NAME");
            dt_model.Columns.Add("NAME");
            dt_list.Columns.Add("NAME");
            DataRow dr;
            string temp = "";
            string temp_src = "";
            string temp_des = "";
            string temp_z = "";
            string temp_last = "";
            string temp_curr = "";
            string src_table = "";
            string des_table = "";
            string job_name = "";
            int i_idx = 0;
            for (int i = 0; i < dtdef.Rows.Count; i++)
            {
                temp = dtdef.Rows[i][1].ToString().Trim();
                if (temp.Length != 0)
                {
                    dr = dt_src.NewRow();
                    dr[0] = temp;
                    dt_src.Rows.Add(dr);
                }
            }
            whsnew.Cells[1, 1] = "源表";
            whsnew.Cells[1, 2] = "目标表";
            whsnew.Cells[1, 3] = "JOB_NAME";
            foreach (DataRow dr_def in dtdef.Rows)
            {
                if (dr_def[5].ToString().Trim().Length > 0)
                {
                    temp_last = "";
                    foreach (DataRow dr_model in dt_model.Rows)
                    {
                        temp_curr = dr_model[0].ToString().Trim();
                        src_table = dr_def[5].ToString().Trim()+"_"+dr_model[0].ToString().Trim();
                        des_table = dr_def[6].ToString().Trim() + "_" + dr_model[0].ToString().Trim();
                        job_name = dr_def[7].ToString().Trim();
                        if (temp_curr != temp_last)
                        {
                            if (src_table.Contains("XXX"))
                            {
                                foreach (DataRow dr_src in dt_src.Rows)
                                {
                                    temp_src = src_table.Replace("XXX", dr_src[0].ToString());
                                    temp_des = des_table.Replace("XXX", dr_src[0].ToString());
                                    whsnew.Cells[i_idx + 2, 1] = temp_src;
                                    whsnew.Cells[i_idx + 2, 2] = temp_des;
                                    whsnew.Cells[i_idx + 2, 3] = job_name;
                                    i_idx++;
                                }
                            }
                            else
                            {
                                whsnew.Cells[i_idx + 2, 1] = src_table;
                                whsnew.Cells[i_idx + 2, 2] = des_table;
                                whsnew.Cells[i_idx + 2, 3] = job_name;
                                i_idx++;
                            }
                        }
                        temp_last = temp_curr;
                    }
                }
            }
        }
        /*
         * Function name:write_sheet_xqwd
         * date:2016-02-02
         * author:齐朝普
         * purpos:生成需求文档
         * wb:工作簿对象
         * dtdef:模型配置工作表
         * dtmodel:模型模板工作表
         */
        public void write_sheet_xqwd(Workbook wb, System.Data.DataTable dtdef, System.Data.DataTable dtmodel)
        {
            //第一步创建workflow的工作表
            string sht_name = "字段需求";
            int cnt = wb.Worksheets.Count;
            Worksheet whsnew;
            cnt = wb.Worksheets.Count;
            whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
            wb.Worksheets.Add(Type.Missing, whsnew);
            cnt = wb.Worksheets.Count;
            whsnew = (Worksheet)wb.Worksheets.get_Item(cnt);
            whsnew.Name = sht_name;
            //第二步写入数据
            System.Data.DataTable dt_src = new System.Data.DataTable(); //源系统列表
            System.Data.DataTable dt_model2 = dtmodel;
            //20160218增加
            string str_c0 = ""; //C0层前缀
            str_c0 = dtdef.Rows[0][2].ToString().Trim();
           
            dt_src.Columns.Add("NAME");
            DataRow dr;
            string temp = "";
            string temp_src = "";
            string temp_des = "";
            string temp_z = "";
            string temp_last = "";
            string temp_curr = "";
            string src_table = "";
            string des_table = "";
            string job_name = "";
            int i_idx = 0;
            int i_seq = 1;
            for (int i = 0; i < dtdef.Rows.Count; i++)
            {
                temp = dtdef.Rows[i][1].ToString().Trim();
                if (temp.Length != 0)
                {
                    dr = dt_src.NewRow();
                    dr[0] = temp;
                    dt_src.Rows.Add(dr);
                }
            }
            //StringBuilder sb_td = new StringBuilder();
            //StringBuilder sb_td_drop_view = new StringBuilder();
            //StringBuilder sb_ora_grant = new StringBuilder();
            //StringBuilder sb_ora_synonym = new StringBuilder();
            string str_c1_name = "";
            string str_v0_name = "";
            whsnew.Cells[1, 1] = "源系统标识";
            whsnew.Cells[1, 2] = "源系统名称";
            whsnew.Cells[1, 3] = "源系统表英文名称";
            whsnew.Cells[1, 4] = "源系统表中文名称";
            whsnew.Cells[1, 5] = "序号";
            whsnew.Cells[1, 6] = "字段英文名";
            whsnew.Cells[1, 7] = "字段中文名";
            whsnew.Cells[1, 8] = "字段类型";
            whsnew.Cells[1, 9] = "是否主键";
            whsnew.Cells[1, 11] = "序号";
            whsnew.Cells[1, 10] = "目标表名";
            whsnew.Cells[1, 12] = "字段英文名";
            whsnew.Cells[1, 13] = "字段类型";
            
            
            foreach (DataRow dr_src in dt_src.Rows)
            {
                temp_last = "";
                i_seq = 1;
                foreach (DataRow dr_model in dt_model2.Rows)
                {
                    temp_curr = dr_model[0].ToString().Trim();
                    if (str_c0.Contains("XXX"))
                    {
                        str_c1_name = "C1_" + str_c0.Substring(3).Replace("XXX", dr_src[0].ToString()) + "_" + temp_curr;
                        str_v0_name = "V0_" + str_c0.Substring(3).Replace("XXX", dr_src[0].ToString()) + "_" + temp_curr;
                    }
                    else
                    {
                        str_c1_name = "C1_" + temp_curr;
                        str_v0_name = "V0_" + temp_curr;
                    }
                    if (temp_curr != temp_last)
                    {
                        
                        //sb_td.Append("CREATE VIEW ${CMM_VIEW}." + "V0_" + dr_src[0].ToString() + "_" + temp_curr);
                        //sb_td.Append(" AS SELECT * FROM ${CMM_DATA}." + "C0_" + dr_src[0].ToString() + "_" + temp_curr + ";\n");
                        //sb_td_drop_view.Append("DROP VIEW ${CMM_VIEW}." + "V0_" + dr_src[0].ToString() + "_" + temp_curr + ";\n");
                        //sb_ora_grant.Append("GRANT SELECT ON " + str_c1_name + " TO CUST_DM;\n");
                        //sb_ora_synonym.Append("CREATE OR REPLACE SYNONYM  " + str_c1_name + " FOR ETL_DS." + str_c1_name + ";\n");
                        i_seq = 1;
                        //temp_src = src_table.Replace("XXX", dr_src[0].ToString());
                        //temp_des = des_table.Replace("XXX", dr_src[0].ToString());
                        //whsnew.Cells[i_idx + 2, 1] = temp_src;
                        //whsnew.Cells[i_idx + 2, 2] = temp_des;
                        //whsnew.Cells[i_idx + 2, 3] = job_name;
                        whsnew.Cells[i_idx + 2, 1] = "T3CMM";
                        whsnew.Cells[i_idx + 2, 2] = "数据仓库";
                        whsnew.Cells[i_idx + 2, 3] = str_v0_name;
                        whsnew.Cells[i_idx + 2, 4] = "";
                        whsnew.Cells[i_idx + 2, 5] = i_seq;
                        whsnew.Cells[i_idx + 2, 6] = dr_model[1].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 7] = dr_model[3].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 8] = dr_model[2].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 9] = "";
                        whsnew.Cells[i_idx + 2, 11] = i_seq;
                        whsnew.Cells[i_idx + 2, 10] = str_c1_name;
                        whsnew.Cells[i_idx + 2, 12] = dr_model[1].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 13] = dr_model[2].ToString().Trim();
                        i_seq++;
                    }
                    else
                    {
                        //whsnew.Cells[i_idx + 2, 1] = temp_src;
                        //whsnew.Cells[i_idx + 2, 2] = temp_des;
                        //whsnew.Cells[i_idx + 2, 3] = job_name;
                        whsnew.Cells[i_idx + 2, 1] = "T3CMM";
                        whsnew.Cells[i_idx + 2, 2] = "数据仓库";
                        whsnew.Cells[i_idx + 2, 3] = str_v0_name;
                        whsnew.Cells[i_idx + 2, 4] = "";
                        whsnew.Cells[i_idx + 2, 5] = i_seq;
                        whsnew.Cells[i_idx + 2, 6] = dr_model[1].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 7] = dr_model[3].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 8] = dr_model[2].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 9] = "";
                        whsnew.Cells[i_idx + 2, 11] = i_seq;
                        whsnew.Cells[i_idx + 2, 10] = str_c1_name;
                        whsnew.Cells[i_idx + 2, 12] = dr_model[1].ToString().Trim();
                        whsnew.Cells[i_idx + 2, 13] = dr_model[2].ToString().Trim();
                        
                        i_seq++;
                    }
                    i_idx++;
                    temp_last = temp_curr;
                }
               
            }
            string str_now = DateTime.Now.ToString("yyyyMMddHHmmss");
            str_now = "_" + str_now;
            string path = AppDomain.CurrentDomain.BaseDirectory + "Result\\sql\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private int random()
        {
            Random rd = new Random();
            //return rd.Next(0, 4) * rd.Next(0, 4) * rd.Next(0, 4) * rd.Next(0, 4);
            return rd.Next(0, 5);
        }
    }
}
