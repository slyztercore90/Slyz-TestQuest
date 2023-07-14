﻿//--- Melia Script ----------------------------------------------------------
// Dialog Transaction Scripts
//--- Description -----------------------------------------------------------
// Handles "Dialog TX" requests from the client.
//---------------------------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using Melia.Shared.Tos.Const;
using Melia.Zone;
using Melia.Zone.Network;
using Melia.Zone.Scripting;
using Melia.Zone.Skills;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;
using Yggdrasil.Geometry.Shapes;
using Yggdrasil.Logging;

public class DialogTxFunctionsScript : GeneralScript
{
	[ScriptableFunction("SCR_ITEM_MANUFACTURE_RECIPE")]
	public DialogTxResult SCR_ITEM_MANUFACTURE_RECIPE(Character character, DialogTxArgs args)
	{
		if (args.NumArgs.Length < 2)
			return DialogTxResult.Fail;

		var recipeId = args.NumArgs[0];
		var craftAmount = args.NumArgs[1];

		if (!ZoneServer.Instance.Data.RecipeDb.TryFind(recipeId, out var recipe))
		{
			character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_FAIL, "", 0);
			return DialogTxResult.Fail;
		}

		character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_START, recipe.ClassName);

		var timeConsumed = 8;
		var type = "CRAFT";

		Send.ZC_NORMAL.TimeAction(character, "!@#$ItemCraftProcess#@!", type, timeConsumed, true);

		var sessionObject = character.AddSessionObject(15509);
		sessionObject.Properties.SetFloat(PropertyName.Step1, 8500);
		Send.ZC_OBJECT_PROPERTY(character, sessionObject, PropertyName.Step1);

		character.TimedEvents.Add(TimeSpan.FromSeconds(timeConsumed), TimeSpan.Zero, 0, "timeaction", caller =>
		{
			var evStopObject = (caller as Character)?.SessionObjects.Get(15509);
			evStopObject?.Properties.SetFloat(PropertyName.Goal1, 1);
			Send.ZC_OBJECT_PROPERTY(character, evStopObject, PropertyName.Goal1);
			(caller as Character)?.RemoveSessionObject(15509);

			Send.ZC_NORMAL.TimeActionState(caller, true);

			for (var i = 0; i < craftAmount; i++)
			{
				foreach (var txItem in args.TxItems)
				{
					var item = txItem.Item;
					var amount = txItem.Amount;

					if (!recipe.RequiredItems.ContainsKey(item.Data.ClassName) || amount < recipe.RequiredItems[item.Data.ClassName])
					{
						character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_FAIL, recipe.ClassName);
						return;
					}
				}
			}

			for (var i = 0; i < craftAmount; i++)
			{
				foreach (var txItem in args.TxItems)
				{
					character.Inventory.Remove(txItem.Item.ObjectId, txItem.Amount, InventoryItemRemoveMsg.Given);
				}
			}

			character.AddItem(recipe.Item, recipe.ItemAmount * craftAmount);
			character.AddonMessage(AddonMessage.JOURNAL_DETAIL_CRAFT_EXEC_SUCCESS, recipe.ClassName, craftAmount);
		}, caller =>
		{
			(caller as Character)?.RemoveSessionObject(15509);
			Send.ZC_NORMAL.TimeActionState(caller, false);
		});

		return DialogTxResult.Okay;
	}

	[ScriptableFunction("GODDESS_REINFORCE")]
	public DialogTxResult GODDESS_REINFORCE(Character character, DialogTxArgs args)
	{
		if (args.TxItems.Length < 2)
			return DialogTxResult.Fail;

		var equipItem = args.TxItems[0];
		var materialItem = args.TxItems[1];

		// TODO: Validate items with a goddess equip upgrade db
		character.Inventory.Remove(materialItem.Item.ObjectId, materialItem.Amount, InventoryItemRemoveMsg.Given);
		equipItem.Item.Properties.Modify(PropertyName.Reinforce_2, 1);

		Send.ZC_OBJECT_PROPERTY(character, equipItem.Item);
		character.AddonMessage(AddonMessage.MSG_SUCCESS_GODDESS_REINFORCE_EXEC, "1", 1);

		return DialogTxResult.Okay;
	}

	[ScriptableFunction("SCR_ITEM_APPRAISAL")]
	public DialogTxResult APPRAISAL(Character character, DialogTxArgs args)
	{
		foreach (var txItem in args.TxItems)
		{
			var item = txItem.Item;

			Send.ZC_ENABLE_CONTROL(character.Connection, "APPRAISER", false);
			Send.ZC_LOCK_KEY(character, "APPRAISER", true);

			Task.Delay(1500).ContinueWith(t =>
			{
				Send.ZC_ENABLE_CONTROL(character.Connection, "APPRAISER", true);
				Send.ZC_LOCK_KEY(character, "APPRAISER", false);
				item.GenerateRandomOptions();
				Send.ZC_OBJECT_PROPERTY(character, item);
				character.AddonMessage(AddonMessage.SUCCESS_APPRALSAL);
				character.AddonMessage(AddonMessage.UPDATE_ITEM_APPRAISAL, "Equip");
				Send.ZC_NORMAL.ShowItemBalloon(character, item);
			});
		}

		return DialogTxResult.Okay;
	}

	[ScriptableFunction("SCR_REVERT_ITEM_OPTION")]
	public DialogTxResult REVERT_ITEM_OPTION(Character character, DialogTxArgs args)
	{
		foreach (var txItem in args.TxItems)
		{
			var item = txItem.Item;

			item.GenerateRandomOptions();
			Send.ZC_OBJECT_PROPERTY(character, item);
			character.AddonMessage(AddonMessage.MSG_SUCCESS_FREE_RANDOM_OPTION);
			character.AddonMessage(AddonMessage.UPDATE_ITEM_APPRAISAL, "Equip");
		}

		return DialogTxResult.Okay;
	}

	[ScriptableFunction("EVENT_SHOP_1_THREAD1")]
	public DialogTxResult EVENT_SHOP_1_THREAD1(Character character, DialogTxArgs args)
	{
		if (args.NumArgs.Length < 2 && args.StrArgs.Length < 1)
			return DialogTxResult.Fail;

		var shopItemId = args.NumArgs[0];
		var shopItemAmount = args.NumArgs[1];
		var shopType = args.StrArgs[0];

		if (!ZoneServer.Instance.Data.TradeShopDb.TryFind(shopItemId, out var shopItem))
		{
			Log.Warning("EVENT_SHOP_1_THREAD1: User '{0}' tried to trade for an item that doesn't exist with id {1}.", character.Username, shopItemId);
			return DialogTxResult.Fail;
		}

		if (shopItem.ShopType != shopType)
		{
			Log.Debug("EVENT_SHOP_1_THREAD1: User '{0}' tried to trade for an item that didn't match the trade shop type: {1}.", character.Username, shopType);
			return DialogTxResult.Fail;
		}

		foreach (var txItem in args.TxItems)
		{
			var item = txItem.Item;
			var amount = txItem.Amount;

			if (!shopItem.RequiredItems.ContainsKey(item.Data.Id) || amount < (shopItemAmount * shopItem.RequiredItems[item.Data.Id]))
				return DialogTxResult.Fail;
		}

		foreach (var txItem in args.TxItems)
		{
			character.Inventory.Remove(txItem.Item.ObjectId, txItem.Amount * shopItemAmount, InventoryItemRemoveMsg.Given);
		}

		character.AddItem(shopItem.ItemCraftedClassName, shopItem.ItemCraftedCount * shopItemAmount);
		character.AddonMessage(AddonMessage.EARTHTOWERSHOP_BUY_ITEM, shopItem.ItemCraftedClassName);
		character.AddonMessage(AddonMessage.EARTHTOWERSHOP_BUY_ITEM_RESULT, shopItem.ShopType + "/0/0");

		return DialogTxResult.Okay;
	}
}
