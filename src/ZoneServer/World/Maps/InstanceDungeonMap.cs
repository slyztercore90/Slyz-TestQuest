using Melia.Zone.World.Dungeons;

namespace Melia.Zone.World.Maps
{
	public class InstanceDungeonMap : DynamicMap
	{
		public InstanceDungeon InstanceDungeon { get; set; }

		public InstanceDungeonMap(InstanceDungeon indun) : base(indun.MapId)
		{
			this.InstanceDungeon = indun;
			this.Load();
		}

		private void Load()
		{

		}
	}
}
