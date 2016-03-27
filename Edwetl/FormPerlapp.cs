using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edwetl.src.common;
using Edwetl.src.model;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
namespace Edwetl
{
    public partial class FormPerlapp : Form
    {
        public FormPerlapp()
        {
            InitializeComponent();
        }
        private void btn_select(object o, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string str_filename = openFileDialog1.FileName;
            textBox1.Text = str_filename;
            var path = string.Format(@"\{0}\", "CMMDM");
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    dbcommon t2o = new dbcommon();
                    System.Data.DataTable dt = dbcommon.GetSchemaTable(t2o.formatstrconn(textBox1.Text));

                    dataGridView1.DataSource = dt;
                }
            }
            richTextBox1.Text = AppDomain.CurrentDomain.BaseDirectory + "Result\\app\n";
            richTextBox1.Text += AppDomain.CurrentDomain.BaseDirectory + @"Result" + path; 
            
        }
        private void btn_bornperl(object o, EventArgs e)
        {
            //initgvbyopexcel();
            string str_filename = textBox1.Text;
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    initgvbydbcommon();
                    richTextBox1.Text += "处理成功\n";
                }
            }
            
        }
        private void job_excel(System.Data.DataTable dt)
        {
            string str_now = DateTime.Now.ToString("yyyyMMddHHmmss");
            richTextBox1.Text += str_now;
            richTextBox1.Text += "\n";
            string path = AppDomain.CurrentDomain.BaseDirectory + "Result\\excel\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str_src = AppDomain.CurrentDomain.BaseDirectory + "model\\job.xlsx";
            string str_des = path + "job_" + str_now + ".xlsx";
            create_job_excel(str_src, str_des);
            write_job_excel(dt, str_des);
        }
        private void create_job_excel(string src, string des)
        {
            opexcel op = new opexcel(src);
            Workbook wb = op.open2();
            op.save(wb, des);
            wb.Close();
            //wb = null;
            op.close2();
        }
        private void write_job_excel(System.Data.DataTable dt, string des)
        {
            etla_excel ee = new etla_excel(dt, des);
            ee.write_etla_excel();
        }
        private void initgvbyopexcel()
        {
            string str_filename = this.textBox1.Text;
            opexcel opxls = new opexcel(str_filename);
            Workbook wbk = opxls.open2();
            System.Data.DataTable dt = opxls.getdatatable(wbk);
            dataGridView1.DataSource = dt;
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Result\\app"))
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "Result\\app", true);
            }
            foreach (DataRow dr in dt.Rows)
            {
                string str_tbname = dr["TABLE_NAME"].ToString();
                str_tbname = str_tbname.Replace("$", "");
                if (str_tbname.Contains("ETL调度") && !str_tbname.Contains("_"))
                {
                    System.Data.DataTable dt2 = opxls.getdatatable(wbk, str_tbname);
                    dataGridView1.DataSource = dt2;
                    gen_perl_app(dt2);
                    job_excel(dt2);
                }
            }
            wbk = null;
            opxls.close2();
        }
        private void initgvbydbcommon()
        {
            dbcommon t2o = new dbcommon();
            System.Data.DataTable dt = dbcommon.GetSchemaTable(t2o.formatstrconn(textBox1.Text));
            dataGridView1.DataSource = dt;
            if (Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "Result\\app"))
            {
                Directory.Delete(AppDomain.CurrentDomain.BaseDirectory + "Result\\app", true);
            }
            foreach (DataRow dr in dt.Rows)
            {
                string str_tbname = dr["TABLE_NAME"].ToString();
                str_tbname = str_tbname.Replace("$", "");
                if (str_tbname.Contains("ETL调度") && !str_tbname.Contains("_"))
                {
                    System.Data.DataTable dt2 = t2o.ImportExcel(textBox1.Text, str_tbname).Tables[0];
                    dataGridView1.DataSource = dt2;
                    gen_perl_app(dt2);
                    job_excel(dt2);
                }
            }
        }
        private void gen_perl_app(System.Data.DataTable dt)
        {
            string JOB_DIR = "$ETL_HOME/App";
            string GROUP_NAME;  //0
            string JOB_NAME;	//1
            string BATCH_ID;		//2
            string CALLPRC;		//3
            string JOB_LX;			//4
            string JOB_NAME_TEMPLET;		//5
            string JOB_DESC;		//6
            string JOB_CONF; ////作业配置信息
            string context;
            perlstr pl = new perlstr();
            bool bl = false;
            bl = checkBox1.Checked;
            foreach (DataRow dr in dt.Rows)
            {
                JOB_DIR=dr[0].ToString()!=null?dr[0].ToString():"";
    	        GROUP_NAME=dr[1].ToString()!=null?dr[1].ToString():"";
		        JOB_NAME=dr[2].ToString()!=null?dr[2].ToString():"";
		        BATCH_ID=dr[3].ToString()!=null?dr[3].ToString():"";
		        CALLPRC=dr[4].ToString()!=null?dr[4].ToString():"";
		        JOB_LX=dr[5].ToString()!=null?dr[5].ToString():"";
		        JOB_NAME_TEMPLET=dr[6].ToString()!=null?dr[6].ToString():"";
                JOB_DESC = dr[7].ToString() != null ? dr[7].ToString() : "";
                JOB_CONF = GROUP_NAME + "," + BATCH_ID + "," + CALLPRC + "," + JOB_DESC;
                if (JOB_DIR != "")
                {
                    context = pl.context(JOB_NAME, JOB_NAME_TEMPLET, JOB_CONF, JOB_DIR);
                    if (bl)
                    {
                        richTextBox1.Text += context + "\n";
                    }
                    ResultHelper.Perl(JOB_NAME, context, JOB_DIR+"\\App");
                }
            }
        }
    }
}
