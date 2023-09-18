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
		AddNpc(40001, "Issaugoti Forest", "ep13_f_siauliai_5", -60.30424, -1271.741, -33, "", "WARP_EP13_F_SIAULIAI_5_TO_EP13_F_SIAULIAI_4", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(20026, " ", "ep13_f_siauliai_5", -223.8069, -913.1422, 90, "", "EP13_F_SIAULIAI_5_MQ_01_TRIG", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_5", -211.1071, -916.3853, 90, "", "EP13_F_SIAULIAI_5_MQ_01_SCRL", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_5", -409.438, -729.9684, 90, "", "EP13_F_SIAULIAI_5_WAVE1", "");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(147469, " ", "ep13_f_siauliai_5", -730.6722, 105.7543, 90, "", "EP13_F_SIAULIAI_5_ENDPOINT", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(160047, "", "ep13_f_siauliai_5", -500.6208, 139.8066, 21, "EP13_F_SIAULIAI_5_RAGANA");
		
		//  
		//-------------------------------------------------------------------------
		AddNpc(151018, " ", "ep13_f_siauliai_5", -121.5226, -38.72401, 90, "", "EP13_F_SIAULIAI_5_WAVE2", "");
		
		// 
		//-------------------------------------------------------------------------
		AddNpc(150210, "", "ep13_f_siauliai_5", 977.57, 214.0969, 9, "EP13_F_SIAULIAI_5_BAIGA");
		
		// [Kingdom Reconstruction] Orsha Messenger
		//-------------------------------------------------------------------------
		AddNpc(20059, "[Kingdom Reconstruction] Orsha Messenger", "ep13_f_siauliai_5", -718.8827, 885.5436, -15, "EP13_F_SIAULIAI_5_REPUTATION_01");
		
		// Delmore Hamlet
		//-------------------------------------------------------------------------
		AddNpc(40001, "Delmore Hamlet", "ep13_f_siauliai_5", 165.2721, 984.2814, 169, "", "WARP_EP13_F_SIAULIAI_5_TO_EP14_1_F_CASTLE_1", "");
		
		// Unknown Sanctuary
		//-------------------------------------------------------------------------
		AddNpc(147507, "Unknown Sanctuary", "ep13_f_siauliai_5", -840.9134, 881.069, 90, "UNKNOWN_SANTUARY_GATE_NORMAL");
	}
}
