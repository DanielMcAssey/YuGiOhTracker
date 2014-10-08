using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

using TrackerSystem.WebScraper;
using TrackerSystem.DBManager;
using TrackerSystem.CardData;


namespace TrackerSystem.Updater
{
	public class UpdaterManager
	{
		private DatabaseManager mDatabase = null;
		private Scraper mScraper = null;

		private string currentCardName = "";
		private int completedCardCount = 0;
		private int totalCardCount = 0;
		private string currentStatus = "";

		public EventHandler InformationChanged;

		public int CompletedCardCount
		{
			get
			{
				return completedCardCount;
			}
		}

		public string CurrentCardName
		{
			get
			{
				return currentCardName;
			}
		}

		public string CurrentStatus
		{
			get
			{
				return currentStatus;
			}
		}

		public int TotalCardCount
		{
			get
			{
				return totalCardCount;
			}
		}

		public UpdaterManager(ref DatabaseManager _db, ref Scraper _scraper)
		{
			mDatabase = _db;
			mScraper = _scraper;
		}

		public void TriggerDataChange()
		{
			if (InformationChanged != null)
				InformationChanged(this, EventArgs.Empty);
		}

		public List<ScraperBundleToUpdate> BundleDifference(List<ScraperBundleToUpdate> bundleNames)
		{
			List<int> newBundleIDs = mDatabase.MultiCheckBundleNames(bundleNames, true);
			List<CardBundle> newCardBundles = new List<CardBundle>();
			List<ScraperBundleToUpdate> newBundlesToUpdate = new List<ScraperBundleToUpdate>();

			for (int i = 0; i < newBundleIDs.Count; i++)
			{
				ScraperBundleToUpdate tmpBundle = bundleNames[newBundleIDs[i]];
				CardBundle tmpNewBundle = new CardBundle();
				tmpNewBundle.Name = tmpBundle.Name;

				Regex specialCharacters = new Regex("[^a-zA-Z0-9 -]");
				string fixSetType = Regex.Replace(specialCharacters.Replace(tmpBundle.SetType, ""), @"\s+", ""); //Remove all whitespace and special characters
				tmpNewBundle.Type = EnumUtils.ParseEnum<BundleType>(fixSetType); //Need to change this to tryparse to catch errors.

				tmpNewBundle.Year = tmpBundle.Year;
				tmpNewBundle.WebID = tmpBundle.WebID;
				tmpNewBundle.IsUpdated = false;

				newCardBundles.Add(tmpNewBundle);
				newBundlesToUpdate.Add(tmpBundle);
			}

			if (newBundleIDs.Count > 0)
				mDatabase.InsertBundles(newCardBundles);

			return newBundlesToUpdate;
		}

		public void BeginUpdate(bool downloadImages)
		{
			currentStatus = "Maintenance: Removing possible corrupted cards...";
			TriggerDataChange();
			mDatabase.RemoveNonUpdatedCards();

			ScraperUpdateData newCards = mScraper.DoScrapeCards(downloadImages, ref currentCardName, ref completedCardCount, ref totalCardCount, ref currentStatus);
			currentStatus = "Saving: Storing new cards/sets... [This may take a LONG time]";
			TriggerDataChange();
			this.totalCardCount = newCards.SetIDToUpdate.Count;
			this.completedCardCount = 0;
			for (int i = 0; i < newCards.SetIDToUpdate.Count; i++ )
			{
				if(newCards.SetGroups.ContainsKey(newCards.SetIDToUpdate[i]))
				{
					mDatabase.InsertCards(newCards.SetGroups[newCards.SetIDToUpdate[i]]);
					mDatabase.MarkBundleUpdated(newCards.SetIDToUpdate[i]);
				}
				this.completedCardCount += 1;
				TriggerDataChange();
			}
			currentStatus = "Completed: A total of " + newCards.SetIDToUpdate.Count.ToString() + " new sets have been added.";
			TriggerDataChange();
		}
	}
}
