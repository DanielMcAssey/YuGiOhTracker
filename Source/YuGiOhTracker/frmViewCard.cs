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

using Newtonsoft.Json;
using System.Net;
using Newtonsoft.Json.Linq;

namespace YuGiOhTracker
{
	public partial class frmViewCard : Form
	{
		struct CardPrices
		{
			public bool Status;
			public double High;
			public double Average;
			public double Low;
			public double Shift;
			public double Shift3;
			public double Shift7;
			public double Shift30;
			public double Shift90;
			public double Shift180;
			public double Shift365;
			public string LastUpdate;
		}
		public const string webPriceURL = "https://yugiohprices.p.mashape.com/price_for_print_tag/";

		private BackgroundWorker priceLoaderWorker;
		private DatabaseManager mDB;
		private int cardID = 0;
		private Card currentCard;
		private CardBundle currentSet;
		private int totalCardImages = 0;
		private int currentCardImageIndex = 0;
		private string[] cardImages;
		private int selectedIndex = 0;

		private void UpdateCardCount()
		{
			if(totalCardImages > 0)
			{
				string newCount = (currentCardImageIndex + 1).ToString() + "/" + (totalCardImages.ToString());
				lblImageCount.Text = newCount;
			}
		}

		private void SetNoCardImage()
		{
			if(File.Exists(Tracker.CardImageDir+"no-card-image.png"))
			{
				pbCardView.Image = Image.FromFile(Tracker.CardImageDir + "no-card-image.png");
			}
		}

		private void SetCardView(int newIndex)
		{
			if (totalCardImages > 0)
			{
				if (newIndex >= 0 && newIndex < cardImages.Length)
				{
					pbCardView.Image = Image.FromFile(cardImages[newIndex]);
					currentCardImageIndex = newIndex;
					UpdateCardCount();
				}
			}
		}

		private void SortCardImages(int webID)
		{
			pbCardView.SizeMode = PictureBoxSizeMode.CenterImage;
			if (Directory.Exists(Tracker.CardImageDir + webID.ToString() + @"\"))
			{
				cardImages = Directory.GetFiles(Tracker.CardImageDir + webID.ToString() + @"\", "*.png");
				if (cardImages.Length > 0)
				{
					totalCardImages = cardImages.Length;
					pbCardView.Image = Image.FromFile(cardImages[0]);
					currentCardImageIndex = 0;
					UpdateCardCount();
				}
				else
				{
					SetNoCardImage();
				}
			}
			else
			{
				SetNoCardImage();
			}
		}

		#region "Load Prices (Worker)"
		private void DoLoadPricesWork(object sender, DoWorkEventArgs e)
		{
			Card tmpCard = (Card)e.Argument;
			e.Result = LoadPricesFromWeb(tmpCard);
		}

		private void LoadPricesWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			CardPrices newPrices = (CardPrices)e.Result;
			if(newPrices.Status)
			{
				txtPriceHigh.Text = newPrices.High.ToString("N2");
				txtPriceLow.Text = newPrices.Low.ToString("N2");
				txtPriceAverage.Text = newPrices.Average.ToString("N2");

				txtShift1.BackColor = txtShift1.BackColor;
				txtShift1.Text = newPrices.Shift.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift < 0)
					txtShift1.ForeColor = Color.Red;
				else if (newPrices.Shift > 0)
					txtShift1.ForeColor = Color.Green;

				txtShift3.BackColor = txtShift3.BackColor;
				txtShift3.Text = newPrices.Shift3.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift3 < 0)
					txtShift3.ForeColor = Color.Red;
				else if (newPrices.Shift3 > 0)
					txtShift3.ForeColor = Color.Green;

				txtShift7.BackColor = txtShift7.BackColor;
				txtShift7.Text = newPrices.Shift7.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift7 < 0)
					txtShift7.ForeColor = Color.Red;
				else if (newPrices.Shift7 > 0)
					txtShift7.ForeColor = Color.Green;

				txtShift30.BackColor = txtShift30.BackColor;
				txtShift30.Text = newPrices.Shift30.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift30 < 0)
					txtShift30.ForeColor = Color.Red;
				else if (newPrices.Shift30 > 0)
					txtShift30.ForeColor = Color.Green;

				txtShift90.BackColor = txtShift90.BackColor;
				txtShift90.Text = newPrices.Shift90.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift90 < 0)
					txtShift90.ForeColor = Color.Red;
				else if (newPrices.Shift90 > 0)
					txtShift90.ForeColor = Color.Green;

				txtShift180.BackColor = txtShift180.BackColor;
				txtShift180.Text = newPrices.Shift180.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift180 < 0)
					txtShift180.ForeColor = Color.Red;
				else if (newPrices.Shift180 > 0)
					txtShift180.ForeColor = Color.Green;

				txtShift365.BackColor = txtShift365.BackColor;
				txtShift365.Text = newPrices.Shift365.ToString("+0.00%;-0.00%;0.00%");
				if (newPrices.Shift365 < 0)
					txtShift365.ForeColor = Color.Red;
				else if (newPrices.Shift365 > 0)
					txtShift365.ForeColor = Color.Green;


				lblPriceLastUpdated.Text = newPrices.LastUpdate;
				lblPriceStatus.Visible = false;
			}
			else
			{
				lblPriceStatus.Text = "Error: Couldnt load price data (Server may be unavailable?)";
				txtPriceAverage.Enabled = false;
				txtPriceHigh.Enabled = false;
				txtPriceLow.Enabled = false;
				txtShift1.Enabled = false;
				txtShift180.Enabled = false;
				txtShift3.Enabled = false;
				txtShift30.Enabled = false;
				txtShift365.Enabled = false;
				txtShift7.Enabled = false;
				txtShift90.Enabled = false;
			}
		}

		private CardPrices LoadPricesFromWeb(Card currentCard)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(webPriceURL + currentCard.Code);
			httpWebRequest.Headers["X-Mashape-Key"] = mDB.GetSetting("mashape_api_key");
			httpWebRequest.ContentType = "application/json; charset=utf-8";
			HttpWebResponse webResponse = null;
			CardPrices newPrices = new CardPrices();
			string jsonResponse = "";
			try
			{
				webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				using (StreamReader stream = new StreamReader(webResponse.GetResponseStream()))
				{
					jsonResponse = stream.ReadToEnd();
				}
				if (webResponse.Headers["X-Ratelimit-Calls-Remaining"] != null)
				{
					if(Convert.ToInt32(webResponse.Headers["X-Ratelimit-Calls-Remaining"]) <= 100)
					{
						MessageBox.Show("WARNING: You have almost reached the API limit, you may be charged extra for each request over the limit.\nYou have " + webResponse.Headers["X-Ratelimit-Calls-Remaining"] + " requests remaining.", "API Request - Limit Almost Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message, "Error - Web Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return newPrices;
			}


			if(jsonResponse.Length > 0)
			{
				JObject o = JObject.Parse(jsonResponse);
				
				if((string)o["status"] == "success")
				{
					JToken p = o["data"]["price_data"];
					if ((string)p["price_data"]["status"] == "success")
					{
						newPrices.Status = true;
						JToken q = p["price_data"]["data"]["prices"];

						newPrices.High = Convert.ToDouble((string)q["high"]);
						newPrices.Low = Convert.ToDouble((string)q["low"]);
						newPrices.Average = Convert.ToDouble((string)q["average"]);
						newPrices.Shift = Convert.ToDouble((string)q["shift"]);
						newPrices.Shift3 = Convert.ToDouble((string)q["shift_3"]);
						newPrices.Shift7 = Convert.ToDouble((string)q["shift_7"]);
						newPrices.Shift30 = Convert.ToDouble((string)q["shift_30"]);
						newPrices.Shift90 = Convert.ToDouble((string)q["shift_90"]);
						newPrices.Shift180 = Convert.ToDouble((string)q["shift_180"]);
						newPrices.Shift365 = Convert.ToDouble((string)q["shift_365"]);
						newPrices.LastUpdate = (string)q["updated_at"];
					}
					else
					{
						newPrices.Status = false;
					}
				}
				else
				{
					newPrices.Status = false;
				}
			}
			else
			{
				newPrices.Status = false;
			}

			return newPrices;
		}

		private void LoadPrices(Card currentCard)
		{
			priceLoaderWorker = new BackgroundWorker();
			priceLoaderWorker.WorkerReportsProgress = false;
			priceLoaderWorker.DoWork += DoLoadPricesWork;
			priceLoaderWorker.RunWorkerCompleted += LoadPricesWorkCompleted;

			if (mDB.GetSetting("mashape_api_key").Length > 0)
				priceLoaderWorker.RunWorkerAsync(currentCard);
			else
				lblPriceStatus.Text = "Error: No API key set, could not retrieve prices.";
		}
		#endregion
		
		public frmViewCard(DatabaseManager _db, int _cardID, bool isWebID)
		{
			InitializeComponent();
			this.mDB = _db;
			this.cardID = _cardID;
			if (cardID != 0 && mDB != null)
			{
				currentCard = mDB.FindCardByID(cardID);
				currentSet = mDB.FindBundleByID(currentCard.SetWebID, true);
				LoadPrices(currentCard);
			}
		}

		private void frmViewCard_Load(object sender, EventArgs e)
		{
			lblPriceStatus.BringToFront();
			lblSimilarCardStatus.BringToFront();

			this.Text = "View Card - " + currentCard.Name;
			lblCardName.Text = currentCard.Name;
			lblCardType.Text = currentCard.Type.ToString() + " Card";
			lnklblSetLink.Text = currentSet.Name;
			txtDescription.Text = currentCard.Description.Replace("\n", Environment.NewLine);
			if (currentCard.Rarity == CardRarity.GoldRare || currentCard.Rarity == CardRarity.Rare || currentCard.Rarity == CardRarity.SecretRare || currentCard.Rarity == CardRarity.SuperRare || currentCard.Rarity == CardRarity.UltraRare)
				lblRarityText.Text = Tracker.AddSpacesToSentence(currentCard.Rarity.ToString(), false);
			else if (currentCard.Rarity == CardRarity.Normal)
				lblRarityText.Text = "Common";
			else
				lblRarityText.Text = Tracker.AddSpacesToSentence(currentCard.Rarity.ToString(), false) + " Rare";

			lblCardCode.Text = currentCard.Code;

			if (currentCard.Status != CardStatus.Normal)
			{
				lblBannedText.Text = Tracker.AddSpacesToSentence(currentCard.Status.ToString(), false);

				if (currentCard.Status == CardStatus.Forbidden)
				{
					lblBannedText.BackColor = Color.Red;
					lblBannedText.ForeColor = Color.White;
				}
				else if (currentCard.Status == CardStatus.Limited)
					lblBannedText.BackColor = Color.Orange;
				else if (currentCard.Status == CardStatus.SemiLimited)
					lblBannedText.BackColor = Color.Yellow;

			}	
			else
				lblBannedText.Text = "";

			if (currentCard.Type == CardType.Monster)
			{
				lblLevelText.Text = currentCard.Level.ToString();
				txtAttribute.Text = currentCard.Attribute.ToString().ToUpper();
				txtCardSubtype.Text = currentCard.MonsterType.ToUpper() + "/";

				if (currentCard.SubType == CardSubType.None)
					txtCardSubtype.Text += "NORMAL";
				else
					txtCardSubtype.Text += currentCard.SubType.ToString().ToUpper();

				if (currentCard.SubType.ToString().Equals("xyz", StringComparison.CurrentCultureIgnoreCase))
				{
					lblLevel.Text = "Rank:";
					pbIcon.Image = Image.FromFile("Assets/Images/rank.png");
				}

				txtATK.Text = currentCard.Attack;
				txtDEF.Text = currentCard.Defence;
			}
			else
			{
				lblLevel.Text = "Type:";
				lblLevelText.Text = Tracker.AddSpacesToSentence(currentCard.ST_Icon.ToString(), false);

				lblATK.Visible = false;
				lblDEF.Visible = false;
				lblAttribute.Visible = false;
				txtATK.Visible = false;
				txtDEF.Visible = false;
				txtAttribute.Visible = false;

				txtCardSubtype.Text = currentCard.ST_Icon.ToString() + " " + currentCard.Type.ToString();

				if (currentCard.ST_Icon == CardIcon.None)
				{
					pbIcon.Visible = false;
				}
				else
				{
					if (File.Exists(Tracker.CardIconDir + currentCard.ST_Icon.ToString() + ".png"))
					{
						pbIcon.Image = Image.FromFile(Tracker.CardIconDir + currentCard.ST_Icon.ToString() + ".png");
					}
					else
					{
						pbIcon.Visible = false;
					}
				}
			}

			SortCardImages(currentCard.ID);

			if (currentCard.Level == 0 && currentCard.Type == CardType.Monster)
			{
				pbIcon.Visible = false;
			}
			else
			{
				for (int i = 1; i < currentCard.Level; i++)
				{
					PictureBox tmpCardStar = new PictureBox();
					tmpCardStar.SizeMode = PictureBoxSizeMode.AutoSize;
					tmpCardStar.BackColor = Color.Black;
					tmpCardStar.Image = pbIcon.Image;
					tmpCardStar.Top = pbIcon.Top;
					tmpCardStar.Size = pbIcon.Size;
					tmpCardStar.BackColor = pbIcon.BackColor;
					tmpCardStar.Margin = pbIcon.Margin;
					tmpCardStar.Padding = pbIcon.Padding;
					tmpCardStar.Visible = true;
					tmpCardStar.Location = new Point((pbIcon.Location.X + (19 * i)) + 12, pbIcon.Location.Y + 12);
					Controls.Add(tmpCardStar);
					tmpCardStar.BringToFront();
					tmpCardStar.Show();
				}
			}

			if (totalCardImages > 1)
			{
				btnNextImage.Enabled = true;
				btnPrevImage.Enabled = true;
			}

			DataTable similarCards = this.mDB.FindAllCardsByIDDT(currentCard.ID, true);
			if(similarCards != null)
			{
				dgvCardList.DataSource = similarCards;
				lblSimilarCardStatus.Visible = false;
				dgvCardList.Columns["code"].HeaderText = "Card Code";

				dgvCardList.Columns["name"].HeaderText = "Name";
				dgvCardList.Columns["rarity"].HeaderText = "Rarity";
				dgvCardList.Columns["status"].HeaderText = "Status";

				dgvCardList.Columns["code"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
				dgvCardList.Columns["rarity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				dgvCardList.Columns["status"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				dgvCardList.Columns["id"].Visible = false;

				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Forbidden")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Red);
				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (1 card)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Orange);
				dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["status"].Value.ToString().Equals("Limited (2 cards)")).ToList().ForEach(f => f.DefaultCellStyle.BackColor = Color.Yellow);
                dgvCardList.Rows.Cast<DataGridViewRow>().Where(w => w.Cells["code"].Value.ToString().Equals(currentCard.Code) && w.Cells["rarity"].Value.ToString().Equals(lblRarityText.Text)).ToList().ForEach(f => f.Visible = false);
                
                lblSimilarCardCount.Text = dgvCardList.RowCount.ToString() + " similar cards";
			}
			else
			{
				lblSimilarCardStatus.Text = "No Similar Cards Found";
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnPrevImage_Click(object sender, EventArgs e)
		{
			if(totalCardImages > 0)
			{
				if ((currentCardImageIndex - 1) >= 0)
				{
					currentCardImageIndex -= 1;
				}
				else
				{
					currentCardImageIndex = (cardImages.Length - 1);
				}
			}

			SetCardView(currentCardImageIndex);
		}

		private void btnNextImage_Click(object sender, EventArgs e)
		{
			if (totalCardImages > 0)
			{
				if ((currentCardImageIndex + 1) < cardImages.Length)
				{
					currentCardImageIndex += 1;
				}
				else
				{
					currentCardImageIndex = 0;
				}
			}

			SetCardView(currentCardImageIndex);
		}

		private void lnklblSetLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			lnklblSetLink.LinkVisited = true;
			frmViewSet SetViewForm = new frmViewSet(this.mDB, this.currentSet.WebID, true);
			SetViewForm.Show();
		}

		#region "Card List (DGV)"
		private void ViewCard(int rowIndex, ref DataGridView dgv)
		{
			if (rowIndex >= 0 && rowIndex < dgv.RowCount)
			{
				dgv.Rows[rowIndex].Selected = true;
				if (dgv.Columns["id"] != null)
				{
					int cardID = Convert.ToInt32(dgv.Rows[rowIndex].Cells["id"].Value.ToString());
					frmViewCard CardViewForm = new frmViewCard(this.mDB, cardID, false);
					CardViewForm.Show();
				}
			}

		}

		private void dgvCardList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			ViewCard(e.RowIndex, ref dgvCardList);
		}

		private void dgvCardList_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				int currentMouseOverRow = dgvCardList.HitTest(e.X, e.Y).RowIndex;
				if (currentMouseOverRow >= 0)
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
			
		}
		#endregion
	}
}
