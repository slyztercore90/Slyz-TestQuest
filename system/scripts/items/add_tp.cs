﻿//--- Melia Script ----------------------------------------------------------
// Add TP Items
//--- Description -----------------------------------------------------------
// Item scripts that add TP (medals) to an account.
//---------------------------------------------------------------------------

using System;
using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class AddTpItemScript : GeneralScript
{
	[ScriptableFunction("SCR_USE_ITEM_ADD_TP")]
	public ItemUseResult SCR_USE_ITEM_ADD_TP(Character character, Item item, string strArg, float tpAmount, float numArg2)
	{
		if (tpAmount < 31)
			character.PlayEffect("F_sys_TPBOX_normal_30", 2.5f, 1, "BOT", 1);
		else if (tpAmount < 101)
			character.PlayEffect("F_sys_TPBOX_normal_100", 2.5f, 1, "BOT", 1);
		else if (tpAmount < 201)
			character.PlayEffect("F_sys_TPBOX_great_200", 2.5f, 1, "BOT", 1);
		else
			character.PlayEffect("F_sys_TPBOX_great_300", 2.5f, 1, "BOT", 1);
		character.ModifyAccountProperty(PropertyName.PremiumMedal, tpAmount);
		return ItemUseResult.Okay;
	}

	[ScriptableFunction("SCR_USE_ITEM_ADD_GIFTTP")]
	public ItemUseResult SCR_USE_ITEM_ADD_GIFTTP(Character character, Item item, string strArg, float tpAmount, float numArg2)
	{
		if (tpAmount < 31)
			character.PlayEffect("F_sys_TPBOX_normal_30", 2.5f, 1, "BOT", 1);
		else if (tpAmount < 101)
			character.PlayEffect("F_sys_TPBOX_normal_100", 2.5f, 1, "BOT", 1);
		else if (tpAmount < 201)
			character.PlayEffect("F_sys_TPBOX_great_200", 2.5f, 1, "BOT", 1);
		else
			character.PlayEffect("F_sys_TPBOX_great_300", 2.5f, 1, "BOT", 1);

		character.ModifyAccountProperty(PropertyName.GiftMedal, tpAmount);
		return ItemUseResult.Okay;
	}
}
