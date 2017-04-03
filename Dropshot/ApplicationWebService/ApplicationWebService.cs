using System;
using System.ServiceModel;
using System.IO;
using System.Collections.Generic;
using UberStrike.Core.ViewModel;
using UberStrike.Core.Serialization;

namespace ApplicationWebService {
	[ServiceBehavior]
	public class ApplicationWebService : IApplicationWebServiceContract {
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
	}
}
