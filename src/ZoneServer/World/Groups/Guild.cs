﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Shared.Util;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Groups;

namespace Melia.Zone.World
{
	/// <summary>
	/// Guild is a party in ToS
	/// </summary>
	public class Guild : Party
	{
		/// <summary>
		/// The guild's unique id.
		/// </summary>
		public new long ObjectId => ObjectIdRanges.Guild + this.DbId;

		/// <summary>
		/// The guild's party type.
		/// </summary>
		public override PartyType Type => PartyType.Guild;

		public new Properties Properties { get; set; } = new Properties("Guild");

		/// <summary>
		/// The guild's level.
		/// </summary>
		public int Level { get; set; }

		public void Join(Character character)
		{
			var account = character.Connection.Account;
			var properties = account.Properties;
			properties.SetFloat(PropertyName.EVENT_IS_JOINED_GUILD, 1);
			Send.ZC_NORMAL.AccountProperties(character, PropertyName.EVENT_IS_JOINED_GUILD);
			this.AddMember(character);
		}

		/// <summary>
		/// Add a guild member and Send to Party Packets Client
		/// ZC_PARTY_INFO, ZC_PARTY_LIST, ZC_PARTY_ENTER, 
		/// ZC_ADDON_MSG, ZC_UPDATE_ALL_STATUS
		/// </summary>
		/// <param name="character"></param>
		/// <param name="silently"></param>
		public override void AddMember(Character character, bool silently = false)
		{
			var member = PartyMember.ToMember(character);

			if (!this.AddMember(member))
				return;

			character.Connection.Guild = this;
			if (!silently)
			{
				Send.ZC_PARTY_INFO(character, this);
				Send.ZC_PARTY_LIST(this);
				Send.ZC_ADDON_MSG(character, AddonMessage.PARTY_JOIN);
				Send.ZC_PARTY_LIST(this);
				Send.ZC_NORMAL.ShowParty(character);
				//Send.ZC_GUILD_COOLDOWN_LIST(character);
			}
		}

		/// <summary>
		/// Remove a guild member and send ZC_PARTY_OUT to guild members
		/// </summary>
		/// <param name="character"></param>
		public override void RemoveMember(Character character)
		{
			base.RemoveMember(character);
			var properties = character.Connection.Account.Properties;
			properties.SetFloat(PropertyName.EVENT_IS_JOINED_GUILD, 0);
			Send.ZC_NORMAL.AccountProperties(character, PropertyName.EVENT_IS_JOINED_GUILD);
			properties.SetString(PropertyName.LastServerGuildOutDay, DateTimeUtils.ToSPropertyDTNow);
			Send.ZC_NORMAL.AccountProperties(character, PropertyName.LastServerGuildOutDay);
			character.Connection.Guild = null;
		}
	}
}
