using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using Newtonsoft.Json;
using UberStrike.Core.Serialization;
using UberStrike.Core.ViewModel;
using UberStrike.DataCenter.Common.Entities;

namespace DropshotServer {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class UserWebService : IUserWebServiceContract {
		private readonly string inventoryDataPath = Path.Combine(Environment.CurrentDirectory, @"Data\Inventory.json");
		private readonly string loadoutDataPath = Path.Combine(Environment.CurrentDirectory, @"Data\Loadout.json");
		private readonly string playerDataPath = Path.Combine(Environment.CurrentDirectory, @"Data\PlayerData.json");

		private readonly Dictionary<string, List<ItemInventoryView>> inventoryData;
		private readonly Dictionary<string, LoadoutView> loadoutData;

		public UserWebService() {
			Console.Write("Initializing UserWebService...\t\t\t");

			if (!File.Exists(inventoryDataPath)) {
				File.WriteAllText(inventoryDataPath, "{}");
			}
			inventoryData = JsonConvert.DeserializeObject<Dictionary<string, List<ItemInventoryView>>>(File.ReadAllText(inventoryDataPath));

			if (!File.Exists(loadoutDataPath)) {
				File.WriteAllText(loadoutDataPath, "{}");
			}
			loadoutData = JsonConvert.DeserializeObject<Dictionary<string, LoadoutView>>(File.ReadAllText(loadoutDataPath));
		}

		private void UpdateInventoryData() {
			var inventoryDataText = JsonConvert.SerializeObject(inventoryData);
			var loadoutDataText = JsonConvert.SerializeObject(loadoutData);

			File.WriteAllText(inventoryDataPath, inventoryDataText);
			File.WriteAllText(loadoutDataPath, loadoutDataText);
		}

		#region ApplicationWebService

		public byte[] ChangeMemberName(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] IsDuplicateMemberName(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GenerateNonDuplicateMemberNames(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetMemberWallet(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetInventory(byte[] data) {
			var inputStream = new MemoryStream(data);
			var steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));

			List<ItemInventoryView> instance = null;
			if (inventoryData.ContainsKey(steamId) && inventoryData[steamId] != null) {
				instance = inventoryData[steamId];
			} else {
				instance = new List<ItemInventoryView> {
					new ItemInventoryView {
						ItemId = 1,
						AmountRemaining = -1
					},
					new ItemInventoryView {
						ItemId = 12,
						AmountRemaining = -1
					}
				};

				inventoryData[steamId] = instance;
				UpdateInventoryData();
			}

			var outputStream = new MemoryStream();
			ListProxy<ItemInventoryView>.Serialize(outputStream, instance, ItemInventoryViewProxy.Serialize);

			return outputStream.ToArray();
		}

		public byte[] GetCurrentDeposits(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetItemTransactions(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetPointsDeposits(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetLoadout(byte[] data) {
			var inputStream = new MemoryStream(data);
			var steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));

			LoadoutView instance = null;
			if (loadoutData.ContainsKey(steamId) && loadoutData[steamId] != null) {
				instance = loadoutData[steamId];
			} else {
				instance = new LoadoutView {
					MeleeWeapon = 1,
					Weapon1 = 12
				};

				loadoutData[steamId] = instance;
				UpdateInventoryData();
			}

			var outputStream = new MemoryStream();
			LoadoutViewProxy.Serialize(outputStream, instance);

			return outputStream.ToArray();
		}

		public byte[] SetLoadout(byte[] data) {
			var inputStream = new MemoryStream(data);
			var steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));
			var loadoutView = LoadoutViewProxy.Deserialize(inputStream);

			var outputStream = new MemoryStream();

			if (loadoutData.ContainsKey(steamId) && loadoutData[steamId] != null) {
				loadoutData[steamId] = loadoutView;

				UpdateInventoryData();

				Int32Proxy.Serialize(outputStream, (int) MemberOperationResult.Ok);
			} else {
				Int32Proxy.Serialize(outputStream, (int) MemberOperationResult.MemberNotFound);
			}

			return outputStream.ToArray();
		}

		public byte[] GetMember(byte[] data) {
			var inputStream = new MemoryStream(data);
			var steamId = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));

			var json = File.ReadAllText(playerDataPath);
			var userData = JsonConvert.DeserializeObject<Dictionary<string, MemberView>>(json);

			var outputStream = new MemoryStream();

			if (userData[steamId] != null) {
				var instance = new UberstrikeUserViewModel {
					CmuneMemberView = userData[steamId],
					UberstrikeMemberView = new UberstrikeMemberView()
				};

				UberstrikeUserViewModelProxy.Serialize(outputStream, instance);
			}

			return outputStream.ToArray();
		}

		public byte[] GetMemberSessionData(byte[] data) {
			return new MemoryStream().ToArray();
		}

		public byte[] GetMemberListSessionData(byte[] data) {
			return new MemoryStream().ToArray();
		}

		#endregion
	}
}