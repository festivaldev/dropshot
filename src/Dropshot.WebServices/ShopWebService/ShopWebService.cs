using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using Cmune.DataCenter.Common.Entities;
using Newtonsoft.Json;
using UberStrike.Core.Models.Views;
using UberStrike.Core.Serialization;
using UberStrike.Core.Types;

namespace Dropshot.WebServices {
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
	public class ShopWebService : IShopWebServiceContract {
		private readonly string inventoryDataPath = Path.Combine(Environment.CurrentDirectory, @"Data\Inventory.json");
		private readonly Dictionary<string, List<ItemInventoryView>> inventoryData;

		private readonly UberStrikeItemShopClientView shopData;

		public ShopWebService() {
			Console.Write("Initializing ShopWebService...\t\t\t");
			shopData = JsonConvert.DeserializeObject<UberStrikeItemShopClientView>(Program.LoadEmbeddedJson("Dropshot.WebServices.Data.Shop.json"));

			if (!File.Exists(inventoryDataPath)) {
				File.WriteAllText(inventoryDataPath, "{}");
			}
			inventoryData = JsonConvert.DeserializeObject<Dictionary<string, List<ItemInventoryView>>>(File.ReadAllText(inventoryDataPath));
		}

		private void UpdateInventoryData() {
			var inventoryDataText = JsonConvert.SerializeObject(inventoryData);

			File.WriteAllText(inventoryDataPath, inventoryDataText);
		}

		#region ShopWebService

		public byte[] GetShop(byte[] data) {
			var outputStream = new MemoryStream();

			UberStrikeItemShopClientViewProxy.Serialize(outputStream, shopData);

			return outputStream.ToArray();
		}

		public byte[] BuyItem(byte[] data) {
			var inputStream = new MemoryStream(data);
			var itemId = Int32Proxy.Deserialize(inputStream);
			var authToken = Encoding.UTF8.GetString(Convert.FromBase64String(StringProxy.Deserialize(inputStream)));
			var currencyType = EnumProxy<UberStrikeCurrencyType>.Deserialize(inputStream);
			var itemType = EnumProxy<UberstrikeItemType>.Deserialize(inputStream);
			var buyingLocationType = EnumProxy<BuyingLocationType>.Deserialize(inputStream);
			var buyingRecommendationType = EnumProxy<BuyingRecommendationType>.Deserialize(inputStream);

			var outputStream = new MemoryStream();
			if (inventoryData.ContainsKey(authToken)) {
				var item = new ItemInventoryView {
					ItemId = itemId,
					AmountRemaining = itemType != UberstrikeItemType.QuickUse ? -1 : 50
				};
				inventoryData[authToken].Add(item);

				UpdateInventoryData();

				Int32Proxy.Serialize(outputStream, (int) BuyItemResult.OK);
			} else {
				Int32Proxy.Serialize(outputStream, (int) BuyItemResult.InvalidMember);
			}

			return outputStream.ToArray();
		}

		public byte[] BuyPack(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetBundles(byte[] data) {
			return new byte[] { };
		}

		public byte[] BuyBundle(byte[] data) {
			return new byte[] { };
		}

		public byte[] BuyBundleSteam(byte[] data) {
			return new byte[] { };
		}

		public byte[] FinishBuyBundleSteam(byte[] data) {
			return new byte[] { };
		}

		public byte[] VerifyReceipt(byte[] data) {
			return new byte[] { };
		}

		public byte[] UseConsumableItem(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetAllMysteryBoxs_1(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetAllMysteryBoxs_2(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetMysteryBox(byte[] data) {
			return new byte[] { };
		}

		public byte[] RollMysteryBox(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetAllLuckyDraws_1(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetAllLuckyDraws_2(byte[] data) {
			return new byte[] { };
		}

		public byte[] GetLuckyDraw(byte[] data) {
			return new byte[] { };
		}

		public byte[] RollLuckyDraw(byte[] data) {
			return new byte[] { };
		}

		#endregion
	}
}