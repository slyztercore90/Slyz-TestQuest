//--- Melia Script ----------------------------------------------------------
// Inner Wall District 10
//--- Description -----------------------------------------------------------
// NPCs found in and around Inner Wall District 10.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FCastle94NpcScript : GeneralScript
{
	public override void Load()
	{
		// Wounded Soldier Spirit
		//-------------------------------------------------------------------------
		AddNpc(150200, "Wounded Soldier Spirit", "f_castle_94", 1062, 775, 90, "CASTLE94_NPC_MAIN01", "CASTLE94_NPC_MAIN01");
		
		// Switchgear
		//-------------------------------------------------------------------------
		AddNpc(151050, "Switchgear", "f_castle_94", -1416, 1000, 90, "CASTLE94_NPC_01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150201, " ", "f_castle_94", 188, 2459, 0, "CASTLE94_NPC_03");
		
		// Evil Aura
		//-------------------------------------------------------------------------
		AddNpc(154065, "Evil Aura", "f_castle_94", 575, 2887, 90, "CASTLE94_NPC_02");
		
		// Royal Soldier Spirit
		//-------------------------------------------------------------------------
		AddNpc(154017, "Royal Soldier Spirit", "f_castle_94", 1062, 775, 90, "CASTLE94_NPC_MAIN02");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", 78.65771, 1205.302, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -208.4962, 857.0498, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -267.3208, 1243.94, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -458.674, 852.9813, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -786.1778, 1203.331, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -759.1938, 854.4965, 0, "CASTLE94_NPC_MONUMENT");
		
		// Statue of Purification
		//-------------------------------------------------------------------------
		AddNpc(152023, "Statue of Purification", "f_castle_94", 575, 2887, 0, "CASTLE94_NPC_04");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_castle_94", -1031.764, 999.8374, 90, "", "CASTLE94_MAIN05_TRIGGER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150202, " ", "f_castle_94", 188, 2459, 0, "CASTLE94_NPC_05");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(154067, " ", "f_castle_94", -1416, 1000, 90, "CASTLE94_MAIN05_SHIELD");
		
		// Inner Wall District 9
		//-------------------------------------------------------------------------
		AddNpc(40001, "Inner Wall District 9", "f_castle_94", -688.4324, -862.6098, 0, "", "F_CASTLE_94_TO_F_CASTLE_20_2", "");
		
		// Outer Wall District 11
		//-------------------------------------------------------------------------
		AddNpc(40001, "Outer Wall District 11", "f_castle_94", 1475.366, 999.3951, 90, "", "F_CASTLE_94_TO_F_CASTLE_93", "");
		
		// Outer Wall District 13
		//-------------------------------------------------------------------------
		AddNpc(40001, "Outer Wall District 13", "f_castle_94", -518.7258, 3216.284, 180, "", "F_CASTLE_94_TO_F_CASTLE_95", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_castle_94", 1133.941, 726.7096, 90, "WARP_F_CASTLE_94", "STOUP_CAMP", "STOUP_CAMP");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -527.4627, 1003.283, 0, "CASTLE94_NPC_MONUMENT");
		
		// Energized Tombstone
		//-------------------------------------------------------------------------
		AddNpc(152032, "Energized Tombstone", "f_castle_94", -80.13569, 1002.779, 0, "CASTLE94_NPC_MONUMENT");
	}
}
