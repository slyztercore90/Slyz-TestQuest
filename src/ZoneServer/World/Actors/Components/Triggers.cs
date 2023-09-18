using System;
using System.Collections.Generic;
using Melia.Zone.World.Actors.Characters;
using Yggdrasil.Composition;
using Yggdrasil.Geometry;
using Yggdrasil.Scheduling;

namespace Melia.Zone.World.Actors.Components
{
	public enum TriggerType
	{
		Enter,
		Inside,
		Outside,
		Leave,
	}

	public class Triggers : ActorComponent, IUpdateable
	{
		private readonly Dictionary<string, Trigger> _triggers = new Dictionary<string, Trigger>();

		public Triggers(IActor actor) : base(actor)
		{
		}

		/// <summary>
		/// Trigger
		/// </summary>
		public class Trigger
		{
			public Trigger(TriggerType type, IShapeF shape, Action<Character> function)
			{
				this.Type = type;
				this.Shape = shape;
				this.Function = function;
			}
			public TriggerType Type { get; private set; }
			public IShapeF Shape { get; private set; }

			public Action<Character> Function { get; }
		}

		/// <summary>
		/// Add a lambda function to run if character is inside a shape
		/// </summary>
		/// <param name="name"></param>
		/// <param name="shape"></param>
		/// <param name="function"></param>
		public void Add(string name, TriggerType type, IShapeF shape, Action<Character> function)
		{
			lock (_triggers)
				_triggers.Add(name, new Trigger(type, shape, function));
		}

		/// <summary>
		/// Update Trigger Events
		/// </summary>
		/// <param name="elapsed"></param>
		public void Update(TimeSpan elapsed)
		{
			lock (_triggers)
			{
				if (_triggers.Count == 0 || this.Actor.Map.CharacterCount == 0)
					return;
				foreach (var trigger in _triggers.Values)
				{
					if (trigger.Shape != null)
					{
						switch (trigger.Type)
						{
							case TriggerType.Enter:
							case TriggerType.Inside:
							{
								foreach (var character in this.Actor.Map.GetCharactersInside(trigger.Shape))
								{
									trigger.Function?.Invoke(character);
								}
							}
							break;
							case TriggerType.Leave:
							case TriggerType.Outside:
							{
								foreach (var character in this.Actor.Map.GetCharactersOutside(trigger.Shape))
								{
									trigger.Function?.Invoke(character);
								}
							}
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Check if a trigger exists
		/// </summary>
		/// <param name="triggerId"></param>
		/// <returns></returns>
		public bool Has(string triggerId)
		{
			lock (_triggers)
				return _triggers.ContainsKey(triggerId);
		}

		/// <summary>
		/// Remove a trigger
		/// </summary>
		/// <param name="triggerId"></param>
		/// <returns></returns>
		public bool Remove(string triggerId)
		{
			lock (_triggers)
				return _triggers.Remove(triggerId);
		}
	}
}
