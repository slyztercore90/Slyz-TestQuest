//--- Melia Script ----------------------------------------------------------
// Entrance of Kateen Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Entrance of Kateen Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn7NpcScript : GeneralScript
{
	public override void Load()
	{
		// Middle Boss Trigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "Middle Boss Trigger", "f_katyn_7", 976, 187, 0, "", "KATYN7_PREBOSS", "");
		
		// Tenet Garden
		//-------------------------------------------------------------------------
		AddNpc(40001, "Tenet Garden", "f_katyn_7", 663, -4459, 0, "", "KATYN7_GELE574", "");
		
		// Owl Burial Ground
		//-------------------------------------------------------------------------
		AddNpc(40001, "Owl Burial Ground", "f_katyn_7", -864, 3894, 180, "", "KATYN7_KATYN7_2", "");
		
		// Commander Vacenin
		//-------------------------------------------------------------------------
		AddNpc(20129, "Commander Vacenin", "f_katyn_7", 761, -3576, 0, "KATYN7_KEYNPC_1");
		
		// Fallen Messenger
		//-------------------------------------------------------------------------
		AddNpc(10033, "Fallen Messenger", "f_katyn_7", 813, 573, 14, "KATYN7_KEYNPC_3");
		
		// Officer Felix
		//-------------------------------------------------------------------------
		AddNpc(20107, "Officer Felix", "f_katyn_7", -1237, -1204, 0, "KATYN7_KEYNPC_4");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_katyn_7", 895, -3102, 0, "KATYN_SUCH_POINT_01");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_katyn_7", 898, -1688, 0, "KATYN_SUCH_POINT_02");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_katyn_7", 5, -915, 0, "KATYN_SUCH_POINT_03");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_katyn_7", 1139, -834, 0, "KATYN_SUCH_POINT_04");
		
		// Bonfire
		//-------------------------------------------------------------------------
		AddNpc(46011, "Bonfire", "f_katyn_7", -1066, -2319, 0, "KATYN_SUCH_POINT_05");
		
		// Patrol Scout
		//-------------------------------------------------------------------------
		AddNpc(20016, "Patrol Scout", "f_katyn_7", 672, -3810, 90, "KATYN_SUCH_POINT_01_SOLDIER");
		
		// Sleeping Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(12081, "Sleeping Owl Statue", "f_katyn_7", -1270, 1330, 0, "KATYN71_OWL_01");
		
		// Officer's Spirit
		//-------------------------------------------------------------------------
		AddNpc(20107, "Officer's Spirit", "f_katyn_7", -1280, 1240, 0, "KATYN71_OFFICER");
		
		// Soldier's Spirit
		//-------------------------------------------------------------------------
		AddNpc(10033, "Soldier's Spirit", "f_katyn_7", -1250, 1290, 0, "", "KATYN71_DEADSOL", "");
		
		// Soldier's Spirit
		//-------------------------------------------------------------------------
		AddNpc(10033, "Soldier's Spirit", "f_katyn_7", -1271, 1292, 0, "", "KATYN71_DEADSOL", "");
		
		// Soldier's Spirit
		//-------------------------------------------------------------------------
		AddNpc(10033, "Soldier's Spirit", "f_katyn_7", -1237, 1307, 0, "", "KATYN71_DEADSOL", "");
		
		// Soldier's Spirit
		//-------------------------------------------------------------------------
		AddNpc(10033, "Soldier's Spirit", "f_katyn_7", -1287, 1306, 0, "", "KATYN71_DEADSOL", "");
		
		// Soldier's Spirit
		//-------------------------------------------------------------------------
		AddNpc(10033, "Soldier's Spirit", "f_katyn_7", -1236, 1329, 0, "", "KATYN71_DEADSOL", "");
		
		// Officer's Spirit
		//-------------------------------------------------------------------------
		AddNpc(20107, "Officer's Spirit", "f_katyn_7", -420, 3440, 0, "KATYN71_OFFICER_AFTER");
		
		// Position Trigger of Commander Vacenin
		//-------------------------------------------------------------------------
		AddNpc(20026, "Position Trigger of Commander Vacenin", "f_katyn_7", 1026, -3727, 0, "", "KATYN7_KEYNPC_1_TRIGGER", "");
		
		// Notice
		//-------------------------------------------------------------------------
		AddNpc(40070, "Notice", "f_katyn_7", 616, -1575, 360, "F_KATYN_7_BOARD02");
		
		// Trap Case
		//-------------------------------------------------------------------------
		AddNpc(20041, "Trap Case", "f_katyn_7", -124, 1592, 90, "", "REPEAT_MON_GEN_TRIGGER", "");
		
		// Trap Case
		//-------------------------------------------------------------------------
		AddNpc(20041, "Trap Case", "f_katyn_7", 190, -3513, 90, "", "REPEAT_MON_GEN_TRIGGER", "");
		
		// Trap Case
		//-------------------------------------------------------------------------
		AddNpc(20041, "Trap Case", "f_katyn_7", 372, -3562, 90, "", "REPEAT_MON_GEN_TRIGGER", "");
		
		// Trap Case
		//-------------------------------------------------------------------------
		AddNpc(20041, "Trap Case", "f_katyn_7", 329, -933, 90, "", "REPEAT_MON_GEN_TRIGGER", "");
		
		// Bait Install Place
		//-------------------------------------------------------------------------
		AddNpc(20025, "Bait Install Place", "f_katyn_7", -917.4514, 3306.635, 90, "KATYN7_MQ06_TRACK");
		
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(20016, "Scout", "f_katyn_7", -1621, 3900, 171, "KATYN71_SOLDIER01_1", "KATYN71_SOLDIER01");
		
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(20016, "Scout", "f_katyn_7", -1572.675, 3929.488, 219, "KATYN71_BOSS");
		
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(20016, "Scout", "f_katyn_7", -1542.716, 3990.158, 247, "KATYN71_SOLDIER01_2", "KATYN71_SOLDIER02");
		
		// Scout
		//-------------------------------------------------------------------------
		AddNpc(20016, "Scout", "f_katyn_7", 994.428, -3990.511, 90, "KATYN7_KEYNPC_5");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_katyn_7", -321.4175, 1961.274, 90, "", "JOB_ROGUE4_1_TRIGGER", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_katyn_7", -2082.19, 1663.05, 90, "TREASUREBOX_LV_F_KATYN_710025");
	}
}
