//--- Melia Script ----------------------------------------------------------
// Woods of the Linked Bridges
//--- Description -----------------------------------------------------------
// NPCs found in and around Woods of the Linked Bridges.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai2NpcScript : GeneralScript
{
	public override void Load()
	{
		// Lemprasa Pond
		//-------------------------------------------------------------------------
		AddNpc(40001, "Lemprasa Pond", "ep13_f_siauliai_2", 3378.182, -671.4368, 90, "", "WARP_EP13_F_SIAULIAI_2_TO_EP13_F_SIAULIAI_1", "");
		
		// Paupys Crossing
		//-------------------------------------------------------------------------
		AddNpc(40001, "Paupys Crossing", "ep13_f_siauliai_2", 898.933, 1795.521, 166, "", "WARP_EP13_F_SIAULIAI_2_TO_EP13_F_SIAULIAI_3", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(150242, "Goddess Lada", "ep13_f_siauliai_2", 2521.595, -910.572, 97, "EP13_F_SIAULIAI_2_MQ_LADA_1");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1268.405, -1029.074, 90, "EP13_F_SIAULIAI_2_MQ_03_CRACK");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1396.782, -895.5403, 263, "EP13_F_SIAULIAI_2_MQ_03_CRACK");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(150243, "Mirtinas Crevice", "ep13_f_siauliai_2", 1137.989, -839.8904, 6, "EP13_F_SIAULIAI_2_MQ_03_CRACK");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(150242, "Goddess Lada", "ep13_f_siauliai_2", 738.2251, -629.3263, 12, "EP13_F_SIAULIAI_2_MQ_LADA_2");
		
		// Beholder's Black Crystal
		//-------------------------------------------------------------------------
		AddNpc(150245, "Beholder's Black Crystal", "ep13_f_siauliai_2", -1185.698, -1127.989, 84, "EP13_F_SIAULIAI_2_MQ_04_BLACKCRYSTAL");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150246, " ", "ep13_f_siauliai_2", -1185.326, -1126.53, 90, "", "EP13_F_SIAULIAI_2_MQ_04_SMOKE", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150247, " ", "ep13_f_siauliai_2", -1186.76, -1127.079, 40, "", "EP13_F_SIAULIAI_2_MQ_05_AFTER", "");
		
		// Beholder's Black Crystal
		//-------------------------------------------------------------------------
		AddNpc(150245, "Beholder's Black Crystal", "ep13_f_siauliai_2", 487.0453, 571.4534, 90, "EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150242, "", "ep13_f_siauliai_2", 546.6949, 618.324, 46, "EP13_F_SIAULIAI_2_MQ_LADA_3");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150246, " ", "ep13_f_siauliai_2", 487.1336, 570.8532, 90, "", "EP13_F_SIAULIAI_2_MQ_06_SMOKE", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(150247, " ", "ep13_f_siauliai_2", 485.1155, 572.2502, 46, "", "EP13_F_SIAULIAI_2_MQ_07_AFTER", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_2", 641.5677, 1436.733, 90, "", "EP13_F_SIAULIAI_2_MQ_08_TRACK_1", "");
		
		// Statue of Goddess Vakarine
		//-------------------------------------------------------------------------
		AddNpc(40120, "Statue of Goddess Vakarine", "ep13_f_siauliai_2", 2428.743, -912.3688, 45, "WARP_EP13_F_SIAULIAI_2", "STOUP_CAMP", "STOUP_CAMP");
		
		// [Kingdom Reconstruction]{nl}Orsha Volunteer
		//-------------------------------------------------------------------------
		AddNpc(20059, "[Kingdom Reconstruction]{nl}Orsha Volunteer", "ep13_f_siauliai_2", 3219.082, -656.717, 22, "EP13_F_SIAULIAI_2_REPUTATION_01");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_2", 3112.793, -658.1342, -6, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_1");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_2", 840.0926, 1744.823, 6, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_2");
		
		// Saint's Sacellum
		//-------------------------------------------------------------------------
		AddNpc(154065, "Saint's Sacellum", "ep13_f_siauliai_2", -371.0349, -1465.935, 90, "GODDESS_RAID_VASILISSA_PORTAL");
		
		// [Arbalester Master]{nl} Vilnius
		//-------------------------------------------------------------------------
		AddNpc(150213, "[Arbalester Master]{nl} Vilnius", "ep13_f_siauliai_2", -345.8438, -1432.316, 105, "MASTER_ARBALESTER_NPC");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "ep13_f_siauliai_2", -1286.507, 471.8385, 90, "", "EXPLORER_MISLE12", "");
		
		// Novaha Institute
		//-------------------------------------------------------------------------
		AddNpc(40001, "Novaha Institute", "ep13_f_siauliai_2", 2048.08, 1031.038, 94, "", "WARP_EP13_F_SIAULIAI_2_TO_EP15_1_FABBEY_1", "");
	}
}
