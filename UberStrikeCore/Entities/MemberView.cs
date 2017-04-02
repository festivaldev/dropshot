using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.Entities {
	public class MemberView {
		public PublicProfileView PublicProfile {
			get;
			set;
		}

		public MemberWalletView MemberWallet {
			get;
			set;
		}

		public List<int> MemberItems {
			get;
			set;
		}

		public MemberView() {
			this.PublicProfile = new PublicProfileView();
			this.MemberWallet = new MemberWalletView();
			this.MemberItems = new List<int>(0);
		}

		public MemberView(PublicProfileView publicProfile, MemberWalletView memberWallet, List<int> memberItems) {
			this.PublicProfile = publicProfile;
			this.MemberWallet = memberWallet;
			this.MemberItems = memberItems;
		}

		public override string ToString() {
			StringBuilder stringBuilder = new StringBuilder("[Member view: ");
			if (this.PublicProfile != null && this.MemberWallet != null) {
				stringBuilder.Append(this.PublicProfile);
				stringBuilder.Append(this.MemberWallet);
				stringBuilder.Append("[items: ");
				if (this.MemberItems != null && this.MemberItems.Count > 0) {
					int num = this.MemberItems.Count;
					foreach (int current in this.MemberItems) {
						stringBuilder.Append(current);
						if (--num > 0) {
							stringBuilder.Append(", ");
						}
					}
				} else {
					stringBuilder.Append("No items");
				}
				stringBuilder.Append("]");
			} else {
				stringBuilder.Append("No member");
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}
	}
}
