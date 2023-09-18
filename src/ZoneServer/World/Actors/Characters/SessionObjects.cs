﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Properties;

namespace Melia.Zone.World.Actors.Characters
{
	/// <summary>
	/// Session object collection.
	/// </summary>
	public class SessionObjects
	{
		private readonly Dictionary<int, SessionObject> _objects = new Dictionary<int, SessionObject>();

		/// <summary>
		/// Get Main Session Object
		/// </summary>
		public SessionObject Main => this.GetOrCreate(SessionObjectId.Main);

		/// <summary>
		/// Adds given session object to collection.
		/// </summary>
		/// <param name="obj"></param>
		public void Add(SessionObject obj)
		{
			lock (_objects)
				_objects[obj.Id] = obj;
		}

		/// <summary>
		/// Removes session object with given id, returns false if it
		/// didn't exist.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public bool Remove(int sessionObjectId)
		{
			lock (_objects)
				return _objects.Remove(sessionObjectId);
		}

		/// <summary>
		/// Returns session object with given id, or null if it didn't
		/// exist.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public SessionObject Get(int sessionObjectId)
		{
			lock (_objects)
			{
				_objects.TryGetValue(sessionObjectId, out var obj);
				return obj;
			}
		}

		/// <summary>
		/// Returns session object with given id. If it doesn't exist,
		/// it's created.
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public SessionObject GetOrCreate(int sessionObjectId)
		{
			lock (_objects)
			{
				if (!_objects.TryGetValue(sessionObjectId, out var obj))
				{
					obj = new SessionObject(sessionObjectId);
					_objects[sessionObjectId] = obj;
				}
				return obj;
			}
		}

		/// <summary>
		/// Returns a list with all session objects.
		/// </summary>
		/// <returns></returns>
		public SessionObject[] GetList()
		{
			lock (_objects)
				return _objects.Values.ToArray();
		}


		public bool Has(string sessionObjectId)
		{
			return this.Has(PropertyTable.GetId("SessionObject", sessionObjectId));
		}

		/// <summary>
		/// Check if a session id exists
		/// </summary>
		/// <param name="sessionObjectId"></param>
		/// <returns></returns>
		public bool Has(int sessionObjectId)
		{
			lock (_objects)
				return _objects.ContainsKey(sessionObjectId);
		}
	}

	/// <summary>
	/// A session object, duh.
	/// </summary>
	/// <remarks>
	/// The exact purpose of those objects is unknown right now,
	/// but apparently they hold some properties of importance.
	/// </remarks>
	public class SessionObject : IPropertyObject
	{
		private static long ObjectIds = ObjectIdRanges.SessionObjects;

		/// <summary>
		/// The object's unique, global id.
		/// </summary>
		public long ObjectId { get; } = Interlocked.Increment(ref ObjectIds);

		/// <summary>
		/// The object's id.
		/// </summary>
		public int Id { get; }

		/// <summary>
		/// The object's properties.
		/// </summary>
		public Properties Properties { get; } = new Properties("SessionObject");

		/// <summary>
		/// Creates new instance.
		/// </summary>
		/// <param name="id"></param>
		public SessionObject(int id)
		{
			this.Id = id;
		}
	}
}
