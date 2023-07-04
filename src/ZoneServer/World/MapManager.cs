using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.World.Maps;

namespace Melia.Zone.World
{
	/// <summary>
	/// Holds and manages a list of maps.
	/// </summary>
	public class MapManager
	{
		private readonly Dictionary<int, Map> _maps = new Dictionary<int, Map>();

		/// <summary>
		/// Start of the dynamic maps id range
		/// </summary>
		public const int DynamicMaps = 35001;

		/// <summary>
		/// Returns the number of maps currently loaded.
		/// </summary>
		public int Count { get { lock (_maps) return _maps.Count; } }

		/// <summary>
		/// Adds map to the world.
		/// </summary>
		/// <param name="map"></param>
		/// <exception cref="ArgumentException">
		/// Thrown if a map with the same id as the given one
		/// already exists.
		/// </exception>
		public void Add(Map map)
		{
			lock (_maps)
			{
				if (_maps.ContainsKey(map.WorldId))
					throw new ArgumentException($"Map id {map.Id} already exists.");

				_maps.Add(map.WorldId, map);
			}
		}

		/// <summary>
		/// Removes map with given id from the world.
		/// </summary>
		/// <param name="worldMapId"></param>
		/// <exception cref="ArgumentException">
		/// Thrown if no map with the given id exists.
		/// </exception>
		public void Remove(int worldMapId)
		{
			lock (_maps)
			{
				if (!_maps.ContainsKey(worldMapId))
					throw new ArgumentException($"Map {worldMapId} doesn't exist.");

				_maps.Remove(worldMapId);
			}
		}

		/// <summary>
		/// Returns true if a map with the given id exists.
		/// </summary>
		/// <param name="worldMapId"></param>
		/// <returns></returns>
		public bool Has(int worldMapId)
		{
			lock (_maps)
				return _maps.ContainsKey(worldMapId);
		}

		/// <summary>
		/// Returns true if a map with the given id exists.
		/// </summary>
		/// <param name="mapName"></param>
		/// <returns></returns>
		public bool Has(string mapName)
		{
			lock (_maps)
				return _maps.Any(a => a.Value.Name == mapName);
		}

		/// <summary>
		/// Returns the map with the given id. Returns null if map
		/// was not found.
		/// </summary>
		/// <param name="worldMapId"></param>
		/// <returns></returns>
		public Map Get(int worldMapId)
		{
			lock (_maps)
			{
				if (!_maps.TryGetValue(worldMapId, out var map))
					return null;

				return map;
			}
		}

		/// <summary>
		/// Returns map with given id via out, returns true if the
		/// map was found and false if not. If it wasn't found,
		/// the value returned via out will be null.
		/// </summary>
		/// <param name="worldMapId"></param>
		/// <param name="map"></param>
		/// <returns></returns>
		public bool TryGet(int worldMapId, out Map map)
		{
			lock (_maps)
				return _maps.TryGetValue(worldMapId, out map);
		}

		/// <summary>
		/// Returns map with given name via out, returns true if the
		/// map was found and false if not. If it wasn't found,
		/// the value returned via out will be null.
		/// </summary>
		/// <param name="mapName"></param>
		/// <param name="map"></param>
		/// <returns></returns>
		public bool TryGet(string mapName, out Map map)
		{
			lock (_maps)
			{
				map = _maps.Values.FirstOrDefault(a => string.Compare(a.Name, mapName, true) == 0);
				return (map != null);
			}
		}

		/// <summary>
		/// Returns a list of all maps.
		/// </summary>
		/// <returns></returns>
		public Map[] GetList()
		{
			lock (_maps)
				return _maps.Values.ToArray();
		}

		/// <summary>
		/// Returns a list of all maps that match the given predicate.
		/// </summary>
		/// <param name="predicate"></param>
		/// <returns></returns>
		public Map[] GetList(Func<Map, bool> predicate)
		{
			lock (_maps)
				return _maps.Values.Where(predicate).ToArray();
		}

		/// <summary>
		/// Executes the given function an all maps.
		/// </summary>
		/// <param name="func"></param>
		public void Execute(Action<Map> func)
		{
			lock (_maps)
			{
				foreach (var map in _maps.Values)
					func(map);
			}
		}

		/// <summary>
		/// Returns a list of results queried from all maps.
		/// </summary>
		/// <typeparam name="TObj"></typeparam>
		/// <param name="func"></param>
		/// <returns></returns>
		public TObj[] ExecuteQuery<TObj>(Func<Map, IEnumerable<TObj>> func)
		{
			lock (_maps)
				return _maps.Values.SelectMany(func).ToArray();
		}

		/// <summary>
		/// Generates a new id for a dynamic map.
		/// </summary>
		/// <returns></returns>
		public int GenerateDynamicMapId()
		{
			lock (_maps)
			{
				for (var i = DynamicMaps; i < ushort.MaxValue; ++i)
				{
					if (!_maps.ContainsKey(i))
						return i;
				}
			}

			throw new Exception("No dynamic map ids available.");
		}
	}
}
