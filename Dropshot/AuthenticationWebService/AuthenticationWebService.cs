using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using UberStrike.Core.ViewModel;
using UberStrike.Core.Entities;
using UberStrike.Core.Serialization;

namespace AuthenticationWebService {
	[ServiceBehavior]
	public class AuthenticationWebService : IAuthenticationWebServiceContract {
		public byte[] LoginSteam(byte[] data) {
			MemoryStream outputStream = new MemoryStream();
			MemberAuthenticationResultView instance = new MemberAuthenticationResultView() {
				MemberAuthenticationResult = MemberAuthenticationResult.Ok,
				MemberView = new MemberView() {
					PublicProfile = new PublicProfileView() {
						Cmid = 234789,
						Name = "UberStrike Demo User",
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
					MemberItems = new List<int>()
				},
				PlayerStatisticsView = new PlayerStatisticsView() {
					Cmid = 234789,
					Splats = 100,
					Splatted = 0,
					Shots = 500,
					Hits = 500,
					Nutshots = 100,
					Xp = 1000,
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
			/*MemberAuthenticationResultView instance = new MemberAuthenticationResultView() {
				AuthToken = "WW91aGF2ZWJlZW5hdXRob3JpemVkdG9wbGF5dGhpc2dhbWU=",
				IsAccountComplete = true,
				MemberAuthenticationResult = MemberAuthenticationResult.Ok,
				ServerTime = new DateTime(),
				MemberView = new MemberView(),
				PlayerStatisticsView = new PlayerStatisticsView()
			};*/

			MemberAuthenticationResultViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
