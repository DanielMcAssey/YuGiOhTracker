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
	public partial class frmSettings : Form
	{
		private DatabaseManager mDB;
		private TrackerSettings mSettings;

		private void LoadSettings()
		{
			Dictionary<string, string> getSettings = mDB.GetAllSettings();

			txtMashapeApiKey.Text = getSettings["mashape_api_key"];
		}

		private void SaveSettings()
		{
			Dictionary<string, string> newSettings = new Dictionary<string, string>();

			newSettings.Add("mashape_api_key", txtMashapeApiKey.Text);

			foreach (KeyValuePair<string, string> settings in newSettings)
			{
				mDB.UpdateSetting(settings.Key, settings.Value);
			}
		}

		public frmSettings(DatabaseManager _db)
		{
			InitializeComponent();
			this.mDB = _db;
		}

		private void frmSettings_Load(object sender, EventArgs e)
		{
			LoadSettings();
			btnApply.Enabled = false;
		}

		#region "Buttons"
		private void btnOK_Click(object sender, EventArgs e)
		{
			this.SaveSettings();
			this.Close();
		}

		private void btnApply_Click(object sender, EventArgs e)
		{
			btnApply.Enabled = false;
			this.SaveSettings();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region "Text Changed"
		private void AnyTextbox_TextChanged(object sender, EventArgs e)
		{
			btnApply.Enabled = true;
		}
		#endregion
	}
}
