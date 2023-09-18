//--- Melia Script ----------------------------------------------------------
// Poslinkis Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Poslinkis Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FKatyn13NpcScript : GeneralScript
{
	public override void Load()
	{
		// Owl Burial Ground
		//-------------------------------------------------------------------------
		AddNpc(40001, "Owl Burial Ground", "f_katyn_13", 71, -2123, 94, "", "KATYN13_KATYN7_2", "");
		
		// Sincere Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(12081, "Sincere Owl Sculpture", "f_katyn_13", -663, -797, 0, "KATYN13_1_OWLBOSS");
		
		// Scared Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48004, "Scared Owl Sculpture", "f_katyn_13", -353, -2081, 0, "KATYN13_1_KEYNPC");
		
		// Devoted Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48004, "Devoted Owl Sculpture", "f_katyn_13", 809, -960, 0, "KATYN13_1_OWLJUNIOR1");
		
		// Troubled Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48004, "Troubled Owl Sculpture", "f_katyn_13", 909, 1010, 0, "KATYN13_1_OWLJUNIOR2");
		
		// Weak Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48024, "Weak Owl Sculpture", "f_katyn_13", -1180, 977, 0, "KATYN13_1_OWLJUNIOR3");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(20041, "Defeat the monsters blocking the road", "f_katyn_13", -665.667, -1326.814, -5, "", "KATYN13_1_KEY_SUB1_TRIGGER", "");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(20041, "Defeat the monsters blocking the road", "f_katyn_13", 1188, 303, 0, "", "KATYN13_1_TO_OWLJUNIOR2_S1_TRIGGER", "");
		
		// Defeat the monsters blocking the road
		//-------------------------------------------------------------------------
		AddNpc(20041, "Defeat the monsters blocking the road", "f_katyn_13", -897.2285, 202.1599, 0, "", "KATYN13_1_TO_OWLJUNIOR3_S1_TRIGGER", "");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48021, "Broken Owl Statue", "f_katyn_13", -2290, 1381, 90, "KATYN13_ADDQUEST1_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48022, "Broken Owl Statue", "f_katyn_13", -2324.545, 1368.72, 60, "KATYN13_ADDQUEST1_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48023, "Broken Owl Statue", "f_katyn_13", -2307, 1389, 120, "KATYN13_ADDQUEST1_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48024, "Broken Owl Statue", "f_katyn_13", -1069.055, 2324.004, 0, "KATYN13_ADDQUEST2_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48021, "Broken Owl Statue", "f_katyn_13", -1094.45, 2329.341, 45, "KATYN13_ADDQUEST2_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48022, "Broken Owl Statue", "f_katyn_13", -1090, 2298, 60, "KATYN13_ADDQUEST2_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48023, "Broken Owl Statue", "f_katyn_13", 8, 1440, 30, "KATYN13_ADDQUEST3_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48024, "Broken Owl Statue", "f_katyn_13", 14, 1455, 50, "KATYN13_ADDQUEST3_NPC");
		
		// Broken Owl Statue
		//-------------------------------------------------------------------------
		AddNpc(48021, "Broken Owl Statue", "f_katyn_13", 25, 1441, 160, "KATYN13_ADDQUEST3_NPC");
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(46212, "Oil Boxes", "f_katyn_13", -1330, 255, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER");
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(46212, "Oil Boxes", "f_katyn_13", -1336, 274, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER");
		
		// Oil Boxes
		//-------------------------------------------------------------------------
		AddNpc(46212, "Oil Boxes", "f_katyn_13", -1321, 269, 180, "KATYN13_ADDQUEST4_NPC", "KATYN13_ADDQUEST4_TRIGGER");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_katyn_13", -2283.21, 1364.55, 0, "KATYN13_ADDQUEST6_NPC", "KATYN13_ADDQUEST1_TRIGGER1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_katyn_13", -1076.23, 2296.26, 0, "KATYN13_ADDQUEST7_NPC", "KATYN13_ADDQUEST2_TRIGGER1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_katyn_13", 20.36, 1426.14, 0, "KATYN13_ADDQUEST8_NPC", "KATYN13_ADDQUEST3_TRIGGER1");
		
		// Captain Owl's Favor
		//-------------------------------------------------------------------------
		AddNpc(20041, "Captain Owl's Favor", "f_katyn_13", -985, -2369, 0, "", "KATYN13_1_TO_2_TRIGGER", "");
		
		// Weak Owl Sculpture
		//-------------------------------------------------------------------------
		AddNpc(48004, "Weak Owl Sculpture", "f_katyn_13", -1180, 977, 0, "KATYN13_1_OWLJUNIOR3_AFTER");
		
		// Saknis Plains
		//-------------------------------------------------------------------------
		AddNpc(40001, "Saknis Plains", "f_katyn_13", -2725, 1296, 270, "", "KATYN13_KATYN14", "");
		
		// ThaumaturgeElementalist5thAdvancementTrigger
		//-------------------------------------------------------------------------
		AddNpc(20026, "ThaumaturgeElementalist5thAdvancementTrigger", "f_katyn_13", -1211.792, 1237.367, 90, "", "JOB_THAUELE5_1_TRIGGER", "");
		
		// Septyni Glen
		//-------------------------------------------------------------------------
		AddNpc(40001, "Septyni Glen", "f_katyn_13", -1079.035, -2373.376, 270, "", "KATYN13_HUEVILLAGE58_4", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_katyn_13", -752.2082, 218.0627, 0, "KATYN13_1_TO_OWLJUNIOR3_S1_BOX");
		
		// Caved Area
		//-------------------------------------------------------------------------
		AddNpc(147372, "Caved Area", "f_katyn_13", -737.9014, -1405.336, 90, "KATYN13_1_KEY_SUB1_TRUFFLE");
		
		// Magic Condenser
		//-------------------------------------------------------------------------
		AddNpc(153059, "Magic Condenser", "f_katyn_13", 719.2162, -367.0856, -44, "PARTY_Q7_DEVICE");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147369, " ", "f_katyn_13", 718.7714, -368.1559, -39, "", "PARTY_Q7_DEVICE02", "");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_katyn_13", -1017.59, -1066.07, 90, "TREASUREBOX_LV_F_KATYN_13773");
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(152002, "Unidentified Spirit", "f_katyn_13", 1930.831, -236.8079, 69, "CHAR120_MSTEP6_1_NPC1");
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(20138, "Unidentified Spirit", "f_katyn_13", 1896.364, -260.493, 90, "CHAR120_MSTEP6_1_NPC2");
		
		// Unidentified Spirit
		//-------------------------------------------------------------------------
		AddNpc(20154, "Unidentified Spirit", "f_katyn_13", 1923.415, -189.9675, 47, "CHAR120_MSTEP6_1_NPC3");
		
		// Asana
		//-------------------------------------------------------------------------
		AddNpc(152001, "Asana", "f_katyn_13", 2014, -226, 47, "CHAR120_MSTEP5_2_NPC3");
		
		// Eimantas
		//-------------------------------------------------------------------------
		AddNpc(147481, "Eimantas", "f_katyn_13", 1987.851, -252.8366, 90, "CHAR120_MSTEP5_NPC2");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(20026, "", "f_katyn_13", 1066.655, -827.7272, 90, "", "CHAR220_MSETP2_2_1_GEN_INIT", "");
		
		// Eimantas
		//-------------------------------------------------------------------------
		AddNpc(155041, "Eimantas", "f_katyn_13", 1987.851, -252.8366, 90, "CHAR120_MSTEP5_NPC1", "CHAR120_MSTEP5_NPC1_IN");
	}
}
