using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class UberStrikeItemGearView : BaseUberStrikeItemView {
		public override UberstrikeItemType ItemType {
			get {
				return UberstrikeItemType.Gear;
			}
		}

		public int ArmorPoints {
			get;
			set;
		}

		public int ArmorWeight {
			get;
			set;
		}
	}
}
