using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Edwetl.src.common;
using System.Threading;
namespace Edwetl
{
    public partial class Form_Xqgl_Jgjc : Form
    {
        public Form_Xqgl_Jgjc()
        {
            InitializeComponent();
            DateTime dt = DateTime.Today;
            tx_etl_date.Text = dt.Year.ToString() + ((dt.Month.ToString().Length == 1) ? ("0" + dt.Month.ToString()) : dt.Month.ToString()) + ((dt.Day.ToString().Length == 1) ? ("0" + dt.Day.ToString()) : dt.Day.ToString());
        }
        private void Form_Xqgl_Jgjc_Load(object sender, EventArgs e)
        {
            
        }
        private void btn_openfile(object sender, EventArgs e)
        {
            openFileExcelDialog.ShowDialog();
            textBox1.Text = openFileExcelDialog.FileName.ToString();
            string str_filename = textBox1.Text;
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    intdgv(textBox1.Text);
                }
            }
        }
        private void intdgv(string filename)
        {
            td_to_orcl tto = new td_to_orcl();
            gv_result.DataSource = td_to_orcl.GetSchemaTable(tto.formatstrconn(filename));
        }

        private void bt_check_Click(object sender, EventArgs e)
        {
            string str_filename = textBox1.Text;
            if (str_filename.Length > 2)
            {
                if ((str_filename.Substring(str_filename.Length - 4, 4) != "xlsx") && (str_filename.Substring(str_filename.Length - 3, 3) != "xls"))
                    MessageBox.Show("请选择xlsx文件或xls文件");
                else
                {
                    doit(sender,e);
                }
            }
        }
        public void doit(object sender, EventArgs e)
        {
            jgjc jc = new jgjc(textBox1.Text);
            //ThreadPool.QueueUserWorkItem(new WaitCallback(dowork), jc);
            //string out_msg="";
            ////Thread t;
            ////t = new Thread(jc.inserdb);
            ////t.Start(textBox1.Text);
            ////jc.inserdb(textBox1.Text);
            ////outwin.Text = outwin.Text + "\n" + "执行成功！\n" + out_msg;
            ////MessageBox.Show("返回结果："+out_msg);
            //MessageBox.Show("已移交给系统后台处理，稍事休息一下~");
            ThreadStart ts = new ThreadStart(jc.inserdb);
            Thread thread = new Thread(ts);
            thread.Start();
            string result = "处理中...";
            label3.Text = result;
            progressBar1.Style = ProgressBarStyle.Marquee;
            while (thread.ThreadState != System.Threading.ThreadState.Stopped)
            {
                //MessageBox.Show(result);

                progressBar1.Visible = true;
                for (int i = 0; i < 100; i++)
                {
                    this.progressBar1.Value = i;
                    System.Threading.Thread.Sleep(50);
                }
                //System.Threading.Thread.Sleep(1000);
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            result = "处理完成";
            this.progressBar1.Value = progressBar1.Maximum;
            label3.Text = result;
            //MessageBox.Show(result);
            bt_result_view(sender, e);
        }
        public void dowork(Object stateInfo)
        {
            jgjc jc = (jgjc) stateInfo;
            jc.inserdb();
        }
        private void bt_result_view(object sender, EventArgs e)
        {
            try
            {
                jgjc jc = new jgjc(textBox1.Text);
                gv_result.DataSource = null;
                DataSet ds = jc.view(tx_etl_date.Text);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count == 0)
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = "对比结果完全一致";
                    dt.Rows.Add(dr);
                }
                gv_result.DataSource = dt;
                outwin.Text = outwin.Text + "\n" + "执行成功！\n";
                MessageBox.Show("处理成功");
            }
            catch (System.Data.OracleClient.OracleException ex)
            {
                MessageBox.Show(ex.Message.ToString(),"出错了");
                outwin.Text += "日期为：" + tx_etl_date.Text + "表不存在\n";
                //DataTable dt = new DataTable();
                //gv_result.DataSource = "日期为：" + tx_etl_date.Text + "表不存在";
            }
        }
    }
}
