using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace AuthenticationWebService {
	[ServiceContract]
	public interface IAuthenticationWebServiceContract {
		[OperationContract]
		byte[] LoginSteam(byte[] data);
	}
}
