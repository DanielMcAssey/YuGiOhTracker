namespace YuGiOhTracker
{
	partial class frmMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.msMain = new System.Windows.Forms.MenuStrip();
			this.msMainFile = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainFileSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.msMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainUpdates = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.msMainHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.dgvCardList = new System.Windows.Forms.DataGridView();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tpCardList = new System.Windows.Forms.TabPage();
			this.gbCardList = new System.Windows.Forms.GroupBox();
			this.cbSearchCardType = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSearch = new System.Windows.Forms.Button();
			this.lblSearchIn = new System.Windows.Forms.Label();
			this.cbSearchInCardList = new System.Windows.Forms.ComboBox();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.lblSearch = new System.Windows.Forms.Label();
			this.tpOfficialDecks = new System.Windows.Forms.TabPage();
			this.gbOfficialDeckList = new System.Windows.Forms.GroupBox();
			this.btnSearchOfficial = new System.Windows.Forms.Button();
			this.lblSearchInOfficial = new System.Windows.Forms.Label();
			this.cbSearchInOfficial = new System.Windows.Forms.ComboBox();
			this.txtSearchOfficial = new System.Windows.Forms.TextBox();
			this.lblSearchOfficial = new System.Windows.Forms.Label();
			this.dgvOfficialDecks = new System.Windows.Forms.DataGridView();
			this.tpUserCollection = new System.Windows.Forms.TabPage();
			this.gbUserCollection = new System.Windows.Forms.GroupBox();
			this.cbUserCollectionCardType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnUserCollectionSearch = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbUserCollectionIn = new System.Windows.Forms.ComboBox();
			this.txtUserCollectionSearch = new System.Windows.Forms.TextBox();
			this.lblUserCollSearch = new System.Windows.Forms.Label();
			this.dgvUserCollection = new System.Windows.Forms.DataGridView();
			this.tpUserDecks = new System.Windows.Forms.TabPage();
			this.tpLimitedCards = new System.Windows.Forms.TabPage();
			this.gbLimitedCardList = new System.Windows.Forms.GroupBox();
			this.cbSearchLimitedCardType = new System.Windows.Forms.ComboBox();
			this.lblSearchLimitedWith = new System.Windows.Forms.Label();
			this.btnSearchLimitedCards = new System.Windows.Forms.Button();
			this.lblSearchInLimited = new System.Windows.Forms.Label();
			this.cbSearchInLimited = new System.Windows.Forms.ComboBox();
			this.txtSearchLimited = new System.Windows.Forms.TextBox();
			this.lblLimitedSearchFor = new System.Windows.Forms.Label();
			this.dgvLimitedCards = new System.Windows.Forms.DataGridView();
			this.ssMain = new System.Windows.Forms.StatusStrip();
			this.ssMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.ssSpring = new System.Windows.Forms.ToolStripStatusLabel();
			this.ssCardCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.ssMainProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.msMain.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).BeginInit();
			this.tcMain.SuspendLayout();
			this.tpCardList.SuspendLayout();
			this.gbCardList.SuspendLayout();
			this.tpOfficialDecks.SuspendLayout();
			this.gbOfficialDeckList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvOfficialDecks)).BeginInit();
			this.tpUserCollection.SuspendLayout();
			this.gbUserCollection.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUserCollection)).BeginInit();
			this.tpLimitedCards.SuspendLayout();
			this.gbLimitedCardList.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLimitedCards)).BeginInit();
			this.ssMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// msMain
			// 
			this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFile,
            this.msMainUpdates,
            this.msMainHelp});
			this.msMain.Location = new System.Drawing.Point(0, 0);
			this.msMain.Name = "msMain";
			this.msMain.Size = new System.Drawing.Size(923, 24);
			this.msMain.TabIndex = 0;
			this.msMain.Text = "menuStrip1";
			// 
			// msMainFile
			// 
			this.msMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainFileSettings,
            this.toolStripSeparator1,
            this.msMainFileExit});
			this.msMainFile.Name = "msMainFile";
			this.msMainFile.Size = new System.Drawing.Size(37, 20);
			this.msMainFile.Text = "File";
			// 
			// msMainFileSettings
			// 
			this.msMainFileSettings.Name = "msMainFileSettings";
			this.msMainFileSettings.Size = new System.Drawing.Size(152, 22);
			this.msMainFileSettings.Text = "Settings...";
			this.msMainFileSettings.Click += new System.EventHandler(this.msMainFileSettings_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// msMainFileExit
			// 
			this.msMainFileExit.Name = "msMainFileExit";
			this.msMainFileExit.Size = new System.Drawing.Size(152, 22);
			this.msMainFileExit.Text = "Exit";
			this.msMainFileExit.Click += new System.EventHandler(this.msMainFileExit_Click);
			// 
			// msMainUpdates
			// 
			this.msMainUpdates.Name = "msMainUpdates";
			this.msMainUpdates.Size = new System.Drawing.Size(118, 20);
			this.msMainUpdates.Text = "Check For Updates";
			this.msMainUpdates.Click += new System.EventHandler(this.msMainUpdates_Click);
			// 
			// msMainHelp
			// 
			this.msMainHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msMainHelpAbout});
			this.msMainHelp.Name = "msMainHelp";
			this.msMainHelp.Size = new System.Drawing.Size(44, 20);
			this.msMainHelp.Text = "Help";
			// 
			// msMainHelpAbout
			// 
			this.msMainHelpAbout.Name = "msMainHelpAbout";
			this.msMainHelpAbout.Size = new System.Drawing.Size(107, 22);
			this.msMainHelpAbout.Text = "About";
			this.msMainHelpAbout.Click += new System.EventHandler(this.msMainHelpAbout_Click);
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
			this.dgvCardList.Location = new System.Drawing.Point(6, 46);
			this.dgvCardList.MultiSelect = false;
			this.dgvCardList.Name = "dgvCardList";
			this.dgvCardList.ReadOnly = true;
			this.dgvCardList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvCardList.Size = new System.Drawing.Size(887, 347);
			this.dgvCardList.TabIndex = 1;
			this.dgvCardList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCardList_CellContentDoubleClick);
			this.dgvCardList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCardList_KeyDown);
			this.dgvCardList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvCardList_MouseClick);
			// 
			// tcMain
			// 
			this.tcMain.Controls.Add(this.tpCardList);
			this.tcMain.Controls.Add(this.tpOfficialDecks);
			this.tcMain.Controls.Add(this.tpUserCollection);
			this.tcMain.Controls.Add(this.tpUserDecks);
			this.tcMain.Controls.Add(this.tpLimitedCards);
			this.tcMain.Location = new System.Drawing.Point(0, 27);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(923, 437);
			this.tcMain.TabIndex = 2;
			this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
			// 
			// tpCardList
			// 
			this.tpCardList.Controls.Add(this.gbCardList);
			this.tpCardList.Location = new System.Drawing.Point(4, 22);
			this.tpCardList.Name = "tpCardList";
			this.tpCardList.Padding = new System.Windows.Forms.Padding(3);
			this.tpCardList.Size = new System.Drawing.Size(915, 411);
			this.tpCardList.TabIndex = 0;
			this.tpCardList.Text = "Cards";
			this.tpCardList.UseVisualStyleBackColor = true;
			// 
			// gbCardList
			// 
			this.gbCardList.Controls.Add(this.cbSearchCardType);
			this.gbCardList.Controls.Add(this.label1);
			this.gbCardList.Controls.Add(this.btnSearch);
			this.gbCardList.Controls.Add(this.lblSearchIn);
			this.gbCardList.Controls.Add(this.cbSearchInCardList);
			this.gbCardList.Controls.Add(this.txtSearch);
			this.gbCardList.Controls.Add(this.lblSearch);
			this.gbCardList.Controls.Add(this.dgvCardList);
			this.gbCardList.Location = new System.Drawing.Point(8, 3);
			this.gbCardList.Name = "gbCardList";
			this.gbCardList.Size = new System.Drawing.Size(899, 399);
			this.gbCardList.TabIndex = 3;
			this.gbCardList.TabStop = false;
			this.gbCardList.Text = "Card List";
			// 
			// cbSearchCardType
			// 
			this.cbSearchCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearchCardType.FormattingEnabled = true;
			this.cbSearchCardType.Location = new System.Drawing.Point(603, 19);
			this.cbSearchCardType.Name = "cbSearchCardType";
			this.cbSearchCardType.Size = new System.Drawing.Size(159, 21);
			this.cbSearchCardType.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(518, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "With card type:";
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(768, 17);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(125, 23);
			this.btnSearch.TabIndex = 5;
			this.btnSearch.Text = "Search";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// lblSearchIn
			// 
			this.lblSearchIn.AutoSize = true;
			this.lblSearchIn.Location = new System.Drawing.Point(327, 22);
			this.lblSearchIn.Name = "lblSearchIn";
			this.lblSearchIn.Size = new System.Drawing.Size(19, 13);
			this.lblSearchIn.TabIndex = 5;
			this.lblSearchIn.Text = "In:";
			// 
			// cbSearchInCardList
			// 
			this.cbSearchInCardList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearchInCardList.FormattingEnabled = true;
			this.cbSearchInCardList.Location = new System.Drawing.Point(352, 19);
			this.cbSearchInCardList.Name = "cbSearchInCardList";
			this.cbSearchInCardList.Size = new System.Drawing.Size(160, 21);
			this.cbSearchInCardList.TabIndex = 3;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(71, 19);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(250, 20);
			this.txtSearch.TabIndex = 2;
			this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(6, 22);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(59, 13);
			this.lblSearch.TabIndex = 2;
			this.lblSearch.Text = "Search for:";
			// 
			// tpOfficialDecks
			// 
			this.tpOfficialDecks.Controls.Add(this.gbOfficialDeckList);
			this.tpOfficialDecks.Location = new System.Drawing.Point(4, 22);
			this.tpOfficialDecks.Name = "tpOfficialDecks";
			this.tpOfficialDecks.Size = new System.Drawing.Size(915, 411);
			this.tpOfficialDecks.TabIndex = 2;
			this.tpOfficialDecks.Text = "Official Decks";
			this.tpOfficialDecks.UseVisualStyleBackColor = true;
			// 
			// gbOfficialDeckList
			// 
			this.gbOfficialDeckList.Controls.Add(this.btnSearchOfficial);
			this.gbOfficialDeckList.Controls.Add(this.lblSearchInOfficial);
			this.gbOfficialDeckList.Controls.Add(this.cbSearchInOfficial);
			this.gbOfficialDeckList.Controls.Add(this.txtSearchOfficial);
			this.gbOfficialDeckList.Controls.Add(this.lblSearchOfficial);
			this.gbOfficialDeckList.Controls.Add(this.dgvOfficialDecks);
			this.gbOfficialDeckList.Location = new System.Drawing.Point(8, 3);
			this.gbOfficialDeckList.Name = "gbOfficialDeckList";
			this.gbOfficialDeckList.Size = new System.Drawing.Size(899, 399);
			this.gbOfficialDeckList.TabIndex = 4;
			this.gbOfficialDeckList.TabStop = false;
			this.gbOfficialDeckList.Text = "Official Deck List";
			// 
			// btnSearchOfficial
			// 
			this.btnSearchOfficial.Location = new System.Drawing.Point(768, 17);
			this.btnSearchOfficial.Name = "btnSearchOfficial";
			this.btnSearchOfficial.Size = new System.Drawing.Size(125, 23);
			this.btnSearchOfficial.TabIndex = 4;
			this.btnSearchOfficial.Text = "Search";
			this.btnSearchOfficial.UseVisualStyleBackColor = true;
			this.btnSearchOfficial.Click += new System.EventHandler(this.btnSearchOfficial_Click);
			// 
			// lblSearchInOfficial
			// 
			this.lblSearchInOfficial.AutoSize = true;
			this.lblSearchInOfficial.Location = new System.Drawing.Point(577, 22);
			this.lblSearchInOfficial.Name = "lblSearchInOfficial";
			this.lblSearchInOfficial.Size = new System.Drawing.Size(19, 13);
			this.lblSearchInOfficial.TabIndex = 5;
			this.lblSearchInOfficial.Text = "In:";
			// 
			// cbSearchInOfficial
			// 
			this.cbSearchInOfficial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearchInOfficial.FormattingEnabled = true;
			this.cbSearchInOfficial.Location = new System.Drawing.Point(602, 19);
			this.cbSearchInOfficial.Name = "cbSearchInOfficial";
			this.cbSearchInOfficial.Size = new System.Drawing.Size(160, 21);
			this.cbSearchInOfficial.TabIndex = 3;
			// 
			// txtSearchOfficial
			// 
			this.txtSearchOfficial.Location = new System.Drawing.Point(71, 19);
			this.txtSearchOfficial.Name = "txtSearchOfficial";
			this.txtSearchOfficial.Size = new System.Drawing.Size(500, 20);
			this.txtSearchOfficial.TabIndex = 2;
			this.txtSearchOfficial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchOfficial_KeyDown);
			// 
			// lblSearchOfficial
			// 
			this.lblSearchOfficial.AutoSize = true;
			this.lblSearchOfficial.Location = new System.Drawing.Point(6, 22);
			this.lblSearchOfficial.Name = "lblSearchOfficial";
			this.lblSearchOfficial.Size = new System.Drawing.Size(59, 13);
			this.lblSearchOfficial.TabIndex = 2;
			this.lblSearchOfficial.Text = "Search for:";
			// 
			// dgvOfficialDecks
			// 
			this.dgvOfficialDecks.AllowUserToAddRows = false;
			this.dgvOfficialDecks.AllowUserToDeleteRows = false;
			this.dgvOfficialDecks.AllowUserToResizeRows = false;
			this.dgvOfficialDecks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvOfficialDecks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOfficialDecks.Location = new System.Drawing.Point(6, 46);
			this.dgvOfficialDecks.MultiSelect = false;
			this.dgvOfficialDecks.Name = "dgvOfficialDecks";
			this.dgvOfficialDecks.ReadOnly = true;
			this.dgvOfficialDecks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOfficialDecks.Size = new System.Drawing.Size(887, 347);
			this.dgvOfficialDecks.TabIndex = 1;
			this.dgvOfficialDecks.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOfficialDecks_CellContentDoubleClick);
			this.dgvOfficialDecks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOfficialDecks_KeyDown);
			this.dgvOfficialDecks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvOfficialDecks_MouseClick);
			// 
			// tpUserCollection
			// 
			this.tpUserCollection.Controls.Add(this.gbUserCollection);
			this.tpUserCollection.Location = new System.Drawing.Point(4, 22);
			this.tpUserCollection.Name = "tpUserCollection";
			this.tpUserCollection.Size = new System.Drawing.Size(915, 411);
			this.tpUserCollection.TabIndex = 3;
			this.tpUserCollection.Text = "User Collection";
			this.tpUserCollection.UseVisualStyleBackColor = true;
			// 
			// gbUserCollection
			// 
			this.gbUserCollection.Controls.Add(this.cbUserCollectionCardType);
			this.gbUserCollection.Controls.Add(this.label2);
			this.gbUserCollection.Controls.Add(this.btnUserCollectionSearch);
			this.gbUserCollection.Controls.Add(this.label3);
			this.gbUserCollection.Controls.Add(this.cbUserCollectionIn);
			this.gbUserCollection.Controls.Add(this.txtUserCollectionSearch);
			this.gbUserCollection.Controls.Add(this.lblUserCollSearch);
			this.gbUserCollection.Controls.Add(this.dgvUserCollection);
			this.gbUserCollection.Location = new System.Drawing.Point(8, 3);
			this.gbUserCollection.Name = "gbUserCollection";
			this.gbUserCollection.Size = new System.Drawing.Size(899, 399);
			this.gbUserCollection.TabIndex = 4;
			this.gbUserCollection.TabStop = false;
			this.gbUserCollection.Text = "Your Collection";
			// 
			// cbUserCollectionCardType
			// 
			this.cbUserCollectionCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUserCollectionCardType.FormattingEnabled = true;
			this.cbUserCollectionCardType.Location = new System.Drawing.Point(603, 19);
			this.cbUserCollectionCardType.Name = "cbUserCollectionCardType";
			this.cbUserCollectionCardType.Size = new System.Drawing.Size(159, 21);
			this.cbUserCollectionCardType.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(518, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "With card type:";
			// 
			// btnUserCollectionSearch
			// 
			this.btnUserCollectionSearch.Location = new System.Drawing.Point(768, 17);
			this.btnUserCollectionSearch.Name = "btnUserCollectionSearch";
			this.btnUserCollectionSearch.Size = new System.Drawing.Size(125, 23);
			this.btnUserCollectionSearch.TabIndex = 6;
			this.btnUserCollectionSearch.Text = "Search";
			this.btnUserCollectionSearch.UseVisualStyleBackColor = true;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(327, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "In:";
			// 
			// cbUserCollectionIn
			// 
			this.cbUserCollectionIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUserCollectionIn.FormattingEnabled = true;
			this.cbUserCollectionIn.Location = new System.Drawing.Point(352, 19);
			this.cbUserCollectionIn.Name = "cbUserCollectionIn";
			this.cbUserCollectionIn.Size = new System.Drawing.Size(160, 21);
			this.cbUserCollectionIn.TabIndex = 3;
			// 
			// txtUserCollectionSearch
			// 
			this.txtUserCollectionSearch.Location = new System.Drawing.Point(71, 19);
			this.txtUserCollectionSearch.Name = "txtUserCollectionSearch";
			this.txtUserCollectionSearch.Size = new System.Drawing.Size(250, 20);
			this.txtUserCollectionSearch.TabIndex = 2;
			// 
			// lblUserCollSearch
			// 
			this.lblUserCollSearch.AutoSize = true;
			this.lblUserCollSearch.Location = new System.Drawing.Point(6, 22);
			this.lblUserCollSearch.Name = "lblUserCollSearch";
			this.lblUserCollSearch.Size = new System.Drawing.Size(59, 13);
			this.lblUserCollSearch.TabIndex = 2;
			this.lblUserCollSearch.Text = "Search for:";
			// 
			// dgvUserCollection
			// 
			this.dgvUserCollection.AllowUserToAddRows = false;
			this.dgvUserCollection.AllowUserToDeleteRows = false;
			this.dgvUserCollection.AllowUserToResizeRows = false;
			this.dgvUserCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvUserCollection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUserCollection.Location = new System.Drawing.Point(6, 46);
			this.dgvUserCollection.MultiSelect = false;
			this.dgvUserCollection.Name = "dgvUserCollection";
			this.dgvUserCollection.ReadOnly = true;
			this.dgvUserCollection.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvUserCollection.Size = new System.Drawing.Size(887, 347);
			this.dgvUserCollection.TabIndex = 1;
			// 
			// tpUserDecks
			// 
			this.tpUserDecks.Location = new System.Drawing.Point(4, 22);
			this.tpUserDecks.Name = "tpUserDecks";
			this.tpUserDecks.Padding = new System.Windows.Forms.Padding(3);
			this.tpUserDecks.Size = new System.Drawing.Size(915, 411);
			this.tpUserDecks.TabIndex = 1;
			this.tpUserDecks.Text = "User Decks";
			this.tpUserDecks.UseVisualStyleBackColor = true;
			// 
			// tpLimitedCards
			// 
			this.tpLimitedCards.Controls.Add(this.gbLimitedCardList);
			this.tpLimitedCards.Location = new System.Drawing.Point(4, 22);
			this.tpLimitedCards.Name = "tpLimitedCards";
			this.tpLimitedCards.Size = new System.Drawing.Size(915, 411);
			this.tpLimitedCards.TabIndex = 4;
			this.tpLimitedCards.Text = "Limited Cards";
			this.tpLimitedCards.UseVisualStyleBackColor = true;
			// 
			// gbLimitedCardList
			// 
			this.gbLimitedCardList.Controls.Add(this.cbSearchLimitedCardType);
			this.gbLimitedCardList.Controls.Add(this.lblSearchLimitedWith);
			this.gbLimitedCardList.Controls.Add(this.btnSearchLimitedCards);
			this.gbLimitedCardList.Controls.Add(this.lblSearchInLimited);
			this.gbLimitedCardList.Controls.Add(this.cbSearchInLimited);
			this.gbLimitedCardList.Controls.Add(this.txtSearchLimited);
			this.gbLimitedCardList.Controls.Add(this.lblLimitedSearchFor);
			this.gbLimitedCardList.Controls.Add(this.dgvLimitedCards);
			this.gbLimitedCardList.Location = new System.Drawing.Point(8, 3);
			this.gbLimitedCardList.Name = "gbLimitedCardList";
			this.gbLimitedCardList.Size = new System.Drawing.Size(899, 399);
			this.gbLimitedCardList.TabIndex = 4;
			this.gbLimitedCardList.TabStop = false;
			this.gbLimitedCardList.Text = "Card List";
			// 
			// cbSearchLimitedCardType
			// 
			this.cbSearchLimitedCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearchLimitedCardType.FormattingEnabled = true;
			this.cbSearchLimitedCardType.Location = new System.Drawing.Point(603, 19);
			this.cbSearchLimitedCardType.Name = "cbSearchLimitedCardType";
			this.cbSearchLimitedCardType.Size = new System.Drawing.Size(159, 21);
			this.cbSearchLimitedCardType.TabIndex = 4;
			// 
			// lblSearchLimitedWith
			// 
			this.lblSearchLimitedWith.AutoSize = true;
			this.lblSearchLimitedWith.Location = new System.Drawing.Point(518, 22);
			this.lblSearchLimitedWith.Name = "lblSearchLimitedWith";
			this.lblSearchLimitedWith.Size = new System.Drawing.Size(79, 13);
			this.lblSearchLimitedWith.TabIndex = 7;
			this.lblSearchLimitedWith.Text = "With card type:";
			// 
			// btnSearchLimitedCards
			// 
			this.btnSearchLimitedCards.Location = new System.Drawing.Point(768, 17);
			this.btnSearchLimitedCards.Name = "btnSearchLimitedCards";
			this.btnSearchLimitedCards.Size = new System.Drawing.Size(125, 23);
			this.btnSearchLimitedCards.TabIndex = 5;
			this.btnSearchLimitedCards.Text = "Search";
			this.btnSearchLimitedCards.UseVisualStyleBackColor = true;
			this.btnSearchLimitedCards.Click += new System.EventHandler(this.btnSearchLimitedCards_Click);
			// 
			// lblSearchInLimited
			// 
			this.lblSearchInLimited.AutoSize = true;
			this.lblSearchInLimited.Location = new System.Drawing.Point(327, 22);
			this.lblSearchInLimited.Name = "lblSearchInLimited";
			this.lblSearchInLimited.Size = new System.Drawing.Size(19, 13);
			this.lblSearchInLimited.TabIndex = 5;
			this.lblSearchInLimited.Text = "In:";
			// 
			// cbSearchInLimited
			// 
			this.cbSearchInLimited.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbSearchInLimited.FormattingEnabled = true;
			this.cbSearchInLimited.Location = new System.Drawing.Point(352, 19);
			this.cbSearchInLimited.Name = "cbSearchInLimited";
			this.cbSearchInLimited.Size = new System.Drawing.Size(160, 21);
			this.cbSearchInLimited.TabIndex = 3;
			// 
			// txtSearchLimited
			// 
			this.txtSearchLimited.Location = new System.Drawing.Point(71, 19);
			this.txtSearchLimited.Name = "txtSearchLimited";
			this.txtSearchLimited.Size = new System.Drawing.Size(250, 20);
			this.txtSearchLimited.TabIndex = 2;
			this.txtSearchLimited.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearchLimited_KeyDown);
			// 
			// lblLimitedSearchFor
			// 
			this.lblLimitedSearchFor.AutoSize = true;
			this.lblLimitedSearchFor.Location = new System.Drawing.Point(6, 22);
			this.lblLimitedSearchFor.Name = "lblLimitedSearchFor";
			this.lblLimitedSearchFor.Size = new System.Drawing.Size(59, 13);
			this.lblLimitedSearchFor.TabIndex = 2;
			this.lblLimitedSearchFor.Text = "Search for:";
			// 
			// dgvLimitedCards
			// 
			this.dgvLimitedCards.AllowUserToAddRows = false;
			this.dgvLimitedCards.AllowUserToDeleteRows = false;
			this.dgvLimitedCards.AllowUserToResizeRows = false;
			this.dgvLimitedCards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgvLimitedCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvLimitedCards.Location = new System.Drawing.Point(6, 46);
			this.dgvLimitedCards.MultiSelect = false;
			this.dgvLimitedCards.Name = "dgvLimitedCards";
			this.dgvLimitedCards.ReadOnly = true;
			this.dgvLimitedCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvLimitedCards.Size = new System.Drawing.Size(887, 347);
			this.dgvLimitedCards.TabIndex = 1;
			this.dgvLimitedCards.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLimitedCards_CellDoubleClick);
			this.dgvLimitedCards.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvLimitedCards_KeyDown);
			this.dgvLimitedCards.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvLimitedCards_MouseClick);
			// 
			// ssMain
			// 
			this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssMainStatus,
            this.ssSpring,
            this.ssCardCount,
            this.ssMainProgress});
			this.ssMain.Location = new System.Drawing.Point(0, 467);
			this.ssMain.Name = "ssMain";
			this.ssMain.Size = new System.Drawing.Size(923, 22);
			this.ssMain.SizingGrip = false;
			this.ssMain.TabIndex = 3;
			this.ssMain.Text = "ssMain";
			// 
			// ssMainStatus
			// 
			this.ssMainStatus.Name = "ssMainStatus";
			this.ssMainStatus.Size = new System.Drawing.Size(61, 17);
			this.ssMainStatus.Text = "StatusText";
			// 
			// ssSpring
			// 
			this.ssSpring.Name = "ssSpring";
			this.ssSpring.Size = new System.Drawing.Size(47, 17);
			this.ssSpring.Text = "SPRING";
			// 
			// ssCardCount
			// 
			this.ssCardCount.Name = "ssCardCount";
			this.ssCardCount.Size = new System.Drawing.Size(65, 17);
			this.ssCardCount.Text = "CardCount";
			// 
			// ssMainProgress
			// 
			this.ssMainProgress.Name = "ssMainProgress";
			this.ssMainProgress.Size = new System.Drawing.Size(100, 16);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(923, 489);
			this.Controls.Add(this.ssMain);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.msMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msMain;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.Text = "YuGiOh Tracker";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.msMain.ResumeLayout(false);
			this.msMain.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCardList)).EndInit();
			this.tcMain.ResumeLayout(false);
			this.tpCardList.ResumeLayout(false);
			this.gbCardList.ResumeLayout(false);
			this.gbCardList.PerformLayout();
			this.tpOfficialDecks.ResumeLayout(false);
			this.gbOfficialDeckList.ResumeLayout(false);
			this.gbOfficialDeckList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvOfficialDecks)).EndInit();
			this.tpUserCollection.ResumeLayout(false);
			this.gbUserCollection.ResumeLayout(false);
			this.gbUserCollection.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUserCollection)).EndInit();
			this.tpLimitedCards.ResumeLayout(false);
			this.gbLimitedCardList.ResumeLayout(false);
			this.gbLimitedCardList.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvLimitedCards)).EndInit();
			this.ssMain.ResumeLayout(false);
			this.ssMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip msMain;
		private System.Windows.Forms.ToolStripMenuItem msMainFile;
		private System.Windows.Forms.ToolStripMenuItem msMainFileExit;
		private System.Windows.Forms.ToolStripMenuItem msMainUpdates;
		private System.Windows.Forms.DataGridView dgvCardList;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.TabPage tpCardList;
		private System.Windows.Forms.TabPage tpUserDecks;
		private System.Windows.Forms.StatusStrip ssMain;
		private System.Windows.Forms.GroupBox gbCardList;
		private System.Windows.Forms.TabPage tpOfficialDecks;
		private System.Windows.Forms.ToolStripMenuItem msMainHelp;
		private System.Windows.Forms.ToolStripMenuItem msMainHelpAbout;
		private System.Windows.Forms.ToolStripStatusLabel ssMainStatus;
		private System.Windows.Forms.ComboBox cbSearchCardType;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Label lblSearchIn;
		private System.Windows.Forms.ComboBox cbSearchInCardList;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label lblSearch;
		private System.Windows.Forms.GroupBox gbOfficialDeckList;
		private System.Windows.Forms.Button btnSearchOfficial;
		private System.Windows.Forms.Label lblSearchInOfficial;
		private System.Windows.Forms.ComboBox cbSearchInOfficial;
		private System.Windows.Forms.TextBox txtSearchOfficial;
		private System.Windows.Forms.Label lblSearchOfficial;
		private System.Windows.Forms.DataGridView dgvOfficialDecks;
		private System.Windows.Forms.ToolStripStatusLabel ssCardCount;
		private System.Windows.Forms.ToolStripStatusLabel ssSpring;
		private System.Windows.Forms.TabPage tpUserCollection;
		private System.Windows.Forms.ToolStripProgressBar ssMainProgress;
		private System.Windows.Forms.GroupBox gbUserCollection;
		private System.Windows.Forms.ComboBox cbUserCollectionCardType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnUserCollectionSearch;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbUserCollectionIn;
		private System.Windows.Forms.TextBox txtUserCollectionSearch;
		private System.Windows.Forms.Label lblUserCollSearch;
		private System.Windows.Forms.DataGridView dgvUserCollection;
		private System.Windows.Forms.TabPage tpLimitedCards;
		private System.Windows.Forms.GroupBox gbLimitedCardList;
		private System.Windows.Forms.ComboBox cbSearchLimitedCardType;
		private System.Windows.Forms.Label lblSearchLimitedWith;
		private System.Windows.Forms.Button btnSearchLimitedCards;
		private System.Windows.Forms.Label lblSearchInLimited;
		private System.Windows.Forms.ComboBox cbSearchInLimited;
		private System.Windows.Forms.TextBox txtSearchLimited;
		private System.Windows.Forms.Label lblLimitedSearchFor;
		private System.Windows.Forms.DataGridView dgvLimitedCards;
		private System.Windows.Forms.ToolStripMenuItem msMainFileSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}

