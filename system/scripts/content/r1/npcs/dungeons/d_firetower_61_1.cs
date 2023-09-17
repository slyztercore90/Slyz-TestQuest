//--- Melia Script ----------------------------------------------------------
// Roxona Reconstruction Agency West Building
//--- Description -----------------------------------------------------------
// NPCs found in and around Roxona Reconstruction Agency West Building.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DFiretower611NpcScript : GeneralScript
{
	public override void Load()
	{
		// Apsimesti Crossroads
		//-------------------------------------------------------------------------
		AddNpc(40001, "Apsimesti Crossroads", "d_firetower_61_1", -300.3336, -2322.191, 0, "", "FIRETOWER611_TO_PILGRIMROAD52", "");
		
		// Roxona Reconstruction Agency East Building
		//-------------------------------------------------------------------------
		AddNpc(40001, "Roxona Reconstruction Agency East Building", "d_firetower_61_1", -113.8056, 2144.53, 180, "", "FIRETOWER611_TO_FIRETOWER612", "");
		
		// Portal Power Generator
		//-------------------------------------------------------------------------
		AddNpc(147307, "Portal Power Generator", "d_firetower_61_1", 1368.903, -943.2156, 46, "FD_FTOWER611_TYPE_A_NPC_02");
		
		// Schilt Amplifier
		//-------------------------------------------------------------------------
		AddNpc(147306, "Schilt Amplifier", "d_firetower_61_1", 913.2559, -1418.379, 90, "FD_FTOWER611_TYPE_A_NPC_01");
		
		// Petrification Detector Sample
		//-------------------------------------------------------------------------
		AddNpc(154025, "Petrification Detector Sample", "d_firetower_61_1", 849.6886, -1418.38, 76, "FD_FTOWER611_TYPE_A_BG_AI_011");
		
		// Petrification Detector Sample
		//-------------------------------------------------------------------------
		AddNpc(154025, "Petrification Detector Sample", "d_firetower_61_1", 913.2669, -1356.486, 90, "FD_FTOWER611_TYPE_A_BG_AI_012");
		
		// Petrification Detector Sample
		//-------------------------------------------------------------------------
		AddNpc(154025, "Petrification Detector Sample", "d_firetower_61_1", 912.7186, -1481.435, 90, "FD_FTOWER611_TYPE_A_BG_AI_013");
		
		// Petrification Detector Sample
		//-------------------------------------------------------------------------
		AddNpc(154025, "Petrification Detector Sample", "d_firetower_61_1", 974.6104, -1420.476, 90, "FD_FTOWER611_TYPE_A_BG_AI_014");
		
		// Isolated Laboratory
		//-------------------------------------------------------------------------
		AddNpc(154069, "Isolated Laboratory", "d_firetower_61_1", 1398, -221, 90, "FIRETOWER611_GROUP_1_1");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40070, "Warning", "d_firetower_61_1", 831.5928, -1270.816, 10, "FD_FTOWER611_TYPE_A_BOARD_01");
		
		// Warning
		//-------------------------------------------------------------------------
		AddNpc(40070, "Warning", "d_firetower_61_1", 1218.314, -869.4147, 90, "FD_FTOWER611_TYPE_A_BOARD_02");
		
		// Outside of Isolation Camp
		//-------------------------------------------------------------------------
		AddNpc(154069, "Outside of Isolation Camp", "d_firetower_61_1", 1643, -159, 90, "FIRETOWER611_GROUP_1_2");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", -88.50967, 728.5776, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", -935.3823, 1121.738, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", -952.774, 684.0488, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", 821.077, 771.1998, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", 1358.701, 1932.647, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Magical Steam
		//-------------------------------------------------------------------------
		AddNpc(153022, "Magical Steam", "d_firetower_61_1", 1018.583, 1363.144, 90, "FD_FTOWER611_TYPE_B_ROAMER_NPC");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "d_firetower_61_1", -185.7816, 4.435118, 90, "WARP_D_FIRETOWER_61_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "d_firetower_61_1", 236.46, -1513.29, 135, "TREASUREBOX_LV_D_FIRETOWER_61_11000");
		
		// JOB_MIKO_6_1_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "JOB_MIKO_6_1_TRIGGER", "d_firetower_61_1", -71.02087, 1694.346, 90, "JOB_MIKO_6_1_FTOWER_61_1");
	}
}
