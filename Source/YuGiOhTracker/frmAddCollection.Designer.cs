namespace YuGiOhTracker
{
	partial class frmAddCollection
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
			this.gbAddCollection = new System.Windows.Forms.GroupBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblCollectionToAdd = new System.Windows.Forms.Label();
			this.cbCollectionToAdd = new System.Windows.Forms.ComboBox();
			this.gbAddCollection.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbAddCollection
			// 
			this.gbAddCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbAddCollection.Controls.Add(this.cbCollectionToAdd);
			this.gbAddCollection.Controls.Add(this.lblCollectionToAdd);
			this.gbAddCollection.Location = new System.Drawing.Point(12, 12);
			this.gbAddCollection.Name = "gbAddCollection";
			this.gbAddCollection.Size = new System.Drawing.Size(498, 49);
			this.gbAddCollection.TabIndex = 0;
			this.gbAddCollection.TabStop = false;
			this.gbAddCollection.Text = "Add To Collection";
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAdd.Location = new System.Drawing.Point(354, 67);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.Location = new System.Drawing.Point(435, 67);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblCollectionToAdd
			// 
			this.lblCollectionToAdd.AutoSize = true;
			this.lblCollectionToAdd.Location = new System.Drawing.Point(6, 22);
			this.lblCollectionToAdd.Name = "lblCollectionToAdd";
			this.lblCollectionToAdd.Size = new System.Drawing.Size(74, 13);
			this.lblCollectionToAdd.TabIndex = 0;
			this.lblCollectionToAdd.Text = "Deck To Add:";
			// 
			// cbCollectionToAdd
			// 
			this.cbCollectionToAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCollectionToAdd.FormattingEnabled = true;
			this.cbCollectionToAdd.Location = new System.Drawing.Point(106, 19);
			this.cbCollectionToAdd.Name = "cbCollectionToAdd";
			this.cbCollectionToAdd.Size = new System.Drawing.Size(386, 21);
			this.cbCollectionToAdd.TabIndex = 1;
			// 
			// frmAddCollection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(522, 102);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.gbAddCollection);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "frmAddCollection";
			this.Text = "Add to Collection";
			this.gbAddCollection.ResumeLayout(false);
			this.gbAddCollection.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbAddCollection;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cbCollectionToAdd;
		private System.Windows.Forms.Label lblCollectionToAdd;
	}
}