//--- Melia Script ----------------------------------------------------------
// Crystal Mine 2F
//--- Description -----------------------------------------------------------
// NPCs found in and around Crystal Mine 2F.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DCmine02NpcScript : GeneralScript
{
	public override void Load()
	{
		// Crystal Mine 1F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine 1F", "d_cmine_02", -2419.326, -882.054, 250, "", "WS_ACT4_2_ACT4_1", "");
		
		// Crystal Mine 3F
		//-------------------------------------------------------------------------
		AddNpc(40001, "Crystal Mine 3F", "d_cmine_02", 1821, 1924, 167, "", "WS_ACT4_2_ACT4_3", "");
		
		// Circulation Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Circulation Purifier", "d_cmine_02", -1615.406, 122.4234, 30, "MINE_2_PURIFY_1");
		
		// Auxiliary Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Auxiliary Purifier", "d_cmine_02", -573.3664, 495.0785, 90, "MINE_2_PURIFY_3");
		
		// Main Purifier
		//-------------------------------------------------------------------------
		AddNpc(151006, "Main Purifier", "d_cmine_02", 524.1791, 364.3578, 60, "MINE_2_PURIFY_7");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_cmine_02", 1822, 321, 390, "WARP_D_CMINE_02", "STOUP_CAMP", "STOUP_CAMP");
		
		// Book Shelf
		//-------------------------------------------------------------------------
		AddNpc(147372, "Book Shelf", "d_cmine_02", 1732, 145, 90, "BOOKSHELF_02");
		
		// Man in Hiding
		//-------------------------------------------------------------------------
		AddNpc(20025, "Man in Hiding", "d_cmine_02", 1860, 580, 90, "CMINE_02_HIDEMAN");
		
		// Foods left
		//-------------------------------------------------------------------------
		AddNpc(20025, "Foods left", "d_cmine_02", 1808, 430, 90, "CMINE_FOOD_01");
		
		// Wine Cask 
		//-------------------------------------------------------------------------
		AddNpc(20025, "Wine Cask ", "d_cmine_02", 1822, 89, 90, "CMINE_FOOD_04");
		
		// Preserved food
		//-------------------------------------------------------------------------
		AddNpc(20025, "Preserved food", "d_cmine_02", 1926, 384, 90, "CMINE_FOOD_03");
		
		// JOB_SWORDMAN1
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_SWORDMAN1", "d_cmine_02", 1023, 1181, 90, "", "JOB_SWORDMAN1", "");
		
		// Business Guide
		//-------------------------------------------------------------------------
		AddNpc(40070, "Business Guide", "d_cmine_02", 1537, 417, 360, "D_CMINE_02_BOARD01");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "d_cmine_02", 1876.55, -1519.923, 90, "", "JOB_DIEVDIRBYS2_TRIGGER", "");
		
		// District 3 Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(147469, "District 3 Purifier Pipe", "d_cmine_02", -1309.593, -737.3552, 90, "MINE_2_CRYSTAL_2_PIPE");
		
		// District 2 Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(151020, "District 2 Purifier Pipe", "d_cmine_02", -1814.553, 939.6089, 90, "MINE_2_CRYSTAL_3_PIPE");
		
		// MINE_2_CRYSTAL_3_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_2_CRYSTAL_3_TRIGGER", "d_cmine_02", -1555.327, 894.7687, 90, "", "MINE_2_CRYSTAL_3_TRIGGER", "");
		
		// Magic Supply Device
		//-------------------------------------------------------------------------
		AddNpc(147469, "Magic Supply Device", "d_cmine_02", -789.3679, 1148.01, 90, "MINE_2_CRYSTAL_7_ENERGY");
		
		// MINE_2_CRYSTAL_10_TRIGGER1
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_2_CRYSTAL_10_TRIGGER1", "d_cmine_02", -87.92126, 942.1158, 93, "", "MINE_2_CRYSTAL_10_TRIGGER1", "");
		
		// MINE_2_CRYSTAL_10_TRIGGER2
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_2_CRYSTAL_10_TRIGGER2", "d_cmine_02", 643.9673, 674.8793, 90, "", "MINE_2_CRYSTAL_10_TRIGGER2", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "d_cmine_02", 338.033, 1095.11, 90, "MINE_2_CRYSTAL_10_OIL");
		
		// Torn-out Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(151017, "Torn-out Purifier Pipe", "d_cmine_02", 1208.371, -1067.293, 90, "MINE_2_CRYSTAL_16_PART");
		
		// Torn-out Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(151017, "Torn-out Purifier Pipe", "d_cmine_02", 1144.433, -1485.567, 180, "MINE_2_CRYSTAL_16_PART");
		
		// Torn-out Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(151017, "Torn-out Purifier Pipe", "d_cmine_02", 2012.121, -1657.709, 270, "MINE_2_CRYSTAL_16_PART");
		
		// Torn-out Purifier Pipe
		//-------------------------------------------------------------------------
		AddNpc(151017, "Torn-out Purifier Pipe", "d_cmine_02", 2066.269, -982.6493, 360, "MINE_2_CRYSTAL_16_PART");
		
		// Main Purifier Parts
		//-------------------------------------------------------------------------
		AddNpc(151016, "Main Purifier Parts", "d_cmine_02", 1558.729, -468.1057, 90, "MINE_2_CRYSTAL_20_PART");
		
		// MINE_2_CRYSTAL_20_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_2_CRYSTAL_20_TRIGGER", "d_cmine_02", 1654.14, -802.7938, 90, "", "MINE_2_CRYSTAL_20_TRIGGER", "");
		
		// MINE_2_CRYSTAL_10_TRIGGER1
		//-------------------------------------------------------------------------
		AddNpc(20026, "MINE_2_CRYSTAL_10_TRIGGER1", "d_cmine_02", -156.4412, 1019.16, 90, "", "MINE_2_CRYSTAL_10_TRIGGER1", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_02", 1509.99, 853.82, 90, "TREASUREBOX_LV_D_CMINE_02550");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_02", -349.39, 1235.15, 90, "TREASUREBOX_LV_D_CMINE_02551");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_cmine_02", 142.58, 189.01, 90, "TREASUREBOX_LV_D_CMINE_02553");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20042, "", "d_cmine_02", 754.1545, 1028.048, 90, "", "MASTER_HIGHLANDER2_3_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "d_cmine_02", 1730.303, 784.8629, 90, "", "MASTER_CRYOMANCER2_2_TRIGGER", "");
	}
}
