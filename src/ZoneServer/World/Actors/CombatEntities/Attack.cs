using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.Tos.Const;
using Melia.Zone.Skills;
using Melia.Zone.World.Actors.Characters;
using Yggdrasil.Util;

namespace Melia.Zone.World.Actors.CombatEntities
{
	/// <summary>
	/// Attack Class
	/// Basis for Attacker/Target/Damage sent to a packet
	/// </summary>
	public class Attack
	{
		/// <summary>
		/// An attack's handle
		/// </summary>
		public int Handle { get; } = ZoneServer.Instance.World.CreateAttackHandle();
		/// <summary>
		/// An attack's origin entity
		/// </summary>
		public ICombatEntity Attacker { get; }
		/// <summary>
		/// An attack's target
		/// </summary>
		public ICombatEntity Target { get; }
		/// <summary>
		/// Skill Factor used to calculate damage
		/// </summary>
		public Skill Skill { get; }
		/// <summary>
		/// An attack's index
		/// Used to cascade attacks sent together?
		/// </summary>
		public byte Index { get; }

		/// Gets or sets the handle of the attacker.
		/// </summary>
		public int AttackerId { get; set; }

		/// <summary>
		/// Gets or sets the target's handle.
		/// </summary>
		public int TargetId { get; set; }

		/// <summary>
		/// Returns a list of targets that were hit.
		/// </summary>
		public List<int> TargetIds { get; } = new List<int>();

		/// <summary>
		/// Returns true if this is an attack action.
		/// </summary>
		public bool IsAttack => this.Handle == this.AttackerId;

		/// <summary>
		/// Returns true if this is a target action.
		/// </summary>
		public bool IsTarget => this.Handle == this.TargetId;

		public int HitCount { get; set; } = 1;

		public HitResult HitResult { get; set; } = HitResult.BLOW;

		public HitEffect HitEffect { get; set; } = HitEffect.NORMAL;

		public Hit HitType { get; set; } = Hit.BASIC;


		public AttackType AttackType
		{
			get
			{
				var attribute = AttackType.Melee;
				if (this.Skill.Data.AttackType != AttackType.None)
					attribute = this.Skill.Data.AttackType;
				else
				{
					if (this.Attacker is Character character && character.Inventory?.GetEquip(EquipSlot.RightHand).Data.AttackType != AttackType.None)
						attribute = character.Inventory.GetEquip(EquipSlot.RightHand)?.Data.AttackType ?? AttackType.Melee;

				}
				return attribute;
			}
		}

		/// <summary>
		/// An attack's damage
		/// </summary>
		public int Damage
		{
			get
			{
				var minAttack = 1;
				var maxAttack = 2;
				var defense = 0;
				if (this.Skill.Data.ClassType == SkillClassType.Magic)
				{
					minAttack = (int)this.Attacker.Properties.GetFloat(PropertyName.MINMATK);
					maxAttack = (int)this.Attacker.Properties.GetFloat(PropertyName.MAXMATK);
					defense = (int)this.Target.Properties.GetFloat(PropertyName.MDEF);
				}
				else
				{
					minAttack = (int)this.Attacker.Properties.GetFloat(PropertyName.MINPATK);
					maxAttack = (int)this.Attacker.Properties.GetFloat(PropertyName.MAXPATK);
					defense = (int)this.Target.Properties.GetFloat(PropertyName.DEF);
				}

				var damage = (int)(RandomProvider.Get().Next(minAttack, maxAttack) * this.Skill.Data.SkillFactor / 100f) - defense;

				return Math2.Clamp(0, int.MaxValue, damage);
			}
		}

		/// <summary>
		/// Gets or sets the id of the skill that applies to this action,
		/// either the attacker's or the target's active skill.
		/// </summary>
		public SkillId SkillId { get; set; }

		/// <summary>
		/// Attack is a knockback
		/// </summary>
		public bool IsKnockBack { get; set; } = false;

		/// <summary>
		/// Attack is defended
		/// </summary>
		public bool Defended => Damage <= 0;

		/// <summary>
		/// Creates a new instance
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		/// <param name="index"></param>
		public Attack(ICombatEntity attacker, ICombatEntity target, Skill skill, byte index = 0)
		{
			this.Attacker = attacker;
			this.Target = target;
			this.Skill = skill;
			this.Index = index;
			this.AttackerId = attacker.Handle;
			this.TargetId = target.Handle;
			this.SkillId = skill.Id;
		}
	}
}
