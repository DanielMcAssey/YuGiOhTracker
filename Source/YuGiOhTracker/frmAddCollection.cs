using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TrackerSystem;
using TrackerSystem.DBManager;
using TrackerSystem.CardData;

namespace YuGiOhTracker
{
	public partial class frmAddCollection : Form
	{
		private DatabaseManager mDB;
		private List<UserCardBundle> mUserBundles;

		private void PopulateComboBox(List<UserCardBundle> _userDecks)
		{
			ComboboxItem cbItem = new ComboboxItem();
			cbItem.Text = "None";
			cbItem.Value = "*";
			cbCollectionToAdd.Items.Add(cbItem);

			for(int i = 0; i < _userDecks.Count; i++)
			{
				cbItem.Text = _userDecks[i].BundleName;
				cbItem.Value = _userDecks[i].ID.ToString();
				cbCollectionToAdd.Items.Add(cbItem);
			}
		}

		public frmAddCollection(DatabaseManager _db)
		{
			InitializeComponent();

			this.mDB = _db;

			//Load user collections
			this.mUserBundles = this.mDB.GetAllUserBundles();
			PopulateComboBox(this.mUserBundles);
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{

		}

		private void btnCancel_Click(object sender, EventArgs e)
		{

		}
	}
}
