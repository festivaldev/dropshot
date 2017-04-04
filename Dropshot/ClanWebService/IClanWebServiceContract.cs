using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ClanWebService {
	[ServiceContract]
	public interface IClanWebServiceContract {
		[OperationContract]
		byte[] GetMyClanId(byte[] data);
	}
}
