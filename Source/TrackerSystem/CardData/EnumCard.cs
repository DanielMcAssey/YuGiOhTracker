using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerSystem.CardData
{
	public enum CardRarity
	{
		Normal,
		Rare,
		SuperRare,
		UltraRare,
		SecretRare,
		Ultimate,
		Holographic,
		GoldRare,
		GoldSecret
	}

	public enum CardStatus
	{
		Normal,
		Forbidden,
		Limited,
		SemiLimited
	}

	public enum CardType
	{
		Monster,
		Spell,
		Trap
	}

	public enum CardSubType
	{
		None,
		Normal,
		Effect,
		Ritual,
		Fusion,
		Synchro,
		Xyz,
		Toon,
		Spirit,
		Union,
		Gemini,
		Tuner,
		Flip,
		Pendulum
	}

	public enum CardAttribute
	{
		None,
		Dark,
		Light,
		Earth,
		Water,
		Fire,
		Wind,
		Divine
	}

	public enum CardIcon
	{
		None,
		Equip,
		Field,
		QuickPlay,
		Ritual,
		Continuous,
		Counter,
		Normal
	}
}
