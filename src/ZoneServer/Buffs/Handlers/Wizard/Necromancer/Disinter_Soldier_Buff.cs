using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Sacrifice: Skeleton, Max HP, Physical and Magic DEF Increase.
	/// </summary>
	[BuffHandler(BuffId.Disinter_Soldier_Buff)]
	public class Disinter_Soldier_Buff : BuffHandler
	{
		private const string MaxHpVarName = "Melia.MaxHPModifier";
		private const string DefVarName = "Melia.DefModifier";
		private const float Bonus = .1f;

		public override void OnStart(Buff buff)
		{
			var target = buff.Target;
			var maxHp = target.Properties.GetFloat(PropertyName.MHP);
			var physicalDef = target.Properties.GetFloat(PropertyName.DEF);

			buff.Vars.SetFloat(MaxHpVarName, maxHp * Bonus);
			buff.Vars.SetFloat(DefVarName, physicalDef * Bonus);

			target.Properties.Modify(PropertyName.MHP_BM, maxHp * Bonus);
			target.Properties.Modify(PropertyName.DEF_BM, physicalDef * Bonus);
			target.Properties.Invalidate(PropertyName.MHP, PropertyName.DEF);

			maxHp = target.Properties.GetFloat(PropertyName.MHP);

			Send.ZC_UPDATE_MHP(target, (int)maxHp);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			if (buff.Vars.TryGetFloat(DefVarName, out var defMod))
			{
				target.Properties.Modify(PropertyName.DEF_BM, -defMod);
				target.Properties.Invalidate(PropertyName.DEF);
			}

			if (buff.Vars.TryGetFloat(MaxHpVarName, out var maxHpMod))
			{
				target.Properties.Modify(PropertyName.MHP_BM, -maxHpMod);
				target.Properties.Invalidate(PropertyName.MHP);

				var maxHp = target.Properties.GetFloat(PropertyName.MHP);

				Send.ZC_UPDATE_MHP(target, (int)maxHp);
			}
		}
	}
}
