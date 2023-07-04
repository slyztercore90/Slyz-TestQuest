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
	/// Handler for the Sorcerer skill Summon Salamion.
	/// </summary>
	[SkillHandler(SkillId.Sorcerer_SummonSalamion)]
	public class SummonSalamion : IGroundSkillHandler
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
			Send.ZC_SKILL_MELEE_GROUND(caster, skill, farPos);

			if (caster is Character character)
			{
				var monsterId = 401581;
				var summonedMonster = new Mob(monsterId, MonsterType.Friendly);

				Send.ZC_EXEC_CLIENT_SCP(character.Connection, string.Format("UPDATE_PC_FOLLOWER_LIST(\"{0}:1#\")", monsterId));
				summonedMonster.Map = caster.Map;
				summonedMonster.Name = "!@#${Auto_1}_of_{Auto_2}$*$Auto_1$*$" + caster.Name + "$*$Auto_2$*$@dicID_^*$ETC_20150317_000235$*^#@!";
				summonedMonster.Position = farPos;
				summonedMonster.OwnerHandle = caster.Handle;
				summonedMonster.Faction = FactionType.Law;
				summonedMonster.Properties.SetFloat(PropertyName.FIXMSPD_BM, 80f);
				summonedMonster.Properties.SetFloat(PropertyName.MINPATK, 40f);
				summonedMonster.Properties.SetFloat(PropertyName.MAXPATK, 50f);
				summonedMonster.Properties.SetFloat(PropertyName.MINMATK, 40f);
				summonedMonster.Properties.SetFloat(PropertyName.MAXMATK, 50f);
				summonedMonster.Components.Add(new MovementComponent(summonedMonster));
				//var ai = new CreatureAi(summonedMonster, "PC_Summon");
				//ai.SetMaster(caster);
				//ai.SetAggro(true);
				//summonedMonster.Components.Add(ai);
				var ai = new AiComponent(summonedMonster, "BasicMonster", caster);
				summonedMonster.Components.Add(ai);
				summonedMonster.Direction = caster.Direction;
				caster.Map.AddMonster(summonedMonster);
				Send.ZC_OWNER(character, summonedMonster);
				Send.ZC_ENTER_MONSTER(summonedMonster);
				Send.ZC_FACTION(character.Connection, summonedMonster, FactionType.Law);
				Send.ZC_NORMAL.SummonPlayAnimation(summonedMonster, "SORCERER_SUMMONSALOON", 1);
				Send.ZC_BUFF_LIST(summonedMonster);

				skillHandle = ZoneServer.Instance.World.CreateSkillHandle();
				Send.ZC_SYNC_START(caster, skillHandle, 1);
				Send.ZC_MSPD(character, summonedMonster, 0, 160f);
				summonedMonster.Components.Get<BuffComponent>()?.AddOrUpdate(new Buff(BuffId.Ability_buff_PC_Summon, 0, 0, TimeSpan.Zero, summonedMonster, summonedMonster));
				Send.ZC_IS_SUMMON_SORCERER_MONSTER(caster, summonedMonster);
				Send.ZC_SYNC_END(caster, skillHandle, 0);
				Send.ZC_SYNC_EXEC_BY_SKILL_TIME(caster, skillHandle, skill.Data.DefaultHitDelay);
			}
		}
	}
}
