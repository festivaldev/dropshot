using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.IO;
using UberStrike.Core.Serialization;
using UberStrike.DataCenter.Common.Entities;
using UberStrike.Core.Types;
using UberStrike.Core.ViewModel;
using Cmune.DataCenter.Common.Entities;

namespace UserWebService {
	[ServiceBehavior]
	public class UserWebService : IUserWebServiceContract {
		public byte[] GetInventory(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			List<ItemInventoryView> instance = new List<ItemInventoryView>() {
				new ItemInventoryView() {
					Cmid = 234789,
					ItemId = 6357090,
					AmountRemaining = -1
				}
			};

			ListProxy<ItemInventoryView>.Serialize(outputStream, instance, new ListProxy<ItemInventoryView>.Serializer<ItemInventoryView>(ItemInventoryViewProxy.Serialize));

			return outputStream.ToArray();
		}

		public byte[] GetLoadout(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			LoadoutView instance = new LoadoutView() {
				Weapon1 = 6357090
			}/* {
				Backpack = 3342386,
				Boots = 6684769,
				Cmid = 234789,
				Face = 6357046,
				FunctionalItem1 = 3407969,
				FunctionalItem2 = 3145825,
				FunctionalItem3 = 3539045,
				Gloves = 3145782,
				Head = 3735653,
				LoadoutId = 3735607,
				LowerBody = 9,
				MeleeWeapon = 10,
				QuickItem1 = 11,
				QuickItem2 = 12,
				QuickItem3 = 12,
				Type = AvatarType.LolaAvatar,
				UpperBody = 14,
				Weapon1 = 15,
				Weapon1Mod1 = 16,
				Weapon1Mod2 = 17,
				Weapon1Mod3 = 18,
				Weapon2 = 19,
				Weapon2Mod1 = 20,
				Weapon2Mod2 = 21,
				Weapon2Mod3 = 22,
				Weapon3 = 23,
				Weapon3Mod1 = 24,
				Weapon3Mod2 = 25,
				Weapon3Mod3 = 26,
				Webbing = 27,
			}*/;

			LoadoutViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] GetMember(byte[] data) {
			MemoryStream outputStream = new MemoryStream();

			UberstrikeUserViewModel instance = new UberstrikeUserViewModel() {
				CmuneMemberView = new MemberView() {
					PublicProfile = new PublicProfileView() {
						Cmid = 234789,
						Name = "Demo User",
						IsChatDisabled = false,
						AccessLevel = MemberAccessLevel.SeniorQA,
						GroupTag = "DEMO",
						LastLoginDate = new DateTime(),
						EmailAddressStatus = EmailAddressStatus.Verified,
						FacebookId = "4"
					},
					MemberWallet = new MemberWalletView() {
						Cmid = 234789,
						Credits = 10000,
						Points = 10000,
						CreditsExpiration = DateTime.Today,
						PointsExpiration = DateTime.Today
					},
					MemberItems = new List<int>() {
						3342386,
						6684769,
						6357046,
						3407969,
						3145825,
						3539045,
						3145782,
						3735653,
						6684773,
						3276898,
						3211320,
						6553655,
						6684728,
						3407969,
						6357090,
						3473460,
						3407922,
						3276900,
						6488113,
						3407974,
						3735649,
						6422583,
						3539000,
						3145825,
						3604530,
						6684724,
						6357048
					}
				},
				UberstrikeMemberView = new UberstrikeMemberView() {

				}
			};

			UberstrikeUserViewModelProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}
	}
}
