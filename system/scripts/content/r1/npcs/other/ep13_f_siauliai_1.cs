//--- Melia Script ----------------------------------------------------------
// Lemprasa Pond
//--- Description -----------------------------------------------------------
// NPCs found in and around Lemprasa Pond.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai1NpcScript : GeneralScript
{
	public override void Load()
	{
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(150242, "Goddess Lada", "ep13_f_siauliai_1", 653.3237, -62.9277, 90, "EP13_F_SIAULIAI_1_MQ_LADA_1");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_1", 209.7904, 1027.33, 90, "", "EP13_F_SIAULIAI_1_MQ_04_TRACK_01", "");
		
		// Orsha
		//-------------------------------------------------------------------------
		AddNpc(40001, "Orsha", "ep13_f_siauliai_1", 2057.641, 336.1328, 122, "", "WARP_EP13_F_SIAULIAI_1_TO_ORSHA", "");
		
		// Woods of the Linked Bridges
		//-------------------------------------------------------------------------
		AddNpc(40001, "Woods of the Linked Bridges", "ep13_f_siauliai_1", -502.0264, -1813.892, -30, "", "WARP_EP13_F_SIAULIAI_1_TO_EP13_F_SIAULIAI_2", "");
		
		// Statue of Goddess Zemyna
		//-------------------------------------------------------------------------
		AddNpc(40110, "Statue of Goddess Zemyna", "ep13_f_siauliai_1", 16.08543, 1297.291, 68, "SIAU16_SQ_06_EV_NPC", "SIAU16_SQ_06_EV_NPC", "SIAU16_SQ_06_EV_NPC");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(150242, "Goddess Lada", "ep13_f_siauliai_1", 196.2018, 925.6906, 177, "EP13_F_SIAULIAI_1_MQ_LADA_2");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(150242, "Goddess Lada", "ep13_f_siauliai_1", -1008.734, 1413.523, 90, "EP13_F_SIAULIAI_1_MQ_LADA_3");
		
		// Unidentified Rigid Crevice
		//-------------------------------------------------------------------------
		AddNpc(150243, "Unidentified Rigid Crevice", "ep13_f_siauliai_1", -1683.593, -1334.366, 77, "EP13_F_SIAULIAI_1_MQ_06_CRACK");
		
		// [Kingdom Reconstruction]{nl}Orsha Soldier
		//-------------------------------------------------------------------------
		AddNpc(20060, "[Kingdom Reconstruction]{nl}Orsha Soldier", "ep13_f_siauliai_1", 1716.189, 244.781, 77, "EP13_F_SIAULIAI_1_REPUTATION_01");
		
		// Khonot Forest
		//-------------------------------------------------------------------------
		AddNpc(40001, "Khonot Forest", "ep13_f_siauliai_1", -439.4073, 1928.631, 164, "", "WARP_EP13_F_SIAULIAI_1_TO_BRACKEN42_1", "");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_1", 1839.385, 55.0285, 186, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_1");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_1", -440.3089, -1630.105, 90, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_2");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_1", 630.3462, -8.86555, 90, "", "EP13_F_SIAULIAI_1_SQ_02_TRG_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_1", 45.31827, -1266.722, 90, "", "EP13_F_SIAULIAI_1_SQ_04_TRG_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_1", -1444.172, -1291.195, 90, "", "EP13_F_SIAULIAI_1_SQ_05_TRG_NPC", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(40095, " ", "ep13_f_siauliai_1", -2108.929, -1352.854, 90, "", "EXPLORER_MISLE11", "");
		
		// Delmore Outskirts
		//-------------------------------------------------------------------------
		AddNpc(40001, "Delmore Outskirts", "ep13_f_siauliai_1", 872.61, 2039.003, 146, "", "WARP_EP13_F_SIAULIAI_1_TO_EP14_1_F_CASTLE_3", "");
	}
}
