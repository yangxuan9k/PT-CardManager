namespace Bouwa.ITSP2V31.WIN.CardInfo
{
    partial class List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(List));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnView = new System.Windows.Forms.ToolStripButton();
            this.tbnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnReadCard = new System.Windows.Forms.ToolStripButton();
            this.tsbHistory = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxBatch = new System.Windows.Forms.TextBox();
            this.tbtCardType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCardNo = new System.Windows.Forms.TextBox();
            this.ddlRegistType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlCostType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlPurpose = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCardType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cloMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colChargesDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTimes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlOrderBy = new System.Windows.Forms.ComboBox();
            this.ddlOrderName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pager1 = new WindowsApp.MyControl.Pager();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnView,
            this.tbnRefresh,
            this.btnReadCard,
            this.tsbHistory});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1169, 25);
            this.toolStrip.TabIndex = 64;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tbnView
            // 
            this.tbnView.Image = ((System.Drawing.Image)(resources.GetObject("tbnView.Image")));
            this.tbnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnView.Name = "tbnView";
            this.tbnView.Size = new System.Drawing.Size(49, 22);
            this.tbnView.Text = "查看";
            this.tbnView.Click += new System.EventHandler(this.tbnView_Click);
            // 
            // tbnRefresh
            // 
            this.tbnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbnRefresh.Image")));
            this.tbnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnRefresh.Name = "tbnRefresh";
            this.tbnRefresh.Size = new System.Drawing.Size(49, 22);
            this.tbnRefresh.Text = "刷新";
            this.tbnRefresh.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReadCard
            // 
            this.btnReadCard.BackColor = System.Drawing.SystemColors.Control;
            this.btnReadCard.Image = ((System.Drawing.Image)(resources.GetObject("btnReadCard.Image")));
            this.btnReadCard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReadCard.Name = "btnReadCard";
            this.btnReadCard.Size = new System.Drawing.Size(49, 22);
            this.btnReadCard.Text = "读卡";
            this.btnReadCard.Click += new System.EventHandler(this.btnReadCard_Click);
            // 
            // tsbHistory
            // 
            this.tsbHistory.Image = ((System.Drawing.Image)(resources.GetObject("tsbHistory.Image")));
            this.tsbHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbHistory.Name = "tsbHistory";
            this.tsbHistory.Size = new System.Drawing.Size(61, 22);
            this.tsbHistory.Text = "卡历史";
            this.tsbHistory.Click += new System.EventHandler(this.tsbHistory_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(195, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 89;
            this.label8.Text = "停车卡类型：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(425, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 88;
            this.label3.Text = "批次：";
            // 
            // tbxBatch
            // 
            this.tbxBatch.Location = new System.Drawing.Point(468, 26);
            this.tbxBatch.Name = "tbxBatch";
            this.tbxBatch.Size = new System.Drawing.Size(120, 21);
            this.tbxBatch.TabIndex = 87;
            // 
            // tbtCardType
            // 
            this.tbtCardType.Location = new System.Drawing.Point(272, 26);
            this.tbtCardType.Name = "tbtCardType";
            this.tbtCardType.Size = new System.Drawing.Size(120, 21);
            this.tbtCardType.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 91;
            this.label1.Text = "卡面编号：";
            // 
            // tbxCardNo
            // 
            this.tbxCardNo.Location = new System.Drawing.Point(68, 26);
            this.tbxCardNo.Name = "tbxCardNo";
            this.tbxCardNo.Size = new System.Drawing.Size(120, 21);
            this.tbxCardNo.TabIndex = 90;
            // 
            // ddlRegistType
            // 
            this.ddlRegistType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRegistType.FormattingEnabled = true;
            this.ddlRegistType.Location = new System.Drawing.Point(468, 48);
            this.ddlRegistType.Name = "ddlRegistType";
            this.ddlRegistType.Size = new System.Drawing.Size(121, 20);
            this.ddlRegistType.TabIndex = 97;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(401, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 18);
            this.label6.TabIndex = 96;
            this.label6.Text = "注册类型：";
            // 
            // ddlCostType
            // 
            this.ddlCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCostType.FormattingEnabled = true;
            this.ddlCostType.Location = new System.Drawing.Point(272, 48);
            this.ddlCostType.Name = "ddlCostType";
            this.ddlCostType.Size = new System.Drawing.Size(121, 20);
            this.ddlCostType.TabIndex = 95;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(207, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 94;
            this.label2.Text = "扣费类型：";
            // 
            // ddlPurpose
            // 
            this.ddlPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPurpose.FormattingEnabled = true;
            this.ddlPurpose.Location = new System.Drawing.Point(68, 48);
            this.ddlPurpose.Name = "ddlPurpose";
            this.ddlPurpose.Size = new System.Drawing.Size(121, 20);
            this.ddlPurpose.TabIndex = 93;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(27, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 18);
            this.label4.TabIndex = 92;
            this.label4.Text = "用途：";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(835, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 98;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(835, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 99;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.colNo,
            this.colCardType,
            this.colBatch,
            this.colPurpose,
            this.colCostType,
            this.colSubmitType,
            this.colEndDate,
            this.cloMoney,
            this.colChargesDate,
            this.colTimes,
            this.colStatus});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgvMain.Location = new System.Drawing.Point(25, 98);
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(974, 161);
            this.dgvMain.TabIndex = 100;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
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
            // colNo
            // 
            this.colNo.DataPropertyName = "no";
            this.colNo.HeaderText = "卡面编号";
            this.colNo.Name = "colNo";
            this.colNo.Width = 200;
            // 
            // colCardType
            // 
            this.colCardType.DataPropertyName = "CardType";
            this.colCardType.HeaderText = "停车卡类型";
            this.colCardType.Name = "colCardType";
            this.colCardType.Width = 300;
            // 
            // colBatch
            // 
            this.colBatch.DataPropertyName = "batch";
            this.colBatch.HeaderText = "批次";
            this.colBatch.Name = "colBatch";
            this.colBatch.Width = 200;
            // 
            // colPurpose
            // 
            this.colPurpose.DataPropertyName = "purpose";
            this.colPurpose.HeaderText = "用途";
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.Width = 80;
            // 
            // colCostType
            // 
            this.colCostType.DataPropertyName = "cost_type";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCostType.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCostType.HeaderText = "扣费类型";
            this.colCostType.Name = "colCostType";
            this.colCostType.Width = 80;
            // 
            // colSubmitType
            // 
            this.colSubmitType.DataPropertyName = "submit_type";
            this.colSubmitType.HeaderText = "注册类型";
            this.colSubmitType.Name = "colSubmitType";
            this.colSubmitType.Width = 80;
            // 
            // colEndDate
            // 
            this.colEndDate.DataPropertyName = "end_date";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "yyyy-MM-dd";
            this.colEndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.colEndDate.HeaderText = "最晚到期";
            this.colEndDate.Name = "colEndDate";
            // 
            // cloMoney
            // 
            this.cloMoney.DataPropertyName = "money";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.cloMoney.DefaultCellStyle = dataGridViewCellStyle5;
            this.cloMoney.HeaderText = "剩余金额(元)";
            this.cloMoney.Name = "cloMoney";
            // 
            // colChargesDate
            // 
            this.colChargesDate.DataPropertyName = "charges_date";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colChargesDate.DefaultCellStyle = dataGridViewCellStyle6;
            this.colChargesDate.HeaderText = "剩余时间(分钟)";
            this.colChargesDate.Name = "colChargesDate";
            // 
            // colTimes
            // 
            this.colTimes.DataPropertyName = "times";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTimes.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTimes.HeaderText = "剩余次数";
            this.colTimes.Name = "colTimes";
            this.colTimes.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "status";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle8;
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(647, 26);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(121, 20);
            this.ddlStatus.TabIndex = 102;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(603, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 18);
            this.label5.TabIndex = 101;
            this.label5.Text = "状态：";
            // 
            // ddlOrderBy
            // 
            this.ddlOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrderBy.FormattingEnabled = true;
            this.ddlOrderBy.Location = new System.Drawing.Point(774, 48);
            this.ddlOrderBy.Name = "ddlOrderBy";
            this.ddlOrderBy.Size = new System.Drawing.Size(57, 20);
            this.ddlOrderBy.TabIndex = 106;
            // 
            // ddlOrderName
            // 
            this.ddlOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrderName.FormattingEnabled = true;
            this.ddlOrderName.Location = new System.Drawing.Point(647, 48);
            this.ddlOrderName.Name = "ddlOrderName";
            this.ddlOrderName.Size = new System.Drawing.Size(121, 20);
            this.ddlOrderName.TabIndex = 105;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(604, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 104;
            this.label7.Text = "排序：";
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager1.Location = new System.Drawing.Point(0, 343);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 1;
            this.pager1.PageSize = 20;
            this.pager1.Size = new System.Drawing.Size(1169, 30);
            this.pager1.TabIndex = 103;
            this.pager1.EventPaging += new WindowsApp.MyControl.EventPagingHandler(this.pager1_EventPaging);
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 373);
            this.Controls.Add(this.ddlOrderBy);
            this.Controls.Add(this.ddlOrderName);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlRegistType);
            this.Controls.Add(this.ddlCostType);
            this.Controls.Add(this.ddlPurpose);
            this.Controls.Add(this.tbxCardNo);
            this.Controls.Add(this.tbxBatch);
            this.Controls.Add(this.tbtCardType);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "List";
            this.Text = "List";
            this.Load += new System.EventHandler(this.List_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbnView;
        private System.Windows.Forms.ToolStripButton tbnRefresh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxBatch;
        private System.Windows.Forms.TextBox tbtCardType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCardNo;
        private System.Windows.Forms.ComboBox ddlRegistType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlCostType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.Label label5;
        private WindowsApp.MyControl.Pager pager1;
        private System.Windows.Forms.ToolStripButton btnReadCard;
        private System.Windows.Forms.ComboBox ddlOrderBy;
        private System.Windows.Forms.ComboBox ddlOrderName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton tsbHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cloMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChargesDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTimes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
    }
}