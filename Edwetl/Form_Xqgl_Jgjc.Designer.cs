namespace Edwetl
{
    partial class Form_Xqgl_Jgjc
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
            this.btn_opendialog = new System.Windows.Forms.Button();
            this.openFileExcelDialog = new System.Windows.Forms.OpenFileDialog();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.outwin = new System.Windows.Forms.RichTextBox();
            this.bt_check = new System.Windows.Forms.Button();
            this.gv_result = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_view = new System.Windows.Forms.Button();
            this.tx_etl_date = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            ((System.ComponentModel.ISupportInitialize)(this.gv_result)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_opendialog
            // 
            this.btn_opendialog.Location = new System.Drawing.Point(26, 39);
            this.btn_opendialog.Name = "btn_opendialog";
            this.btn_opendialog.Size = new System.Drawing.Size(76, 23);
            this.btn_opendialog.TabIndex = 0;
            this.btn_opendialog.Text = "选择文件";
            this.btn_opendialog.UseVisualStyleBackColor = true;
            this.btn_opendialog.Click += new System.EventHandler(this.btn_openfile);
            // 
            // openFileExcelDialog
            // 
            this.openFileExcelDialog.FileName = "选择需求文档";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(684, 21);
            this.textBox1.TabIndex = 1;
            // 
            // outwin
            // 
            this.outwin.Location = new System.Drawing.Point(12, 414);
            this.outwin.Name = "outwin";
            this.outwin.Size = new System.Drawing.Size(760, 113);
            this.outwin.TabIndex = 2;
            this.outwin.Text = "";
            // 
            // bt_check
            // 
            this.bt_check.Location = new System.Drawing.Point(132, 39);
            this.bt_check.Name = "bt_check";
            this.bt_check.Size = new System.Drawing.Size(75, 23);
            this.bt_check.TabIndex = 3;
            this.bt_check.Text = "执行核对";
            this.bt_check.UseVisualStyleBackColor = true;
            this.bt_check.Click += new System.EventHandler(this.bt_check_Click);
            // 
            // gv_result
            // 
            this.gv_result.AllowUserToAddRows = false;
            this.gv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_result.Location = new System.Drawing.Point(12, 95);
            this.gv_result.Name = "gv_result";
            this.gv_result.RowTemplate.Height = 23;
            this.gv_result.Size = new System.Drawing.Size(760, 313);
            this.gv_result.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "对比结果";
            // 
            // bt_view
            // 
            this.bt_view.Location = new System.Drawing.Point(233, 38);
            this.bt_view.Name = "bt_view";
            this.bt_view.Size = new System.Drawing.Size(75, 23);
            this.bt_view.TabIndex = 6;
            this.bt_view.Text = "查看结果";
            this.bt_view.UseVisualStyleBackColor = true;
            this.bt_view.Click += new System.EventHandler(this.bt_result_view);
            // 
            // tx_etl_date
            // 
            this.tx_etl_date.Location = new System.Drawing.Point(374, 41);
            this.tx_etl_date.Name = "tx_etl_date";
            this.tx_etl_date.Size = new System.Drawing.Size(100, 21);
            this.tx_etl_date.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(327, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "日期";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(535, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 9;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(588, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(122, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form_Xqgl_Jgjc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tx_etl_date);
            this.Controls.Add(this.bt_view);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gv_result);
            this.Controls.Add(this.bt_check);
            this.Controls.Add(this.outwin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_opendialog);
            this.Name = "Form_Xqgl_Jgjc";
            this.Text = "需求检查";
            this.Load += new System.EventHandler(this.Form_Xqgl_Jgjc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_result)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_opendialog;
        private System.Windows.Forms.OpenFileDialog openFileExcelDialog;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox outwin;
        private System.Windows.Forms.Button bt_check;
        private System.Windows.Forms.DataGridView gv_result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_view;
        private System.Windows.Forms.TextBox tx_etl_date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
    }
}