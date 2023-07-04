using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;

namespace Melia.Zone.Skills.Handlers.Barbarian
{
	/// <summary>
	/// Handler for the Barbarian skill Pouncing.
	/// </summary>
	[SkillHandler(SkillId.Barbarian_Pouncing)]
	public class Pouncing : IDynamicCastSkillHandler
	{
		public void HandleCastStart(Skill skill, Character caster, float maxCastTime)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.Components.Get<CombatComponent>().SetAttackState(true);
			caster.SetProperty(PropertyName.Jumpable, 0);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_NORMAL.Skill(caster, skill, "Barbarian_Pouncing", caster.Position, caster.Direction, 0, 35, skillHandle, 45);
			var buff = new Buff(BuffId.Pouncing_Buff, 0, 0, TimeSpan.Zero, caster, caster);
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(buff);
			Send.ZC_PLAY_SOUND(caster, 370028);
			Send.ZC_NORMAL.Skill_4D(caster, skill.Id);
		}

		public void HandleCastEnd(Skill skill, Character caster, float maxCastTime)
		{
			caster.SetProperty(PropertyName.Jumpable, 1);
			caster.Components.Get<BuffComponent>()?.Remove(BuffId.Pouncing_Buff);
			Send.ZC_STOP_SOUND(caster, 370028);
			Send.ZC_NORMAL.Skill_4E(caster, skill.Id, 3.5f);
			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
			Send.ZC_NORMAL.Skill(caster, skill, "Barbarian_Pouncing", caster.Position, caster.Direction, 0, 35, skillHandle, 45);
		}
	}
}
