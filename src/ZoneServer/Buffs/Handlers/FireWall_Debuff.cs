using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Fire, Reduced Fire resistance for debuffed enemies..
	/// </summary>
	[BuffHandler(BuffId.FireWall_Debuff)]
	public class FireWall_Debuff : BuffHandler
	{
		private const float FireResistance = -20f;

		public override void OnStart(Buff buff)
		{
			if (buff.Target is Character)
				buff.Target.Properties.Modify(PropertyName.ResFire_BM, FireResistance);
			else
				buff.Target.Properties.Modify(PropertyName.Fire_Def, FireResistance);
		}

		public override void OnEnd(Buff buff)
		{
			if (buff.Target is Character)
				buff.Target.Properties.Modify(PropertyName.ResFire_BM, -FireResistance);
			else
				buff.Target.Properties.Modify(PropertyName.Fire_Def, -FireResistance);
		}
	}
}
