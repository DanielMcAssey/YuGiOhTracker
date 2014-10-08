using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerSystem.CardData
{
	public struct CardBundle
	{
		public int WebID;
		public BundleType Type;
		public int Year;
		public string Name;
		public bool IsUpdated;
	}
}
