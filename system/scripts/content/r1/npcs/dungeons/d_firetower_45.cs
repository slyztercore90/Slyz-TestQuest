//--- Melia Script ----------------------------------------------------------
// Mage Tower 5F
//--- Description -----------------------------------------------------------
// NPCs found in and around Mage Tower 5F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower45NpcScript : GeneralScript
{
	public override void Load()
	{
		// Mage Tower 4F
		//-------------------------------------------------------------------------
		AddNpc(147500, "Mage Tower 4F", "d_firetower_45", -1215.601, -2087.144, 90, "", "FIRETOWER45_TO_FIRETOWER44", "");
		
		// Simon Shaw
		//-------------------------------------------------------------------------
		AddNpc(20139, "Simon Shaw", "d_firetower_45", -1361, -1314, 90, "FTOWER45_SQ_01");
		
		// Simon Shaw
		//-------------------------------------------------------------------------
		AddNpc(20139, "Simon Shaw", "d_firetower_45", -1239, 24, 90, "FTOWER45_SQ_03");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_firetower_45", -1430, -193, 90, "", "FTOWER45_SQ_T", "");
		
		// Sealed Stone
		//-------------------------------------------------------------------------
		AddNpc(151050, "Sealed Stone", "d_firetower_45", 599, 1146, 90, "FTOWER45_SQ_04");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_firetower_45", 197, 1441, 90, "", "FTOWER45_SQ_05", "");
		
		// Magic Suppressor
		//-------------------------------------------------------------------------
		AddNpc(151003, "Magic Suppressor", "d_firetower_45", -576, -1092, 0, "FTOWER45_MQ_01_D", "FTOWER45_MQ_01_E");
		
		// Magic Suppressor
		//-------------------------------------------------------------------------
		AddNpc(151003, "Magic Suppressor", "d_firetower_45", -501, -745, 45, "FTOWER45_MQ_02_D", "FTOWER45_MQ_02_E");
		
		// Magic Suppressor
		//-------------------------------------------------------------------------
		AddNpc(151003, "Magic Suppressor", "d_firetower_45", -12, 26, 91, "FTOWER45_MQ_03_D", "FTOWER45_MQ_03_E");
		
		// Magic Suppressor
		//-------------------------------------------------------------------------
		AddNpc(151003, "Magic Suppressor", "d_firetower_45", -223, 1036, 72, "FTOWER45_MQ_04_D", "FTOWER45_MQ_04_E");
		
		// FTOWER45_MQ_05_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "FTOWER45_MQ_05_TRIGGER", "d_firetower_45", 826.4413, 2333.979, 90, "", "FTOWER45_MQ_05_E", "");
		
		// Goddess Gabija
		//-------------------------------------------------------------------------
		AddNpc(147452, "Goddess Gabija", "d_firetower_45", 837.07, 2330.39, 0, "FTOWER45_MQ_06_D");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_firetower_45", -1689.079, -643.7197, 90, "WARP_D_FIRETOWER_45", "STOUP_CAMP", "STOUP_CAMP");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151018, " ", "d_firetower_45", 840.5307, 2307.611, 90, "FTOWER45_MQ_05_D");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(151053, "", "d_firetower_45", 860.4548, 2355.368, 0, "", "FTOWER45_GRITA_PHOENIX", "");
		
		// Psychokino Tome Volume 5
		//-------------------------------------------------------------------------
		AddNpc(147311, "Psychokino Tome Volume 5", "d_firetower_45", -117.4209, 1675.798, 90, "JOB_2_PSYCHOKINO_5_1_BOOK_5");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_firetower_45", -1706.06, -187.25, 90, "TREASUREBOX_LV_D_FIRETOWER_45219");
	}
}
