namespace Melia.Shared.Tos.Const
{
	/// <summary>
	/// Defines a NPC's state.
	/// </summary>
	public enum NpcState
	{
		/// <summary>
		/// Used for opened chests, when they disappear.
		/// </summary>
		Invisible = -1,

		/// <summary>
		/// Presumed default state.
		/// </summary>
		Normal = 0,

		/// <summary>
		/// Make's NPC visible on the minimap
		/// </summary>
		Highlighted = 1,
	}
}
