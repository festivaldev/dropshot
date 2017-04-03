using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ShopWebService {
	[ServiceContract]
	public interface IShopWebServiceContract {
		[OperationContract]
		byte[] GetShop(byte[] data);
	}
}
