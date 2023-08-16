//--- Melia Script ----------------------------------------------------------
// Paupys Crossing
//--- Description -----------------------------------------------------------
// NPCs found in and around Paupys Crossing.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai3NpcScript : GeneralScript
{
	public override void Load()
	{
		// Woods of the Linked Bridges
		//-------------------------------------------------------------------------
		AddNpc(2, 40001, "Woods of the Linked Bridges", "ep13_f_siauliai_3", 2687.554, 171.9151, -591.4047, 61, "", "WARP_EP13_F_SIAULIAI_3_TO_EP13_F_SIAULIAI_2", "");
		
		// Issaugoti Forest
		//-------------------------------------------------------------------------
		AddNpc(3, 40001, "Issaugoti Forest", "ep13_f_siauliai_3", -1412.676, 84.8867, 868.9893, -78, "", "WARP_EP13_F_SIAULIAI_3_TO_EP13_F_SIAULIAI_4", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(5, 150242, "Goddess Lada", "ep13_f_siauliai_3", 2324.633, 171.9151, -682.0194, 86, "EP13_F_SIAULIAI_3_MQ_LADA_1", "", "");
		AddNpc(6, 150243, " ", "ep13_f_siauliai_3", 1968.571, 209.7152, -531.2291, 33, "", "", "");
		AddNpc(7, 150243, " ", "ep13_f_siauliai_3", 2125.865, 209.7152, -293.438, 44, "", "", "");
		AddNpc(8, 150243, " ", "ep13_f_siauliai_3", 1272.606, 209.7152, 14.1655, 28, "", "", "");
		AddNpc(9, 150243, " ", "ep13_f_siauliai_3", 1593.662, 283.6958, 408.0826, 29, "", "", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(10, 150242, "Goddess Lada", "ep13_f_siauliai_3", 1635.93, 283.6958, 583.6829, -1, "EP13_F_SIAULIAI_3_MQ_LADA_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(11, 147469, " ", "ep13_f_siauliai_3", 729.0203, 280.5747, -488.0904, 90, "", "EP13_F_SIAULIAI_3_MQ_04_TRACK_1", "");
		
		// Baiga
		//-------------------------------------------------------------------------
		AddNpc(12, 150210, "Baiga", "ep13_f_siauliai_3", 558.6793, 209.7152, 707.8093, 259, "EP13_F_SIAULIAI_3_MQ_BAIGA_1", "", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(13, 150242, "Goddess Lada", "ep13_f_siauliai_3", 1077.382, 318.8113, 1663.918, 13, "EP13_F_SIAULIAI_3_MQ_LADA_3", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(14, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", 1218.274, 318.8113, 1529.972, 90, "EP13_F_SIAULIAI_3_MQ_06_CRACK_1", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(15, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", 1059.105, 318.8113, 1488.362, -5, "EP13_F_SIAULIAI_3_MQ_06_CRACK_2", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(16, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", 826.5458, 318.8113, 1502.519, 28, "EP13_F_SIAULIAI_3_MQ_06_CRACK_3", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(17, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", 917.0594, 318.8113, 1358.09, -86, "EP13_F_SIAULIAI_3_MQ_06_CRACK_4", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(18, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", 774.1691, 318.8113, 1278.837, 90, "EP13_F_SIAULIAI_3_MQ_06_CRACK_5", "", "");
		
		// Mirtinas Crevice
		//-------------------------------------------------------------------------
		AddNpc(19, 150243, "Mirtinas Crevice", "ep13_f_siauliai_3", -398.411, 84.8867, 504.522, 75, "EP13_F_SIAULIAI_3_MQ_07_CRACK_1", "", "");
		
		// Goddess Lada
		//-------------------------------------------------------------------------
		AddNpc(20, 150242, "Goddess Lada", "ep13_f_siauliai_3", -1308.81, 84.8867, 1047.764, 48, "EP13_F_SIAULIAI_3_MQ_LADA_4", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(21, 147469, " ", "ep13_f_siauliai_3", -394.8064, 84.8867, 492.9374, 90, "", "EP13_F_SIAULIAI_3_MQ_07_TRACK_1", "");
		
		// [Kingdom Reconstruction]{nl}Orsha Investigator
		//-------------------------------------------------------------------------
		AddNpc(22, 151089, "[Kingdom Reconstruction]{nl}Orsha Investigator", "ep13_f_siauliai_3", 2573.041, 171.9151, -528.369, 8, "EP13_F_SIAULIAI_3_REPUTATION_01", "", "");
		AddNpc(23, 147363, " ", "ep13_f_siauliai_3", 2573.458, 171.9151, -528.2327, 90, "", "", "");
		
		// [Kingdom Reconstruction]{nl}Orsha Damage Recovery Team
		//-------------------------------------------------------------------------
		AddNpc(1092, 20064, "[Kingdom Reconstruction]{nl}Orsha Damage Recovery Team", "ep13_f_siauliai_3", 2324.811, 171.9151, -599.8713, 90, "EP13_SUB_RECONSTRUCTION_NPC_SIAU_3_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1093, 151020, " ", "ep13_f_siauliai_3", 1479.093, 209.7152, -544.364, 90, "EP13_F_SIAULIAI_3_SQ_02_CITIZEN_1", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1094, 151020, " ", "ep13_f_siauliai_3", -106.9248, 84.8867, 343.9305, 90, "EP13_F_SIAULIAI_3_SQ_02_CITIZEN_2", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1095, 151020, " ", "ep13_f_siauliai_3", 5.716775, 84.8867, 838.98, 90, "EP13_F_SIAULIAI_3_SQ_02_CITIZEN_3", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1096, 151020, " ", "ep13_f_siauliai_3", 556.6219, 209.7152, 845.7916, 90, "EP13_F_SIAULIAI_3_SQ_02_CITIZEN_4", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1097, 151020, " ", "ep13_f_siauliai_3", 1024.524, 209.7152, 1119.515, 90, "EP13_F_SIAULIAI_3_SQ_02_CITIZEN_5", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(1098, 147469, " ", "ep13_f_siauliai_3", 1130.749, 318.8113, 1530.166, 90, "", "EP13_F_SIAULIAI_3_HQ_01_TRG_1", "");
		
		// Ashaq Underground Prison 2F
		//-------------------------------------------------------------------------
		AddNpc(1099, 40001, "Ashaq Underground Prison 2F", "ep13_f_siauliai_3", 1235.945, 318.8113, 1636.257, 135, "", "WARP_EP13_F_SIAULIAI_3_TO_EP13_2_D_PRISON_2", "");
		
		// Massive Kruvina Walls
		//-------------------------------------------------------------------------
		AddNpc(1101, 147469, "Massive Kruvina Walls", "ep13_f_siauliai_3", 384.2817, 84.8867, 1598.841, 90, "EP13_2_DPRISON2_MQ_NPC_1", "", "");
	}
}
