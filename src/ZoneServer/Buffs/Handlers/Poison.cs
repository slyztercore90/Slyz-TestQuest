using System;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.Skills.Combat;
using Melia.Zone.World.Actors;
using Yggdrasil.Util;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Deadly Poison, Periodically receiving poison damage..
	/// </summary>
	[BuffHandler(BuffId.Poison)]
	public class Poison : BuffHandler
	{
		private const float AttackBonus = -2f;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			Send.ZC_SHOW_EMOTICON(target, "I_emo_poison", buff.Duration);
			target.Properties.Modify(PropertyName.ATK_BM, buff.NumArg1 * AttackBonus);
		}

		public override void WhileActive(Buff buff)
		{

			if (buff.Caster is ICombatEntity caster)
			{
				var target = buff.Target;
				var minMATK = caster.Properties.GetFloat(PropertyName.MINMATK);
				var maxMATK = caster.Properties.GetFloat(PropertyName.MAXMATK);
				var damage = (minMATK + maxMATK) / RandomProvider.Next(7, 10);

				var forceId = ForceId.GetNew();

				target.TakeDamage(damage, caster);

				var hitInfo = new HitInfo(caster, target, damage, HitResultType.Hit);
				hitInfo.ForceId = forceId;
				hitInfo.Type = HitType.Fire;

				Send.ZC_HIT_INFO(caster, target, hitInfo);
			}
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			Send.ZC_SHOW_EMOTICON(target, "I_emo_poison", TimeSpan.Zero);
			target.Properties.Modify(PropertyName.ATK_BM, buff.NumArg1 * -AttackBonus);
		}
	}
}
