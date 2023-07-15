using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Melia.Shared.Configuration.Files;
using Melia.Shared.L10N;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.Commands;
using Melia.Zone.Network;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Components;
using Melia.Zone.World.Actors.Monsters;
using Yggdrasil.Extensions;
using Yggdrasil.Geometry;
using Yggdrasil.Geometry.Shapes;
using Yggdrasil.Util;

namespace Melia.Zone.Scripting
{
	public static class Shortcuts
	{
		/// <summary>
		/// A function that initializes a shop.
		/// </summary>
		/// <param name="shop"></param>
		public delegate void ShopCreationFunc(ShopBuilder shop);

		/// <summary>
		/// Returns an option element, to be used with the Menu function.
		/// </summary>
		/// <param name="text">Text to display in the menu.</param>
		/// <param name="key">Key to return if the option was selected.</param>
		/// <returns></returns>
		public static DialogOption Option(string text, string key)
			=> new DialogOption(text, key);

		/// <summary>
		/// Returns a localized version of the given string.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string L(string key)
			=> Localization.Get(key);

		/// <summary>
		/// Returns a localized version of the given string, formatted
		/// with the optional arguments.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static string LF(string key, params object[] args)
			=> string.Format(Localization.Get(key), args);

		/// <summary>
		/// Returns a localized plural version of the given string.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="keyPlural"></param>
		/// <param name="n"></param>
		/// <returns></returns>
		public static string LN(string key, string keyPlural, int n)
			=> Localization.GetPlural(key, keyPlural, n);

		/// <summary>
		/// Returns a localized plural version of the given string,
		/// formatted with the optional arguments.
		/// </summary>
		/// <param name="key"></param>
		/// <param name="keyPlural"></param>
		/// <param name="n"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		public static string LNF(string key, string keyPlural, int n, params object[] args)
			=> string.Format(Localization.GetPlural(key, keyPlural, n), args);

		/// <summary>
		/// Adds new NPC to the world.
		/// </summary>
		/// <param name="monsterId"></param>
		/// <param name="name"></param>
		/// <param name="map"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <param name="direction"></param>
		/// <param name="dialog"></param>
		/// <exception cref="ArgumentException"></exception>
		public static Npc AddNpc(int monsterId, string name, string map, double x, double z, double direction, DialogFunc dialog = null)
		{
			if (!ZoneServer.Instance.World.TryGetMap(map, out var mapObj))
				throw new ArgumentException($"Map '{map}' not found.");

			var pos = new Position((float)x, 0, (float)z);
			if (mapObj.Ground.TryGetHeightAt(pos, out var height))
				pos.Y = height;

			// Wrap name in localization code if applicable
			if (Dialog.IsLocalizationKey(name))
			{
				name = Dialog.WrapLocalizationKey(name);
			}
			// Insert line breaks in tagged NPC names that don't have one
			else if (name.StartsWith("[") && !name.Contains("{nl}"))
			{
				var endIndex = name.LastIndexOf("] ");
				if (endIndex != -1)
				{
					// Remove space and insert new line instead.
					name = name.Remove(endIndex + 1, 1);
					name = name.Insert(endIndex + 1, "{nl}");
				}
			}

			var location = new Location(mapObj.Id, pos);
			var dir = new Direction(direction);

			var monster = new Npc(monsterId, name, location, dir);

			if (dialog != null)
				monster.SetClickTrigger("DYNAMIC_DIALOG", dialog);

			mapObj.AddMonster(monster);

			return monster;
		}

		/// <summary>
		/// Adds new NPC to the world.
		/// </summary>
		/// <param name="monsterId"></param>
		/// <param name="name"></param>
		/// <param name="map"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <param name="direction"></param>
		/// <param name="dialogFuncName"></param>
		/// <exception cref="ArgumentException"></exception>
		public static Npc AddNpc(int monsterId, string name, string map, double x, double z, double direction, string dialogFuncName, string enterFuncName = "", string leaveFuncName = "", double range = 100)
		{
			if (!ZoneServer.Instance.World.TryGetMap(map, out var mapObj))
				throw new ArgumentException($"Map '{map}' not found.");

			var pos = new Position((float)x, 0, (float)z);
			if (mapObj.Ground.TryGetHeightAt(pos, out var height))
				pos.Y = height;

			// Wrap name in localization code if applicable
			if (Dialog.IsLocalizationKey(name))
			{
				name = Dialog.WrapLocalizationKey(name);
			}
			// Insert line breaks in tagged NPC names that don't have one
			else if (name.StartsWith("[") && !name.Contains("{nl}"))
			{
				var endIndex = name.LastIndexOf("] ");
				if (endIndex != -1)
				{
					// Remove space and insert new line instead.
					name = name.Remove(endIndex + 1, 1);
					name = name.Insert(endIndex + 1, "{nl}");
				}
			}

			var location = new Location(mapObj.Id, pos);
			var dir = new Direction(direction);
			ZoneServer.Instance.DialogFunctions.TryGet(dialogFuncName, out var dialog);
			ZoneServer.Instance.DialogFunctions.TryGet(enterFuncName, out var enter);
			ZoneServer.Instance.DialogFunctions.TryGet(leaveFuncName, out var leave);

			var monster = new Npc(monsterId, name, location, dir);
			if (dialog != null)
				monster.SetClickTrigger(dialogFuncName, dialog);
			if (enter != null || leave != null)
			{
				monster.SetTriggerArea(Spot(monster.Position.X, monster.Position.Z, range));
			}
			if (enter != null)
			{
				monster.SetEnterTrigger(enterFuncName, enter);
				/**
				monster.Triggers.Add("EnterHook", TriggerType.Enter, Spot(monster.Position.X, monster.Position.Z, range), character =>
				{
					if (character.Triggers.Has(monster.LeaveName + "_LeaveHook"))
						character.Triggers.Remove(monster.LeaveName + "_LeaveHook");
					if (!character.Triggers.Has(monster.EnterName + "_EnterHook"))
					{
						character.Triggers.Add(monster.EnterName + "_EnterHook", TriggerType.Enter, null, null);
						Send.ZC_ENTER_HOOK(character, monster.ClassId);
						monster.OnEnterFunc.Invoke(new Dialog(character, monster));
					}
				});
				**/
			}
			if (leave != null)
			{
				monster.SetLeaveTrigger(leaveFuncName, leave);
				/**
				monster.Triggers.Add("LeaveHook", TriggerType.Leave, Spot(monster.Position.X, monster.Position.Z, range), character =>
				{
					if (!character.Triggers.Has(monster.EnterName + "_LeaveHook") && character.Triggers.Has(monster.EnterName + "_EnterHook"))
					{
						character.Triggers.Remove(monster.EnterName + "_EnterHook");
						character.Triggers.Add(monster.LeaveName + "_LeaveHook", TriggerType.Leave, null, null);
						Send.ZC_LEAVE_HOOK(character, monster.ClassId);
						monster.OnLeaveFunc.Invoke(new Dialog(character, monster));
					}
				});
				**/
			}

			mapObj.AddMonster(monster);

			return monster;
		}

		/// <summary>
		/// Creates a warp.
		/// </summary>
		/// <param name="warpName"></param>
		/// <param name="direction"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <returns></returns>
		public static WarpMonster AddWarp(string warpName, double direction, Location from, Location to)
		{
			if (!ZoneServer.Instance.World.TryGetMap(from.MapId, out var fromMap))
				throw new ArgumentException($"Map '{from.MapId}' not found.");

			if (!ZoneServer.Instance.World.TryGetMap(to.MapId, out var toMap))
				throw new ArgumentException($"Map '{to.MapId}' not found.");

			var targetLocationName = Localization.Get(toMap.Data.Name);

			var monster = new WarpMonster(warpName, targetLocationName, from, to, new Direction(direction));
			fromMap.AddMonster(monster);

			return monster;
		}

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassName"></param>
		/// <param name="maxAmount"></param>
		/// <param name="respawn"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(string monsterClassName, int maxAmount, TimeSpan respawn, string map, IShapeF area)
		{
			if (!ZoneServer.Instance.Data.MonsterDb.TryFind(a => a.ClassName == monsterClassName, out var monsterData))
				throw new ArgumentException($"Monster '{monsterClassName}' not found.");

			return AddSpawner(monsterData.Id, maxAmount, respawn, map, area, TendencyType.Peaceful, null);
		}

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassId"></param>
		/// <param name="maxAmount"></param>
		/// <param name="respawn"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(int monsterClassId, int maxAmount, TimeSpan respawn, string map, IShapeF area)
			=> AddSpawner(monsterClassId, maxAmount, respawn, map, area, TendencyType.Peaceful, null);

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassId"></param>
		/// <param name="maxAmount"></param>
		/// <param name="respawn"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <param name="tendency"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(int monsterClassId, int maxAmount, TimeSpan respawn, string map, IShapeF area, TendencyType tendency)
			=> AddSpawner(monsterClassId, maxAmount, respawn, map, area, tendency, null);

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassId"></param>
		/// <param name="maxAmount"></param>
		/// <param name="respawn"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <param name="propertyOverrides"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(int monsterClassId, int maxAmount, TimeSpan respawn, string map, IShapeF area, PropertyOverrides propertyOverrides)
			=> AddSpawner(monsterClassId, maxAmount, respawn, map, area, TendencyType.Peaceful, propertyOverrides);

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassId"></param>
		/// <param name="maxAmount"></param>
		/// <param name="respawn"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <param name="tendency"></param>
		/// <param name="propertyOverrides"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(int monsterClassId, int maxAmount, TimeSpan respawn, string map, IShapeF area, TendencyType tendency, PropertyOverrides propertyOverrides)
		{
			var initialSpawnDelay = TimeSpan.FromSeconds(0);
			var minRespawnDelay = Math2.Max(TimeSpan.FromSeconds(3), respawn);
			var maxRespawnDelay = minRespawnDelay.Multiply(3);
			var minAmount = Math.Max(1, (int)(maxAmount * 0.10));

			return AddSpawner(monsterClassId, minAmount, maxAmount, initialSpawnDelay, minRespawnDelay, maxRespawnDelay, map, area, tendency, propertyOverrides);
		}

		/// <summary>
		/// Adds monster spawner to the world.
		/// </summary>
		/// <param name="monsterClassId"></param>
		/// <param name="minAmount"></param>
		/// <param name="maxAmount"></param>
		/// <param name="initialSpawnDelay"></param>
		/// <param name="minRespawnDelay"></param>
		/// <param name="maxRespawnDelay"></param>
		/// <param name="map"></param>
		/// <param name="area"></param>
		/// <param name="tendency"></param>
		/// <param name="propertyOverrides"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static MonsterSpawner AddSpawner(int monsterClassId, int minAmount, int maxAmount, TimeSpan initialSpawnDelay, TimeSpan minRespawnDelay, TimeSpan maxRespawnDelay, string map, IShapeF area, TendencyType tendency, PropertyOverrides propertyOverrides)
		{
			if (!ZoneServer.Instance.World.TryGetMap(map, out var mapObj))
				throw new ArgumentException($"Map '{map}' not found.");

			var spawner = new MonsterSpawner(monsterClassId, minAmount, maxAmount, map, area, initialSpawnDelay, minRespawnDelay, maxRespawnDelay, tendency, propertyOverrides);
			mapObj.AddSpawner(spawner);

			return spawner;
		}

		/// <summary>
		/// Adds an override for the properties of a monster on a specific
		/// map. These override the stats of monsters spawned via spawners
		/// if no property overrides are specified for the spawner itself.
		/// </summary>
		/// <param name="mapClassName"></param>
		/// <param name="monsterClassId"></param>
		/// <param name="propertyOverrides"></param>
		/// <returns></returns>
		public static void AddPropertyOverrides(string mapClassName, int monsterClassId, PropertyOverrides propertyOverrides)
		{
			if (!ZoneServer.Instance.World.TryGetMap(mapClassName, out var map))
				throw new ArgumentException($"Map '{mapClassName}' not found.");

			map.AddPropertyOverrides(monsterClassId, propertyOverrides);
		}

		/// <summary>
		/// Returns a polygonal shape made up of the given coordinates.
		/// </summary>
		/// <param name="coordinates">Evenly numbered list of at least 3 X and Y coordinates.</param>
		/// <returns></returns>
		/// <example>
		/// Area(0, 0, 0, 10, 10, 10, 10, 0) // 10x10 square
		/// </example>
		public static IShapeF Area(params double[] coordinates)
		{
			if (coordinates.Length == 0 || coordinates.Length % 2 != 0)
				throw new ArgumentException("Expected an even amount of coordinates for area.");

			if (coordinates.Length < 3)
				throw new ArgumentException("Needs at least 3 points (6 X/Y coordinates).");

			var points = new List<Vector2F>();
			for (var i = 0; i < coordinates.Length;)
			{
				var point = new Vector2F((int)coordinates[i++], (int)coordinates[i++]);
				points.Add(point);
			}

			return new PolygonF(points);
		}

		/// <summary>
		/// Returns a circular shape with the given coordinates and radius.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <param name="radius"></param>
		/// <returns></returns>
		public static IShapeF Spot(double x, double z, double radius = 0)
		{
			var center = new Vector2F((int)x, (int)z);
			return new CircleF(center, (int)radius);
		}

		/// <summary>
		/// Returns a rectangle centered at the given coordinates, height and width.
		/// If width is set to 0 returns a square.
		/// </summary>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <param name="height"></param>
		/// <param name="width"></param>
		/// <returns></returns>
		public static IShapeF Rectangle(double x, double z, double height, double width = 0)
		{
			var center = new Vector2F((float)x, (float)z);
			var size = new Vector2F((float)height, (float)(width != 0 ? width : height));
			return Yggdrasil.Geometry.Shapes.RectangleF.Centered(center, size);
		}

		/// <summary>
		/// Returns a list of named properties based on a list of key/value
		/// pairs.
		/// </summary>
		/// <example>
		/// Properties("MHP", 1000, "EXP", 5) // { "MHP": 1000, "EXP": 5 }
		/// </example>
		/// <param name="properties"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		public static PropertyOverrides Properties(params object[] properties)
		{
			var result = new PropertyOverrides();

			if (properties.Length % 2 != 0)
				throw new ArgumentException("Expected an even amount of arguments for key/value pairs.");

			for (var i = 0; i < properties.Length; i += 2)
			{
				var propertyNameObj = properties[i];
				var propertyValueObj = properties[i + 1];

				if (!(propertyNameObj is string propertyName))
					throw new ArgumentException($"Expected a string for key, got '{propertyValueObj.GetType().Name}'.");

				switch (propertyValueObj)
				{
					case int _:
					case float _:
					case string _:
						result[propertyName] = propertyValueObj;
						break;

					default:
						throw new ArgumentException($"Expected an int, float or string for value, got '{propertyValueObj.GetType().Name}'.");
				}
			}

			return result;
		}

		/// <summary>
		/// Returns a full location object from the given map and coordinates.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static Location From(string map, double x, double z)
			=> GetLocation(map, x, z);

		/// <summary>
		/// Returns a full location object from the given map and coordinates.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		public static Location To(string map, double x, double z)
			=> GetLocation(map, x, z);

		/// <summary>
		/// Returns a full location object from the given map and coordinates.
		/// </summary>
		/// <param name="map"></param>
		/// <param name="x"></param>
		/// <param name="z"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentException"></exception>
		private static Location GetLocation(string map, double x, double z)
		{
			if (!ZoneServer.Instance.World.TryGetMap(map, out var mapObj))
				throw new ArgumentException($"Map '{map}' not found.");

			var pos = new Position((float)x, 0, (float)z);
			if (mapObj.Ground.TryGetHeightAt(pos, out var height))
				pos.Y = height;

			return new Location(mapObj.Id, pos);
		}

		/// <summary>
		/// Creates a custom shop.
		/// </summary>
		/// <param name="name"></param>
		/// <param name="creationFunc"></param>
		public static void CreateShop(string name, ShopCreationFunc creationFunc)
		{
			var shopBuilder = new ShopBuilder(name);
			creationFunc(shopBuilder);

			// TODO: Not a big fan of dynamically modifying the data.
			//   Perhaps we should create shop objects based on the
			//   data and add to that, where we could also do more
			//   things without poluting the data classes.

			var shopData = shopBuilder.Build();
			ZoneServer.Instance.Data.ShopDb.AddOrReplace(shopData.Name, shopData);
		}

		/// <summary>
		/// Returns a random number between 0 and max - 1.
		/// </summary>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int Random(int max)
		{
			return RandomProvider.Next(max);
		}

		/// <summary>
		/// Returns a random number between min and max - 1.
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		public static int Random(int min, int max)
		{
			return RandomProvider.Next(min, max);
		}

		/// <summary>
		/// Plays chest opening animations and makes the chest disappear.
		/// Returns after the animation played and the chest's contents
		/// can be distributed.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="npc"></param>
		/// <returns></returns>
		public static async Task OpenChest(Character character, Npc npc)
		{
			//if (character.Help.NotSeen(34))
			//	Send.ZC_HELP_ADD(character, 34, 1);

			// Play animations for character to kick open the chest
			Send.ZC_PLAY_ANI(character, AnimationName.KickBox);
			Send.ZC_PLAY_ANI(npc, AnimationName.Opened, true);

			// Wait a second, so the animations can play
			await Task.Delay(1000);

			// Make chest disappear
			Send.ZC_NORMAL.FadeOut(npc, TimeSpan.FromSeconds(4));
			npc.SetState(NpcState.Invisible);

			// Make chest reappear after a certain amount of time
			// TODO: Add timer component, to set up and associate timers
			//   and intervals with entities.
			_ = Task.Delay(TimeSpan.FromMinutes(1)).ContinueWith(_ => npc.SetState(NpcState.Normal));
		}

		/// <summary>
		/// Adds or overrides a command, making it available to players
		/// who have the given authority levels.
		/// </summary>
		/// <param name="command"></param>
		/// <param name="usage"></param>
		/// <param name="description"></param>
		/// <param name="auth"></param>
		/// <param name="targetAuth"></param>
		/// <param name="func"></param>
		public static void AddChatCommand(string command, string usage, string description, int auth, int targetAuth, ChatCommandFunc func)
		{
			ZoneServer.Instance.ChatCommands.Add(command, usage, description, func);
			ZoneServer.Instance.Conf.Commands.CommandLevels[command] = new CommandAuthLevels(auth, targetAuth);
		}

		/// <summary>
		/// Returns a random element from the array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="values"></param>
		/// <returns></returns>
		public static T RandomElement<T>(params T[] values)
		{
			return values[RandomProvider.Next(values.Length)];
		}
	}

	/// <summary>
	/// A list of properties that can be used to override default values
	/// for spawned monsters.
	/// </summary>
	public class PropertyOverrides : Dictionary<string, object>
	{
	}
}
