using System.ServiceModel;

namespace ApplicationWebService {
	[ServiceContract]
	interface IApplicationWebServiceContract {
		[OperationContract]
		byte[] AuthenticateApplication(byte[] data);

		[OperationContract]
		byte[] GetConfigurationData(byte[] data);

		[OperationContract]
		byte[] GetMaps(byte[] data);
	}
}
