//--- Melia Script ----------------------------------------------------------
// Nuoridin Falls
//--- Description -----------------------------------------------------------
// NPCs found in and around Nuoridin Falls.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FRemains371NpcScript : GeneralScript
{
	public override void Load()
	{
		// Valius' Eternal Resting Place
		//-------------------------------------------------------------------------
		AddNpc(40001, "Valius' Eternal Resting Place", "f_remains_37_1", -65.84995, -1794.304, 151, "", "REMAINS37_1_CATACOMB_02", "");
		
		// Stele Road
		//-------------------------------------------------------------------------
		AddNpc(40001, "Stele Road", "f_remains_37_1", 2123.194, -745.3977, 48, "", "REMAINS37_1_REMAINS37", "");
		
		// Namu Temple Ruins
		//-------------------------------------------------------------------------
		AddNpc(40001, "Namu Temple Ruins", "f_remains_37_1", -2785.502, 1350.796, 14, "", "REMAINS37_1_REMAINS37_2", "");
		
		// Adrijus
		//-------------------------------------------------------------------------
		AddNpc(155037, "Adrijus", "f_remains_37_1", -469.8836, -380.4202, 90, "REMAINS37_1_ADRIJUS");
		
		// Adrijus' Notice Board
		//-------------------------------------------------------------------------
		AddNpc(40070, "Adrijus' Notice Board", "f_remains_37_1", -228.6361, -1954.113, 46, "REMAINS37_1_BOARD");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", -368.2415, -2131.79, 175, "REMAINS37_1_FAKEMT01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", -259.1892, -1138.456, 8, "REMAINS37_1_FAKEMT02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", 742.2964, -1244.137, 52, "REMAINS37_1_MT01");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", 1609.23, -1013.039, -39, "REMAINS37_1_MT02");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", -664.9534, 1658.73, -28, "REMAINS37_1_MT05");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -717.124, 588.7125, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -912.6697, 866.3734, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -776.2604, 979.4545, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -1024.258, 524.2941, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -360.4382, 819.8244, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -138.5659, 711.221, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -1046.932, 216.1871, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -1278.146, -128.3795, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -1515.273, -272.0577, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(47200, " ", "f_remains_37_1", -944.2491, -229.8867, 90, "REMAINS37_1_KRAUT");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152030, " ", "f_remains_37_1", 755.1261, -668.5732, 24, "", "REMAINS37_1_MT04_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(152031, " ", "f_remains_37_1", 755.1261, -668.5732, 24, "REMAINS37_1_MT04");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_remains_37_1", -835.83, 1575.17, 0, "TREASUREBOX_LV_F_REMAINS_37_11000");
	}
}
