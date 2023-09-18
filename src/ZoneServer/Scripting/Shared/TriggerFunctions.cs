﻿using System;
using System.Collections.Generic;
using Melia.Zone.Scripting.Dialogues;

namespace Melia.Zone.Scripting.Shared
{
	public class TriggerFunctions
	{
		protected Dictionary<string, DialogFunc> _functions = new Dictionary<string, DialogFunc>();

		public int Count => _functions.Count;

		/// <summary>
		/// Loads methods with the DialogFunctionAttribute inside this class.
		/// </summary>
		public void LoadMethods()
		{
			foreach (var method in typeof(TriggerFunctions).GetMethods())
			{
				foreach (TriggerFunctionAttribute attr in method.GetCustomAttributes(typeof(TriggerFunctionAttribute), false))
				{
					var func = (DialogFunc)Delegate.CreateDelegate(typeof(DialogFunc), method);
					foreach (var dialog in attr.DialogIds)
						this.Add(dialog, func);
				}
			}
			foreach (var method in typeof(Triggers).GetMethods())
			{
				foreach (TriggerFunctionAttribute attr in method.GetCustomAttributes(typeof(TriggerFunctionAttribute), false))
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
	/// Specifies which triggers a TriggerFunction should be used for.
	/// </summary>
	public class TriggerFunctionAttribute : Attribute
	{
		/// <summary>
		/// Returns list of ids of dialogs the script should be used for.
		/// </summary>
		public string[] DialogIds { get; }

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="dialogIds"></param>
		public TriggerFunctionAttribute(params string[] dialogIds)
		{
			this.DialogIds = dialogIds;
		}
	}
}
