using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;

namespace Melia.Zone.Skills.Handlers.Common
{
	/// <summary>
	/// Handler for the Common skill Magic Attack.
	/// </summary>
	//[SkillHandler(SkillId.Magic_Attack)]
	public class MagicAttack : IForceSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			skill.IncreaseOverheat();

			if (target != null)
			{
				var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				var attacks = AttackInfo.CreateAttacks(caster, target, skill);
				var hit = new SkillHitInfo(caster, target, skill, attacks[0].Damage, TimeSpan.Zero, skill.Data.DefaultHitDelay);

				Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, Position.Zero);
				Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Position.GetDirection(target.Position), target?.Position ?? Position.Zero);
				Send.ZC_NORMAL.SkillParticleEffect(caster, target, "SHOW_SKILL_ATTRIBUTE", 5, "Melee");

				foreach (var attack in attacks)
					if (attack.ApplyDamage())
						Send.ZC_SKILL_CAST_CANCEL(caster);
				Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, attacks);
				// Bugged right now, doesn't hit target.
				//Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, 1, new[] { hit });
			}
			else
				Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, 1, null);
		}

		public void Handle(Skill skill, ICombatEntity caster, Direction dir)
		{
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_FORCE_TARGET(caster, null, skill, null);
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets)
		{
			if (targets.Any())
				this.Handle(skill, caster, targets.FirstOrDefault());
		}
	}
}
