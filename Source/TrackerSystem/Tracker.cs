using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using TrackerSystem.Updater;
using TrackerSystem.WebScraper;
using TrackerSystem.DBManager;
using TrackerSystem.CardData;

namespace TrackerSystem
{
	public struct TrackerSettings
	{
		public string MashapeAPIKey;
	}

	public class ComboboxItem
	{
		public string Text { get; set; }
		public object Value { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}

	public struct SearchData
	{
		public string SearchDGV;
		public string SearchText;
		public string Box1Text;
		public string Box2Text;
	}

	public struct RefreshData
	{
		public List<string> RefreshWhat;
		public DataTable CardListData;
		public DataTable SetListData;
		public DataTable LimitedListData;
		public DataTable UserListData;
		public DataTable UserSetListData;
	}

    public class Tracker
    {
		public const string CardImageDir = @"Assets\Images\Cards\";
		public const string CardIconDir = @"Assets\Images\CardIcons\";
		public const string CardImageMissing = "no-card-image.png";

		private UpdaterManager mUpdater;
		private Scraper mScraper;
		private DatabaseManager mDB;

		public UpdaterManager UpdaterSystem
		{
			get
			{
				return this.mUpdater;
			}
		}

		public Tracker()
		{
			mDB = new DatabaseManager();
			mScraper = new Scraper(this);
			mUpdater = new UpdaterManager(ref mDB, ref mScraper);
		}

		public bool CheckUpdate()
		{
			return mScraper.CheckUpdate();
		}

		public void Update(bool downloadImages)
		{
			mUpdater.BeginUpdate(downloadImages);
		}

		public List<int> GetCurrentCardIDs()
		{
			return mDB.GetExistingCards();
		}

		public List<ScraperExistingCards> GetCurrentCardsWithCode()
		{
			return mDB.GetExistingCardsWithCode();
		}

		public void MarkBundleUpdated(int WebID)
		{
			mDB.MarkBundleUpdated(WebID);
		}

		public bool GetCardExists(int webID, string cardCode, string cardRarity)
		{
			return mDB.GetCardExists(webID, cardCode, cardRarity);
		}

		public List<ScraperBundleToUpdate> CompareBundles(List<ScraperBundleToUpdate> bundleNames)
		{
			return mUpdater.BundleDifference(bundleNames);
		}

		public void UpdateStatuses(List<Card> newStatuses)
		{
			mDB.UpdateStatuses(newStatuses);
		}

		public static string AddSpacesToSentence(string text, bool preserveAcronyms)
		{
			if (string.IsNullOrWhiteSpace(text))
				return string.Empty;
			StringBuilder newText = new StringBuilder(text.Length * 2);
			newText.Append(text[0]);
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i]))
					if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
						(preserveAcronyms && char.IsUpper(text[i - 1]) &&
						 i < text.Length - 1 && !char.IsUpper(text[i + 1])))
						newText.Append(' ');
				newText.Append(text[i]);
			}
			return newText.ToString();
		}
		
		public bool AddCardToCollection(string cardCode)
		{
			if (mDB.GetCardExistsByCode(cardCode)) //Card exists :D
			{
				mDB.AddCard(cardCode);
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool AddSetToCollection(int setWebID)
		{
			return false;
		}
    }
}
