using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Shared.World;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Houses;

namespace Melia.Zone.World.Maps
{
	public class PersonalHouseMap : DynamicMap
	{
		public PersonalHouse House { get; set; }

		public PersonalHouseMap(PersonalHouse house) : base(house.MapId)
		{
			this.House = house;
			this.Load();
		}

		/// <summary>
		/// Loads the map's data.
		/// </summary>
		private void Load()
		{
			var monster = new Mob(3010001, MonsterType.NPC);
			var dir = CardinalDirection.South;
			monster.Position = new Position(-40f, 0f, 140f);
			monster.Direction = Direction.FromCardinalDirection(dir);
			monster.DialogName = "PERSONAL_HOUSING_OBJ_BARRACK_06_CHAIR_1";
			//monster.Talk = NpcFunctions.PERSONAL_HOUSING_OBJ_BARRACK_06_CHAIR_1;
			foreach (var prop in this.House.Props)
			{
				monster = new Mob(prop.MonsterId, MonsterType.NPC);
				monster.Position = prop.Position;
				monster.Direction = prop.Direction;
				monster.IsProp = true;
				this.AddMonster(monster);
				prop.Handle = monster.Handle;
			}
		}
	}
}
