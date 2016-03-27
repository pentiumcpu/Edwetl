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
    public partial class Form_zysj_excel : Form
    {
        public Form_zysj_excel()
        {
            InitializeComponent();
        }
        private void btn_select(object o, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string str_filename = openFileDialog1.FileName;
            textBox1.Text = str_filename;
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    dbcommon t2o = new dbcommon();
                    System.Data.DataTable dt = dbcommon.GetSchemaTable(t2o.formatstrconn(textBox1.Text));
                    dt = (t2o.ImportExcel(textBox1.Text,"Sheet1")).Tables[0];
                    dataGridView1.DataSource = dt;
                    richTextBox1.Text = AppDomain.CurrentDomain.BaseDirectory + "Result\n";
                }
            }

        }
        private void btn_zysj_excel(object o, EventArgs e)
        {
            string str_now = DateTime.Now.ToString("yyyyMMddHHmmss");
            richTextBox1.Text += str_now;
            richTextBox1.Text += "\n";
            string path = AppDomain.CurrentDomain.BaseDirectory + "Result\\excel\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string str_src = AppDomain.CurrentDomain.BaseDirectory + "model\\zysj.xlsx";
            string str_des = path + "dhc-客户管理数据集市-作业设计_" + str_now + ".xlsx";
            string str_filename = textBox1.Text;
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    create_zysj_excel(str_src, str_des);
                    write_zysj_excel(str_des);
                }
            }
        }
        private void create_zysj_excel(string src,string des)
        {
            opexcel op = new opexcel(src);
            Workbook wb = op.open2();
            op.save(wb, des);
            wb.Close();
            op.close2();
        }
        private void write_zysj_excel(string file_name)
        {
            string str_filename = textBox1.Text;
            if (str_filename.Length > 0)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    zysj_excel se = new zysj_excel(str_filename, file_name);
                    se.write_zysj_excel();
                    richTextBox1.Text += "处理成功\n";
                }
            }
            else
                MessageBox.Show("请选择xlsx文件或xls文件");
        }
        
    }
}
