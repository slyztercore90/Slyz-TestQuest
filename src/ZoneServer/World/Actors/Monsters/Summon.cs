using System;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Util;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Scheduling;

namespace Melia.Zone.World.Actors.Monsters
{
	public class Summon : Mob
	{
		/// <summary>
		/// A reference to the character which owns this summon.
		/// </summary>
		public Character Owner { get; private set; }
		public long Experience { get; set; }
		public DateTime CreateTime { get; set; }

		public Summon(Character owner, int id, MonsterType type) : base(id, type)
		{
			this.Owner = owner;
		}

		public void SetState(bool isActive)
		{
			if (isActive)
			{
				this.Map = this.Owner.Map;
				this.OwnerHandle = this.Owner.Handle;
				this.Components.Add(new MovementComponent(this));
				this.Components.Add(new AiComponent(this, "BasicMonster"));
				this.Position = this.Owner.Position.GetRandomInRange2D(15, new Random());
				Send.ZC_SET_POS(this);
				this.Map.AddMonster(this);
			}
			else
			{
				this.Position = Position.Zero;
				this.OwnerHandle = 0;
				// Clear Buffs
				this.Map.RemoveMonster(this);
				this.Components.Remove<AiComponent>();
				this.Components.Remove<MovementComponent>();
			}
		}
	}
}
