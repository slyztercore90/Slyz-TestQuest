using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Spurt, Move faster for 15 seconds..
	/// </summary>
	[BuffHandler(BuffId.Scud)]
	public class Scud : BuffHandler
	{
		private const int MovementBonus = 3;

		public override void OnStart(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.MSPD_BM, MovementBonus);
		}

		public override void OnEnd(Buff buff)
		{
			buff.Target.Properties.Modify(PropertyName.MSPD_BM, -MovementBonus);
		}
	}
}
