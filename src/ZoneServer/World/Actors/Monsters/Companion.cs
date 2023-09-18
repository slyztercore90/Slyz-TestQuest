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
	public class Companion : Mob, IPropertyObject
	{
		/// <summary>
		/// Companion's unique id.
		/// </summary>
		public long DbId { get; set; }

		/// <summary>
		/// Companion's globally unique id.
		/// </summary>
		public long ObjectId => ObjectIdRanges.Companions + this.DbId;

		/// <summary>
		/// A reference to the character which owns this companion.
		/// </summary>
		public Character Owner { get; private set; }

		/// <summary>
		/// Companion is activated (Visible)
		/// </summary>
		public bool IsActivated
		{
			get
			{
				return this.Properties.GetFloat(PropertyName.IsActivated) == 1;
			}
			set
			{
				this.Properties.SetFloat(PropertyName.IsActivated, value ? 1 : 0);
			}
		}

		public int Stamina { get; set; }
		public long Experience { get; set; }
		public DateTime AdoptTime { get; set; }
		public bool IsRiding { get; set; } = false;

		public Companion(Character owner, int id, MonsterType type) : base(id, type)
		{
			this.Owner = owner;

			this.Properties.Create(new FloatProperty(PropertyName.Range, 0f));
			this.Properties.Create(new FloatProperty(PropertyName.Scale, 0f));

			this.Properties.Create(new StringProperty(PropertyName.AdoptTime, this.AdoptTime.ToSPropertyDateTime()));
			this.Properties.Create(new FloatProperty(PropertyName.SDR, 1.00f));
			this.Properties.Create(new FloatProperty(PropertyName.ATK, 47.00f));
			this.Properties.Create(new FloatProperty(PropertyName.CRTDR, 4.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MHP, 1437.00f));
			this.Properties.Create(new FloatProperty(PropertyName.DEX, 2.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountDEF, 2.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MDEF, 21.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountDR, 3.00f));
			this.Properties.Create(new FloatProperty(PropertyName.CON, 4.00f));
			this.Properties.Create(new FloatProperty(PropertyName.BLK, 25.00f));
			this.Properties.Create(new FloatProperty(PropertyName.STR, 4.00f));
			this.Properties.Create(new FloatProperty(PropertyName.DEF, 21.00f));
			this.Properties.Create(new FloatProperty(PropertyName.DR, 45.00f));
			this.Properties.Create(new FloatProperty(PropertyName.INT, 2.00f));
			this.Properties.Create(new FloatProperty(PropertyName.SR, 16.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountMHP, 359.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MAXPATK, 47.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountMSPD, 0.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountPATK, 0.00f));
			this.Properties.Create(new FloatProperty(PropertyName.BLK_BREAK, 23.00f));
			this.Properties.Create(new FloatProperty(PropertyName.CRTATK, 4.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MNA, 2.00f));
			this.Properties.Create(new FloatProperty(PropertyName.HR, 45.00f));
			this.Properties.Create(new FloatProperty(PropertyName.CRTHR, 2.00f));
			this.Properties.Create(new FloatProperty(PropertyName.RHPTIME, 10000.00f));
			this.Properties.Create(new FloatProperty(PropertyName.IsActivated, this.IsActivated ? 1 : 0));
			this.Properties.Create(new FloatProperty(PropertyName.MHR, 0.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MAXMATK, 47.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MINPATK, 47.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MountMATK, 0.00f));
			this.Properties.Create(new FloatProperty(PropertyName.MINMATK, 47.00f));

			this.Properties.Create(new FloatProperty(PropertyName.WlkMSPD, this.Data.WalkSpeed));
			this.Properties.Create(new FloatProperty(PropertyName.RunMSPD, this.Data.RunSpeed));
			this.Properties.Create(new FloatProperty(PropertyName.FIXMSPD_BM, 90f));
		}

		public void SetCompanionState(bool isActive)
		{
			this.IsActivated = isActive;
			Send.ZC_OBJECT_PROPERTY(this.Owner.Connection, this, PropertyName.IsActivated);
			if (isActive)
			{
				this.Map = this.Owner.Map;
				this.OwnerHandle = this.Owner.Handle;
				this.Components.Add(new MovementComponent(this));
				this.Components.Add(new AiComponent(this, "BasicMonster", this.Owner));
				Send.ZC_NORMAL.PetIsInactive(this.Owner.Connection, this);
				this.Position = this.Owner.Position.GetRandomInRange2D(15, new Random());
				Send.ZC_SET_POS(this);
				this.Map.AddMonster(this);
				Send.ZC_NORMAL.PetPlayAnimation(this.Owner.Connection, this);
				// Probably speed is not a fixed 90f value
				Send.ZC_MSPD(this.Owner, this, this.ObjectId, 90f);
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

		/// <summary>
		/// Grants exp to companion.
		/// </summary>
		/// <param name="exp"></param>
		/// <param name="monster"></param>
		public void GiveExp(long exp, IMonster monster)
		{
			// Base EXP
			this.Experience += exp;

			Send.ZC_NORMAL.PetExpUpdate(this.Owner, this);
		}
	}
}
