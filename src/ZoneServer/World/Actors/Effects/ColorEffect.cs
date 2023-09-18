using Melia.Zone.Network;

namespace Melia.Zone.World.Actors.Effects
{
	public class ColorEffect : Effect
	{
		public byte Yellow { get; }
		public byte Magenta { get; }
		public byte Cyan { get; }
		public byte Alpha { get; }
		public float TransitionDuration { get; }
		public byte UnkByte { get; }
		public ColorEffect(byte yellow, byte magenta, byte cyan, byte alpha, float transitionDuration = 0, byte unkByte = 1)
		{
			Yellow = yellow;
			Magenta = magenta;
			Cyan = cyan;
			Alpha = alpha;
			TransitionDuration = transitionDuration;
			UnkByte = unkByte;
		}

		public override void ShowEffect(IZoneConnection conn, IActor actor)
		{
			Send.ZC_NORMAL.SetActorColor(conn, actor, this.Yellow, this.Magenta, this.Cyan, this.Alpha, this.TransitionDuration, this.UnkByte);
		}
	}
}
