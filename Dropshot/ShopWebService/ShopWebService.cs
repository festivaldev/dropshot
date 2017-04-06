using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;
using Cmune.DataCenter.Common.Entities;
using Newtonsoft.Json;

namespace ShopWebService {
	[ServiceBehavior]
	public class ShopWebService : IShopWebServiceContract {
		public byte[] GetShop(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\shop.json"));

			UberStrikeItemShopClientView instance = JsonConvert.DeserializeObject<UberStrikeItemShopClientView>(json);
			UberStrikeItemShopClientViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
