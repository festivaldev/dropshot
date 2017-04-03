using System;
using System.ServiceModel;
using System.IO;
using System.Collections.Generic;
using UberStrike.Core.ViewModel;
using UberStrike.Core.Serialization;
using UberStrike.Core.Entities;

namespace ApplicationWebService {
	[ServiceBehavior]
	public class ApplicationWebService : IApplicationWebServiceContract {
		public byte[] AuthenticateApplication(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			AuthenticateApplicationView instance = new AuthenticateApplicationView() {
				CommServer = new PhotonView() {
					IP = "127.0.0.1",
					MinLatency = 1000,
					Name = "EU West",
					PhotonId = 743958298,
					Port = 80,
					Region = RegionType.EuWest,
					UsageType = PhotonUsageType.CommServer
				},
				EncryptionInitVector = "032847tw8ehufiiuhaer",
				EncryptionPassPhrase = "gldjjofsdsdj2i0ß9",
				GameServers = new List<PhotonView>(),
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
					{1, 10 },
					{2, 10 },
					{3, 10 },
					{4, 10 },
					{5, 10 },
					{6, 10 },
					{7, 10 },
					{8, 10 },
					{9, 10 },
					{10, 10 }

				}
			};
			ApplicationConfigurationViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] GetMaps(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			List<MapView> instance = new List<MapView>() {
				new MapView() {
					MapId = 0,
					DisplayName = "The Warehouse",
					Description = "Example Description",
					SceneName = "TheWarehouse",
					IsBlueBox = false,
					RecommendedItemId = -1,
					SupportedGameModes = 1,
					SupportedItemClass = 1,
					MaxPlayers = 32,
					Settings = new Dictionary<GameModeType, MapSettings>() {
						{GameModeType.TeamDeathMatch, new MapSettings() }
					}
				}
			};
			ListProxy<MapView>.Serialize(outputStream, instance, new ListProxy<MapView>.Serializer<MapView>(MapViewProxy.Serialize));

			return outputStream.ToArray();
		}
	}
}
