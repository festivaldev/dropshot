using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class ApplicationConfigurationView {
		public Dictionary<int, int> XpRequiredPerLevel {
			get;
			set;
		}

		public int MaxLevel {
			get;
			set;
		}

		public int MaxXp {
			get;
			set;
		}

		public int XpKill {
			get;
			set;
		}

		public int XpSmackdown {
			get;
			set;
		}

		public int XpHeadshot {
			get;
			set;
		}

		public int XpNutshot {
			get;
			set;
		}

		public int XpPerMinuteLoser {
			get;
			set;
		}

		public int XpPerMinuteWinner {
			get;
			set;
		}

		public int XpBaseLoser {
			get;
			set;
		}

		public int XpBaseWinner {
			get;
			set;
		}

		public int PointsKill {
			get;
			set;
		}

		public int PointsSmackdown {
			get;
			set;
		}

		public int PointsHeadshot {
			get;
			set;
		}

		public int PointsNutshot {
			get;
			set;
		}

		public int PointsPerMinuteLoser {
			get;
			set;
		}

		public int PointsPerMinuteWinner {
			get;
			set;
		}

		public int PointsBaseLoser {
			get;
			set;
		}

		public int PointsBaseWinner {
			get;
			set;
		}
	}
}
