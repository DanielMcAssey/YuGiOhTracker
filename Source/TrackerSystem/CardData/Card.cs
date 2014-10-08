using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerSystem.CardData
{
	public struct Card
	{
		public int ID;
		public string Code;
		public string Name;
		public string Description;
		public int Level;
		public CardType Type;
		public CardSubType SubType;
		public CardAttribute Attribute;
		public CardIcon ST_Icon;
		public CardRarity Rarity;
		public CardStatus Status;
		public string MonsterType;
		public string Attack;
		public string Defence;
		public int SetWebID;
		public bool ImageDownloaded;
	}
}
