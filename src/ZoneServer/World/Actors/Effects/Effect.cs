using Melia.Zone.Network;

namespace Melia.Zone.World.Actors.Effects
{
	public abstract class Effect
	{
		/// <summary>
		/// Show's an effect to a specific connection
		/// </summary>
		/// <param name="conn"></param>
		/// <param name="actor"></param>
		/// <returns></returns>
		public abstract void ShowEffect(IZoneConnection conn, IActor actor);
	}
}
