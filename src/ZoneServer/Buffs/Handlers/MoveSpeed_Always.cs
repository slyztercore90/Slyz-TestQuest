using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Increase Movement Speed, Increase movement speed..
	/// </summary>
	[BuffHandler(BuffId.MoveSpeed_Always)]
	public class MoveSpeed_Always : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			target.Properties.Modify(PropertyName.MSPD_BM, 10 * buff.NumArg1);

			Send.ZC_MSPD(target);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			target.Properties.SetFloat(PropertyName.MSPD_BM, -10 * buff.NumArg1);

			Send.ZC_MSPD(target);
		}
	}
}
