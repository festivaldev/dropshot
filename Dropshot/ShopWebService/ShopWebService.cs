using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;

namespace ShopWebService {
	[ServiceBehavior]
	public class ShopWebService : IShopWebServiceContract {
		public byte[] GetShop(byte[] data) {
			MemoryStream outputStream = new MemoryStream();
			UberStrikeItemShopClientView instance = new UberStrikeItemShopClientView() {
				FunctionalItems = new List<UberStrikeItemFunctionalView>() {
					new UberStrikeItemFunctionalView() {
						ID = 3407969,
						Name = "Test 1",
						Description = "Test Description"
					}
				},
				GearItems = new List<UberStrikeItemGearView>(),
				QuickItems = new List<UberStrikeItemQuickView>(),
				WeaponItems = new List<UberStrikeItemWeaponView>()
			};
			UberStrikeItemShopClientViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
