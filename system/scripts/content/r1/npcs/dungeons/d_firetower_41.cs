//--- Melia Script ----------------------------------------------------------
// Mage Tower 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Mage Tower 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower41NpcScript : GeneralScript
{
	public override void Load()
	{
		// Fedimian Suburbs
		//-------------------------------------------------------------------------
		AddNpc(147500, "Fedimian Suburbs", "d_firetower_41", -2301.328, -1410.267, 90, "", "FIRETOWER41_TO_REMAINS40", "");
		
		// Mage Tower 2F
		//-------------------------------------------------------------------------
		AddNpc(147500, "Mage Tower 2F", "d_firetower_41", 2956.427, -1409.302, 90, "", "FIRETOWER41_TO_FIRETOWER42", "");
		
		// Grita
		//-------------------------------------------------------------------------
		AddNpc(147449, "Grita", "d_firetower_41", -2600, -1571, 90, "FTOWER41_GRITA_01");
		
		// Defense Activation Device 
		//-------------------------------------------------------------------------
		AddNpc(151000, "Defense Activation Device ", "d_firetower_41", 2360, -2276, 135, "FTOWER41_MQ_05");
		
		// 2nd Transport Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(147500, "2nd Transport Magic Circle", "d_firetower_41", -582, -1856, 90, "FTOWER41_MQ_03");
		
		// Owyn
		//-------------------------------------------------------------------------
		AddNpc(20117, "Owyn", "d_firetower_41", -1664, -1786, 90, "FTOWER41_SQ_01");
		
		// Cordelier
		//-------------------------------------------------------------------------
		AddNpc(20146, "Cordelier", "d_firetower_41", 491, -1696, 90, "FTOWER41_SQ_03");
		
		// Book Shelf
		//-------------------------------------------------------------------------
		AddNpc(147372, "Book Shelf", "d_firetower_41", 1199.668, -891.27, 90, "FTOWER41_SQ_05_NPC");
		
		// JOB_THAUMATURGE4_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_THAUMATURGE4_1_TRIGGER", "d_firetower_41", 1860.145, -2304.492, 90, "", "JOB_THAUMATURGE4_1_TRIGGER", "");
		
		// 1st Transport Magic Circle
		//-------------------------------------------------------------------------
		AddNpc(147500, "1st Transport Magic Circle", "d_firetower_41", -1609, -1402, 90, "FTOWER41_MQ_02_NPC");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_firetower_41", 2005.266, -1369.808, 30, "WARP_D_FIRETOWER_41", "STOUP_CAMP", "STOUP_CAMP");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "d_firetower_41", -2176.399, -2123.405, 90, "FTOWER41_MQ_01_NPC");
		
		// Psychokino Tome Volume 1
		//-------------------------------------------------------------------------
		AddNpc(147311, "Psychokino Tome Volume 1", "d_firetower_41", 1252.079, -2282.968, 90, "JOB_2_PSYCHOKINO_5_1_BOOK_1");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_firetower_41", -2714.8, -1436.66, 90, "TREASUREBOX_LV_D_FIRETOWER_41126");
	}
}
