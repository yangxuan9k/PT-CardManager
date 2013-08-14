namespace Bouwa.ITSP2V31.Win.CardInfo
{
    partial class History
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(History));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNetwork = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAddressType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOperationUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpEffectDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpEffectDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEffectDateEnd = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cmbChoice = new System.Windows.Forms.ComboBox();
            this.pager1 = new WindowsApp.MyControl.Pager();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnClose});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1247, 25);
            this.toolStrip.TabIndex = 65;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tbnClose
            // 
            this.tbnClose.Image = ((System.Drawing.Image)(resources.GetObject("tbnClose.Image")));
            this.tbnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbnClose.Name = "tbnClose";
            this.tbnClose.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbnClose.Size = new System.Drawing.Size(49, 22);
            this.tbnClose.Text = "关闭";
            this.tbnClose.ToolTipText = "关闭";
            this.tbnClose.Click += new System.EventHandler(this.tbnClose_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNumber,
            this.colOperationTime,
            this.colNetwork,
            this.colAddressType,
            this.colOperationType,
            this.colOperationMemo,
            this.colOperationUser});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvMain.Location = new System.Drawing.Point(25, 98);
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(1191, 161);
            this.dgvMain.TabIndex = 101;
            // 
            // colRowNumber
            // 
            this.colRowNumber.DataPropertyName = "RowNumber";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRowNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.colRowNumber.HeaderText = "序号";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.Width = 35;
            // 
            // colOperationTime
            // 
            this.colOperationTime.DataPropertyName = "OperationTime";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.colOperationTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.colOperationTime.HeaderText = "操作时间";
            this.colOperationTime.Name = "colOperationTime";
            this.colOperationTime.Width = 150;
            // 
            // colNetwork
            // 
            this.colNetwork.DataPropertyName = "NetWork";
            this.colNetwork.HeaderText = "地点";
            this.colNetwork.Name = "colNetwork";
            this.colNetwork.Width = 150;
            // 
            // colAddressType
            // 
            this.colAddressType.DataPropertyName = "AddressType";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colAddressType.DefaultCellStyle = dataGridViewCellStyle4;
            this.colAddressType.HeaderText = "网点类型";
            this.colAddressType.Name = "colAddressType";
            this.colAddressType.Width = 180;
            // 
            // colOperationType
            // 
            this.colOperationType.DataPropertyName = "OperationType";
            this.colOperationType.HeaderText = "操作类型";
            this.colOperationType.Name = "colOperationType";
            this.colOperationType.Width = 80;
            // 
            // colOperationMemo
            // 
            this.colOperationMemo.DataPropertyName = "OperationMemo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colOperationMemo.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOperationMemo.HeaderText = "操作事项";
            this.colOperationMemo.Name = "colOperationMemo";
            this.colOperationMemo.Width = 500;
            // 
            // colOperationUser
            // 
            this.colOperationUser.DataPropertyName = "OperationUser";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colOperationUser.DefaultCellStyle = dataGridViewCellStyle6;
            this.colOperationUser.HeaderText = "操作人";
            this.colOperationUser.Name = "colOperationUser";
            // 
            // dtpEffectDateEnd
            // 
            this.dtpEffectDateEnd.Location = new System.Drawing.Point(310, 29);
            this.dtpEffectDateEnd.Name = "dtpEffectDateEnd";
            this.dtpEffectDateEnd.Size = new System.Drawing.Size(120, 21);
            this.dtpEffectDateEnd.TabIndex = 103;
            // 
            // dtpEffectDateBegin
            // 
            this.dtpEffectDateBegin.Location = new System.Drawing.Point(164, 29);
            this.dtpEffectDateBegin.Name = "dtpEffectDateBegin";
            this.dtpEffectDateBegin.Size = new System.Drawing.Size(120, 21);
            this.dtpEffectDateBegin.TabIndex = 102;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(12, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 18);
            this.label9.TabIndex = 104;
            this.label9.Text = "操作时间：";
            // 
            // lblEffectDateEnd
            // 
            this.lblEffectDateEnd.AutoSize = true;
            this.lblEffectDateEnd.Location = new System.Drawing.Point(290, 33);
            this.lblEffectDateEnd.Name = "lblEffectDateEnd";
            this.lblEffectDateEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEffectDateEnd.Size = new System.Drawing.Size(11, 12);
            this.lblEffectDateEnd.TabIndex = 106;
            this.lblEffectDateEnd.Text = "~";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(436, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 107;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbChoice
            // 
            this.cmbChoice.FormattingEnabled = true;
            this.cmbChoice.Items.AddRange(new object[] {
            "大于",
            "小于",
            "等于",
            "介于"});
            this.cmbChoice.Location = new System.Drawing.Point(76, 29);
            this.cmbChoice.Name = "cmbChoice";
            this.cmbChoice.Size = new System.Drawing.Size(82, 20);
            this.cmbChoice.TabIndex = 108;
            this.cmbChoice.SelectedIndexChanged += new System.EventHandler(this.cmbChoice_SelectedIndexChanged);
            // 
            // pager1
            // 
            this.pager1.Location = new System.Drawing.Point(0, 366);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 20;
            this.pager1.Size = new System.Drawing.Size(791, 30);
            this.pager1.TabIndex = 66;
            this.pager1.EventPaging += new WindowsApp.MyControl.EventPagingHandler(this.pager1_EventPaging);
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 397);
            this.Controls.Add(this.cmbChoice);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEffectDateEnd);
            this.Controls.Add(this.dtpEffectDateEnd);
            this.Controls.Add(this.dtpEffectDateBegin);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "History";
            this.Text = "History";
            this.Load += new System.EventHandler(this.History_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbnClose;
        private WindowsApp.MyControl.Pager pager1;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.DateTimePicker dtpEffectDateEnd;
        private System.Windows.Forms.DateTimePicker dtpEffectDateBegin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEffectDateEnd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbChoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNetwork;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAddressType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOperationUser;
    }
}