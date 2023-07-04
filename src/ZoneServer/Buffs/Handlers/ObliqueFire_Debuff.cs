using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handler for ObliqueFire_Buff, which increases the target's
	/// movement speed.
	/// </summary>
	[BuffHandler(BuffId.ObliqueFire_Debuff)]
	public class ObliqueFireDebuffHandler : BuffHandler
	{
		private const string ModifierVar = "Buff:ObliqueFire_Buff/Modifier";
		private float _modifier = 0f;

		/// <summary>
		/// Starts buff, modifying the target's movement speed.
		/// </summary>
		/// <param name="buff"></param>
		public override void OnStart(Buff buff)
		{
			var target = buff.Target;

			// Movement Speed -5% per stack when stack is 4 or more
			if (buff.OverbuffCounter > 3)
			{
				var mspd = target.Properties.GetFloat(PropertyName.MSPD);
				var add = -mspd * 0.05f;

				target.Properties.Modify(PropertyName.MSPD_BM, add);
				_modifier += add;

				Send.ZC_MOVE_SPEED(target);
			}
		}

		/// <summary>
		/// Ends the buff, resetting the movement speed.
		/// </summary>
		/// <param name="buff"></param>
		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;
			target.Properties.Modify(PropertyName.MSPD_BM, _modifier);

			Send.ZC_MOVE_SPEED(target);
		}
	}
}
