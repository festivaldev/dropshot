using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using UberStrike.DataCenter.Common.Entities;
using UberStrike.Core.Serialization;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Types;
using Cmune.Core.Models.Views;
using Cmune.DataCenter.Common.Entities;
using Newtonsoft.Json;

namespace ApplicationWebService {
	[ServiceBehavior]
	class ApplicationWebService : IApplicationWebServiceContract {
		public byte[] AuthenticateApplication(byte[] data) {
			MemoryStream outputStream = new MemoryStream();
			AuthenticateApplicationView instance = new AuthenticateApplicationView() {
				CommServer = new PhotonView() {
					IP = "127.0.0.1",
					MinLatency = 1000,
					Name = "EU West",
					PhotonId = 743958298,
					Port = 5055,
					Region = RegionType.EuWest,
					UsageType = PhotonUsageType.CommServer
				},
				EncryptionInitVector = "032847tw8ehufiiuhaer",
				EncryptionPassPhrase = "gldjjofsdsdj2i0ß9",
				GameServers = new List<PhotonView>() {
					new PhotonView() {
						PhotonId = 5982379,
						IP = "127.0.0.1",
						Name = "UberStrike Test Server",
						Region = RegionType.EuWest,
						Port = 5056,
						UsageType = PhotonUsageType.All,
						MinLatency = 1000
					}
				},
				IsEnabled = true,
				WarnPlayer = false
			};
			AuthenticateApplicationViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] GetConfigurationData(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			ApplicationConfigurationView instance = new ApplicationConfigurationView() {
				MaxLevel = 10,
				XpRequiredPerLevel = new Dictionary<int, int>() {
					{1, 1000 },
					{2, 2000 },
					{3, 3000 },
					{4, 4000 },
					{5, 5000 },
					{6, 6000 },
					{7, 7000 },
					{8, 8000 },
					{9, 9000 },
					{10, 10000 }

				}
			};

			ApplicationConfigurationViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] GetMaps(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\maps.json"));
			List<MapView> instance = JsonConvert.DeserializeObject<List<MapView>>(json);
			ListProxy<MapView>.Serialize(outputStream, instance, new ListProxy<MapView>.Serializer<MapView>(MapViewProxy.Serialize));

			return outputStream.ToArray();
		}
	}
}
