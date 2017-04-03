using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class UberStrikeItemFunctionalView : BaseUberStrikeItemView {
		public override UberstrikeItemType ItemType {
			get {
				return UberstrikeItemType.Functional;
			}
		}
	}
}
