namespace YuGiOhTracker
{
	partial class frmAbout
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
			this.gbAbout = new System.Windows.Forms.GroupBox();
			this.lblGitHub = new System.Windows.Forms.Label();
			this.lnklblGitHub = new System.Windows.Forms.LinkLabel();
			this.lblCreatedBy = new System.Windows.Forms.Label();
			this.lblCreatedByTxt = new System.Windows.Forms.Label();
			this.txtLicence = new System.Windows.Forms.TextBox();
			this.gbLicence = new System.Windows.Forms.GroupBox();
			this.gbAbout.SuspendLayout();
			this.gbLicence.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbAbout
			// 
			this.gbAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbAbout.Controls.Add(this.gbLicence);
			this.gbAbout.Controls.Add(this.lblCreatedByTxt);
			this.gbAbout.Controls.Add(this.lblCreatedBy);
			this.gbAbout.Controls.Add(this.lnklblGitHub);
			this.gbAbout.Controls.Add(this.lblGitHub);
			this.gbAbout.Location = new System.Drawing.Point(12, 12);
			this.gbAbout.Name = "gbAbout";
			this.gbAbout.Size = new System.Drawing.Size(460, 437);
			this.gbAbout.TabIndex = 0;
			this.gbAbout.TabStop = false;
			this.gbAbout.Text = "About this program";
			// 
			// lblGitHub
			// 
			this.lblGitHub.AutoSize = true;
			this.lblGitHub.Location = new System.Drawing.Point(6, 29);
			this.lblGitHub.Name = "lblGitHub";
			this.lblGitHub.Size = new System.Drawing.Size(43, 13);
			this.lblGitHub.TabIndex = 0;
			this.lblGitHub.Text = "GitHub:";
			// 
			// lnklblGitHub
			// 
			this.lnklblGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lnklblGitHub.AutoSize = true;
			this.lnklblGitHub.Location = new System.Drawing.Point(202, 29);
			this.lnklblGitHub.Name = "lnklblGitHub";
			this.lnklblGitHub.Size = new System.Drawing.Size(252, 13);
			this.lnklblGitHub.TabIndex = 2;
			this.lnklblGitHub.TabStop = true;
			this.lnklblGitHub.Text = "https://github.com/DanielMcAssey/YuGiOhTracker";
			this.lnklblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblGitHub_LinkClicked);
			// 
			// lblCreatedBy
			// 
			this.lblCreatedBy.AutoSize = true;
			this.lblCreatedBy.Location = new System.Drawing.Point(6, 16);
			this.lblCreatedBy.Name = "lblCreatedBy";
			this.lblCreatedBy.Size = new System.Drawing.Size(62, 13);
			this.lblCreatedBy.TabIndex = 3;
			this.lblCreatedBy.Text = "Created By:";
			// 
			// lblCreatedByTxt
			// 
			this.lblCreatedByTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCreatedByTxt.AutoSize = true;
			this.lblCreatedByTxt.Location = new System.Drawing.Point(371, 16);
			this.lblCreatedByTxt.Name = "lblCreatedByTxt";
			this.lblCreatedByTxt.Size = new System.Drawing.Size(83, 13);
			this.lblCreatedByTxt.TabIndex = 4;
			this.lblCreatedByTxt.Text = "Daniel McAssey";
			// 
			// txtLicence
			// 
			this.txtLicence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtLicence.Location = new System.Drawing.Point(6, 19);
			this.txtLicence.Multiline = true;
			this.txtLicence.Name = "txtLicence";
			this.txtLicence.ReadOnly = true;
			this.txtLicence.Size = new System.Drawing.Size(433, 361);
			this.txtLicence.TabIndex = 5;
			// 
			// gbLicence
			// 
			this.gbLicence.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbLicence.Controls.Add(this.txtLicence);
			this.gbLicence.Location = new System.Drawing.Point(9, 45);
			this.gbLicence.Name = "gbLicence";
			this.gbLicence.Size = new System.Drawing.Size(445, 386);
			this.gbLicence.TabIndex = 7;
			this.gbLicence.TabStop = false;
			this.gbLicence.Text = "License";
			// 
			// frmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(484, 461);
			this.Controls.Add(this.gbAbout);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmAbout";
			this.Text = "About - YuGiOh Tracker";
			this.Load += new System.EventHandler(this.frmAbout_Load);
			this.gbAbout.ResumeLayout(false);
			this.gbAbout.PerformLayout();
			this.gbLicence.ResumeLayout(false);
			this.gbLicence.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbAbout;
		private System.Windows.Forms.LinkLabel lnklblGitHub;
		private System.Windows.Forms.Label lblGitHub;
		private System.Windows.Forms.TextBox txtLicence;
		private System.Windows.Forms.Label lblCreatedByTxt;
		private System.Windows.Forms.Label lblCreatedBy;
		private System.Windows.Forms.GroupBox gbLicence;
	}
}