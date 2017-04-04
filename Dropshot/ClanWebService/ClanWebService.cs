using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;
using UberStrike.Core.Serialization;

namespace ClanWebService {
	[ServiceBehavior]
	public class ClanWebService : IClanWebServiceContract {
		public byte[] GetMyClanId(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			Int32Proxy.Serialize(outputStream, -1);

			return outputStream.ToArray();
		}
	}
}
