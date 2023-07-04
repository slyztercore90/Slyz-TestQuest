using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Data.Database;
using Melia.Shared.Tos.Const;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Util;

namespace Melia.Zone.Skills.Combat
{
	/// <summary>
	/// Attack Class
	/// Basis for Attacker/Target/Damage sent to a packet
	/// </summary>
	public class AttackInfo
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

		public int HitCount { get; set; } = 1;

		public HitResult HitResult { get; set; } = HitResult.BLOW;

		public HitEffect HitEffect { get; set; } = HitEffect.NORMAL;

		public Hit HitType { get; set; } = Hit.BASIC;

		/// <summary>
		/// Returns a reference to Skill Hit Info object.
		/// </summary>
		public SkillHitInfo SkillHitInfo { get; set; }
		/// <summary>
		/// Returns a reference to Hit Info object.
		/// </summary>
		public HitInfo HitInfo { get; set; }

		public SkillAttackType AttackType
		{
			get
			{
				var attribute = SkillAttackType.Melee;
				if (this.Skill.Data.AttackType != SkillAttackType.None)
					attribute = this.Skill.Data.AttackType;
				else
				{
					if (this.Attacker is Character character && character.Inventory?.GetEquip(EquipSlot.RightHand).Data.AttackType != SkillAttackType.None)
						attribute = character.Inventory.GetEquip(EquipSlot.RightHand)?.Data.AttackType ?? SkillAttackType.Melee;

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
				int minAttack;
				int maxAttack;
				int defense;
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

				var damage = (int)(RandomProvider.Get().Next(minAttack, maxAttack) * this.Skill.Data.Factor / 100f) - defense;

				return Math2.Clamp(0, int.MaxValue, damage);
			}
		}

		/// <summary>
		/// Gets or sets the id of the skill used to attack.
		/// </summary>
		public SkillId SkillId { get; set; }

		/// <summary>
		/// Attack is a knockback
		/// </summary>
		public bool IsKnockBack { get; set; } = false;

		/// <summary>
		/// Attack is defended
		/// </summary>
		public bool Defended => this.Damage <= 0;

		public int EffectHandle { get; internal set; }

		/// <summary>
		/// Creates a new instance
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="target"></param>
		/// <param name="skill"></param>
		/// <param name="index"></param>
		public AttackInfo(ICombatEntity attacker, ICombatEntity target, Skill skill, byte index = 0)
		{
			this.Attacker = attacker;
			this.Target = target;
			this.Skill = skill;
			this.Index = index;
			this.AttackerId = attacker.Handle;
			this.TargetId = target.Handle;
			this.SkillId = skill.Id;
		}

		/// <summary>
		/// Create a list of attacks for a single target
		/// </summary>
		public static AttackInfo[] CreateAttacks(ICombatEntity attacker, ICombatEntity target, Skill skill, byte count = 1)
		{
			var attacks = new List<AttackInfo>();

			for (var i = 0; i < count; i++)
			{
				attacks.Add(new AttackInfo(attacker, target, skill, (byte)(i + 1)));
			}

			return attacks.ToArray();
		}

		/// <summary>
		/// Create a list of attacks for multiple targets
		/// </summary>
		/// <param name="attacker"></param>
		/// <param name="targets"></param>
		/// <param name="skill"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static AttackInfo[] CreateAttacks(ICombatEntity attacker, IList<ICombatEntity> targets, Skill skill, byte count = 1)
		{
			var attacks = new List<AttackInfo>();

			for (var i = 0; i < count; i++)
			{
				for (var j = 0; j < targets.Count; j++)
				{
					if (!targets[j].IsDead)
						attacks.Add(new AttackInfo(attacker, targets[j], skill, (byte)(i + 1)));
				}
			}

			return attacks.ToArray();
		}

		public bool ApplyDamage()
		{
			return this.Target?.TakeDamage(this.Damage, this.Attacker) ?? false;
		}
	}
}
