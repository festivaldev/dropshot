using System.ServiceModel;

namespace ApplicationWebService {
	[ServiceContract]
	interface IApplicationWebServiceContract {
		[OperationContract]
		byte[] GetConfigurationData(byte[] data);
	}
}
