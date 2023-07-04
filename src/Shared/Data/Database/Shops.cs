using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	public enum PersonalShopType
	{
		// 4 (0 = Buff Shop, 2 = Repair Shop,3 = Gem Roasting, 5 = Food Table, 9 = Portal Shop, 10 = Item Awakening)
		NPC = -2,
		Personal = -1,
		Buff = 1,
		SpellShop = 0, // Not sure about this value
		Repair = 2,
		GemRoasting = 3,
		FoodTable = 5,
		Portal = 9,
		ItemAwakening = 10,
	}

	[Serializable]
	public class ShopData
	{
		public string Name { get; set; }
		public bool IsCustom { get; set; }
		public PersonalShopType Type { get; set; } = PersonalShopType.NPC;
		public Dictionary<int, ProductData> Products { get; set; } = new Dictionary<int, ProductData>();
		public int Level { get; set; }
		public int EffectId { get; set; } = 270065;
		public bool IsClosed { get; set; }

		public int SkillIcon
		{
			get
			{
				switch (Type)
				{
					case PersonalShopType.Buff:
						return 40805;
					case PersonalShopType.Repair:
						return 50301;
					case PersonalShopType.FoodTable:
						return 50304;
					case PersonalShopType.ItemAwakening:
						return 21007;
					default:
						return 0;
				}
			}
		}

		public ProductData GetProduct(int id)
		{
			this.Products.TryGetValue(id, out var product);
			return product;
		}
	}

	[Serializable]
	public class ProductData
	{
		public string ShopName { get; set; }
		public int Id { get; set; }
		public int ItemId { get; set; }
		public int Cost { get; set; }
		public float PriceMultiplier { get; set; }
		public int Amount { get; set; }
		public int RequiredAmount { get; set; }
	}

	/// <summary>
	/// Shop database, indexed by shop name.
	/// </summary>
	public class ShopDb : DatabaseJsonIndexed<string, ShopData>
	{
		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("shopName", "productId", "itemId", "amount", "priceMultiplier");

			var data = new ProductData();

			data.ShopName = entry.ReadString("shopName");
			data.Id = entry.ReadInt("productId");
			data.ItemId = entry.ReadInt("itemId");
			data.Cost = entry.ReadInt("amount");
			data.PriceMultiplier = entry.ReadFloat("priceMultiplier");

			if (!this.Entries.TryGetValue(data.ShopName, out var shopData))
			{
				shopData = new ShopData();
				shopData.Name = data.ShopName;

				this.AddOrReplace(data.ShopName, shopData);
			}

			shopData.Products[data.Id] = data;
		}
	}
}
