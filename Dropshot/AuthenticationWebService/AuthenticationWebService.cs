using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using UberStrike.Core.ViewModel;
using UberStrike.Core.Serialization;
using UberStrike.DataCenter.Common.Entities;
using Cmune.DataCenter.Common.Entities;

namespace AuthenticationWebService {
	public class AuthenticationWebService : IAuthenticationWebServiceContract {
		public byte[] LoginSteam(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			MemberAuthenticationResultView instance = new MemberAuthenticationResultView() {
				MemberAuthenticationResult = MemberAuthenticationResult.Ok,
				MemberView = new MemberView() {
					PublicProfile = new PublicProfileView() {
						Cmid = 234789,
						Name = "Demo User",
						IsChatDisabled = false,
						AccessLevel = MemberAccessLevel.Admin,
						GroupTag = "DEMO",
						LastLoginDate = new DateTime(),
						EmailAddressStatus = EmailAddressStatus.Verified,
						FacebookId = "4"
					},
					MemberWallet = new MemberWalletView() {
						Cmid = 234789,
						Credits = 10000,
						Points = 10000,
						CreditsExpiration = DateTime.Today,
						PointsExpiration = DateTime.Today
					},
					MemberItems = new List<int>() {
						15,
						3342386,
						6684769,
						6357046,
						3407969,
						3145825,
						3539045,
						3145782,
						3735653,
						6684773,
						3276898,
						3211320,
						6553655,
						6684728,
						3407969,
						6357090,
						3473460,
						3407922,
						3276900,
						6488113,
						3407974,
						3735649,
						6422583,
						3539000,
						3145825,
						3604530,
						6684724,
						6357048
					}
				},
				PlayerStatisticsView = new PlayerStatisticsView() {
					Cmid = 234789,
					Splats = 100,
					Splatted = 0,
					Shots = 500,
					Hits = 500,
					Nutshots = 100,
					Xp = 1500,
					Level = 3,
					TimeSpentInGame = 100,
					PersonalRecord = new PlayerPersonalRecordStatisticsView() {
						MostHeadshots = 10,
						MostNutshots = 10,
						MostConsecutiveSnipes = 10,
						MostXPEarned = 150,
						MostSplats = 5,
						MostDamageDealt = 100,
						MostDamageReceived = 0,
						MostArmorPickedUp = 200,
						MostHealthPickedUp = 200,
						MostMeleeSplats = 5,
						MostMachinegunSplats = 5,
						MostShotgunSplats = 5,
						MostSniperSplats = 5,
						MostSplattergunSplats = 5,
						MostCannonSplats = 5,
						MostLauncherSplats = 5
					},
					WeaponStatistics = new PlayerWeaponStatisticsView()
				},
				ServerTime = DateTime.Now,
				IsAccountComplete = true,
				AuthToken = "WW91aGF2ZWJlZW5hdXRob3JpemVkdG9wbGF5dGhpc2dhbWU="
			};
			MemberAuthenticationResultViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
