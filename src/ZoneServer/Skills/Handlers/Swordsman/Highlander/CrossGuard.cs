using System;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Highlander
{
	/// <summary>
	/// Handler for the Highlander skill Cross Guard.
	/// </summary>
	[SkillHandler(SkillId.Highlander_CrossGuard)]
	public class CrossGuard : IDynamicGroundSkillHandler
	{
		public void HandleCastStart(Skill skill, Character caster, float maxCastTime)
		{
			Send.ZC_PLAY_SOUND(caster, "shieldup", 0, -1, 0);
			Send.ZC_PLAY_SOUND(caster, "shieldup_2", 0, -1, 0);
			var buff = new Buff(BuffId.CrossGuard_Buff, 0, 0, TimeSpan.FromSeconds(0), caster, caster);
			//buff.Skill = skill;
			caster?.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_NORMAL.Skill_4D(caster, skill.Id);
		}

		public void HandleCastEnd(Skill skill, Character caster, float maxCastTime)
		{
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.StartUp_Charging_Buff);
			Send.ZC_NORMAL.Skill_4E(caster, skill.Id, 2);
		}

		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity target)
		{
			skill.IncreaseOverheat();
		}
	}
}
