using System.Collections.Generic;
using System.Linq;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.World.Actors;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Shared.World;

namespace Melia.Zone.Skills.Handlers.Common
{
	/// <summary>
	/// Handler for the Common skill Cannon Normal Attack.
	/// </summary>
	[SkillHandler(SkillId.Cannon_Normal_Attack)]
	public class CannonNormalAttack : IForceSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets)
		{
			skill.IncreaseOverheat();

			if (targets.Any())
			{
				var target = targets.FirstOrDefault();
				var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				var attacks = AttackInfo.CreateAttacks(caster, target, skill);

				Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
				//Send.ZC_NORMAL.Skill_40(caster, skill, caster.Direction, 1, 481.9474f, 1, 0, skillHandle, 1.244949f, 0, 0, 512, 0);
				Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, attacks);

				foreach (var attack in attacks)
				{
					if (attack.ApplyDamage())
						Send.ZC_SKILL_CAST_CANCEL(caster);
				}
			}
			else
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill, null);
		}
	}
}
