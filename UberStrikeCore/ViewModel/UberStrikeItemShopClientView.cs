using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class UberStrikeItemShopClientView {
		public List<UberStrikeItemFunctionalView> FunctionalItems {
			get;
			set;
		}

		public List<UberStrikeItemGearView> GearItems {
			get;
			set;
		}

		public List<UberStrikeItemQuickView> QuickItems {
			get;
			set;
		}

		public List<UberStrikeItemWeaponView> WeaponItems {
			get;
			set;
		}
	}
}
