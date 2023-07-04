using System.Collections.Generic;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Common
{
	/// <summary>
	/// Handler for the Common skill Normal Two Handed Attack.
	/// </summary>
	[SkillHandler(SkillId.Normal_Attack_TH)]
	public class NormalAttackTH : IMeleeGroundSkillHandler
	{
		/// <summary>
		/// Handles skill behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, IList<ICombatEntity> targets)
		{
			var castRange = originPos.Get2DDistance(farPos);
			if (castRange > (skill.Data.MaxRange + 1f))
			{
				Log.Warning("NormalAttackTH: Player {0} cast skill farther than max range ({1} > {2}).", caster.Name, castRange, skill.Data.MaxRange);
				Send.ZC_SKILL_CAST_CANCEL(caster);
				return;
			}

			skill.IncreaseOverheat();

			var radius = (int)skill.Data.SplashRange * 2;
			//var targets = caster.Map.GetAttackableEntitiesInRange(caster, farPos, radius);
			var attacks = AttackInfo.CreateAttacks(caster, (List<ICombatEntity>)targets, skill);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos, null);

			Send.ZC_SKILL_HIT_INFO(caster, skill, 1, attacks);
			foreach (var attack in attacks)
			{
				if (attack.ApplyDamage())
					Send.ZC_SKILL_CAST_CANCEL(caster);
			}
		}
	}
}
