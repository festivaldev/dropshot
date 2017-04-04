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

namespace ShopWebService {
	[ServiceBehavior]
	public class ShopWebService : IShopWebServiceContract {
		public byte[] GetShop(byte[] data) {
			MemoryStream outputStream = new MemoryStream();
			UberStrikeItemShopClientView instance = new UberStrikeItemShopClientView() {
				FunctionalItems = new List<UberStrikeItemFunctionalView>(),
				GearItems = new List<UberStrikeItemGearView>(),
				QuickItems = new List<UberStrikeItemQuickView>(),
				WeaponItems = new List<UberStrikeItemWeaponView>() {
					new UberStrikeItemWeaponView() {
						Name = "Fucking Machine Gun",
						ItemClass = UberstrikeItemClass.WeaponMachinegun,
						ID = 6357090,
						Tier = 1,
						HasAutomaticFire = true,
						CriticalStrikeBonus = 1000,
						WeaponSecondaryAction = 2,
						SecondaryActionReticle = 0,
						CombatRange = 1,
						RecoilMovement = 500,
						RateOfFire = 100,
						ProjectileSpeed = 1,
						ProjectilesPerShot = 1,
						MaxAmmo = 1000000,
						StartAmmo = 1000000,
						PrefabName = "MachineGun",
						LevelLock = 0,
						ItemProperties = new Dictionary<ItemPropertyType, int>(),
						ShopHighlightType = ItemShopHighlightType.Popular,
						CustomProperties = new Dictionary<string, string>(),
						Prices = new List<ItemPrice>() {
							new ItemPrice() {
								Price = 0,
								Currency = UberStrikeCurrencyType.Points,
								Amount = 1,
								Duration = BuyingDurationType.Permanent
							}
						}
					}
				}
			};
			UberStrikeItemShopClientViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
