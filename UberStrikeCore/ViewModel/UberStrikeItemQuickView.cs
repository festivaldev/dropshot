using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class UberStrikeItemQuickView : BaseUberStrikeItemView {
		public override UberstrikeItemType ItemType {
			get {
				return UberstrikeItemType.QuickUse;
			}
		}

		public int UsesPerLife {
			get;
			set;
		}

		public int UsesPerRound {
			get;
			set;
		}

		public int UsesPerGame {
			get;
			set;
		}

		public int CoolDownTime {
			get;
			set;
		}

		public int WarmUpTime {
			get;
			set;
		}

		public int MaxOwnableAmount {
			get;
			set;
		}

		public QuickItemLogic BehaviourType {
			get;
			set;
		}
	}
}
