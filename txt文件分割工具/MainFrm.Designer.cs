namespace txt文件分割工具
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose (bool disposing)
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose ();
            }
            base.Dispose (disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listInfo = new System.Windows.Forms.ListBox();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nupChose = new System.Windows.Forms.NumericUpDown();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbProgressInfo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnCombine = new System.Windows.Forms.Button();
            this.btnClearChose = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.FIleList = new System.Windows.Forms.ListBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nupChose)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenFile.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOpenFile.Location = new System.Drawing.Point(568, 21);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 32);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "打开";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "打开或输入文件地址";
            // 
            // listInfo
            // 
            this.listInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listInfo.BackColor = System.Drawing.SystemColors.MenuText;
            this.listInfo.ForeColor = System.Drawing.SystemColors.Menu;
            this.listInfo.FormattingEnabled = true;
            this.listInfo.ItemHeight = 12;
            this.listInfo.Location = new System.Drawing.Point(6, 122);
            this.listInfo.Name = "listInfo";
            this.listInfo.Size = new System.Drawing.Size(637, 184);
            this.listInfo.TabIndex = 2;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFilePath.Location = new System.Drawing.Point(174, 24);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(388, 29);
            this.txtFilePath.TabIndex = 3;
            this.txtFilePath.Leave += new System.EventHandler(this.nupChose_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择分割等份";
            // 
            // nupChose
            // 
            this.nupChose.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nupChose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nupChose.Location = new System.Drawing.Point(174, 65);
            this.nupChose.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupChose.Name = "nupChose";
            this.nupChose.Size = new System.Drawing.Size(53, 29);
            this.nupChose.TabIndex = 5;
            this.nupChose.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupChose.ValueChanged += new System.EventHandler(this.nupChose_ValueChanged);
            // 
            // btnEnter
            // 
            this.btnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnter.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnEnter.Location = new System.Drawing.Point(568, 62);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 32);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "确定";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbInfo.Location = new System.Drawing.Point(242, 69);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 21);
            this.lbInfo.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(659, 353);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listInfo);
            this.tabPage1.Controls.Add(this.lbInfo);
            this.tabPage1.Controls.Add(this.btnOpenFile);
            this.tabPage1.Controls.Add(this.btnEnter);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.nupChose);
            this.tabPage1.Controls.Add(this.txtFilePath);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(651, 327);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "分割";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbProgressInfo);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.listBox1);
            this.tabPage2.Controls.Add(this.btnCombine);
            this.tabPage2.Controls.Add(this.btnClearChose);
            this.tabPage2.Controls.Add(this.btnClearAll);
            this.tabPage2.Controls.Add(this.btnAdd);
            this.tabPage2.Controls.Add(this.FIleList);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(651, 327);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "合并";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbProgressInfo
            // 
            this.lbProgressInfo.AutoSize = true;
            this.lbProgressInfo.Location = new System.Drawing.Point(247, 289);
            this.lbProgressInfo.Name = "lbProgressInfo";
            this.lbProgressInfo.Size = new System.Drawing.Size(17, 12);
            this.lbProgressInfo.TabIndex = 5;
            this.lbProgressInfo.Text = "0%";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "当前合并进度:";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(158, 154);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(485, 112);
            this.listBox1.TabIndex = 4;
            // 
            // btnCombine
            // 
            this.btnCombine.Location = new System.Drawing.Point(25, 228);
            this.btnCombine.Name = "btnCombine";
            this.btnCombine.Size = new System.Drawing.Size(116, 79);
            this.btnCombine.TabIndex = 3;
            this.btnCombine.Text = "确定合并";
            this.btnCombine.UseVisualStyleBackColor = true;
            this.btnCombine.Click += new System.EventHandler(this.btnCombine_Click);
            // 
            // btnClearChose
            // 
            this.btnClearChose.Location = new System.Drawing.Point(25, 92);
            this.btnClearChose.Name = "btnClearChose";
            this.btnClearChose.Size = new System.Drawing.Size(116, 35);
            this.btnClearChose.TabIndex = 2;
            this.btnClearChose.Text = "清除选择";
            this.btnClearChose.UseVisualStyleBackColor = true;
            this.btnClearChose.Click += new System.EventHandler(this.btnClearChose_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(25, 160);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(116, 35);
            this.btnClearAll.TabIndex = 2;
            this.btnClearAll.Text = "清空文件";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(25, 24);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(116, 35);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "添加文件";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // FIleList
            // 
            this.FIleList.FormattingEnabled = true;
            this.FIleList.ItemHeight = 12;
            this.FIleList.Location = new System.Drawing.Point(158, 24);
            this.FIleList.Name = "FIleList";
            this.FIleList.Size = new System.Drawing.Size(485, 124);
            this.FIleList.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 353);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainFrm";
            this.Text = "txt分割工具";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainFrm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.nupChose)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listInfo;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nupChose;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnCombine;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListBox FIleList;
        private System.Windows.Forms.Button btnClearChose;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbProgressInfo;
        private System.Windows.Forms.Label label3;
    }
}

