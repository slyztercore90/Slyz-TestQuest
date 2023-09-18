using System.Collections.Generic;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Effects;

namespace Melia.Zone.World.Actors.Components
{
	public class EffectsComponent : ActorComponent
	{
		private readonly List<Effect> _effects = new List<Effect>();

		public EffectsComponent(IActor actor) : base(actor)
		{
		}

		public void AddEffect(Effect effect)
		{
			lock (_effects)
				_effects.Add(effect);
		}

		public void ShowEffects(IZoneConnection connection)
		{
			lock (_effects)
				foreach (var effect in _effects)
					effect.ShowEffect(connection, this.Actor);
		}
	}
}
