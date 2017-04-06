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
using Newtonsoft.Json;

namespace UserWebService {
	[ServiceBehavior]
	public class UserWebService : IUserWebServiceContract {
		public byte[] GetInventory(byte[] data) {
			MemoryStream inputStream = new MemoryStream(data);
			string steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));
			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\inventory.json"));

			Dictionary<String, List<ItemInventoryView>> userData = JsonConvert.DeserializeObject<Dictionary<String, List<ItemInventoryView>>>(json);

			List<ItemInventoryView> instance = null;
			if (userData.ContainsKey(steamId) && userData[steamId] != null) {
				instance = userData[steamId];
			} else {
				instance = new List<ItemInventoryView>() {
					new ItemInventoryView() {
						Cmid = 234789,
						ItemId = 1,
						AmountRemaining = -1
					},
					new ItemInventoryView() {
						Cmid = 234789,
						ItemId = 12,
						AmountRemaining = -1
					}
				};
			}

			MemoryStream outputStream = new MemoryStream();
			ListProxy<ItemInventoryView>.Serialize(outputStream, instance, new ListProxy<ItemInventoryView>.Serializer<ItemInventoryView>(ItemInventoryViewProxy.Serialize));

			return outputStream.ToArray();
		}

		public byte[] GetLoadout(byte[] data) {
			MemoryStream inputStream = new MemoryStream(data);
			string steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));
			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\loadout.json"));

			Dictionary<String, LoadoutView> userData = JsonConvert.DeserializeObject<Dictionary<String, LoadoutView>>(json);

			LoadoutView instance = null;
			if (userData.ContainsKey(steamId) && userData[steamId] != null) {
				instance = userData[steamId];
			} else {
				instance = new LoadoutView() {
					MeleeWeapon = 1,
					Weapon1 = 12,
					QuickItem1 = 2001
				};
			}

			MemoryStream outputStream = new MemoryStream();
			LoadoutViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] GetMember(byte[] data) {
			MemoryStream inputStream = new MemoryStream(data);
			string steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));

			string json = File.ReadAllText(Path.Combine(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath, @"data\playerdata.json"));
			Dictionary<String, MemberView> userData = JsonConvert.DeserializeObject<Dictionary<String, MemberView>>(json);

			MemoryStream outputStream = new MemoryStream();

			if (userData[steamId] != null) {
				UberstrikeUserViewModel instance = new UberstrikeUserViewModel() {
					CmuneMemberView = userData[steamId],
					UberstrikeMemberView = new UberstrikeMemberView()
				};

				UberstrikeUserViewModelProxy.Serialize(outputStream, instance);
			}


			return outputStream.ToArray();
		}
	}
}
