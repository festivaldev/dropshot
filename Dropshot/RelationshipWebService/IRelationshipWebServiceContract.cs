using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace RelationshipWebService {
	[ServiceContract]
	interface IRelationshipWebServiceContract {
		[OperationContract]
		byte[] GetContactsByGroups(byte[] data);
	}
}
