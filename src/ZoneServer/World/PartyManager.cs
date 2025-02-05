﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melia.Shared.ObjectProperties;
using Melia.Shared.Tos.Const;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;

namespace Melia.Zone.World
{
	public class PartyManager
	{
		/// <summary>
		/// Parties indexed by their id.
		/// </summary>
		private readonly Dictionary<long, Party> _parties = new Dictionary<long, Party>();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="character"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public Party Create(Character character)
		{
			var party = new Party()
			{
				LeaderDbId = character.DbId,
			};
			party.AddMember(character, true);

			ZoneServer.Instance.Database.CreateParty(party);
			Send.ZC_PARTY_INFO(character, party);
			Send.ZC_ADDON_MSG(character, AddonMessage.PARTY_JOIN, 0, "None");
			Send.ZC_PARTY_LIST(party);
			Send.ZC_NORMAL.ShowParty(character);
			this.Add(party);
			return party;
		}

		/// <summary>
		/// Removes a party and deletes it from the database.
		/// </summary>
		/// <param name="party"></param>
		public void Delete(Party party)
		{
			if (this.Remove(party.ObjectId))
				ZoneServer.Instance.Database.DeleteParty(party);
		}

		/// <summary>
		/// Adds party to the manager.
		/// </summary>
		/// <param name="party"></param>
		/// <exception cref="ArgumentException">
		/// Thrown if a party with the same id as the given one
		/// already exists.
		/// </exception>
		public void Add(Party party)
		{
			lock (_parties)
			{
				if (_parties.ContainsKey(party.ObjectId))
					throw new ArgumentException($"Party id {party.ObjectId} already exists.");

				_parties.Add(party.ObjectId, party);
			}
		}

		/// <summary>
		/// Removes the party with given id from the manager.
		/// </summary>
		/// <param name="partyId"></param>
		/// <exception cref="ArgumentException">
		/// Thrown if no party with the given id exists.
		/// </exception>
		public bool Remove(long partyId)
		{
			if (partyId < ObjectIdRanges.Party)
				partyId += ObjectIdRanges.Party;

			lock (_parties)
			{
				if (!_parties.ContainsKey(partyId))
					throw new ArgumentException($"Party {partyId} doesn't exist.");

				return _parties.Remove(partyId);
			}
		}

		/// <summary>
		/// Checks if a party exists with given id in the manager.
		/// </summary>
		/// <param name="partyId"></param>
		/// <returns>True if the party exists</returns>
		public bool Exists(long partyId)
		{
			if (partyId < ObjectIdRanges.Party)
				partyId += ObjectIdRanges.Party;

			lock (_parties)
			{
				return _parties.ContainsKey(partyId);
			}
		}

		/// <summary>
		/// Find party by id or null if it doesn't exist
		/// </summary>
		/// <param name="partyId"></param>
		/// <returns></returns>
		public Party GetParty(long partyId)
		{
			if (partyId < ObjectIdRanges.Party)
				partyId += ObjectIdRanges.Party;

			lock (_parties)
			{
				if (_parties.ContainsKey(partyId))
					return _parties[partyId];
			}
			return null;
		}
	}
}
