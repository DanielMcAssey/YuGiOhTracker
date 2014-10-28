using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;
using System.Data;

using TrackerSystem.CardData;
using TrackerSystem.WebScraper;

namespace TrackerSystem.DBManager
{
	public class DatabaseManager
	{
		private string SystemConnection;
		private string UserConnection;

		private const string systemDB = "_data.db";
		private const string userDB = "_user.db";

		public DatabaseManager()
		{
			this.Initialization();
		}

		private void Initialization()
		{
			SystemConnection = "Data Source=" + systemDB + ";Version=3;Compress=True;Pooling=True;Max Pool Size=100;";
			UserConnection = "Data Source=" + userDB + ";Version=3;Compress=True;Pooling=True;Max Pool Size=100;";

			bool seedSystemTables = false;
			bool seedUserTables = false;

			if (!File.Exists(systemDB))
			{
				SQLiteConnection.CreateFile(systemDB);
				seedSystemTables = true;
			}

			if (!File.Exists(userDB))
			{
				SQLiteConnection.CreateFile(userDB);
				seedUserTables = true;
			}

			SQLiteConnection dbSys = new SQLiteConnection(SystemConnection);
			dbSys.Open();

			if(!seedSystemTables)
			{
				string dbVersion = "";
				string getVersion = "SELECT * FROM system WHERE id = 'app_version'";
				SQLiteCommand getVersionCMD = new SQLiteCommand(getVersion, dbSys);
				SQLiteDataReader getVersionReader = getVersionCMD.ExecuteReader();
				while (getVersionReader.Read())
					dbVersion = getVersionReader["setting"].ToString();

				if(System.Reflection.Assembly.GetAssembly(typeof(Tracker)).GetName().Version.ToString() != dbVersion)
				{
					//NEED TO DO AUTOMATIC BACKUP HERE // TODO
					File.Delete("_data.db");
					seedSystemTables = true;
				}
			}

			dbSys.Close();

			if (seedSystemTables)
				this.SeedSystemTables();

			if (seedUserTables)
				this.SeedUserTables();

			SeedUserTables();
		}

		private void SeedSystemTables()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<string> tableSeed = new List<string>();

				//Table seeds below
				//CREATE
				tableSeed.Add("CREATE TABLE IF NOT EXISTS system (id VARCHAR(64) PRIMARY KEY, setting VARCHAR(64))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS card_rarities (id INTEGER PRIMARY KEY, stub VARCHAR(24), text VARCHAR(32))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS bundle_types (id INTEGER PRIMARY KEY, stub VARCHAR(24), text VARCHAR(32))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS status_types (id INTEGER PRIMARY KEY, stub VARCHAR(24), text VARCHAR(32))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS cards (id INTEGER PRIMARY KEY, webid INT, code VARCHAR(24), rarity VARCHAR(24), name VARCHAR(254), description TEXT, level INT, type VARCHAR(12), subtype VARCHAR(12), monstertype VARCHAR(24), attribute VARCHAR(12), sticon VARCHAR(12), atk VARCHAR(8), def VARCHAR(8), setid INT, cardimage INT, status VARCHAR(12))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS card_bundle (id INTEGER PRIMARY KEY, webid INT, type VARCHAR(64), year INT, name VARCHAR(254), isupdated INT)");
				//INSERT
				tableSeed.Add("INSERT INTO system (id, setting) VALUES ('app_version', '" + System.Reflection.Assembly.GetAssembly(typeof(Tracker)).GetName().Version.ToString() + "')");

				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'Normal', 'Common')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'Rare', 'Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'SuperRare', 'Super Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'UltraRare', 'Ultra Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'SecretRare', 'Secret Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'Ultimate', 'Ultimate Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'Holographic', 'Holographic Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'GoldRare', 'Gold Rare')");
				tableSeed.Add("INSERT INTO card_rarities (id, stub, text) VALUES (NULL, 'GoldSecret', 'Gold Secret Rare')");

				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'BoosterPacks', 'Booster Packs')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'SpecialEditionBoxes', 'Special Edition Boxes')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'StarterDecks', 'Starter Decks')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'StructureDecks', 'Structure Decks')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'Tins', 'Tins')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'DuelistPacks', 'Duelist Packs')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'DuelTerminalCards', 'Duel Terminal Cards')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'Others', 'Others')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'MagazinesBooksComics', 'Magazines, Books, Comics')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'Tournaments', 'Tournaments')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'PromotionalCards', 'Promotional Cards')");
				tableSeed.Add("INSERT INTO bundle_types (id, stub, text) VALUES (NULL, 'VideoGameBundles', 'Video Game Bundles')");

				tableSeed.Add("INSERT INTO status_types (id, stub, text) VALUES (NULL, 'Normal', 'No Limit')");
				tableSeed.Add("INSERT INTO status_types (id, stub, text) VALUES (NULL, 'Forbidden', 'Forbidden')");
				tableSeed.Add("INSERT INTO status_types (id, stub, text) VALUES (NULL, 'Limited', 'Limited (1 card)')");
				tableSeed.Add("INSERT INTO status_types (id, stub, text) VALUES (NULL, 'SemiLimited', 'Limited (2 cards)')");

				for (int i = 0; i < tableSeed.Count; i++)
				{
					SQLiteCommand tmpCommand = new SQLiteCommand(tableSeed[i], dbSys);
					tmpCommand.ExecuteNonQuery();
				}
			}
		}

		private void SeedUserTables()
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				List<string> tableSeed = new List<string>();

				//Table seeds below
				//CREATE
				tableSeed.Add("CREATE TABLE IF NOT EXISTS system (id VARCHAR(64) PRIMARY KEY, setting VARCHAR(64))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS user_cards (id INT PRIMARY KEY, cardCode VARCHAR(24))");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS user_decks (id INT PRIMARY KEY, deckName VARCHAR(64), lastUpdatedDate TEXT, createdDate TEXT)");
				tableSeed.Add("CREATE TABLE IF NOT EXISTS deck_card_rel (id INT PRIMARY KEY, deckID INT, cardCode VARCHAR(24))");
				//INSERT
				//tableSeed.Add("INSERT INTO system (id, setting) VALUES ('revision', '0')");
				//tableSeed.Add("INSERT INTO system (id, setting) VALUES ('save_count', '0')");
				//tableSeed.Add("INSERT INTO system (id, setting) VALUES ('mashape_api_key', '')");

				for (int i = 0; i < tableSeed.Count; i++)
				{
					SQLiteCommand tmpCommand = new SQLiteCommand(tableSeed[i], dbUser);
					tmpCommand.ExecuteNonQuery();
				}
			}
		}

		private void ResetStatuses()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "UPDATE cards SET status = 'Normal'";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.ExecuteNonQuery();
			}
		}

		public void UpdateStatuses(List<Card> updatedCards)
		{
			ResetStatuses(); //Reset statuses to default, before updating
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				for (int i = 0; i < updatedCards.Count; i++)
				{
					string sql = "UPDATE cards SET status = @paramstatus WHERE webid = @paramwebid";
					SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
					sqlCMD.Parameters.Add(new SQLiteParameter("@paramstatus", updatedCards[i].Status.ToString()));
					sqlCMD.Parameters.Add(new SQLiteParameter("@paramwebid", updatedCards[i].ID));
					sqlCMD.ExecuteNonQuery();
				}
			}
		}

		public List<int> MultiCheckBundleNames(List<ScraperBundleToUpdate> bundleNames, bool updatedBundles)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<int> newIDs = new List<int>();
				for (int i = 0; i < bundleNames.Count; i++)
				{
					string getBundles = "SELECT COUNT(*) FROM card_bundle WHERE webid = @bundlewebid AND isupdated = @paramupdated";
					SQLiteCommand getBundlesCMD = new SQLiteCommand(getBundles, dbSys);
					getBundlesCMD.Parameters.Add(new SQLiteParameter("@bundlewebid", bundleNames[i].WebID));
					getBundlesCMD.Parameters.Add(new SQLiteParameter("@paramupdated", Convert.ToInt32(updatedBundles)));
					int rowsFound = Convert.ToInt32(getBundlesCMD.ExecuteScalar());
					if (rowsFound == 0)
						newIDs.Add(i);
				}
				return newIDs;
			}
		}

		public List<int> GetBundlesByUpdate(bool updatedBundles)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<int> bundleList = new List<int>();
				string getBundles = "SELECT webid FROM card_bundle WHERE isupdated = @paramupdated";
				SQLiteCommand getBundlesCMD = new SQLiteCommand(getBundles, dbSys);
				getBundlesCMD.Parameters.Add(new SQLiteParameter("@paramupdated", Convert.ToInt32(updatedBundles)));
				SQLiteDataReader reader = getBundlesCMD.ExecuteReader();
				while (reader.Read())
					bundleList.Add(Convert.ToInt32(reader["webid"]));

				return bundleList;
			}
		}

		public List<int> GetExistingCards()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<int> cardList = new List<int>();
				string sql = "SELECT webid FROM cards";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while (reader.Read())
					cardList.Add(Convert.ToInt32(reader["webid"]));

				return cardList;
			}
		}

		public List<ScraperExistingCards> GetExistingCardsWithCode()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<ScraperExistingCards> cardList = new List<ScraperExistingCards>();
				string sql = "SELECT webid,code,setid FROM cards";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while (reader.Read())
				{
					ScraperExistingCards tmpExistingCard = new ScraperExistingCards();
					tmpExistingCard.WebID = Convert.ToInt32(reader["webid"]);
					tmpExistingCard.Code = reader["code"].ToString();
					tmpExistingCard.SetWebID = Convert.ToInt32(reader["setid"]);
				}

				return cardList;
			}
		}

		public void RemoveNonUpdatedBundles()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string removeBundles = "DELETE FROM card_bundle WHERE isupdated = 0";
				SQLiteCommand removeBundlesCMD = new SQLiteCommand(removeBundles, dbSys);
				removeBundlesCMD.ExecuteNonQuery();
			}
		}

		public void RemoveNonUpdatedCards()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				List<int> bundlesNotUpdated = GetBundlesByUpdate(false);
				for (int i = 0; i < bundlesNotUpdated.Count; i++)
				{
					string sql = "DELETE FROM cards WHERE setid = @bundlesetid";
					SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
					sqlCMD.Parameters.Add(new SQLiteParameter("@bundlesetid", bundlesNotUpdated[i]));
					sqlCMD.ExecuteNonQuery();
				}
			}
		}

		public int GetBundleIDByName(string name)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string getBundles = "SELECT rowid FROM card_bundle WHERE name = @bundlename";
				int rowID = 0;
				SQLiteCommand getBundlesCMD = new SQLiteCommand(getBundles, dbSys);
				getBundlesCMD.Parameters.Add(new SQLiteParameter("@bundlename", name));
				SQLiteDataReader reader = getBundlesCMD.ExecuteReader();
				while (reader.Read())
					rowID = Convert.ToInt32(reader["rowid"]);

				return rowID;
			}
		}

		public bool GetBundleExists(int webID)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				bool bundleExists = false;
				string sql = "SELECT COUNT(*) FROM card_bundle WHERE webid = @bundlewebid";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@bundlewebid", webID));
				int rowsFound = Convert.ToInt32(sqlCMD.ExecuteScalar());
				if (rowsFound > 0)
					bundleExists = true;

				return bundleExists;
			}
		}

		public bool GetCardExists(int webID, string cardCode, string cardRarity)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				bool cardExists = false;
				string sql = "SELECT COUNT(*) FROM cards WHERE webid = @cardwebid AND code = @cardcode AND rarity = @cardrarity";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@cardwebid", webID));
				sqlCMD.Parameters.Add(new SQLiteParameter("@cardcode", cardCode));
				sqlCMD.Parameters.Add(new SQLiteParameter("@cardrarity", cardRarity));
				int rowsFound = Convert.ToInt32(sqlCMD.ExecuteScalar());
				if (rowsFound > 0)
					cardExists = true;

				return cardExists;
			}
		}

		public void InsertBundles(List<CardBundle> listBundles)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				for (int i = 0; i < listBundles.Count; i++)
				{
					if (!GetBundleExists(listBundles[i].WebID))
					{
						string sql = "INSERT INTO card_bundle (id,webid,type,year,name,isupdated) VALUES (NULL,@paramwebid,@paramtype,@paramyear,@paramname,@paramupdated)";
						SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramwebid", listBundles[i].WebID));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramtype", listBundles[i].Type.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramyear", listBundles[i].Year));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramname", listBundles[i].Name));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramupdated", Convert.ToInt32(listBundles[i].IsUpdated)));
						sqlCMD.ExecuteNonQuery();
					}
				}
			}
		}

		public void InsertCards(List<Card> listCards)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				for (int i = 0; i < listCards.Count; i++)
				{
					if (!GetCardExists(listCards[i].ID, listCards[i].Code, listCards[i].Rarity.ToString()))
					{
						string sql = "INSERT INTO cards (id,webid,code,rarity,name,description,level,type,subtype,monstertype,attribute,sticon,atk,def,setid,cardimage) VALUES (NULL,@paramwebid,@paramcode,@paramrarity,@paramname,@paramdesc,@paramlevel,@paramtype,@paramsubtype,@parammonstertype,@paramattribute,@paramsticon,@paramattack,@paramdefence,@paramsetid,@paramimage)";
						SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramwebid", listCards[i].ID));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramcode", listCards[i].Code));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramrarity", listCards[i].Rarity.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramname", listCards[i].Name));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramdesc", listCards[i].Description));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramlevel", listCards[i].Level));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramtype", listCards[i].Type.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramsubtype", listCards[i].SubType.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@parammonstertype", listCards[i].MonsterType));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramattribute", listCards[i].Attribute.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramsticon", listCards[i].ST_Icon.ToString()));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramattack", listCards[i].Attack));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramdefence", listCards[i].Defence));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramsetid", listCards[i].SetWebID));
						sqlCMD.Parameters.Add(new SQLiteParameter("@paramimage", Convert.ToInt32(listCards[i].ImageDownloaded)));
						sqlCMD.ExecuteNonQuery();
					}
				}
			}
		}

		public void MarkBundleUpdated(int bundleWebID)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "UPDATE card_bundle SET isupdated = 1 WHERE webid = @bundlewebid";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@bundlewebid", bundleWebID));

				try
				{
					sqlCMD.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}


		public CardBundle FindBundleByID(int id, bool isWebID)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				CardBundle result = new CardBundle();
				string sql = "SELECT * FROM card_bundle WHERE card_bundle.id = @bundleid";

				if(isWebID)
					sql = "SELECT * FROM card_bundle WHERE card_bundle.webid = @bundleid";

				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@bundleid", id));
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while (reader.Read())
				{
					result.Name = reader["name"].ToString();
					result.Type = EnumUtils.ParseEnum<BundleType>(reader["type"].ToString());
					result.WebID = Convert.ToInt32(reader["webid"].ToString());
					result.Year = Convert.ToInt32(reader["year"].ToString());
				}

				return result;
			}
		}

		public Card FindCardByID(int id)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				Card result = new Card();

				string sql = "SELECT id,code,level,name,description,rarity,type,subtype,monstertype,sticon,attribute,atk,def,webid,setid,status FROM cards WHERE cards.id = @cardid";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@cardid", id));
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while (reader.Read())
				{
					result.ID = Convert.ToInt32(reader["webid"].ToString());
					result.Code = reader["code"].ToString();
					result.Name = reader["name"].ToString();
					result.Description = reader["description"].ToString();
					result.Type = EnumUtils.ParseEnum<CardType>(reader["type"].ToString());
					result.Level = Convert.ToInt32(reader["level"].ToString());
					result.Attribute = EnumUtils.ParseEnum<CardAttribute>(reader["attribute"].ToString());
					result.SubType = EnumUtils.ParseEnum<CardSubType>(reader["subtype"].ToString());
					result.Attack = reader["atk"].ToString();
					result.Defence = reader["def"].ToString();
					result.ST_Icon = EnumUtils.ParseEnum<CardIcon>(reader["sticon"].ToString());
					result.Rarity = EnumUtils.ParseEnum<CardRarity>(reader["rarity"].ToString());
					result.SetWebID = Convert.ToInt32(reader["setid"].ToString());
					result.Status = EnumUtils.ParseEnum<CardStatus>(reader["status"].ToString());
					result.MonsterType = reader["monstertype"].ToString();
				}

				return result;
			}
		}

		public DataTable FindAllBundlesDT()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "SELECT card_bundle.id,bundle_types.text AS type,year,name,webid FROM card_bundle JOIN bundle_types ON card_bundle.type = bundle_types.stub ORDER BY card_bundle.year DESC, card_bundle.type ASC";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public DataTable FindAllCardsDT()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "SELECT cards.id,code,level,name,card_rarities.text AS rarity,type,subtype,sticon,attribute,atk,def,status_types.text AS status FROM cards JOIN card_rarities ON cards.rarity = card_rarities.stub JOIN status_types ON cards.status = status_types.stub ORDER BY cards.code ASC";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public DataTable FindAllCardsByIDDT(int _id, bool isWebID)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "SELECT cards.id,code,name,card_rarities.text AS rarity,status_types.text AS status FROM cards JOIN card_rarities ON cards.rarity = card_rarities.stub JOIN status_types ON cards.status = status_types.stub WHERE id = @paramid ORDER BY cards.code ASC";
				if(isWebID)
					sql = "SELECT cards.id,code,name,card_rarities.text AS rarity,status_types.text AS status FROM cards JOIN card_rarities ON cards.rarity = card_rarities.stub JOIN status_types ON cards.status = status_types.stub WHERE webid = @paramid ORDER BY cards.code ASC";
				
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramid", _id));
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public DataTable FindAllBannedCardsDT()
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "SELECT cards.id,code,type,name,status_types.text AS status FROM cards JOIN card_rarities ON cards.rarity = card_rarities.stub JOIN status_types ON cards.status = status_types.stub WHERE cards.status != 'Normal' ORDER BY cards.status,cards.type ASC";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public DataTable FindAllCardsByBundleWebIDDT(int bundleWebID)
		{
			using (SQLiteConnection dbSys = new SQLiteConnection(SystemConnection))
			{
				dbSys.Open();

				string sql = "SELECT cards.id,code,level,name,card_rarities.text AS rarity,type,subtype,sticon,attribute,atk,def,status_types.text AS status FROM cards JOIN card_rarities ON cards.rarity = card_rarities.stub JOIN status_types ON cards.status = status_types.stub WHERE cards.setid = @paramsetid ORDER BY cards.name ASC";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbSys);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramsetid", bundleWebID));
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public Dictionary<string, string> GetAllSettings()
		{
			Dictionary<string, string> getSettings = new Dictionary<string, string>();
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "SELECT * FROM system";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while(reader.Read())
				{
					getSettings.Add(reader["id"].ToString(), reader["setting"].ToString());
				}

				return getSettings;
			}
		}

		public string GetSetting(string settingKey)
		{
			string result = "";
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "SELECT * FROM system WHERE id = @paramkey";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramkey", settingKey));
				SQLiteDataReader reader = sqlCMD.ExecuteReader();
				while (reader.Read())
				{
					result = reader["setting"].ToString();
				}

				return result;
			}
		}

		public void UpdateSetting(string settingKey, string settingValue)
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "UPDATE system SET setting = @paramvalue WHERE id = @paramkey";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramkey", settingKey));
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramvalue", settingValue));

				try
				{
					sqlCMD.ExecuteNonQuery();
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public List<UserCardBundle> GetAllUserBundles()
		{
			List<UserCardBundle> result = new List<UserCardBundle>();
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "SELECT * FROM user_decks";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				SQLiteDataReader reader = sqlCMD.ExecuteReader();

				string sqlCount = "SELECT * FROM deck_card_rel WHERE deckID = @paramdeckid";
				SQLiteCommand sqlCountCMD = new SQLiteCommand(sqlCount, dbUser);

				while (reader.Read())
				{
					sqlCountCMD.Parameters.Add(new SQLiteParameter("@paramdeckid", Convert.ToInt32(reader["id"].ToString())));
					int cardCount = 0;
					cardCount = Convert.ToInt32(sqlCountCMD.ExecuteScalar());

					UserCardBundle tmpBundle = new UserCardBundle();
					tmpBundle.ID = Convert.ToInt32(reader["id"].ToString());
					tmpBundle.BundleName = reader["deckName"].ToString();
					tmpBundle.CardCount = cardCount;
					result.Add(tmpBundle);
				}
			}

			return result;
		}

		public DataTable FindAllUserBundlesDT()
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "SELECT * FROM user_decks ORDER BY lastUpdatedDate DESC";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public DataTable FindAllUserCardsDT()
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "SELECT * FROM user_cards";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				SQLiteDataAdapter sqlDA = new SQLiteDataAdapter(sqlCMD);
				DataSet sqlDS = new DataSet();
				DataTable sqlDT = null;

				try
				{
					sqlDA.Fill(sqlDS);
					sqlDT = sqlDS.Tables[0];
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}

				return sqlDT;
			}
		}

		public void AddCard(string cardCode)
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "INSERT INTO user_cards (id,cardCode) VALUES (NULL,@paramcardcode)";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramcardcode", cardCode));
				sqlCMD.ExecuteNonQuery();
			}
		}

		public void AddCardToCollection(int deckID, string cardCode)
		{
			using (SQLiteConnection dbUser = new SQLiteConnection(UserConnection))
			{
				dbUser.Open();

				string sql = "INSERT INTO deck_card_rel (id,deckID,cardCode) VALUES (NULL,@paramdeckid,@paramcardcode)";
				SQLiteCommand sqlCMD = new SQLiteCommand(sql, dbUser);
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramdeckid", deckID));
				sqlCMD.Parameters.Add(new SQLiteParameter("@paramcardcode", cardCode));
				sqlCMD.ExecuteNonQuery();
			}
		}
	}
}
