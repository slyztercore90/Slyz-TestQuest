using Yggdrasil.Composition;

namespace Melia.Zone.World.Actors.Components
{
	public abstract class ActorComponent : IComponent
	{
		/// <summary>
		/// Returns the owner of this component.
		/// </summary>
		public IActor Actor { get; }

		/// <summary>
		/// Initializes component's properties.
		/// </summary>
		/// <param name="actor"></param>
		public ActorComponent(IActor actor)
		{
			this.Actor = actor;
		}
	}
}
