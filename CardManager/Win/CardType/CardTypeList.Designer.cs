namespace Bouwa.ITSP2V31.WIN.CardType
{
    partial class CardTypeList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardTypeList));
            this.dtpEffectDateBegin = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgColumn = new System.Windows.Forms.DataGridView();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.colRowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBatch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPurpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCostType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubmitType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEffectDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOutDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnInsert = new System.Windows.Forms.ToolStripButton();
            this.tbnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tbnView = new System.Windows.Forms.ToolStripButton();
            this.tbnDelete = new System.Windows.Forms.ToolStripButton();
            this.tbnValid = new System.Windows.Forms.ToolStripButton();
            this.tbnInvalid = new System.Windows.Forms.ToolStripButton();
            this.tbnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tbnInit = new System.Windows.Forms.ToolStripButton();
            this.btnInitAgain = new System.Windows.Forms.ToolStripButton();
            this.lblEffectDateEnd = new System.Windows.Forms.Label();
            this.dtpEffectDateEnd = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPurpose = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlCostType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxBatch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpOutDateEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpOutDateBegion = new System.Windows.Forms.DateTimePicker();
            this.ddlRegistType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ddlOrderName = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlOrderBy = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbkEffectTime = new System.Windows.Forms.CheckBox();
            this.cbkEndTime = new System.Windows.Forms.CheckBox();
            this.pager1 = new WindowsApp.MyControl.Pager();
            ((System.ComponentModel.ISupportInitialize)(this.dgColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEffectDateBegin
            // 
            this.dtpEffectDateBegin.Location = new System.Drawing.Point(84, 48);
            this.dtpEffectDateBegin.Name = "dtpEffectDateBegin";
            this.dtpEffectDateBegin.Size = new System.Drawing.Size(120, 21);
            this.dtpEffectDateBegin.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 21);
            this.txtName.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1109, 25);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgColumn
            // 
            this.dgColumn.AllowUserToAddRows = false;
            this.dgColumn.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgColumn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgColumn.Location = new System.Drawing.Point(-4, 3);
            this.dgColumn.Name = "dgColumn";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgColumn.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgColumn.RowTemplate.Height = 23;
            this.dgColumn.Size = new System.Drawing.Size(1023, 472);
            this.dgColumn.TabIndex = 60;
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNumber,
            this.colName,
            this.colBatch,
            this.colPurpose,
            this.colCostType,
            this.colSubmitType,
            this.colStatus,
            this.colEffectDate,
            this.colOutDate});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMain.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvMain.Location = new System.Drawing.Point(25, 98);
            this.dgvMain.Name = "dgvMain";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMain.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(958, 161);
            this.dgvMain.TabIndex = 61;
            this.dgvMain.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMain_CellDoubleClick);
            // 
            // colRowNumber
            // 
            this.colRowNumber.DataPropertyName = "RowNumber";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colRowNumber.DefaultCellStyle = dataGridViewCellStyle5;
            this.colRowNumber.HeaderText = "序号";
            this.colRowNumber.Name = "colRowNumber";
            this.colRowNumber.Width = 35;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "停车卡类型";
            this.colName.Name = "colName";
            this.colName.Width = 300;
            // 
            // colBatch
            // 
            this.colBatch.DataPropertyName = "Batch";
            this.colBatch.HeaderText = "批次";
            this.colBatch.Name = "colBatch";
            this.colBatch.Width = 200;
            // 
            // colPurpose
            // 
            this.colPurpose.DataPropertyName = "Purpose";
            this.colPurpose.HeaderText = "用途";
            this.colPurpose.Name = "colPurpose";
            this.colPurpose.Width = 80;
            // 
            // colCostType
            // 
            this.colCostType.DataPropertyName = "CostType";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colCostType.DefaultCellStyle = dataGridViewCellStyle6;
            this.colCostType.HeaderText = "扣费类型";
            this.colCostType.Name = "colCostType";
            this.colCostType.Width = 80;
            // 
            // colSubmitType
            // 
            this.colSubmitType.DataPropertyName = "SubmitType";
            this.colSubmitType.HeaderText = "注册类型";
            this.colSubmitType.Name = "colSubmitType";
            this.colSubmitType.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.DataPropertyName = "Status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colStatus.DefaultCellStyle = dataGridViewCellStyle7;
            this.colStatus.HeaderText = "状态";
            this.colStatus.Name = "colStatus";
            // 
            // colEffectDate
            // 
            this.colEffectDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colEffectDate.DataPropertyName = "EffectDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "yyyy-MM-dd";
            dataGridViewCellStyle8.NullValue = null;
            this.colEffectDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.colEffectDate.HeaderText = "生效日期";
            this.colEffectDate.Name = "colEffectDate";
            // 
            // colOutDate
            // 
            this.colOutDate.DataPropertyName = "OutDate";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "yyyy-MM-dd";
            this.colOutDate.DefaultCellStyle = dataGridViewCellStyle9;
            this.colOutDate.HeaderText = "最晚到期";
            this.colOutDate.Name = "colOutDate";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnInsert,
            this.tbnUpdate,
            this.tbnView,
            this.tbnDelete,
            this.tbnValid,
            this.tbnInvalid,
            this.tbnRefresh,
            this.tbnInit,
            this.btnInitAgain});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1262, 25);
            this.toolStrip.TabIndex = 63;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tbnInsert
            // 
            this.tbnInsert.Image = ((System.Drawing.Image)(resources.GetObject("tbnInsert.Image")));
            this.tbnInsert.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbnInsert.Name = "tbnInsert";
            this.tbnInsert.Size = new System.Drawing.Size(49, 22);
            this.tbnInsert.Text = "新增";
            this.tbnInsert.ToolTipText = "新增";
            this.tbnInsert.Visible = false;
            this.tbnInsert.Click += new System.EventHandler(this.tbnInsert_Click);
            // 
            // tbnUpdate
            // 
            this.tbnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tbnUpdate.Image")));
            this.tbnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnUpdate.Name = "tbnUpdate";
            this.tbnUpdate.Size = new System.Drawing.Size(49, 22);
            this.tbnUpdate.Text = "修改";
            this.tbnUpdate.Visible = false;
            this.tbnUpdate.Click += new System.EventHandler(this.tbnUpdate_Click);
            // 
            // tbnView
            // 
            this.tbnView.Image = ((System.Drawing.Image)(resources.GetObject("tbnView.Image")));
            this.tbnView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnView.Name = "tbnView";
            this.tbnView.Size = new System.Drawing.Size(49, 22);
            this.tbnView.Tag = "View";
            this.tbnView.Text = "查看";
            this.tbnView.Click += new System.EventHandler(this.tbnView_Click);
            // 
            // tbnDelete
            // 
            this.tbnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tbnDelete.Image")));
            this.tbnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnDelete.Name = "tbnDelete";
            this.tbnDelete.Size = new System.Drawing.Size(49, 22);
            this.tbnDelete.Text = "删除";
            this.tbnDelete.Visible = false;
            this.tbnDelete.Click += new System.EventHandler(this.tbnDelete_Click);
            // 
            // tbnValid
            // 
            this.tbnValid.Image = ((System.Drawing.Image)(resources.GetObject("tbnValid.Image")));
            this.tbnValid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnValid.Name = "tbnValid";
            this.tbnValid.Size = new System.Drawing.Size(49, 22);
            this.tbnValid.Text = "启用";
            this.tbnValid.Visible = false;
            // 
            // tbnInvalid
            // 
            this.tbnInvalid.Image = ((System.Drawing.Image)(resources.GetObject("tbnInvalid.Image")));
            this.tbnInvalid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnInvalid.Name = "tbnInvalid";
            this.tbnInvalid.Size = new System.Drawing.Size(49, 22);
            this.tbnInvalid.Text = "禁用";
            this.tbnInvalid.Visible = false;
            // 
            // tbnRefresh
            // 
            this.tbnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tbnRefresh.Image")));
            this.tbnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnRefresh.Name = "tbnRefresh";
            this.tbnRefresh.Size = new System.Drawing.Size(49, 22);
            this.tbnRefresh.Text = "刷新";
            this.tbnRefresh.Click += new System.EventHandler(this.tbnRefresh_Click);
            // 
            // tbnInit
            // 
            this.tbnInit.Image = ((System.Drawing.Image)(resources.GetObject("tbnInit.Image")));
            this.tbnInit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnInit.Name = "tbnInit";
            this.tbnInit.Size = new System.Drawing.Size(61, 22);
            this.tbnInit.Tag = "Init";
            this.tbnInit.Text = "初始化";
            this.tbnInit.Click += new System.EventHandler(this.tbnInit_Click);
            // 
            // btnInitAgain
            // 
            this.btnInitAgain.Image = ((System.Drawing.Image)(resources.GetObject("btnInitAgain.Image")));
            this.btnInitAgain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInitAgain.Name = "btnInitAgain";
            this.btnInitAgain.Size = new System.Drawing.Size(85, 22);
            this.btnInitAgain.Tag = "InitAgain";
            this.btnInitAgain.Text = "重新初始化";
            this.btnInitAgain.Click += new System.EventHandler(this.btnInitAgain_Click);
            // 
            // lblEffectDateEnd
            // 
            this.lblEffectDateEnd.AutoSize = true;
            this.lblEffectDateEnd.Location = new System.Drawing.Point(233, 55);
            this.lblEffectDateEnd.Name = "lblEffectDateEnd";
            this.lblEffectDateEnd.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEffectDateEnd.Size = new System.Drawing.Size(11, 12);
            this.lblEffectDateEnd.TabIndex = 66;
            this.lblEffectDateEnd.Text = "~";
            // 
            // dtpEffectDateEnd
            // 
            this.dtpEffectDateEnd.Location = new System.Drawing.Point(264, 48);
            this.dtpEffectDateEnd.Name = "dtpEffectDateEnd";
            this.dtpEffectDateEnd.Size = new System.Drawing.Size(120, 21);
            this.dtpEffectDateEnd.TabIndex = 65;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(1109, 47);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 67;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(219, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 69;
            this.label1.Text = "用途：";
            // 
            // ddlPurpose
            // 
            this.ddlPurpose.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPurpose.FormattingEnabled = true;
            this.ddlPurpose.Location = new System.Drawing.Point(263, 26);
            this.ddlPurpose.Name = "ddlPurpose";
            this.ddlPurpose.Size = new System.Drawing.Size(121, 20);
            this.ddlPurpose.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(436, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 18);
            this.label2.TabIndex = 71;
            this.label2.Text = "扣费类型：";
            // 
            // ddlCostType
            // 
            this.ddlCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCostType.FormattingEnabled = true;
            this.ddlCostType.Location = new System.Drawing.Point(506, 26);
            this.ddlCostType.Name = "ddlCostType";
            this.ddlCostType.Size = new System.Drawing.Size(121, 20);
            this.ddlCostType.TabIndex = 72;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(651, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 18);
            this.label3.TabIndex = 74;
            this.label3.Text = "批次：";
            // 
            // tbxBatch
            // 
            this.tbxBatch.Location = new System.Drawing.Point(692, 26);
            this.tbxBatch.Name = "tbxBatch";
            this.tbxBatch.Size = new System.Drawing.Size(120, 21);
            this.tbxBatch.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(435, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 78;
            this.label4.Text = "最晚日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(653, 55);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 77;
            this.label5.Text = "~";
            // 
            // dtpOutDateEnd
            // 
            this.dtpOutDateEnd.Location = new System.Drawing.Point(692, 48);
            this.dtpOutDateEnd.Name = "dtpOutDateEnd";
            this.dtpOutDateEnd.Size = new System.Drawing.Size(120, 21);
            this.dtpOutDateEnd.TabIndex = 76;
            // 
            // dtpOutDateBegion
            // 
            this.dtpOutDateBegion.CustomFormat = "yyyy-MM-dd";
            this.dtpOutDateBegion.Location = new System.Drawing.Point(506, 48);
            this.dtpOutDateBegion.Name = "dtpOutDateBegion";
            this.dtpOutDateBegion.Size = new System.Drawing.Size(120, 21);
            this.dtpOutDateBegion.TabIndex = 75;
            // 
            // ddlRegistType
            // 
            this.ddlRegistType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlRegistType.FormattingEnabled = true;
            this.ddlRegistType.Location = new System.Drawing.Point(917, 26);
            this.ddlRegistType.Name = "ddlRegistType";
            this.ddlRegistType.Size = new System.Drawing.Size(121, 20);
            this.ddlRegistType.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(847, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 18);
            this.label6.TabIndex = 79;
            this.label6.Text = "注册类型：";
            // 
            // ddlOrderName
            // 
            this.ddlOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrderName.FormattingEnabled = true;
            this.ddlOrderName.Location = new System.Drawing.Point(917, 48);
            this.ddlOrderName.Name = "ddlOrderName";
            this.ddlOrderName.Size = new System.Drawing.Size(121, 20);
            this.ddlOrderName.TabIndex = 82;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(871, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 14);
            this.label7.TabIndex = 81;
            this.label7.Text = "排序：";
            // 
            // ddlOrderBy
            // 
            this.ddlOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlOrderBy.FormattingEnabled = true;
            this.ddlOrderBy.Location = new System.Drawing.Point(1048, 48);
            this.ddlOrderBy.Name = "ddlOrderBy";
            this.ddlOrderBy.Size = new System.Drawing.Size(57, 20);
            this.ddlOrderBy.TabIndex = 83;
            // 
            // label8
            // 
            this.label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.label8.Location = new System.Drawing.Point(3, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 18);
            this.label8.TabIndex = 84;
            this.label8.Text = "停车卡类型：";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 18);
            this.label9.TabIndex = 85;
            this.label9.Text = "生效日期：";
            // 
            // cbkEffectTime
            // 
            this.cbkEffectTime.AutoSize = true;
            this.cbkEffectTime.Checked = true;
            this.cbkEffectTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEffectTime.Location = new System.Drawing.Point(390, 50);
            this.cbkEffectTime.Name = "cbkEffectTime";
            this.cbkEffectTime.Size = new System.Drawing.Size(48, 16);
            this.cbkEffectTime.TabIndex = 87;
            this.cbkEffectTime.Text = "为空";
            this.cbkEffectTime.UseVisualStyleBackColor = true;
            this.cbkEffectTime.CheckedChanged += new System.EventHandler(this.cbkEffectTime_CheckedChanged);
            // 
            // cbkEndTime
            // 
            this.cbkEndTime.AutoSize = true;
            this.cbkEndTime.Checked = true;
            this.cbkEndTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbkEndTime.Location = new System.Drawing.Point(817, 50);
            this.cbkEndTime.Name = "cbkEndTime";
            this.cbkEndTime.Size = new System.Drawing.Size(48, 16);
            this.cbkEndTime.TabIndex = 88;
            this.cbkEndTime.Text = "为空";
            this.cbkEndTime.UseVisualStyleBackColor = true;
            this.cbkEndTime.CheckedChanged += new System.EventHandler(this.cbkEffectTime_CheckedChanged);
            // 
            // pager1
            // 
            this.pager1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pager1.Location = new System.Drawing.Point(0, 315);
            this.pager1.Name = "pager1";
            this.pager1.NMax = 0;
            this.pager1.PageCount = 0;
            this.pager1.PageCurrent = 0;
            this.pager1.PageSize = 20;
            this.pager1.Size = new System.Drawing.Size(1262, 30);
            this.pager1.TabIndex = 89;
            this.pager1.EventPaging += new WindowsApp.MyControl.EventPagingHandler(this.pager1_EventPaging);
            // 
            // CardTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 345);
            this.Controls.Add(this.pager1);
            this.Controls.Add(this.cbkEndTime);
            this.Controls.Add(this.cbkEffectTime);
            this.Controls.Add(this.ddlOrderBy);
            this.Controls.Add(this.ddlOrderName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ddlRegistType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpOutDateEnd);
            this.Controls.Add(this.dtpOutDateBegion);
            this.Controls.Add(this.tbxBatch);
            this.Controls.Add(this.ddlCostType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ddlPurpose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.lblEffectDateEnd);
            this.Controls.Add(this.dtpEffectDateEnd);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.dtpEffectDateBegin);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CardTypeList";
            this.Text = "CardTypeList";
            this.Load += new System.EventHandler(this.CardTypeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEffectDateBegin;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgColumn;

        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbnInsert;
        private System.Windows.Forms.ToolStripButton tbnUpdate;
        private System.Windows.Forms.ToolStripButton tbnView;
        private System.Windows.Forms.Label lblEffectDateEnd;
        private System.Windows.Forms.DateTimePicker dtpEffectDateEnd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ToolStripButton tbnDelete;
        private System.Windows.Forms.ToolStripButton tbnValid;
        private System.Windows.Forms.ToolStripButton tbnInvalid;
        private System.Windows.Forms.ToolStripButton tbnRefresh;
        private System.Windows.Forms.ToolStripButton tbnInit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPurpose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCostType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxBatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpOutDateEnd;
        private System.Windows.Forms.DateTimePicker dtpOutDateBegion;
        private System.Windows.Forms.ComboBox ddlRegistType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox ddlOrderName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlOrderBy;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbkEffectTime;
        private System.Windows.Forms.CheckBox cbkEndTime;
        private WindowsApp.MyControl.Pager pager1;
        private System.Windows.Forms.ToolStripButton btnInitAgain;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBatch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPurpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCostType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubmitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEffectDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOutDate;
    }
}