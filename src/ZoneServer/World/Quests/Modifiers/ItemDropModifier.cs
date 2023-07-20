using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.Events;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Quests.Objectives;

namespace Melia.Zone.World.Quests.Modifiers
{
	/// <summary>
	/// A modifier that gives a chance to add drops to a monster.
	/// </summary>
	public class ItemDropModifier : QuestModifier
	{
		/// <summary>
		/// Returns the item id that a monster drops.
		/// </summary>
		public int ItemId { get; }

		/// <summary>
		/// Returns the amount of chance the monster has to drop an item.
		/// </summary>
		public float DropChance { get; }

		/// <summary>
		/// Returns an array of monster ids that drops the item.
		/// </summary>
		public int[] MonsterIds { get; }

		/// <summary>
		/// Returns the monster id that drops the item.
		/// </summary>
		public int MonsterId { get; }

		public ItemDropModifier(int itemId, float dropChance, params int[] monsterIds)
		{
			this.ItemId = itemId;
			this.DropChance = dropChance;
			this.MonsterIds = monsterIds;
		}

		public ItemDropModifier(int itemId, float dropChance, params string[] monsterIds)
		{
			this.ItemId = itemId;
			this.DropChance = dropChance;
			this.MonsterIds = new int[monsterIds.Length];

			for (var i = 0; i < monsterIds.Length; i++)
			{
				var monster = monsterIds[i];
				if (ZoneServer.Instance.Data.MonsterDb.TryFind(monster, out var data))
					this.MonsterIds[i] = data.Id;
			}
		}

		/// <summary>
		/// Sets up event subscriptions.
		/// </summary>
		public override void Load()
		{
			ZoneServer.Instance.ServerEvents.EntityKilled += this.OnEntityKilled;
		}

		/// <summary>
		/// Cleans up event subscriptions.
		/// </summary>
		public override void Unload()
		{
			ZoneServer.Instance.ServerEvents.EntityKilled -= this.OnEntityKilled;
		}

		/// <summary>
		/// Called when a character dies.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		private void OnEntityKilled(object sender, CombatEventArgs args)
		{
			if (args.Target is not Mob monster)
				return;

			if (args.Attacker is not Character character)
				return;

			character.Quests.UpdateModifiers<ItemDropModifier>((quest, modifier, progress) =>
			{
				if (modifier.MonsterIds == null)
				{
					if (monster.Id == modifier.MonsterId)
						monster.DropItem(character, modifier.ItemId, modifier.DropChance);
				}
				else
				{
					foreach (var monsterId in modifier.MonsterIds)
					{
						if (monster.Id == monsterId)
							monster.DropItem(character, modifier.ItemId, modifier.DropChance);
					}
				}
			});
		}
	}
}
