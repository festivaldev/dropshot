using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace UserWebService {
	[ServiceContract]
	public interface IUserWebServiceContract {
		[OperationContract]
		byte[] GetInventory(byte[] data);

		[OperationContract]
		byte[] GetLoadout(byte[] data);

		[OperationContract]
		byte[] GetMember(byte[] data);
	}
}
