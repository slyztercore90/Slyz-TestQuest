//--- Melia Script ----------------------------------------------------------
// Crystal Mine 1F
//--- Description -----------------------------------------------------------
// NPCs found in and around Crystal Mine 1F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCmine01NpcScript : GeneralScript
{
	public override void Load()
	{
		// Miners' Village
		//-------------------------------------------------------------------------
		AddNpc(40001, "Miners' Village", "d_cmine_01", -1294, -1710, -76, "", "WS_ACT4_1_ACT3", "");
		
		// Crystal Mine 2F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine 2F", "d_cmine_01", -1412, 679, 241, "", "WS_ACT4_1_ACT4_2", "");
		
		// [Alchemist Master]{nl}Vaidotas
		//-------------------------------------------------------------------------
		AddNpc(20110, "[Alchemist Master]{nl}Vaidotas", "d_cmine_01", -1188, -1799, 90, "MINE_1_ALCHEMIST");
		
		// Entrance Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Entrance Purifier", "d_cmine_01", -881.8724, -1246.434, 90, "MINE_1_PURIFY_1");
		
		// Passage Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Passage Purifier", "d_cmine_01", -341.71, 992.15, 90, "MINE_1_PURIFY_7");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147453, "", "d_cmine_01", 748.17, 103.72, -5, "MINE_1_CRYSTAL_10");
		
		// Central Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Central Purifier", "d_cmine_01", 33.13, -44.16, 5, "MINE_1_PURIFY_5");
		
		// JOB_HIGHLANDER4_3_Transferred Quest
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_HIGHLANDER4_3_Transferred Quest", "d_cmine_01", 1196.97, 195.8, 90, "", "JOB_HIGHLANDER4_3", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_cmine_01", -1222.77, -1230.72, 60, "WARP_D_CMINE_01", "STOUP_CAMP", "STOUP_CAMP");
		
		// Lv2 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(40030, "Lv2 Treasure Chest", "d_cmine_01", 1316, 730, 360, "TREASUREBOX_LV_D_CMINE_01533");
		
		// Entrance Purifier Parts
		//-------------------------------------------------------------------------
		AddNpc(151015, "Entrance Purifier Parts", "d_cmine_01", -1035.85, -1460.69, 90, "MINE_1_CRYSTAL_4");
		
		// Entrance Purifier Parts
		//-------------------------------------------------------------------------
		AddNpc(151015, "Entrance Purifier Parts", "d_cmine_01", -743.19, -85.56, 90, "MINE_1_CRYSTAL_4");
		
		// MINE_1_CRYSTAL_9_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_1_CRYSTAL_9_TRIGGER", "d_cmine_01", 1287, -994, 90, "", "MINE_1_CRYSTAL_9_TRIGGER", "");
		
		// Spare Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Spare Purifier", "d_cmine_01", 1417.74, -913.54, 0, "MINE_1_CRYSTAL_9_DEVICE");
		
		// MINE_1_CRYSTAL_18_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_1_CRYSTAL_18_TRIGGER", "d_cmine_01", -1125.76, 427.64, 90, "", "MINE_1_CRYSTAL_18_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151008, " ", "d_cmine_01", -1501.23, 706.83, -16, "", "MINE_1_ELEVATOR", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_01", 645.39, -27.96, 0, "TREASUREBOX_LV_D_CMINE_01541");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_01", 331.21, 494.6, 0, "TREASUREBOX_LV_D_CMINE_01542");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_01", -1542.96, 494.07, 90, "TREASUREBOX_LV_D_CMINE_01543");
	}
}
