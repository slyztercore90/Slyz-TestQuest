//--- Melia Script ----------------------------------------------------------
// Mage Tower 4F
//--- Description -----------------------------------------------------------
// NPCs found in and around Mage Tower 4F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower44NpcScript : GeneralScript
{
	public override void Load()
	{
		// Mage Tower 3F
		//-------------------------------------------------------------------------
		AddNpc(147500, "Mage Tower 3F", "d_firetower_44", 584.4926, -1318.89, 90, "", "FIRETOWER44_TO_FIRETOWER43", "");
		
		// Mage Tower 5F
		//-------------------------------------------------------------------------
		AddNpc(147500, "Mage Tower 5F", "d_firetower_44", -2718.143, 62.12241, 90, "", "FIRETOWER44_TO_FIRETOWER45", "");
		
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(147449, "Grita", "d_firetower_44", 571.6976, -1149.573, -11, "FTOWER44_GRITA_01");
		
		// Furry Odd
		//-------------------------------------------------------------------------
		AddNpc(20145, "Furry Odd", "d_firetower_44", 1262, -184, 90, "FTOWER44_SQ_01");
		
		// Furry Odd
		//-------------------------------------------------------------------------
		AddNpc(20145, "Furry Odd", "d_firetower_44", 1896, 253, 90, "FTOWER44_SQ_02");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_firetower_44", 1780, 507, 90, "", "FTOWER44_SQ_03", "");
		
		// Sealed Stone
		//-------------------------------------------------------------------------
		AddNpc(151050, "Sealed Stone", "d_firetower_44", 32, 310, 90, "FTOWER44_SQ_04");
		
		// Sealed Stone
		//-------------------------------------------------------------------------
		AddNpc(151050, "Sealed Stone", "d_firetower_44", -453.0844, -1449.623, 90, "FTOWER44_SQ_05");
		
		// Magic Stabilizing Device 
		//-------------------------------------------------------------------------
		AddNpc(147372, "Magic Stabilizing Device ", "d_firetower_44", 158.0137, 113.6509, 90, "FTOWER44_MQ_02");
		
		// FTOWER44_MQ_05_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "FTOWER44_MQ_05_TRIGGER", "d_firetower_44", -2194.911, 62.18592, 90, "", "FTOWER44_MQ_05_TRIGGER", "");
		
		// Flame Crystal
		//-------------------------------------------------------------------------
		AddNpc(151001, "Flame Crystal", "d_firetower_44", -391.8288, -617.7429, 90, "FTOWER44_MQ_03");
		
		// Flame Crystal
		//-------------------------------------------------------------------------
		AddNpc(151001, "Flame Crystal", "d_firetower_44", -554.4518, -736.5818, 90, "FTOWER44_MQ_03");
		
		// Flame Crystal
		//-------------------------------------------------------------------------
		AddNpc(151001, "Flame Crystal", "d_firetower_44", -495.4181, -1278.579, 90, "FTOWER44_MQ_03");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40070, "Warning", "d_firetower_44", -568.1971, -367.1758, 90, "FTOWER_44_WARING");
		
		// Spell Control Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(147469, "Spell Control Magic Circle", "d_firetower_44", -1603, 614, 90, "FTOWER44_MQ_04_NPC");
		
		// Flame Crystal
		//-------------------------------------------------------------------------
		AddNpc(151001, "Flame Crystal", "d_firetower_44", -418.7737, -1561.873, 90, "FTOWER44_MQ_03");
		
		// Flame Crystal
		//-------------------------------------------------------------------------
		AddNpc(151001, "Flame Crystal", "d_firetower_44", -267.795, -1334.424, 90, "FTOWER44_MQ_03");
		
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(147449, "Grita", "d_firetower_44", -1596.22, 587.6, 180, "FTOWER44_GRITA_REMAIN");
		
		// Psychokino Tome Volume 4
		//-------------------------------------------------------------------------
		AddNpc(147311, "Psychokino Tome Volume 4", "d_firetower_44", 1411.337, -656.3796, 90, "JOB_2_PSYCHOKINO_5_1_BOOK_4");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_firetower_44", 744.7, 554.75, 90, "TREASUREBOX_LV_D_FIRETOWER_44230");
		
		// Mage Tower Guild Mission
		//-------------------------------------------------------------------------
		AddNpc(40001, "Mage Tower Guild Mission", "d_firetower_44", -368.5267, -1505.354, -75, "", "FIRETOWER44_TO_GUILDMISSION", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "d_firetower_44", 653.94, -1663.74, 90, "HT2_FTOWER_44_TSCOPE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152057, " ", "d_firetower_44", 544.1, -1687.83, 90, "HT2_FTOWER_44_TSCOPE");
	}
}
