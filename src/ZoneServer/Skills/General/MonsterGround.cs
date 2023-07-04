using System;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Network;
using Melia.Zone.Skills.Base;
using Melia.Zone.Skills.SplashAreas;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.General
{
	/// <summary>
	/// Generic Monster Ground Skill Handler
	/// </summary>
	public class MonsterGroundSkillHandler : IMonsterGroundSkillHandler
	{
		public void Handle(Skill skill, ICombatEntity caster, Position castPosition, Position targetPosition)
		{
			//var splashArea = skill.GetSplashArea(targetPosition);
			var splashArea = new Square(castPosition, caster.Direction, skill.Data.SplashHeight, skill.Data.SplashRange); // higher than Normal_Attack, but narrower
			var targets = caster.Map.GetAttackableEntitiesIn(caster, splashArea);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, targetPosition, null);
			Task.Delay(skill.HitTime).ContinueWith(t =>
			{
				foreach (var target in targets)
					Send.ZC_SKILL_HIT_INFO(caster, target, 1);
			});
		}
	}
}
