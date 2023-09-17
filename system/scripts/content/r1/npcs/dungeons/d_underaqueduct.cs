//--- Melia Script ----------------------------------------------------------
// Outer Wall Sewers
//--- Description -----------------------------------------------------------
// NPCs found in and around Outer Wall Sewers.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class DUnderaqueductNpcScript : GeneralScript
{
	public override void Load()
	{
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(152078, "Sewer Teleportation Device", "d_underaqueduct", 1048.242, 1272.548, 90, "D_UNDERAQUEDUCT_SETPOS_1");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(152078, "Sewer Teleportation Device", "d_underaqueduct", -1717.808, -880.9163, 90, "D_UNDERAQUEDUCT_SETPOS_2");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(152078, "Sewer Teleportation Device", "d_underaqueduct", -1695.672, 1669.149, 90, "D_UNDERAQUEDUCT_SETPOS_3");
		
		// Sewer Teleportation Device
		//-------------------------------------------------------------------------
		AddNpc(152078, "Sewer Teleportation Device", "d_underaqueduct", 1036.604, -1126.836, 90, "D_UNDERAQUEDUCT_SETPOS_4");
		
		// Supply Device
		//-------------------------------------------------------------------------
		AddNpc(151108, "Supply Device", "d_underaqueduct", -1176.419, 1355.446, 90, "D_UNDERAQUEDUCT_EVENT_1");
		
		// Secret Supply Device
		//-------------------------------------------------------------------------
		AddNpc(151108, "Secret Supply Device", "d_underaqueduct", -1183.232, 1265.041, 90, "D_UNDERAQUEDUCT_EVENT_2");
		
		// Chamber Entry Device
		//-------------------------------------------------------------------------
		AddNpc(151003, "Chamber Entry Device", "d_underaqueduct", -1039.296, 1373.089, 90, "D_UNDERAQUEDUCT_BOSS_SETPOS");
		
		// Docks
		//-------------------------------------------------------------------------
		AddNpc(154069, "Docks", "d_underaqueduct", -158.1535, 1374.568, 90, "D_UNDERAQUEDUCT_BOSS_SETPOS2");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "d_underaqueduct", 1215.218, -528.3562, 90, "D_UNDERAQUEDUCT_BOOK_1_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "d_underaqueduct", 270.8728, 744.741, 90, "D_UNDERAQUEDUCT_BOOK_2_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "d_underaqueduct", -1789.095, 169.8979, 90, "D_UNDERAQUEDUCT_BOOK_3_NPC");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(147312, "", "d_underaqueduct", -1221.999, 1526.404, 90, "D_UNDERAQUEDUCT_BOOK_4_NPC");
		
		// Skull
		//-------------------------------------------------------------------------
		AddNpc(152015, "Skull", "d_underaqueduct", 22.14384, 1510.373, 90, "D_UNDERAQUEDUCT_BOOK_5_NPC");
		
		// Outer Wall District 14
		//-------------------------------------------------------------------------
		AddNpc(147507, "Outer Wall District 14", "d_underaqueduct", 1704.62, -445.665, 90, "D_UNDERAQUEDUCT_TO_F_CASTLE_96");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "d_underaqueduct", -857.996, 1350.304, 90, "", "EXPLORER_MISLE31", "");
	}
}
