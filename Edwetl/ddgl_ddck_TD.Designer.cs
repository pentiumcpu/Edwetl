namespace Edwetl
{
    partial class ddgl_ddck_TD
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mapping_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Src_tab_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.des_tab_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.del_str = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQL_STR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tx_date = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmm2 = new System.Windows.Forms.RadioButton();
            this.cmm1 = new System.Windows.Forms.RadioButton();
            this.btn_detail = new System.Windows.Forms.Button();
            this.rtx_delete = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mapping_id,
            this.batch_id,
            this.Src_tab_name,
            this.des_tab_name,
            this.del_str,
            this.SQL_STR});
            this.dataGridView1.Location = new System.Drawing.Point(327, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(954, 123);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // mapping_id
            // 
            this.mapping_id.DataPropertyName = "mapping_id";
            this.mapping_id.HeaderText = "MappingID";
            this.mapping_id.Name = "mapping_id";
            this.mapping_id.ReadOnly = true;
            // 
            // batch_id
            // 
            this.batch_id.DataPropertyName = "batch_id";
            this.batch_id.HeaderText = "batch_id";
            this.batch_id.Name = "batch_id";
            this.batch_id.ReadOnly = true;
            // 
            // Src_tab_name
            // 
            this.Src_tab_name.DataPropertyName = "src_tab_name";
            this.Src_tab_name.HeaderText = "Src_tab_name";
            this.Src_tab_name.Name = "Src_tab_name";
            this.Src_tab_name.ReadOnly = true;
            // 
            // des_tab_name
            // 
            this.des_tab_name.DataPropertyName = "des_tab_name";
            this.des_tab_name.HeaderText = "des_tab_name";
            this.des_tab_name.Name = "des_tab_name";
            this.des_tab_name.ReadOnly = true;
            // 
            // del_str
            // 
            this.del_str.DataPropertyName = "delete_sql";
            this.del_str.HeaderText = "del_str";
            this.del_str.Name = "del_str";
            this.del_str.ReadOnly = true;
            this.del_str.Width = 300;
            // 
            // SQL_STR
            // 
            this.SQL_STR.DataPropertyName = "sql_str";
            this.SQL_STR.HeaderText = "SQL_STR";
            this.SQL_STR.Name = "SQL_STR";
            this.SQL_STR.ReadOnly = true;
            this.SQL_STR.Width = 500;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(34, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1247, 31);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "Data Source = 103.160.98.49;User ID = T3_CMM_ADM_DEV1;Password = pwd";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "点击我查看任务配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(327, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(327, 367);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(425, 238);
            this.richTextBox2.TabIndex = 4;
            this.richTextBox2.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(532, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "保存SQL";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.Location = new System.Drawing.Point(34, 173);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 432);
            this.treeView1.TabIndex = 6;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(398, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 21);
            this.textBox1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "关键字";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(677, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "检索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(772, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "数据日期";
            // 
            // tx_date
            // 
            this.tx_date.Location = new System.Drawing.Point(774, 367);
            this.tx_date.MaxLength = 8;
            this.tx_date.Name = "tx_date";
            this.tx_date.Size = new System.Drawing.Size(62, 21);
            this.tx_date.TabIndex = 11;
            this.tx_date.Text = "20150101";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(774, 404);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(62, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "执行";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(856, 249);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(425, 349);
            this.richTextBox3.TabIndex = 4;
            this.richTextBox3.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmm2);
            this.groupBox1.Controls.Add(this.cmm1);
            this.groupBox1.Location = new System.Drawing.Point(34, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 89);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "环境";
            // 
            // cmm2
            // 
            this.cmm2.AutoSize = true;
            this.cmm2.Location = new System.Drawing.Point(109, 17);
            this.cmm2.Name = "cmm2";
            this.cmm2.Size = new System.Drawing.Size(53, 16);
            this.cmm2.TabIndex = 1;
            this.cmm2.Text = "开发2";
            this.cmm2.UseVisualStyleBackColor = true;
            this.cmm2.CheckedChanged += new System.EventHandler(this.cmm2_CheckedChanged);
            // 
            // cmm1
            // 
            this.cmm1.AutoSize = true;
            this.cmm1.Checked = true;
            this.cmm1.Location = new System.Drawing.Point(7, 17);
            this.cmm1.Name = "cmm1";
            this.cmm1.Size = new System.Drawing.Size(53, 16);
            this.cmm1.TabIndex = 0;
            this.cmm1.TabStop = true;
            this.cmm1.Text = "开发1";
            this.cmm1.UseVisualStyleBackColor = true;
            this.cmm1.CheckedChanged += new System.EventHandler(this.cmm1_CheckedChanged);
            // 
            // btn_detail
            // 
            this.btn_detail.Location = new System.Drawing.Point(433, 211);
            this.btn_detail.Name = "btn_detail";
            this.btn_detail.Size = new System.Drawing.Size(75, 23);
            this.btn_detail.TabIndex = 14;
            this.btn_detail.Text = " 查看明细";
            this.btn_detail.UseVisualStyleBackColor = true;
            this.btn_detail.Click += new System.EventHandler(this.btn_show_detail);
            // 
            // rtx_delete
            // 
            this.rtx_delete.Location = new System.Drawing.Point(327, 251);
            this.rtx_delete.Name = "rtx_delete";
            this.rtx_delete.Size = new System.Drawing.Size(425, 99);
            this.rtx_delete.TabIndex = 15;
            this.rtx_delete.Text = "";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(856, 208);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 23);
            this.progressBar1.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(327, 352);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 17;
            this.label4.Text = "加工逻辑SQL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "清除逻辑SQL";
            // 
            // rtb_log
            // 
            this.rtb_log.Location = new System.Drawing.Point(34, 622);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.Size = new System.Drawing.Size(1247, 96);
            this.rtb_log.TabIndex = 18;
            this.rtb_log.Text = "";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(988, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "cmm_data_dev1.cmm_etl_tab_mapping_def";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(934, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "配置表名";
            // 
            // ddgl_ddck_TD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1350, 730);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.rtb_log);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.rtx_delete);
            this.Controls.Add(this.btn_detail);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.tx_date);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "ddgl_ddck_TD";
            this.Text = "TD调度管理知识库";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ddgl_ddck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tx_date;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton cmm2;
        private System.Windows.Forms.RadioButton cmm1;
        private System.Windows.Forms.Button btn_detail;
        private System.Windows.Forms.RichTextBox rtx_delete;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mapping_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn batch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Src_tab_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn des_tab_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn del_str;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQL_STR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label6;
    }
}