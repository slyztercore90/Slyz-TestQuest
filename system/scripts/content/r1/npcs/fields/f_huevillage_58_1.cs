//--- Melia Script ----------------------------------------------------------
// Veja Ravine
//--- Description -----------------------------------------------------------
// NPCs found in and around Veja Ravine.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class FHuevillage581NpcScript : GeneralScript
{
	public override void Load()
	{
		// Old Man of Andale Village
		//-------------------------------------------------------------------------
		AddNpc(147396, "Old Man of Andale Village", "f_huevillage_58_1", 200, -1300, 101, "HUEVILLAGE_58_1_MQ01_NPC");
		
		// Holy Pond
		//-------------------------------------------------------------------------
		AddNpc(147372, "Holy Pond", "f_huevillage_58_1", -973.57, 983.3, 90, "HUEVILLAGE_58_1_MQ02_NPC");
		
		// Corrupted Pond 1
		//-------------------------------------------------------------------------
		AddNpc(20026, "Corrupted Pond 1", "f_huevillage_58_1", -985, 1035, 90, "", "HUEVILLAGE_58_1_MQ02_SMOKE_01", "");
		
		// Injured Villager
		//-------------------------------------------------------------------------
		AddNpc(147407, "Injured Villager", "f_huevillage_58_1", -232, -434, 190, "HUEVILLAGE_58_1_MQ03_NPC");
		
		// Nugria Altar
		//-------------------------------------------------------------------------
		AddNpc(47124, "Nugria Altar", "f_huevillage_58_1", -1250, 490, 60, "HUEVILLAGE_58_1_PORTAL");
		
		// Nefritas Cliff
		//-------------------------------------------------------------------------
		AddNpc(40001, "Nefritas Cliff", "f_huevillage_58_1", 1562.31, -1187.531, 79, "", "HUEVILLAGE58_1_TO_GELE573", "");
		
		// Vieta Gorge
		//-------------------------------------------------------------------------
		AddNpc(40001, "Vieta Gorge", "f_huevillage_58_1", -719.62, -402.6, -51, "", "HUEVILLAGE58_1_TO_HUEVILLAGE58_2", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "f_huevillage_58_1", 217.9083, -916.1648, 79, "WARP_F_HUEVILLAGE_58_1", "STOUP_CAMP", "STOUP_CAMP");
		
		// HUEVILLAGE_58_1_MQ11_TRIGGER
		//-------------------------------------------------------------------------
		AddNpc(20026, "HUEVILLAGE_58_1_MQ11_TRIGGER", "f_huevillage_58_1", -1044.6, 415.3144, 90, "", "HUEVILLAGE_58_1_MQ11_TRIGGER", "");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -428.3319, 946.6636, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -279.0617, 996.8748, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -41.62195, 901.6882, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -179.4038, 827.4052, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -274.3823, 680.8425, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// HUEVILLAGE_58_3_MQ04_Trigger for return
		//-------------------------------------------------------------------------
		AddNpc(20026, "HUEVILLAGE_58_3_MQ04_Trigger for return", "f_huevillage_58_1", -511.3197, -277.6531, 90, "", "HUEVILLAGE_58_3_MQ04_TO_HUE1", "");
		
		// Source of Corruption
		//-------------------------------------------------------------------------
		AddNpc(147372, "Source of Corruption", "f_huevillage_58_1", -330.3746, 809.6934, 90, "HUEVILLAGE_58_1_SQ02_NPC");
		
		// Gytis Settlement Area
		//-------------------------------------------------------------------------
		AddNpc(40001, "Gytis Settlement Area", "f_huevillage_58_1", 222.0356, -1974.421, -22, "", "HUEVILLAGE_58_1_SIAUL50_1", "");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(40070, "To the other side", "f_huevillage_58_1", 647.6614, -188.8819, 0, "HUEVILLAGE_58_1_CABLETEMP_01");
		
		// To the other side
		//-------------------------------------------------------------------------
		AddNpc(40070, "To the other side", "f_huevillage_58_1", 632.8807, 596.5604, 0, "HUEVILLAGE_58_1_CABLETEMP_02");
		
		// Klaipeda Mayor's Spirit
		//-------------------------------------------------------------------------
		AddNpc(155022, "Klaipeda Mayor's Spirit", "f_huevillage_58_1", 259.65, -656.01, 90, "KLAIPEDA_MAYER");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(40095, "", "f_huevillage_58_1", 429.9816, -890.0194, 135, "PARTY_Q4_TRIGGER");
		
		// Spirit Eye
		//-------------------------------------------------------------------------
		AddNpc(151022, "Spirit Eye", "f_huevillage_58_1", 429.9816, -890.0194, 90, "PARTY_Q41_ORB");
		
		// Lv1 Treasure Chest
		//-------------------------------------------------------------------------
		AddNpc(147392, "Lv1 Treasure Chest", "f_huevillage_58_1", -315.6, -1374.85, 180, "TREASUREBOX_LV_F_HUEVILLAGE_58_150");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "f_huevillage_58_1", 263.469, 928.6599, 90, "", "EXPLORER_MISLE10", "");
	}
}
