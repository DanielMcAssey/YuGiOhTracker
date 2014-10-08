namespace YuGiOhTracker
{
	partial class frmViewSet
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewSet));
			this.gbSetDetails = new System.Windows.Forms.GroupBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.lblSetTypeText = new System.Windows.Forms.Label();
			this.lblSetType = new System.Windows.Forms.Label();
			this.lblSeparator = new System.Windows.Forms.Label();
			this.lblYear = new System.Windows.Forms.Label();
			this.lblSetName = new System.Windows.Forms.Label();
			this.lblCardCount = new System.Windows.Forms.Label();
			this.lblSetCards = new System.Windows.Forms.Label();
			this.dgvSetCards = new System.Windows.Forms.DataGridView();
			this.gbSetDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSetCards)).BeginInit();
			this.SuspendLayout();
			// 
			// gbSetDetails
			// 
			this.gbSetDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSetDetails.Controls.Add(this.btnClose);
			this.gbSetDetails.Controls.Add(this.lblSetTypeText);
			this.gbSetDetails.Controls.Add(this.lblSetType);
			this.gbSetDetails.Controls.Add(this.lblSeparator);
			this.gbSetDetails.Controls.Add(this.lblYear);
			this.gbSetDetails.Controls.Add(this.lblSetName);
			this.gbSetDetails.Controls.Add(this.lblCardCount);
			this.gbSetDetails.Controls.Add(this.lblSetCards);
			this.gbSetDetails.Controls.Add(this.dgvSetCards);
			this.gbSetDetails.Location = new System.Drawing.Point(12, 12);
			this.gbSetDetails.Name = "gbSetDetails";
			this.gbSetDetails.Size = new System.Drawing.Size(794, 468);
			this.gbSetDetails.TabIndex = 0;
			this.gbSetDetails.TabStop = false;
			this.gbSetDetails.Text = "Set Details";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(713, 439);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 8;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// lblSetTypeText
			// 
			this.lblSetTypeText.AutoSize = true;
			this.lblSetTypeText.Location = new System.Drawing.Point(65, 69);
			this.lblSetTypeText.Name = "lblSetTypeText";
			this.lblSetTypeText.Size = new System.Drawing.Size(72, 13);
			this.lblSetTypeText.TabIndex = 7;
			this.lblSetTypeText.Text = "%SETTYPE%";
			// 
			// lblSetType
			// 
			this.lblSetType.AutoSize = true;
			this.lblSetType.Location = new System.Drawing.Point(6, 69);
			this.lblSetType.Name = "lblSetType";
			this.lblSetType.Size = new System.Drawing.Size(53, 13);
			this.lblSetType.TabIndex = 6;
			this.lblSetType.Text = "Set Type:";
			// 
			// lblSeparator
			// 
			this.lblSeparator.AutoSize = true;
			this.lblSeparator.Location = new System.Drawing.Point(43, 45);
			this.lblSeparator.Name = "lblSeparator";
			this.lblSeparator.Size = new System.Drawing.Size(10, 13);
			this.lblSeparator.TabIndex = 5;
			this.lblSeparator.Text = "-";
			// 
			// lblYear
			// 
			this.lblYear.AutoSize = true;
			this.lblYear.Location = new System.Drawing.Point(6, 45);
			this.lblYear.Name = "lblYear";
			this.lblYear.Size = new System.Drawing.Size(31, 13);
			this.lblYear.TabIndex = 4;
			this.lblYear.Text = "2002";
			// 
			// lblSetName
			// 
			this.lblSetName.AutoSize = true;
			this.lblSetName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSetName.Location = new System.Drawing.Point(6, 16);
			this.lblSetName.Name = "lblSetName";
			this.lblSetName.Size = new System.Drawing.Size(183, 29);
			this.lblSetName.TabIndex = 3;
			this.lblSetName.Text = "%SETNAME%";
			// 
			// lblCardCount
			// 
			this.lblCardCount.AutoSize = true;
			this.lblCardCount.Location = new System.Drawing.Point(59, 45);
			this.lblCardCount.Name = "lblCardCount";
			this.lblCardCount.Size = new System.Drawing.Size(43, 13);
			this.lblCardCount.TabIndex = 2;
			this.lblCardCount.Text = "0 Cards";
			// 
			// lblSetCards
			// 
			this.lblSetCards.AutoSize = true;
			this.lblSetCards.Location = new System.Drawing.Point(6, 95);
			this.lblSetCards.Name = "lblSetCards";
			this.lblSetCards.Size = new System.Drawing.Size(64, 13);
			this.lblSetCards.TabIndex = 1;
			this.lblSetCards.Text = "Cards in Set";
			// 
			// dgvSetCards
			// 
			this.dgvSetCards.AllowUserToAddRows = false;
			this.dgvSetCards.AllowUserToDeleteRows = false;
			this.dgvSetCards.AllowUserToResizeRows = false;
			this.dgvSetCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvSetCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSetCards.Location = new System.Drawing.Point(6, 111);
			this.dgvSetCards.MultiSelect = false;
			this.dgvSetCards.Name = "dgvSetCards";
			this.dgvSetCards.ReadOnly = true;
			this.dgvSetCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvSetCards.ShowEditingIcon = false;
			this.dgvSetCards.Size = new System.Drawing.Size(782, 322);
			this.dgvSetCards.TabIndex = 0;
			this.dgvSetCards.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSetCards_CellDoubleClick);
			this.dgvSetCards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvSetCards_KeyDown);
			this.dgvSetCards.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvSetCards_MouseClick);
			// 
			// frmViewSet
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(818, 492);
			this.Controls.Add(this.gbSetDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmViewSet";
			this.Text = "View Set - %SETNAME%";
			this.Load += new System.EventHandler(this.frmViewSet_Load);
			this.gbSetDetails.ResumeLayout(false);
			this.gbSetDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSetCards)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbSetDetails;
		private System.Windows.Forms.Label lblSetCards;
		private System.Windows.Forms.DataGridView dgvSetCards;
		private System.Windows.Forms.Label lblCardCount;
		private System.Windows.Forms.Label lblSetName;
		private System.Windows.Forms.Label lblSeparator;
		private System.Windows.Forms.Label lblYear;
		private System.Windows.Forms.Label lblSetType;
		private System.Windows.Forms.Label lblSetTypeText;
		private System.Windows.Forms.Button btnClose;
	}
}