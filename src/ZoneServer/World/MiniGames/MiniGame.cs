using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Zone.World.Actors;

namespace Melia.Zone.World.MiniGames
{
	public class MiniGame
	{
		List<Stage> _stages = new List<Stage>();

		public Stage ActiveStage { get; set; }

		public IList<IActor> Actors => this.ActiveStage.Actors;
	}

	public class Stage
	{
		public IList<IActor> Actors { get; set; }
	}
}
