namespace YuGiOhTracker
{
	partial class frmUpdates
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUpdates));
			this.gbUpdater = new System.Windows.Forms.GroupBox();
			this.lblCurrentCard = new System.Windows.Forms.Label();
			this.lblCurrentCardText = new System.Windows.Forms.Label();
			this.lblCardPercentage = new System.Windows.Forms.Label();
			this.lblUpdating = new System.Windows.Forms.Label();
			this.pbCards = new System.Windows.Forms.ProgressBar();
			this.lblStatus = new System.Windows.Forms.Label();
			this.lblStatusText = new System.Windows.Forms.Label();
			this.gbUpdater.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbUpdater
			// 
			this.gbUpdater.Controls.Add(this.lblCurrentCard);
			this.gbUpdater.Controls.Add(this.lblCurrentCardText);
			this.gbUpdater.Controls.Add(this.lblCardPercentage);
			this.gbUpdater.Controls.Add(this.lblUpdating);
			this.gbUpdater.Controls.Add(this.pbCards);
			this.gbUpdater.Location = new System.Drawing.Point(12, 26);
			this.gbUpdater.Name = "gbUpdater";
			this.gbUpdater.Size = new System.Drawing.Size(590, 78);
			this.gbUpdater.TabIndex = 0;
			this.gbUpdater.TabStop = false;
			this.gbUpdater.Text = "Updater";
			// 
			// lblCurrentCard
			// 
			this.lblCurrentCard.AutoSize = true;
			this.lblCurrentCard.Location = new System.Drawing.Point(6, 58);
			this.lblCurrentCard.Name = "lblCurrentCard";
			this.lblCurrentCard.Size = new System.Drawing.Size(69, 13);
			this.lblCurrentCard.TabIndex = 7;
			this.lblCurrentCard.Text = "Current Card:";
			// 
			// lblCurrentCardText
			// 
			this.lblCurrentCardText.AutoSize = true;
			this.lblCurrentCardText.Location = new System.Drawing.Point(81, 58);
			this.lblCurrentCardText.Name = "lblCurrentCardText";
			this.lblCurrentCardText.Size = new System.Drawing.Size(29, 13);
			this.lblCurrentCardText.TabIndex = 6;
			this.lblCurrentCardText.Text = "Card";
			// 
			// lblCardPercentage
			// 
			this.lblCardPercentage.AutoSize = true;
			this.lblCardPercentage.Location = new System.Drawing.Point(65, 16);
			this.lblCardPercentage.Name = "lblCardPercentage";
			this.lblCardPercentage.Size = new System.Drawing.Size(21, 13);
			this.lblCardPercentage.TabIndex = 5;
			this.lblCardPercentage.Text = "0%";
			// 
			// lblUpdating
			// 
			this.lblUpdating.AutoSize = true;
			this.lblUpdating.Location = new System.Drawing.Point(6, 16);
			this.lblUpdating.Name = "lblUpdating";
			this.lblUpdating.Size = new System.Drawing.Size(53, 13);
			this.lblUpdating.TabIndex = 4;
			this.lblUpdating.Text = "Updating:";
			// 
			// pbCards
			// 
			this.pbCards.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pbCards.Location = new System.Drawing.Point(6, 32);
			this.pbCards.Name = "pbCards";
			this.pbCards.Size = new System.Drawing.Size(578, 23);
			this.pbCards.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this.pbCards.TabIndex = 3;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(9, 9);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(40, 13);
			this.lblStatus.TabIndex = 3;
			this.lblStatus.Text = "Status:";
			// 
			// lblStatusText
			// 
			this.lblStatusText.AutoSize = true;
			this.lblStatusText.Location = new System.Drawing.Point(55, 9);
			this.lblStatusText.Name = "lblStatusText";
			this.lblStatusText.Size = new System.Drawing.Size(58, 13);
			this.lblStatusText.TabIndex = 4;
			this.lblStatusText.Text = "StatusText";
			// 
			// frmUpdates
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(614, 116);
			this.Controls.Add(this.lblStatusText);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.gbUpdater);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUpdates";
			this.Text = "Checking for Updates";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmUpdates_FormClosing);
			this.Load += new System.EventHandler(this.frmUpdates_Load);
			this.Shown += new System.EventHandler(this.frmUpdates_Shown);
			this.gbUpdater.ResumeLayout(false);
			this.gbUpdater.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox gbUpdater;
		private System.Windows.Forms.Label lblCardPercentage;
		private System.Windows.Forms.Label lblUpdating;
		private System.Windows.Forms.ProgressBar pbCards;
		private System.Windows.Forms.Label lblCurrentCardText;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Label lblStatusText;
		private System.Windows.Forms.Label lblCurrentCard;
	}
}