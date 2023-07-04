using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.Scripting
{
	/// <summary>
	/// Track script manager.
	/// </summary>
	public static class TrackScripts
	{

		private static readonly Dictionary<string, TrackScriptFunc> Scripts = new Dictionary<string, TrackScriptFunc>();

		/// <summary>
		/// Registers the given function as the handler for the script name.
		/// </summary>
		/// <param name="scriptFuncName"></param>
		/// <param name="scriptFunc"></param>
		public static void Register(string scriptFuncName, TrackScriptFunc scriptFunc)
		{
			lock (Scripts)
				Scripts[scriptFuncName] = scriptFunc;
		}

		/// <summary>
		/// Returns the handler function for the given script via out,
		/// returns false if no script was defined.
		/// </summary>
		/// <param name="scriptName"></param>
		/// <param name="scriptFunc"></param>
		/// <returns></returns>
		public static bool TryGet(string scriptName, out TrackScriptFunc scriptFunc)
		{
			lock (Scripts)
				return Scripts.TryGetValue(scriptName, out scriptFunc);
		}

		/// <summary>
		/// Loads handler methods on the given object.
		/// </summary>
		/// <param name="obj"></param>
		public static void Load(object obj)
		{
			foreach (var method in obj.GetType().GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
			{
				foreach (var attribute in method.GetCustomAttributes<TrackScriptAttribute>(false))
				{
					var func = (TrackScriptFunc)Delegate.CreateDelegate(typeof(TrackScriptFunc), obj, method);
					Register(attribute.ScriptFuncName, func);
				}
			}
		}
	}

	/// <summary>
	/// Used to mark a method as a dialog transcription script handler.
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class TrackScriptAttribute : Attribute
	{
		/// <summary>
		/// Returns the name of the script that is handled by the function.
		/// </summary>
		public string ScriptFuncName { get; }

		/// <summary>
		/// Creates new attribute.
		/// </summary>
		/// <param name="scriptFuncName"></param>
		public TrackScriptAttribute(string scriptFuncName)
		{
			this.ScriptFuncName = scriptFuncName;
		}
	}

	/// <summary>
	/// A function that handles a transaction.
	/// </summary>
	/// <param name="character"></param>
	/// <param name="dialog"></param>
	/// <returns></returns>
	public delegate TrackResult TrackScriptFunc(Character character, Dialog dialog);

	/// <summary>
	/// Specifies the result of the transaction.
	/// </summary>
	public enum TrackResult
	{
		/// <summary>
		/// The transaction was successful.
		/// </summary>
		Completed,

		/// <summary>
		/// The transaction failed.
		/// </summary>
		Failed,
	}
}
