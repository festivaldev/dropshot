using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;

namespace RelationshipWebService {
	[ServiceBehavior]
	class RelationshipWebService : IRelationshipWebServiceContract {
		public byte[] GetContactsByGroups(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			return outputStream.ToArray();
		}
	}
}
