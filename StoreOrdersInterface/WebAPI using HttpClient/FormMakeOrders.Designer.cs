namespace WebAPI_using_HttpClient
{
    partial class FormMakeOrders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMakeOrders));
            this.dgvOrderDetails = new System.Windows.Forms.DataGridView();
            this.lblProductsBought = new System.Windows.Forms.Label();
            this.btnReturnBack = new System.Windows.Forms.Button();
            this.btnEnsureOrders = new System.Windows.Forms.Button();
            this.lblOrderSettings = new System.Windows.Forms.Label();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.txtCustomerPhoneNumberInput = new System.Windows.Forms.TextBox();
            this.txtCustomerPhoneNumber = new System.Windows.Forms.TextBox();
            this.cboCustomerName = new System.Windows.Forms.ComboBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelPayment = new System.Windows.Forms.Panel();
            this.radioLINEPAY = new System.Windows.Forms.RadioButton();
            this.radioCash = new System.Windows.Forms.RadioButton();
            this.txtInvoiceChoice = new System.Windows.Forms.TextBox();
            this.panelInvoiceChoice = new System.Windows.Forms.Panel();
            this.radioEinvoice = new System.Windows.Forms.RadioButton();
            this.radioPaperInvoice = new System.Windows.Forms.RadioButton();
            this.radioNoInvoice = new System.Windows.Forms.RadioButton();
            this.txtEinvoice = new System.Windows.Forms.TextBox();
            this.txtEinvoiceInput = new System.Windows.Forms.TextBox();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panelPayment.SuspendLayout();
            this.panelInvoiceChoice.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderDetails
            // 
            this.dgvOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderDetails.Location = new System.Drawing.Point(27, 52);
            this.dgvOrderDetails.Name = "dgvOrderDetails";
            this.dgvOrderDetails.RowHeadersWidth = 51;
            this.dgvOrderDetails.RowTemplate.Height = 24;
            this.dgvOrderDetails.Size = new System.Drawing.Size(446, 367);
            this.dgvOrderDetails.TabIndex = 0;
            // 
            // lblProductsBought
            // 
            this.lblProductsBought.AutoSize = true;
            this.lblProductsBought.Location = new System.Drawing.Point(32, 16);
            this.lblProductsBought.Name = "lblProductsBought";
            this.lblProductsBought.Size = new System.Drawing.Size(152, 25);
            this.lblProductsBought.TabIndex = 1;
            this.lblProductsBought.Text = "購買品項清單：";
            // 
            // btnReturnBack
            // 
            this.btnReturnBack.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnReturnBack.Location = new System.Drawing.Point(723, 370);
            this.btnReturnBack.Name = "btnReturnBack";
            this.btnReturnBack.Size = new System.Drawing.Size(119, 48);
            this.btnReturnBack.TabIndex = 2;
            this.btnReturnBack.Text = "返回編輯";
            this.btnReturnBack.UseVisualStyleBackColor = true;
            this.btnReturnBack.Click += new System.EventHandler(this.btnReturnBack_Click);
            // 
            // btnEnsureOrders
            // 
            this.btnEnsureOrders.Location = new System.Drawing.Point(848, 370);
            this.btnEnsureOrders.Name = "btnEnsureOrders";
            this.btnEnsureOrders.Size = new System.Drawing.Size(119, 48);
            this.btnEnsureOrders.TabIndex = 3;
            this.btnEnsureOrders.Text = "確定結帳";
            this.btnEnsureOrders.UseVisualStyleBackColor = true;
            this.btnEnsureOrders.Click += new System.EventHandler(this.btnEnsureOrders_Click);
            // 
            // lblOrderSettings
            // 
            this.lblOrderSettings.AutoSize = true;
            this.lblOrderSettings.Location = new System.Drawing.Point(491, 16);
            this.lblOrderSettings.Name = "lblOrderSettings";
            this.lblOrderSettings.Size = new System.Drawing.Size(112, 25);
            this.lblOrderSettings.TabIndex = 4;
            this.lblOrderSettings.Text = "訂單設定：";
            // 
            // txtPayment
            // 
            this.txtPayment.Location = new System.Drawing.Point(9, 103);
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.ReadOnly = true;
            this.txtPayment.Size = new System.Drawing.Size(110, 34);
            this.txtPayment.TabIndex = 4;
            this.txtPayment.TabStop = false;
            this.txtPayment.Text = "付款方式*";
            // 
            // txtCustomerPhoneNumberInput
            // 
            this.txtCustomerPhoneNumberInput.Location = new System.Drawing.Point(125, 63);
            this.txtCustomerPhoneNumberInput.Name = "txtCustomerPhoneNumberInput";
            this.txtCustomerPhoneNumberInput.Size = new System.Drawing.Size(304, 34);
            this.txtCustomerPhoneNumberInput.TabIndex = 3;
            // 
            // txtCustomerPhoneNumber
            // 
            this.txtCustomerPhoneNumber.Location = new System.Drawing.Point(9, 63);
            this.txtCustomerPhoneNumber.Name = "txtCustomerPhoneNumber";
            this.txtCustomerPhoneNumber.ReadOnly = true;
            this.txtCustomerPhoneNumber.Size = new System.Drawing.Size(110, 34);
            this.txtCustomerPhoneNumber.TabIndex = 2;
            this.txtCustomerPhoneNumber.Text = "客戶電話";
            // 
            // cboCustomerName
            // 
            this.cboCustomerName.FormattingEnabled = true;
            this.cboCustomerName.Location = new System.Drawing.Point(125, 23);
            this.cboCustomerName.Name = "cboCustomerName";
            this.cboCustomerName.Size = new System.Drawing.Size(304, 33);
            this.cboCustomerName.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(9, 23);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.ReadOnly = true;
            this.txtCustomerName.Size = new System.Drawing.Size(110, 34);
            this.txtCustomerName.TabIndex = 0;
            this.txtCustomerName.Text = "客戶名稱*";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.txtCustomerName);
            this.flowLayoutPanel1.Controls.Add(this.cboCustomerName);
            this.flowLayoutPanel1.Controls.Add(this.txtCustomerPhoneNumber);
            this.flowLayoutPanel1.Controls.Add(this.txtCustomerPhoneNumberInput);
            this.flowLayoutPanel1.Controls.Add(this.txtPayment);
            this.flowLayoutPanel1.Controls.Add(this.panelPayment);
            this.flowLayoutPanel1.Controls.Add(this.txtInvoiceChoice);
            this.flowLayoutPanel1.Controls.Add(this.panelInvoiceChoice);
            this.flowLayoutPanel1.Controls.Add(this.txtEinvoice);
            this.flowLayoutPanel1.Controls.Add(this.txtEinvoiceInput);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(491, 52);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6, 20, 6, 20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(476, 248);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.radioLINEPAY);
            this.panelPayment.Controls.Add(this.radioCash);
            this.panelPayment.Location = new System.Drawing.Point(125, 103);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(304, 34);
            this.panelPayment.TabIndex = 6;
            // 
            // radioLINEPAY
            // 
            this.radioLINEPAY.AutoSize = true;
            this.radioLINEPAY.Location = new System.Drawing.Point(83, 2);
            this.radioLINEPAY.Name = "radioLINEPAY";
            this.radioLINEPAY.Size = new System.Drawing.Size(114, 29);
            this.radioLINEPAY.TabIndex = 1;
            this.radioLINEPAY.TabStop = true;
            this.radioLINEPAY.Text = "LINEPAY";
            this.radioLINEPAY.UseVisualStyleBackColor = true;
            // 
            // radioCash
            // 
            this.radioCash.AutoSize = true;
            this.radioCash.Location = new System.Drawing.Point(3, 3);
            this.radioCash.Name = "radioCash";
            this.radioCash.Size = new System.Drawing.Size(73, 29);
            this.radioCash.TabIndex = 0;
            this.radioCash.TabStop = true;
            this.radioCash.Text = "現金";
            this.radioCash.UseVisualStyleBackColor = true;
            // 
            // txtInvoiceChoice
            // 
            this.txtInvoiceChoice.Location = new System.Drawing.Point(9, 143);
            this.txtInvoiceChoice.Name = "txtInvoiceChoice";
            this.txtInvoiceChoice.ReadOnly = true;
            this.txtInvoiceChoice.Size = new System.Drawing.Size(110, 34);
            this.txtInvoiceChoice.TabIndex = 7;
            this.txtInvoiceChoice.TabStop = false;
            this.txtInvoiceChoice.Text = "發票*";
            // 
            // panelInvoiceChoice
            // 
            this.panelInvoiceChoice.Controls.Add(this.radioEinvoice);
            this.panelInvoiceChoice.Controls.Add(this.radioPaperInvoice);
            this.panelInvoiceChoice.Controls.Add(this.radioNoInvoice);
            this.panelInvoiceChoice.Location = new System.Drawing.Point(125, 143);
            this.panelInvoiceChoice.Name = "panelInvoiceChoice";
            this.panelInvoiceChoice.Size = new System.Drawing.Size(328, 34);
            this.panelInvoiceChoice.TabIndex = 7;
            // 
            // radioEinvoice
            // 
            this.radioEinvoice.AutoSize = true;
            this.radioEinvoice.Location = new System.Drawing.Point(209, 2);
            this.radioEinvoice.Name = "radioEinvoice";
            this.radioEinvoice.Size = new System.Drawing.Size(113, 29);
            this.radioEinvoice.TabIndex = 2;
            this.radioEinvoice.TabStop = true;
            this.radioEinvoice.Text = "開立電子";
            this.radioEinvoice.UseVisualStyleBackColor = true;
            this.radioEinvoice.CheckedChanged += new System.EventHandler(this.radioEinvoice_CheckedChanged);
            // 
            // radioPaperInvoice
            // 
            this.radioPaperInvoice.AutoSize = true;
            this.radioPaperInvoice.Location = new System.Drawing.Point(95, 3);
            this.radioPaperInvoice.Name = "radioPaperInvoice";
            this.radioPaperInvoice.Size = new System.Drawing.Size(113, 29);
            this.radioPaperInvoice.TabIndex = 1;
            this.radioPaperInvoice.TabStop = true;
            this.radioPaperInvoice.Text = "開立紙本";
            this.radioPaperInvoice.UseVisualStyleBackColor = true;
            // 
            // radioNoInvoice
            // 
            this.radioNoInvoice.AutoSize = true;
            this.radioNoInvoice.Location = new System.Drawing.Point(3, 3);
            this.radioNoInvoice.Name = "radioNoInvoice";
            this.radioNoInvoice.Size = new System.Drawing.Size(93, 29);
            this.radioNoInvoice.TabIndex = 0;
            this.radioNoInvoice.TabStop = true;
            this.radioNoInvoice.Text = "不開立";
            this.radioNoInvoice.UseVisualStyleBackColor = true;
            // 
            // txtEinvoice
            // 
            this.txtEinvoice.Enabled = false;
            this.txtEinvoice.Location = new System.Drawing.Point(9, 183);
            this.txtEinvoice.Name = "txtEinvoice";
            this.txtEinvoice.ReadOnly = true;
            this.txtEinvoice.Size = new System.Drawing.Size(110, 34);
            this.txtEinvoice.TabIndex = 8;
            this.txtEinvoice.TabStop = false;
            this.txtEinvoice.Text = "載具號碼";
            // 
            // txtEinvoiceInput
            // 
            this.txtEinvoiceInput.Enabled = false;
            this.txtEinvoiceInput.Location = new System.Drawing.Point(125, 183);
            this.txtEinvoiceInput.Name = "txtEinvoiceInput";
            this.txtEinvoiceInput.Size = new System.Drawing.Size(304, 34);
            this.txtEinvoiceInput.TabIndex = 9;
            this.txtEinvoiceInput.TabStop = false;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalAmount.Location = new System.Drawing.Point(493, 372);
            this.lblTotalAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(126, 38);
            this.lblTotalAmount.TabIndex = 23;
            this.lblTotalAmount.Text = "總計: $0";
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsTab = true;
            this.txtMessage.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMessage.Location = new System.Drawing.Point(491, 288);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(476, 65);
            this.txtMessage.TabIndex = 24;
            // 
            // FormMakeOrders
            // 
            this.AcceptButton = this.btnEnsureOrders;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnReturnBack;
            this.ClientSize = new System.Drawing.Size(982, 449);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblOrderSettings);
            this.Controls.Add(this.btnEnsureOrders);
            this.Controls.Add(this.btnReturnBack);
            this.Controls.Add(this.lblProductsBought);
            this.Controls.Add(this.dgvOrderDetails);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMakeOrders";
            this.Text = "FormMakeOrders";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnClosing_Click);
            this.Load += new System.EventHandler(this.FormMakeOrders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderDetails)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            this.panelInvoiceChoice.ResumeLayout(false);
            this.panelInvoiceChoice.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderDetails;
        private System.Windows.Forms.Label lblProductsBought;
        private System.Windows.Forms.Button btnReturnBack;
        private System.Windows.Forms.Button btnEnsureOrders;
        private System.Windows.Forms.Label lblOrderSettings;
        private System.Windows.Forms.TextBox txtPayment;
        private System.Windows.Forms.TextBox txtCustomerPhoneNumberInput;
        private System.Windows.Forms.TextBox txtCustomerPhoneNumber;
        private System.Windows.Forms.ComboBox cboCustomerName;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton radioLINEPAY;
        private System.Windows.Forms.RadioButton radioCash;
        private System.Windows.Forms.Panel panelPayment;
        private System.Windows.Forms.TextBox txtInvoiceChoice;
        private System.Windows.Forms.Panel panelInvoiceChoice;
        private System.Windows.Forms.RadioButton radioEinvoice;
        private System.Windows.Forms.RadioButton radioPaperInvoice;
        private System.Windows.Forms.RadioButton radioNoInvoice;
        private System.Windows.Forms.TextBox txtEinvoice;
        private System.Windows.Forms.TextBox txtEinvoiceInput;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtMessage;
    }
}