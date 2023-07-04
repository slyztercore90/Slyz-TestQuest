using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class RecipeData
	{
		public int Id { get; set; }
		public string ClassName { get; set; }
		public string Item { get; set; }
		public int ItemAmount { get; set; }
		public Dictionary<string, int> RequiredItems { get; set; } = new Dictionary<string, int>();
	}

	/// <summary>
	/// Recipe database.
	/// </summary>
	public class RecipeDb : DatabaseJsonIndexed<int, RecipeData>
	{
		/// <summary>
		/// Returns data for the first recipe with the given class name,
		/// or null if none were found.
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public RecipeData Find(string className)
		{
			return this.Entries.Values.FirstOrDefault(a => a.ClassName == className);
		}

		/// <summary>
		/// Returns true for the first recipe with the given class name,
		/// or false if none were found.
		/// </summary>
		/// <param name="className"></param>
		/// <returns></returns>
		public bool TryFind(string className, out RecipeData recipe)
		{
			recipe = this.Find(className);
			return recipe != null;
		}

		/// <summary>
		/// Recipes database, indexed by recipe's id.
		/// </summary>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "className", "itemCrafted", "itemCraftedCount", "requiredItems");

			var data = new RecipeData();

			data.Id = entry.ReadInt("id");
			data.ClassName = entry.ReadString("className");
			data.Item = entry.ReadString("itemCrafted");
			data.ItemAmount = entry.ReadInt("itemCraftedCount");

			if (entry.ContainsKey("requiredItems"))
			{
				foreach (JObject item in entry["requiredItems"])
				{
					item.AssertNotMissing("item", "amount");

					var itemName = item.ReadString("item");
					if (!data.RequiredItems.ContainsKey(itemName))
						data.RequiredItems.Add(itemName, item.ReadInt("amount", 1));
				}
			}

			this.AddOrReplace(data.Id, data);
		}
	}
}
