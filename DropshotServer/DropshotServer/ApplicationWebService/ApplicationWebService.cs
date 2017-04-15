using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using Newtonsoft.Json;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;
using UberStrike.DataCenter.Common.Entities;

namespace DropshotServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ApplicationWebService : IApplicationWebServiceContract {
		private readonly ApplicationConfigurationView gameConfig;
		private readonly List<MapView> mapData;
		private readonly AuthenticateApplicationView photonServers;

		public ApplicationWebService() {
			Console.Write("Initializing ApplicationWebService...\t\t");

			photonServers = JsonConvert.DeserializeObject<AuthenticateApplicationView>(Program.LoadEmbeddedJson("DropshotServer.Data.PhotonServers.json"));
			gameConfig = JsonConvert.DeserializeObject<ApplicationConfigurationView>(Program.LoadEmbeddedJson("DropshotServer.Data.ApplicationConfiguration.json"));
			mapData = JsonConvert.DeserializeObject<List<MapView>>(Program.LoadEmbeddedJson("DropshotServer.Data.Maps.json"));
		}

		#region ApplicationWebService

		public byte[] AuthenticateApplication(byte[] data) {
			var outputStream = new MemoryStream();
			AuthenticateApplicationViewProxy.Serialize(outputStream, photonServers);

			return outputStream.ToArray();
		}

		public byte[] GetConfigurationData(byte[] data) {
			var outputStream = new MemoryStream();
			ApplicationConfigurationViewProxy.Serialize(outputStream, gameConfig);

			return outputStream.ToArray();
		}

		public byte[] GetMaps(byte[] data) {
			var outputStream = new MemoryStream();
			ListProxy<MapView>.Serialize(outputStream, mapData, MapViewProxy.Serialize);

			return outputStream.ToArray();
		}

		public byte[] SetMatchScore(byte[] data) {
			return new MemoryStream().ToArray();
		}

		#endregion
	}
}