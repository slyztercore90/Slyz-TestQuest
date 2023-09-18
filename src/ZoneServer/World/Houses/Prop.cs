using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.World;

namespace Melia.Zone.World.Houses
{
	/// <summary>
	/// Represent's a spawnable prop in a house.
	/// </summary>
	public class Prop
	{
		public int Handle { get; set; }
		public int MonsterId { get; set; }
		public int FurnitureId { get; set; }
		public Position Position { get; set; }
		public Direction Direction { get; set; }
		public FurnitureData Data { get; set; }
		public int[] UsedCells { get; set; }

		public Prop(int furnitureId)
		{
			this.FurnitureId = furnitureId;

			this.LoadData();
		}

		/// <summary>
		/// Loads data from data files.
		/// </summary>
		protected void LoadData()
		{
			if (FurnitureId == 0)
				throw new InvalidOperationException("Id wasn't set before calling LoadData.");

			this.Data = ZoneServer.Instance.Data.FurnitureDb.Find(FurnitureId);
			if (this.Data == null)
				throw new NullReferenceException("No data found for '" + FurnitureId + "'.");
			this.UsedCells = new int[this.Data.Column * this.Data.Row * this.Data.Height];
		}
	}
}
