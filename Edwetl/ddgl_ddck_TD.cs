using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OracleClient;
using Edwetl.src.common;
using Edwetl.src.model;
namespace Edwetl
{
    public partial class ddgl_ddck_TD : Form
    {
        public ddgl_ddck_TD()
        {
            InitializeComponent();
            btn_detail.Enabled = false;
            button2.Enabled=false;
            DateTime dt = DateTime.Today;
            tx_date.Text = dt.Year.ToString() + ((dt.Month.ToString().Length == 1) ? ("0" + dt.Month.ToString()) : dt.Month.ToString()) + ((dt.Day.ToString().Length == 1) ? ("0" + dt.Day.ToString()) : dt.Day.ToString());
        
        }
        private delegate void funHandle(int nValue);
        private funHandle myHandle = null; 
        private Form2 progressForm = new Form2(); 
        private void ddgl_ddck_Load(object sender, EventArgs e)
        {
            //if (richTextBox1.Text != null)
            //{
            //    oporacle orcl = new oporacle(richTextBox1.Text);
            //    dataGridView1.DataSource = orcl.getds();
            //    //dataGridView1.DataBindings;
            //}

        }
        

        public void nodeadd()
        {
            initp();
        }
        public void initp()
        {
            string str_conn = richTextBox1.Text;
            string str_tab_name = textBox2.Text;
            teradata db = new teradata(str_conn);
            treeView1.Nodes.Clear();
            {


                //string sql = "select substr(batch_id,1,3) as mapping_id,substr(batch_id,1,3) as batch_id,'' delete_sql,'' sql_str from ETL_TAB_MAPPING_DEF where mapping_id=24000101";
                //DataTable dt = db.getdsbysql(sql).Tables[0];
                //DataRow[] drs = dt.Select();
                DataTable dt;
                
                treeView1.Nodes.Clear();
                TreeNode tn = new TreeNode();
                //foreach (DataRow dr in drs)
                //{
                    
                //    tn.Tag = dr["batch_id"].ToString();
                //    tn.Text = dr["mapping_id"].ToString();
                //    tn.Tag = "0";
                //    tn.Text = "客户管理数据集市";
                //    treeView1.Nodes.Add(tn);
                                 
                //}
                tn.Tag = "0";
                tn.Text = "数据集市知识库";
                treeView1.Nodes.Add(tn);
                string sql2 = @"select * from (select to_char(mapping_id) mapping_id,
       to_char(batch_id) batch_id,
       delete_sql,
       '' sql_str,
       des_tab_name
  from " + str_tab_name + @"
union all
select distinct substr(to_char(batch_id), 1, 6) as mapping_id,
                substr(to_char(batch_id), 1, 2) as batch_id,
                '' delete_sql,
                '' sql_str,
                des_tab_name
  from " + str_tab_name + @"
   where mapping_id in (
  select max(mapping_id) from " + str_tab_name + @" group by batch_id)
union all  
  select distinct substr(to_char(batch_id), 1, 2) as mapping_id,
                substr(to_char(batch_id), 1, 1) as batch_id,
                '' delete_sql,
                '' sql_str,
                '' des_tab_name
  from " + str_tab_name + @"
  union all  
  select distinct substr(to_char(batch_id), 1, 1) as mapping_id,
                substr('0', 1, 1) as batch_id,
                '' delete_sql,
                '' sql_str,
                '' des_tab_name
  from " + str_tab_name + @") t where t.mapping_id<>t.batch_id
 order by 1";
                rtb_log.Text += sql2+"\n";
                dt = db.getdsbysql(sql2).Tables[0];
                db = null;
                initchild(dt, tn);
            }

        }
        public void initchild(DataTable dt, TreeNode ptn)
        {
            
            DataRow[] drs = dt.Select("batch_id='" + ptn.Tag.ToString() + "'");
            foreach (DataRow dr in drs)
            {
                TreeNode tn = new TreeNode();
                tn.Tag = dr["mapping_id"].ToString();
                tn.Text = dr["mapping_id"].ToString() +" "+ dr["des_tab_name"];
                ptn.Nodes.Add(tn);
                initchild(dt, tn);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            nodeadd();
                //dataGridView1.DataBindings;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            aa();
        }
        public void aa()
        {
            //string str_recid = dataGridView1.CurrentRow.Cells["unitid"].Value.ToString();
            //MessageBox.Show(str_recid);
            btn_detail.Enabled = true;
            button2.Enabled = true;
            label1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            richTextBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            rtx_delete.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
        public void initdgv(string str_pid)
        {
            string str_conn = richTextBox1.Text;
            teradata db = new teradata(str_conn);
            StringBuilder sb=new StringBuilder("");
            sb.Append("select mapping_id,batch_id,src_tab_name,des_tab_name,delete_sql,sql_str from  " + textBox2.Text);
            sb.Append(" where ");
            sb.Append("to_char(mapping_id) like '%" + str_pid + "%'");
            sb.Append(" or ");
            sb.Append("to_char(BATCH_ID) like '%" + str_pid + "%'");
            sb.Append(" or ");
            sb.Append("SYS_CODE like '%" + str_pid + "%'");
            sb.Append(" or ");
            sb.Append("UPPER(DELETE_SQL) like '%" + str_pid.ToUpper() + "%'");
            sb.Append(" or ");
            sb.Append("UPPER(SQL_STR) like '%" + str_pid.ToUpper() + "%'");
            sb.Append(" or ");
            sb.Append("UPPER(SRC_TAB_NAME) like '%" + str_pid.ToUpper() + "%'");
            sb.Append(" or ");
            sb.Append("UPPER(DES_TAB_NAME) like '%" + str_pid.ToUpper() + "%'");
            sb.Append(" order by mapping_id asc");
            string sql = sb.ToString();
            rtb_log.Text += sql+"\n";
            DataSet ds = db.getdsbysql(sql);
            db = null;
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ds.Tables[0];
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str_conn = richTextBox1.Text;
            teradata db = new teradata(str_conn);
            string str_delete = rtx_delete.Text;
            str_delete = str_delete.Replace("'","''");
            string str_recid = dataGridView1.CurrentRow.Cells["mapping_id"].Value.ToString();
            string sql = "update " + textBox2.Text + " set delete_sql='" + str_delete + "',sql_str=? where mapping_id='" + str_recid + "'";
            string str_clob = richTextBox2.Text;
            //MessageBox.Show(str_recid);
            DialogResult dr;
            dr = MessageBox.Show("确认修改批次号为[" + label1.Text + "]的SQL_STR" + "吗？", "是否确认", MessageBoxButtons.YesNoCancel);
            if (dr == DialogResult.Yes)
            {
                int rst=db.Exesql(sql, str_clob);
                db = null;
                if (rst == 1)
                {
                    MessageBox.Show("修改成功");
                }
                else
                {
                    MessageBox.Show("修改失败");
                }
                if (treeView1.Nodes.Count < 1)
                {
                    nodeadd();
                    string str_tag = textBox1.Text;
                    initdgv(str_tag);
                    aa();
                }
                else
                {
                    string str_tag = this.treeView1.SelectedNode.Tag.ToString();
                    initdgv(str_tag);
                    aa();
                }
            }
            
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str_tag = this.treeView1.SelectedNode.Tag.ToString();
            initdgv(str_tag);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str_mappingid = textBox1.Text;
            initdgv(str_mappingid);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string str_date_8 = tx_date.Text;
            string str_conn = richTextBox1.Text;
            string str_del = rtx_delete.Text;
            string sql = richTextBox2.Text;
            string str_date_d = "to_date('" + str_date_8 + "','YYYYMMDD')";
            string str_date = "'" + str_date_8.Substring(0, 4) + "-" + str_date_8.Substring(4, 2) + "-" + str_date_8.Substring(6, 2) + "'";
            str_date_8 = "'" + str_date_8 + "'";
            sql = sql.Replace(":ETL_DATE_8", str_date_8);
            sql = sql.Replace(":ETL_DATE_D", str_date_d);
            sql = sql.Replace(":ETL_DATE", str_date);
            str_del = str_del.Replace(":ETL_DATE_8", str_date_8);
            str_del = str_del.Replace(":ETL_DATE_D", str_date_d);
            str_del = str_del.Replace(":ETL_DATE", str_date);
            string result=fundeal(str_conn, str_date_8, str_del, sql);
            MessageBox.Show(result);
            richTextBox3.Text = sql; 
        }
        Func<string,string, string, string, string> fundeal = delegate(string str_conn,string str_date_8, string del_str, string sql)
        {
            
            //richTextBox3.Text = sql;
            try
            {
                teradata db = new teradata(str_conn);
                int i_del=db.Exesql(del_str);
                int i = db.Exesql(sql);
                return "执行成功，删除 " + i_del + " 条，插入 " + i + " 条";
                
            }
            catch
            { 
                return "执行失败";
            }
            
        };
        private void cmm1_CheckedChanged(object sender, EventArgs e)
        {
            dbcommon db = new dbcommon();
            string result = db.get_conn("4");
            string[] results;
            results=result.Split('|');
            richTextBox1.Text = results[0];
            textBox2.Text = results[1];
            db = null;
            //richTextBox1.Text = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=103.160.120.173)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=cmm1)));User ID=cust_dm;Password=cust_dm";
        }

        private void cmm2_CheckedChanged(object sender, EventArgs e)
        {
            dbcommon db = new dbcommon();
            string result = db.get_conn("5");
            string[] results;
            results = result.Split('|');
            richTextBox1.Text = results[0];
            textBox2.Text = results[1];
            db = null;
        }
        private void btn_show_detail(object sender, EventArgs e)
        {
            
            string mapping_id = label1.Text;
            show_detail(mapping_id);
        }
        private void show_detail(string var_mapping_id)
        {
            string str_lx = "";
            if (cmm1.Checked)
            {
                str_lx = "4";
            }
            else if (cmm2.Checked)
            {
                str_lx = "5";
            }
            show_detail showd = new show_detail(var_mapping_id, str_lx);
            //showd.set_tb_mapping_id(var_mapping_id);
            showd.StartPosition = FormStartPosition.CenterScreen;
            showd.Show();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            // 启动线程  
            string str_date_8 = tx_date.Text;
            string str_conn = richTextBox1.Text;
            string str_del = rtx_delete.Text;
            string sql = richTextBox2.Text;
            string str_date_d = "to_date('" + str_date_8 + "','YYYYMMDD')";
            string str_date = "'" + str_date_8.Substring(0, 4) + "-" + str_date_8.Substring(4, 2) + "-" + str_date_8.Substring(6, 2) + "'";
            str_date_8 = "'" + str_date_8 + "'";
            sql = sql.Replace(":ETL_DATE_8", str_date_8);
            sql = sql.Replace(":ETL_DATE_D", str_date_d);
            sql = sql.Replace(":ETL_DATE", str_date);
            sql = sql.Trim();
            if(sql.Length>1)
                sql = sql.Substring(0, sql.Length - 1);//去掉最后的分号
            str_del = str_del.Replace(":ETL_DATE_8", str_date_8);
            str_del = str_del.Replace(":ETL_DATE_D", str_date_d);
            str_del = str_del.Replace(":ETL_DATE", str_date);
            str_del = str_del.Trim();
            if (str_del.Length > 1)
                str_del = str_del.Substring(0, str_del.Length - 1);//去掉最后的分号
            //string result = fundeal(str_conn, str_date_8, str_del, sql);
            string result = "处理中...";
            //MessageBox.Show(result);
            richTextBox3.Text = sql;
            
            try
            {
                teradata db = new teradata(str_conn);
                int i_del = 0;
                int i = 0;
                if (str_del.Length > 0)
                {
                    i_del = db.Exesql(str_del);
                }
                if (sql.Length > 0)
                {
                    i = db.Exesql(sql);
                }
                result= "执行成功，删除 " + i_del + " 条，插入 " + i + " 条";

            }
            catch (Teradata.Client.Provider.TdException ex)
            {
                result = "执行失败," + ex.Message.ToString();
            }
            progressBar1.Style = ProgressBarStyle.Blocks;
            this.progressBar1.Value = progressBar1.Maximum;
            //result = "处理完成";
            MessageBox.Show(result);
            rtb_log.Text += result + "\n";
        }

        /// <summary>  
        /// 线程函数中调用的函数  
        /// </summary>  
        private void ShowProgressBar()
        {
            myHandle = new funHandle(progressForm.SetProgressValue);
            progressForm.ShowDialog();
        }

        /// <summary>  
        /// 线程函数，用于处理调用  
        /// </summary>  
        private void ThreadFun()
        {
            MethodInvoker mi = new MethodInvoker(ShowProgressBar);
            this.BeginInvoke(mi);

            System.Threading.Thread.Sleep(1000); // sleep to show window  
            
            for (int i = 0; i < 1000; ++i)
            {
                System.Threading.Thread.Sleep(5);
                // 这里直接调用代理  
                this.Invoke(this.myHandle, new object[] { (i / 10) });
            }
        } 
    }
}
