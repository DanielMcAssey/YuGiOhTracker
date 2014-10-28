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

namespace YuGiOhTracker
{
	public partial class frmUpdates : Form
	{
		private Tracker objTracker;

		#region "Generic Worker Init"
		private BackgroundWorker updateWorker;
		private BackgroundWorker checkUpdateWorker;

		private void InitializeUpdateWorker()
		{
			updateWorker = new BackgroundWorker();
			updateWorker.WorkerReportsProgress = true;
			updateWorker.DoWork += DoUpdateWork;
			updateWorker.ProgressChanged += UpdateWorkProgressChanged;
			updateWorker.RunWorkerCompleted += UpdateWorkCompleted;
			objTracker.UpdaterSystem.InformationChanged += UpdateDataChanged;

			checkUpdateWorker = new BackgroundWorker();
			checkUpdateWorker.WorkerReportsProgress = false;
			checkUpdateWorker.DoWork += DoCheckUpdateWork;
			checkUpdateWorker.RunWorkerCompleted += CheckUpdateWorkCompleted;
		}
		#endregion

		#region "Check Update Worker"
		private void StartCheckUpdateWork()
		{
			checkUpdateWorker.RunWorkerAsync();
		}

		private void DoCheckUpdateWork(object sender, DoWorkEventArgs e)
		{
			e.Result = objTracker.CheckUpdate();
		}

		private void CheckUpdateWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool updateRequired = (bool)e.Result;

			if (updateRequired)
			{
				DialogResult msgUpdateResult = MessageBox.Show("There is an update available, would you like to download it?", "Update Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (msgUpdateResult == DialogResult.Yes)
				{
					lblCurrentCard.Visible = true;
					lblCardPercentage.Visible = true;
					lblUpdating.Visible = true;
					pbCards.Style = ProgressBarStyle.Continuous;

					DialogResult msgDownloadResult = MessageBox.Show("Would you like to download card images?\n(May take significantly longer to update)", "Download Images", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
					if (msgDownloadResult == DialogResult.Yes)
					{
						StartUpdateWork(true);
					}
					else if (msgDownloadResult == DialogResult.No)
					{
						StartUpdateWork(false);
					}
				}
				else if (msgUpdateResult == DialogResult.No)
				{
					this.Close();
				}
			}
			else
			{
				pbCards.Style = ProgressBarStyle.Continuous;
				lblStatusText.Text = "No updates available.";
				DialogResult msgUpdateResult = MessageBox.Show("No updates available", "No Update Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
				this.Close();
			}
		}
		#endregion

		#region "Update Worker"
		private void StartUpdateWork(bool downloadImages)
		{
			lblStatusText.Text = "Preparing: Collecting Metadata... (This may take a LONG time)";
			updateWorker.RunWorkerAsync(downloadImages);
		}

		private void DoUpdateWork(object sender, DoWorkEventArgs e)
		{
			objTracker.Update((bool)e.Argument);
		}

		private void UpdateWorkProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage > 100)
				pbCards.Value = 100;
			else
				pbCards.Value = e.ProgressPercentage;

			lblCardPercentage.Text = e.ProgressPercentage.ToString() + "%";
			lblStatusText.Text = objTracker.UpdaterSystem.CurrentStatus;
			lblCurrentCardText.Text = objTracker.UpdaterSystem.CurrentCardName;
		}

		private void UpdateWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Close();
		}

		private void UpdateDataChanged(object sender, EventArgs e)
		{
			if (updateWorker != null && objTracker.UpdaterSystem.TotalCardCount != 0)
			{
				double tmpCompleted = objTracker.UpdaterSystem.CompletedCardCount;
				double tmpTotal = objTracker.UpdaterSystem.TotalCardCount;
				int updateProgress = Convert.ToInt32(Math.Round(((tmpCompleted / tmpTotal) * 100), 0, MidpointRounding.AwayFromZero));
				updateWorker.ReportProgress(updateProgress);
			}
		}
		#endregion

		public frmUpdates()
		{
			objTracker = new Tracker();
			InitializeComponent();
			InitializeUpdateWorker();
		}

		private void frmUpdates_Load(object sender, EventArgs e)
		{
			lblCurrentCard.Visible = false;
			lblCardPercentage.Visible = false;
			lblUpdating.Visible = false;
			pbCards.Style = ProgressBarStyle.Marquee;
			lblCurrentCardText.Text = "";
			lblStatusText.Text = "";
			lblCardPercentage.Text = "";
		}

		private void frmUpdates_Shown(object sender, EventArgs e)
		{
			lblStatusText.Text = "Checking for updates, please wait...";
			StartCheckUpdateWork();
		}

		private void frmUpdates_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (updateWorker.IsBusy)
			{
				DialogResult msgExit = MessageBox.Show("There is an update in progress, are you sure you want to exit?\n(You will loose all update data)", "Exit Update", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (msgExit == DialogResult.Yes)
				{
					e.Cancel = false;
				}
				else if (msgExit == DialogResult.No)
				{
					e.Cancel = true;
				}
			}
			else
			{
				e.Cancel = false;
			}
		}
	}
}
