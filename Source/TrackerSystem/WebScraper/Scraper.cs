using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Web;
using System.Net;
using System.Drawing;

using HtmlAgilityPack;

using TrackerSystem.CardData;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;

namespace TrackerSystem.WebScraper
{
	public struct ScraperBundleToUpdate
	{
		public string Name;
		public string Link;
		public string SetType;
		public int Year;
		public int WebID;
	}

	public struct ScraperExistingCards
	{
		public int WebID;
		public string Code;
		public int SetWebID;
	}

	public struct ScraperUpdateData
	{
		public List<int> SetIDToUpdate;
		public Dictionary<int, List<Card>> SetGroups;
	}

	//SCRAPER NEEDS A MAJOR REWORK, THIS IS NOT OPTIMAL!!!
	public class Scraper
	{
		private string webScrapeURL = "http://www.db.yugioh-card.com/yugiohdb/";
		private HtmlWeb webGet = null;
		private List<ScraperBundleToUpdate> webDeckUpdateLinks = null;
		private Dictionary<int, List<int>> webBundleCardIDs = null;
		private Tracker mTracker = null;

		public Scraper(Tracker _tracker)
		{
			mTracker = _tracker;
			webGet = new HtmlWeb();
			webBundleCardIDs = new Dictionary<int, List<int>>();
		}

		public ScraperUpdateData DoScrapeCards(bool downloadImages, ref string currentCard, ref int completedCards, ref int totalCards, ref string currentStatus)
		{
			List<int> cardIDList = new List<int>();
			List<int> bundleIDs = new List<int>();

			currentStatus = "Preparing: Collecting set data... (This may take a LONG time)";
			mTracker.UpdaterSystem.TriggerDataChange();
			for (int i = 0; i < webDeckUpdateLinks.Count; i++) //For each bundle
			{
				HtmlDocument webDocument = null;

				try
				{
					webDocument = webGet.Load(webScrapeURL + webDeckUpdateLinks[i].Link + "&mode=2");
				}
				catch (Exception ex)
				{
					//Catch exception
				}

				if (webDocument != null) //Make sure web document has loaded correctly
				{
					HtmlNodeCollection cardListRows = webDocument.DocumentNode.SelectNodes("//div[@id='search_result']/table/tr[@class='row']");
					bool updateBundle = false;
					for (int j = 0; j < cardListRows.Count; j++) //For each card
					{
						string cardLink = cardListRows[j].SelectSingleNode("td[2]/input").Attributes["value"].Value.Replace("card_search.action", "");
						NameValueCollection cardQuery = HttpUtility.ParseQueryString(cardLink);
						int cardID = Convert.ToInt32(cardQuery["cid"]);
						if (cardIDList.Contains(cardID) == false) //Only accept new ID's to prevent unnecesary scraping.
						{
							if (!updateBundle)
								updateBundle = true;

							cardIDList.Add(cardID);
							totalCards += 1;
						}
					}

					if (updateBundle) //Add bundle to update
						bundleIDs.Add(webDeckUpdateLinks[i].WebID);
					else //Mark bundle updated if there are no new cards.
						mTracker.MarkBundleUpdated(webDeckUpdateLinks[i].WebID);

				}
			}

			mTracker.UpdaterSystem.TriggerDataChange();
			ScraperUpdateData updateData = new ScraperUpdateData();
			updateData.SetIDToUpdate = bundleIDs;
			updateData.SetGroups = DoUpdateCards(cardIDList, downloadImages, ref currentCard, ref completedCards, ref currentStatus);
			return updateData;
		}

		private Dictionary<int, List<Card>> DoUpdateCards(List<int> cardIDs, bool downloadImages, ref string currentCard, ref int completedCards, ref string currentStatus)
		{
			Dictionary<int, List<Card>> bundleSets = new Dictionary<int, List<Card>>();
			currentStatus = "Updating: Downloading card/set data...";
			mTracker.UpdaterSystem.TriggerDataChange();
			for (int i = 0; i < cardIDs.Count; i++) //For each card
			{
				HtmlDocument webDocument = null;

				try
				{
					webGet.Load(webScrapeURL + "card_search.action?ope=2&cid=" + cardIDs[i].ToString());
				}
				catch (Exception ex)
				{
					//Catch exception
				}

				if (webDocument != null) //Make sure web document has loaded correctly
				{
					//Remove comments, if not it breaks parsing
					webDocument.DocumentNode.Descendants().Where(n => n.NodeType == HtmlAgilityPack.HtmlNodeType.Comment).ToList().ForEach(n => n.Remove());


					CardType cardType = CardType.Monster;
					string cardName = webDocument.DocumentNode.SelectSingleNode("//header[@id='broad_title']/div/h1").InnerText.Trim();
					string cardDescription = "";
					currentCard = cardName;

					//Monster specific
					string cardMonsterType = "";
					int cardLevel = 0;
					CardSubType cardSubType = CardSubType.None;
					CardAttribute cardAttribute = CardAttribute.None;
					string cardAttack = "0";
					string cardDefence = "0";

					//Spell/Trap Specific
					CardIcon cardIcon = CardIcon.None;

					HtmlNodeCollection cardDetailRows = webDocument.DocumentNode.SelectNodes("//table[@id='details']//td");
					for (int j = 0; j < cardDetailRows.Count; j++) //Get details
					{
						string rowType = cardDetailRows[j].SelectSingleNode("div[1]/*[@class='item_box_title']/b").InnerText;
						string rowValue = "";
						HtmlNode dataNode = cardDetailRows[j].SelectSingleNode("div[1]/*[@class='item_box_value']");
						if (dataNode == null)
						{
							if (rowType == "Card Type") //Temporary fix
							{
								dataNode = cardDetailRows[j].SelectSingleNode("div[1]/text()[3]");
								rowValue = dataNode.InnerText.Trim();
							}
							else if (rowType == "Card Text")
							{
								if (cardSubType == CardSubType.Xyz)
								{
									rowValue = cardDetailRows[j].SelectSingleNode("div[1]/text()[2]").InnerText.Trim();

									dataNode = cardDetailRows[j].SelectSingleNode("div[1]/text()[3]");
									if (dataNode != null)
										rowValue += "\n" + dataNode.InnerText.Trim();

									dataNode = cardDetailRows[j].SelectSingleNode("div[1]/text()[4]");
									if (dataNode != null)
										rowValue += "\n" + dataNode.InnerText.Trim();

								}
								else
								{
									dataNode = cardDetailRows[j].SelectSingleNode("div[1]/text()[2]");
									rowValue = dataNode.InnerText.Trim();
								}
							}
							else
							{
								dataNode = cardDetailRows[j].SelectSingleNode("div[1]/text()[last()]");
								rowValue = dataNode.InnerText.Trim();
							}
						}
						else
						{
							rowValue = dataNode.InnerText.Trim();
						}

						//Need to find a better way to find out if its a monster or a trap/spell
						if (cardDetailRows.Count > 2) //Monster
						{

							cardType = CardType.Monster;
							switch (rowType)
							{
								case "Attribute":
									if (rowValue.Length > 0)
									{
										cardAttribute = EnumUtils.ParseEnum<CardAttribute>(rowValue);
									}
									else
									{
										cardAttribute = CardAttribute.None;
									}
									break;
								case "Level":
									cardLevel = Convert.ToInt32(rowValue);
									break;
								case "Rank":
									cardLevel = Convert.ToInt32(rowValue);
									break;
								case "Monster Type":
									cardMonsterType = rowValue;
									break;
								case "Card Type":
									if (rowValue.Length > 0)
									{
										cardSubType = EnumUtils.ParseEnum<CardSubType>(rowValue);
									}
									else
									{
										cardSubType = CardSubType.None;
									}
									break;
								case "ATK":
									cardAttack = rowValue;
									break;
								case "DEF":
									cardDefence = rowValue;
									break;
								case "Card Text":
									cardDescription = rowValue;
									break;
							}
						}
						else //Spell/Trap
						{
							string cardDataIcon = "";
							Regex specialCharacters = new Regex("[^a-zA-Z0-9 -]");
							string cleanRowValue = specialCharacters.Replace(rowValue, "").Replace("-", ""); //Remove all special characters
							string[] cardData = cleanRowValue.Split(' ');
							if (cardData.Length == 2)
							{
								cardDataIcon = cardData[0];
								if (cardData[1] == "Spell")
								{
									cardType = CardType.Spell;
								}
								else
								{
									cardType = CardType.Trap;
								}
							}

							switch (rowType)
							{
								case "Icon":
									if (rowValue.Length > 0)
									{
										cardIcon = EnumUtils.ParseEnum<CardIcon>(cardDataIcon);
									}
									else
									{
										cardIcon = CardIcon.None;
									}
									break;
								case "Card Text":
									cardDescription = cleanRowValue;
									break;
							}
						}
					}

					HtmlNodeCollection cardPackRows = webDocument.DocumentNode.SelectNodes("//div[@id='pack_list']/table/tr[@class='row']");
					bool isImageDownloaded = false;
					if (downloadImages)
					{
						HtmlNodeCollection cardFrames = webDocument.DocumentNode.SelectNodes("//div[@id='thumbnail']/img");

						if (!Directory.Exists(Tracker.CardImageDir + cardIDs[i].ToString())) //Create Card Directory if it doesnt exist
						{
							Directory.CreateDirectory(Tracker.CardImageDir + cardIDs[i].ToString());
						}


						for (int j = 0; j < cardFrames.Count; j++) //Get images for each image available
						{
							int currentImageID = Convert.ToInt32(cardFrames[j].Attributes["alt"].Value);
							HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webScrapeURL + "get_image.action?type=2&cid=" + cardIDs[i].ToString() + "&ciid=" + currentImageID.ToString());
							httpWebRequest.Referer = webScrapeURL + "card_search.action?ope=2&cid=" + cardIDs[i].ToString();

							if (!File.Exists(Tracker.CardImageDir + cardIDs[i].ToString() + @"\" + currentImageID.ToString() + ".png")) //No point in downloading image if its already there.
							{
								using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
								{
									using (Stream stream = httpWebReponse.GetResponseStream())
									{
										Image newImage = Image.FromStream(stream);
										newImage.Save(Tracker.CardImageDir + cardIDs[i].ToString() + @"\" + currentImageID.ToString() + ".png", ImageFormat.Png);
									}
								}

								if (File.Exists(Tracker.CardImageDir + cardIDs[i].ToString() + @"\" + currentImageID.ToString() + ".png")) //Check if file downloaded
								{
									isImageDownloaded = true;
								}
							}
							else
							{
								isImageDownloaded = true;
							}
						}
					}

					for (int j = 0; j < cardPackRows.Count; j++) //Each pack the card is in
					{
						string cardCode = cardPackRows[j].SelectSingleNode("td[2]").InnerText;
						CardRarity cardRarity = CardRarity.Normal;
						HtmlNode rarityNode = cardPackRows[j].SelectSingleNode("td[4]/img");
						if (rarityNode != null)
						{
							string rarityText = rarityNode.Attributes["alt"].Value.Replace(" ", "");
							cardRarity = EnumUtils.ParseEnum<CardRarity>(rarityText); //Need to change to TryParse
						}

						if (!mTracker.GetCardExists(cardIDs[i], cardCode, cardRarity.ToString())) //Only allow new cards to be added.
						{
							string setQueryString = cardPackRows[j].SelectSingleNode("td[3]/input").Attributes["value"].Value.Replace("card_search.action", "");
							NameValueCollection cardQuery = HttpUtility.ParseQueryString(setQueryString);
							int setID = Convert.ToInt32(cardQuery["pid"]);

							Card tmpCard = new Card();

							//Generic
							tmpCard.Type = cardType;
							tmpCard.ID = cardIDs[i];
							tmpCard.Code = cardCode;
							tmpCard.Name = cardName;
							tmpCard.Description = cardDescription;
							tmpCard.SetWebID = setID;
							tmpCard.Rarity = cardRarity;
							tmpCard.ImageDownloaded = isImageDownloaded;

							//Monster Specific
							tmpCard.SubType = cardSubType;
							tmpCard.Level = cardLevel;
							tmpCard.Attack = cardAttack;
							tmpCard.Defence = cardDefence;
							tmpCard.Attribute = cardAttribute;
							tmpCard.MonsterType = cardMonsterType;

							//Icon
							tmpCard.ST_Icon = cardIcon;

							if (bundleSets.ContainsKey(setID))
							{
								bundleSets[setID].Add(tmpCard);
							}
							else
							{
								bundleSets.Add(setID, new List<Card>());
								bundleSets[setID].Add(tmpCard);
							}
						}
					}
				}

				completedCards += 1;
				mTracker.UpdaterSystem.TriggerDataChange();
			}

			UpdateBanList(); //Update banlist with new cards.
			return bundleSets;
		}

		public bool CheckUpdate()
		{
			HtmlDocument webDocument = null;

			try
			{
				webDocument = webGet.Load(webScrapeURL + "card_list.action");
			}
			catch (Exception ex)
			{
				//Catch exception
			}

			if (webDocument != null) //Make sure web document has loaded correctly
			{
				List<ScraperBundleToUpdate> listBundles = new List<ScraperBundleToUpdate>();
				HtmlNodeCollection cardListRows = webDocument.DocumentNode.SelectNodes("//div[@id='card_list_1']/table/tr");
				for (int i = 0; i < cardListRows.Count; i++) //Get Table Rows
				{
					HtmlNodeCollection cardSet = cardListRows[i].SelectNodes("td");
					for (int j = 0; j < cardSet.Count; j++) //Set (e.g. Booster Packs)
					{
						string setType = cardSet[j].SelectSingleNode("div[@class='list_title radius_top']/table/tr/th[2]").InnerText;
						int currentYear = 2002;
						HtmlNodeCollection cardListBody = cardSet[j].SelectNodes("div[@class='list_body']/div");
						for (int k = 0; k < cardListBody.Count; k++) //Packs (e.g. Primal Origin)
						{
							if (cardListBody[k].Attributes["class"].Value == "pack_m") //Is year
							{
								string parseYear = cardListBody[k].InnerText.Substring(8); //Need a more automated substring way of removing double chevrons
								bool parseYearResult = Int32.TryParse(parseYear, out currentYear);
							}
							else if (cardListBody[k].Attributes["class"].Value == "toggle") //Is bundle
							{
								HtmlNodeCollection cardListBundles = cardListBody[k].SelectNodes("div[@class='pack pack_en']");
								for (int l = 0; l < cardListBundles.Count; l++) //Each Bundle
								{
									HtmlNode CardBundle = cardListBundles[l];
									ScraperBundleToUpdate tmpBundle = new ScraperBundleToUpdate();
									string queryString = CardBundle.SelectSingleNode("input[1]").Attributes["value"].Value;
									NameValueCollection cardQuery = HttpUtility.ParseQueryString(queryString.Replace("card_search.action", ""));
									int packID = Convert.ToInt32(cardQuery["pid"]);

									tmpBundle.Name = CardBundle.SelectSingleNode("strong[1]").InnerText;
									tmpBundle.Link = queryString;
									tmpBundle.SetType = setType;
									tmpBundle.Year = currentYear;
									tmpBundle.WebID = packID;
									listBundles.Add(tmpBundle);
								}
							}
						}
					}
				}

				CheckUpdatePart2(ref listBundles, ref webDocument);
				UpdateBanList(); // Update Banned and Forbidden cards
				webDeckUpdateLinks = mTracker.CompareBundles(listBundles);

				if (webDeckUpdateLinks.Count > 0)
					return true; //New bundles!
				else
					return false; //No new bundles :(

			}
			return false;
		}

		private void CheckUpdatePart2(ref List<ScraperBundleToUpdate> bundlesToUpdate, ref HtmlDocument webDocument)
		{
			if (bundlesToUpdate != null && webDocument != null)
			{
				HtmlNodeCollection cardListRows = webDocument.DocumentNode.SelectNodes("//div[@id='card_list_2']/table/tr");
				for (int i = 0; i < cardListRows.Count; i++) //Get Table Rows
				{
					HtmlNodeCollection cardSet = cardListRows[i].SelectNodes("td");
					for (int j = 0; j < cardSet.Count; j++) //Set (e.g. Booster Packs)
					{
						string setType = cardSet[j].SelectSingleNode("div[@class='list_title radius_top']/table/tr/th[2]").InnerText;
						int currentYear = 2002;
						HtmlNodeCollection cardListBody = cardSet[j].SelectNodes("div[@class='list_body']/div");
						for (int k = 0; k < cardListBody.Count; k++) //Packs (e.g. Primal Origin)
						{
							if (cardListBody[k].Attributes["class"].Value == "pack_m") //Is year
							{
								string parseYear = cardListBody[k].InnerText.Substring(8); //Need a more automated substring way of removing double chevrons
								bool parseYearResult = Int32.TryParse(parseYear, out currentYear);
							}
							else if (cardListBody[k].Attributes["class"].Value == "toggle none") //Is bundle
							{
								HtmlNodeCollection cardListBundles = cardListBody[k].SelectNodes("div[@class='pack pack_en']");
								for (int l = 0; l < cardListBundles.Count; l++) //Each Bundle
								{
									HtmlNode CardBundle = cardListBundles[l];
									ScraperBundleToUpdate tmpBundle = new ScraperBundleToUpdate();
									string queryString = CardBundle.SelectSingleNode("input[1]").Attributes["value"].Value;
									NameValueCollection cardQuery = HttpUtility.ParseQueryString(queryString.Replace("card_search.action", ""));
									int packID = Convert.ToInt32(cardQuery["pid"]);

									tmpBundle.Name = CardBundle.SelectSingleNode("strong[1]").InnerText;
									tmpBundle.Link = queryString;
									tmpBundle.SetType = setType.Replace(",", "");
									tmpBundle.Year = currentYear;
									tmpBundle.WebID = packID;
									bundlesToUpdate.Add(tmpBundle);
								}
							}
						}
					}
				}
			}
		}

		private void UpdateBanList() //Update banned and forbidden list
		{
			HtmlDocument webDocument = null;

			try
			{
				webDocument = webGet.Load(webScrapeURL + "forbidden_limited.action");
			}
			catch (Exception ex)
			{
				//Catch exception
			}

			if (webDocument != null) //Make sure web document has loaded correctly
			{
				HtmlNodeCollection cardTables = webDocument.DocumentNode.SelectNodes("//div[@id='article_body']/table/tr");
				List<Card> bannedCards = new List<Card>();
				CardStatus currentStatus = CardStatus.Normal;
				for (int i = 0; i < cardTables.Count; i++)
				{
					if (i > 2)
					{
						break;
					}
					else
					{
						if (i == 0)
							currentStatus = CardStatus.Forbidden;
						else if (i == 1)
							currentStatus = CardStatus.Limited;
						else if (i == 2)
							currentStatus = CardStatus.SemiLimited;

						HtmlNodeCollection cardList = cardTables[i].SelectNodes("td/div[@class='forbidden_limited_list radius_top']/table/tr[@class='row']");
						for (int j = 0; j < cardList.Count; j++)
						{
							string setQueryString = cardList[j].SelectSingleNode("td[2]/a").Attributes["href"].Value.Replace("card_search.action", "");
							NameValueCollection cardQuery = HttpUtility.ParseQueryString(setQueryString);
							int cardID = Convert.ToInt32(cardQuery["cid"]);

							Card tmpCard = new Card();

							//Generic
							tmpCard.ID = cardID;
							tmpCard.Status = currentStatus;

							bannedCards.Add(tmpCard);
						}
					}
				}

				this.mTracker.UpdateStatuses(bannedCards);
			}
		}
	}
}
