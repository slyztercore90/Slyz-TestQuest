//--- Melia Script ----------------------------------------------------------
// Doll Items
//--- Description -----------------------------------------------------------
// Item scripts that add and remove buffs on equipping dolls.
//---------------------------------------------------------------------------

using System;
using Melia.Zone;
using Melia.Zone.Scripting;
using Melia.Zone.World.Actors;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Items;

public class DollItemScript : GeneralScript
{

	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_fairy_guilty")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_tiny")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_gabia")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_gabia_re")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_hauberk")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_lucy")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_vakarine")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_laima")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_medeina")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_zemina")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_zanas_jpn")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_santa_guilty")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Event_Doll_fairy_guilty")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_succubus")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_paulius")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_furry_guilty")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_jellyzele")]
	[ScriptableFunction("SCP_ON_EQUIP_ITEM_Doll_tiny_2")]
	public ItemEquipResult SCP_ON_EQUIP_ITEM_BUFF(Character character, Item item, string strArg, string strArg2, float numArg1, float numArg2)
	{
		var buffName = strArg;

		if (ZoneServer.Instance.Data.BuffDb.TryFind(buffName, out var buffData))
			character.StartBuff(buffData.Id, TimeSpan.Zero);

		return ItemEquipResult.Okay;
	}

	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_fairy_guilty")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_tiny")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_gabia")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_gabia_re")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_hauberk")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_lucy")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_vakarine")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_laima")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_medeina")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_zemina")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_zanas_jpn")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_santa_guilty")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Event_Doll_fairy_guilty")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_succubus")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_paulius")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_furry_guilty")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_jellyzele")]
	[ScriptableFunction("SCP_ON_UNEQUIP_ITEM_Doll_tiny_2")]
	public ItemUnequipResult SCP_ON_UNEQUIP_ITEM_BUFF(Character character, Item item, string strArg, string strArg2, float numArg1, float numArg2)
	{
		var buffName = strArg;

		if (ZoneServer.Instance.Data.BuffDb.TryFind(buffName, out var buffData))
			character.Buffs.Remove(buffData.Id);

		return ItemUnequipResult.Okay;
	}
}
