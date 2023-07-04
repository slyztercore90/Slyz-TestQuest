using System;
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
using Yggdrasil.Util;
using static Melia.Zone.Skills.SkillUseFunctions;

namespace Melia.Zone.Skills.Handlers.Archer
{
	/// <summary>
	/// Handler for the Archer skill Oblique Shot.
	/// </summary>
	[SkillHandler(SkillId.Archer_ObliqueShot)]
	public class ObliqueShot : ITargetSkillHandler
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
				Log.Warning("Oblique Shot: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				return;
			}

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, target.Position);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, target?.Handle ?? 0, caster.Position, caster.Direction, target?.Position ?? Position.Zero);

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

			// Add Buff Id: 160008 [Common_Slow] Duration: 8000
			// Target ZC_MSPD affected
			var rnd = RandomProvider.Get();
			if (rnd.NextDouble() > .50)
			{
				var buff = new Buff(BuffId.Common_Slow, 0, 0, TimeSpan.FromMilliseconds(8000), target, caster);
				target.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			}

			if (splashTarget != null)
			{
				var effectHandle = ZoneServer.Instance.World.CreateEffectHandle();

				Send.ZC_SYNC_START(caster, skillHandle, 1);
				Send.ZC_NORMAL.SkillEffectSplash(caster, target, splashTarget, effectHandle,
					"I_arrow009_red", 0.7f, "arrow_cast", "F_hit_good", 1, "arrow_blow", "SLOW", 800,
					1, 5, 0, 0);
				Send.ZC_SYNC_END(caster, skillHandle, 0.1f);

				skillHitResult = SCR_SkillHit(caster, splashTarget, skill);
				splashTarget.TakeDamage(skillHitResult.Damage, caster);
				var hitInfo = new HitInfo(caster, splashTarget, skill, skillHitResult.Damage, skillHitResult.Result);
				hitInfo.ForceId = effectHandle;
				Send.ZC_HIT_INFO(caster, splashTarget, skill, hitInfo);
			}
		}
	}
}
