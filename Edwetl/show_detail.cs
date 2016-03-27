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
using Edwetl.src.dao;
namespace Edwetl
{
    public partial class show_detail : Form
    {
        public show_detail()
        {
            InitializeComponent();
            init(); 
        }
        public show_detail(string v_mapping)
        {
            InitializeComponent();
            set_mapping_id(v_mapping);
            init();
        }
        public show_detail(string v_mapping,string v_lx)
        {
            InitializeComponent();
            set_mapping_id(v_mapping);
            set_lx(v_lx);
            init();
        }
        private string _lx;
        private string _mapping_id;
        public void set_lx(string var_lx)
        {
            this._lx = var_lx;
        }
        public  void set_mapping_id(string var_mapping_id)
        {
            this._mapping_id = var_mapping_id;
        }
        //初始化列表
        public void set_proce_list()
        {
            comboBox1.Items.Clear();
            try
            {
                procedures_DAO proce = new procedures_DAO(_lx);
                DataSet ds = proce.getdsbysql();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string dot = "";
                    if (dr[0].ToString().Length * dr[1].ToString().Length == 0)
                    {
                        dot = "";
                    }
                    else
                    {
                        dot = ".";
                    }
                    comboBox1.Items.Add(dr[0].ToString() + dot + dr[1].ToString());
                }
            }
            catch { };
            comboBox1.Items.Add("BTEQ");
        }
        public string get_mapping_id()
        {
            return this._mapping_id;
        }
        public void init()
        {
            set_proce_list();
            etl_tab_mapping_def_tdDAO etldao = new etl_tab_mapping_def_tdDAO(_lx);
            etl_tab_mapping_def etld = etldao.get_etl_map_defbympping_id(this._mapping_id);
            lb_mapping_id.Text = etld.get_mapping_id().ToString();
            tx_map_id.Text = etld.get_mapping_id().ToString();
            tx_batch_id.Text = etld.get_batch_id().ToString();
            tx_sys_code.Text = etld.get_sys_code();
            tx_src_tab.Text = etld.get_src_tab_name();
            tx_des_tab.Text = etld.get_des_tab_name();
            tx_conv_type.Text = etld.get_conv_type();
            tx_conv_desc.Text = etld.get_conv_type_desc();
            rtx_delete.Text = etld.get_delete_sql();
            rtx_sql.Text = etld.get_sql_str();
            tx_job_name.Text = etld.get_job_name();
            tx_job_desc.Text = etld.get_job_desc();
            tx_map_desc.Text = etld.get_mapping_desc();
            tx_remark.Text = etld.get_remark();
            tx_st_date.Text = etld.get_st_date();
            tx_mnt_date.Text = etld.get_mnt_date();
            tx_end_date.Text = etld.get_end_date();
            
            comboBox1.SelectedItem = etld.get_job_name();
            reset(false);
            etld = null;
            etldao = null;
        }
        public void set_tb_mapping_id(string v_mapping_id)
        {
            tx_map_id.Text = v_mapping_id;
        }
        private void add_click(object sender, EventArgs e)
        {
            set_proce_list();
            init();
            lb_mapping_id.Text = "新增";
            tx_map_id.Text = (int.Parse(tx_map_id.Text) + 1).ToString();
            rtx_delete.Text = "请补充";
            rtx_sql.Text = "请补充";
            reset(true);
            rtx_delete.BackColor = Color.White;
            rtx_sql.BackColor = Color.White;
        }
        private void modify_Click(object sender, EventArgs e)
        {
            set_proce_list();
            init();
            
            reset(true);
            rtx_delete.BackColor = Color.White;
            rtx_sql.BackColor = Color.White;
        }
        private void save_click(object sender, EventArgs e)
        {
            save();
            reset(false);
            rtx_delete.BackColor = BackColor;
            rtx_sql.BackColor = BackColor;
            
        }
        
        private void save()
        {
            string str_mapping_id_key = lb_mapping_id.Text;
            etl_tab_mapping_def etld = new etl_tab_mapping_def();
            etl_tab_mapping_def_tdDAO etldao = new etl_tab_mapping_def_tdDAO(_lx);
            etld.set_mapping_id(int.Parse(tx_map_id.Text));
            etld.set_batch_id(int.Parse(tx_batch_id.Text));
            etld.set_sys_code(tx_sys_code.Text);
            etld.set_src_tab_name(tx_src_tab.Text);
            etld.set_des_tab_name(tx_des_tab.Text);
            etld.set_conv_type(tx_conv_type.Text);
            etld.set_conv_type_desc(tx_conv_desc.Text);
            etld.set_delete_sql(rtx_delete.Text.Length == 0 ? "" : rtx_delete.Text);
            etld.set_sql_str(rtx_sql.Text.Length == 0 ? "" : rtx_sql.Text);
            //etld.set_job_name(tx_job_name.Text);
            etld.set_job_name(comboBox1.SelectedItem.ToString());
            etld.set_job_desc(tx_job_desc.Text);
            etld.set_mapping_desc(tx_map_desc.Text);
            etld.set_remark(tx_remark.Text);
            etld.set_st_date(tx_st_date.Text);
            etld.set_mnt_date(tx_mnt_date.Text);
            etld.set_end_date(tx_end_date.Text);
            if (str_mapping_id_key != "新增")
            {
                etldao.updateby_mapping_id(etld, str_mapping_id_key);
                lb_mapping_id.Text = tx_map_id.Text;
            }
            else
            {
                etldao.insert(etld, str_mapping_id_key);
                lb_mapping_id.Text = tx_map_id.Text;
            }
            MessageBox.Show("保存成功！");
        }
        private void reset(Boolean bl_visual)
        {
            //tx_map_id.Enabled = bl_visual;
            //tx_batch_id.Enabled = bl_visual;
            //tx_sys_code.Enabled = bl_visual;
            //tx_src_tab.Enabled = bl_visual;
            //tx_des_tab.Enabled = bl_visual;
            //tx_conv_type.Enabled = bl_visual;
            //tx_conv_desc.Enabled = bl_visual;
            //rtx_delete.Enabled = bl_visual;
            //rtx_sql.Enabled = bl_visual;
            //tx_job_name.Enabled = bl_visual;
            //tx_job_desc.Enabled = bl_visual;
            //tx_map_desc.Enabled = bl_visual;
            //tx_remark.Enabled = bl_visual;
            //tx_st_date.Enabled = bl_visual;
            //tx_mnt_date.Enabled = bl_visual;
            //tx_end_date.Enabled = bl_visual;
            //comboBox1.Enabled = bl_visual;
            //button1.Enabled = !bl_visual;
            //button2.Enabled = bl_visual;
            //btn_add.Enabled = !bl_visual;
            
            //
            tx_map_id.ReadOnly = !bl_visual;
            tx_batch_id.ReadOnly = !bl_visual;
            tx_sys_code.ReadOnly = !bl_visual;
            tx_src_tab.ReadOnly = !bl_visual;
            tx_des_tab.ReadOnly = !bl_visual;
            tx_conv_type.ReadOnly = !bl_visual;
            tx_conv_desc.ReadOnly = !bl_visual;
            rtx_delete.ReadOnly = !bl_visual;
            rtx_sql.ReadOnly = !bl_visual;
                
            //rtx_delete.r
            tx_job_name.ReadOnly = !bl_visual;
            tx_job_desc.ReadOnly = !bl_visual;
            tx_map_desc.ReadOnly = !bl_visual;
            tx_remark.ReadOnly = !bl_visual;
            tx_st_date.ReadOnly = !bl_visual;
            tx_mnt_date.ReadOnly = !bl_visual;
            tx_end_date.ReadOnly = !bl_visual;
            
            comboBox1.Enabled = bl_visual;
            button1.Enabled = !bl_visual;
            button2.Enabled = bl_visual;
            btn_add.Enabled = !bl_visual;
        }
    }
}
