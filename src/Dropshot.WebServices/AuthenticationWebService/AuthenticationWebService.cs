using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using Newtonsoft.Json;
using UberStrike.Core.Serialization;
using UberStrike.Core.ViewModel;
using UberStrike.DataCenter.Common.Entities;

namespace Dropshot.WebServices {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class AuthenticationWebService : IAuthenticationWebServiceContract {
		private readonly string playerStatisticsPath = Path.Combine(Environment.CurrentDirectory, @"Data\PlayerStatistics.json");
		private readonly string userDataPath = Path.Combine(Environment.CurrentDirectory, @"Data\PlayerData.json");
		private readonly Dictionary<string, PlayerStatisticsView> playerStatistics;

		private readonly Dictionary<string, MemberView> userData;

		public AuthenticationWebService() {
			Console.Write("Initializing AuthenticationWebService...\t");

			if (!File.Exists(userDataPath)) {
				File.WriteAllText(userDataPath, "{}");
			}
			userData = JsonConvert.DeserializeObject<Dictionary<string, MemberView>>(File.ReadAllText(userDataPath));

			if (!File.Exists(playerStatisticsPath)) {
				File.WriteAllText(playerStatisticsPath, "{}");
			}
			playerStatistics = JsonConvert.DeserializeObject<Dictionary<string, PlayerStatisticsView>>(File.ReadAllText(playerStatisticsPath));
		}

		public byte[] CreateUser(byte[] data) {
			return new byte[] { };
		}

		public byte[] CompleteAccount(byte[] data) {
			return new byte[] { };
		}

		public byte[] LoginMemberEmail(byte[] data) {
			return new byte[] { };
		}

		public byte[] LoginMemberFacebookUnitySdk(byte[] data) {
			return new byte[] { };
		}

		public byte[] LoginSteam(byte[] data) {
			var inputStream = new MemoryStream(data);

			var steamId = StringProxy.Deserialize(inputStream);
			var authToken = StringProxy.Deserialize(inputStream);
			var machineId = StringProxy.Deserialize(inputStream);

			var outputStream = new MemoryStream();

			if (userData.ContainsKey(steamId) && userData[steamId] != null) {
				var instance = new MemberAuthenticationResultView {
					MemberAuthenticationResult = MemberAuthenticationResult.Ok,
					MemberView = userData[steamId],
					PlayerStatisticsView = playerStatistics[steamId],
					ServerTime = DateTime.Now,
					IsAccountComplete = true,
					AuthToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(steamId))
				};

				MemberAuthenticationResultViewProxy.Serialize(outputStream, instance);
			} else {
				var r = new Random((int) DateTime.Now.Ticks);
				var Cmid = r.Next(1000000, 9999999);

				var newMemberView = new MemberView {
					PublicProfile = new PublicProfileView {
						Cmid = Cmid,
						Name = "Player Name",
						IsChatDisabled = false,
						AccessLevel = MemberAccessLevel.Default,
						GroupTag = "",
						LastLoginDate = DateTime.Now,
						EmailAddressStatus = EmailAddressStatus.Verified,
						FacebookId = "-1"
					},
					MemberWallet = new MemberWalletView {
						Cmid = Cmid,
						Credits = 2000,
						Points = 2000
					}
				};

				var newPlayerStatisticsView = new PlayerStatisticsView {
					Cmid = Cmid,
					PersonalRecord = new PlayerPersonalRecordStatisticsView(),
					WeaponStatistics = new PlayerWeaponStatisticsView()
				};

				var instance = new MemberAuthenticationResultView {
					MemberAuthenticationResult = MemberAuthenticationResult.Ok,
					MemberView = newMemberView,
					PlayerStatisticsView = newPlayerStatisticsView,
					ServerTime = DateTime.Now,
					IsAccountComplete = true,
					AuthToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(steamId))
				};

				userData[steamId] = newMemberView;
				playerStatistics[steamId] = newPlayerStatisticsView;

				MemberAuthenticationResultViewProxy.Serialize(outputStream, instance);

				UpdatePlayerData();
			}

			return outputStream.ToArray();
		}

		public byte[] LoginMemberPortal(byte[] data) {
			return new byte[] { };
		}

		public byte[] LinkSteamMember(byte[] data) {
			return new byte[] { };
		}

		private void UpdatePlayerData() {
			var userDataText = JsonConvert.SerializeObject(userData);
			var playerStatisticsText = JsonConvert.SerializeObject(playerStatistics);

			File.WriteAllText(userDataPath, userDataText);
			File.WriteAllText(playerStatisticsPath, playerStatisticsText);
		}
	}
}