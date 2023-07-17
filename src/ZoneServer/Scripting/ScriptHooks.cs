using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Zone.Scripting
{
	/// <summary>
	/// Manages hooks used by scripts.
	/// </summary>
	public static class ScriptHook
	{
		private static readonly Dictionary<string, List<ScriptHookFunc>> Hooks = new Dictionary<string, List<ScriptHookFunc>>();

		/// <summary>
		/// Adds a hook callback function that will be called Run is called
		/// for the given identifiers.
		/// </summary>
		/// <param name="ownerName"></param>
		/// <param name="hookName"></param>
		/// <param name="func"></param>
		public static void Add(string ownerName, string hookName, ScriptHookFunc func)
		{
			var ident = ownerName + "\0::\0" + hookName;

			lock (Hooks)
			{
				if (!Hooks.TryGetValue(ident, out var hooks))
					Hooks.Add(ident, hooks = new List<ScriptHookFunc>());

				Hooks[ident].Add(func);
			}
		}

		/// <summary>
		/// Iterates over the hook functions for the given identifiers
		/// and returns whether a hook returned Break, indicating that a
		/// hook occured.
		/// </summary>
		/// <param name="ownerName"></param>
		/// <param name="hookName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static async Task<bool> Run(string ownerName, string hookName, params object[] args)
		{
			var ident = ownerName + "\0::\0" + hookName;

			ScriptHookFunc[] hooks;
			lock (Hooks)
			{
				if (!Hooks.TryGetValue(ident, out var hookFuncs))
					return false;

				hooks = hookFuncs.ToArray();
			}

			foreach (var hook in hooks)
			{
				var result = await hook(args);
				switch (result)
				{
					case HookResult.Continue: continue;
					case HookResult.Break: return true;
				}
			}

			return false;
		}
	}

	/// <summary>
	/// A function that can be used in a hook.
	/// </summary>
	/// <param name="args"></param>
	/// <returns></returns>
	public delegate Task<HookResult> ScriptHookFunc(params object[] args);

	/// <summary>
	/// Specifies what a hook wants to happen after it was run.
	/// </summary>
	public enum HookResult
	{
		/// <summary>
		/// Continue executing the remaining hooks.
		/// </summary>
		Continue,

		/// <summary>
		/// Stop executing hooks and return to the caller.
		/// </summary>
		Break,
	}
}
