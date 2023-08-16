//--- Melia Script ----------------------------------------------------------
// Kirtimas Forest
//--- Description -----------------------------------------------------------
// NPCs found in and around Kirtimas Forest.
//---------------------------------------------------------------------------

using Melia.Shared.Tos.Const;
using Melia.Zone.Scripting;
using static Melia.Zone.Scripting.Shortcuts;

public class Ep13FSiauliai5NpcScript : GeneralScript
{
	public override void Load()
	{
		// Issaugoti Forest
		//-------------------------------------------------------------------------
		AddNpc(1, 40001, "Issaugoti Forest", "ep13_f_siauliai_5", -60.30424, 15.98207, -1271.741, -33, "", "WARP_EP13_F_SIAULIAI_5_TO_EP13_F_SIAULIAI_4", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(3, 20026, " ", "ep13_f_siauliai_5", -223.8069, 15.98207, -913.1422, 90, "", "EP13_F_SIAULIAI_5_MQ_01_TRIG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(4, 147469, " ", "ep13_f_siauliai_5", -211.1071, 15.98207, -916.3853, 90, "", "EP13_F_SIAULIAI_5_MQ_01_SCRL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(5, 147469, " ", "ep13_f_siauliai_5", -409.438, 15.98207, -729.9684, 90, "", "EP13_F_SIAULIAI_5_WAVE1", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(6, 147469, " ", "ep13_f_siauliai_5", -730.6722, 15.98207, 105.7543, 90, "", "EP13_F_SIAULIAI_5_ENDPOINT", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(7, 160047, "", "ep13_f_siauliai_5", -500.6208, 15.98207, 139.8066, 21, "EP13_F_SIAULIAI_5_RAGANA", "", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(8, 151018, " ", "ep13_f_siauliai_5", -121.5226, 15.98207, -38.72401, 90, "", "EP13_F_SIAULIAI_5_WAVE2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(9, 150210, "", "ep13_f_siauliai_5", 977.57, 15.98207, 214.0969, 9, "EP13_F_SIAULIAI_5_BAIGA", "", "");
		
		// [Kingdom Reconstruction] Orsha Messenger
		//-------------------------------------------------------------------------
		AddNpc(10, 20059, "[Kingdom Reconstruction] Orsha Messenger", "ep13_f_siauliai_5", -718.8827, 15.98207, 885.5436, -15, "EP13_F_SIAULIAI_5_REPUTATION_01", "", "");
		AddNpc(11, 147363, "", "ep13_f_siauliai_5", -721.6089, 15.98207, 884.7151, 90, "", "", "");
		
		// Delmore Hamlet
		//-------------------------------------------------------------------------
		AddNpc(1020, 40001, "Delmore Hamlet", "ep13_f_siauliai_5", 165.2721, 15.98207, 984.2814, 169, "", "WARP_EP13_F_SIAULIAI_5_TO_EP14_1_F_CASTLE_1", "");
		
		// Unknown Sanctuary
		//-------------------------------------------------------------------------
		AddNpc(1023, 147507, "Unknown Sanctuary", "ep13_f_siauliai_5", -840.9134, 15.98207, 881.069, 90, "UNKNOWN_SANTUARY_GATE_NORMAL", "", "");
	}
}
