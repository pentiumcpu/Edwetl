namespace Edwetl
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.需求管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.结构检查ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.建表脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调度管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调度查看ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tD知识库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.调度测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.交付物ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eTLAExcelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.perl脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.运维统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.客户模型ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据卸载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.视图脚本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据抽取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tD2ORACLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtd = new System.Windows.Forms.RadioButton();
            this.rboracle = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(454, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始执行";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(25, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(807, 133);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "欢迎使用EDWETL初始化工具，请准备文件dhc-客户管理数据集市-作业设计-20141202.xlsx";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(349, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "选择文件";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.需求管理ToolStripMenuItem,
            this.调度管理ToolStripMenuItem,
            this.交付物ToolStripMenuItem,
            this.数据卸载ToolStripMenuItem,
            this.数据抽取ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1313, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 需求管理ToolStripMenuItem
            // 
            this.需求管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.结构检查ToolStripMenuItem,
            this.建表脚本ToolStripMenuItem});
            this.需求管理ToolStripMenuItem.Name = "需求管理ToolStripMenuItem";
            this.需求管理ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.需求管理ToolStripMenuItem.Text = "需求管理";
            // 
            // 结构检查ToolStripMenuItem
            // 
            this.结构检查ToolStripMenuItem.Name = "结构检查ToolStripMenuItem";
            this.结构检查ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.结构检查ToolStripMenuItem.Text = "结构检查";
            this.结构检查ToolStripMenuItem.Click += new System.EventHandler(this.Open_Xqgl_Jgjc);
            // 
            // 建表脚本ToolStripMenuItem
            // 
            this.建表脚本ToolStripMenuItem.Name = "建表脚本ToolStripMenuItem";
            this.建表脚本ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.建表脚本ToolStripMenuItem.Text = "建表脚本";
            // 
            // 调度管理ToolStripMenuItem
            // 
            this.调度管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.调度查看ToolStripMenuItem,
            this.tD知识库管理ToolStripMenuItem,
            this.调度测试ToolStripMenuItem});
            this.调度管理ToolStripMenuItem.Name = "调度管理ToolStripMenuItem";
            this.调度管理ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.调度管理ToolStripMenuItem.Text = "知识库";
            // 
            // 调度查看ToolStripMenuItem
            // 
            this.调度查看ToolStripMenuItem.Name = "调度查看ToolStripMenuItem";
            this.调度查看ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.调度查看ToolStripMenuItem.Text = "知识库管理";
            this.调度查看ToolStripMenuItem.Click += new System.EventHandler(this.调度查看ToolStripMenuItem_Click);
            // 
            // tD知识库管理ToolStripMenuItem
            // 
            this.tD知识库管理ToolStripMenuItem.Name = "tD知识库管理ToolStripMenuItem";
            this.tD知识库管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tD知识库管理ToolStripMenuItem.Text = "TD知识库管理";
            this.tD知识库管理ToolStripMenuItem.Click += new System.EventHandler(this.Td_zsk);
            // 
            // 调度测试ToolStripMenuItem
            // 
            this.调度测试ToolStripMenuItem.Name = "调度测试ToolStripMenuItem";
            this.调度测试ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.调度测试ToolStripMenuItem.Text = "调度测试";
            // 
            // 交付物ToolStripMenuItem
            // 
            this.交付物ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eTLAExcelToolStripMenuItem,
            this.perl脚本ToolStripMenuItem,
            this.运维统计ToolStripMenuItem,
            this.客户模型ToolStripMenuItem});
            this.交付物ToolStripMenuItem.Name = "交付物ToolStripMenuItem";
            this.交付物ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.交付物ToolStripMenuItem.Text = "交付物";
            // 
            // eTLAExcelToolStripMenuItem
            // 
            this.eTLAExcelToolStripMenuItem.Name = "eTLAExcelToolStripMenuItem";
            this.eTLAExcelToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.eTLAExcelToolStripMenuItem.Text = "作业设计Excel";
            this.eTLAExcelToolStripMenuItem.Click += new System.EventHandler(this.zysj_excel);
            // 
            // perl脚本ToolStripMenuItem
            // 
            this.perl脚本ToolStripMenuItem.Name = "perl脚本ToolStripMenuItem";
            this.perl脚本ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.perl脚本ToolStripMenuItem.Text = "Perl脚本及ETLA Excel";
            this.perl脚本ToolStripMenuItem.Click += new System.EventHandler(this.perl);
            // 
            // 运维统计ToolStripMenuItem
            // 
            this.运维统计ToolStripMenuItem.Name = "运维统计ToolStripMenuItem";
            this.运维统计ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.运维统计ToolStripMenuItem.Text = "运维统计";
            this.运维统计ToolStripMenuItem.Click += new System.EventHandler(this.sxt_excel);
            // 
            // 客户模型ToolStripMenuItem
            // 
            this.客户模型ToolStripMenuItem.Name = "客户模型ToolStripMenuItem";
            this.客户模型ToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.客户模型ToolStripMenuItem.Text = "客户模型";
            this.客户模型ToolStripMenuItem.Click += new System.EventHandler(this.crm_model);
            // 
            // 数据卸载ToolStripMenuItem
            // 
            this.数据卸载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.视图管理ToolStripMenuItem,
            this.视图脚本ToolStripMenuItem});
            this.数据卸载ToolStripMenuItem.Name = "数据卸载ToolStripMenuItem";
            this.数据卸载ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据卸载ToolStripMenuItem.Text = "数据卸载";
            // 
            // 视图管理ToolStripMenuItem
            // 
            this.视图管理ToolStripMenuItem.Name = "视图管理ToolStripMenuItem";
            this.视图管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.视图管理ToolStripMenuItem.Text = "视图管理";
            // 
            // 视图脚本ToolStripMenuItem
            // 
            this.视图脚本ToolStripMenuItem.Name = "视图脚本ToolStripMenuItem";
            this.视图脚本ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.视图脚本ToolStripMenuItem.Text = "视图脚本";
            // 
            // 数据抽取ToolStripMenuItem
            // 
            this.数据抽取ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tD2ORACLEToolStripMenuItem});
            this.数据抽取ToolStripMenuItem.Name = "数据抽取ToolStripMenuItem";
            this.数据抽取ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据抽取ToolStripMenuItem.Text = "数据抽取";
            // 
            // tD2ORACLEToolStripMenuItem
            // 
            this.tD2ORACLEToolStripMenuItem.Name = "tD2ORACLEToolStripMenuItem";
            this.tD2ORACLEToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.tD2ORACLEToolStripMenuItem.Text = "TD_2_ORACLE";
            this.tD2ORACLEToolStripMenuItem.Click += new System.EventHandler(this.tD2ORACLEToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.about);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(858, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "测试";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 245);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1255, 354);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.gv_doubleclick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtd);
            this.groupBox1.Controls.Add(this.rboracle);
            this.groupBox1.Location = new System.Drawing.Point(25, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 39);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库类型";
            // 
            // rbtd
            // 
            this.rbtd.AutoSize = true;
            this.rbtd.Location = new System.Drawing.Point(109, 17);
            this.rbtd.Name = "rbtd";
            this.rbtd.Size = new System.Drawing.Size(71, 16);
            this.rbtd.TabIndex = 1;
            this.rbtd.Text = "Teradata";
            this.rbtd.UseVisualStyleBackColor = true;
            this.rbtd.CheckedChanged += new System.EventHandler(this.rbtd_CheckedChanged);
            // 
            // rboracle
            // 
            this.rboracle.AutoSize = true;
            this.rboracle.Checked = true;
            this.rboracle.Location = new System.Drawing.Point(7, 17);
            this.rboracle.Name = "rboracle";
            this.rboracle.Size = new System.Drawing.Size(59, 16);
            this.rboracle.TabIndex = 0;
            this.rboracle.TabStop = true;
            this.rboracle.Text = "Oracle";
            this.rboracle.UseVisualStyleBackColor = true;
            this.rboracle.CheckedChanged += new System.EventHandler(this.rboracle_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(549, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "检查文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "ALL所有表";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 611);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "EDWETL开发工具";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 调度管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调度查看ToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtd;
        private System.Windows.Forms.RadioButton rboracle;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem 数据抽取ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tD2ORACLEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 需求管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 结构检查ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 建表脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 交付物ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据卸载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 视图脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 调度测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem perl脚本ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eTLAExcelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 运维统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tD知识库管理ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 客户模型ToolStripMenuItem;
    }
}

