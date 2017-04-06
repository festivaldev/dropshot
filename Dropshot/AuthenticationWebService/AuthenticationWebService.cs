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
using Newtonsoft.Json;

namespace AuthenticationWebService {
	public class AuthenticationWebService : IAuthenticationWebServiceContract {
		public byte[] LoginSteam(byte[] data) {
			MemoryStream inputStream = new MemoryStream(data);

			string steamId = StringProxy.Deserialize(inputStream);
			string authToken = StringProxy.Deserialize(inputStream);
			string machineId = StringProxy.Deserialize(inputStream);

			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\playerdata.json"));
			Dictionary<String, MemberView> userData = JsonConvert.DeserializeObject<Dictionary<String, MemberView>>(json);

			MemoryStream outputStream = new MemoryStream();

			if (userData[steamId] != null) {
				MemberAuthenticationResultView instance = new MemberAuthenticationResultView() {
					MemberAuthenticationResult = MemberAuthenticationResult.Ok,
					MemberView = userData[steamId],
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
					AuthToken = Convert.ToBase64String(Encoding.UTF8.GetBytes(steamId))
				};

				MemberAuthenticationResultViewProxy.Serialize(outputStream, instance);
			}
			

			return outputStream.ToArray();
		}
	}
}
