using Melia.Shared.Tos.Const;
using Melia.Zone.Buffs.Base;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Buffs.Handlers
{
	/// <summary>
	/// Handle for the Petrify, Petrified..
	/// </summary>
	[BuffHandler(BuffId.Petrification)]
	public class Petrification : BuffHandler
	{
		public override void OnStart(Buff buff)
		{
			var caster = buff.Caster;
			var target = buff.Target;

			Send.ZC_SHOW_EMOTICON(target, "I_emo_petrify", buff.Duration);
			Send.ZC_NORMAL.PlayTextEffect(target, caster, AnimationName.ShowBuffText, (float)buff.Id, null);
			Send.ZC_PLAY_SOUND(target, "skl_eff_debuff_stone");

			//LeaveEffect(self, GetBuffRemainTime(buff), 'Stonize', buff.ClassName);

			if (buff.Target is Character character)
				character.SetProperty(PropertyName.Jumpable, 0);
		}

		public override void OnEnd(Buff buff)
		{
			var target = buff.Target;

			Send.ZC_SHOW_EMOTICON(target, "I_emo_petrify", System.TimeSpan.Zero);

			if (buff.Target is Character character)
				character.SetProperty(PropertyName.Jumpable, 1);
		}
	}
}
