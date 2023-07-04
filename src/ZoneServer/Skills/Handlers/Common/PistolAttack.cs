using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Common
{
	/// <summary>
	/// Handler for the Common skill Pistol Attack.
	/// </summary>
	//[SkillHandler(SkillId.Pistol_Attack)]
	public class PistolAttack : ITargetSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			skill.IncreaseOverheat();

			if (target == null)
			{
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill, null);
				return;
			}

			var attacks = AttackInfo.CreateAttacks(caster, target, skill);

			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, attacks);

			foreach (var attack in attacks)
			{
				if (attack.ApplyDamage())
					Send.ZC_SKILL_CAST_CANCEL(caster);
			}
		}
	}
}
