using System.ServiceModel;

namespace AuthenticationWebService {
	[ServiceContract]
	public interface IAuthenticationWebServiceContract {
		[OperationContract]
		byte[] LoginSteam(byte[] data);
	}
}
