using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Melia.Zone.World.Tracks
{
	public class TrackData
	{
		public string Id { get; set; }
		public bool Cancelable { get; set; } = false;
		public TimeSpan StartDelay { get; set; } = TimeSpan.Zero;
	}
}
