using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.World.Actors.Characters.Components
{
	/// <summary>
	/// Assister Cabinet.
	/// </summary>
	public class AssisterCabinetComponent : CharacterComponent
	{
		/// <summary>
		/// Assister Collection
		/// </summary>
		private readonly IList<AssisterCard> _assisters = new List<AssisterCard>();

		/// <summary>
		/// Assister Collection Count
		/// </summary>
		public int Count
		{
			get
			{
				lock (_assisters)
					return this._assisters.Count;
			}
		}

		public AssisterCabinetComponent(Character character) : base(character)
		{
		}

		/// <summary>
		/// Add to client's album
		/// </summary>
		/// <param name="assister"></param>
		public void Add(string assister)
		{
			var card = new AssisterCard(-1, assister, this.Count);
			this.Add(card);
		}

		/// <summary>
		/// Add to client's album
		/// </summary>
		/// <param name="assister"></param>
		public void Add(AssisterCard card, bool silently = false)
		{
			lock (this._assisters)
				this._assisters.Add(card);
			if (!silently)
				Send.ZC_ANCIENT_CARD_ADD(this.Character, card);
		}

		/// <summary>
		/// Swap to card slot
		/// </summary>
		/// <param name="assister"></param>
		public void Swap(int slot1, int slot2)
		{
			lock (this._assisters)
			{
				var card1 = this._assisters[slot1];
				var card2 = this._assisters[slot2];

				if (card1 != null && card2 != null)
				{
					this._assisters[slot1].Slot = card2.Slot;
					this._assisters[slot2].Slot = card1.Slot;
				}
				Send.ZC_ANCIENT_CARD_UPDATE(this.Character, card1);
			}
		}

		public AssisterCard[] GetAssisters()
		{
			lock (_assisters)
				return _assisters.ToArray();
		}
	}

	/// <summary>
	/// Assister Card
	/// </summary>
	public class AssisterCard
	{
		/// <summary>
		/// Assister card's globally unique id.
		/// </summary>
		/// <remarks>
		/// This is different than the item's object id.
		/// </remarks>
		public long ObjectId { get; set; }
		public string Name { get; set; }
		public int Slot { get; set; }
		public long Experience { get; set; } = 0;

		public AssisterCard(long objectId, string name, int slot)
		{
			this.ObjectId = objectId;
			this.Name = name;
			this.Slot = slot;
		}
	}
}
