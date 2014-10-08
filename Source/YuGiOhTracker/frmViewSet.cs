using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using TrackerSystem;
using TrackerSystem.DBManager;
using TrackerSystem.CardData;

using YuGiOhTracker.CustomDataGridView;

namespace YuGiOhTracker
{
	public partial class frmViewSet : Form
	{
		private DatabaseManager mDB;
		private int setID = 0;
		private CardBundle currentBundle;

		DataGridViewColumnHeaderCellImage levelHeader = null;

		#region "Helper Functions"
		public void SortList()
		{
			dgvSetCards.DataSource = mDB.FindAllCardsByBundleWebIDDT(currentBundle.WebID);
			dgvSetCards.Columns["level"].HeaderCell = levelHeader;
			//Card List
			dgvSetCards.Columns["code"].HeaderText = "Card Code";
			dgvSetCards.Columns["rarity"].HeaderText = "Rarity";
			dgvSetCards.Columns["name"].HeaderText = "Name";
			dgvSetCards.Columns["level"].HeaderText = "";
			dgvSetCards.Columns["type"].HeaderText = "Type";
			dgvSetCards.Columns["attribute"].HeaderText = "Attribute";
			dgvSetCards.Columns["subtype"].HeaderText = "Monster Property";
			dgvSetCards.Columns["sticon"].HeaderText = "Spell/Trap Property";
			dgvSetCards.Columns["atk"].HeaderText = "ATK";
			dgvSetCards.Columns["def"].HeaderText = "DEF";
			dgvSetCards.Columns["status"].HeaderText = "Status";

			dgvSetCards.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["rarity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			dgvSetCards.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgvSetCards.Columns["level"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["type"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["attribute"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["subtype"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			dgvSetCards.Columns["sticon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
			dgvSetCards.Columns["atk"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["def"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			dgvSetCards.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

			dgvSetCards.Columns["id"].Visible = false;

			lblCardCount.Text = dgvSetCards.Rows.Count.ToString() + " Cards";
			dgvSetCards.Sort(dgvSetCards.Columns["code"], ListSortDirection.Ascending);
			dgvSetCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Forbidden")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
			dgvSetCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (1 card)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Orange);
			dgvSetCards.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (2 cards)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Yellow);
		}

		private void ViewCard(int rowIndex)
		{
			dgvSetCards.Rows[rowIndex].Selected = true;
			if (dgvSetCards.Columns["id"] != null)
			{
				int cardID = Convert.ToInt32(dgvSetCards.Rows[rowIndex].Cells["id"].Value.ToString());
				frmViewCard CardViewForm = new frmViewCard(mDB, cardID, false);
				CardViewForm.Show();
			}
		}
		#endregion

		public frmViewSet(DatabaseManager _db, int _setID, bool isWebID)
		{
			InitializeComponent();
			this.mDB = _db;
			this.setID = _setID;
			levelHeader = new DataGridViewColumnHeaderCellImage();
			levelHeader.HeaderImage = Image.FromFile("Assets/Images/star_rank.png");

			if (setID != 0 && mDB != null)
			{
				currentBundle = mDB.FindBundleByID(setID, isWebID);
			}
		}

		private void frmViewSet_Load(object sender, EventArgs e)
		{
			this.Text = "View Set - " + currentBundle.Name;
			lblSetName.Text = currentBundle.Name;
			lblSetTypeText.Text = Tracker.AddSpacesToSentence(currentBundle.Type.ToString(), false);
			lblYear.Text = currentBundle.Year.ToString();
			SortList();
		}

		private void dgvSetCards_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewCard(e.RowIndex);
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		int selectedIndex = 0;

		private void dgvSetCards_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvSetCards.HitTest(e.X, e.Y).RowIndex;
				if (currentMouseOverRow >= 0)
				{
					ContextMenu cm = new ContextMenu();
					cm.MenuItems.Add(new MenuItem("View Card...", new EventHandler(cmViewCard)));
					cm.MenuItems.Add(new MenuItem("Add Card To Collection...", new EventHandler(cmAddCard)));

					selectedIndex = currentMouseOverRow;
					dgvSetCards.CurrentCell = dgvSetCards.Rows[currentMouseOverRow].Cells["name"];
					dgvSetCards.Rows[currentMouseOverRow].Selected = true;

					cm.Show(dgvSetCards, new Point(e.X, e.Y));
				}
			}
		}

		protected void cmViewCard(Object sender, EventArgs e)
		{
			ViewCard(selectedIndex);
		}

		protected void cmAddCard(Object sender, EventArgs e)
		{

		}

		private void dgvSetCards_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				foreach (DataGridViewRow row in dgvSetCards.SelectedRows)
				{
					ViewCard(row.Index);
				}

				e.Handled = true;
			}
		}
	}
}
