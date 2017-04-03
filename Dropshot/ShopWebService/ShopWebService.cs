using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ServiceModel;
using UberStrike.Core.ViewModel;
using UberStrike.Core.Serialization;
using UberStrike.Core.Entities;

namespace ShopWebService {
	[ServiceBehavior]
	public class ShopWebService : IShopWebServiceContract {
		public byte[] GetShop(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			UberStrikeItemShopClientView instance = new UberStrikeItemShopClientView() {
				FunctionalItems = new List<UberStrikeItemFunctionalView>() {
					new UberStrikeItemFunctionalView() {
						ID = 27890,
						Name = "Test",
						Description = "Item Description"
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
