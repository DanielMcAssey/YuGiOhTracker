using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrackerSystem;
using TrackerSystem.DBManager;

using YuGiOhTracker.CustomDataGridView;

namespace YuGiOhTracker
{
	public partial class frmMain : Form
	{
		DatabaseManager objDBManager = null;
		Tracker mTracker = null;
		private int selectedIndex = 0;
		DataGridViewColumnHeaderCellImage levelHeader = null;

		#region "Generic Worker Stuff"
		BackgroundWorker searchWorker = null;
		BackgroundWorker refreshDataWorker = null;

		private void InitializeWorkers()
		{
			searchWorker = new BackgroundWorker();
			searchWorker.WorkerReportsProgress = true;
			searchWorker.DoWork += DoSearchWork;
			searchWorker.ProgressChanged += WorkerProgressChanged;
			searchWorker.RunWorkerCompleted += SearchWorkerCompleted;

			refreshDataWorker = new BackgroundWorker();
			refreshDataWorker.WorkerReportsProgress = true;
			refreshDataWorker.DoWork += DoRefreshDataWork;
			refreshDataWorker.ProgressChanged += WorkerProgressChanged;
			refreshDataWorker.RunWorkerCompleted += RefreshDataWorkCompleted;
		}

		private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ssMainProgress.Value = e.ProgressPercentage;
		}
		#endregion

		#region "Search Worker"
		private void DoSearchWork(object sender, DoWorkEventArgs e)
		{
			ssMainStatus.Text = "Searching Data...";
			e.Result = this.StartSearch((SearchData)e.Argument);
		}

		private int StartSearch(SearchData searchData)
		{
			switch(searchData.SearchDGV)
			{
				case "limited":
					return this.SearchLimitedList(searchData);
				case "officialsets":
					return this.SearchOfficialSetList(searchData);
				case "cards":
					return this.SearchCardList(searchData);
				case "usercards":
					return this.SearchUserList(searchData);
				case "usersets":
					return this.SearchUserSetList(searchData);
				default:
					return -1;
			}
		}

		private void SearchWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ssMainStatus.Text = "Search Completed.";
			ssMainProgress.Value = 100;
			int rowIndex = (int)e.Result;
			if(rowIndex > 0)
			{
				dgvCardList.FirstDisplayedScrollingRowIndex = rowIndex;
				dgvCardList.ClearSelection();
				dgvCardList.Rows[rowIndex].Selected = true;
			}
			else
			{
				MessageBox.Show("We could not find anything matching your search parameters.", "No Match Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region "Refresh Data Worker"
		private void DoRefreshDataWork(object sender, DoWorkEventArgs e)
		{
			ssMainStatus.Text = "Reloading Data...";
			e.Result = RefreshDataViews((List<string>)e.Argument);
		}

		private void RefreshDataWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			RefreshData newRefreshData = (RefreshData)e.Result;

			//////////////////////////////
			// Refresh Data and Columns //
			//////////////////////////////

			if (newRefreshData.RefreshWhat.Contains("dgvCardList") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Card List
				dgvCardList.DataSource = newRefreshData.CardListData;
				dgvCardList.Columns["level"].HeaderCell = levelHeader;

				dgvCardList.Columns["code"].HeaderText = "Card Code";
				dgvCardList.Columns["rarity"].HeaderText = "Rarity";
				dgvCardList.Columns["name"].HeaderText = "Name";
				dgvCardList.Columns["level"].HeaderText = "";
				dgvCardList.Columns["type"].HeaderText = "Type";
				dgvCardList.Columns["attribute"].HeaderText = "Attribute";
				dgvCardList.Columns["subtype"].HeaderText = "Monster Property";
				dgvCardList.Columns["sticon"].HeaderText = "Spell/Trap Property";
				dgvCardList.Columns["atk"].HeaderText = "ATK";
				dgvCardList.Columns["def"].HeaderText = "DEF";
				dgvCardList.Columns["status"].HeaderText = "Status";

				dgvCardList.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["rarity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				dgvCardList.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvCardList.Columns["level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["attribute"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["subtype"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				dgvCardList.Columns["sticon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				dgvCardList.Columns["atk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["def"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				dgvCardList.Columns["id"].Visible = false;
			}

			if (newRefreshData.RefreshWhat.Contains("dgvOfficialDecks") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Set list
				dgvOfficialDecks.DataSource = newRefreshData.SetListData;

				dgvOfficialDecks.Columns["type"].HeaderText = "Set Type";
				dgvOfficialDecks.Columns["year"].HeaderText = "Release Year";
				dgvOfficialDecks.Columns["name"].HeaderText = "Set Name";

				dgvOfficialDecks.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvOfficialDecks.Columns["year"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvOfficialDecks.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

				dgvOfficialDecks.Columns["id"].Visible = false;
				dgvOfficialDecks.Columns["webid"].Visible = false;
			}

			if (newRefreshData.RefreshWhat.Contains("dgvLimitedCards") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Limited List
				dgvLimitedCards.DataSource = newRefreshData.LimitedListData;

				dgvLimitedCards.Columns["code"].HeaderText = "Card Code";
				dgvLimitedCards.Columns["type"].HeaderText = "Type";
				dgvLimitedCards.Columns["name"].HeaderText = "Name";
				dgvLimitedCards.Columns["status"].HeaderText = "Status";

				dgvLimitedCards.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvLimitedCards.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvLimitedCards.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvLimitedCards.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				dgvLimitedCards.Columns["id"].Visible = false;
			}

			if (newRefreshData.RefreshWhat.Contains("dgvUserCollection") || newRefreshData.RefreshWhat.Contains("*"))
			{
				dgvUserCollection.DataSource = newRefreshData.UserSetListData;

				dgvUserCollection.Columns["code"].HeaderText = "Card Code";
				dgvUserCollection.Columns["name"].HeaderText = "Name";
				dgvUserCollection.Columns["type"].HeaderText = "Type";
				dgvUserCollection.Columns["rarity"].HeaderText = "Rarity";
				dgvUserCollection.Columns["status"].HeaderText = "Status";

				dgvUserCollection.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvUserCollection.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvUserCollection.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvUserCollection.Columns["rarity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
				dgvUserCollection.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				dgvUserCollection.Columns["id"].Visible = false;
			}

			if (newRefreshData.RefreshWhat.Contains("dgvUserDecks") || newRefreshData.RefreshWhat.Contains("*"))
			{
				dgvUserDecks.DataSource = newRefreshData.UserListData;

				dgvUserDecks.Columns["deckName"].HeaderText = "Deck Name";
				dgvUserDecks.Columns["lastUpdatedDate"].HeaderText = "Last Updated";
				dgvUserDecks.Columns["createdDate"].HeaderText = "Created";

				dgvUserDecks.Columns["deckName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvUserDecks.Columns["lastUpdatedDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvUserDecks.Columns["createdDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				dgvUserDecks.Columns["id"].Visible = false;
			}

			////////////////
			// Row Colors //
			////////////////

			if (newRefreshData.RefreshWhat.Contains("dgvCardList") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Card List
				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Forbidden")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (1 card)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Orange);
				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (2 cards)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Yellow);
			}

			if (newRefreshData.RefreshWhat.Contains("dgvOfficialDecks") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Set list
			}

			if (newRefreshData.RefreshWhat.Contains("dgvLimitedCards") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//Limited List
				dgvLimitedCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Forbidden")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
				dgvLimitedCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (1 card)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Orange);
				dgvLimitedCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (2 cards)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Yellow);
			}

			if (newRefreshData.RefreshWhat.Contains("dgvUserCollection") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//User Card List
				dgvUserCollection.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Forbidden")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
				dgvUserCollection.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (1 card)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Orange);
				dgvUserCollection.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (2 cards)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Yellow);
			}

			if (newRefreshData.RefreshWhat.Contains("dgvUserDecks") || newRefreshData.RefreshWhat.Contains("*"))
			{
				//User Set List
			}

			//Other stuff
			if (dgvCardList.RowCount == 0)
				ssCardCount.Text = "No cards found";
			else
				ssCardCount.Text = dgvCardList.RowCount.ToString("#,###") + " cards";

			ssMainStatus.Text = "Reload Completed.";
		}


		private RefreshData RefreshDataViews(List<string> _RefreshWhat)
		{
			RefreshData newRefreshData = new RefreshData();
			newRefreshData.RefreshWhat = _RefreshWhat;

			refreshDataWorker.ReportProgress(0);
			if (newRefreshData.RefreshWhat.Contains("dgvOfficialDecks") || newRefreshData.RefreshWhat.Contains("*"))
				newRefreshData.SetListData = objDBManager.FindAllBundlesDT();

			refreshDataWorker.ReportProgress(20);
			if (newRefreshData.RefreshWhat.Contains("dgvLimitedCards") || newRefreshData.RefreshWhat.Contains("*"))
				newRefreshData.LimitedListData = objDBManager.FindAllBannedCardsDT();

			refreshDataWorker.ReportProgress(40);
			if (newRefreshData.RefreshWhat.Contains("dgvCardList") || newRefreshData.RefreshWhat.Contains("*"))
				newRefreshData.CardListData = objDBManager.FindAllCardsDT();

			refreshDataWorker.ReportProgress(60);
			if (newRefreshData.RefreshWhat.Contains("dgvUserCollection") || newRefreshData.RefreshWhat.Contains("*"))
				newRefreshData.UserSetListData = objDBManager.FindAllUserCardsDT();

			refreshDataWorker.ReportProgress(80);
			if (newRefreshData.RefreshWhat.Contains("dgvUserDecks") || newRefreshData.RefreshWhat.Contains("*"))
				newRefreshData.UserListData = objDBManager.FindAllUserBundlesDT();

			refreshDataWorker.ReportProgress(100);
			return newRefreshData;
		}

		private void StartRefrehsData(List<string> _RefreshWhat)
		{
			if(refreshDataWorker != null)
			{
				refreshDataWorker.RunWorkerAsync(_RefreshWhat);
			}
		}
		#endregion

		#region "Helper Functions"
		private void PopulateCombobox()
		{
			//Card List
			//-Card List (IN)
			ComboboxItem cbItem = new ComboboxItem();
			cbItem.Text = "Card Code";
			cbItem.Value = "code";
			cbSearchInCardList.Items.Add(cbItem);
			cbSearchInLimited.Items.Add(cbItem);
			cbUserCollectionIn.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Name";
			cbItem.Value = "name";
			cbSearchInCardList.Items.Add(cbItem);
			cbSearchInLimited.Items.Add(cbItem);
			cbUserCollectionIn.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Level";
			cbItem.Value = "level";
			cbSearchInCardList.Items.Add(cbItem);
			cbUserCollectionIn.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Type";
			cbItem.Value = "type";
			cbSearchInCardList.Items.Add(cbItem);
			cbUserCollectionIn.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Attribute";
			cbItem.Value = "attribute";
			cbSearchInCardList.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Monster Property";
			cbItem.Value = "subtype";
			cbSearchInCardList.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Spell/Trap Property";
			cbItem.Value = "sticon";
			cbSearchInCardList.Items.Add(cbItem);

			cbSearchInCardList.SelectedIndex = 0;
			cbSearchInLimited.SelectedIndex = 0;
			cbUserCollectionIn.SelectedIndex = 0;

			//-Card List (Type)
			cbItem = new ComboboxItem();
			cbItem.Text = "Any";
			cbItem.Value = "any";
			cbSearchCardType.Items.Add(cbItem);
			cbSearchLimitedCardType.Items.Add(cbItem);
			cbUserCollectionCardType.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Monster";
			cbItem.Value = "monster";
			cbSearchCardType.Items.Add(cbItem);
			cbSearchLimitedCardType.Items.Add(cbItem);
			cbUserCollectionCardType.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Spell";
			cbItem.Value = "spell";
			cbSearchCardType.Items.Add(cbItem);
			cbSearchLimitedCardType.Items.Add(cbItem);
			cbUserCollectionCardType.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Trap";
			cbItem.Value = "trap";
			cbSearchCardType.Items.Add(cbItem);
			cbSearchLimitedCardType.Items.Add(cbItem);
			cbUserCollectionCardType.Items.Add(cbItem);

			cbSearchCardType.SelectedIndex = 0;
			cbSearchLimitedCardType.SelectedIndex = 0;
			cbUserCollectionCardType.SelectedIndex = 0;

			//Deck List
			cbItem = new ComboboxItem();
			cbItem.Text = "Set Type";
			cbItem.Value = "type";
			cbSearchInOfficial.Items.Add(cbItem);
			cbSearchInUser.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Year";
			cbItem.Value = "year";
			cbSearchInOfficial.Items.Add(cbItem);
			cbSearchInUser.Items.Add(cbItem);

			cbItem = new ComboboxItem();
			cbItem.Text = "Set Name";
			cbItem.Value = "name";
			cbSearchInOfficial.Items.Add(cbItem);
			cbSearchInUser.Items.Add(cbItem);

			cbSearchInOfficial.SelectedIndex = 0;
			cbSearchInUser.SelectedIndex = 0;
			
		}

		private void ViewCard(int rowIndex, ref DataGridView dgv)
		{
			if (rowIndex >= 0 && rowIndex < dgv.RowCount)
			{
				dgv.Rows[rowIndex].Selected = true;
				if (dgv.Columns["id"] != null)
				{
					int cardID = Convert.ToInt32(dgv.Rows[rowIndex].Cells["id"].Value.ToString());
					frmViewCard CardViewForm = new frmViewCard(this.objDBManager, cardID, false);
					CardViewForm.Show();
				}
			}

		}

		private void ViewSet(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvOfficialDecks.RowCount)
			{
				dgvOfficialDecks.Rows[rowIndex].Selected = true;
				if (dgvOfficialDecks.Columns["id"] != null)
				{
					int setID = Convert.ToInt32(dgvOfficialDecks.Rows[rowIndex].Cells["id"].Value.ToString());
					frmViewSet SetViewForm = new frmViewSet(this.objDBManager, setID, false);
					SetViewForm.Show();
				}
			}
		}

		public void ViewUserSet(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvUserDecks.RowCount)
			{
				dgvUserDecks.Rows[rowIndex].Selected = true;
				if (dgvUserDecks.Columns["id"] != null)
				{
					int setID = Convert.ToInt32(dgvUserDecks.Rows[rowIndex].Cells["id"].Value.ToString());
					frmViewSet SetViewForm = new frmViewSet(this.objDBManager, setID, false); //TODO
					SetViewForm.Show();
				}
			}
		}

		public void AddCard(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvCardList.RowCount)
			{
				string cardCode = dgvCardList.Rows[rowIndex].Cells["code"].Value.ToString();
				AddCardByCode(cardCode);
			}
		}

		public void AddCardByCode(string cardCode)
		{
			if(!mTracker.AddCardToCollection(cardCode))
			{
				MessageBox.Show("Could not add \"" + cardCode + "\", card may not exist in the current database.", "Add Card - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				List<string> refreshData = new List<string>();
				refreshData.Add("dgvUserCollection");
				StartRefrehsData(refreshData);
			}
		}

		public void AddSet(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvOfficialDecks.RowCount)
			{
				int setWebID = Convert.ToInt32(dgvCardList.Rows[rowIndex].Cells["webid"].Value.ToString());
				if (!mTracker.AddSetToCollection(setWebID))
				{
					MessageBox.Show("Could not add set with ID: \"" + setWebID.ToString() + "\", set may not exist in the current database.", "Add Set - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else
				{
					List<string> refreshData = new List<string>();
					refreshData.Add("dgvUserDecks");
					StartRefrehsData(refreshData);
				}
			}
		}

		public void NewUserSet()
		{
			//TODO
		}

		public void RemoveUserCard(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvCardList.RowCount)
			{
				if (dgvUserDecks.Columns["id"] != null)
				{
					int cardID = Convert.ToInt32(dgvUserDecks.Rows[rowIndex].Cells["id"].Value.ToString());
					//TODO
				}
			}
		}

		public void RemoveUserSet(int rowIndex)
		{
			if (rowIndex >= 0 && rowIndex < dgvUserDecks.RowCount)
			{
				dgvUserDecks.Rows[rowIndex].Selected = true;
				if (dgvUserDecks.Columns["id"] != null)
				{
					int setID = Convert.ToInt32(dgvUserDecks.Rows[rowIndex].Cells["id"].Value.ToString());
					//TODO
				}
			}
		}
		#endregion

		#region "Menu Strip"
		private void msMainFileSettings_Click(object sender, EventArgs e)
		{
			frmSettings settingsDialog = new frmSettings(this.objDBManager);
			settingsDialog.ShowDialog();
		}

		private void msMainFileExit_Click(object sender, EventArgs e)
		{
			DialogResult exitDialog = MessageBox.Show("Are you sure you want to exit?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if(exitDialog == DialogResult.Yes)
				Application.Exit();

		}

		private void msMainUpdates_Click(object sender, EventArgs e)
		{
			frmUpdates updateDialog = new frmUpdates();
			updateDialog.FormClosed += new FormClosedEventHandler(UpdateDialogClosed);
			updateDialog.ShowDialog();
		}

		private void UpdateDialogClosed(object sender, FormClosedEventArgs e)
		{
			List<string> refreshData = new List<string>();
			refreshData.Add("dgvCardList");
			refreshData.Add("dgvOfficialDecks");
			refreshData.Add("dgvLimitedCards");
			StartRefrehsData(refreshData);
		}

		private void msMainHelpAbout_Click(object sender, EventArgs e)
		{
			new frmAbout().ShowDialog();
		}
		#endregion

		#region "Card List (Search)
		private void btnSearch_Click(object sender, EventArgs e)
		{
			SearchData sendSearchData = new SearchData();
			sendSearchData.SearchDGV = "cards";
			sendSearchData.SearchText = txtSearch.Text;
			sendSearchData.Box1Text = (cbSearchInCardList.SelectedItem as ComboboxItem).Value.ToString();
			sendSearchData.Box2Text = (cbSearchCardType.SelectedItem as ComboboxItem).Value.ToString();
			searchWorker.RunWorkerAsync(sendSearchData);
		}

		private void txtSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SearchData sendSearchData = new SearchData();
				sendSearchData.SearchDGV = "cards";
				sendSearchData.SearchText = txtSearch.Text;
				sendSearchData.Box1Text = (cbSearchInCardList.SelectedItem as ComboboxItem).Value.ToString();
				sendSearchData.Box2Text = (cbSearchCardType.SelectedItem as ComboboxItem).Value.ToString();
				searchWorker.RunWorkerAsync(sendSearchData);
			}
		}

		private int SearchCardList(SearchData searchData)
		{
			int rowIndex = -1;
			double rowCount = dgvCardList.RowCount;

			if (dgvCardList.Columns[searchData.Box1Text] != null)
			{
				double currentRowNumber = 0;
				foreach (DataGridViewRow row in dgvCardList.Rows)
				{
					if (row.Cells[searchData.Box1Text].Value.ToString().Contains(searchData.SearchText))
					{
						rowIndex = row.Index;
						break;
					}
					currentRowNumber += 1;

					if(searchWorker.IsBusy)
					{
						int progressPercentage = Convert.ToInt32(Math.Round((currentRowNumber / rowCount) * 100));
						searchWorker.ReportProgress(progressPercentage);
					}
				}
			}

			if (rowIndex >= 0)
				return rowIndex;
			else
				return -1;

		}
		#endregion

		#region "Set List (Search)"
		private void btnSearchOfficial_Click(object sender, EventArgs e)
		{
			SearchData sendSearchData = new SearchData();
			sendSearchData.SearchDGV = "officialsets";
			sendSearchData.SearchText = txtSearchOfficial.Text;
			sendSearchData.Box1Text = (cbSearchInOfficial.SelectedItem as ComboboxItem).Value.ToString();
			searchWorker.RunWorkerAsync(sendSearchData);
		}

		private void txtSearchOfficial_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SearchData sendSearchData = new SearchData();
				sendSearchData.SearchDGV = "officialsets";
				sendSearchData.SearchText = txtSearchOfficial.Text;
				sendSearchData.Box1Text = (cbSearchInOfficial.SelectedItem as ComboboxItem).Value.ToString();
				searchWorker.RunWorkerAsync(sendSearchData);
			}
		}

		private int SearchOfficialSetList(SearchData searchData)
		{
			int rowIndex = -1;
			double rowCount = dgvOfficialDecks.RowCount;

			if (dgvOfficialDecks.Columns[searchData.Box1Text] != null)
			{
				double currentRowNumber = 0;
				foreach (DataGridViewRow row in dgvOfficialDecks.Rows)
				{
					if (row.Cells[searchData.Box1Text].Value.ToString().Contains(searchData.SearchText))
					{
						rowIndex = row.Index;
						break;
					}
					currentRowNumber += 1;

					if (searchWorker.IsBusy)
					{
						int progressPercentage = Convert.ToInt32(Math.Round((currentRowNumber / rowCount) * 100));
						searchWorker.ReportProgress(progressPercentage);
					}
				}
			}

			if (rowIndex >= 0)
				return rowIndex;
			else
				return -1;

		}
		#endregion

		#region "User Set List (Search)"
		private void btnSearchUser_Click(object sender, EventArgs e)
		{
			SearchData sendSearchData = new SearchData();
			sendSearchData.SearchDGV = "usersets";
			sendSearchData.SearchText = txtSearchUser.Text;
			sendSearchData.Box1Text = (cbSearchInUser.SelectedItem as ComboboxItem).Value.ToString();
			searchWorker.RunWorkerAsync(sendSearchData);
		}

		private void txtSearchUser_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SearchData sendSearchData = new SearchData();
				sendSearchData.SearchDGV = "usersets";
				sendSearchData.SearchText = txtSearchUser.Text;
				sendSearchData.Box1Text = (cbSearchInUser.SelectedItem as ComboboxItem).Value.ToString();
				searchWorker.RunWorkerAsync(sendSearchData);
			}
		}

		private int SearchUserSetList(SearchData searchData)
		{
			int rowIndex = -1;
			double rowCount = dgvUserDecks.RowCount;

			if (dgvUserDecks.Columns[searchData.Box1Text] != null)
			{
				double currentRowNumber = 0;
				foreach (DataGridViewRow row in dgvUserDecks.Rows)
				{
					if (row.Cells[searchData.Box1Text].Value.ToString().Contains(searchData.SearchText))
					{
						rowIndex = row.Index;
						break;
					}
					currentRowNumber += 1;

					if (searchWorker.IsBusy)
					{
						int progressPercentage = Convert.ToInt32(Math.Round((currentRowNumber / rowCount) * 100));
						searchWorker.ReportProgress(progressPercentage);
					}
				}
			}

			if (rowIndex >= 0)
				return rowIndex;
			else
				return -1;

		}
		#endregion

		#region "Limited List (Search)"
		private void btnSearchLimitedCards_Click(object sender, EventArgs e)
		{
			SearchData sendSearchData = new SearchData();
			sendSearchData.SearchDGV = "limited";
			sendSearchData.SearchText = txtSearchLimited.Text;
			sendSearchData.Box1Text = (cbSearchInLimited.SelectedItem as ComboboxItem).Value.ToString();
			sendSearchData.Box2Text = (cbSearchLimitedCardType.SelectedItem as ComboboxItem).Value.ToString();
			searchWorker.RunWorkerAsync(sendSearchData);
		}

		private void txtSearchLimited_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				SearchData sendSearchData = new SearchData();
				sendSearchData.SearchDGV = "limited";
				sendSearchData.SearchText = txtSearchLimited.Text;
				sendSearchData.Box1Text = (cbSearchInLimited.SelectedItem as ComboboxItem).Value.ToString();
				sendSearchData.Box2Text = (cbSearchLimitedCardType.SelectedItem as ComboboxItem).Value.ToString();
				searchWorker.RunWorkerAsync(sendSearchData);
			}
		}

		private int SearchLimitedList(SearchData searchData)
		{
			int rowIndex = -1;
			double rowCount = dgvLimitedCards.RowCount;

			if (dgvLimitedCards.Columns[searchData.Box1Text] != null)
			{
				double currentRowNumber = 0;
				foreach (DataGridViewRow row in dgvLimitedCards.Rows)
				{
					if (row.Cells[searchData.Box1Text].Value.ToString().Contains(searchData.SearchText))
					{
						rowIndex = row.Index;
						break;
					}
					currentRowNumber += 1;

					if (searchWorker.IsBusy)
					{
						int progressPercentage = Convert.ToInt32(Math.Round((currentRowNumber / rowCount) * 100));
						searchWorker.ReportProgress(progressPercentage);
					}
				}
			}

			if (rowIndex >= 0)
				return rowIndex;
			else
				return -1;

		}
		#endregion

		#region "User Collection List (Search)
		private void btnUserCollectionSearch_Click(object sender, EventArgs e)
		{
			SearchData sendSearchData = new SearchData();
			sendSearchData.SearchDGV = "usercards";
			sendSearchData.SearchText = txtUserCollectionSearch.Text;
			sendSearchData.Box1Text = (cbUserCollectionIn.SelectedItem as ComboboxItem).Value.ToString();
			sendSearchData.Box2Text = (cbUserCollectionCardType.SelectedItem as ComboboxItem).Value.ToString();
			searchWorker.RunWorkerAsync(sendSearchData);
		}

		private void txtUserCollectionSearch_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				SearchData sendSearchData = new SearchData();
				sendSearchData.SearchDGV = "usercards";
				sendSearchData.SearchText = txtUserCollectionSearch.Text;
				sendSearchData.Box1Text = (cbUserCollectionIn.SelectedItem as ComboboxItem).Value.ToString();
				sendSearchData.Box2Text = (cbUserCollectionCardType.SelectedItem as ComboboxItem).Value.ToString();
				searchWorker.RunWorkerAsync(sendSearchData);
			}
		}

		private int SearchUserList(SearchData searchData)
		{
			int rowIndex = -1;
			double rowCount = dgvUserCollection.RowCount;

			if (dgvUserCollection.Columns[searchData.Box1Text] != null)
			{
				double currentRowNumber = 0;
				foreach (DataGridViewRow row in dgvUserCollection.Rows)
				{
					if (row.Cells[searchData.Box1Text].Value.ToString().Contains(searchData.SearchText))
					{
						rowIndex = row.Index;
						break;
					}
					currentRowNumber += 1;

					if (searchWorker.IsBusy)
					{
						int progressPercentage = Convert.ToInt32(Math.Round((currentRowNumber / rowCount) * 100));
						searchWorker.ReportProgress(progressPercentage);
					}
				}
			}

			if (rowIndex >= 0)
				return rowIndex;
			else
				return -1;

		}
		#endregion

		#region "User Collection List (Generic)
		private void AddCardsFromTextbox()
		{
			string cardsToAdd = txtUserCollectionAdd.Text;
			if(cardsToAdd.Length > 0)
			{
				Regex.Replace(cardsToAdd, @"\s+", "");
				List<string> cardCodes = cardsToAdd.Split(',').ToList<string>();

				for (int i = 0; i < cardCodes.Count; i++)
				{
					AddCardByCode(cardCodes[i]);
				}
			}
			else
			{
				MessageBox.Show("Please enter the codes of the cards you would like to add, and space each code with a comma (',').", "Add Card - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btnUserCollectionAdd_Click(object sender, EventArgs e)
		{
			AddCardsFromTextbox();
		}

		private void txtUserCollectionAdd_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter)
			{
				AddCardsFromTextbox();
			}
		}
		#endregion

		#region "Card List (DGV)"
		private void dgvCardList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewCard(e.RowIndex, ref dgvCardList);
		}

		private void dgvCardList_MouseClick(object sender, MouseEventArgs e)
		{
			if(e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvCardList.HitTest(e.X, e.Y).RowIndex;
				if(currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Card...", new EventHandler(cmViewCard)));
					cm.MenuItems.Add(new MenuItem("Add Card To Collection...", new EventHandler(cmAddCard)));

					selectedIndex = currentMouseOverRow;
					dgvCardList.CurrentCell = dgvCardList.Rows[currentMouseOverRow].Cells["name"];
					dgvCardList.Rows[currentMouseOverRow].Selected = true;

					cm.Show(dgvCardList, new Point(e.X, e.Y));
				}
			}
		}

		private void dgvCardList_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvCardList.SelectedRows)
				{
					ViewCard(row.Index, ref dgvCardList);
				}

				e.Handled = true;
			}
		}

		protected void cmViewCard(Object sender, EventArgs e)
		{
			ViewCard(selectedIndex, ref dgvCardList);
		}

		protected void cmAddCard(Object sender, EventArgs e)
		{
			AddCard(selectedIndex);
		}
		#endregion

		#region "Official Set List (DGV)"
		private void dgvOfficialDecks_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewSet(e.RowIndex);
		}

		private void dgvOfficialDecks_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvOfficialDecks.SelectedRows)
				{
					ViewSet(row.Index);
				}

				e.Handled = true;
			}
		}

		private void dgvOfficialDecks_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvOfficialDecks.HitTest(e.X, e.Y).RowIndex;
				if (currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Set...", new EventHandler(cmViewSet)));
					cm.MenuItems.Add(new MenuItem("Add Set To Collection...", new EventHandler(cmAddSet)));

					selectedIndex = currentMouseOverRow;
					dgvOfficialDecks.CurrentCell = dgvOfficialDecks.Rows[currentMouseOverRow].Cells["name"];
					dgvOfficialDecks.Rows[currentMouseOverRow].Selected = true;

					cm.Show(dgvOfficialDecks, new Point(e.X, e.Y));
				}
			}
		}

		protected void cmViewSet(Object sender, EventArgs e)
		{
			ViewSet(selectedIndex);
		}

		protected void cmAddSet(Object sender, EventArgs e)
		{
			AddSet(selectedIndex);
		}
		#endregion

		#region "Limited List (DGV)"
		private void dgvLimitedCards_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewCard(e.RowIndex, ref dgvLimitedCards);
		}

		private void dgvLimitedCards_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvLimitedCards.HitTest(e.X, e.Y).RowIndex;
				if (currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Card...", new EventHandler(cmViewCardLimited)));
					cm.MenuItems.Add(new MenuItem("Add Card To Collection...", new EventHandler(cmAddCard)));

					selectedIndex = currentMouseOverRow;
					dgvLimitedCards.CurrentCell = dgvLimitedCards.Rows[currentMouseOverRow].Cells["name"];
					dgvLimitedCards.Rows[currentMouseOverRow].Selected = true;

					cm.Show(dgvLimitedCards, new Point(e.X, e.Y));
				}
			}
		}

		private void dgvLimitedCards_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvLimitedCards.SelectedRows)
				{
					ViewCard(row.Index, ref dgvLimitedCards);
				}

				e.Handled = true;
			}
		}

		protected void cmViewCardLimited(Object sender, EventArgs e)
		{
			ViewCard(selectedIndex, ref dgvLimitedCards);
		}

		#endregion

		#region "User Collection List (DGV)"
		private void dgvUserCollection_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewCard(e.RowIndex, ref dgvUserCollection);
		}

		private void dgvUserCollection_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvUserCollection.HitTest(e.X, e.Y).RowIndex;
				if (currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Card...", new EventHandler(cmViewCardUser)));
					cm.MenuItems.Add(new MenuItem("Remove Card", new EventHandler(cmRemoveCardUser)));

					selectedIndex = currentMouseOverRow;
					dgvUserCollection.CurrentCell = dgvUserCollection.Rows[currentMouseOverRow].Cells["name"];
					dgvUserCollection.Rows[currentMouseOverRow].Selected = true;

					cm.Show(dgvUserCollection, new Point(e.X, e.Y));
				}
			}
		}

		private void dgvUserCollection_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvUserCollection.SelectedRows)
				{
					ViewCard(row.Index, ref dgvUserCollection);
				}

				e.Handled = true;
			}
		}

		protected void cmViewCardUser(Object sender, EventArgs e)
		{
			ViewCard(selectedIndex, ref dgvUserCollection);
		}

		protected void cmRemoveCardUser(Object sender, EventArgs e)
		{
			RemoveUserCard(selectedIndex);
		}
		#endregion

		#region "User Set List (DGV)"
		private void dgvUserDecks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewUserSet(e.RowIndex);
		}

		private void dgvUserDecks_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				ContextMenu cm = new ContextMenu();
				cm.MenuItems.Add(new MenuItem("New Deck...", new EventHandler(cmNewDeckUser)));
				cm.Show(dgvUserDecks, new Point(e.X, e.Y));
			}
		}

		private void dgvUserDecks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvUserDecks.HitTest(e.X, e.Y).RowIndex;
				
				if (currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Deck...", new EventHandler(cmViewDeckUser)));
					cm.MenuItems.Add(new MenuItem("Remove Deck", new EventHandler(cmRemoveDeckUser)));

					selectedIndex = currentMouseOverRow;
					dgvUserDecks.CurrentCell = dgvUserDecks.Rows[currentMouseOverRow].Cells["deckName"];
					dgvUserDecks.Rows[currentMouseOverRow].Selected = true;

					cm.MenuItems.Add(new MenuItem("New Deck...", new EventHandler(cmNewDeckUser)));
					cm.Show(dgvUserDecks, new Point(e.X, e.Y));
				}
			}
		}

		private void dgvUserDecks_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvUserDecks.SelectedRows)
				{
					ViewUserSet(selectedIndex);
				}

				e.Handled = true;
			}
		}

		protected void cmViewDeckUser(Object sender, EventArgs e)
		{
			ViewUserSet(selectedIndex);
		}

		protected void cmNewDeckUser(Object sender, EventArgs e)
		{
			NewUserSet();
		}

		protected void cmRemoveDeckUser(Object sender, EventArgs e)
		{
			DialogResult removeDialog = MessageBox.Show("Are you sure you want to delete this deck?", "Delete Deck", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (removeDialog == DialogResult.Yes)
				RemoveUserSet(selectedIndex);
		}
		#endregion

		public frmMain()
		{
			InitializeComponent();
			objDBManager = new DatabaseManager();
			mTracker = new Tracker();
			InitializeWorkers();
			levelHeader = new DataGridViewColumnHeaderCellImage();
			levelHeader.HeaderImage = Image.FromFile("Assets/Images/star_rank.png");
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			ssSpring.Text = "";
			ssSpring.Spring = true;
			ssMainStatus.Text = "Ready";
			ssCardCount.Text = "";
			PopulateCombobox();
			List<string> refreshData = new List<string>();
			refreshData.Add("dgvCardList");
			StartRefrehsData(refreshData);
			ActiveControl = dgvCardList;
		}

		private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
		{
			List<string> refreshData = new List<string>();
			switch (tcMain.SelectedIndex)
			{
				case 0: //Card List //No need for refresh unless its by an update or form load.
					if (dgvCardList.RowCount == 0) //No need for refresh unless its by an update or form load.
					{
						refreshData.Add("dgvCardList");
						StartRefrehsData(refreshData);
					}
					break;
				case 1: //Official Decks
					if (dgvOfficialDecks.RowCount == 0) //No need for refresh unless its by an update or form load.
					{
						refreshData.Add("dgvOfficialDecks");
						StartRefrehsData(refreshData);
					}
					break;
				case 2: //User Collection
					if (dgvUserCollection.RowCount == 0) //No need for refresh unless its by an update.
					{
						refreshData.Add("dgvUserCollection");
						StartRefrehsData(refreshData);
					}
					break;
				case 3: //User Decks
					if (dgvUserDecks.RowCount == 0) //No need for refresh unless its by an update.
					{
						refreshData.Add("dgvUserDecks");
						StartRefrehsData(refreshData);
					}
					break;
				case 4: //Limited Cards 
					if (dgvLimitedCards.RowCount == 0) //No need for refresh unless its by an update.
					{
						refreshData.Add("dgvLimitedCards");
						StartRefrehsData(refreshData);
					}
					break;
			}
		}
	}
}
