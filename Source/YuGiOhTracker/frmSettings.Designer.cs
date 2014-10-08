namespace YuGiOhTracker
{
	partial class frmSettings
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
			this.gbSettingsGeneral = new System.Windows.Forms.GroupBox();
			this.txtMashapeApiKey = new System.Windows.Forms.TextBox();
			this.lblMashApe = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnApply = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.gbSettingsGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbSettingsGeneral
			// 
			this.gbSettingsGeneral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.gbSettingsGeneral.Controls.Add(this.txtMashapeApiKey);
			this.gbSettingsGeneral.Controls.Add(this.lblMashApe);
			this.gbSettingsGeneral.Location = new System.Drawing.Point(12, 12);
			this.gbSettingsGeneral.Name = "gbSettingsGeneral";
			this.gbSettingsGeneral.Size = new System.Drawing.Size(446, 51);
			this.gbSettingsGeneral.TabIndex = 0;
			this.gbSettingsGeneral.TabStop = false;
			this.gbSettingsGeneral.Text = "General Configuration";
			// 
			// txtMashapeApiKey
			// 
			this.txtMashapeApiKey.Location = new System.Drawing.Point(107, 19);
			this.txtMashapeApiKey.Name = "txtMashapeApiKey";
			this.txtMashapeApiKey.Size = new System.Drawing.Size(333, 20);
			this.txtMashapeApiKey.TabIndex = 1;
			this.txtMashapeApiKey.TextChanged += new System.EventHandler(this.AnyTextbox_TextChanged);
			// 
			// lblMashApe
			// 
			this.lblMashApe.AutoSize = true;
			this.lblMashApe.Location = new System.Drawing.Point(6, 22);
			this.lblMashApe.Name = "lblMashApe";
			this.lblMashApe.Size = new System.Drawing.Size(95, 13);
			this.lblMashApe.TabIndex = 0;
			this.lblMashApe.Text = "Mashape API Key:";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOK.Location = new System.Drawing.Point(221, 69);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnApply
			// 
			this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnApply.Location = new System.Drawing.Point(302, 69);
			this.btnApply.Name = "btnApply";
			this.btnApply.Size = new System.Drawing.Size(75, 23);
			this.btnApply.TabIndex = 1;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(383, 69);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// frmSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(470, 104);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gbSettingsGeneral);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.btnOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmSettings";
			this.Text = "YuGiOh Tracker - Settings";
			this.Load += new System.EventHandler(this.frmSettings_Load);
			this.gbSettingsGeneral.ResumeLayout(false);
			this.gbSettingsGeneral.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbSettingsGeneral;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblMashApe;
		private System.Windows.Forms.TextBox txtMashapeApiKey;
	}
}