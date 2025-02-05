﻿using System;
using Newtonsoft.Json.Linq;
using Yggdrasil.Data.JSON;

namespace Melia.Shared.Data.Database
{
	[Serializable]
	public class AccountOptionData
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int DefaultValue { get; set; }
	}

	/// <summary>
	/// Account option database, indexed by their ids.
	/// </summary>
	public class AccountOptionDb : DatabaseJsonIndexed<int, AccountOptionData>
	{
		/// <summary>
		/// Reads given entry and adds it to the database.
		/// </summary>
		/// <param name="entry"></param>
		protected override void ReadEntry(JObject entry)
		{
			entry.AssertNotMissing("id", "name", "defaultValue");

			var data = new AccountOptionData();

			data.Id = entry.ReadInt("id");
			data.Name = entry.ReadString("name");
			data.DefaultValue = entry.ReadInt("defaultValue");

			this.AddOrReplace(data.Id, data);
		}
	}
}
