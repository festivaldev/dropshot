using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class MemberAuthenticationResultView {
		public MemberAuthenticationResult MemberAuthenticationResult {
			get;
			set;
		}

		public MemberView MemberView {
			get;
			set;
		}

		public PlayerStatisticsView PlayerStatisticsView {
			get;
			set;
		}

		public DateTime ServerTime {
			get;
			set;
		}

		public bool IsAccountComplete {
			get;
			set;
		}

		/*public LuckyDrawUnityView LuckyDraw {
			get;
			set;
		}*/

		public string AuthToken {
			get;
			set;
		}
	}
}
