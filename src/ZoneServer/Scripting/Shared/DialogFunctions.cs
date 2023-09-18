using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.Scripting.Dialogues;

namespace Melia.Zone.Scripting.Shared
{
	public class DialogFunctions
	{
		protected Dictionary<string, DialogFunc> _functions = new Dictionary<string, DialogFunc>();

		public int Count => _functions.Count;

		/// <summary>
		/// Loads methods with the DialogFunctionAttribute inside this class.
		/// </summary>
		public void LoadMethods()
		{
			foreach (var method in typeof(NPCFunctions).GetMethods())
			{
				foreach (DialogFunctionAttribute attr in method.GetCustomAttributes(typeof(DialogFunctionAttribute), false))
				{
					var func = (DialogFunc)Delegate.CreateDelegate(typeof(DialogFunc), method);
					foreach (var dialog in attr.DialogIds)
						this.Add(dialog, func);
				}
			}
			foreach (var method in typeof(Triggers).GetMethods())
			{
				foreach (DialogFunctionAttribute attr in method.GetCustomAttributes(typeof(DialogFunctionAttribute), false))
				{
					var func = (DialogFunc)Delegate.CreateDelegate(typeof(DialogFunc), method);
					foreach (var dialog in attr.DialogIds)
						this.Add(dialog, func);
				}
			}
		}

		/// <summary>
		/// Sets handler for the given dialog name.
		/// </summary>
		/// <param name="dialogName"></param>
		/// <param name="func"></param>
		public void Add(string dialogName, DialogFunc func)
		{
			_functions[dialogName] = func;
		}

		public bool TryGet(string dialogName, out DialogFunc func)
		{
			return _functions.TryGetValue(dialogName, out func);
		}
	}

	/// <summary>
	/// Specifies which items an DialogFunction should be used for.
	/// </summary>
	public class DialogFunctionAttribute : Attribute
	{
		/// <summary>
		/// Returns list of ids of dialogs the script should be used for.
		/// </summary>
		public string[] DialogIds { get; }

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="dialogIds"></param>
		public DialogFunctionAttribute(params string[] dialogIds)
		{
			this.DialogIds = dialogIds;
		}
	}
}
