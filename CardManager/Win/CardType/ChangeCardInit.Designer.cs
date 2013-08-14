namespace Bouwa.ITSP2V31.Win.CardType
{
    partial class ChangeCardInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeCardInit));
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblLabelNo = new System.Windows.Forms.Label();
            this.tbxCardNum = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOverPlus = new System.Windows.Forms.Label();
            this.lblOverPlusUnit = new System.Windows.Forms.Label();
            this.tbxOverPlus = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblMaxUnit = new System.Windows.Forms.Label();
            this.tbxMax = new System.Windows.Forms.TextBox();
            this.tbxLotNum = new System.Windows.Forms.TextBox();
            this.tbxCardType = new System.Windows.Forms.TextBox();
            this.lblSaasId = new System.Windows.Forms.Label();
            this.lblCardTypeId = new System.Windows.Forms.Label();
            this.lblCostType = new System.Windows.Forms.Label();
            this.lblEffectDate = new System.Windows.Forms.Label();
            this.lblOutDate = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbnInit = new System.Windows.Forms.ToolStripButton();
            this.btnReload = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.lblPurpose = new System.Windows.Forms.Label();
            this.lblSubmitType = new System.Windows.Forms.Label();
            this.lblExtSaasId = new System.Windows.Forms.Label();
            this.lblExtCardTypeId = new System.Windows.Forms.Label();
            this.ddlStatus = new System.Windows.Forms.TextBox();
            this.lblNum = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblMessage.Location = new System.Drawing.Point(53, 30);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(263, 12);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "提示： 只有在空卡状态下，才可进行换卡操作！";
            // 
            // lblLabelNo
            // 
            this.lblLabelNo.AutoSize = true;
            this.lblLabelNo.Location = new System.Drawing.Point(53, 52);
            this.lblLabelNo.Name = "lblLabelNo";
            this.lblLabelNo.Size = new System.Drawing.Size(41, 12);
            this.lblLabelNo.TabIndex = 2;
            this.lblLabelNo.Text = "卡号：";
            // 
            // tbxCardNum
            // 
            this.tbxCardNum.Location = new System.Drawing.Point(97, 71);
            this.tbxCardNum.MaxLength = 7;
            this.tbxCardNum.Name = "tbxCardNum";
            this.tbxCardNum.ReadOnly = true;
            this.tbxCardNum.Size = new System.Drawing.Size(183, 21);
            this.tbxCardNum.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "卡面编号：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "批次：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "停车卡类型：";
            // 
            // lblOverPlus
            // 
            this.lblOverPlus.AutoSize = true;
            this.lblOverPlus.Location = new System.Drawing.Point(29, 142);
            this.lblOverPlus.Name = "lblOverPlus";
            this.lblOverPlus.Size = new System.Drawing.Size(65, 12);
            this.lblOverPlus.TabIndex = 10;
            this.lblOverPlus.Text = "剩余金额：";
            // 
            // lblOverPlusUnit
            // 
            this.lblOverPlusUnit.AutoSize = true;
            this.lblOverPlusUnit.Location = new System.Drawing.Point(287, 145);
            this.lblOverPlusUnit.Name = "lblOverPlusUnit";
            this.lblOverPlusUnit.Size = new System.Drawing.Size(17, 12);
            this.lblOverPlusUnit.TabIndex = 11;
            this.lblOverPlusUnit.Text = "元";
            // 
            // tbxOverPlus
            // 
            this.tbxOverPlus.Location = new System.Drawing.Point(97, 138);
            this.tbxOverPlus.MaxLength = 10;
            this.tbxOverPlus.Name = "tbxOverPlus";
            this.tbxOverPlus.ReadOnly = true;
            this.tbxOverPlus.Size = new System.Drawing.Size(183, 21);
            this.tbxOverPlus.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(41, 165);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "卡状态：";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(29, 189);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(65, 12);
            this.lblMax.TabIndex = 21;
            this.lblMax.Text = "上限金额：";
            // 
            // lblMaxUnit
            // 
            this.lblMaxUnit.AutoSize = true;
            this.lblMaxUnit.Location = new System.Drawing.Point(287, 189);
            this.lblMaxUnit.Name = "lblMaxUnit";
            this.lblMaxUnit.Size = new System.Drawing.Size(17, 12);
            this.lblMaxUnit.TabIndex = 28;
            this.lblMaxUnit.Text = "元";
            // 
            // tbxMax
            // 
            this.tbxMax.Location = new System.Drawing.Point(97, 184);
            this.tbxMax.Name = "tbxMax";
            this.tbxMax.ReadOnly = true;
            this.tbxMax.Size = new System.Drawing.Size(183, 21);
            this.tbxMax.TabIndex = 31;
            // 
            // tbxLotNum
            // 
            this.tbxLotNum.Location = new System.Drawing.Point(97, 93);
            this.tbxLotNum.Name = "tbxLotNum";
            this.tbxLotNum.ReadOnly = true;
            this.tbxLotNum.Size = new System.Drawing.Size(183, 21);
            this.tbxLotNum.TabIndex = 34;
            // 
            // tbxCardType
            // 
            this.tbxCardType.Location = new System.Drawing.Point(97, 115);
            this.tbxCardType.Name = "tbxCardType";
            this.tbxCardType.ReadOnly = true;
            this.tbxCardType.Size = new System.Drawing.Size(183, 21);
            this.tbxCardType.TabIndex = 35;
            // 
            // lblSaasId
            // 
            this.lblSaasId.AutoSize = true;
            this.lblSaasId.Location = new System.Drawing.Point(313, 111);
            this.lblSaasId.Name = "lblSaasId";
            this.lblSaasId.Size = new System.Drawing.Size(41, 12);
            this.lblSaasId.TabIndex = 39;
            this.lblSaasId.Text = "saasId";
            this.lblSaasId.Visible = false;
            // 
            // lblCardTypeId
            // 
            this.lblCardTypeId.AutoSize = true;
            this.lblCardTypeId.Location = new System.Drawing.Point(312, 137);
            this.lblCardTypeId.Name = "lblCardTypeId";
            this.lblCardTypeId.Size = new System.Drawing.Size(65, 12);
            this.lblCardTypeId.TabIndex = 40;
            this.lblCardTypeId.Text = "cardTypeId";
            this.lblCardTypeId.Visible = false;
            // 
            // lblCostType
            // 
            this.lblCostType.AutoSize = true;
            this.lblCostType.Location = new System.Drawing.Point(313, 151);
            this.lblCostType.Name = "lblCostType";
            this.lblCostType.Size = new System.Drawing.Size(53, 12);
            this.lblCostType.TabIndex = 41;
            this.lblCostType.Text = "costType";
            this.lblCostType.Visible = false;
            // 
            // lblEffectDate
            // 
            this.lblEffectDate.AutoSize = true;
            this.lblEffectDate.Location = new System.Drawing.Point(315, 196);
            this.lblEffectDate.Name = "lblEffectDate";
            this.lblEffectDate.Size = new System.Drawing.Size(65, 12);
            this.lblEffectDate.TabIndex = 42;
            this.lblEffectDate.Text = "effectDate";
            this.lblEffectDate.Visible = false;
            // 
            // lblOutDate
            // 
            this.lblOutDate.AutoSize = true;
            this.lblOutDate.Location = new System.Drawing.Point(315, 208);
            this.lblOutDate.Name = "lblOutDate";
            this.lblOutDate.Size = new System.Drawing.Size(47, 12);
            this.lblOutDate.TabIndex = 43;
            this.lblOutDate.Text = "outDate";
            this.lblOutDate.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbnInit,
            this.btnReload,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(318, 25);
            this.toolStrip1.TabIndex = 44;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbnInit
            // 
            this.tbnInit.Image = ((System.Drawing.Image)(resources.GetObject("tbnInit.Image")));
            this.tbnInit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbnInit.Name = "tbnInit";
            this.tbnInit.Size = new System.Drawing.Size(49, 22);
            this.tbnInit.Text = "换卡";
            this.tbnInit.Click += new System.EventHandler(this.tbnWriteCard_Click);
            // 
            // btnReload
            // 
            this.btnReload.Image = ((System.Drawing.Image)(resources.GetObject("btnReload.Image")));
            this.btnReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(73, 22);
            this.btnReload.Text = "重新读取";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 22);
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.tbnClose_Click);
            // 
            // lblPurpose
            // 
            this.lblPurpose.AutoSize = true;
            this.lblPurpose.Location = new System.Drawing.Point(315, 215);
            this.lblPurpose.Name = "lblPurpose";
            this.lblPurpose.Size = new System.Drawing.Size(47, 12);
            this.lblPurpose.TabIndex = 45;
            this.lblPurpose.Text = "purpose";
            this.lblPurpose.Visible = false;
            // 
            // lblSubmitType
            // 
            this.lblSubmitType.AutoSize = true;
            this.lblSubmitType.Location = new System.Drawing.Point(317, 239);
            this.lblSubmitType.Name = "lblSubmitType";
            this.lblSubmitType.Size = new System.Drawing.Size(65, 12);
            this.lblSubmitType.TabIndex = 46;
            this.lblSubmitType.Text = "submitType";
            this.lblSubmitType.Visible = false;
            // 
            // lblExtSaasId
            // 
            this.lblExtSaasId.AutoSize = true;
            this.lblExtSaasId.Location = new System.Drawing.Point(317, 262);
            this.lblExtSaasId.Name = "lblExtSaasId";
            this.lblExtSaasId.Size = new System.Drawing.Size(59, 12);
            this.lblExtSaasId.TabIndex = 47;
            this.lblExtSaasId.Text = "extSaasId";
            this.lblExtSaasId.Visible = false;
            // 
            // lblExtCardTypeId
            // 
            this.lblExtCardTypeId.AutoSize = true;
            this.lblExtCardTypeId.Location = new System.Drawing.Point(312, 274);
            this.lblExtCardTypeId.Name = "lblExtCardTypeId";
            this.lblExtCardTypeId.Size = new System.Drawing.Size(83, 12);
            this.lblExtCardTypeId.TabIndex = 48;
            this.lblExtCardTypeId.Text = "extCardTypeId";
            this.lblExtCardTypeId.Visible = false;
            // 
            // ddlStatus
            // 
            this.ddlStatus.Location = new System.Drawing.Point(97, 160);
            this.ddlStatus.MaxLength = 10;
            this.ddlStatus.Name = "ddlStatus";
            this.ddlStatus.ReadOnly = true;
            this.ddlStatus.Size = new System.Drawing.Size(183, 21);
            this.ddlStatus.TabIndex = 49;
            // 
            // lblNum
            // 
            this.lblNum.Location = new System.Drawing.Point(97, 48);
            this.lblNum.MaxLength = 10;
            this.lblNum.Name = "lblNum";
            this.lblNum.ReadOnly = true;
            this.lblNum.Size = new System.Drawing.Size(183, 21);
            this.lblNum.TabIndex = 50;
            // 
            // ChangeCardInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 217);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.ddlStatus);
            this.Controls.Add(this.lblExtCardTypeId);
            this.Controls.Add(this.lblExtSaasId);
            this.Controls.Add(this.lblSubmitType);
            this.Controls.Add(this.lblPurpose);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.lblOutDate);
            this.Controls.Add(this.lblEffectDate);
            this.Controls.Add(this.lblCostType);
            this.Controls.Add(this.lblCardTypeId);
            this.Controls.Add(this.lblSaasId);
            this.Controls.Add(this.tbxCardType);
            this.Controls.Add(this.tbxLotNum);
            this.Controls.Add(this.tbxMax);
            this.Controls.Add(this.lblMaxUnit);
            this.Controls.Add(this.lblMax);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.tbxOverPlus);
            this.Controls.Add(this.lblOverPlusUnit);
            this.Controls.Add(this.lblOverPlus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxCardNum);
            this.Controls.Add(this.lblLabelNo);
            this.Controls.Add(this.lblMessage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeCardInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CardTypeInit";
            this.Load += new System.EventHandler(this.CardTypeInit_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblLabelNo;
        private System.Windows.Forms.TextBox tbxCardNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOverPlus;
        private System.Windows.Forms.Label lblOverPlusUnit;
        private System.Windows.Forms.TextBox tbxOverPlus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblMaxUnit;
        private System.Windows.Forms.TextBox tbxMax;
        private System.Windows.Forms.TextBox tbxLotNum;
        private System.Windows.Forms.TextBox tbxCardType;
        private System.Windows.Forms.Label lblSaasId;
        private System.Windows.Forms.Label lblCardTypeId;
        private System.Windows.Forms.Label lblCostType;
        private System.Windows.Forms.Label lblEffectDate;
        private System.Windows.Forms.Label lblOutDate;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbnInit;
        private System.Windows.Forms.ToolStripButton btnReload;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.Label lblPurpose;
        private System.Windows.Forms.Label lblSubmitType;
        private System.Windows.Forms.Label lblExtSaasId;
        private System.Windows.Forms.Label lblExtCardTypeId;
        private System.Windows.Forms.TextBox ddlStatus;
        private System.Windows.Forms.TextBox lblNum;
    }
}