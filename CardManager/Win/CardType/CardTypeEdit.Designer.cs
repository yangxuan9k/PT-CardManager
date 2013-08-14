namespace Bouwa.ITSP2V31.WIN.CardType
{
    partial class CardTypeEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardTypeEdit));
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnRead = new System.Windows.Forms.ToolStripButton();
            this.tbnSave = new System.Windows.Forms.ToolStripButton();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.ComboBox();
            this.lblMemo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.ddlPurpoe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlCostType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ddlSubmitType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpEffectDate = new System.Windows.Forms.DateTimePicker();
            this.dtpOutDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.lblDefault = new System.Windows.Forms.Label();
            this.tbxDefault = new System.Windows.Forms.TextBox();
            this.lblDefault_Unit = new System.Windows.Forms.Label();
            this.lblMax_Unit = new System.Windows.Forms.Label();
            this.tbxMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlDefault_Status = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ckbIsView = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMemo = new System.Windows.Forms.RichTextBox();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(338, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "停车卡类型：";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnRead,
            this.tbnSave});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(731, 25);
            this.toolStrip.TabIndex = 64;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tbnRead
            // 
            this.tbnRead.Image = ((System.Drawing.Image)(resources.GetObject("tbnRead.Image")));
            this.tbnRead.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbnRead.Name = "tbnRead";
            this.tbnRead.Size = new System.Drawing.Size(73, 22);
            this.tbnRead.Tag = "Init";
            this.tbnRead.Text = "卡初始化";
            this.tbnRead.ToolTipText = "初始化，请放入停车卡！";
            this.tbnRead.Click += new System.EventHandler(this.tbnRead_Click);
            // 
            // tbnSave
            // 
            this.tbnSave.Image = ((System.Drawing.Image)(resources.GetObject("tbnSave.Image")));
            this.tbnSave.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbnSave.Name = "tbnSave";
            this.tbnSave.Size = new System.Drawing.Size(49, 22);
            this.tbnSave.Text = "关闭";
            this.tbnSave.ToolTipText = "保存";
            this.tbnSave.Click += new System.EventHandler(this.tbnSave_Click);
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(101, 28);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(184, 21);
            this.txtBatch.TabIndex = 66;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(57, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 65;
            this.lblName.Text = "批次：";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(373, 84);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(41, 12);
            this.lbl.TabIndex = 67;
            this.lbl.Text = "状态：";
            // 
            // ddlStatus
            // 
            this.ddlStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStatus.FormattingEnabled = true;
            this.ddlStatus.Location = new System.Drawing.Point(420, 80);
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.Size = new System.Drawing.Size(185, 20);
            this.ddlStatus.TabIndex = 68;
            // 
            // lblMemo
            // 
            this.lblMemo.AutoSize = true;
            this.lblMemo.Location = new System.Drawing.Point(57, 190);
            this.lblMemo.Name = "lblMemo";
            this.lblMemo.Size = new System.Drawing.Size(41, 12);
            this.lblMemo.TabIndex = 69;
            this.lblMemo.Text = "备注：";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(420, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 21);
            this.txtName.TabIndex = 1;
            // 
            // ddlPurpoe
            // 
            this.ddlPurpoe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPurpoe.FormattingEnabled = true;
            this.ddlPurpoe.Location = new System.Drawing.Point(101, 55);
            this.ddlPurpoe.Name = "ddlPurpoe";
            this.ddlPurpoe.Size = new System.Drawing.Size(184, 20);
            this.ddlPurpoe.TabIndex = 72;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 71;
            this.label2.Text = "用途：";
            // 
            // ddlCostType
            // 
            this.ddlCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCostType.FormattingEnabled = true;
            this.ddlCostType.Location = new System.Drawing.Point(420, 55);
            this.ddlCostType.Name = "ddlCostType";
            this.ddlCostType.Size = new System.Drawing.Size(185, 20);
            this.ddlCostType.TabIndex = 74;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(350, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 73;
            this.label3.Text = "扣费类型：";
            // 
            // ddlSubmitType
            // 
            this.ddlSubmitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSubmitType.FormattingEnabled = true;
            this.ddlSubmitType.Location = new System.Drawing.Point(101, 81);
            this.ddlSubmitType.Name = "ddlSubmitType";
            this.ddlSubmitType.Size = new System.Drawing.Size(184, 20);
            this.ddlSubmitType.TabIndex = 76;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 75;
            this.label4.Text = "注册类型：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 77;
            this.label5.Text = "生效日期：";
            // 
            // dtpEffectDate
            // 
            this.dtpEffectDate.Location = new System.Drawing.Point(101, 107);
            this.dtpEffectDate.Name = "dtpEffectDate";
            this.dtpEffectDate.Size = new System.Drawing.Size(183, 21);
            this.dtpEffectDate.TabIndex = 78;
            // 
            // dtpOutDate
            // 
            this.dtpOutDate.Location = new System.Drawing.Point(420, 107);
            this.dtpOutDate.Name = "dtpOutDate";
            this.dtpOutDate.Size = new System.Drawing.Size(185, 21);
            this.dtpOutDate.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(349, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 79;
            this.label6.Text = "最晚到期：";
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Location = new System.Drawing.Point(33, 134);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(65, 12);
            this.lblDefault.TabIndex = 81;
            this.lblDefault.Text = "预设金额：";
            // 
            // tbxDefault
            // 
            this.tbxDefault.Location = new System.Drawing.Point(101, 134);
            this.tbxDefault.Name = "tbxDefault";
            this.tbxDefault.Size = new System.Drawing.Size(184, 21);
            this.tbxDefault.TabIndex = 82;
            // 
            // lblDefault_Unit
            // 
            this.lblDefault_Unit.AutoSize = true;
            this.lblDefault_Unit.Location = new System.Drawing.Point(287, 137);
            this.lblDefault_Unit.Name = "lblDefault_Unit";
            this.lblDefault_Unit.Size = new System.Drawing.Size(17, 12);
            this.lblDefault_Unit.TabIndex = 83;
            this.lblDefault_Unit.Text = "元";
            // 
            // lblMax_Unit
            // 
            this.lblMax_Unit.AutoSize = true;
            this.lblMax_Unit.Location = new System.Drawing.Point(613, 137);
            this.lblMax_Unit.Name = "lblMax_Unit";
            this.lblMax_Unit.Size = new System.Drawing.Size(17, 12);
            this.lblMax_Unit.TabIndex = 86;
            this.lblMax_Unit.Text = "元";
            // 
            // tbxMax
            // 
            this.tbxMax.Location = new System.Drawing.Point(420, 134);
            this.tbxMax.Name = "tbxMax";
            this.tbxMax.Size = new System.Drawing.Size(185, 21);
            this.tbxMax.TabIndex = 85;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(349, 137);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(65, 12);
            this.lblMax.TabIndex = 84;
            this.lblMax.Text = "上限金额：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 161);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 87;
            this.label7.Text = "预设卡状态：";
            // 
            // ddlDefault_Status
            // 
            this.ddlDefault_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlDefault_Status.FormattingEnabled = true;
            this.ddlDefault_Status.Location = new System.Drawing.Point(101, 161);
            this.ddlDefault_Status.Name = "ddlDefault_Status";
            this.ddlDefault_Status.Size = new System.Drawing.Size(184, 20);
            this.ddlDefault_Status.TabIndex = 88;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(349, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 89;
            this.label8.Text = "预设可变：";
            // 
            // ckbIsView
            // 
            this.ckbIsView.AutoSize = true;
            this.ckbIsView.Location = new System.Drawing.Point(420, 164);
            this.ckbIsView.Name = "ckbIsView";
            this.ckbIsView.Size = new System.Drawing.Size(15, 14);
            this.ckbIsView.TabIndex = 90;
            this.ckbIsView.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(441, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(287, 12);
            this.label9.TabIndex = 91;
            this.label9.Text = "注：表示在卡初始化时可以对【预设】信息进行修改 ";
            // 
            // txtMemo
            // 
            this.txtMemo.BackColor = System.Drawing.SystemColors.Control;
            this.txtMemo.Location = new System.Drawing.Point(101, 187);
            this.txtMemo.Name = "txtMemo";
            this.txtMemo.Size = new System.Drawing.Size(504, 112);
            this.txtMemo.TabIndex = 92;
            this.txtMemo.Text = "";
            // 
            // CardTypeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 311);
            this.Controls.Add(this.txtMemo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ckbIsView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.ddlDefault_Status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblMax_Unit);
            this.Controls.Add(this.tbxMax);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.lblDefault_Unit);
            this.Controls.Add(this.tbxDefault);
            this.Controls.Add(this.lblDefault);
            this.Controls.Add(this.dtpOutDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpEffectDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ddlSubmitType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ddlCostType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ddlPurpoe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMemo);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.txtBatch);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CardTypeEdit";
            this.Text = "CardTypeEdit";
            this.Load += new System.EventHandler(this.CardTypeEdit_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbnSave;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.ComboBox ddlStatus;
        private System.Windows.Forms.Label lblMemo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox ddlPurpoe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlCostType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlSubmitType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpEffectDate;
        private System.Windows.Forms.DateTimePicker dtpOutDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.TextBox tbxDefault;
        private System.Windows.Forms.Label lblDefault_Unit;
        private System.Windows.Forms.Label lblMax_Unit;
        private System.Windows.Forms.TextBox tbxMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox ddlDefault_Status;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ckbIsView;
        private System.Windows.Forms.ToolStripButton tbnRead;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox txtMemo;
    }
}