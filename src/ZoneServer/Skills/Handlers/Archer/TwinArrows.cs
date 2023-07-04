using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Archer
{
	/// <summary>
	/// Handler for the Archer skill Twin Arrows.
	/// </summary>
	[SkillHandler(SkillId.Archer_TwinArrows)]
	public class TwinArrows : ITargetSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, ICombatEntity target)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(target);
			caster.Components.Get<CombatComponent>().SetAttackState(true);

			if (target == null)
			{
				Send.ZC_SKILL_FORCE_TARGET(caster, null, skill);
				return;
			}

			var castRange = caster.Position.Get2DDistance(target.Position);
			if (castRange > skill.Data.MaxRange)
			{
				Log.Warning("Twin Arrows: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				return;
			}

			Send.ZC_SKILL_READY(caster, skill, 1, caster.Position, target.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Position.GetDirection(target.Position), target?.Position ?? Position.Zero);

			var damageDelay = TimeSpan.FromMilliseconds(500);
			var skillHitDelay = skill.Properties.HitDelay;

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);

			var skillHit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
			skillHit.ForceId = ForceId.GetNew();

			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, skillHit);
		}
	}
}
