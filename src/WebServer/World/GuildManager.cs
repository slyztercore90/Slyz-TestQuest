using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const.Web;
using Yggdrasil.Logging;

namespace Melia.Web.World
{
	public class GuildManager
	{
		private readonly Dictionary<long, GuildInfo> _guildIndexed = new Dictionary<long, GuildInfo>();
		private readonly Dictionary<long, GuildMemberInfoList> _guildMembersIndexed = new Dictionary<long, GuildMemberInfoList>();

		public void Load()
		{
			var guilds = WebServer.Instance.Database.LoadGuilds();
			foreach (var guild in guilds)
			{
				if (long.TryParse(guild.Id, out var guildId))
					this._guildIndexed.Add(guildId, guild);
			}
			Log.Info("Loaded {0} guilds from database.", guilds.Count);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="guildId"></param>
		/// <param name="members"></param>
		/// <returns></returns>
		public bool TryGetGuildMembers(long guildId, out GuildMemberInfoList members)
		{
			lock (_guildMembersIndexed)
				return _guildMembersIndexed.TryGetValue(guildId, out members);
		}
	}
}
