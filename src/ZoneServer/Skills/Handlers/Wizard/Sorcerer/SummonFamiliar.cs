using System;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Buffs;
using Melia.Zone.Network;
using Melia.Zone.Skills.Handlers.Base;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.CombatEntities.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Logging;

namespace Melia.Zone.Skills.Handlers.Sorcerer
{
	/// <summary>
	/// Handler for the Sorcerer skill Summon Familiar.
	/// </summary>
	[SkillHandler(SkillId.Sorcerer_SummonFamiliar)]
	public class SummonFamiliar : IGroundSkillHandler
	{
		/// <summary>
		/// Handle Skill Behavior
		/// </summary>
		/// <param name="skill"></param>
		/// <param name="caster"></param>
		/// <param name="originPos"></param>
		/// <param name="farPos"></param>
		/// <param name="designatedTarget"></param>
		public void Handle(Skill skill, ICombatEntity caster, Position originPos, Position farPos, ICombatEntity designatedTarget)
		{
			if (!caster.TrySpendSp(skill))
			{
				caster.ServerMessage(Localization.Get("Not enough SP."));
				return;
			}

			skill.IncreaseOverheat();
			caster.TurnTowards(designatedTarget);
			caster.Components.Get<CombatComponent>().SetAttackState(true);

			var skillHandle = ZoneServer.Instance.World.CreateSkillHandle();

			Send.ZC_SKILL_READY(caster, skill, skillHandle, caster.Position, farPos);
			Send.ZC_NORMAL.UpdateSkillEffect(caster, 0, caster.Position, caster.Direction, Position.Zero);
			Send.ZC_SYNC_START(caster, skillHandle, 1);
			Send.ZC_SYNC_END(caster, skillHandle, 0);
			Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);

			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			var monsterId = 57432;
			for (var i = 0; i < 5; i++)
			{
				var summonedMonster = new Mob(monsterId, MonsterType.Friendly);
				summonedMonster.Map = caster.Map;
				summonedMonster.Position = farPos;
				summonedMonster.Direction = caster.Direction;
				summonedMonster.Faction = FactionType.Law;
				summonedMonster.Properties.SetFloat(PropertyName.FIXMSPD_BM, 80f);
				summonedMonster.Components.Add(new MovementComponent(summonedMonster));

				var ai = new AiComponent(summonedMonster, "BasicMonster", caster);
				summonedMonster.Components.Add(ai);
				caster.Map.AddMonster(summonedMonster);
				// Should this be handled by the character visibility update or map update?
				// Might be redundant to send this again if handled there.
				if (caster is Character summoner)
				{
					Send.ZC_OWNER(summoner, summonedMonster);
					Send.ZC_ENTER_MONSTER(summonedMonster);
					Send.ZC_FACTION(summoner.Connection, summonedMonster, FactionType.Law);
					Send.ZC_NORMAL.SummonPlayAnimation(summonedMonster, "SORCERER_SUMMONSALOON", 1);
					Send.ZC_BUFF_LIST(summonedMonster);
				}

				skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				if (caster is Character character)
					Send.ZC_MSPD(character, summonedMonster, 0, summonedMonster.Properties.GetFloat(PropertyName.MSPD));
				summonedMonster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Ability_buff_PC_Summon, 0, 0, TimeSpan.Zero, summonedMonster, summonedMonster));
				Send.ZC_IS_SUMMON_SORCERER_MONSTER(caster, summonedMonster);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			}
			caster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.sorcerer_bat, 0, 0, TimeSpan.FromSeconds(60), caster, caster));
		}
	}
}
