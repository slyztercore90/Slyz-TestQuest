using System;
using System.Collections.Generic;
using System.Linq;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Yggdrasil.Logging;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Scout
{
	/// <summary>
	/// Handler for the Scout skill Oblique Fire.
	/// </summary>
	[SkillHandler(SkillId.Scout_ObliqueFire)]
	public class ObliqueFire : ITargetSkillHandler
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

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, target.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Direction, target?.Position ?? Position.Zero);

			Send.ZC_SYNC_START(caster, skillHandle, 1);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.ObliqueFire_Buff, 0, 0, TimeSpan.FromSeconds(10), caster, caster));
			Send.ZC_SYNC_END(caster, skillHandle, 0.1f);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);

			var damageDelay = TimeSpan.FromMilliseconds(500);
			var skillHitDelay = skill.Properties.HitDelay;

			var skillHitResult = SCR_SkillHit(caster, target, skill);
			target.TakeDamage(skillHitResult.Damage, caster);
			target.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.ObliqueFire_Debuff, 0, 0, TimeSpan.FromSeconds(10), target, caster));

			// The force id needs to be set on both the skill hits
			// and ZC_SKILL_FORCE_TARGET for the client to connect
			// the pieces and stop arrows from flying past the targets.
			var forceId = ForceId.GetNew();

			var hit = new SkillHitInfo(caster, target, skill, skillHitResult, damageDelay, skillHitDelay);
			hit.ForceId = forceId;
			var radius = (int)skill.Data.SplashRange * 4;
			var splashTarget = caster.Map.GetAttackableEntityInRangeAroundEntity(caster, target, radius);

			Send.ZC_SKILL_FORCE_TARGET(caster, target, skill, hit);

			if (splashTarget != null)
			{
				var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				Send.ZC_NORMAL.SkillEffectSplash(caster, target, splashTarget, effectHandle,
					"I_archer_pistol_atk", 0.5f, "arrow_cast", "I_archer_pistol_atk_smoke", 1, "arrow_blow", "SLOW", 800,
					1, 5, 0, 0);
				Send.ZC_SYNC_END(caster, skillHandle, 0.1f);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);

				skillHitResult = SCR_SkillHit(caster, target, skill);
				splashTarget.TakeDamage(skillHitResult.Damage, caster);

				var hitInfo = new HitInfo(caster, splashTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.ForceId = effectHandle;
				Send.ZC_HIT_INFO(caster, splashTarget, skill, hitInfo);
			}

			// Add Buff Id: 420 [ObliqueFire_Buff] Duration: 10000
			// Add Buff Id: 421 [ObliqueFire_Debuff] Duration: 10000
		}
	}
}
