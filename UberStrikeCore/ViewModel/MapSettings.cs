using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class MapSettings {
		public int KillsMin {
			get;
			set;
		}

		public int KillsMax {
			get;
			set;
		}

		public int KillsCurrent {
			get;
			set;
		}

		public int PlayersMin {
			get;
			set;
		}

		public int PlayersMax {
			get;
			set;
		}

		public int PlayersCurrent {
			get;
			set;
		}

		public int TimeMin {
			get;
			set;
		}

		public int TimeMax {
			get;
			set;
		}

		public int TimeCurrent {
			get;
			set;
		}
	}
}
