namespace YuGiOhTracker
{
	partial class frmViewCard
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmViewCard));
			this.btnClose = new System.Windows.Forms.Button();
			this.gbCardDetails = new System.Windows.Forms.GroupBox();
			this.lblBannedText = new System.Windows.Forms.Label();
			this.lblCardCodeSeperator = new System.Windows.Forms.Label();
			this.lblCardCode = new System.Windows.Forms.Label();
			this.lblSet = new System.Windows.Forms.Label();
			this.lnklblSetLink = new System.Windows.Forms.LinkLabel();
			this.lblRarity = new System.Windows.Forms.Label();
			this.lblRarityText = new System.Windows.Forms.Label();
			this.lblNotice = new System.Windows.Forms.Label();
			this.txtDEF = new System.Windows.Forms.TextBox();
			this.txtATK = new System.Windows.Forms.TextBox();
			this.lblDEF = new System.Windows.Forms.Label();
			this.lblATK = new System.Windows.Forms.Label();
			this.lblCardSubtype = new System.Windows.Forms.Label();
			this.lblLevelText = new System.Windows.Forms.Label();
			this.lblLevel = new System.Windows.Forms.Label();
			this.txtCardSubtype = new System.Windows.Forms.TextBox();
			this.txtAttribute = new System.Windows.Forms.TextBox();
			this.lblAttribute = new System.Windows.Forms.Label();
			this.btnNextImage = new System.Windows.Forms.Button();
			this.btnPrevImage = new System.Windows.Forms.Button();
			this.lblImageCount = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.lblDescription = new System.Windows.Forms.Label();
			this.pbIcon = new System.Windows.Forms.PictureBox();
			this.lblCardType = new System.Windows.Forms.Label();
			this.lblCardName = new System.Windows.Forms.Label();
			this.pbCardView = new System.Windows.Forms.PictureBox();
			this.gbPriceHistory = new System.Windows.Forms.GroupBox();
			this.lblPriceStatus = new System.Windows.Forms.Label();
			this.lblPriceLastUpdated = new System.Windows.Forms.Label();
			this.lblPriceDescription = new System.Windows.Forms.Label();
			this.lblShift365 = new System.Windows.Forms.Label();
			this.lblShift180 = new System.Windows.Forms.Label();
			this.lblShift90 = new System.Windows.Forms.Label();
			this.lblShift30 = new System.Windows.Forms.Label();
			this.lblShift7 = new System.Windows.Forms.Label();
			this.lblShift3 = new System.Windows.Forms.Label();
			this.txtShift365 = new System.Windows.Forms.TextBox();
			this.txtShift180 = new System.Windows.Forms.TextBox();
			this.txtShift90 = new System.Windows.Forms.TextBox();
			this.txtShift30 = new System.Windows.Forms.TextBox();
			this.txtShift7 = new System.Windows.Forms.TextBox();
			this.txtShift3 = new System.Windows.Forms.TextBox();
			this.txtShift1 = new System.Windows.Forms.TextBox();
			this.lblShift1 = new System.Windows.Forms.Label();
			this.txtPriceAverage = new System.Windows.Forms.TextBox();
			this.txtPriceLow = new System.Windows.Forms.TextBox();
			this.lblPriceLow = new System.Windows.Forms.Label();
			this.lblPriceAverage = new System.Windows.Forms.Label();
			this.txtPriceHigh = new System.Windows.Forms.TextBox();
			this.lblPriceHigh = new System.Windows.Forms.Label();
			this.gbSimilarCards = new System.Windows.Forms.GroupBox();
			this.dgvCardList = new System.Windows.Forms.DataGridView();
			this.lblSimilarCardStatus = new System.Windows.Forms.Label();
			this.lblSimilarSeperator = new System.Windows.Forms.Label();
			this.lblSimilarCardCount = new System.Windows.Forms.Label();
			this.gbCardDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCardView)).BeginInit();
			this.gbPriceHistory.SuspendLayout();
			this.gbSimilarCards.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
			this.SuspendLayout();
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.Location = new System.Drawing.Point(513, 367);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 0;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// gbCardDetails
			// 
			this.gbCardDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbCardDetails.Controls.Add(this.lblBannedText);
			this.gbCardDetails.Controls.Add(this.lblCardCodeSeperator);
			this.gbCardDetails.Controls.Add(this.lblCardCode);
			this.gbCardDetails.Controls.Add(this.lblSet);
			this.gbCardDetails.Controls.Add(this.lnklblSetLink);
			this.gbCardDetails.Controls.Add(this.lblRarity);
			this.gbCardDetails.Controls.Add(this.lblRarityText);
			this.gbCardDetails.Controls.Add(this.lblNotice);
			this.gbCardDetails.Controls.Add(this.txtDEF);
			this.gbCardDetails.Controls.Add(this.btnClose);
			this.gbCardDetails.Controls.Add(this.txtATK);
			this.gbCardDetails.Controls.Add(this.lblDEF);
			this.gbCardDetails.Controls.Add(this.lblATK);
			this.gbCardDetails.Controls.Add(this.lblCardSubtype);
			this.gbCardDetails.Controls.Add(this.lblLevelText);
			this.gbCardDetails.Controls.Add(this.lblLevel);
			this.gbCardDetails.Controls.Add(this.txtCardSubtype);
			this.gbCardDetails.Controls.Add(this.txtAttribute);
			this.gbCardDetails.Controls.Add(this.lblAttribute);
			this.gbCardDetails.Controls.Add(this.btnNextImage);
			this.gbCardDetails.Controls.Add(this.btnPrevImage);
			this.gbCardDetails.Controls.Add(this.lblImageCount);
			this.gbCardDetails.Controls.Add(this.txtDescription);
			this.gbCardDetails.Controls.Add(this.lblDescription);
			this.gbCardDetails.Controls.Add(this.pbIcon);
			this.gbCardDetails.Controls.Add(this.lblCardType);
			this.gbCardDetails.Controls.Add(this.lblCardName);
			this.gbCardDetails.Controls.Add(this.pbCardView);
			this.gbCardDetails.Location = new System.Drawing.Point(12, 12);
			this.gbCardDetails.Name = "gbCardDetails";
			this.gbCardDetails.Size = new System.Drawing.Size(594, 398);
			this.gbCardDetails.TabIndex = 1;
			this.gbCardDetails.TabStop = false;
			this.gbCardDetails.Text = "Card Details";
			// 
			// lblBannedText
			// 
			this.lblBannedText.AutoSize = true;
			this.lblBannedText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblBannedText.Location = new System.Drawing.Point(8, 48);
			this.lblBannedText.Name = "lblBannedText";
			this.lblBannedText.Size = new System.Drawing.Size(119, 18);
			this.lblBannedText.TabIndex = 27;
			this.lblBannedText.Text = "%ISBANNED%";
			// 
			// lblCardCodeSeperator
			// 
			this.lblCardCodeSeperator.AutoSize = true;
			this.lblCardCodeSeperator.Location = new System.Drawing.Point(71, 0);
			this.lblCardCodeSeperator.Name = "lblCardCodeSeperator";
			this.lblCardCodeSeperator.Size = new System.Drawing.Size(10, 13);
			this.lblCardCodeSeperator.TabIndex = 26;
			this.lblCardCodeSeperator.Text = "-";
			// 
			// lblCardCode
			// 
			this.lblCardCode.AutoSize = true;
			this.lblCardCode.Location = new System.Drawing.Point(87, 0);
			this.lblCardCode.Name = "lblCardCode";
			this.lblCardCode.Size = new System.Drawing.Size(83, 13);
			this.lblCardCode.TabIndex = 25;
			this.lblCardCode.Text = "%CARDCODE%";
			// 
			// lblSet
			// 
			this.lblSet.AutoSize = true;
			this.lblSet.Location = new System.Drawing.Point(255, 111);
			this.lblSet.Name = "lblSet";
			this.lblSet.Size = new System.Drawing.Size(26, 13);
			this.lblSet.TabIndex = 24;
			this.lblSet.Text = "Set:";
			// 
			// lnklblSetLink
			// 
			this.lnklblSetLink.AutoSize = true;
			this.lnklblSetLink.Location = new System.Drawing.Point(322, 111);
			this.lnklblSetLink.Name = "lnklblSetLink";
			this.lnklblSetLink.Size = new System.Drawing.Size(98, 13);
			this.lnklblSetLink.TabIndex = 23;
			this.lnklblSetLink.TabStop = true;
			this.lnklblSetLink.Text = "%CARDSETLINK%";
			this.lnklblSetLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lnklblSetLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblSetLink_LinkClicked);
			// 
			// lblRarity
			// 
			this.lblRarity.AutoSize = true;
			this.lblRarity.Location = new System.Drawing.Point(256, 97);
			this.lblRarity.Name = "lblRarity";
			this.lblRarity.Size = new System.Drawing.Size(37, 13);
			this.lblRarity.TabIndex = 22;
			this.lblRarity.Text = "Rarity:";
			// 
			// lblRarityText
			// 
			this.lblRarityText.AutoSize = true;
			this.lblRarityText.Location = new System.Drawing.Point(322, 97);
			this.lblRarityText.Name = "lblRarityText";
			this.lblRarityText.Size = new System.Drawing.Size(93, 13);
			this.lblRarityText.TabIndex = 20;
			this.lblRarityText.Text = "%CARDRARITY%";
			// 
			// lblNotice
			// 
			this.lblNotice.AutoSize = true;
			this.lblNotice.Location = new System.Drawing.Point(253, 372);
			this.lblNotice.Name = "lblNotice";
			this.lblNotice.Size = new System.Drawing.Size(250, 13);
			this.lblNotice.TabIndex = 19;
			this.lblNotice.Text = "Card images belong to Konami Digital Entertainment";
			// 
			// txtDEF
			// 
			this.txtDEF.Location = new System.Drawing.Point(478, 181);
			this.txtDEF.Name = "txtDEF";
			this.txtDEF.ReadOnly = true;
			this.txtDEF.Size = new System.Drawing.Size(110, 20);
			this.txtDEF.TabIndex = 18;
			this.txtDEF.Text = "%CARDDEF%";
			// 
			// txtATK
			// 
			this.txtATK.Location = new System.Drawing.Point(325, 181);
			this.txtATK.Name = "txtATK";
			this.txtATK.ReadOnly = true;
			this.txtATK.Size = new System.Drawing.Size(110, 20);
			this.txtATK.TabIndex = 17;
			this.txtATK.Text = "%CARDATK%";
			// 
			// lblDEF
			// 
			this.lblDEF.AutoSize = true;
			this.lblDEF.Location = new System.Drawing.Point(441, 184);
			this.lblDEF.Name = "lblDEF";
			this.lblDEF.Size = new System.Drawing.Size(31, 13);
			this.lblDEF.TabIndex = 16;
			this.lblDEF.Text = "DEF:";
			// 
			// lblATK
			// 
			this.lblATK.AutoSize = true;
			this.lblATK.Location = new System.Drawing.Point(255, 184);
			this.lblATK.Name = "lblATK";
			this.lblATK.Size = new System.Drawing.Size(31, 13);
			this.lblATK.TabIndex = 15;
			this.lblATK.Text = "ATK:";
			// 
			// lblCardSubtype
			// 
			this.lblCardSubtype.AutoSize = true;
			this.lblCardSubtype.Location = new System.Drawing.Point(255, 158);
			this.lblCardSubtype.Name = "lblCardSubtype";
			this.lblCardSubtype.Size = new System.Drawing.Size(59, 13);
			this.lblCardSubtype.TabIndex = 14;
			this.lblCardSubtype.Text = "Card Type:";
			// 
			// lblLevelText
			// 
			this.lblLevelText.AutoSize = true;
			this.lblLevelText.Location = new System.Drawing.Point(322, 83);
			this.lblLevelText.Name = "lblLevelText";
			this.lblLevelText.Size = new System.Drawing.Size(86, 13);
			this.lblLevelText.TabIndex = 13;
			this.lblLevelText.Text = "%CARDLEVEL%";
			// 
			// lblLevel
			// 
			this.lblLevel.AutoSize = true;
			this.lblLevel.Location = new System.Drawing.Point(255, 83);
			this.lblLevel.Name = "lblLevel";
			this.lblLevel.Size = new System.Drawing.Size(36, 13);
			this.lblLevel.TabIndex = 12;
			this.lblLevel.Text = "Level:";
			// 
			// txtCardSubtype
			// 
			this.txtCardSubtype.Location = new System.Drawing.Point(325, 155);
			this.txtCardSubtype.Name = "txtCardSubtype";
			this.txtCardSubtype.ReadOnly = true;
			this.txtCardSubtype.Size = new System.Drawing.Size(263, 20);
			this.txtCardSubtype.TabIndex = 11;
			this.txtCardSubtype.Text = "%CARDTYPE%";
			// 
			// txtAttribute
			// 
			this.txtAttribute.Location = new System.Drawing.Point(325, 129);
			this.txtAttribute.Name = "txtAttribute";
			this.txtAttribute.ReadOnly = true;
			this.txtAttribute.Size = new System.Drawing.Size(263, 20);
			this.txtAttribute.TabIndex = 10;
			this.txtAttribute.Text = "%CARDATTRIBUTE%";
			// 
			// lblAttribute
			// 
			this.lblAttribute.AutoSize = true;
			this.lblAttribute.Location = new System.Drawing.Point(256, 132);
			this.lblAttribute.Name = "lblAttribute";
			this.lblAttribute.Size = new System.Drawing.Size(49, 13);
			this.lblAttribute.TabIndex = 9;
			this.lblAttribute.Text = "Attribute:";
			// 
			// btnNextImage
			// 
			this.btnNextImage.Enabled = false;
			this.btnNextImage.Location = new System.Drawing.Point(172, 367);
			this.btnNextImage.Name = "btnNextImage";
			this.btnNextImage.Size = new System.Drawing.Size(75, 23);
			this.btnNextImage.TabIndex = 8;
			this.btnNextImage.Text = ">";
			this.btnNextImage.UseVisualStyleBackColor = true;
			this.btnNextImage.Click += new System.EventHandler(this.btnNextImage_Click);
			// 
			// btnPrevImage
			// 
			this.btnPrevImage.Enabled = false;
			this.btnPrevImage.Location = new System.Drawing.Point(6, 367);
			this.btnPrevImage.Name = "btnPrevImage";
			this.btnPrevImage.Size = new System.Drawing.Size(75, 23);
			this.btnPrevImage.TabIndex = 7;
			this.btnPrevImage.Text = "<";
			this.btnPrevImage.UseVisualStyleBackColor = true;
			this.btnPrevImage.Click += new System.EventHandler(this.btnPrevImage_Click);
			// 
			// lblImageCount
			// 
			this.lblImageCount.AutoSize = true;
			this.lblImageCount.Location = new System.Drawing.Point(112, 372);
			this.lblImageCount.Name = "lblImageCount";
			this.lblImageCount.Size = new System.Drawing.Size(24, 13);
			this.lblImageCount.TabIndex = 6;
			this.lblImageCount.Text = "0/0";
			this.lblImageCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(253, 226);
			this.txtDescription.Multiline = true;
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.ReadOnly = true;
			this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtDescription.Size = new System.Drawing.Size(335, 135);
			this.txtDescription.TabIndex = 5;
			this.txtDescription.Text = "%CARDDESCRIPTION%";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(255, 210);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(60, 13);
			this.lblDescription.TabIndex = 4;
			this.lblDescription.Text = "Description";
			// 
			// pbIcon
			// 
			this.pbIcon.BackColor = System.Drawing.SystemColors.Control;
			this.pbIcon.Image = ((System.Drawing.Image)(resources.GetObject("pbIcon.Image")));
			this.pbIcon.Location = new System.Drawing.Point(258, 64);
			this.pbIcon.Name = "pbIcon";
			this.pbIcon.Size = new System.Drawing.Size(18, 18);
			this.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbIcon.TabIndex = 3;
			this.pbIcon.TabStop = false;
			// 
			// lblCardType
			// 
			this.lblCardType.AutoSize = true;
			this.lblCardType.Location = new System.Drawing.Point(255, 48);
			this.lblCardType.Name = "lblCardType";
			this.lblCardType.Size = new System.Drawing.Size(81, 13);
			this.lblCardType.TabIndex = 2;
			this.lblCardType.Text = "%CARDTYPE%";
			// 
			// lblCardName
			// 
			this.lblCardName.AutoSize = true;
			this.lblCardName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCardName.Location = new System.Drawing.Point(6, 16);
			this.lblCardName.Name = "lblCardName";
			this.lblCardName.Size = new System.Drawing.Size(202, 29);
			this.lblCardName.TabIndex = 1;
			this.lblCardName.Text = "%CARDNAME%";
			// 
			// pbCardView
			// 
			this.pbCardView.Location = new System.Drawing.Point(6, 48);
			this.pbCardView.Name = "pbCardView";
			this.pbCardView.Size = new System.Drawing.Size(241, 313);
			this.pbCardView.TabIndex = 0;
			this.pbCardView.TabStop = false;
			// 
			// gbPriceHistory
			// 
			this.gbPriceHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbPriceHistory.Controls.Add(this.lblPriceStatus);
			this.gbPriceHistory.Controls.Add(this.lblPriceLastUpdated);
			this.gbPriceHistory.Controls.Add(this.lblPriceDescription);
			this.gbPriceHistory.Controls.Add(this.lblShift365);
			this.gbPriceHistory.Controls.Add(this.lblShift180);
			this.gbPriceHistory.Controls.Add(this.lblShift90);
			this.gbPriceHistory.Controls.Add(this.lblShift30);
			this.gbPriceHistory.Controls.Add(this.lblShift7);
			this.gbPriceHistory.Controls.Add(this.lblShift3);
			this.gbPriceHistory.Controls.Add(this.txtShift365);
			this.gbPriceHistory.Controls.Add(this.txtShift180);
			this.gbPriceHistory.Controls.Add(this.txtShift90);
			this.gbPriceHistory.Controls.Add(this.txtShift30);
			this.gbPriceHistory.Controls.Add(this.txtShift7);
			this.gbPriceHistory.Controls.Add(this.txtShift3);
			this.gbPriceHistory.Controls.Add(this.txtShift1);
			this.gbPriceHistory.Controls.Add(this.lblShift1);
			this.gbPriceHistory.Controls.Add(this.txtPriceAverage);
			this.gbPriceHistory.Controls.Add(this.txtPriceLow);
			this.gbPriceHistory.Controls.Add(this.lblPriceLow);
			this.gbPriceHistory.Controls.Add(this.lblPriceAverage);
			this.gbPriceHistory.Controls.Add(this.txtPriceHigh);
			this.gbPriceHistory.Controls.Add(this.lblPriceHigh);
			this.gbPriceHistory.Location = new System.Drawing.Point(12, 416);
			this.gbPriceHistory.Name = "gbPriceHistory";
			this.gbPriceHistory.Size = new System.Drawing.Size(594, 189);
			this.gbPriceHistory.TabIndex = 2;
			this.gbPriceHistory.TabStop = false;
			this.gbPriceHistory.Text = "Price History (All prices are in [$] unless otherwise stated)";
			// 
			// lblPriceStatus
			// 
			this.lblPriceStatus.Location = new System.Drawing.Point(6, 16);
			this.lblPriceStatus.Name = "lblPriceStatus";
			this.lblPriceStatus.Size = new System.Drawing.Size(582, 170);
			this.lblPriceStatus.TabIndex = 0;
			this.lblPriceStatus.Text = "Loading Price Data...";
			this.lblPriceStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblPriceLastUpdated
			// 
			this.lblPriceLastUpdated.AutoSize = true;
			this.lblPriceLastUpdated.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPriceLastUpdated.Location = new System.Drawing.Point(6, 169);
			this.lblPriceLastUpdated.Name = "lblPriceLastUpdated";
			this.lblPriceLastUpdated.Size = new System.Drawing.Size(91, 13);
			this.lblPriceLastUpdated.TabIndex = 22;
			this.lblPriceLastUpdated.Text = "%LASTUPDATE%";
			// 
			// lblPriceDescription
			// 
			this.lblPriceDescription.Location = new System.Drawing.Point(8, 123);
			this.lblPriceDescription.Name = "lblPriceDescription";
			this.lblPriceDescription.Size = new System.Drawing.Size(297, 46);
			this.lblPriceDescription.TabIndex = 21;
			this.lblPriceDescription.Text = "These prices are as accurate as possible, however there may be some mistakes plea" +
    "se do not take these as official figures, rather use these as guidelines.";
			// 
			// lblShift365
			// 
			this.lblShift365.AutoSize = true;
			this.lblShift365.Location = new System.Drawing.Point(311, 152);
			this.lblShift365.Name = "lblShift365";
			this.lblShift365.Size = new System.Drawing.Size(85, 13);
			this.lblShift365.TabIndex = 20;
			this.lblShift365.Text = "Shift (365 Days):";
			// 
			// lblShift180
			// 
			this.lblShift180.AutoSize = true;
			this.lblShift180.Location = new System.Drawing.Point(311, 126);
			this.lblShift180.Name = "lblShift180";
			this.lblShift180.Size = new System.Drawing.Size(85, 13);
			this.lblShift180.TabIndex = 19;
			this.lblShift180.Text = "Shift (180 Days):";
			// 
			// lblShift90
			// 
			this.lblShift90.AutoSize = true;
			this.lblShift90.Location = new System.Drawing.Point(311, 100);
			this.lblShift90.Name = "lblShift90";
			this.lblShift90.Size = new System.Drawing.Size(79, 13);
			this.lblShift90.TabIndex = 18;
			this.lblShift90.Text = "Shift (90 Days):";
			// 
			// lblShift30
			// 
			this.lblShift30.AutoSize = true;
			this.lblShift30.Location = new System.Drawing.Point(311, 74);
			this.lblShift30.Name = "lblShift30";
			this.lblShift30.Size = new System.Drawing.Size(79, 13);
			this.lblShift30.TabIndex = 17;
			this.lblShift30.Text = "Shift (30 Days):";
			// 
			// lblShift7
			// 
			this.lblShift7.AutoSize = true;
			this.lblShift7.Location = new System.Drawing.Point(311, 48);
			this.lblShift7.Name = "lblShift7";
			this.lblShift7.Size = new System.Drawing.Size(73, 13);
			this.lblShift7.TabIndex = 16;
			this.lblShift7.Text = "Shift (7 Days):";
			// 
			// lblShift3
			// 
			this.lblShift3.AutoSize = true;
			this.lblShift3.Location = new System.Drawing.Point(311, 22);
			this.lblShift3.Name = "lblShift3";
			this.lblShift3.Size = new System.Drawing.Size(73, 13);
			this.lblShift3.TabIndex = 15;
			this.lblShift3.Text = "Shift (3 Days):";
			// 
			// txtShift365
			// 
			this.txtShift365.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift365.Location = new System.Drawing.Point(402, 149);
			this.txtShift365.Name = "txtShift365";
			this.txtShift365.ReadOnly = true;
			this.txtShift365.Size = new System.Drawing.Size(186, 20);
			this.txtShift365.TabIndex = 14;
			// 
			// txtShift180
			// 
			this.txtShift180.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift180.Location = new System.Drawing.Point(402, 123);
			this.txtShift180.Name = "txtShift180";
			this.txtShift180.ReadOnly = true;
			this.txtShift180.Size = new System.Drawing.Size(186, 20);
			this.txtShift180.TabIndex = 13;
			// 
			// txtShift90
			// 
			this.txtShift90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift90.Location = new System.Drawing.Point(402, 97);
			this.txtShift90.Name = "txtShift90";
			this.txtShift90.ReadOnly = true;
			this.txtShift90.Size = new System.Drawing.Size(186, 20);
			this.txtShift90.TabIndex = 12;
			// 
			// txtShift30
			// 
			this.txtShift30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift30.Location = new System.Drawing.Point(402, 71);
			this.txtShift30.Name = "txtShift30";
			this.txtShift30.ReadOnly = true;
			this.txtShift30.Size = new System.Drawing.Size(186, 20);
			this.txtShift30.TabIndex = 11;
			// 
			// txtShift7
			// 
			this.txtShift7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift7.Location = new System.Drawing.Point(402, 45);
			this.txtShift7.Name = "txtShift7";
			this.txtShift7.ReadOnly = true;
			this.txtShift7.Size = new System.Drawing.Size(186, 20);
			this.txtShift7.TabIndex = 10;
			// 
			// txtShift3
			// 
			this.txtShift3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift3.Location = new System.Drawing.Point(402, 19);
			this.txtShift3.Name = "txtShift3";
			this.txtShift3.ReadOnly = true;
			this.txtShift3.Size = new System.Drawing.Size(186, 20);
			this.txtShift3.TabIndex = 9;
			// 
			// txtShift1
			// 
			this.txtShift1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtShift1.Location = new System.Drawing.Point(94, 97);
			this.txtShift1.Name = "txtShift1";
			this.txtShift1.ReadOnly = true;
			this.txtShift1.Size = new System.Drawing.Size(211, 20);
			this.txtShift1.TabIndex = 8;
			// 
			// lblShift1
			// 
			this.lblShift1.AutoSize = true;
			this.lblShift1.Location = new System.Drawing.Point(8, 100);
			this.lblShift1.Name = "lblShift1";
			this.lblShift1.Size = new System.Drawing.Size(83, 13);
			this.lblShift1.TabIndex = 7;
			this.lblShift1.Text = "Shift (24 Hours):";
			// 
			// txtPriceAverage
			// 
			this.txtPriceAverage.Location = new System.Drawing.Point(94, 71);
			this.txtPriceAverage.Name = "txtPriceAverage";
			this.txtPriceAverage.ReadOnly = true;
			this.txtPriceAverage.Size = new System.Drawing.Size(211, 20);
			this.txtPriceAverage.TabIndex = 6;
			// 
			// txtPriceLow
			// 
			this.txtPriceLow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtPriceLow.Location = new System.Drawing.Point(94, 45);
			this.txtPriceLow.Name = "txtPriceLow";
			this.txtPriceLow.ReadOnly = true;
			this.txtPriceLow.Size = new System.Drawing.Size(211, 20);
			this.txtPriceLow.TabIndex = 5;
			// 
			// lblPriceLow
			// 
			this.lblPriceLow.AutoSize = true;
			this.lblPriceLow.Location = new System.Drawing.Point(8, 48);
			this.lblPriceLow.Name = "lblPriceLow";
			this.lblPriceLow.Size = new System.Drawing.Size(30, 13);
			this.lblPriceLow.TabIndex = 4;
			this.lblPriceLow.Text = "Low:";
			// 
			// lblPriceAverage
			// 
			this.lblPriceAverage.AutoSize = true;
			this.lblPriceAverage.Location = new System.Drawing.Point(8, 74);
			this.lblPriceAverage.Name = "lblPriceAverage";
			this.lblPriceAverage.Size = new System.Drawing.Size(50, 13);
			this.lblPriceAverage.TabIndex = 3;
			this.lblPriceAverage.Text = "Average:";
			// 
			// txtPriceHigh
			// 
			this.txtPriceHigh.Location = new System.Drawing.Point(94, 19);
			this.txtPriceHigh.Name = "txtPriceHigh";
			this.txtPriceHigh.ReadOnly = true;
			this.txtPriceHigh.Size = new System.Drawing.Size(211, 20);
			this.txtPriceHigh.TabIndex = 2;
			// 
			// lblPriceHigh
			// 
			this.lblPriceHigh.AutoSize = true;
			this.lblPriceHigh.Location = new System.Drawing.Point(8, 22);
			this.lblPriceHigh.Name = "lblPriceHigh";
			this.lblPriceHigh.Size = new System.Drawing.Size(32, 13);
			this.lblPriceHigh.TabIndex = 1;
			this.lblPriceHigh.Text = "High:";
			// 
			// gbSimilarCards
			// 
			this.gbSimilarCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gbSimilarCards.Controls.Add(this.lblSimilarCardCount);
			this.gbSimilarCards.Controls.Add(this.lblSimilarSeperator);
			this.gbSimilarCards.Controls.Add(this.lblSimilarCardStatus);
			this.gbSimilarCards.Controls.Add(this.dgvCardList);
			this.gbSimilarCards.Location = new System.Drawing.Point(12, 611);
			this.gbSimilarCards.Name = "gbSimilarCards";
			this.gbSimilarCards.Size = new System.Drawing.Size(594, 112);
			this.gbSimilarCards.TabIndex = 3;
			this.gbSimilarCards.TabStop = false;
			this.gbSimilarCards.Text = "Similar Cards";
			// 
			// dgvCardList
			// 
			this.dgvCardList.AllowUserToAddRows = false;
			this.dgvCardList.AllowUserToDeleteRows = false;
			this.dgvCardList.AllowUserToResizeRows = false;
			this.dgvCardList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvCardList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCardList.Location = new System.Drawing.Point(6, 19);
			this.dgvCardList.MultiSelect = false;
			this.dgvCardList.Name = "dgvCardList";
			this.dgvCardList.ReadOnly = true;
			this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCardList.Size = new System.Drawing.Size(582, 87);
			this.dgvCardList.TabIndex = 2;
			this.dgvCardList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCardList_CellContentDoubleClick);
			this.dgvCardList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCardList_KeyDown);
			this.dgvCardList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCardList_MouseClick);
			// 
			// lblSimilarCardStatus
			// 
			this.lblSimilarCardStatus.Location = new System.Drawing.Point(6, 16);
			this.lblSimilarCardStatus.Name = "lblSimilarCardStatus";
			this.lblSimilarCardStatus.Size = new System.Drawing.Size(582, 90);
			this.lblSimilarCardStatus.TabIndex = 3;
			this.lblSimilarCardStatus.Text = "Loading Similar Cards...";
			this.lblSimilarCardStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSimilarSeperator
			// 
			this.lblSimilarSeperator.AutoSize = true;
			this.lblSimilarSeperator.Location = new System.Drawing.Point(71, 0);
			this.lblSimilarSeperator.Name = "lblSimilarSeperator";
			this.lblSimilarSeperator.Size = new System.Drawing.Size(10, 13);
			this.lblSimilarSeperator.TabIndex = 4;
			this.lblSimilarSeperator.Text = "-";
			// 
			// lblSimilarCardCount
			// 
			this.lblSimilarCardCount.AutoSize = true;
			this.lblSimilarCardCount.Location = new System.Drawing.Point(87, 0);
			this.lblSimilarCardCount.Name = "lblSimilarCardCount";
			this.lblSimilarCardCount.Size = new System.Drawing.Size(134, 13);
			this.lblSimilarCardCount.TabIndex = 5;
			this.lblSimilarCardCount.Text = "%CARDSIMILARCOUNT%";
			// 
			// frmViewCard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(618, 735);
			this.Controls.Add(this.gbSimilarCards);
			this.Controls.Add(this.gbPriceHistory);
			this.Controls.Add(this.gbCardDetails);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "frmViewCard";
			this.Text = "View Card - %CARDNAME%";
			this.Load += new System.EventHandler(this.frmViewCard_Load);
			this.gbCardDetails.ResumeLayout(false);
			this.gbCardDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pbCardView)).EndInit();
			this.gbPriceHistory.ResumeLayout(false);
			this.gbPriceHistory.PerformLayout();
			this.gbSimilarCards.ResumeLayout(false);
			this.gbSimilarCards.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.GroupBox gbCardDetails;
		private System.Windows.Forms.Label lblCardName;
		private System.Windows.Forms.PictureBox pbCardView;
		private System.Windows.Forms.Label lblCardType;
		private System.Windows.Forms.PictureBox pbIcon;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.Button btnNextImage;
		private System.Windows.Forms.Button btnPrevImage;
		private System.Windows.Forms.Label lblImageCount;
		private System.Windows.Forms.Label lblLevelText;
		private System.Windows.Forms.Label lblLevel;
		private System.Windows.Forms.TextBox txtCardSubtype;
		private System.Windows.Forms.TextBox txtAttribute;
		private System.Windows.Forms.Label lblAttribute;
		private System.Windows.Forms.TextBox txtDEF;
		private System.Windows.Forms.TextBox txtATK;
		private System.Windows.Forms.Label lblDEF;
		private System.Windows.Forms.Label lblATK;
		private System.Windows.Forms.Label lblCardSubtype;
		private System.Windows.Forms.Label lblNotice;
		private System.Windows.Forms.Label lblRarityText;
		private System.Windows.Forms.Label lblRarity;
		private System.Windows.Forms.LinkLabel lnklblSetLink;
		private System.Windows.Forms.Label lblSet;
		private System.Windows.Forms.Label lblCardCodeSeperator;
		private System.Windows.Forms.Label lblCardCode;
		private System.Windows.Forms.Label lblBannedText;
		private System.Windows.Forms.GroupBox gbPriceHistory;
		private System.Windows.Forms.Label lblPriceStatus;
		private System.Windows.Forms.TextBox txtPriceHigh;
		private System.Windows.Forms.Label lblPriceHigh;
		private System.Windows.Forms.Label lblPriceAverage;
		private System.Windows.Forms.TextBox txtPriceAverage;
		private System.Windows.Forms.TextBox txtPriceLow;
		private System.Windows.Forms.Label lblPriceLow;
		private System.Windows.Forms.TextBox txtShift365;
		private System.Windows.Forms.TextBox txtShift180;
		private System.Windows.Forms.TextBox txtShift90;
		private System.Windows.Forms.TextBox txtShift30;
		private System.Windows.Forms.TextBox txtShift7;
		private System.Windows.Forms.TextBox txtShift3;
		private System.Windows.Forms.TextBox txtShift1;
		private System.Windows.Forms.Label lblShift1;
		private System.Windows.Forms.Label lblShift365;
		private System.Windows.Forms.Label lblShift180;
		private System.Windows.Forms.Label lblShift90;
		private System.Windows.Forms.Label lblShift30;
		private System.Windows.Forms.Label lblShift7;
		private System.Windows.Forms.Label lblShift3;
		private System.Windows.Forms.Label lblPriceDescription;
		private System.Windows.Forms.Label lblPriceLastUpdated;
		private System.Windows.Forms.GroupBox gbSimilarCards;
		private System.Windows.Forms.Label lblSimilarCardStatus;
		private System.Windows.Forms.DataGridView dgvCardList;
		private System.Windows.Forms.Label lblSimilarCardCount;
		private System.Windows.Forms.Label lblSimilarSeperator;
	}
}