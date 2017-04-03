using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;	

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class ItemPrice {
		public int Price {
			get;
			set;
		}

		public UberStrikeCurrencyType Currency {
			get;
			set;
		}

		public int Discount {
			get;
			set;
		}

		public int Amount {
			get;
			set;
		}

		public PackType PackType {
			get;
			set;
		}

		public BuyingDurationType Duration {
			get;
			set;
		}

		public bool IsConsumable {
			get {
				return this.Amount > 0;
			}
		}
	}
}
