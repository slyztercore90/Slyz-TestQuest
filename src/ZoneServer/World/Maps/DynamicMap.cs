using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Zone.World.Maps
{
	public class DynamicMap : Map
	{
		public DynamicMap(int id, string name = null) : base(id, name)
		{
			this.WorldId = ZoneServer.Instance.World.GenerateDynamicMapId();
			this.Name = name ?? "DynamicMap" + this.Id;
		}
	}
}
