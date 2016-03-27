using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Edwetl
{
    public partial class TD_2_Orcl : Form
    {
        public TD_2_Orcl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //this.label1.Text = openFileDialog1.FileName;
            string str_filename = openFileDialog1.FileName;
            this.label1.Text = str_filename;
            if (str_filename.Substring(str_filename.Length - 4, 3).ToLower() != "xls")
                MessageBox.Show("请选择xls或xlsx文件");
        }
        private void bt_tbmap_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //this.label1.Text = openFileDialog1.FileName;
            string str_filename = openFileDialog1.FileName;
            this.label5.Text = str_filename;
            if (str_filename.Substring(str_filename.Length - 4, 3).ToLower() != "xls")
                MessageBox.Show("请选择xls或xlsx文件");
            else
            {
                td_to_orcl t2o = new td_to_orcl();
                DataTable dt = t2o.ImportExcel(str_filename,"Sheet1").Tables["Sheet1"];
                //dt = t2o.getdtbyexcel(str_filename);
                dataGridView2.DataSource = null;
                dataGridView2.DataSource = dt;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Length > 0 && richTextBox3.Text.Length > 0)
            {
                td_to_orcl t2o = new td_to_orcl();
                DataSet ds = t2o.f_get_ds(richTextBox1.Text, richTextBox3.Text);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ds.Tables[0];
                //int rst=t2o.f_to_orcl(richTextBox2.Text, str_c1_name, ds);
                MessageBox.Show("数据加载成功!");
            }
            //MessageBox.Show("成功插入" + rst + "条");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str_xls = label5.Text;
            string str_c1_name = tx_c1_tbname.Text;
            if (str_c1_name.Length > 0)
            {
                td_to_orcl t2o = new td_to_orcl();
                DataSet ds = t2o.f_get_ds(richTextBox1.Text, richTextBox3.Text);
                //string sql = t2o.getsqlbyds(ds, str_c1_name).ToString();
                int rst = t2o.f_to_orcl(richTextBox2.Text, str_c1_name, ds);
                MessageBox.Show("成功插入" + rst + "条");
            }
        }
        private void button_gensql_Click(object sender, EventArgs e)
        {
            string str_xls = label5.Text;
            string str_td_name = tx_td_tname_src.Text;
            string str_c1_name = tx_c1_tbname.Text;
            string str_td_schema = tx_td_schema.Text;
            if (str_c1_name.Length > 0 && str_td_name.Length > 0)
            {
                td_to_orcl t2o = new td_to_orcl();
                System.Data.DataTable dt = t2o.ImportExcel(str_xls, "Sheet2").Tables["Sheet2"];
                //string sql = t2o.f_gen_sql(str_xls, str_td_name, str_c1_name).ToString();
                string sql = t2o.f_gen_sql_td(dt, str_td_name, str_c1_name,str_td_schema).ToString();
                richTextBox3.Text = sql;
                MessageBox.Show("执行成功!");
            }
        }
        private void ImportOracleBatch_Click(object sender, EventArgs e)
        {
            //循环datagridview2表格
            string sql = "";
            string str_xls = label5.Text;
            string str_td_name ="";
            string str_c1_name ="";
            string str_td_schema = "";
            td_to_orcl t2o = new td_to_orcl();
            System.Data.DataTable dt = t2o.ImportExcel(str_xls, "Sheet2").Tables["Sheet2"];
            int count = dataGridView2.RowCount;
            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                //修改文本框的内容
                if (count>1)
                {
                    tx_td_tname_src.Text = dr.Cells[0].Value.ToString();
                    tx_c1_tbname.Text = dr.Cells[1].Value.ToString();
                    //生成查询TDsql
                    str_td_name = tx_td_tname_src.Text;
                    str_c1_name = tx_c1_tbname.Text;
                    str_td_schema = tx_td_schema.Text;
                    sql = t2o.f_gen_sql_td(dt, str_td_name, str_c1_name, str_td_schema).ToString();
                    richTextBox3.Text = sql;
                    count--;
                    //执行插入
                    try
                    {
                        DataSet ds = t2o.f_get_ds(richTextBox1.Text, richTextBox3.Text);
                        int rst = t2o.f_to_orcl(richTextBox2.Text, str_c1_name, ds);
                    }
                    catch
                    {
                    }
                }
            }
            MessageBox.Show("成功插入" + (dataGridView2.RowCount - 1) + "张表");
        }
        public DataSet ImportExcel(string strFileName)         //strFileName指定的路径+文件名.xls
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
                string sql = "select * from [Sheet1$]";
                System.Data.OleDb.OleDbConnection Conn = new System.Data.OleDb.OleDbConnection(strCon);
                Conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(sql, Conn);
                
                try
                {
                    da.Fill(ds,"Sheet1");
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

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            tx_td_tname_src.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            tx_c1_tbname.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            string str_xls = label5.Text;
            string str_td_name = tx_td_tname_src.Text;
            string str_c1_name = tx_c1_tbname.Text;
            string str_td_schema = tx_td_schema.Text;
            td_to_orcl t2o = new td_to_orcl();
            System.Data.DataTable dt = t2o.ImportExcel(str_xls, "Sheet2").Tables["Sheet2"];
            //string sql = t2o.f_gen_sql(str_xls, str_td_name, str_c1_name).ToString();
            string sql = t2o.f_gen_sql_td(dt, str_td_name, str_c1_name, str_td_schema).ToString();
            richTextBox3.Text = sql;
            MessageBox.Show("执行成功!");
        } 

    }
}
