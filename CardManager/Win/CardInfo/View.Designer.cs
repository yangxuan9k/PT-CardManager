namespace Bouwa.ITSP2V31.Win.CardInfo
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tbnHistory = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnChangeCard = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblDefault_Unit = new System.Windows.Forms.Label();
            this.btnChargeValue = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMax_Unit = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUnit = new System.Windows.Forms.Label();
            this.tbxMax = new System.Windows.Forms.TextBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.dtpEffectDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.ddlCostType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ddlSubmitType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ddlPurpoe = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBatch = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbxDefault = new System.Windows.Forms.TextBox();
            this.lblDefault = new System.Windows.Forms.Label();
            this.ddlDefault_Status = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxCardType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbxCardNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnHistory});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(410, 25);
            this.toolStrip.TabIndex = 65;
            this.toolStrip.Text = "ToolStrip";
            // 
            // tbnHistory
            // 
            this.tbnHistory.Image = ((System.Drawing.Image)(resources.GetObject("tbnHistory.Image")));
            this.tbnHistory.ImageTransparentColor = System.Drawing.Color.Black;
            this.tbnHistory.Name = "tbnHistory";
            this.tbnHistory.Size = new System.Drawing.Size(61, 22);
            this.tbnHistory.Text = "卡历史";
            this.tbnHistory.ToolTipText = "卡历史";
            this.tbnHistory.Click += new System.EventHandler(this.tbnHistory_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(391, 335);
            this.tabControl1.TabIndex = 66;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage1.Controls.Add(this.btnChangeCard);
            this.tabPage1.Controls.Add(this.btnBack);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.lblDefault_Unit);
            this.tabPage1.Controls.Add(this.btnChargeValue);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Location = new System.Drawing.Point(4, 21);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(383, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "卡信息";
            // 
            // btnChangeCard
            // 
            this.btnChangeCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnChangeCard.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChangeCard.Location = new System.Drawing.Point(321, 202);
            this.btnChangeCard.Name = "btnChangeCard";
            this.btnChangeCard.Size = new System.Drawing.Size(56, 44);
            this.btnChangeCard.TabIndex = 87;
            this.btnChangeCard.Tag = "0";
            this.btnChangeCard.Text = "申请换卡";
            this.btnChangeCard.UseVisualStyleBackColor = false;
            this.btnChangeCard.Click += new System.EventHandler(this.btnChangeCard_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnBack.Location = new System.Drawing.Point(321, 160);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(56, 41);
            this.btnBack.TabIndex = 86;
            this.btnBack.Text = "退卡";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnReset.Location = new System.Drawing.Point(321, 116);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(56, 42);
            this.btnReset.TabIndex = 85;
            this.btnReset.Text = "卡重置";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblDefault_Unit
            // 
            this.lblDefault_Unit.AutoSize = true;
            this.lblDefault_Unit.Location = new System.Drawing.Point(289, 71);
            this.lblDefault_Unit.Name = "lblDefault_Unit";
            this.lblDefault_Unit.Size = new System.Drawing.Size(17, 12);
            this.lblDefault_Unit.TabIndex = 84;
            this.lblDefault_Unit.Text = "元";
            // 
            // btnChargeValue
            // 
            this.btnChargeValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(165)))), ((int)(((byte)(165)))));
            this.btnChargeValue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnChargeValue.Location = new System.Drawing.Point(321, 45);
            this.btnChargeValue.Name = "btnChargeValue";
            this.btnChargeValue.Size = new System.Drawing.Size(56, 44);
            this.btnChargeValue.TabIndex = 10;
            this.btnChargeValue.Text = "充值";
            this.btnChargeValue.UseVisualStyleBackColor = false;
            this.btnChargeValue.Click += new System.EventHandler(this.btnChargeValue_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMax_Unit);
            this.panel2.Controls.Add(this.dtpEndDate);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblUnit);
            this.panel2.Controls.Add(this.tbxMax);
            this.panel2.Controls.Add(this.lblMax);
            this.panel2.Controls.Add(this.dtpEffectDate);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.ddlCostType);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.ddlSubmitType);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.ddlPurpoe);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtBatch);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Location = new System.Drawing.Point(7, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(308, 180);
            this.panel2.TabIndex = 9;
            // 
            // lblMax_Unit
            // 
            this.lblMax_Unit.AutoSize = true;
            this.lblMax_Unit.Location = new System.Drawing.Point(282, 138);
            this.lblMax_Unit.Name = "lblMax_Unit";
            this.lblMax_Unit.Size = new System.Drawing.Size(17, 12);
            this.lblMax_Unit.TabIndex = 92;
            this.lblMax_Unit.Text = "元";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(98, 112);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(183, 21);
            this.dtpEndDate.TabIndex = 91;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 90;
            this.label9.Text = "最晚到期：";
            // 
            // lblUnit
            // 
            this.lblUnit.AutoSize = true;
            this.lblUnit.Location = new System.Drawing.Point(308, 122);
            this.lblUnit.Name = "lblUnit";
            this.lblUnit.Size = new System.Drawing.Size(0, 12);
            this.lblUnit.TabIndex = 89;
            // 
            // tbxMax
            // 
            this.tbxMax.Location = new System.Drawing.Point(98, 135);
            this.tbxMax.Name = "tbxMax";
            this.tbxMax.Size = new System.Drawing.Size(183, 21);
            this.tbxMax.TabIndex = 88;
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(27, 138);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(65, 12);
            this.lblMax.TabIndex = 87;
            this.lblMax.Text = "上限金额：";
            this.lblMax.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtpEffectDate
            // 
            this.dtpEffectDate.Location = new System.Drawing.Point(97, 89);
            this.dtpEffectDate.Name = "dtpEffectDate";
            this.dtpEffectDate.Size = new System.Drawing.Size(183, 21);
            this.dtpEffectDate.TabIndex = 86;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 85;
            this.label8.Text = "生效日期：";
            // 
            // ddlCostType
            // 
            this.ddlCostType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlCostType.FormattingEnabled = true;
            this.ddlCostType.Location = new System.Drawing.Point(97, 68);
            this.ddlCostType.Name = "ddlCostType";
            this.ddlCostType.Size = new System.Drawing.Size(183, 20);
            this.ddlCostType.TabIndex = 84;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 83;
            this.label7.Text = "扣费类型：";
            // 
            // ddlSubmitType
            // 
            this.ddlSubmitType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSubmitType.FormattingEnabled = true;
            this.ddlSubmitType.Location = new System.Drawing.Point(97, 47);
            this.ddlSubmitType.Name = "ddlSubmitType";
            this.ddlSubmitType.Size = new System.Drawing.Size(183, 20);
            this.ddlSubmitType.TabIndex = 82;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 81;
            this.label5.Text = "注册类型：";
            // 
            // ddlPurpoe
            // 
            this.ddlPurpoe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPurpoe.FormattingEnabled = true;
            this.ddlPurpoe.Location = new System.Drawing.Point(97, 25);
            this.ddlPurpoe.Name = "ddlPurpoe";
            this.ddlPurpoe.Size = new System.Drawing.Size(183, 20);
            this.ddlPurpoe.TabIndex = 80;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(51, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 79;
            this.label6.Text = "用途：";
            // 
            // txtBatch
            // 
            this.txtBatch.Location = new System.Drawing.Point(98, 3);
            this.txtBatch.Name = "txtBatch";
            this.txtBatch.Size = new System.Drawing.Size(183, 21);
            this.txtBatch.TabIndex = 78;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(51, 6);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 77;
            this.lblName.Text = "批次：";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(6, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(371, 19);
            this.panel1.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(4, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "卡类型信息";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tbxDefault);
            this.panel3.Controls.Add(this.lblDefault);
            this.panel3.Controls.Add(this.ddlDefault_Status);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbxCardType);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.tbxCardNum);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(7, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(308, 95);
            this.panel3.TabIndex = 11;
            // 
            // tbxDefault
            // 
            this.tbxDefault.Location = new System.Drawing.Point(98, 68);
            this.tbxDefault.Name = "tbxDefault";
            this.tbxDefault.Size = new System.Drawing.Size(183, 21);
            this.tbxDefault.TabIndex = 7;
            // 
            // lblDefault
            // 
            this.lblDefault.AutoSize = true;
            this.lblDefault.Location = new System.Drawing.Point(27, 71);
            this.lblDefault.Name = "lblDefault";
            this.lblDefault.Size = new System.Drawing.Size(65, 12);
            this.lblDefault.TabIndex = 6;
            this.lblDefault.Text = "剩余金额：";
            this.lblDefault.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ddlDefault_Status
            // 
            this.ddlDefault_Status.FormattingEnabled = true;
            this.ddlDefault_Status.Location = new System.Drawing.Point(98, 47);
            this.ddlDefault_Status.Name = "ddlDefault_Status";
            this.ddlDefault_Status.Size = new System.Drawing.Size(184, 20);
            this.ddlDefault_Status.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "状态：";
            // 
            // tbxCardType
            // 
            this.tbxCardType.Location = new System.Drawing.Point(99, 25);
            this.tbxCardType.Name = "tbxCardType";
            this.tbxCardType.Size = new System.Drawing.Size(183, 21);
            this.tbxCardType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "停车卡类型：";
            // 
            // tbxCardNum
            // 
            this.tbxCardNum.Location = new System.Drawing.Point(99, 3);
            this.tbxCardNum.Name = "tbxCardNum";
            this.tbxCardNum.Size = new System.Drawing.Size(183, 21);
            this.tbxCardNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "卡面编号：";
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 375);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "View";
            this.Text = "View";
            this.Load += new System.EventHandler(this.View_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton tbnHistory;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCardNum;
        private System.Windows.Forms.TextBox tbxCardType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ddlDefault_Status;
        private System.Windows.Forms.TextBox tbxDefault;
        private System.Windows.Forms.Label lblDefault;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox ddlSubmitType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ddlPurpoe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBatch;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox ddlCostType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpEffectDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbxMax;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Button btnChargeValue;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblDefault_Unit;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblMax_Unit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnChangeCard;
    }
}