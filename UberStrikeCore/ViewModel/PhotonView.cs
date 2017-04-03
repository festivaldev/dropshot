using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UberStrike.Core.Entities;

namespace UberStrike.Core.ViewModel {
	[Serializable]
	public class PhotonView {
		public int PhotonId {
			get;
			set;
		}

		public string IP {
			get;
			set;
		}

		public string Name {
			get;
			set;
		}

		public RegionType Region {
			get;
			set;
		}

		public int Port {
			get;
			set;
		}

		public PhotonUsageType UsageType {
			get;
			set;
		}

		public int MinLatency {
			get;
			set;
		}
	}
}
