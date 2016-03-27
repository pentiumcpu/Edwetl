using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Reflection;
using Edwetl.src.common;
using Edwetl.src.model;
using Edwetl.src.dao;
namespace Edwetl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string str_filename = this.label1.Text;
            if (str_filename.Substring(str_filename.Length - 4, 4) == "xlsx")
            {
                int rows=0;
                string str_insert = "";
                string str_clob = "";
                if (rboracle.Checked)
                {
                    etl_tab_mapping_def_tdDAO etldao = new etl_tab_mapping_def_tdDAO("1");
                    //oporacle orcl = new oporacle(richTextBox1.Text);
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        
                        if (dr.Cells[3].Value.ToString().Trim().Length > 0)
                        {
                            str_insert = dr.Cells[23].Value.ToString();
                            str_clob = dr.Cells[12].Value.ToString();
                            //orcl.insert(str_insert, str_clob);
                            string str_mapping_id_key = dr.Cells[3].Value.ToString();
                            etl_tab_mapping_def etld = new etl_tab_mapping_def();
                           
                            etld.set_mapping_id(int.Parse(dr.Cells[4].Value.ToString()));
                            etld.set_batch_id(int.Parse(dr.Cells[5].Value.ToString()));
                            etld.set_sys_code(dr.Cells[6].Value.ToString());
                            etld.set_src_tab_name(dr.Cells[7].Value.ToString());
                            etld.set_des_tab_name(dr.Cells[8].Value.ToString());
                            etld.set_conv_type(dr.Cells[9].Value.ToString());
                            etld.set_conv_type_desc(dr.Cells[10].Value.ToString());
                            etld.set_delete_sql(dr.Cells[11].Value.ToString().Length == 0 ? "" : dr.Cells[11].Value.ToString());
                            etld.set_sql_str(dr.Cells[12].Value.ToString().Length == 0 ? "" : dr.Cells[12].Value.ToString());
                            //etld.set_job_name(tx_job_name.Text);
                            etld.set_job_name(dr.Cells[14].Value.ToString());
                            etld.set_job_desc(dr.Cells[15].Value.ToString());
                            etld.set_mapping_desc(dr.Cells[16].Value.ToString());
                            etld.set_remark(dr.Cells[17].Value.ToString());
                            etld.set_st_date(dr.Cells[18].Value.ToString());
                            etld.set_mnt_date(dr.Cells[19].Value.ToString());
                            etld.set_end_date(dr.Cells[20].Value.ToString());
                            etldao.insert(etld, str_mapping_id_key);
                            //
                            //richTextBox1.Text += "\n";
                            //richTextBox1.Text += str_insert;
                            rows++;
                        }
                    }
                     etldao = null;
                }
                if (rbtd.Checked)
                {
                    //teradata td = new teradata(richTextBox1.Text);
                    etl_tab_mapping_def_tdDAO etldao = new etl_tab_mapping_def_tdDAO("4");
                    foreach (DataGridViewRow dr in dataGridView1.Rows)
                    {
                        //str_insert = dataGridView1.CurrentRow.Cells[23].Value.ToString();
                        //str_clob = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                        if (dr.Cells[3].Value.ToString().Trim().Length > 0)
                        {
                            //td.exesql(str_insert);
                            string str_mapping_id_key = dr.Cells[3].Value.ToString();
                            etl_tab_mapping_def etld = new etl_tab_mapping_def();
                            
                            etld.set_mapping_id(int.Parse(dr.Cells[4].Value.ToString()));
                            etld.set_batch_id(int.Parse(dr.Cells[5].Value.ToString()));
                            etld.set_sys_code(dr.Cells[6].Value.ToString());
                            etld.set_src_tab_name(dr.Cells[7].Value.ToString());
                            etld.set_des_tab_name(dr.Cells[8].Value.ToString());
                            etld.set_conv_type(dr.Cells[9].Value.ToString());
                            etld.set_conv_type_desc(dr.Cells[10].Value.ToString());
                            etld.set_delete_sql(dr.Cells[11].Value.ToString().Length == 0 ? "" : dr.Cells[11].Value.ToString());
                            etld.set_sql_str(dr.Cells[12].Value.ToString().Length == 0 ? "" : dr.Cells[12].Value.ToString());
                            //etld.set_job_name(tx_job_name.Text);
                            etld.set_job_name(dr.Cells[14].Value.ToString());
                            etld.set_job_desc(dr.Cells[15].Value.ToString());
                            etld.set_mapping_desc(dr.Cells[16].Value.ToString());
                            etld.set_remark(dr.Cells[17].Value.ToString());
                            etld.set_st_date(dr.Cells[18].Value.ToString());
                            etld.set_mnt_date(dr.Cells[19].Value.ToString());
                            etld.set_end_date(dr.Cells[20].Value.ToString());
                            etldao.insert(etld, str_mapping_id_key);
                            rows++;
                        }
                    }
                    etldao = null;
                }
                
                MessageBox.Show("执行成功，成功添加[ "+rows+" ]条");
            }
            else 
            {
                MessageBox.Show("请选择xlsx文件");
            }
        }
        public string find_str(Workbook wbk,string str_sheetname,int r,int c)
        {
            
            Sheets shs = wbk.Sheets;
            Worksheet wsh = (Worksheet)shs.get_Item(str_sheetname);
            return (string)(wsh.Cells[r, c].ToString());
        }
        //配置表
        public string find_conf(Workbook wbk, int r, int c)
        {
            Sheets shs = wbk.Sheets;
            string sheetname = "配置表";
            //Worksheet wsh = (Worksheet)shs.get_Item(sheetname);
            Worksheet wsh = (Worksheet)shs.get_Item(sheetname);
            
            string rst = (string)(wsh.Cells[r, c].ToString());
            return rst;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //this.label1.Text = openFileDialog1.FileName;
            string str_filename = openFileDialog1.FileName;
            this.label1.Text = str_filename ;
            if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                MessageBox.Show("请选择xlsx文件或xls文件");
            else
            {
                dbcommon t2o = new dbcommon();
                System.Data.DataTable dt = dbcommon.GetSchemaTable(t2o.formatstrconn(str_filename));
                //dt = (t2o.ImportExcel(textBox1.Text, "Sheet1")).Tables[0];
                dataGridView1.DataSource = dt;
            }

        }

        private void 调度查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ddgl_ddck ddck = new ddgl_ddck();
            ddck.StartPosition = FormStartPosition.CenterScreen;
            ddck.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //string str_filename = this.label1.Text;
            //opexcel opxls = new opexcel(str_filename);
            //_Workbook wbk = opxls.open();
            //string str_sheetname = find_conf(wbk, 7, 2);
            //richTextBox1.Text=find_str(wbk, str_sheetname, 177, 13);
            //MessageBox.Show("字符串长度为："+find_str(wbk, str_sheetname, 177, 13).Length);
            test();
        }
        public void test()
        {
            //teradata td = new teradata();
            //string sql="select * from CMM_DATA_DEV1.test_from";
            //DataSet ds = td.getdsbysql(sql);
            //dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            //_Workbook wbk = opxls.open();
            StringBuilder rst = new StringBuilder("");
            if (rboracle.Checked)
            {
                rst = getrst(false);
            }
            if (rbtd.Checked)
            {
                rst = getrst( true);
            }
            richTextBox1.Text = rst.ToString();
            //Sheets shs = wbk.Sheets;
            //_Worksheet wsh = (_Worksheet)shs.get_Item(1);
            //try
            //{
            //    string str_filename = this.label1.Text;
            //    opexcel opxls = new opexcel(str_filename);
            //    Workbook wbk = opxls.open2();
            //    dataGridView1.DataSource = opxls.getdatatable(wbk);
            //    richTextBox1.Text = rst.ToString();
            //    wbk = null;
            //    opxls.close2();
            //}
            //catch { }
        }
        public StringBuilder getrst(Boolean istd)
        {
            
            
            string str_sql_length = "";
            string str_clob = "";
            string str_db_sql_length = "";
            string oraclconf = richTextBox1.Text;
            
            StringBuilder rst = new StringBuilder("");
            StringBuilder rst2db = new StringBuilder("");
            System.Data.DataTable dt = new System.Data.DataTable();
            
            if (istd)
            {
                string sql = "select to_char(mapping_id) mapping_id,length(sql_str) sqllength from CUST_DM.ETL_TAB_MAPPING_DEF";
                dt = new teradata(oraclconf).getdsbysql(sql).Tables[0];
            }
            else
            {
                string sql = "select to_char(mapping_id) mapping_id,length(sql_str) sqllength from CUST_DM.ETL_TAB_MAPPING_DEF";
                dt = new oporacle(oraclconf).getdsbysql(sql).Tables[0];
            }
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {

                if (dr.Cells[3].Value.ToString().Trim().Length > 0)
                {
                    
                    str_sql_length = dr.Cells[25].Value.ToString();
                    str_clob = dr.Cells[12].Value.ToString();
                    if (Int32.Parse(str_sql_length) != str_clob.Length)
                    {
                        rst.Append("Mapping_ID为：" + dr.Cells[4].Value.ToString() + "不一致。");
                        rst.Append("读取excel中的sql字符串的长度为:" + str_clob.Length + ",");
                        rst.Append("excel中的sql字符串的实际长度为:" + Int32.Parse(str_sql_length));
                        rst.Append("\n");
                    }
                    str_db_sql_length = getresult(dt,dr.Cells[4].Value.ToString());
                    if (Int32.Parse(str_sql_length) != Int32.Parse(str_db_sql_length))
                    {
                        rst2db.Append("Mapping_ID为：" + dr.Cells[4].Value.ToString() + "不一致。");
                        rst2db.Append("读取oracle中的sql字符串的长度为:" + str_db_sql_length + ",");
                        rst2db.Append("excel中的sql字符串的实际长度为:" + Int32.Parse(str_sql_length));
                        rst2db.Append("\n");
                    }
                }
            }
            //for (int i = 1; i <= rows; i++)
            //{
            //    r = i + 2;
            //    str_sql_length = find_str(wbk, str_sheetname, r, i_sql_length);
            //    str_clob = find_str(wbk, str_sheetname, r, s);
            //    if (Int32.Parse(str_sql_length) != str_clob.Length)
            //    {
            //        rst.Append("Mapping_ID为：" + find_str(wbk, str_sheetname, r, 5) + "不一致。");
            //        rst.Append("读取excel中的sql字符串的长度为:" + str_clob.Length + ",");
            //        rst.Append("excel中的sql字符串的实际长度为:" + Int32.Parse(str_sql_length));
            //        rst.Append("\n");
            //    }
            //    str_db_sql_length = getresult(dt, find_str(wbk, str_sheetname, r, 5));
            //    if (Int32.Parse(str_sql_length) != Int32.Parse(str_db_sql_length))
            //    {
            //        rst2db.Append("Mapping_ID为：" + find_str(wbk, str_sheetname, r, 5) + "不一致。");
            //        rst2db.Append("读取oracle中的sql字符串的长度为:" + str_db_sql_length + ",");
            //        rst2db.Append("excel中的sql字符串的实际长度为:" + Int32.Parse(str_sql_length));
            //        rst2db.Append("\n");
            //    }
            //}
            
            rst.Append("---------------我是邪恶的分割线-----------------\n");
            if (rst2db.Length < 20)
                rst2db.Append("恭喜！数据库的sql_str与EXCEL的insert_sql一致，没有问题！");
            rst.Append(rst2db);
            return rst;
        }
        public string getresult(System.Data.DataTable dt, string kw)
        {
            StringBuilder rst = new StringBuilder("");
            DataRow[] drs = dt.Select("mapping_id='" + kw + "'");
            if (drs.Length > 0)
            {
                return drs[0]["sqllength"].ToString();
            }
            else
            {
                return "0";
            }
        }
        //打开需求管理-结构检查窗口
        private void Open_Xqgl_Jgjc(object sender, EventArgs e)
        {
            Form_Xqgl_Jgjc win = new Form_Xqgl_Jgjc();
            //win.Size = new Size(800, 600);
            //win.WindowState = FormWindowState.Maximized;
            win.StartPosition = FormStartPosition.CenterScreen;
            win.Show();
        }
        private void tD2ORACLEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TD_2_Orcl ddck = new TD_2_Orcl();
            ddck.StartPosition = FormStartPosition.CenterScreen;
            ddck.Show();
        }
        private void perl(object sender, EventArgs e)
        {
            FormPerlapp pl = new FormPerlapp();
            pl.StartPosition = FormStartPosition.CenterScreen;
            pl.Show();
        }
        private void zysj_excel(object sender, EventArgs e)
        {
            Form_zysj_excel zysj = new Form_zysj_excel();
            zysj.StartPosition = FormStartPosition.CenterScreen;
            zysj.Show();
        }
        private void sxt_excel(object sender, EventArgs e)
        {
            Form_ywtj sxt = new Form_ywtj();
            sxt.StartPosition = FormStartPosition.CenterScreen;
            sxt.Show();
        }
        private void crm_model(object sender, EventArgs e)
        {
            Form_Crm_Model fcm = new Form_Crm_Model();
            fcm.StartPosition = FormStartPosition.CenterScreen;
            fcm.Show();
        }
        private void about(object sender, EventArgs e)
        {
            AboutBox1 abt = new AboutBox1(); 
            
            abt.StartPosition = FormStartPosition.CenterScreen;
            abt.ShowDialog();
        }
        private void Td_zsk(object sender, EventArgs e)
        {
            ddgl_ddck_TD form = new ddgl_ddck_TD();
            form.Show();
            
        }

        private void rboracle_CheckedChanged(object sender, EventArgs e)
        {
            dbcommon db = new dbcommon();
            richTextBox1.Text = db.get_conn("1");
            db = null;
        }

        private void rbtd_CheckedChanged(object sender, EventArgs e)
        {
            dbcommon db = new dbcommon();
            richTextBox1.Text = db.get_conn("4");
            db = null;
        }
        private void gv_doubleclick(object sender, DataGridViewCellMouseEventArgs e)
        {

            dbcommon t2o = new dbcommon();
            if (label2.Text == "ALL所有表")
            {
                string str_tbname = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                str_tbname = str_tbname.Replace("$", "");
                System.Data.DataTable dt2 = t2o.ImportExcel(this.label1.Text, str_tbname).Tables[0];
                dataGridView1.DataSource = dt2;
                label2.Text = str_tbname;
            }
            else
            {
                System.Data.DataTable dt = dbcommon.GetSchemaTable(t2o.formatstrconn(this.label1.Text));
                dataGridView1.DataSource = dt;
                label2.Text = "ALL所有表";
            }

        }
    }
}
