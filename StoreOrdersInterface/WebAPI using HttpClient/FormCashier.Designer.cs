namespace WebAPI_using_HttpClient
{
    partial class FormCashier
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCashier));
            this.btnAddComment = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstProducts = new System.Windows.Forms.ListBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnMakeOrders = new System.Windows.Forms.Button();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.txtStoreInfo = new System.Windows.Forms.TextBox();
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cmsProductCategories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddComment
            // 
            this.btnAddComment.AutoEllipsis = true;
            this.btnAddComment.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.btnAddComment.Location = new System.Drawing.Point(980, 546);
            this.btnAddComment.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddComment.Name = "btnAddComment";
            this.btnAddComment.Size = new System.Drawing.Size(60, 80);
            this.btnAddComment.TabIndex = 0;
            this.btnAddComment.Text = "留言";
            this.btnAddComment.UseVisualStyleBackColor = true;
            this.btnAddComment.Click += new System.EventHandler(this.btnAddComment_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(1065, 18);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(399, 358);
            this.dataGridView1.TabIndex = 1;
            // 
            // lstProducts
            // 
            this.lstProducts.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lstProducts.FormattingEnabled = true;
            this.lstProducts.ItemHeight = 29;
            this.lstProducts.Location = new System.Drawing.Point(623, 18);
            this.lstProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstProducts.Name = "lstProducts";
            this.lstProducts.Size = new System.Drawing.Size(416, 497);
            this.lstProducts.TabIndex = 2;
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsTab = true;
            this.txtMessage.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtMessage.Location = new System.Drawing.Point(623, 545);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(349, 80);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            // 
            // btnMakeOrders
            // 
            this.btnMakeOrders.AutoEllipsis = true;
            this.btnMakeOrders.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnMakeOrders.Location = new System.Drawing.Point(909, 632);
            this.btnMakeOrders.Margin = new System.Windows.Forms.Padding(4);
            this.btnMakeOrders.Name = "btnMakeOrders";
            this.btnMakeOrders.Size = new System.Drawing.Size(131, 56);
            this.btnMakeOrders.TabIndex = 14;
            this.btnMakeOrders.Text = "結帳";
            this.btnMakeOrders.UseVisualStyleBackColor = true;
            this.btnMakeOrders.Click += new System.EventHandler(this.btnMakeOrders_Click);
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblTotalAmount.Location = new System.Drawing.Point(616, 645);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(126, 38);
            this.lblTotalAmount.TabIndex = 22;
            this.lblTotalAmount.Text = "總計: $0";
            // 
            // txtStoreInfo
            // 
            this.txtStoreInfo.BackColor = System.Drawing.SystemColors.Control;
            this.txtStoreInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtStoreInfo.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtStoreInfo.Location = new System.Drawing.Point(12, 12);
            this.txtStoreInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStoreInfo.Name = "txtStoreInfo";
            this.txtStoreInfo.Size = new System.Drawing.Size(136, 27);
            this.txtStoreInfo.TabIndex = 23;
            // 
            // flpProducts
            // 
            this.flpProducts.AutoScroll = true;
            this.flpProducts.Location = new System.Drawing.Point(12, 132);
            this.flpProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(588, 550);
            this.flpProducts.TabIndex = 25;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1065, 389);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(359, 300);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 27;
            this.pictureBox1.TabStop = false;
            // 
            // cmsProductCategories
            // 
            this.cmsProductCategories.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsProductCategories.Name = "cmsProductCategories";
            this.cmsProductCategories.Size = new System.Drawing.Size(61, 4);
            // 
            // flpCategories
            // 
            this.flpCategories.Location = new System.Drawing.Point(12, 68);
            this.flpCategories.Margin = new System.Windows.Forms.Padding(4);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(588, 59);
            this.flpCategories.TabIndex = 28;
            // 
            // FormCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1540, 696);
            this.Controls.Add(this.flpCategories);
            this.Controls.Add(this.txtStoreInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.flpProducts);
            this.Controls.Add(this.lblTotalAmount);
            this.Controls.Add(this.btnMakeOrders);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lstProducts);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnAddComment);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCashier";
            this.Text = "Vita";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddComment;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstProducts;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnMakeOrders;
        private System.Windows.Forms.Label lblTotalAmount;
        private System.Windows.Forms.TextBox txtStoreInfo;
        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ContextMenuStrip cmsProductCategories;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
    }
}

