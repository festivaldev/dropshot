using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UberStrike.Core.Entities {
	[Serializable]
	public class PlayerPersonalRecordStatisticsView {
		public int MostHeadshots {
			get;
			set;
		}

		public int MostNutshots {
			get;
			set;
		}

		public int MostConsecutiveSnipes {
			get;
			set;
		}

		public int MostXPEarned {
			get;
			set;
		}

		public int MostSplats {
			get;
			set;
		}

		public int MostDamageDealt {
			get;
			set;
		}

		public int MostDamageReceived {
			get;
			set;
		}

		public int MostArmorPickedUp {
			get;
			set;
		}

		public int MostHealthPickedUp {
			get;
			set;
		}

		public int MostMeleeSplats {
			get;
			set;
		}

		public int MostMachinegunSplats {
			get;
			set;
		}

		public int MostShotgunSplats {
			get;
			set;
		}

		public int MostSniperSplats {
			get;
			set;
		}

		public int MostSplattergunSplats {
			get;
			set;
		}

		public int MostCannonSplats {
			get;
			set;
		}

		public int MostLauncherSplats {
			get;
			set;
		}

		public PlayerPersonalRecordStatisticsView() {
		}

		public PlayerPersonalRecordStatisticsView(int mostHeadshots, int mostNutshots, int mostConsecutiveSnipes, int mostXPEarned, int mostSplats, int mostDamageDealt, int mostDamageReceived, int mostArmorPickedUp, int mostHealthPickedUp, int mostMeleeSplats, int mostMachinegunSplats, int mostShotgunSplats, int mostSniperSplats, int mostSplattergunSplats, int mostCannonSplats, int mostLauncherSplats) {
			this.MostArmorPickedUp = mostArmorPickedUp;
			this.MostCannonSplats = mostCannonSplats;
			this.MostConsecutiveSnipes = mostConsecutiveSnipes;
			this.MostDamageDealt = mostDamageDealt;
			this.MostDamageReceived = mostDamageReceived;
			this.MostHeadshots = mostHeadshots;
			this.MostHealthPickedUp = mostHealthPickedUp;
			this.MostLauncherSplats = mostLauncherSplats;
			this.MostMachinegunSplats = mostMachinegunSplats;
			this.MostMeleeSplats = mostMeleeSplats;
			this.MostNutshots = mostNutshots;
			this.MostShotgunSplats = mostShotgunSplats;
			this.MostSniperSplats = mostSniperSplats;
			this.MostSplats = mostSplats;
			this.MostSplattergunSplats = mostSplattergunSplats;
			this.MostXPEarned = mostXPEarned;
		}

		public override string ToString() {
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("[PlayerPersonalRecordStatisticsView: ");
			stringBuilder.Append("[MostArmorPickedUp: ");
			stringBuilder.Append(this.MostArmorPickedUp);
			stringBuilder.Append("][MostCannonSplats: ");
			stringBuilder.Append(this.MostCannonSplats);
			stringBuilder.Append("][MostConsecutiveSnipes: ");
			stringBuilder.Append(this.MostConsecutiveSnipes);
			stringBuilder.Append("][MostDamageDealt: ");
			stringBuilder.Append(this.MostDamageDealt);
			stringBuilder.Append("][MostDamageReceived: ");
			stringBuilder.Append(this.MostDamageReceived);
			stringBuilder.Append("][MostHeadshots: ");
			stringBuilder.Append(this.MostHeadshots);
			stringBuilder.Append("][MostHealthPickedUp: ");
			stringBuilder.Append(this.MostHealthPickedUp);
			stringBuilder.Append("][MostLauncherSplats: ");
			stringBuilder.Append(this.MostLauncherSplats);
			stringBuilder.Append("][MostMachinegunSplats: ");
			stringBuilder.Append(this.MostMachinegunSplats);
			stringBuilder.Append("][MostMeleeSplats: ");
			stringBuilder.Append(this.MostMeleeSplats);
			stringBuilder.Append("][MostNutshots: ");
			stringBuilder.Append(this.MostNutshots);
			stringBuilder.Append("][MostShotgunSplats: ");
			stringBuilder.Append(this.MostShotgunSplats);
			stringBuilder.Append("][MostSniperSplats: ");
			stringBuilder.Append(this.MostSniperSplats);
			stringBuilder.Append("][MostSplats: ");
			stringBuilder.Append(this.MostSplats);
			stringBuilder.Append("][MostSplattergunSplats: ");
			stringBuilder.Append(this.MostSplattergunSplats);
			stringBuilder.Append("][MostXPEarned: ");
			stringBuilder.Append(this.MostXPEarned);
			stringBuilder.Append("]]");
			return stringBuilder.ToString();
		}
	}
}
