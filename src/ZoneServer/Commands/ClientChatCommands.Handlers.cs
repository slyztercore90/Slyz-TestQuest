using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Melia.Shared.Network;
using Melia.Shared.Tos.Const;
using Melia.Shared.Tos.Properties;
using Melia.Shared.Util;
using Melia.Zone.Network;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Actors.Characters.Components;
using Melia.Zone.World.Actors.Monsters;
using Melia.Zone.World.Items;
using Yggdrasil.Logging;
using Yggdrasil.Util.Commands;
using Yggdrasil.Extensions;

namespace Melia.Zone.Commands
{
	/// <summary>
	/// The dedicated chat command manager for chat commands sent by clients
	/// (usually from from behind the scenes).
	/// </summary>
	public partial class ClientChatCommands : CommandManager<ClientChatCommand, ClientChatCommandFunc>
	{
		/// <summary>
		/// Initializes commands.
		/// </summary>
		public ClientChatCommands()
		{
			// Official
			this.Add("requpdateequip", "", "", this.HandleReqUpdateEquip);
			this.Add("buyabilpoint", "<amount>", "", this.HandleBuyAbilPoint);
			this.Add("guildexpup", "", "", this.HandleGuildExpUp);
			this.Add("retquest", "<quest id>", "", this.HandleReturnToQuestGiver);
			this.Add("intewarp", "<warp id> 0", "", this.HandleInteWarp);
			this.Add("partyname", "0 0 <account id> <party name>", "", this.HandlePartyName);
			this.Add("partymake", "<partyName>", "", this.HandlePartyMake);
			this.Add("partyDirectInvite", "<team name>", "", this.HandlePartyInvite);
			this.Add("partyban", "0 <team name>", "", this.HandlePartyBan);
			this.Add("mic", "", "", this.HandleShout);
			this.Add("memberinfoForAct", "<team name>", "", this.HandleMemberInfoForAct);
			//this.Add("readcollection", "id", "", this.HandleReadCollection);

			//this.Add("outguildcheck", "", "", this.HandleLeaveGuildCheck);
			//this.Add("outguildbyweb", "", "", this.HandleLeaveGuildByWeb);

			this.Add("hairgacha", "", "", this.HandleHairGacha);
			this.Add("petstat", "", "", this.HandlePetStat);
			this.Add("pethire", "", "", this.HandlePetHire);

			// Skills
			//this.Add("sageSavePos", "", "", this.HandleSageSavePosition);
			//this.Add("sageDelPos", "", "", this.HandleSageDeletePosition);
			//this.Add("sageOpenPortal", "", "", this.HandleSageOpenPortal);

			// Custom (Client Scripting)
			this.Add("buyshop", "", "", this.HandleBuyShop);
			this.Add("updatemouse", "", "", this.HandleUpdateMouse);
		}

		private CommandResult HandleReturnToQuestGiver(Character character, string message, string commandName, Arguments args)
		{
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count != 1)
			{
				Log.Debug("HandleReturnToQuestGiver: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			if (int.TryParse(args.Get(0), out var questId) && ZoneServer.Instance.Data.QuestDb.TryFind(questId, out var quest))
			{
				if (!character.Quests.IsActive(questId) ||
					string.IsNullOrEmpty(quest.StartNPC)
					|| ZoneServer.Instance.World.NPCs.TryGetValue(quest.StartNPC, out var npc))
				{
					return CommandResult.Okay;
				}

				var mapId = npc.Map.Id;
				var newPosition = npc.Position.GetRelative(npc.Direction, 50);
				var newDirection = -npc.Direction;

				character.SetDirection(newDirection);
				character.Warp(mapId, newPosition);
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command, purpose unknown.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="command"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleReqUpdateEquip(Character character, string message, string command, Arguments args)
		{
			// Command is sent when the inventory is opened, purpose unknown,
			// officials don't seem to send anything back.

			// Comment in the client's Lua files:
			//   내구도 회복 유료템 때문에 정확한 값을 지금 알아야 함.
			//   (Durability recovery Due to the paid system, you need to know the correct value now.)

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command, exchanges silver for ability points.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="command"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleBuyAbilPoint(Character character, string message, string command, Arguments args)
		{
			if (args.Count < 0)
			{
				Log.Warning("HandleBuyAbilPoint: No amount given by user '{0}'.", character.Connection.Account.Name);
				return CommandResult.Okay;
			}

			if (!int.TryParse(args.Get(0), out var amount))
			{
				Log.Warning("HandleBuyAbilPoint: Invalid amount '{0}' by user '{1}'.", amount, character.Connection.Account.Name);
				return CommandResult.Okay;
			}

			var costPerPoint = ZoneServer.Instance.Conf.World.AbilityPointCost;
			var totalCost = (amount * costPerPoint);
			var silver = character.Inventory.CountItem(ItemId.Silver);
			if (silver < totalCost)
			{
				Log.Warning("HandleBuyAbilPoint: User '{0}' didn't have enough money.", character.Connection.Account.Name);
				return CommandResult.Okay;
			}

			character.Inventory.Remove(ItemId.Silver, totalCost, InventoryItemRemoveMsg.Given);
			character.ModifyAbilityPoints(amount);

			Send.ZC_ADDON_MSG(character, AddonMessage.SUCCESS_BUY_ABILITY_POINT, 0, "BLANK");

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command, increase guild exp up.
		/// </summary>
		/// <example>
		/// /guildexpup 527456344001753 9
		/// </example>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleGuildExpUp(Character character, string message, string commandName, Arguments args)
		{
			var guild = character.Connection.Guild;
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count != 2 || !long.TryParse(args.Get(0), out var characterId) || !int.TryParse(args.Get(1), out var amount) || character.ObjectId != characterId || guild == null)
			{
				Log.Debug("HandleGuildExpUp: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			if (character.Inventory.CountItem(ItemId.Talt) >= amount)
			{
				var itemData = ZoneServer.Instance.Data.ItemDb.Find(ItemId.Talt);
				if (character.RemoveItem(ItemId.Talt, amount) >= amount)
				{
					Send.ZC_SYSTEM_MSG(character, 102072);
					Send.ZC_SYSTEM_MSG(character, 102434, new MsgParameter("value", amount.ToString()));
					guild.Properties.Modify(PropertyName.Exp, itemData.Script.NumArg1 * amount);
					Send.ZC_NORMAL.PartyPropertyUpdate(guild, guild.Properties.GetSelect(PropertyName.Exp));
					character.GuildMemberProperties?.Modify(PropertyName.Contribution, amount);
					Send.ZC_NORMAL.PartyMemberPropertyUpdate(guild, character, character.GuildMemberProperties.GetSelect(PropertyName.Contribution));
				}
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to get a Member Info For Act?
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleInteWarp(Character character, string message, string commandName, Arguments args)
		{
			if (args.Count < 2)
			{
				Log.Debug("HandleInteWarp: No warp id '{0}'.", character.Username);
				return CommandResult.Okay;
			}

			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.

			if (args.Count != 2)
			{
				Log.Debug("HandleInteWarp: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			if (int.TryParse(args.Get(0), out var warpId))
			{
				int.TryParse(args.Get(1), out var unk1);
				if (unk1 == 0)
				{
					if (ZoneServer.Instance.Data.WarpDb.TryFind(warpId, out var warpData) && ZoneServer.Instance.World.NPCs.TryGetValue(warpData.ClassName, out var npc))
					{
						var mapId = npc.Map.Id;
						var newPosition = npc.Position.GetRelative(npc.Direction, 50);
						var newDirection = -npc.Direction;

						character.SetDirection(newDirection);
						character.Warp(mapId, newPosition);
					}
				}
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to get a Member Info For Act?
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleMemberInfoForAct(Character character, string message, string commandName, Arguments args)
		{
			if (args.Count < 1)
			{
				Log.Debug("HandleMemberInfoForAct: No team name given by user '{0}'.", character.Username);
				return CommandResult.Okay;
			}

			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.

			if (args.Count != 1)
			{
				Log.Debug("HandleMemberInfoForAct: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			var targetCharacter = ZoneServer.Instance.World.GetCharacterByTeamName(args.Get(0));
			if (targetCharacter != null)
			{
				if (targetCharacter.Connection.Party != null || targetCharacter.Connection.Guild != null)
				{
					Send.ZC_NORMAL.ShowParty(targetCharacter.Connection, targetCharacter);
					Send.ZC_TO_SOMEWHERE_CLIENT(targetCharacter);
				}
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to change a party name
		/// </summary>
		/// <example>
		/// /partyname 0 0 1 Fun Party
		/// </example>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePartyName(Character character, string message, string commandName, Arguments args)
		{
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count < 4)
			{
				Log.Debug("HandlePartyName: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			var party = character.Connection.Party;

			if (party != null && party.Owner.ObjectId == character.ObjectId)
			{
				var partyName = message.Substring(message.IndexOf(args.Get(2)) + args.Get(2).Length + 1);
				// Client has an internal limit, additional safety check
				if (partyName.Length > 2 && partyName.Length < 16)
					character.Connection.Party.ChangeName(partyName);
			}

			return CommandResult.Okay;
		}


		/// <summary>
		/// Official slash command to invite to a party
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePartyMake(Character character, string message, string commandName, Arguments args)
		{
			if (args.Count < 0)
			{
				Log.Debug("HandlePartyMake: No team name given by user '{0}'.", character.Username);
				return CommandResult.Okay;
			}

			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.

			if (args.Count != 1)
			{
				Log.Debug("HandlePartyMake: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			// To Do - Handle Party Name Check
			//ZoneServer.Instance.World.GetParty() ?
			if (character.Connection.Party == null)
			{
				var party = ZoneServer.Instance.World.Parties.Create(character);
				party.SetProperty(PropertyName.CreateTime, DateTimeUtils.ToSDateTime(party.DateCreated));
				party.SetProperty(PropertyName.ExpGainType, party.ExpDistribution.ToString());
				party.SetProperty(PropertyName.LastMemberAddedTime, party.DateCreated.Ticks.ToString());
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to invite a character to a party
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePartyInvite(Character character, string message, string commandName, Arguments args)
		{
			if (args.Count < 1)
			{
				Log.Debug("HandlePartyInvite: No team name given by user '{0}'.", character.Username);
				return CommandResult.Okay;
			}

			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.

			if (args.Count != 1)
			{
				Log.Debug("HandlePartyInvite: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			var targetCharacter = ZoneServer.Instance.World.GetCharacterByTeamName(args.Get(0));
			if (targetCharacter != null)
				Send.ZC_NORMAL.PartyInvite(targetCharacter, character, PartyType.Party);

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to expel a member from a party
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="target"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePartyBan(Character sender, string message, string commandName, Arguments args)
		{
			if (args.Count < 1)
			{
				Log.Debug("HandlePartyBan: No team name given by user '{0}'.", sender.Username);
				return CommandResult.Okay;
			}

			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.

			if (args.Count != 2)
			{
				Log.Debug("HandlePartyBan: Invalid call by user '{0}': {1}", sender.Username, commandName);
				return CommandResult.Okay;
			}

			var teamName = args.Get(0);
			var party = sender.Connection.Party;

			party?.Expel(sender, teamName);

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to use gacha
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="target"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleHairGacha(Character sender, string message, string commandName, Arguments args)
		{
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count < 1)

			{
				Log.Debug("HandleGacha: Invalid call by user '{0}': {1}", sender.Username, commandName);
				return CommandResult.Okay;
			}

			if (sender.RemoveItem(args.Get(0)) == 1)
			{
				var randomItem = ZoneServer.Instance.Data.ItemDb.Entries.ToArray().Random();
				sender.Inventory.Add(new Item(randomItem.Value.Id), InventoryAddType.NotNew, InventoryType.Inventory, 99999);
				Send.ZC_ENABLE_CONTROL(sender.Connection, "ITEM_GACHA_TP", false);
				Send.ZC_LOCK_KEY(sender, "ITEM_GACHA_TP", true);
				sender.TimedEvents.Add(TimeSpan.FromSeconds(5), TimeSpan.Zero, 0, "gacha", caller =>
				{
					Send.ZC_ENABLE_CONTROL(sender.Connection, "ITEM_GACHA_TP", true);
					Send.ZC_LOCK_KEY(sender, "ITEM_GACHA_TP", false);
					Send.ZC_ADDON_MSG(sender, "HAIR_GACHA_POPUP", 1003, randomItem.Value.ClassName);
				});
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to hire a pet
		/// </summary>
		/// <example>/pethire 3 Pet</example>
		/// <param name="sender"></param>
		/// <param name="target"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePetHire(Character sender, string message, string commandName, Arguments args)
		{
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count < 2)
			{
				Log.Debug("HandlePetHire: Invalid call by user '{0}': {1}", sender.Username, commandName);
				return CommandResult.Okay;
			}

			if (!sender.HasCompanions)
				return CommandResult.Okay;

			if (!int.TryParse(args.Get(0), out var petShopId))
				return CommandResult.InvalidArgument;

			var companion = new Companion(sender, petShopId, MonsterType.Friendly);
			if (args.Count > 1)
				companion.Name = args.Get(1);

			sender.CreateCompanion(companion);

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command to raise pet stats
		/// </summary>
		/// <example>/petstat 528525790635969 MHP 1</example>
		/// <param name="character"></param>
		/// <param name="target"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandlePetStat(Character character, string message, string commandName, Arguments args)
		{
			// Since this command is sent via UI interactions, we'll not
			// use any automated command result messages, but we'll leave
			// debug messages for now, in case of unexpected values.
			if (args.Count < 2)
			{
				Log.Debug("HandlePetStat: Invalid call by user '{0}': {1}", character.Username, commandName);
				return CommandResult.Okay;
			}

			if (!character.HasCompanions)
				return CommandResult.Okay;

			if (long.TryParse(args.Get(0), out var companionObjectId))
			{
				var companion = character.GetCompanion(companionObjectId);
				var propertyName = "Monster_Stat_" + args.Get(1);

				if (companion != null && PropertyTable.Exists("Monster", propertyName)
					&& int.TryParse(args.Get(2), out var modifierValue))
				{
					var baseCost = propertyName == PropertyName.Stat_DEF ? 600 : 300;
					var totalCost = 0;
					var currentValue = companion.Properties.GetFloat(propertyName) - 1;

					for (var i = currentValue; i < (currentValue + modifierValue); i++)
						totalCost += (int)Math.Floor(baseCost * Math.Pow(1.08, i));

					if (character.Inventory.CountItem(ItemId.Silver) >= totalCost)
					{
						character.Inventory.Remove(ItemId.Silver, totalCost);
						companion.Properties.Modify(propertyName, modifierValue);
						Send.ZC_OBJECT_PROPERTY(character.Connection, companion);
					}
				}
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Official slash command, for shouting.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="target"></param>
		/// <param name="message"></param>
		/// <param name="commandName"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleShout(Character character, string message, string commandName, Arguments args)
		{
			// Command is sent when the inventory is opened, purpose unknown,
			// officials don't seem to send anything back.

			if (character.Inventory.Remove(ItemId.Megaphone, 1) == InventoryResult.Success)
			{
				// TODO: Send shout packets to Chat (Social) Server?
			}

			return CommandResult.Okay;
		}

		/// <summary>
		/// Opens buy-in shop creation window or creates shop based on
		/// arguments.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="command"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleBuyShop(Character character, string message, string command, Arguments args)
		{
			if (args.Count == 0)
			{
				Send.ZC_EXEC_CLIENT_SCP(character.Connection, "OPEN_PERSONAL_SHOP_REGISTER()");
				return CommandResult.Okay;
			}

			if (args.Count < 2)
			{
				Log.Debug("HandleBuyShop: Not enough arguments.");
				return CommandResult.Okay;
			}

			// Read arguments
			var title = args.Get(0);
			var items = new List<Tuple<int, int, int>>();

			for (var i = 2; i < args.Count; ++i)
			{
				var split = args.Get(i).Split(',');

				if (split.Length != 3 || !int.TryParse(split[0], out var id) || !int.TryParse(split[1], out var amount) || !int.TryParse(split[2], out var price))
				{
					Log.Debug("HandleBuyShop: Invalid argument '{0}'.", args.Get(i));
					return CommandResult.Okay;
				}

				items.Add(new Tuple<int, int, int>(id, amount, price));
			}

			// Create auto seller packet from arguments and have the
			// channel handle it as if the client had sent it.
			var packet = new Packet(Op.CZ_REGISTER_AUTOSELLER);
			packet.PutString(title, 64);
			packet.PutInt(items.Count);
			packet.PutInt(270065); // PersonalShop
			packet.PutInt(0);

			foreach (var item in items)
			{
				packet.PutInt(item.Item1);
				packet.PutInt(item.Item2);
				packet.PutInt(item.Item3);
				packet.PutEmptyBin(264);
			}

			ZoneServer.Instance.PacketHandler.Handle(character.Connection, packet);

			return CommandResult.Okay;
		}

		/// Updates the character's mouse position variables.
		/// </summary>
		/// <param name="character"></param>
		/// <param name="message"></param>
		/// <param name="command"></param>
		/// <param name="args"></param>
		/// <returns></returns>
		private CommandResult HandleUpdateMouse(Character character, string message, string command, Arguments args)
		{
			character.Variables.Temp.SetFloat("MouseX", float.Parse(args.Get(0), CultureInfo.InvariantCulture));
			character.Variables.Temp.SetFloat("MouseY", float.Parse(args.Get(1), CultureInfo.InvariantCulture));
			character.Variables.Temp.SetFloat("ScreenWidth", float.Parse(args.Get(2), CultureInfo.InvariantCulture));
			character.Variables.Temp.SetFloat("ScreenHeight", float.Parse(args.Get(3), CultureInfo.InvariantCulture));

			return CommandResult.Okay;
		}
	}
}
