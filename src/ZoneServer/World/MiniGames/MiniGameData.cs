using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Zone.World.MiniGames
{
	public class MiniGameData
	{
		public string Id { get; set; }
		public TimeSpan StartDelay { get; set; } = TimeSpan.Zero;
	}
}
